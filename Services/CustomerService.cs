using Domain.Login;
using Domain;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class CustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<ResponseDE> GetCustomer(CustomerDE pobjCustomerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                CustomerDE dataObj = new CustomerDE();
                DataTable dataTable = await _customerRepo.GetCustomer(pobjCustomerDE);
                foreach (DataRow drrow in dataTable.Rows)
                {
                    dataObj.Customer_ID = Convert.ToInt32(drrow["Customer_ID"]);
                    dataObj.Customer_Name = Convert.ToString(drrow["Customer_Name"]);
                    dataObj.Entity_ID = Convert.ToInt32(drrow["Entity_ID"]);
                    dataObj.User_Type = Convert.ToString(drrow["User_Type"]);
                    dataObj.User_ID = Convert.ToInt32(drrow["User_ID"]);
                }
                responseDE.StatusCode = 1;
                responseDE.data = dataObj;
                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> ChangePassword(ChangePasswordDE pobjChangePasswordDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                UserEntityDE userEntityDE = new UserEntityDE();
                responseDE = await _loginRepository.ChangePassword(pobjChangePasswordDE);

                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
