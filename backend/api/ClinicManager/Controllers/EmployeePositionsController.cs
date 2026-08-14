using ClinicManager.Data;
using ClinicManager.DTOs.EmployeePositions;
using ClinicManager.DTOs.Employees;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeePositionsController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public EmployeePositionsController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/EmployeePositions

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EmployeePositionDTO>>> GetEmployeePosition()
		{
			var employeePosition = await _context.EmployeePositions
			  .Select(ep => new EmployeePositionDTO
			  {
				  EmployeeId = ep.EmployeeId,
				  EmployeeName = $"{ep.Employee!.FirstName1} {ep.Employee.LastName1}" , 
				  PositionId = ep.PositionId,
				  PositionName = ep.Position!.Name,
				  UserName = ep.Employee!.User!.UserName,
				  //CreateUser = ep.Employee!.User!.UserName ,

			  }).ToListAsync();
			return employeePosition;
		}


		//POST
		[HttpPost]

		public async Task<ActionResult<EmployeePositionDTO>> CreateEmployeePosition(CreateEmployeePositionDTO dto)
		{

			var exists = await _context.EmployeePositions.AnyAsync(ep =>
				ep.EmployeeId == dto.EmployeeId &&
				ep.PositionId == dto.PositionId);

			if (exists)
			{
				return BadRequest("The position is already assigned to the employee.");
			}


			var employeePosition = new EmployeePosition
			{
				EmployeeId = dto.EmployeeId,
				PositionId = dto.PositionId,
				CreateUser = dto.CreateUser,
				CreateDate = DateTime.Now
			};




			_context.EmployeePositions.Add(employeePosition);
			await _context.SaveChangesAsync();

			var result = new EmployeePositionDTO
			{
				EmployeeId = employeePosition.EmployeeId,
				PositionId = employeePosition.PositionId,
				CreateUser = employeePosition.CreateUser
			};

			return CreatedAtAction(nameof(GetEmployeePosition), new { employeeId = employeePosition.EmployeeId, positionId = employeePosition.PositionId }, result);
		}
		

		[HttpDelete]
		// DELETE: api/EmployeePositions
		// Deletes a EmployeePositions relationship
		[HttpDelete("{employeeId}/{positionId}")]
		public async Task<IActionResult> DeleteEmployeePosition(int employeeId, int positionId)
		{
			var employeePosition = await _context.EmployeePositions
				.FirstOrDefaultAsync(ep =>
					ep.EmployeeId == employeeId &&
					ep.PositionId == positionId);

			if (employeePosition == null)
				return NotFound();

			_context.EmployeePositions.Remove(employeePosition);
			await _context.SaveChangesAsync();

			return NoContent();
		}

	}
}

