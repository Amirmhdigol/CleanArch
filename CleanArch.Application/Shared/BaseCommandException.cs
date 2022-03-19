using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Shared
{
    public class BaseCommandException : Exception
    {
        public BaseCommandException()
        {

        }
        public BaseCommandException(string message) : base(message)
        {

        }
    }
}
