using SurveySystem.Domain.Users;

namespace SurveySystem.Domain.Surveys;

public interface ISurveyRepository
{
    // This is implemented in Infrastructure.Repository, not in SurveyRepository
    Task<Survey?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Survey survey);
}
