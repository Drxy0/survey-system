using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Users;
using SurveySystem.Infrastructure.Repositories;


namespace SurveySystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration));

        // connect to db
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ISurveyRepository, SurveyRepository>();
        services.AddTransient<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        // // sp - Service Provider
        // services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        //
        // // Register the interface and map its implementation
        // services.AddSingleton<ISqlConnectionFactory>(_ =>
        //     new SqlConnectionFactory(connectionString));

        return services;
    }
}