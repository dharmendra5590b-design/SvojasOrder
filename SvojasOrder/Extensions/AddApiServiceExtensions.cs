
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
            //Service Register
            Services.AddScoped<ILoginService, LoginService>();
            //Create singleton from instance

            Services.AddHttpContextAccessor();
        }
    }
}
