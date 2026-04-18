using ClinicManager.Data;
using ClinicManager.DTOs.Doctors;
using ClinicManager.DTOs.Users;
using ClinicManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		// Constructor with dependency injection
		public UsersController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/users
		// Returns all users
		/*[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			return await _context.Users.ToListAsync();
		}
		*/

		// GET: api/users
		// Returns all users
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
		{
			var users = await _context.Users
				.Select(u => new UserDto
				{
					UserId = u.UserId,
					FirstName = u.FirstName,
					LastName = u.LastName,
					UserName = u.UserName
				})
				.ToListAsync();

			return users;
		}


		// GET: api/users/5
		// Returns a user by id
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			var user = await _context.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			return user;
		}

        // POST: api/users
        // Creates a new user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                PasswordHash = dto.PasswordHash,
                Email = dto.EmailAddress,
                Phone = dto.Phone,
                IsActive = true,
                CreateDate = DateTime.Now
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser),
                new { id = user.UserId },
                user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
        {
            if (id != dto.UserId)
                return BadRequest();

            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();


			user.FirstName = dto.FirstName;
			user.LastName = dto.LastName;
			user.UserName = dto.UserName;
			user.Email = dto.Email;
			user.Phone = dto.Phone;
			user.IsActive = true;
			user.EditDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent();
        }



        // DELETE: api/users/5
        // Deletes a user
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _context.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}