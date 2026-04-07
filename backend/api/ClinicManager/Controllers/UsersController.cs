using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.Users;

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
		public async Task<ActionResult<User>> CreateUser(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
		}

		// PUT: api/users/5
		// Updates an existing user
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(int id, User user)
		{
			if (id != user.UserId)
			{
				return BadRequest();
			}

			_context.Entry(user).State = EntityState.Modified;

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