
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.DBConnection;
using Repository.Interface;
using System.Repository;

namespace SvojasOrder.Extensions
{
    public static class AddApiServiceExtensions
    {
        public static void RegisterApiServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddScoped<ISqlConnection, ClSSqlConnection>();
            //Repo Register
            
            //Service Register
           
            //Create singleton from instance

            Services.AddHttpContextAccessor();
        }
    }
}
