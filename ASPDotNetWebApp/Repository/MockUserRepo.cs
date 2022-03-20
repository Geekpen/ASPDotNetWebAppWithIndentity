using ASPDotNetWebApp.Interfaces;
using ASPDotNetWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Repository
{
    public class MockUserRepo : IUserRepo
    {
        private List<User> users = new List<User>
        {
            new User { ID = 1, Name = "James Bond", Email = "James@Bond.co.uk", Password = "00000007", PhoneNumber = "1234567890", IsActive = true},
            new User { ID = 2, Name = "Bruce Wayne", Email = "Batman@Wayne.com", Password = "Superman", PhoneNumber = "0987654321", IsActive = true},
            new User { ID = 3, Name = "Darth Vader", Email = "Darth@Empire.galaxy", Password = "Skywalker", PhoneNumber = "0987612345", IsActive = false},
            new User { ID = 4, Name = "Neo", Email = "Neo@Matrix.com", Password = "Password", PhoneNumber = "0000000000", IsActive = false},
            new User { ID = 5, Name = "Neo Keyanu", Email = "Neo@Matrix.com", Password = "Password", PhoneNumber = "0000000000", IsActive = true}
        };
        public Task<User> CreateUser(User user)
        {
            users.Add(user);
            return Task.FromResult(user);
        }

        public Task<User> DeleteUser(int id)
        {
            var user = users.Find(result => result.ID == id);
            users.Remove(user);
            return Task.FromResult(user); ;
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return Task.FromResult<IEnumerable<User>>(users);
        }

        public Task<User> GetUserById(int id)
        {
            var user = users.Find(result => result.ID == id);
            return Task.FromResult(user); ;
        }

        public Task<IEnumerable<User>> GetUsersByName(string name)
        {
            name = name.ToLower();
            var result = users.FindAll(u => u.Name.ToLower().Contains(name));
            return Task.FromResult<IEnumerable<User>>(result);
        }

        public Task<User> UpdateUser(User user)
        {
            var oldUser = users.Find(result => result.ID == user.ID);
            users.Remove(oldUser);
            users.Add(user);
            return Task.FromResult(user); 
        }
    }
}
