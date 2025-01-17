using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveySystem.Application.Abstractions.Data;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Users;
using SurveySystem.Infrastructure.Data;
using SurveySystem.Infrastructure.Repositories;

namespace SurveySystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // register services
        //services.AddTransisent<IDateTimeProvider>, DateTimeProvider > ();

        // connect to db
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
=======
        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
>>>>>>> b14d977 (Update db connection string)
=======
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
>>>>>>> 906bf84 (fixed)
=======
        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
>>>>>>> b75042a (Rebase)

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();

        // sp - Service Provider
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        // Register the inteface and map its implementation
        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        return services;
    }
}
