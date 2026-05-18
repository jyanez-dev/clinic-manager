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
                CreateDate = DateTime.Now,
				CreateUser = dto.CreateUser
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
			user.EditUser = dto.EditUser;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> UpdateUserRoles(int id, UpdateUserRolesDto dto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            // Obtener roles actuales
            // Get current roles
            var currentRoles = await _context.UserRoles
                .Where(ur => ur.UserId == id)
                .ToListAsync();

            var currentRoleIds = currentRoles.Select(r => r.RoleId).ToList();

            // Roles a eliminar
            // Roles to remove
            var rolesToRemove = currentRoles
                .Where(r => !dto.RoleIds.Contains(r.RoleId))
                .ToList();

            // Roles a agregar
            // Roles to add
            var rolesToAdd = dto.RoleIds
                .Where(rid => !currentRoleIds.Contains(rid))
                .ToList();

            // DELETE
            _context.UserRoles.RemoveRange(rolesToRemove);

            // INSERT
            foreach (var roleId in rolesToAdd)
            {
                _context.UserRoles.Add(new UserRole
                {
                    UserId = id,
                    RoleId = roleId,
                    CreateDate = DateTime.Now,
                    CreateUser = dto.EditUser
                });
            }

            // Auditoría del cambio
            // Change audit
            user.EditDate = DateTime.Now;
            user.EditUser = dto.EditUser;

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