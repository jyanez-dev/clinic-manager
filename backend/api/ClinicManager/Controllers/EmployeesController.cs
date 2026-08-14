using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using ClinicManager.Data;
using ClinicManager.DTOs.EmployeePositions;
using ClinicManager.DTOs.Employees;
using ClinicManager.DTOs.EmployeeSpecialties;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeesController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public EmployeesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		//Get api/employee
		[HttpGet]

		public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
		{
			var employees = await _context.Employees
				.Select(e => new EmployeeDTO
				{
					EmployeeId = e.EmployeeId,
					UserId = e.UserId,
					FirstName1 = e.FirstName1,
					LastName1 = e.LastName1,
					DocNum = e.DocNum,
					Email = e.Email,
					Observation = e.Observation,
					Sex = e.Sex,	

				}).ToListAsync();
			return employees;
		}

		//POST
		[HttpPost]

		public async Task<ActionResult<EmployeeDTO>> CreateEmployee(CreateEmployeeDTO dto)
		{
			var employee = new Employee
			{
				UserId = dto.UserId,
				FirstName1 = dto.FirstName1,
				LastName1 = dto.LastName1,
				DocNum = dto.DocNum,
				Email = dto.Email,
				Status = true,
				CreateUser = dto.CreateUser,
				CreateDate = DateTime.Now,
				Observation = dto.Observation,
				Sex = dto.Sex,
			};
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();

			var result = new EmployeeDTO
			{
				UserId = employee.UserId,
				FirstName1 = employee.FirstName1,
				LastName1 = employee.LastName1,
				Email = employee.Email,
				CreateUser = employee.CreateUser,
				Observation = employee.Observation,
				Sex= employee.Sex,
			};

			return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmployeeId }, result);

		}

		//PUT
		[HttpPut("{id}")]

		public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDTO dto)
		{
			if (id != dto.EmployeeId)
				return BadRequest();

			var employee = await _context.Employees.FindAsync(id);

			if (employee == null)
				return NotFound();

			employee.UserId = dto.UserId;
			employee.FirstName1 = dto.FirstName1;
			employee.LastName1 = dto.LastName1;
			employee.DocNum = dto.DocNum;
			employee.Status = dto.Status;
			employee.Email = dto.Email;
			employee.EditDate = DateTime.Now;
			employee.EditUser = dto.EditUser;
			employee.Observation = dto.Observation;
			employee.Sex = dto.Sex;

			await _context.SaveChangesAsync();

			return NoContent();
		}



		/**************************************/

		[HttpPut("{id}/positions")]
		public async Task<IActionResult> UpdateEmployeePositions(int id, UpdateEmployeePositionsDTO dto)
		{
			var employee = await _context.Employees.FindAsync(id);

			if (employee == null)
				return NotFound();

			
			// Get current positions
			var currentPositions = await _context.EmployeePositions
				.Where(ep => ep.EmployeeId == id)
				.ToListAsync();

			var currentPositionIds = currentPositions.Select(p => p.PositionId).ToList();
						
			// positions to remove
			var positionsToRemove = currentPositionIds
				.Where(pid => !dto.positionIds.Contains(pid))
				.ToList();
			
			// positions to add
			var positionsToAdd = dto.positionIds
				.Where(pid => !currentPositionIds.Contains(pid))
				.ToList();

			// DELETE
			_context.EmployeePositions.RemoveRange();

			// INSERT
			foreach (var positionId in positionsToAdd)
			{
				_context.EmployeePositions.Add(new EmployeePosition
				{
					EmployeeId = id,
					PositionId = positionId,
					CreateDate = DateTime.Now,
					CreateUser = dto.EditUser
				});
			}

			// Auditoría del cambio
			// Change audit
			employee.EditDate = DateTime.Now;
			employee.EditUser = dto.EditUser;

			await _context.SaveChangesAsync();

			return NoContent();

		}

		[HttpPut("{id}/specialties")]

			public async Task<IActionResult> UpdateEmployeeSpecialties(int id, UpdateEmployeeSpecialtiesDTO dto)
			{
				var employee = await _context.Employees.FindAsync(id);

				if (employee == null)
					return NotFound();

				// Obtener roles actuales
				// Get current roles
				var currentSpecialties = await _context.EmployeeSpecialties
					.Where(ep => ep.EmployeeId == id)
					.ToListAsync();

				var currentSpecialtyIds = currentSpecialties.Select(s => s.SpecialtyId).ToList();

				// Roles a eliminar
				// Roles to remove
				var specialtiesToRemove = currentSpecialties
					.Where(s => !dto.SpecialtyIds.Contains(s.SpecialtyId))
					.ToList();

				// Roles a agregar
				// Roles to add
				var specialtiesToAdd = dto.SpecialtyIds
					.Where(sid => !currentSpecialtyIds.Contains(sid))
					.ToList();

				// DELETE
				_context.EmployeeSpecialties.RemoveRange(specialtiesToRemove);

				// INSERT
				foreach (var specialtyId in specialtiesToAdd)
				{
					_context.EmployeeSpecialties.Add(new EmployeeSpecialty
					{
						EmployeeId = id,
						SpecialtyId = specialtyId,
						CreateDate = DateTime.Now,
						CreateUser = dto.EditUser
					});
				}

				// Auditoría del cambio
				// Change audit
				employee.EditDate = DateTime.Now;
			    employee.EditUser = dto.EditUser;

				await _context.SaveChangesAsync();

				return NoContent();
			}
		

		

		/**************************************/

		//DELETE
		[HttpDelete("{id}")]

		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			
			if (employee == null)
				return NotFound();

			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();

			return NoContent();

		} 
	}
}