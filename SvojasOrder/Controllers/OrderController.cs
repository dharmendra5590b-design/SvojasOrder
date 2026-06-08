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
        public async Task<ResponseDE> SaveOrder([FromForm] OrderRequestDto dto)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                var order = new OrderRequestDE
                {
                    Order_ID = dto.Order_ID,
                    Customer_ID = dto.Customer_ID,
                    Design_ID = dto.Design_ID,
                    Karat_ID = dto.Karat_ID,
                    Karat_Percent = dto.Karat_Percent,
                    Design_Type_ID = dto.Design_Type_ID,
                    Gold_Colour_ID = dto.Gold_Colour_ID,
                    Size = dto.Size,
                    Weight = dto.Weight,
                    Stone_ID = dto.Stone_ID,
                    Is_Colour_Required = dto.Is_Colour_Required,
                    Colour_Stone_ID = dto.Colour_Stone_ID,
                    Colour_Stone = dto.Colour_Stone,
                    Is_Certificate_Required = dto.Is_Certificate_Required,
                    Cretificate_ID = dto.Certificate_ID,
                    Diamond_Quality_ID = dto.Diamond_Quality_ID,
                    Diamond_Weight = dto.Diamond_Weight,
                    NoOf_Diamonds = dto.NoOf_Diamonds,
                    Delivery_Date = dto.Delivery_Date,
                    Specification = dto.Specification,

                    Front_Image_URL = await SaveFile(dto.frontImage),
                    Top_Image_URL = await SaveFile(dto.topImage),
                    Side_Image_URL = await SaveFile(dto.sideImage),
                    Back_Image_URL = await SaveFile(dto.backImage)
                };

                responseDE = await _orderService.SaveOrder(order);

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

        [HttpPost]
        public async Task<List<OrderDetailDE>> GetOrderDetail(OrderSearchDE pobOrderSearchDE)
        {
            List<OrderDetailDE> dataObj = new List<OrderDetailDE>();
            try
            {
                dataObj = await _orderService.GetOrderDetail(pobOrderSearchDE);
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpPost]
        public async Task<List<OrderDetailsGridDE>> GetGridOrder(OrderSearchDE pobOrderSearchDE)
        {
            List<OrderDetailsGridDE> dataObj = new List<OrderDetailsGridDE>();
            try
            {
                dataObj = await _orderService.GetGridOrder(pobOrderSearchDE);
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        private async Task<string?> SaveFile(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/uploads");

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            string fileName =
                Guid.NewGuid().ToString() +
                Path.GetExtension(file.FileName);

            string filePath = Path.Combine(uploadFolder, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "wwwroot/uploads/" + fileName;
        }

    }

}
