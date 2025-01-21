using Microsoft.EntityFrameworkCore;
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

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>().FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public override void Add(User user)
    {
        DbContext.Add(user);
    }
}

/*Example usage
    var userRepository = new UserRepository(applicationDbContext);
    var user = new User { Id = Guid.NewGuid(), Name = "Alice" };
    userRepository.Add(user);
 */
