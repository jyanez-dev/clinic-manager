using ClinicManager.Models;

namespace ClinicManager.DTOs.MedicalRecords
{
	public class CreateMedicalRecordDto
	{
		public int AppointmentId { get; set; }
		public string? ChiefComplaint { get; set; }

		public string? Diagnosis { get; set; }
		public string? Treatment { get; set; }

		public string? Prescription { get; set; }

		public string? Observation { get; set; }

		public string? Recommendations { get; set; }

		public int? CreateUser { get; set; }
		//public DateTime CreateDate { get; set; }
		
	}
}
