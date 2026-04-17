using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Patients
{
	public class CreatePatientDto
	{
		
		[Required]
		public string FirstName1 { get; set; } = string.Empty;
		[Required]
		public string LastName1 { get; set; } = string.Empty;
		public string? DocNum { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
	}
}
