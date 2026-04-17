using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.Appointments;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AppointmentsController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		// Constructor with DbContext injection
		public AppointmentsController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/appointments
		// Returns all appointments with related data
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
		{
			var appointments = await _context.Appointments
				.Select(a => new AppointmentDto
				{
					AppointmentId = a.AppointmentId,

					PatientId = a.PatientId,
					PatientName = a.Patient.FirstName1 + " " + a.Patient.LastName1,

					DoctorId = a.DoctorId,
					DoctorName = a.Doctor.User.UserName,

					AppointmentDateTime = a.AppointmentDateTime,

					AppointmentStatusId = a.AppointmentStatusId,
					StatusName = a.AppointmentStatus.Description,

					Description = a.Description,
					Amount = a.Amount
				})
				.ToListAsync();

			return appointments;
		}

		// POST: api/appointments
		// Creates a new appointment
		[HttpPost]
		public async Task<ActionResult<AppointmentDto>> CreateAppointment(CreateAppointmentDto dto)
		{
			var appointment = new Appointment
			{
				PatientId = dto.PatientId,
				DoctorId = dto.DoctorId,
				AppointmentDateTime = dto.AppointmentDateTime,
				AppointmentStatusId = dto.AppointmentStatusId,
				Description = dto.Description,
				Amount = dto.Amount
			};

			_context.Appointments.Add(appointment);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAppointments),
				new { id = appointment.AppointmentId },
				null);
		}

		// PUT: api/appointments/{id}
		// Updates an appointment
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto dto)
		{
			if (id != dto.AppointmentId)
				return BadRequest();

			var appointment = await _context.Appointments.FindAsync(id);

			if (appointment == null)
				return NotFound();

			appointment.PatientId = dto.PatientId;
			appointment.DoctorId = dto.DoctorId;
			appointment.AppointmentDateTime = dto.AppointmentDateTime;
			appointment.AppointmentStatusId = dto.AppointmentStatusId;
			appointment.Description = dto.Description;
			appointment.Amount = dto.Amount;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/appointments/{id}
		// Deletes an appointment
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAppointment(int id)
		{
			var appointment = await _context.Appointments.FindAsync(id);

			if (appointment == null)
				return NotFound();

			_context.Appointments.Remove(appointment);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// GET: api/appointments/{id}
		// Returns a single appointment by id
		[HttpGet("{id}")]
		public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
		{
			var appointment = await _context.Appointments
				.Where(a => a.AppointmentId == id)
				.Select(a => new AppointmentDto
				{
					AppointmentId = a.AppointmentId,

					PatientId = a.PatientId,
					PatientName = a.Patient.FirstName1 + " " + a.Patient.LastName1,

					DoctorId = a.DoctorId,
					DoctorName = a.Doctor.User.UserName,

					AppointmentDateTime = a.AppointmentDateTime,

					AppointmentStatusId = a.AppointmentStatusId,
					StatusName = a.AppointmentStatus.Description,

					Description = a.Description,
					Amount = a.Amount
				})
				.FirstOrDefaultAsync();

			if (appointment == null)
				return NotFound();

			return appointment;
		}
	}
}