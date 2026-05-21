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
        Task<DataTable> ValidateUser(LoginRequestDE loginRequestDE);
        Task<DataTable> ChangePassword(ChangePasswordDE changePassword);
    }
}
