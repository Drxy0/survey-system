using SurveySystem.Domain.Abstractions;
namespace SurveySystem.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;

/* Example use case
 public void CreateUser(...)
{
    var user = new User(Guid.NewGuid(), firstName, lastName, email);
    user.RaiseDomainEvent(new UserCreatedDomainEvents(user.Id));
}
*/
