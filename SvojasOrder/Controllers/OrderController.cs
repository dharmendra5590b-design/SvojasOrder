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
                    Quantity=dto.Quantity,
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
                    Back_Image_URL = await SaveFile(dto.backImage),
                    Mode=dto.Order_ID>0?"M":"A",                    
                    Reorder_Type=dto.Reorder_Type,

                };
                order.Mode = dto.Mode == "R" ? dto.Mode : order.Mode;
                order.Front_Image_URL = string.IsNullOrEmpty(order.Front_Image_URL) ? Utility.GetRelativePath(dto.Front_Image_URL) : order.Front_Image_URL;
                order.Back_Image_URL = string.IsNullOrEmpty(order.Back_Image_URL) ? Utility.GetRelativePath(dto.Back_Image_URL) : order.Back_Image_URL;
                order.Top_Image_URL = string.IsNullOrEmpty(order.Top_Image_URL) ? Utility.GetRelativePath(dto.Top_Image_URL) : order.Top_Image_URL;
                order.Side_Image_URL = string.IsNullOrEmpty(order.Side_Image_URL) ? Utility.GetRelativePath(dto.Side_Image_URL) : order.Side_Image_URL;
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

        [HttpPost]
        public async Task<ResponseDE> CancelOrder(OrderCancelRequestDE orderCancelRequestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
               
                responseDE = await _orderService.AMDCancelOrder(orderCancelRequestDE);

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

        [HttpGet]
        public async Task<List<OrderViewInfoDE>> GetOrderView(int OrderID)
        {
            List<OrderViewInfoDE> dataObj = new List<OrderViewInfoDE>();
            try
            {
                dataObj = await _orderService.GetOrderView(OrderID);
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderDesignInfoDE>> GetPendingDesingOrder()
        {
            List<OrderDesignInfoDE> dataObj = new List<OrderDesignInfoDE>();
            try
            {
                dataObj = await _orderService.GetPendingDesingOrder();
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderDesignInfoDE>> GetDesingOrder(int DesignerID)
        {
            List<OrderDesignInfoDE> dataObj = new List<OrderDesignInfoDE>();
            try
            {
                dataObj = await _orderService.GetDesingOrder(DesignerID);
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderReworkInfoDE>> GetReworkOrder()
        {
            List<OrderReworkInfoDE> dataObj = new List<OrderReworkInfoDE>();
            try
            {
                dataObj = await _orderService.GetReworkOrder();
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderDesignUploadInfoDE>> GetDesignUploadOrder()
        {
            List<OrderDesignUploadInfoDE> dataObj = new List<OrderDesignUploadInfoDE>();
            try
            {
                dataObj = await _orderService.GetDesignUploadOrder();
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderPendingConfirmationInfoDE>> GetPendingOrderConfirmation()
        {
            List<OrderPendingConfirmationInfoDE> dataObj = new List<OrderPendingConfirmationInfoDE>();
            try
            {
                dataObj = await _orderService.GetPendingOrderConfirmation();
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderConfirmedInfo>> GetConfirmedOrder()
        {
            List<OrderConfirmedInfo> dataObj = new List<OrderConfirmedInfo>();
            try
            {
                dataObj = await _orderService.GetConfirmedOrder();
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<OrderUnderProductionInfoDE>> GetUnderProductionOrder()
        {
            List<OrderUnderProductionInfoDE> dataObj = new List<OrderUnderProductionInfoDE>();
            try
            {
                dataObj = await _orderService.GetUnderProductionOrder();
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpGet]
        public async Task<List<EmployeeDE>> GetOperator(int OrderID)
        {
            List<EmployeeDE> dataObj = new List<EmployeeDE>();
            try
            {
                dataObj = await _orderService.GetOperator(OrderID);
                return dataObj;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
                return dataObj;
            }
        }

        [HttpPost]
        public async Task<ResponseDE> AssignDesigner(OrderDesignRequestDE requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {

                responseDE = await _orderService.AMDAssignDesigner(requestDE);

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

        [HttpPost]
        public async Task<ResponseDE> OrderDesingUploadCAD(OrderDesingUploadRequest requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                var OrderUpload = new OrderDesingUploadDE
                {
                    Order_ID = requestDE.Order_ID,
                    CAD_Image_URL = await SaveFile(requestDE.CADImage)
                };
                responseDE = await _orderService.AMDOrderDesingUpload(OrderUpload);

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


        [HttpPost]
        public async Task<ResponseDE> OrderDesignApprove(OrderDesignApproveDE request)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {

                responseDE = await _orderService.AMDOrderDesignApprove(request);

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

        [HttpPost]
        public async Task<ResponseDE> CreateReOrder(ReOrderDE requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                
                responseDE = await _orderService.CreateReOrder(requestDE);

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

        [HttpPost]
        public async Task<ResponseDE> OrderReworkDtl(OrderReworkDtlDto requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                var OrderRequest = new OrderReworkDtlDE
                {
                    Order_ID = requestDE.Order_ID,
                    User_ID = requestDE.User_ID,
                    Specification = requestDE.Specification,
                    Rework_Image_URL = await SaveFile(requestDE.CADImage)
                };
                responseDE = await _orderService.OrderReworkDtl(OrderRequest);

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

        [HttpPost]
        public async Task<ResponseDE> OrderAssignToProduction(OrderAssignToProductionDE requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {                
                responseDE = await _orderService.OrderAssignToProduction(requestDE);

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

        [HttpPost]
        public async Task<ResponseDE> OrderComplete(OrderCompleteDE requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                responseDE = await _orderService.OrderComplete(requestDE);
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

        [HttpPost]
        public async Task<ResponseDE> CustomerOrderConfirm(OrderConfirmDE requestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                responseDE = await _orderService.CustomerOrderConfirm(requestDE);

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
        public IActionResult Download(string fileName, string downloadFileName)
        {
            string uploadFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/"+ fileName);
            if (!System.IO.File.Exists(uploadFolder))
                return NotFound();

            var stream = new FileStream(uploadFolder, FileMode.Open, FileAccess.Read);

            return File(stream, "application/octet-stream", downloadFileName+ Path.GetExtension(fileName));
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

            return "uploads/" + fileName;
        }


    }

}
