using ASPDotNetWebApp.Interfaces;
using ASPDotNetWebApp.Models;
using System;
using System.Collections.Generic;
using ASPDotNetWebApp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetWebApp.Repository
{
    public class SqlUserRepo : IUserRepo
    {
        //Dependancy Injection
        private readonly DotNetCoreMySQLContext _context;

        public SqlUserRepo(DotNetCoreMySQLContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            _context.Users.Remove(user);
            _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            
            var user = _context.Users.FindAsync(id);
            return await user;
        }

        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            name = name.ToLower();
            var allUsers = _context.Users.ToList().FindAll(u => u.Name.ToLower().Contains(name));
            return allUsers;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChangesAsync();

            return user;
        }
    }
}
