using System.Reflection;
using System.Text;
using DigiToll.DataStorage.DatabaseContext;
using DigiToll.DataStorage.EntityConfigurations.AccountManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VehicleIdentification.Infrastructure.Persistence;

namespace VehicleIdentification.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers().ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var modelState = actionContext.ModelState.Values;
                string errorMsg = string.Empty;
                StringBuilder errorMsgBuilder = new StringBuilder();

                foreach (var modelStateEntry in modelState)
                {
                    string str = string.Join(". ", modelStateEntry.Errors.Select(x => x.ErrorMessage));
                    errorMsgBuilder.Append(str);
                    errorMsg = errorMsgBuilder.ToString();
                }

                var response = new Behaviour.ApiResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = errorMsg
                };

                return new BadRequestObjectResult(response);
            };
        });

        return services;
    }

    public static IServiceCollection AddDatabaseContexts(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<VehicleDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("VehicleDbConnection")));

        return services;
    }

     public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddMemoryCache();
       
        return services;
    }
}
