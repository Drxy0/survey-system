using System.Linq;
namespace SurveySystem.Domain.Users;

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        if (value.Any(char.IsDigit))
        {
            throw new ArgumentException("Name must not contain digits");
        }
        this.Value = value;
    }

}

