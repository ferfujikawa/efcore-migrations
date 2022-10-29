using efcore_migrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace efcore_migrations.Extensions
{
    public static class AppExtensions
    {
        public static void LoadConfiguration(this IConfigurationBuilder builder)
        {
            builder
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }

        public static void InjectConnection(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<DataContext>(
                    options => options.UseNpgsql(connectionString));
        }

        public static void InjectConnection(this IHostBuilder builder, string connectionString)
        {
            builder
                .ConfigureServices(
                    services => services.AddDbContext<DataContext>(
                        options => options.UseNpgsql(connectionString))
                    );
        }
    }
}
