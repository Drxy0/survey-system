using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Domain.Survey;

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
}
