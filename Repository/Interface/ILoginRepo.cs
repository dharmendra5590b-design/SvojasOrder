using Domain;
using Domain.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ILoginRepo
    {
        Task<ResponseDE> ValidateUser(LoginRequestDE loginRequestDE);
        Task<ResponseDE> ChangePassword(ChangePasswordDE changePassword);
    }
}
