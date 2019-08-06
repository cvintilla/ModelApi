using Domain;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi.Configuration
{
    /// <summary>
    /// Configure Services Extension
    /// </summary>
    public static class ConfigureServicesExtensions
    {
        /// <summary>
        /// Configures Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentMongoRepository, StudentMongoRepository>();

            services.AddTransient<IStudentService, StudentService>();

            services.AddTransient<MongoConstants>();

            return services;
        }
    }
}
