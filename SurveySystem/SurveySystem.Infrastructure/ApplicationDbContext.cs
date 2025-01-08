using SurveySystem.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SurveySystem.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
