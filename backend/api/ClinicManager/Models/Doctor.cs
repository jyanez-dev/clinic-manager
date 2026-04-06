namespace ClinicManager.Models
{
	public class Doctor
	{
		public int DoctorId { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }

		public string? Specialty { get; set; }
		public bool Active { get; set; }

		public ICollection<Appointment>? Appointments { get; set; }
	}
}