using CRUD_DotNet8.Data;
using CRUD_DotNet8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("✅ User Added!");
        }
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User updatedUser)
        {
            var dbUser = await _context.Users.FindAsync(updatedUser.Id);
            if (dbUser is null)
                return NotFound();

            dbUser.FirstName = updatedUser.FirstName;
            dbUser.LastName = updatedUser.LastName;
            dbUser.Email = updatedUser.Email;

            await _context.SaveChangesAsync();

            return Ok("✅ User Updated!");
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("❌ User Removed!");
        }
    }
}
