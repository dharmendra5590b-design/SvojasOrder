using Common;
using Domain;
using Domain.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;
using SvojasOrder.Models;

namespace SvojasOrder.Controllers
{
    
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

       
        [HttpPost]
        public async Task<ResponseDE> SaveOrder(OrderRequestDE pobjOrderRequestDE)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {
                responseDE = await _orderService.SaveOrder(pobjOrderRequestDE);
                return responseDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                responseDE.Message = "Something went wrong.";
                responseDE.StatusCode = -1;
                return responseDE;
            }
        }

        [HttpGet]
        public async Task<OrderListDE> GetListCustomerOrder()
        {
            OrderListDE orderListDE = new OrderListDE();
            try
            {
                orderListDE = await _orderService.GetListCustomerOrder();
                return orderListDE;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return orderListDE;
            }
        }
    }
    
 }
