using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICustomerService
    {
        Task<ResponseDE> GetCustomer(CustomerDE pobjCustomerDE);
        Task<ResponseDE> SaveCustomer(CustomerDE pobjCustomerDE);
    }
}
