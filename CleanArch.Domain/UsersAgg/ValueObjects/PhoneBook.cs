using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Users.ValueObjects
{
    public class PhoneBook : BaseValueObject
    {
        public PhoneBook()
        {

        }
        public PhoneBook(PhoneNumber telePhone, PhoneNumber fax)
        {
            TelePhone = telePhone;
            Fax = fax;
        }
        public PhoneNumber TelePhone { get; }
        public PhoneNumber Fax { get; }
    }
}
