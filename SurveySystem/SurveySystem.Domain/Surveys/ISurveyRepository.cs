using SurveySystem.Domain.Users;

namespace SurveySystem.Domain.Surveys;

public interface ISurveyRepository
{
    Task<Survey?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Survey survey);
}
