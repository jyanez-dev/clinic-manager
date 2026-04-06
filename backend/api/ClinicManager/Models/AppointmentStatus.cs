namespace ClinicManager.Models
{
	public class AppointmentStatus
	{
		public int AppointmentStatusId { get; set; }
		public string Description { get; set; } = string.Empty;

		public ICollection<Appointment>? Appointments { get; set; }
	}
}