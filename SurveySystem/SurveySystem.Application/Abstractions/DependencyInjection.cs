using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SurveySystem.Application.Abstractions;

public static class DependencyInjection
{
    // This adds application specific services
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR services
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

        });

        // Registering specific services from the domain layer
		
        return services;
    }
}
