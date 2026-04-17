using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.Roles;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RolesController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public RolesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/roles
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
		{
			var roles = await _context.Roles
				.Select(r => new RoleDto
				{
					RoleId = r.RoleId,
					RoleName = r.RoleName
				})
				.ToListAsync();

			return roles;
		}

		// POST
		[HttpPost]
		public async Task<ActionResult<RoleDto>> CreateRole(CreateRoleDto dto)
		{
			var role = new Role
			{
				RoleName = dto.RoleName
			};

			_context.Roles.Add(role);
			await _context.SaveChangesAsync();

			var result = new RoleDto
			{
				RoleId = role.RoleId,
				RoleName = role.RoleName
			};

			return CreatedAtAction(nameof(GetRoles), new { id = role.RoleId }, result);
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRole(int id, UpdateRoleDto dto)
		{
			if (id != dto.RoleId)
				return BadRequest();

			var role = await _context.Roles.FindAsync(id);
			if (role == null)
				return NotFound();

			role.RoleName = dto.RoleName;

			await _context.SaveChangesAsync();
			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			var role = await _context.Roles.FindAsync(id);
			if (role == null)
				return NotFound();

			_context.Roles.Remove(role);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}