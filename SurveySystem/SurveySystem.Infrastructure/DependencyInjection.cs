using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SurveySystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrucutre(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // register services
        //services.AddTransisent<IDateTimeProvider>, DateTimeProvider > ();

        // connect to db
        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            //options.___(connectionString)
        });

        return services;
    }
}
