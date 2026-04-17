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
                    DocNum = p.DocNum,
                    Email = p.Email
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
                DocNum = dto.DocNum,
                Email = dto.Email,
                Status = true,
                CreateDate = DateTime.Now,
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var result = new PatientDto
            {
                PatientId = patient.PatientId,
                FirstName1 = patient.FirstName1,
                LastName1 = patient.LastName1,
                DocNum = patient.DocNum,
                Email = patient.Email
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
			patient.DocNum = dto.DocNum;
			patient.Email = dto.Email;
			patient.Status = dto.Status;
			patient.EditDate = DateTime.Now;

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

/*
    
*/
/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Data;
using ClinicManager.Models;
using ClinicManager.DTOs.Patients;

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

        // GET: api/patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _context.Patients
                .Select(p => new PatientDto
                {
                    PatientId = p.PatientId,
                    FirstName1 = p.FirstName1,
                    LastName1 = p.LastName1,
                    DocNum = p.DocNum,
                    Email = p.Email
                })
                .ToListAsync();

            return patients;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                FirstName1 = dto.FirstName1,
                LastName1 = dto.LastName1,
                DocNum = dto.DocNum,
                Email = dto.Email,
                Status = true,
                CreateDate = DateTime.Now
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var result = new PatientDto
            {
                PatientId = patient.PatientId,
                FirstName1 = patient.FirstName1,
                LastName1 = patient.LastName1,
                DocNum = patient.DocNum,
                Email = patient.Email
            };

            return CreatedAtAction(nameof(GetPatients), new { id = patient.PatientId }, result);
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
            patient.DocNum = dto.DocNum;
            patient.Email = dto.Email;
            patient.Status = dto.Status;
            patient.EditDate = DateTime.Now;

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



 */