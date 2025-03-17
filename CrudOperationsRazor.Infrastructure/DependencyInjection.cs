using CrudOperationsRazor.Domain.Interfaces;
using CrudOperationsRazor.Infrastructure.Data;
using CrudOperationsRazor.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsRazor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));


            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
