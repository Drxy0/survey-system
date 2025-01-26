using SurveySystem.Application.Abstractions.Messaging;

namespace SurveySystem.Application.Users.Login;

public sealed record LoginCommand(
    string Email,
    string Password) : ICommand<Guid>;
