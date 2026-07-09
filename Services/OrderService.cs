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

        public async Task<List<OrderDetailsGridDE>> GetGridOrder(OrderSearchDE orderSearchDE)
        {
            try
            {
                orderSearchDE.mode = "S";
                DataTable dataTable = await _orderRepo.GetOrder(orderSearchDE);
                List<OrderDetailsGridDE> orders = new List<OrderDetailsGridDE>();

                foreach (DataRow dr in dataTable.Rows)
                {
                    orders.Add(new OrderDetailsGridDE
                    {
                        Order_ID = Convert.ToInt32(dr["Order_ID"]),
                        Order_Number = dr["Order_Number"]?.ToString(),
                        Order_Date = dr["Order_Date"]?.ToString(),
                        //Order_Type = dr["Order_Type"]?.ToString(),
                        Design_ID = Convert.ToInt32(dr["Design_ID"]),
                        Design = Convert.ToString(dr["Design"]),
                        Delivery_Date = dr["Delivery_Date"]?.ToString(),

                        Is_Assigned_Designer = dr["Is_Assigned_Designer"]?.ToString(),
                        Designer_Assgined_DT = dr["Assgined_To_Designer"]?.ToString(),

                        //Is_Design_Approved = dr["Is_Design_Approved"]?.ToString(),
                        Design_Approved_DT = dr["Design_Approved"]?.ToString(),

                        //Is_Order_Confirmed = dr["Is_Order_Confirmed"]?.ToString(),
                        Order_Confirmed_DT = dr["Order_Confirmed"]?.ToString(),

                        //Is_Assigned_Production = dr["Is_Assigned_Production"]?.ToString(),
                        Production_Assigned_DT = dr["Assigned_To_Production"]?.ToString(),

                        //Is_OrderCompleted = dr["Is_OrderCompleted"]?.ToString(),
                        Order_Completed_DT = dr["Order_Completed"]?.ToString()
                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderDetailDE>> GetOrderDetail(OrderSearchDE orderSearchDE)
        {
            try
            {
                orderSearchDE.mode = orderSearchDE.mode=="C"? orderSearchDE.mode: "S";
                DataTable dataTable = await _orderRepo.GetOrder(orderSearchDE);
                List<OrderDetailDE> orders = new List<OrderDetailDE>();

                foreach (DataRow dr in dataTable.Rows)
                {
                    orders.Add(new OrderDetailDE
                    {
                        Order_ID = dr.GetNullableInt("Order_ID") ?? 0,
                        Order_Number = dr.GetString("Order_Number"),
                        Order_Date = dr.GetNullableDateTime("Order_Date"),

                        Customer_ID = dr.GetNullableInt("Customer_ID"),
                        Design_ID = dr.GetNullableInt("Design_ID"),
                        Karat_ID = dr.GetNullableInt("Karat_ID"),
                        Karat_Percent = dr.GetNullableDecimal("Karat_Percent"),
                        Design_Type_ID = dr.GetNullableInt("Design_Type_ID"),
                        Gold_Colour_ID = dr.GetNullableInt("Gold_Colour_ID"),

                        Size = dr.GetString("Size"),
                        Weight = dr.GetNullableDecimal("Weight"),

                        Stone_ID = dr.GetNullableInt("Stone_ID"),

                        Is_Colour_Required = dr.GetBool("Is_Colour_Required"),
                        Colour_Stone_ID = dr.GetNullableInt("Colour_Stone_ID"),
                        Colour_Stone = dr.GetString("Colour_Stone"),
                        Quantity = dr.GetString("Quantity"),

                        Is_Certificate_Required = dr.GetBool("Is_Certificate_Required"),
                        Cretificate_ID = dr.GetNullableInt("Cretificate_ID"),
                        Diamond_Quality_ID = dr.GetNullableInt("Diamond_Quality_ID"),
                        Diamond_Weight = dr.GetNullableDecimal("Diamond_Weight"),
                        NoOf_Diamonds = dr.GetNullableInt("NoOf_Diamonds"),

                        Delivery_Date = dr.GetNullableDateTime("Delivery_Date"),
                        Specification = dr.GetString("Specification"),

                        Front_Image_URL = dr.GetString("Front_Image_URL"),
                        Top_Image_URL = dr.GetString("Top_Image_URL"),
                        Side_Image_URL = dr.GetString("Side_Image_URL"),
                        Back_Image_URL = dr.GetString("Back_Image_URL"),

                        IS_Editable = dr.GetBool("IS_Editable"),

                        Is_Design_Approved = dr.GetBool("Is_Design_Approved"),
                        CAD_Image_URL = dr.GetString("CAD_Image_URL"),

                        Designer_Weight = dr.GetNullableDecimal("Designer_Weight"),
                        Designer_Diamond_Weight = dr.GetNullableDecimal("Designer_Diamond_Weight"),
                        Designer_NoOf_Diamonds = dr.GetNullableInt("Designer_NoOf_Diamonds"),

                        Is_Confirmable = dr.GetBool("Is_Confirmable"),

                        Is_Order_Completed = dr.GetBool("Is_Order_Completed"),
                        Order_Complete_DT = dr.GetNullableDateTime("Order_Complete_DT"),

                        Final_Gross_Weight = dr.GetNullableDecimal("Final_Gross_Weight"),
                        Final_Noof_Diamonds = dr.GetNullableInt("Final_Noof_Diamonds"),
                        Final_Diamond_Weight = dr.GetNullableDecimal("Final_Diamond_Weight"),

                        NoOfColour_Stone = dr.GetNullableInt("NoOfColour_Stone"),
                        ColourStone_Weight = dr.GetNullableDecimal("ColourStone_Weight"),

                        Others_NoOfColour_Stone = dr.GetNullableInt("Others_NoOfColour_Stone"),
                        Others_Colour_Stone_Weight = dr.GetNullableDecimal("Others_Colour_Stone_Weight"),

                        Final_Net_Weight = dr.GetNullableDecimal("Final_Net_Weight")
                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderViewInfoDE>> GetOrderView(int OrderID)
        {
            try
            {
                DataTable dataTable = await _orderRepo.GetOrderView(OrderID);
                List<OrderViewInfoDE> orders = new List<OrderViewInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderViewInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = Convert.ToString(row["Order_Date"]),

                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null : Convert.ToString(row["Quantity"]),

                        Karat = Convert.ToString(row["Karat"]),
                        Karat_Percent = row["Karat_Percent"] == DBNull.Value ? null : Convert.ToString(row["Karat_Percent"]),

                        Design_Type = Convert.ToString(row["Design_Type"]),
                        Gold_Colour = Convert.ToString(row["Gold_Colour"]),

                        Size = Convert.ToString(row["Size"]),
                        Weight = row["Weight"] == DBNull.Value ? null : Convert.ToString(row["Weight"]),

                        Stone_Name = Convert.ToString(row["Stone_Name"]),
                        Is_Colour_Required = row["Is_Colour_Required"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_Colour_Required"]),

                        Colour_Stone_Name = Convert.ToString(row["Colour_Stone_Name"]),
                        Colour_Stone = row["Colour_Stone"] == DBNull.Value ? null : Convert.ToString(row["Colour_Stone"]),

                        Is_Certificate_Required = row["Is_Certificate_Required"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_Certificate_Required"]),
                        Cretificate_Name = Convert.ToString(row["Cretificate_Name"]),

                        Diamond_Quality = Convert.ToString(row["Diamond_Quality"]),
                        Diamond_Weight = row["Diamond_Weight"] == DBNull.Value ? null : Convert.ToString(row["Diamond_Weight"]),

                        NoOf_Diamonds = row["NoOf_Diamonds"] == DBNull.Value ? null : Convert.ToString(row["NoOf_Diamonds"]),

                        Delivery_Date = row["Delivery_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Delivery_Date"]),
                        Specification = Convert.ToString(row["Specification"]),

                        Front_Image_URL = Convert.ToString(row["Front_Image_URL"]),
                        Top_Image_URL = Convert.ToString(row["Top_Image_URL"]),
                        Side_Image_URL = Convert.ToString(row["Side_Image_URL"]),

                        Is_Design_Approved = Convert.ToBoolean(row["Is_Design_Approved"]),
                        CAD_Image_URL = Convert.ToString(row["CAD_Image_URL"]),

                        Designer_Weight = row["Designer_Weight"] == DBNull.Value ? null : Convert.ToString(row["Designer_Weight"]),
                        Designer_Diamond_Weight = row["Designer_Diamond_Weight"] == DBNull.Value ? null : Convert.ToString(row["Designer_Diamond_Weight"]),
                        Designer_NoOf_Diamonds = row["Designer_NoOf_Diamonds"] == DBNull.Value ? null : Convert.ToString(row["Designer_NoOf_Diamonds"]),

                        Is_Order_Completed = Convert.ToBoolean(row["Is_Order_Completed"]),
                        Order_Complete_DT = row["Order_Complete_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Order_Complete_DT"]),

                        Final_Gross_Weight = row["Final_Gross_Weight"] == DBNull.Value ? null : Convert.ToString(row["Final_Gross_Weight"]),
                        Final_Noof_Diamonds = row["Final_Noof_Diamonds"] == DBNull.Value ? null : Convert.ToInt32(row["Final_Noof_Diamonds"]),
                        Final_Diamond_Weight = row["Final_Diamond_Weight"] == DBNull.Value ? null : Convert.ToString(row["Final_Diamond_Weight"]),

                        NoOfColour_Stone = row["NoOfColour_Stone"] == DBNull.Value ? null : Convert.ToString(row["NoOfColour_Stone"]),
                        ColourStone_Weight = row["ColourStone_Weight"] == DBNull.Value ? null : Convert.ToString(row["ColourStone_Weight"]),

                        Others_NoOfColour_Stone = row["Others_NoOfColour_Stone"] == DBNull.Value ? null : Convert.ToString(row["Others_NoOfColour_Stone"]),
                        Others_Colour_Stone_Weight = row["Others_Colour_Stone_Weight"] == DBNull.Value ? null : Convert.ToString(row["Others_Colour_Stone_Weight"]),

                        Final_Net_Weight = row["Final_Net_Weight"] == DBNull.Value ? null : Convert.ToString(row["Final_Net_Weight"]),
                        Order_Status = row["Current_Order_Status"] == DBNull.Value ? null : Convert.ToString(row["Current_Order_Status"]),
                        adminSpecification = row["Current_Order_Status"] == DBNull.Value ? null : Convert.ToString(row["Admin_Specification"])
                    });

                };
                
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderDesignInfoDE>> GetPendingDesingOrder()
        {
            try
            {
              
                DataTable dataTable = await _orderRepo.GetPendingDesingOrder();
                List<OrderDesignInfoDE> orders = new List<OrderDesignInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderDesignInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] as DateTime?,
                        Customer_Name = Convert.ToString(row["Customer_Name"]),
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null : Convert.ToString(row["Quantity"]),
                        Delivery_Date = row["Delivery_Date"] as DateTime?,
                        Designer_Name = Convert.ToString(row["Designer_Name"]),
                        Designer_Assgined_DT = row["Designer_Assgined_DT"] as DateTime?,
                        Is_High_Priority = row["Is_High_Priority"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_High_Priority"]),
                        Design_Expected_DT = row["Design_Expected_DT"] as DateTime?

                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderDesignInfoDE>> GetDesingOrder(int DesignerID)
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetDesingOrder(DesignerID);
                List<OrderDesignInfoDE> orders = new List<OrderDesignInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderDesignInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] as DateTime?,
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        //Delivery_Date = row["Delivery_Date"] as DateTime?,
                        Designer_Assgined_DT = row["Designer_Assgined_DT"] as DateTime?,
                        Is_High_Priority = row["Is_High_Priority"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_High_Priority"]),
                        Design_Expected_DT = row["Design_Expected_DT"] as DateTime?

                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeDE>> GetOperator(int OrderID)
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetOperator(OrderID);
                List<EmployeeDE> employee = new List<EmployeeDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    employee.Add(new EmployeeDE
                    {
                        Employee_ID = Convert.ToInt32(row["Employee_ID"]),
                        Employee_Name = Convert.ToString(row["Employee_Name"]),

                    });
                }
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderReworkInfoDE>> GetReworkOrder()
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetReworkOrder();
                List<OrderReworkInfoDE> orders = new List<OrderReworkInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderReworkInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] == DBNull.Value ? null: (DateTime?)Convert.ToDateTime(row["Order_Date"]),
                        Customer_Name = Convert.ToString(row["Customer_Name"]),
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null: Convert.ToString(row["Quantity"]),
                        Delivery_Date = row["Delivery_Date"] == DBNull.Value? null: (DateTime?)Convert.ToDateTime(row["Delivery_Date"])


                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderDesignUploadInfoDE>> GetDesignUploadOrder()
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetDesignUploadedOrder();
                List<OrderDesignUploadInfoDE> orders = new List<OrderDesignUploadInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderDesignUploadInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["Order_Date"]),
                        Customer_Name = Convert.ToString(row["Customer_Name"]),
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null : Convert.ToString(row["Quantity"]),
                        Delivery_Date = row["Delivery_Date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["Delivery_Date"]),
                        Designer_Name = Convert.ToString(row["Designer_Name"]),
                        Designer_Assgined_DT = row["Designer_Assgined_DT"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["Designer_Assgined_DT"]),
                        Is_High_Priority = row["Is_High_Priority"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(row["Is_High_Priority"]),
                        Design_Expected_DT = row["Design_Expected_DT"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["Design_Expected_DT"]),
                        Design_Upload_DT = row["Design_Upload_DT"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["Design_Upload_DT"])



                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderPendingConfirmationInfoDE>> GetPendingOrderConfirmation()
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetPendingOrderConfirmation();
                List<OrderPendingConfirmationInfoDE> orders = new List<OrderPendingConfirmationInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderPendingConfirmationInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Order_Date"]),
                        Customer_Name = Convert.ToString(row["Customer_Name"]),
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null : Convert.ToString(row["Quantity"]),
                        Delivery_Date = row["Delivery_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Delivery_Date"]),
                        Designer_Name = Convert.ToString(row["Designer_Name"]),
                        Designer_Assgined_DT = row["Designer_Assgined_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Designer_Assgined_DT"]),
                        Is_High_Priority = row["Is_High_Priority"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_High_Priority"]),
                        Design_Upload_DT = row["Design_Upload_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Design_Upload_DT"]),
                        Design_Approved_DT = row["Design_Approved_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Design_Approved_DT"])




                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderConfirmedInfo>> GetConfirmedOrder()
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetConfirmedOrder();
                List<OrderConfirmedInfo> orders = new List<OrderConfirmedInfo>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderConfirmedInfo
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Order_Date"]),
                        Customer_Name = Convert.ToString(row["Customer_Name"]),
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null : Convert.ToString(row["Quantity"]),
                        Delivery_Date = row["Delivery_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Delivery_Date"]),
                        Designer_Name = Convert.ToString(row["Designer_Name"]),
                        Designer_Assgined_DT = row["Designer_Assgined_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Designer_Assgined_DT"]),
                        Is_High_Priority = row["Is_High_Priority"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_High_Priority"]),
                        Design_Upload_DT = row["Design_Upload_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Design_Upload_DT"]),
                        Design_Approved_DT = row["Design_Approved_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Design_Approved_DT"]),
                        Order_Confirmed_DT = row["Order_Confirmed_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Order_Confirmed_DT"])





                    });
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderUnderProductionInfoDE>> GetUnderProductionOrder()
        {
            try
            {

                DataTable dataTable = await _orderRepo.GetUnderProductionOrder();
                List<OrderUnderProductionInfoDE> orders = new List<OrderUnderProductionInfoDE>();

                foreach (DataRow row in dataTable.Rows)
                {
                    orders.Add(new OrderUnderProductionInfoDE
                    {
                        Order_ID = Convert.ToInt32(row["Order_ID"]),
                        Order_Number = Convert.ToString(row["Order_Number"]),
                        Order_Date = row["Order_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Order_Date"]),
                        Customer_Name = Convert.ToString(row["Customer_Name"]),
                        Order_Type = Convert.ToString(row["Order_Type"]),
                        Design = Convert.ToString(row["Design"]),
                        Quantity = row["Quantity"] == DBNull.Value ? null : Convert.ToString(row["Quantity"]),
                        Delivery_Date = row["Delivery_Date"] == DBNull.Value ? null : Convert.ToDateTime(row["Delivery_Date"]),
                        Designer_Name = Convert.ToString(row["Designer_Name"]),
                        Designer_Assgined_DT = row["Designer_Assgined_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Designer_Assgined_DT"]),
                        Is_High_Priority = row["Is_High_Priority"] == DBNull.Value ? null : Convert.ToBoolean(row["Is_High_Priority"]),
                        Design_Upload_DT = row["Design_Upload_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Design_Upload_DT"]),
                        Design_Approved_DT = row["Design_Approved_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Design_Approved_DT"]),
                        Order_Confirmed_DT = row["Order_Confirmed_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Order_Confirmed_DT"]),
                        Production_Assigned_DT = row["Production_Assigned_DT"] == DBNull.Value ? null : Convert.ToDateTime(row["Production_Assigned_DT"])






                    });
                }
                return orders;
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

        public async Task<ResponseDE> AMDCancelOrder(OrderCancelRequestDE orderCancelRequestDE)
        {
            try
            {

                return await _orderRepo.AMDCancelOrder(orderCancelRequestDE);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> AMDAssignDesigner(OrderDesignRequestDE requestDE)
        {
            try
            {

                return await _orderRepo.AMDAssignDesigner(requestDE);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderDesingUpload(OrderDesingUploadDE requestDE)
        {
            try
            {

                return await _orderRepo.AMDOrderDesingUpload(requestDE);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderDesignApprove(OrderDesignApproveDE request)
        {
            try
            {

                return await _orderRepo.AMDOrderDesignApprove(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> CreateReOrder(ReOrderDE request)
        {
            try
            {

                return await _orderRepo.AMDCreateReOrder(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> OrderReworkDtl(OrderReworkDtlDE request)
        {
            try
            {

                return await _orderRepo.AMDOrderReworkDtl(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> CustomerOrderConfirm(OrderConfirmDE request)
        {
            try
            {

                return await _orderRepo.AMDCustomerOrderConfirm(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> OrderAssignToProduction(OrderAssignToProductionDE request)
        {
            try
            {

                return await _orderRepo.AMDOrderAssignToProduction(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDE> OrderComplete(OrderCompleteDE request)
        {
            try
            {

                return await _orderRepo.AMDOrderComplete(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
