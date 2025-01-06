using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Domain.Users;
public sealed class User : Entity
{
    private User(Guid id, string name, string surname, string password, Address address, string phoneNumber, string email) : base(id)
    {
        Name = name;
        Surname = surname;
        Password = password;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public Address Address{ get; private set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }


    public static User Create(string name, string surname, string password, Address address, string phoneNumber, string email)
    {
        var user = new User(Guid.NewGuid(), name, surname, password, address, phoneNumber, email);

        // do smth

        return user;
    }
}
