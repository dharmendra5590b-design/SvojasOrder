using Domain;
using Domain.Login;
using Repository;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<ResponseDE> SaveUser(UserDE pobjUserDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _userRepo.AMDUser(pobjUserDE);

                return responseDE;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
