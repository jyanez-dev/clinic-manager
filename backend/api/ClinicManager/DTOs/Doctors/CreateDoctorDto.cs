using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Doctors
{
	public class CreateDoctorDto
	{
		[Required]
		public int UserId { get; set; }

		[Required]
		public string Specialty { get; set; } = string.Empty;

		public bool Active { get; set; } = true;
	}
}
