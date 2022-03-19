using CleanArch.Domain.Users;
using CleanArch.Domain.UsersAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.EF.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AddDbContext _context;

        public UserRepository(AddDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public async Task<User> GetbyEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Email == email);
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public bool UserIsExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
