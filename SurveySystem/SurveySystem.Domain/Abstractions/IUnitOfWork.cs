namespace SurveySystem.Domain.Abstractions;

// Used for saving changes to the db
public interface IUnitOfWork
{
    // This method is implemented by DbContext in the infrastructure layer
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
