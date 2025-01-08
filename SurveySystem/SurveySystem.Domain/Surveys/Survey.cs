using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys.Events;

namespace SurveySystem.Domain.Surveys;

public sealed class Survey : Entity
{
    private Survey(Guid id,
                   string title,
                   List<QuestionAnwserPair> qa,
                   List<string> emailList,
                   bool isAnonymous)
    {
        Title = title;
        QuestionsAndAnwsers = qa;
        EmailList = emailList;
        IsAnonymous = isAnonymous;
    }
    public string Title { get; set; }
    public List<QuestionAnwserPair> QuestionsAndAnwsers { get; set; }
    public List<string> EmailList { get; set; }
    public bool IsAnonymous { get; set; }

    public static Result<Survey> Create(string title, List<QuestionAnwserPair> qa, List<string> emailList, bool isAnonymous)
    {
        if (emailList.Count > 50)
        {
            return Result.Failure<Survey>(SurveyErrors.TooManyEmails);
        }
        Survey survey = new Survey(Guid.NewGuid(), title, qa, emailList, isAnonymous);
        survey.RaiseDomainEvent(new SurveyCreatedDomainEvent(survey.Id));
        return survey;
    }
}
