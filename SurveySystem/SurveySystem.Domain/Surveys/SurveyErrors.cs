using SurveySystem.Domain.Abstractions;
namespace SurveySystem.Domain.Surveys;

public static class SurveyErrors
{
    public static Error NotFound = new(
    "Survey.NotFound",
    "The Survey with the specified id was not found");
    
    public static Error TooManyEmails = new(
    "Survey.TooManyEmails",
    "More than 50 email addresses were provided");
}
