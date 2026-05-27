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
    }
    
 }
