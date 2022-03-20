using ASPDotNetWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Interfaces
{
    public interface IUserRepo
    {
        Task<User> CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
        Task<IEnumerable<User>> GetUsersByName(string name);
    }
}
