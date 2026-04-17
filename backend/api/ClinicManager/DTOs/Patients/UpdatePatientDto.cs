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

		public string? DocNum { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		public bool Status { get; set; }
	}
}
