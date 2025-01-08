namespace SurveySystem.Domain.Abstractions;

// Used in the Application layer for saving changes to the db
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
