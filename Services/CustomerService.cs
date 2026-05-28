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
        public async Task<ResponseDE> SaveEmployee(EmployeeDE pobjEmployeeDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerRepo.AMDEmployee(pobjEmployeeDE);

                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ResponseDE> GetEmployee(EmployeeDE employeeDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                List<EmployeeDE> employeeDEs = new List<EmployeeDE>();
                DataTable dataTable = await _customerRepo.GetEmployee(employeeDE);
                foreach (DataRow drrow in dataTable.Rows)
                {
                    EmployeeDE dataObj = new EmployeeDE();
                    dataObj.Employee_ID = Convert.ToInt32(drrow["Employee_ID"]);
                    dataObj.Employee_Name = Convert.ToString(drrow["Employee_Name"]);
                    dataObj.Email_ID = Convert.ToString(drrow["Email_ID"]);
                    dataObj.Mobile_Number = Convert.ToString(drrow["Mobile_Number"]);
                    dataObj.Designation = Convert.ToString(drrow["Designation"]);
                    employeeDEs.Add(dataObj);
                }
                responseDE.StatusCode = 1;
                responseDE.data = employeeDEs;
                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> GetCustomerMapping()
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                List<CustomerMappingDE> dataObj = new List<CustomerMappingDE>();
                DataTable dataTable = await _customerRepo.GetCustomerMapping();
                foreach (DataRow drrow in dataTable.Rows)
                {
                    dataObj.Add(new CustomerMappingDE { Customer_ID = Convert.ToInt32(drrow["Customer_ID"]),
                    Customer_Name = Convert.ToString(drrow["Customer_ID"])
                    });
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

        public async Task<ResponseDE> GetCustomerMappingDtl(CustomerDE customerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                List<CustomerMappingDE> dataObj = new List<CustomerMappingDE>();
                DataTable dataTable = await _customerRepo.GetCustomerMappingDtl(customerDE);
                foreach (DataRow drrow in dataTable.Rows)
                {
                    dataObj.Add(new CustomerMappingDE
                    {
                        Employee_ID = Convert.ToInt32(drrow["Employee_ID"])
                    });
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

        public async Task<ResponseDE> SaveCustomerMapping(CustomerMappingDE customerMappingDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerRepo.AMDCustomerMapping(customerMappingDE);

                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
