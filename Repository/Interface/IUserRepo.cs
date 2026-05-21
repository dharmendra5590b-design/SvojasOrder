using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepo
    {
        Task<ResponseDE> AMDUser(UserDE userDE);
    }
}
