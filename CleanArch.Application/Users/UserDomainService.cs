using CleanArch.Domain.UsersAgg;
using CleanArch.Domain.UsersAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Users
{
    public class UserDomainService : IUserDomainServices
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }
        public bool EmailIsExist(string email)
        {
            return _repository.UserIsExist(email);
        }
    }
}
