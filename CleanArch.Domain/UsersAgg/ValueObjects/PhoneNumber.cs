using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Users.ValueObjects
{
    public class PhoneNumber : BaseValueObject
    {
        public PhoneNumber()
        {

        }
        public string Phone { get; private set; }

        public PhoneNumber(string phone)
        {
            if (phone.Length < 11 || phone.Length > 11)
                throw new InvalidDataException();
            Phone = phone;
        }
    }
}
