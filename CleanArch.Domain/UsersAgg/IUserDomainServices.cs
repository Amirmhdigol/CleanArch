using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.UsersAgg
{
    public interface IUserDomainServices
    {
        public bool EmailIsExist(string email);
    }
}
