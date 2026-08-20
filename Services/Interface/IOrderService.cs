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
        Task<ResponseDE> AMDCancelOrder(OrderCancelRequestDE orderCancelRequestDE);
        Task<List<OrderDetailDE>> GetOrderDetail(OrderSearchDE orderSearchDE);
        Task<List<OrderDetailsGridDE>> GetGridOrder(OrderSearchDE orderSearchDE);
        Task<List<OrderViewInfoDE>> GetOrderView(int OrderID, int? UserID);
        Task<List<OrderPrintReportDE>> GetOrderPrint(int OrderID);
        Task<List<DesignerPrintDE>> GetDesginerPrint(int OrderID);
        Task<List<EmployeeDE>> GetOperator(int OrderID);
        Task<List<OrderDesignInfoDE>> GetPendingDesingOrder();
        Task<List<OrderDesignInfoDE>> GetDesingOrder(int DesignerID);
        Task<List<OrderDesignInfoDE>> GetDesingerOrderReport(int DesignerID);
        Task<List<OrderReworkInfoDE>> GetReworkOrder();
        Task<List<OrderDesignUploadInfoDE>> GetDesignUploadOrder();
        Task<List<OrderPendingConfirmationInfoDE>> GetPendingOrderConfirmation(int? customerID);
        Task<List<OrderConfirmedInfo>> GetConfirmedOrder();
        Task<List<OrderUnderProductionInfoDE>> GetUnderProductionOrder();
        Task<ResponseDE> AMDAssignDesigner(OrderDesignRequestDE requestDE);
        Task<ResponseDE> AMDOrderDesingUpload(OrderDesingUploadDE requestDE);
        Task<ResponseDE> AMDOrderDesignApprove(OrderDesignApproveDE request);
        Task<ResponseDE> CreateReOrder(ReOrderDE request);
        Task<ResponseDE> OrderReworkDtl(OrderReworkDtlDE request);
        Task<ResponseDE> CustomerOrderConfirm(OrderConfirmDE request);
        Task<ResponseDE> OrderAssignToProduction(OrderAssignToProductionDE request);
        Task<ResponseDE> OrderComplete(OrderCompleteDE request);
    }
}
