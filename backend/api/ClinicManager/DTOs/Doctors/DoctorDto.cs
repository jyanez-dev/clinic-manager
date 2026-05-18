namespace ClinicManager.DTOs.Doctors
{
	public class DoctorDto
	{
		public int DoctorId { get; set; }

		public int UserId { get; set; }
		public string? UserName { get; set; }

		public bool Active { get; set; }
	}
}
