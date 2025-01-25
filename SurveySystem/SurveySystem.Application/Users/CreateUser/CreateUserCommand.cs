using SurveySystem.Application.Abstractions.Messaging;
namespace SurveySystem.Application.Users.CreateUser;

public sealed record CreateUserCommand(
    string Name,
    string Surname,
    string Email,
    string Password,
    string PhoneNumber,
    string Address,
    string City,
    string Country) : ICommand<Guid>;
