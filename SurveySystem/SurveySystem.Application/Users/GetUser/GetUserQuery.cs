using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Users.GetUser;

public sealed record GetUserQuery(string Email) : IQuery<User>;