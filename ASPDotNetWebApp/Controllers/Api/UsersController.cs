using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPDotNetWebApp.Data;
using ASPDotNetWebApp.Models;
using ASPDotNetWebApp.Interfaces;

namespace ASPDotNetWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _user;

        public UsersController(IUserRepo user)
        {
            _user = user;
        }

        // GET: api/Users
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _user.GetAllUsers();
            //return await _context.Users.ToListAsync();
        }

        [Route("name/{name}")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            return await _user.GetUsersByName(name);
        }
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _user.GetUserById(id);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        */
        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var usr = await _user.CreateUser(user);

            return CreatedAtAction("GetUser", new { id = user.ID }, usr);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _user.DeleteUser(id);
            
            return user;
        }

        /*
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
        */
        
    }
}
