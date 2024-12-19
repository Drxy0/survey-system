using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Domain.Users;
public sealed class User : Entity
{
    public Name Name { get; set; }
    public Surname Surname { get; set; }
    public string Password { get; set; }
    public Address Address{ get; private set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Email Email { get; set; }
}
