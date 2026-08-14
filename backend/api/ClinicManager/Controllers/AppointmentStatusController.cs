using ClinicManager.Data;
using ClinicManager.DTOs.Appointments;
using ClinicManager.DTOs.AppointmentStatus;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		public async Task<ActionResult<IEnumerable<AppointmentStatusDto>>> GetAppointmentStatus()
		{
			return await _context.AppointmentStatuses
				.Select(x => new AppointmentStatusDto
				{
					AppointmentStatusId = x.AppointmentStatusId,
					Name = x.Name
				})
				.ToListAsync();
		}

		// POST
		[HttpPost]
		public async Task<ActionResult> Create(CreateAppointmentStatusDto dto)
		{
			var appointmentStatus = new AppointmentStatus
			{
				Name = dto.Name
			};

			_context.AppointmentStatuses.Add(appointmentStatus);
			await _context.SaveChangesAsync();

			var result = new AppointmentStatusDto
			{
				Name = appointmentStatus.Name
			};
			
			return CreatedAtAction(nameof(GetAppointmentStatus),
				new { id = appointmentStatus.AppointmentStatusId },	result);
		
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateAppointmentStatusDto dto)
		{
			var appointmentStatus = await _context.AppointmentStatuses.FindAsync(id);

			if (appointmentStatus == null)
				return NotFound();

			appointmentStatus.Name = dto.Name;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var appointmentStatus = await _context.AppointmentStatuses.FindAsync(id);

			if (appointmentStatus == null)
				return NotFound();

			_context.AppointmentStatuses.Remove(appointmentStatus);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}