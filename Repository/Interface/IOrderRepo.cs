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
        Task<ResponseDE> AMDCancelOrder(OrderCancelRequestDE orderCancelRequestDE);
        Task<ResponseDE> AMDOrderDesingUpload(OrderDesingUploadDE request);
        Task<ResponseDE> AMDOrderAssignToProduction(OrderAssignToProductionDE request);
        Task<ResponseDE> AMDOrderComplete(OrderCompleteDE request);
        Task<DataTable> GetOrder(OrderSearchDE orderSearchDE);
        Task<DataTable> GetOrderView(int OrderID);
        Task<DataTable> GetOrderPrint(int OrderID);
        Task<DataSet> GetOrderEmail(int OrderID);
        Task<DataTable> GetPendingDesingOrder();
        Task<DataTable> GetDesingOrder(int DesignerID);
        Task<DataTable> GetOperator(int OrderID);
        Task<DataTable> GetReworkOrder();
        Task<DataTable> GetDesignUploadedOrder();
        Task<DataTable> GetPendingOrderConfirmation();
        Task<DataTable> GetConfirmedOrder();
        Task<DataTable> GetUnderProductionOrder();
        Task<ResponseDE> AMDAssignDesigner(OrderDesignRequestDE request);
        Task<ResponseDE> AMDOrderDesignApprove(OrderDesignApproveDE request);
        Task<ResponseDE> AMDCreateReOrder(ReOrderDE request);
        Task<ResponseDE> AMDOrderReworkDtl(OrderReworkDtlDE request);
        Task<ResponseDE> AMDCustomerOrderConfirm(OrderConfirmDE request);
    }
}
