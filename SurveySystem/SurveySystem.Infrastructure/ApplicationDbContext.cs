using SurveySystem.Application.Exceptions;
using SurveySystem.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SurveySystem.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    // Used for publishing domain event
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            // calls the base implementation of SaveChangesAsync to persist changes made in the context
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            // return value is the number of entries written to the db
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

    private async Task PublishDomainEventsAsync()
    {
        // ChangeTracker is the property of DbContext
        // keeps track of all entities in the context
        var domainEvents = ChangeTracker
            // Get all entries of type Entity
            .Entries<Entity>()
            // Transform EntityEntry objects from above to actual entity instances (e.g. Survey)
            .Select(entry => entry.Entity)
            // for each entity, get domain events associated with it
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                // Clear events, so they don't get published again
                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}