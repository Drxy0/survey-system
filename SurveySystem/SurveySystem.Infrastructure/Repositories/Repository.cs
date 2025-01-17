using Microsoft.EntityFrameworkCore;
using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Infrastructure.Repositories;

// Generic repository pattern
// Used for interacting with the db for specific entities
internal abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext DbContext; // EF Core database context

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            // Retrieves a DbSet for the type T,
            // representing the database table for that entity.
            .Set<T>()
            // Executes a query to retrieve the first entity with the provided id.
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public virtual void Add(T entity)
    {
        // Marks the entity as "Added" in the DbContext.
        // EF Core will insert the entity into the database during the next SaveChanges call.
        DbContext.Add(entity);
    }
}