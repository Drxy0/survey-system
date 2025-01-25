using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Domain.Users;

public sealed class User : Entity
{
    public string Name { get; private set; } = String.Empty;
    public string Surname { get; private set; } = String.Empty;
    public string Password { get; private set; } = String.Empty;
    public string Address { get; private set; } = String.Empty; // No need for rich domain model
    public string City { get; private set; } = String.Empty;
    public string Country { get; private set; } = String.Empty;
    public string PhoneNumber { get; private set; } = String.Empty;
    public string Email { get; private set; } = String.Empty;

    private User(
        Guid id,
        string name,
        string surname,
        string email,
        string password,
        string phoneNumber,
        string address,
        string city,
        string country) : base(id)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Address = address;
        City = city;
        Country = country;
    }

    private User()
    {
        // Not meant to be instantiated; Used for EntityFramework.
    }

    public static User Create(string name,
                              string surname,
                              string email,
                              string password,
                              string phoneNumber,
                              string address,
                              string city,
                              string country)
    {
        var user = new User(Guid.NewGuid(),
                            name,
                            surname,
                            email,
                            password,
                            phoneNumber,
                            address,
                            city,
                            country);
        return user;
    }
}