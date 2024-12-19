using System.Linq;
namespace SurveySystem.Domain.Users;
public record Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        // If e-mail doesn't contain '@' its not valid
        if (!value.Contains("@"))
        {
            throw new NotImplementedException();
        }
        this.Value = value;
    }
}