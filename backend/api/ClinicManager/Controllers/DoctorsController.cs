using ClinicManager.Data;
using ClinicManager.DTOs.Doctors;
using ClinicManager.DTOs.DoctorSpecialties;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
				Active = dto.Active,
                CreateDate = DateTime.Now,
                CreateUser = dto.CreateUser
            };

			_context.Doctors.Add(doctor);
			await _context.SaveChangesAsync();

			var result = new DoctorDto
			{
				DoctorId = doctor.DoctorId,
				UserId = doctor.UserId,
				Active = doctor.Active,
				UserName = null // optional
             };

			return CreatedAtAction(nameof(GetDoctors), new { id = doctor.DoctorId }, result);
		}

        /****/

		
        [HttpPut("{id}/specialties")]
        public async Task<IActionResult> UpdateDoctorSpecialties(int id, UpdateDoctorSpecialtiesDTO dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
                return NotFound();

            // Obtener roles actuales
            // Get current roles
            var currentSpecialties = await _context.DoctorSpecialties
                .Where(ds => ds.DoctorId == id)
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
            _context.DoctorSpecialties.RemoveRange(specialtiesToRemove);

            // INSERT
            foreach (var specialtyId in specialtiesToAdd)
            {
                _context.DoctorSpecialties.Add(new DoctorSpecialty
                {
                    DoctorId =  id, 
					SpecialtyId = specialtyId,
                    CreateDate = DateTime.Now,
                    CreateUser = dto.EditUser
                });
            }

            // Auditoría del cambio
            // Change audit
            doctor.EditDate = DateTime.Now;
            doctor.EditUser = dto.EditUser;

            await _context.SaveChangesAsync();

            return NoContent();
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
			doctor.Active = dto.Active;
            doctor.EditDate = DateTime.Now;
            doctor.EditUser = dto.EditUser;

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