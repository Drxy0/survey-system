namespace SurveySystem.Api.Controllers.Users;

public sealed record CreateUserRequest(
    string Name,
    string Surname,
    string Email,
    string Password,
    string PhoneNumber,
    string Address,
    string City,
    string Country);
