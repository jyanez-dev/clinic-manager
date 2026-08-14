using ClinicManager.Data;
using ClinicManager.DTOs.Appointments;
using ClinicManager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

					EmployeeId = a.EmployeeId,
					EmployeeName = a.Employee.FirstName1 + " " + a.Employee.LastName1,
				
					AppointmentDateTime = a.AppointmentDateTime,

					AppointmentStatusId = a.AppointmentStatusId,
					StatusName = a.AppointmentStatus.Name,

					Description = a.Description,
					Amount = a.Amount,
					Observation = a.Observation
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
				EmployeeId = dto.EmployeeId,
				AppointmentDateTime = dto.AppointmentDateTime,
				AppointmentStatusId = dto.AppointmentStatusId,
				CreateUser =dto.CreateUser,
				CreateDate = DateTime.Now,
				Description = dto.Description,
				Amount = dto.Amount,
				Observation = dto.Observation
			};

			_context.Appointments.Add(appointment);
			await _context.SaveChangesAsync();

			
			var result = new AppointmentDto
			{
			    PatientId = appointment.PatientId,
				EmployeeId = appointment.EmployeeId,
				AppointmentDateTime = appointment.AppointmentDateTime,
				AppointmentStatusId = appointment.AppointmentStatusId,
				//CreateUser = appointment.CreateUser,
				//CreateDate = DateTime.Now,
				Description = appointment.Description,
				Amount = appointment.Amount,
				Observation = appointment.Observation
			};

			//return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmployeeId }, result);
			
			return CreatedAtAction(nameof(GetAppointments),
				new { id = appointment.AppointmentId },
				result);
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
			appointment.EmployeeId = dto.EmployeeId;
			appointment.AppointmentDateTime = dto.AppointmentDateTime;
			appointment.AppointmentStatusId = dto.AppointmentStatusId;
			appointment.Description = dto.Description;
			appointment.Amount = dto.Amount;
			appointment.Observation = dto.Observation;
			appointment.EditUser = dto.EditUser;
			appointment.EditDate = DateTime.Now;

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

					EmployeeId = a.EmployeeId,
					EmployeeName = a.Employee.FirstName1 + " " + a.Employee.LastName1,

					//DoctorName = a.Doctor.User.UserName,

					AppointmentDateTime = a.AppointmentDateTime,

					AppointmentStatusId = a.AppointmentStatusId,
					StatusName = a.AppointmentStatus.Name,

					Description = a.Description,
					Amount = a.Amount,
					Observation = a.Observation
				})
				.FirstOrDefaultAsync();

			if (appointment == null)
				return NotFound();

			return appointment;
		}
	}
}