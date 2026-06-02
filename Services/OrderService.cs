using Common;
using Domain;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService: IOrderService
    {
        public readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderListDE> GetListCustomerOrder()
        {
            try
            {
                OrderListDE orderList = new OrderListDE();
                DataSet dataSet=await _orderRepo.GetListCustomerOrder();
                orderList.Design = Utility.ConvertToSelectList(dataSet.Tables[0], "Misc_Name", "Misc_ID");
                orderList.Karat = Utility.ConvertToSelectList(dataSet.Tables[1], "Misc_Name", "Misc_ID");
                orderList.DesignType = Utility.ConvertToSelectList(dataSet.Tables[2], "Misc_Name", "Misc_ID");
                orderList.GoldColor = Utility.ConvertToSelectList(dataSet.Tables[3], "Misc_Name", "Misc_ID");
                orderList.Stones = Utility.ConvertToSelectList(dataSet.Tables[4], "Misc_Name", "Misc_ID");
                orderList.ClrStone = Utility.ConvertToSelectList(dataSet.Tables[5], "Misc_Name", "Misc_ID");
                orderList.Certificate = Utility.ConvertToSelectList(dataSet.Tables[6], "Misc_Name", "Misc_ID");
                orderList.Quality = Utility.ConvertToSelectList(dataSet.Tables[7], "Misc_Name", "Misc_ID");
                return orderList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> SaveOrder(OrderRequestDE orderRequestDE)
        {
            try
            {
               
                return await _orderRepo.AMDOrderRequest(orderRequestDE);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
