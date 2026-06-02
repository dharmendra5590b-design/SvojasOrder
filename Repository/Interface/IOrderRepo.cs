using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRepo
    {
        Task<DataSet> GetListCustomerOrder();
        Task<ResponseDE> AMDOrderRequest(OrderRequestDE orderRequest);
    }
}
