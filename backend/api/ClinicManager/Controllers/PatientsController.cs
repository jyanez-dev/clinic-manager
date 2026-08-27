using Microsoft.AspNetCore.Mvc;
using ClinicManager.DTOs.Patients;
using ClinicManager.Data;
using ClinicManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ClinicManagerDbContext _context;

        public PatientsController(ClinicManagerDbContext context)
        {
            _context = context;
        }

        // Get: api/patinets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatiens()
        {
            var patients = await _context.Patients
                .Select(p => new PatientDto
                {
                    PatientId = p.PatientId,
                    FirstName1 = p.FirstName1,
                    LastName1 = p.LastName1,
                    FirstName2 = p.FirstName2,
                    DocTypeId = p.DocTypeId,
                    DocNum = p.DocNum,
                    Email = p.Email,
                    Observation = p.Observation,
                    CreateUser = p.CreateUser,
                    BirthDate = p.BirthDate,
                    Tel1 = p.Tel1,		
                    Tel2 = p.Tel2,
                    Mobile1 = p.Mobile1,
                    Mobile2 = p.Mobile2,
                    Address = p.Address,
                    Sex = p.Sex

	})
                .ToListAsync();
            return patients;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                FirstName1 = dto.FirstName1,
                LastName1 = dto.LastName1,
				FirstName2 = dto.FirstName2,
				LastName2 = dto.LastName2,
				DocTypeId = dto.DocTypeId,
                DocNum = dto.DocNum,
                Email = dto.Email,
                Status = true,
                Observation = dto.Observation,
                Sex = dto.Sex,
                CreateUser = dto.CreateUser,
				BirthDate = dto.BirthDate,
				Tel1 = dto.Tel1,
				Tel2 = dto.Tel2,
				Mobile1 = dto.Mobile1,
				Mobile2 = dto.Mobile2,
                Address = dto.Address,

			};

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var result = new PatientDto
            {
                PatientId = patient.PatientId,
                FirstName1 = patient.FirstName1,
                LastName1 = patient.LastName1,
				FirstName2 = patient.FirstName2,
				LastName2 = patient.LastName2,
				DocTypeId = patient.DocTypeId,
                DocNum = patient.DocNum,
                Email = patient.Email,
                Observation = patient.Observation,
                Sex= patient.Sex,
                CreateUser = patient.CreateUser,
				BirthDate = patient.BirthDate,
				Tel1 = patient.Tel1,
				Tel2 = patient.Tel2,
				Mobile1 = patient.Mobile1,
				Mobile2 = patient.Mobile2,
                Address = patient.Address,
			};

            return CreatedAtAction(nameof(GetPatiens), new { id = patient.PatientId }, result);

        }

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDto dto)
		{
			if (id != dto.PatientId)
				return BadRequest();

			var patient = await _context.Patients.FindAsync(id);

			if (patient == null)
				return NotFound();

			patient.FirstName1 = dto.FirstName1;
			patient.LastName1 = dto.LastName1;
			patient.FirstName2 = dto.FirstName2;
			patient.LastName2 = dto.LastName2;
			patient.DocTypeId = dto.DocTypeId;
            patient.DocNum = dto.DocNum;
			patient.Email = dto.Email;
			patient.Status = dto.Status;
			patient.EditUser = dto.EditUser;
            patient.Observation = dto.Observation;
            patient.Sex = dto.Sex;
            patient.BirthDate = dto.BirthDate;
            patient.Tel1 = dto.Tel1;
            patient.Tel2 = dto.Tel2;
            patient.Mobile1 = dto.Mobile1;
            patient.Mobile2 = dto.Mobile2;
            patient.Address = dto.Address;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePatient(int id)
		{
			var patient = await _context.Patients.FindAsync(id);

			if (patient == null)
				return NotFound();

			_context.Patients.Remove(patient);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}

