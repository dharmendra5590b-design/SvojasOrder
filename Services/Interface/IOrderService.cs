using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderService
    {
        Task<OrderListDE> GetListCustomerOrder();
        Task<ResponseDE> SaveOrder(OrderRequestDE orderRequestDE);
        Task<List<OrderDetailDE>> GetOrderDetail(OrderSearchDE orderSearchDE);
        Task<List<OrderDetailsGridDE>> GetGridOrder(OrderSearchDE orderSearchDE);

    }
}
