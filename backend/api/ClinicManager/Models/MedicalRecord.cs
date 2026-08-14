using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManager.Models
{
	public class MedicalRecord
	{
		public int MedicalRecordId { get; set; }
		public int AppointmentId { get; set; }
		public string? ChiefComplaint { get; set; }

		public string? Diagnosis { get; set; }
		public string? Treatment { get; set; }

		public string? Prescription { get; set; }

		public string? Observation { get; set; }

		public string? Recommendations { get; set; }

		public int? CreateUser { get; set; }
		[ForeignKey("CreateUser")]
		public User? CreateUserNav { get; set; }
		public DateTime CreateDate { get; set; }

		public int? EditUser { get; set; }
		
		[ForeignKey("EditUser")]
		public User? EditUserNav { get; set; }
		public DateTime? EditDate { get; set; }
	}
}