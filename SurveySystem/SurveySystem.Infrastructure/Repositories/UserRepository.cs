using SurveySystem.Domain.Users;

namespace SurveySystem.Infrastructure.Repositories;

// IUserRepository - defined in the domain layer
// Contains methods needed only for the User entity
internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}

/*Example usage
    var userRepository = new UserRepository(applicationDbContext);
    var user = new User { Id = Guid.NewGuid(), Name = "Alice" };
    userRepository.Add(user);
 */