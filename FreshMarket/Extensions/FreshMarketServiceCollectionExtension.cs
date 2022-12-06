using FreshMarket.Core.Contracts;
using FreshMarket.Core.Services;
using FreshMarket.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FreshMarketServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICreatorService, CreatorService>();

            return services;
        }
    }
}
