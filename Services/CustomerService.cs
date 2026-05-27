using Domain;
using Domain.Login;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService: ICustomerService
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
                List<CustomerDE> customerDEs = new List<CustomerDE>();
                DataTable dataTable = await _customerRepo.GetCustomer(pobjCustomerDE);
                foreach (DataRow drrow in dataTable.Rows)
                {
                    CustomerDE dataObj = new CustomerDE();
                    dataObj.Customer_ID = Convert.ToInt32(drrow["Customer_ID"]);
                    dataObj.Customer_Name = Convert.ToString(drrow["Customer_Name"]);
                    dataObj.Customer_Code = Convert.ToString(drrow["Customer_Code"]);
                    dataObj.Company_Name = Convert.ToString(drrow["Company_Name"]);
                    dataObj.Mobile_Number = Convert.ToString(drrow["Mobile_Number"]);
                    // dataObj.Amount_OpeningBalance = Convert.ToDecimal(drrow["Amount_OpeningBalance"]);
                    // dataObj.Gold_OpeningBalance = Convert.ToDecimal(drrow["Gold_OpeningBalance"]);
                    customerDEs.Add(dataObj);
                }
                responseDE.StatusCode = 1;
                responseDE.data = customerDEs;
                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> SaveCustomer(CustomerDE pobjCustomerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                 responseDE = await _customerRepo.AMDCustomer(pobjCustomerDE);

                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
