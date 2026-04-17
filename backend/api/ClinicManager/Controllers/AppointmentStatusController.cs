using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.AppointmentStatus;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AppointmentStatusController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		public AppointmentStatusController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/appointmentstatus
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AppointmentStatusDto>>> GetAll()
		{
			return await _context.AppointmentStatuses
				.Select(x => new AppointmentStatusDto
				{
					AppointmentStatusId = x.AppointmentStatusId,
					Description = x.Description
				})
				.ToListAsync();
		}

		// POST
		[HttpPost]
		public async Task<ActionResult> Create(CreateAppointmentStatusDto dto)
		{
			var entity = new AppointmentStatus
			{
				Description = dto.Description
			};

			_context.AppointmentStatuses.Add(entity);
			await _context.SaveChangesAsync();

			return Ok();
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateAppointmentStatusDto dto)
		{
			var entity = await _context.AppointmentStatuses.FindAsync(id);

			if (entity == null)
				return NotFound();

			entity.Description = dto.Description;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var entity = await _context.AppointmentStatuses.FindAsync(id);

			if (entity == null)
				return NotFound();

			_context.AppointmentStatuses.Remove(entity);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}