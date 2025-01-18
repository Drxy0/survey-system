namespace SurveySystem.Domain.Users;

// Repository pattern,
// Used by the Infrastructure layer and for communicating with the db
// Here we define methods specific to the user entity
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    void Add(User user);
}