using CleanArch.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.UsersAgg.Repository
{
    public interface IUserRepository
    {
        void Add(User user);

        Task<User> GetById(long id);

        Task<User> GetbyEmail(string email);

        bool UserIsExist(string email);

        Task SaveChange();

        void Update(User user);
    }
}
