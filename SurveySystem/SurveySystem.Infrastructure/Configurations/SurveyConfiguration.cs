using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveySystem.Domain.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.Infrastructure.Configurations;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("surveys");

        builder.HasKey(survey => survey.Id);

        builder.Property(survey => survey.Title).IsRequired();
        builder.Property(survey => survey.IsAnonymous).IsRequired();
        builder.Property(survey => survey.QuestionsAndAnwsers).IsRequired();
        builder.Property(survey => survey.EmailList).IsRequired();
    }
}
