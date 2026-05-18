using ClinicManager.Data;
using ClinicManager.DTOs.Doctors;
using ClinicManager.DTOs.UserRoles;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserRolesController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		// Constructor with dependency injection of DbContext
		public UserRolesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/userroles
		// Returns all user-role relationships
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetUserRoles()
		{
			var userRoles = await _context.UserRoles
				.Select(ur => new UserRoleDto
				{
					UserId = ur.UserId,
					UserName = ur.User.UserName,

					RoleId = ur.RoleId,
					RoleName = ur.Role.Name
				})
				.ToListAsync();

			return userRoles;
		}

		// POST: api/userroles
		// Creates a new user-role relationship
		[HttpPost]
		public async Task<ActionResult<UserRoleDto>> CreateUserRole(CreateUserRoleDto dto)
		{
			var userRole = new UserRole
			{
				UserId = dto.UserId,
				RoleId = dto.RoleId,
                CreateDate = DateTime.Now,
                CreateUser = dto.CreateUser
            };

			_context.UserRoles.Add(userRole);
			await _context.SaveChangesAsync();

			var result = new UserRoleDto
			{
				UserId = userRole.UserId,
				RoleId = userRole.RoleId,
				UserName = null, // Optional: can be loaded if needed
				RoleName = null
			};

			return CreatedAtAction(nameof(GetUserRoles),
				new { userId = userRole.UserId, roleId = userRole.RoleId },
				result);
		}
/*
        // PUT: api/userroles
        // Updates an existing relationship (not commonly used for join tables)
       // [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleDto dto)
		{
			var userRole = await _context.UserRoles
				.FirstOrDefaultAsync(ur =>
					ur.UserId == dto.UserId &&
					ur.RoleId == dto.RoleId);

			if (userRole == null)
				return NotFound();

            userRole.EditDate = DateTime.Now;
            userRole.EditUser = dto.EditUser;


            // No fields to update in a join table
            await _context.SaveChangesAsync();

			return NoContent();
		}*/

/*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, UpdateDoctorDto dto)
        {
            if (id != dto.DoctorId)
                return BadRequest();

            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
                return NotFound();

            doctor.UserId = dto.UserId;
            doctor.Specialty = dto.Specialty;
            doctor.Active = dto.Active;
            doctor.EditDate = DateTime.Now;
            doctor.EditUser = dto.EditUser;

            await _context.SaveChangesAsync();

            return NoContent();
        }

*/





        // DELETE: api/userroles
        // Deletes a user-role relationship
        [HttpDelete]
		public async Task<IActionResult> DeleteUserRole(int userId, int roleId)
		{
			var userRole = await _context.UserRoles
				.FirstOrDefaultAsync(ur =>
					ur.UserId == userId &&
					ur.RoleId == roleId);

			if (userRole == null)
				return NotFound();

			_context.UserRoles.Remove(userRole);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}