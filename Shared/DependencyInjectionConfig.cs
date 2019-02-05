
using Blogging.Services.Implementations;
using Blogging.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Blogging.Shared
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {

            services.AddScoped<IPostService, PostService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
