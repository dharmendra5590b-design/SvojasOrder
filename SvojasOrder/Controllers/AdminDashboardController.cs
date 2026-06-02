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
    
    public class AdminDashboardController : BaseController
    {
        private readonly IAdminDashboardService _adminDashboardService;
        public AdminDashboardController(IAdminDashboardService adminDashboardService)
        {
            _adminDashboardService = adminDashboardService;
        }

       
        [HttpGet]
        public async Task<List<AdminDashboardDE>> GetAdminDashboard()
        {
            List<AdminDashboardDE> lobjAdminDashboardDE=new List<AdminDashboardDE>();
            try
            {
                lobjAdminDashboardDE = await _adminDashboardService.GetAdminDashboard();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(ex);
            }
            return lobjAdminDashboardDE;
        }
    }
    
 }
