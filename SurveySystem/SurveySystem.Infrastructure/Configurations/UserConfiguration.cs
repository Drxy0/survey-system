using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveySystem.Domain.Users;

namespace SurveySystem.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(user => user.Id);
                
        builder.Property(user => user.Name).IsRequired();
        builder.Property(user => user.Surname).IsRequired();
        builder.Property(user => user.Email).IsRequired();
        builder.Property(user => user.Password).IsRequired();
        builder.Property(user => user.PhoneNumber).IsRequired();
        builder.Property(user => user.Address).IsRequired();
        builder.Property(user => user.City).IsRequired();
        builder.Property(user => user.Country).IsRequired();
        
        builder.HasIndex(user => user.Email).IsUnique();
    }
}