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
    
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly JwtSettings jwtSettings;
        public LoginController(ILoginService loginService, JwtSettings jwtSettings)
        {
            _loginService = loginService;
            this.jwtSettings = jwtSettings;
        }

        [HttpPost]
        public async Task<ResponseDE> ValidateUser(LoginRequestDE pobjLoginRequestDE)
        {
            ResponseDE responseDE=new ResponseDE();
            try
            {
                responseDE = await _loginService.ValidateUser(pobjLoginRequestDE);
                if (responseDE.StatusCode == 1)
                {
                    UserEntityDE _UserDE = (UserEntityDE)responseDE.data;
                    UserTokens Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = pobjLoginRequestDE.UserName,
                        GuidId = Guid.NewGuid(),
                        UserName = Convert.ToString(_UserDE.User_Name),
                        Id = Convert.ToString(_UserDE.User_ID),

                    }, jwtSettings);
                    _UserDE.token = Token.Token;
                    responseDE.data = _UserDE;
                }
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex.Message);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> ChangePassword(ChangePasswordDE pobjChangePasswordDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _loginService.ChangePassword(pobjChangePasswordDE);
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
