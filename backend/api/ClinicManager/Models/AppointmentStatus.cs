using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManager.Models
{
	[Table("AppointmentStatus")]
	public class AppointmentStatus
	{
		public int AppointmentStatusId { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<Appointment>? Appointments { get; set; }
	}
}