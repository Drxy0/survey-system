using System.Linq;
namespace SurveySystem.Domain.Users;

public record PhoneNumber
{
    public string Value { get; init; }
    
    public PhoneNumber(string value)
    {
        if (value[0] != '+')
        {
            throw new ArgumentException("Phone number must start with a '+'.");
        }
        if (!value[1..].Any(char.IsDigit))
        {
            throw new ArgumentException("Phone number must contain only digits after '+'.");
        }

        this.Value = value;
    }
}