namespace ClinicManager.Models
{
	public class Appointment
	{
		public int AppointmentId { get; set; }
		public int PatientId { get; set; }
		public Patient? Patient { get; set; }

		public int DoctorId { get; set; }
		public Doctor? Doctor { get; set; }

		public DateTime? AppointmentDateTime { get; set; }
		public int AppointmentStatusId { get; set; } = 1;
		public AppointmentStatus? AppointmentStatus { get; set; }

		public string? Observation { get; set; }
		public string? Description { get; set; }
		public decimal? Amount { get; set; }

		public int? CreateUser { get; set; }
		public User? CreateUserNav { get; set; }
		public DateTime CreateDate { get; set; }
		public int? EditUser { get; set; }
		public User? EditUserNav { get; set; }
		public DateTime? EditDate { get; set; }
	}
}