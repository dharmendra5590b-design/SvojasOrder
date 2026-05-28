using Common;
using Domain;
using Domain.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;
using SvojasOrder.Models;

namespace SvojasOrder.Controllers
{
    
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

       
        [HttpPost]
        public async Task<ResponseDE> SaveCustomer(CustomerDE pobjCustomerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.SaveCustomer(pobjCustomerDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }


        [HttpPost]
        public async Task<ResponseDE> GetCustomer(CustomerDE pobjCustomerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.GetCustomer(pobjCustomerDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> SaveEmployee(EmployeeDE pobjEmployeeDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.SaveEmployee(pobjEmployeeDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> GetEmployee(EmployeeDE pobjEmployeeDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.GetEmployee(pobjEmployeeDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpGet]
        public async Task<ResponseDE> GetCustomerMapping()
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.GetCustomerMapping();
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> GetCustomerMappingDtl(CustomerDE pobjCustomerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.GetCustomerMappingDtl(pobjCustomerDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> SaveCustomerMapping(CustomerMappingDE pobjCustomerMappingDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.SaveCustomerMapping(pobjCustomerMappingDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> SaveCustomerLedgerCredit(CustomerLedgerDE pobjCustomerLedgerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.SaveCustomerLedgerCredit(pobjCustomerLedgerDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> SaveCustomerLedgerDebit(CustomerLedgerDE pobjCustomerLedgerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.SaveCustomerLedgerDebit(pobjCustomerLedgerDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> GetCustomerLedger(CustomerDE pobjCustomerDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _customerService.GetCustomerLedger(pobjCustomerDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }


    }

}
