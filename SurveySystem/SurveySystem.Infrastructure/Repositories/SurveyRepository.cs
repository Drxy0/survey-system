using SurveySystem.Domain.Surveys;

namespace SurveySystem.Infrastructure.Repositories;

internal sealed class SurveyRepository : Repository<Survey>, ISurveyRepository
{
    public SurveyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
