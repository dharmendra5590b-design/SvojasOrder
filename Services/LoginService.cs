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
                DataTable dtTable= await _loginRepository.ValidateUser(pobjLoginRequestDE);
                foreach (DataRow drrow in dtTable.Rows)
                {
                    userEntityDE.User_Name = Convert.ToString(drrow["User_Name"]);
                    userEntityDE.Entity_Name = Convert.ToString(drrow["Entity_Name"]);
                    userEntityDE.Entity_ID = Convert.ToInt32(drrow["Entity_ID"]);
                    userEntityDE.User_Type = Convert.ToString(drrow["User_Type"]);
                    userEntityDE.User_ID = Convert.ToInt32(drrow["User_ID"]);
                }
                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
