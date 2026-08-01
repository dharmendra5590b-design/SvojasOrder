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
    public class LoginService: ILoginService
    {
        private readonly ILoginRepo _loginRepository;
        public LoginService(ILoginRepo loginService)
        {
            _loginRepository = loginService;
        }
        public async Task<ResponseDE> ValidateUser(LoginRequestDE pobjLoginRequestDE)
        {
            ResponseDE responseDE=new ResponseDE();
            try
            {
                UserEntityDE userEntityDE = new UserEntityDE();
                responseDE = await _loginRepository.ValidateUser(pobjLoginRequestDE);
                if (responseDE.StatusCode==1)
                {
                    foreach (DataRow drrow in ((DataTable)responseDE.data).Rows)
                    {
                        userEntityDE.User_Name = Convert.ToString(drrow["User_Name"]);
                        userEntityDE.Entity_Name = Convert.ToString(drrow["Entity_Name"]);
                        userEntityDE.Entity_ID = Convert.ToInt32(drrow["Entity_ID"]);
                        userEntityDE.User_Type = Convert.ToString(drrow["User_Type"]);
                        userEntityDE.User_ID = Convert.ToInt32(drrow["User_ID"]);
                        userEntityDE.Is_Order_Available_For_Confirm = Convert.ToBoolean(drrow["Is_Order_Available_For_Confirm"]);
                    }
                }
                responseDE.data = userEntityDE;
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
