
using HackerStories.DAL.DataContext;
using HackerStories.DAL.Interface;
using HackerStories.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HackerStories.DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<StoryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("HackerStoryDB"));
            });

            services.AddScoped<IStoryRepository, StoryRepository>();
        }
    }
}
