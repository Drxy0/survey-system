namespace SurveySystem.Domain.Users;

// Repository pattern,
// Used by the Infrastructure layer and for communicating with the db
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(User user);
}
