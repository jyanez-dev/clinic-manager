using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Doctors
{
	public class UpdateDoctorDto
	{
		[Required]
		public int DoctorId { get; set; }

		[Required]
		public int UserId { get; set; }
				
        [Required]
        public int EditUser { get; set; }

        public bool Active { get; set; }
	}
}