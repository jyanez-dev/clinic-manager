using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Patients
{
	public class UpdatePatientDto
	{
		[Required]
		public int PatientId { get; set; }

		[Required]
		public string FirstName1 { get; set; } = string.Empty;

		[Required]
		public string LastName1 { get; set; } = string.Empty;

		[Required]
		public int EditUser { get; set; }

		public string? DocNum { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		public string? Observation { get; set; }

		public bool Status { get; set; }

		public short Sex { get; set; }  // 0=unknown, 1=male, 2=female
	}
}
