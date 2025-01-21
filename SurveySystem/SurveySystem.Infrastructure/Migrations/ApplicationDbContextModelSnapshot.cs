using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveySystem.Infrastructure;

#nullable disable

namespace SurveySystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SurveySystem.Domain.Users.User", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("char(36)");

                b.Property<string>("Address")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Surname")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.HasIndex("Email")
                    .IsUnique();

                b.ToTable("users");
            });
        }
    }
}
