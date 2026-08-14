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
		public string Observation { get; set; }
		public short Sex { get; set; }  // 0=unknown, 1=male, 2=female
		public int CreateUser { get; set; }
	}

}