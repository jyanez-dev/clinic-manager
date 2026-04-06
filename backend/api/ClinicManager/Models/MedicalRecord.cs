namespace ClinicManager.Models
{
	public class MedicalRecord
	{
		public int MedicalRecordId { get; set; }
		public string? RecordNumber { get; set; }

		public int PatientId { get; set; }
		public Patient? Patient { get; set; }

		public int RecordTypeId { get; set; } = 1;
		public RecordType? RecordType { get; set; }

		public int? CreateUser { get; set; }
		public User? CreateUserNav { get; set; }
		public DateTime CreateDate { get; set; }

		public int? EditUser { get; set; }
		public User? EditUserNav { get; set; }
		public DateTime? EditDate { get; set; }
	}
}