using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.Doctors;

namespace ClinicManager.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DoctorsController : ControllerBase
	{
		private readonly ClinicManagerDbContext _context;

		// Constructor with DbContext injection
		public DoctorsController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		// GET: api/doctors
		// Returns all doctors
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
		{
			var doctors = await _context.Doctors
				.Select(d => new DoctorDto
				{
					DoctorId = d.DoctorId,
					UserId = d.UserId,
					UserName = d.User.UserName,
					Specialty = d.Specialty,
					Active = d.Active
				})
				.ToListAsync();

			return doctors;
		}

		// POST: api/doctors
		// Creates a new doctor
		[HttpPost]
		public async Task<ActionResult<DoctorDto>> CreateDoctor(CreateDoctorDto dto)
		{
			var doctor = new Doctor
			{
				UserId = dto.UserId,
				Specialty = dto.Specialty,
				Active = dto.Active
			};

			_context.Doctors.Add(doctor);
			await _context.SaveChangesAsync();

			var result = new DoctorDto
			{
				DoctorId = doctor.DoctorId,
				UserId = doctor.UserId,
				Specialty = doctor.Specialty,
				Active = doctor.Active,
				UserName = null // optional
			};

			return CreatedAtAction(nameof(GetDoctors), new { id = doctor.DoctorId }, result);
		}

		// PUT: api/doctors/{id}
		// Updates an existing doctor
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

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/doctors/{id}
		// Deletes a doctor
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDoctor(int id)
		{
			var doctor = await _context.Doctors.FindAsync(id);

			if (doctor == null)
				return NotFound();

			_context.Doctors.Remove(doctor);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}