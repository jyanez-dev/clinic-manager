using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Doctors
{
	public class CreateDoctorDto
	{
		[Required]
		public int UserId { get; set; }
		
        [Required]
        public int CreateUser { get; set; }

        public bool Active { get; set; } = true;
	}
}
