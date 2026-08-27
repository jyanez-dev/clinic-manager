using ClinicManager.Data;
using ClinicManager.DTOs.MedicalRecords;
using ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClinicManager.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class MedicalRecordsController : ControllerBase
	{
			private readonly ClinicManagerDbContext _context;

		// Constructor with DbContext injection
		public MedicalRecordsController(ClinicManagerDbContext context)
		{
			_context = context;
		}

		[HttpGet]

		public async Task<ActionResult<IEnumerable<MedicalRecordDto>>> GetMedicalRecords() 
		{

			var medicalRecord = await _context.MedicalRecords 
			   .Select(mr => new MedicalRecordDto
			   {

					MedicalRecordId = mr.MedicalRecordId,
					AppointmentId = mr.AppointmentId,
				    ChiefComplaint = mr.ChiefComplaint,
					Diagnosis = mr.Diagnosis,
				    Treatment = mr.Treatment,
				    Prescription = mr.Prescription,
				    Observation = mr.Observation,
				    Recommendations = mr.Recommendations,
				    CreateUser = mr.CreateUser,
					CreateDate = mr.CreateDate
			   })
			   .ToListAsync();

			return medicalRecord;

		}

		//POST: api/medicalreport
		// Creates a new medicalreport
	    [HttpPost]
		public async Task<ActionResult<MedicalRecordDto>> CreateMedicalReport(CreateMedicalRecordDto dto)
		{
			var medicalRecord = new MedicalRecord
			{
				AppointmentId = dto.AppointmentId,
				ChiefComplaint = dto.ChiefComplaint,
				Diagnosis = dto.Diagnosis,
				Treatment = dto.Treatment,
				Prescription = dto.Prescription,
				Observation = dto.Observation,
				Recommendations = dto.Recommendations,
				CreateUser = dto.CreateUser,
			};

			_context.MedicalRecords.Add(medicalRecord);
			await _context.SaveChangesAsync();


			var result = new MedicalRecordDto
			{
				AppointmentId = medicalRecord.AppointmentId,
				ChiefComplaint = medicalRecord.ChiefComplaint,
				Diagnosis = medicalRecord.Diagnosis,
				Treatment = medicalRecord.Treatment,
				Prescription = medicalRecord.Prescription,
				Observation = medicalRecord.Observation,
				Recommendations = medicalRecord.Recommendations,
				CreateUser = medicalRecord.CreateUser,
			};



			return CreatedAtAction(nameof(GetMedicalRecords),
				new { id = medicalRecord.MedicalRecordId },	result);
		}
		
		

		// PUT: api/medicalreport/{id}
		// Updates an medicalreport

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMedicalRecord(int id, UpdateMedicalRecordDto dto)
		{
			if (id != dto.MedicalRecordId)
				return BadRequest();

			var medicalRecord = await _context.MedicalRecords.FindAsync(id);

			if (medicalRecord == null)
				return NotFound();

			medicalRecord.MedicalRecordId = dto.MedicalRecordId;
			medicalRecord.AppointmentId = dto.AppointmentId;
			medicalRecord.ChiefComplaint = dto.ChiefComplaint;

			medicalRecord.Diagnosis = dto.Diagnosis;
			medicalRecord.Treatment = dto.Treatment;
			medicalRecord.Prescription = dto.Prescription;
			medicalRecord.Observation = dto.Observation;
			medicalRecord.Recommendations = dto.Recommendations;
			medicalRecord.EditUser = dto.EditUser;
			    
			await _context.SaveChangesAsync();

			return NoContent();
		}


		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMedicalRecord(int id)
		{
			var medicalRecord = await _context.MedicalRecords.FindAsync(id);

			if (medicalRecord == null)
				return NotFound();

			_context.MedicalRecords.Remove(medicalRecord);
			await _context.SaveChangesAsync();

			return NoContent();
		}


	}


}

