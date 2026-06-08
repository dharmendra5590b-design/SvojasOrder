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
                orderSearchDE.mode = "S";
                DataTable dataTable = await _orderRepo.GetOrder(orderSearchDE);
                List<OrderDetailDE> orders = new List<OrderDetailDE>();

                foreach (DataRow dr in dataTable.Rows)
                {
                    orders.Add(new OrderDetailDE
                    {
                        Order_ID = dr.Field<int>("Order_ID"),
                        Order_Number = dr["Order_Number"]?.ToString(),
                        Order_Date = dr.Field<DateTime?>("Order_Date"),
                        Customer_ID = dr.Field<int?>("Customer_ID"),
                        Design_ID = dr.Field<int?>("Design_ID"),
                        Karat_ID = dr.Field<int?>("Karat_ID"),
                        Karat_Percent = dr.Field<decimal?>("Karat_Percent"),
                        Design_Type_ID = dr.Field<int?>("Design_Type_ID"),
                        Gold_Colour_ID = dr.Field<int?>("Gold_Colour_ID"),
                        Size = dr["Size"]?.ToString(),
                        Weight = dr.Field<decimal?>("Weight"),

                        Stone_ID = dr.Field<int?>("Stone_ID"),
                        Is_Colour_Required = Convert.ToBoolean(dr["Is_Colour_Required"]),
                        Colour_Stone_ID = dr.Field<int?>("Colour_Stone_ID"),
                        Colour_Stone = dr["Colour_Stone"]?.ToString(),

                        Is_Certificate_Required = Convert.ToBoolean(dr["Is_Certificate_Required"]),
                        Cretificate_ID = dr.Field<int?>("Cretificate_ID"),
                        Diamond_Quality_ID = dr.Field<int?>("Diamond_Quality_ID"),
                        Diamond_Weight = dr.Field<decimal?>("Diamond_Weight"),
                        NoOf_Diamonds = dr.Field<int?>("NoOf_Diamonds"),

                        Delivery_Date = dr.Field<DateTime?>("Delivery_Date"),
                        Specification = dr["Specification"]?.ToString(),

                        Front_Image_URL = dr["Front_Image_URL"]?.ToString(),
                        Top_Image_URL = dr["Top_Image_URL"]?.ToString(),
                        Side_Image_URL = dr["Side_Image_URL"]?.ToString(),
                        Back_Image_URL = dr["Back_Image_URL"]?.ToString(),

                        IS_Editable = Convert.ToBoolean(dr["IS_Editable"]),

                        Is_Design_Approved = Convert.ToBoolean(dr["Is_Design_Approved"]),
                        CAD_Image_URL = dr["CAD_Image_URL"]?.ToString(),

                        Designer_Weight = dr.Field<decimal?>("Designer_Weight"),
                        Designer_Diamond_Weight = dr.Field<decimal?>("Designer_Diamond_Weight"),
                        Designer_NoOf_Diamonds = dr.Field<int?>("Designer_NoOf_Diamonds"),

                        Is_Confirmable = Convert.ToBoolean(dr["Is_Confirmable"]),

                        Is_Order_Completed = Convert.ToBoolean(dr["Is_Order_Completed"]),
                        Order_Complete_DT = dr.Field<DateTime?>("Order_Complete_DT"),

                        Final_Gross_Weight = dr.Field<decimal?>("Final_Gross_Weight"),
                        Final_Noof_Diamonds = dr.Field<int?>("Final_Noof_Diamonds"),
                        Final_Diamond_Weight = dr.Field<decimal?>("Final_Diamond_Weight"),

                        NoOfColour_Stone = dr.Field<int?>("NoOfColour_Stone"),
                        ColourStone_Weight = dr.Field<decimal?>("ColourStone_Weight"),

                        Others_NoOfColour_Stone = dr.Field<int?>("Others_NoOfColour_Stone"),
                        Others_Colour_Stone_Weight = dr.Field<decimal?>("Others_Colour_Stone_Weight"),

                        Final_Net_Weight = dr.Field<decimal?>("Final_Net_Weight")
                    });
                }
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
