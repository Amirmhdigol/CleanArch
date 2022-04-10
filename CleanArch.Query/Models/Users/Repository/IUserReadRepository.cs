using CleanArch.Query.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Models.Users.Repository
{
    public interface IUserReadRepository
    {
        Task<UserReadModel> GetByEmail(string email);
    }
}