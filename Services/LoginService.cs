using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginService)
        {
            _loginRepository = loginService;
        }
    }
}
