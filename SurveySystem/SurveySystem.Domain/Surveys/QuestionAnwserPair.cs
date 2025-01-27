namespace SurveySystem.Domain.Surveys
{
    public class QuestionAnwserPair
    {
        public string QuestionText { get; set; } = string.Empty;
        public List<QuestionAnswer> Anwsers { get; set; } = new List<QuestionAnswer>();
    }
}
