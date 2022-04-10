using CleanArch.Query.Shared.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Models.Users.Repository
{
    public class UserReadRepository : BaseReadRepository<UserReadModel>, IUserReadRepository
    {
        public UserReadRepository(IMongoClient client) : base(client)
        {
           
        }
        public async Task<UserReadModel> GetByEmail(string email)
        {
            return await _collection.Find(f => f.Email == email).FirstOrDefaultAsync();
        }
    }
}
