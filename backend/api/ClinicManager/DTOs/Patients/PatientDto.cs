using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Patients
{
	public class PatientDto
	{
		
	    public int PatientId { get; set; }
		public string FirstName1 { get; set; } = string.Empty;
		public string LastName1 { get; set; } = string.Empty;
		public string? DocNum { get; set; }
		public string? Email { get; set; }
	}

}