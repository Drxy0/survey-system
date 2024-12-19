using System.Linq;
namespace SurveySystem.Domain.Users;

public record Surname
{
    public string Value { get; init; }

    public Surname(string value)
    {
        if (value.Any(char.IsDigit))
        {
            throw new ArgumentException("Surname must not contain digits");
        }
        this.Value = value;
    }

}