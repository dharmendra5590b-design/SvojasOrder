using Domain;
using Repository;
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
    public class AdminDashboardService: IAdminDashboardService
    {
        private readonly IAdminDashboardRepo _adminDashboardRepo;
        public AdminDashboardService(IAdminDashboardRepo adminDashboardRepo)
        {
            _adminDashboardRepo = adminDashboardRepo;
        }

        public async Task<List<AdminDashboardDE>> GetAdminDashboard()
        {
            List<AdminDashboardDE> adminDashboardDE = new List<AdminDashboardDE>();
            try
            {
               
                DataTable dataTable = await _adminDashboardRepo.GetAdminDashboard();
                foreach (DataRow drrow in dataTable.Rows)
                {
                    AdminDashboardDE dataObj = new AdminDashboardDE();
                    dataObj.NewOrderCount = Convert.ToInt32(drrow["NewOrderCount"]);
                    dataObj.PendingDesignCount = Convert.ToInt32(drrow["PendingDesignCount"]);
                    dataObj.DesignUploadedCount = Convert.ToInt32(drrow["DesignUploadedCount"]);
                    dataObj.PendingOrderConfirmedCount = Convert.ToInt32(drrow["PendingOrderConfirmedCount"]);
                    dataObj.OrderConfirmedCount = Convert.ToInt32(drrow["OrderConfirmedCount"]);
                    dataObj.OrderUnderProductionCount = Convert.ToInt32(drrow["OrderUnderProductionCount"]);
                    adminDashboardDE.Add(dataObj);
                }
                return adminDashboardDE;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
