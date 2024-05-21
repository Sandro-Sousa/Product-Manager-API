using Entities.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Commom;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Helpers;
using Service.Interfaces;
using Service.Services;

namespace Product_Manager.WebAPIs.Extensions
{
    public static class DependencyContainer
    {

        public static void AddProductManagerContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ProductManagerDbContext>(opt =>
            {
                var factory = new ProductManagerDbContextFactory();
                opt.UseSqlServer(factory.CreateDbContext(Array.Empty<string>()).Database.GetDbConnection(),
                    options => options.EnableRetryOnFailure());
            });

            builder.Services.AddAutoMapper(typeof(ProductManagerProfile));

            // Repository
            builder.Services.AddScoped<IProductManagerRepository, ProductManagerRepository>();

            // Services
            builder.Services.AddScoped<IProductManagerService, ProductManagerService>();
        }
    }
}

