using Domain;
using Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ILoginService
    {
        Task<ResponseDE> ValidateUser(LoginRequestDE pobjLoginRequestDE);
        Task<ResponseDE> ChangePassword(ChangePasswordDE pobjChangePasswordDE);
    }
}
