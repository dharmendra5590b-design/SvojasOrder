using Common;
using Domain;
using Domain.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;

namespace SvojasOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ResponseDE> ValidateUser(LoginRequestDE pobjLoginRequestDE)
        {
            ResponseDE responseDE=new ResponseDE();
            try
            {
                responseDE = await _loginService.ValidateUser(pobjLoginRequestDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex.Message);
                responseDE.Message = "Something went wrong.";
                responseDE.Status = -1;
                return responseDE;
            }
        }
    }
    
 }
