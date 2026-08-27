using ClinicManager.Data;
using ClinicManager.DTOs.EmployeeSpecialties;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeSpecialtiesController : ControllerBase
	{

		private readonly ClinicManagerDbContext _context;

		// Constructor with dependency injection of DbContext
		public EmployeeSpecialtiesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/employeespecialty
		// Returns all employee-especialty relationships
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EmployeeSpecialtyDTO>>> GetEmployeeSpecialty()
		{
			var employeeSpecialties = await _context.EmployeeSpecialties
				.Select(es => new EmployeeSpecialtyDTO
				{
					EmployeeId = es.EmployeeId ,
					EmployeeName = $"{es.Employee!.FirstName1} {es.Employee.LastName1}" ,
					SpecialtyId = es.SpecialtyId,
					SpecialtyName = es.Specialty!.Name,
					CreateUser = es.CreateUser,
					UserName = es.Employee!.User!.UserName,

				})
				.ToListAsync();

			return employeeSpecialties;

		}

		//POST
		[HttpPost]

		public async Task<ActionResult<EmployeeSpecialtyDTO>> CreateEmployeeSpecialty(CreateEmployeeSpecialtyDTO dto)
		{

			var exists = await _context.EmployeeSpecialties.AnyAsync(es =>
				es.EmployeeId == dto.EmployeeId &&
				es.SpecialtyId == dto.SpecialtyId);

			if (exists)
			{
				return BadRequest("The Specialty is already assigned to the employee.");
			}


			var employeeSpecialty = new EmployeeSpecialty
			{
				EmployeeId = dto.EmployeeId,
				SpecialtyId = dto.SpecialtyId,
				CreateUser = dto.CreateUser
			};




			_context.EmployeeSpecialties.Add(employeeSpecialty);
			await _context.SaveChangesAsync();

			var result = new EmployeeSpecialtyDTO
			{
				EmployeeId = employeeSpecialty.EmployeeId,
				SpecialtyId = employeeSpecialty.SpecialtyId,
				CreateUser = employeeSpecialty.CreateUser
			};

			return CreatedAtAction(nameof(GetEmployeeSpecialty), new { employeeId = employeeSpecialty.EmployeeId, SpecialtyId = employeeSpecialty.SpecialtyId }, result);
		}

	
		// DELETE: api/employeeSpecialties
		// Deletes a employee- specialties-role relationship
		[HttpDelete("{employeeId}/{specialtyId}")]
		public async Task<IActionResult> DeleteEmployeeSpecialty(int employeeId, int specialtyId)
		{
			var employeeSpecialty = await _context.EmployeeSpecialties
				.FirstOrDefaultAsync(es =>
					es.EmployeeId == employeeId &&
					es.SpecialtyId == specialtyId);

			if (employeeSpecialty == null)
				return NotFound();

			_context.EmployeeSpecialties.Remove(employeeSpecialty);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}


	
	

	


