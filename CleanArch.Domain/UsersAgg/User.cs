using CleanArch.Domain.Shared;
using CleanArch.Domain.Users.ValueObjects;
using CleanArch.Domain.UsersAgg.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Users
{
    public class User : BaseAggregate
    {
        private User()
        {

        }
        public User(string name, string email, string family, PhoneNumber phoneNumber)
        {
            Name = name;
            Email = email;
            Family = family;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Family { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public static User RegisterUser(string eMail)
        {
            var user = new User("", eMail,"",null) ;
            user.AddDomainEvent(new UserRegistered(user.Id,eMail));
            return user;
        }
    }
}
