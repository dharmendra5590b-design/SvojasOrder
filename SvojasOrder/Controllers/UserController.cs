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
    
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

       
        [HttpPost]
        public async Task<ResponseDE> SaveUser(UserDE pobjUserDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _userService.SaveUser(pobjUserDE);
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
