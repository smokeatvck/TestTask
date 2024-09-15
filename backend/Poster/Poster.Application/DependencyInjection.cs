using Microsoft.Extensions.DependencyInjection;
using Poster.Application.Interfaces;
using Poster.Application.Services;

namespace Poster.Application
{
    public static class DependencyInjection
    {
        public static void AddBase(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
        }
    }
}
