using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.Found",
        "User not found");

    public static Error AlreadyExists = new(
        "User.Exists",
        "The user with the specified id already exists");
}
