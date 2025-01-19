using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Domain.Users;

public sealed class User : Entity
{
    public string Name { get; private set; } = String.Empty;
    public string Surname { get; private set; } = String.Empty;
    public string Password { get; private set; } = String.Empty;
    public string Address { get; private set; } = String.Empty; // No need for rich domain model
    public string PhoneNumber { get; private set; } = String.Empty;
    public string Email { get; private set; } = String.Empty;

    private User(Guid id, string name, string surname, string password, string address, string phoneNumber,
        string email) : base(id)
    {
        Name = name;
        Surname = surname;
        Password = password;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    private User()
    {
        // Not meant to be instantiated; Used for EntityFramework.
    }

    public static User Create(string name, string surname, string password, string address, string phoneNumber,
        string email)
    {
        var user = new User(Guid.NewGuid(), name, surname, password, address, phoneNumber, email);
        return user;
    }
}