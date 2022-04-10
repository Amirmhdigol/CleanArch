using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using CleanArch.Domain.Users.ValueObjects;
using CleanArch.Domain.UsersAgg;
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
        public User(string name, string family, PhoneNumber phoneNumber, string email
        , IUserDomainServices domainService)
        {
            Guard(email);
            if (domainService.EmailIsExist(email))
                throw new InvalidDomainDataException("ایمیل وارد شده قبلا استفاده شده است");

            Name = name;
            Email = email;
            Family = family;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Family { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public static User RegisterUser(string email, string phoneNumber, IUserDomainServices domainService)
        {
            var user = new User("", "", new PhoneNumber(phoneNumber), email, domainService);
            user.AddDomainEvent(new UserRegistered(user.Id, email));
            return user;
        }
        private void Guard(string email)
        {
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
        }
    }
}
