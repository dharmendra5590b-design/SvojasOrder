
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.DBConnection;
using Repository.Interface;
using Services;
using Services.Interface;
using System.Repository;

namespace SvojasOrder.Extensions
{
    public static class AddApiServiceExtensions
    {
        public static void RegisterApiServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddScoped<ISqlConnection, ClSSqlConnection>();
            //Repo Register
            Services.AddScoped<ILoginRepo, LoginRepo>();
            Services.AddScoped<ICustomerRepo, CustomerRepo>();
            Services.AddScoped<IUserRepo, UserRepo>();
            Services.AddScoped<IAdminDashboardRepo, AdminDashboardRepo>();
            Services.AddScoped<IOrderService, OrderService>();
            //Service Register
            Services.AddScoped<ILoginService, LoginService>();
            Services.AddScoped<ICustomerService,CustomerService>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IAdminDashboardService, AdminDashboardService>();
            Services.AddScoped<IOrderRepo, OrderRepo>();
            //Create singleton from instance

            Services.AddHttpContextAccessor();
        }
    }
}
