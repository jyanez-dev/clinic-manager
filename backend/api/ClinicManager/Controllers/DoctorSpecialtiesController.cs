using ClinicManager.Data;
using ClinicManager.DTOs.DoctorSpecialties;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClinicManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorSpecialtiesController: ControllerBase
    {
		private readonly ClinicManagerDbContext _context;

        // Constructor with dependency injection of DbContext
		public DoctorSpecialtiesController(ClinicManagerDbContext context)
		{
			_context = context;
		}

        // GET: api/doctorspecialty
        // Returns all user-role relationships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorSpecialtyDTO>>> GetDoctorSpecialty()
        {
            var doctorSpecialties = await _context.DoctorSpecialties
                .Select(ds => new DoctorSpecialtyDTO
                {
                    DoctorId = ds.DoctorId,
                    //DoctorName = ds.Doctor.UserId.na

                    SpecialtyId = ds.SpecialtyId,
					//SpecialtyName = ds.Specialty.Name
                    
                })
                .ToListAsync();

            return doctorSpecialties;
        }
        /*
        // POST: api/userroles
        // Creates a new user-role relationship
        [HttpPost]
        public async Task<ActionResult<DoctorSpecialtyDTO>> CreateDoctorSpecialty(CreateDoctorSpecialtyDTO dto)
        {
            var doctorSpecialty = new DoctorSpecialty
            {
                DoctorId = dto.DoctorId,
                SpecialtyId = dto.SpecialtyId,
                CreateDate = DateTime.Now,
                CreateUser = dto.CreateUser
            };

             _context.DoctorSpecialties.Add(doctorSpecialty);
            await _context.SaveChangesAsync();

            var result = new DoctorSpecialtyDTO
            {
                DoctorId = doctorSpecialty.DoctorId ,
                SpecialtyId  = doctorSpecialty.SpecialtyId,
                DoctorName = null, // Optional: can be loaded if needed
                SpecialtyName = null
            };

            return CreatedAtAction(nameof(GetDoctorSpecialty),
            new { doctorId = doctorSpecialty.DoctorId, specialtyId = doctorSpecialty.SpecialtyId },
            result);

        }
        */

        // DELETE: api/userroles
        // Deletes a user-role relationship
        [HttpDelete("{doctorId}/{specialtyId}")]
        public async Task<IActionResult> DeleteDoctorSpecialty(int doctorId, int specialtyId)
        {
            var doctorSpecialty = await _context.DoctorSpecialties
                .FirstOrDefaultAsync(ds =>
                    ds.DoctorId  == doctorId &&
                    ds.SpecialtyId == specialtyId);

            if (doctorSpecialty == null)
                return NotFound();

            _context.DoctorSpecialties.Remove(doctorSpecialty);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}

