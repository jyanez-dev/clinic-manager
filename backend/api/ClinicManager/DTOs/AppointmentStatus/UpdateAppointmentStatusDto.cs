namespace ClinicManager.DTOs.AppointmentStatus
{
	public class UpdateAppointmentStatusDto
	{
		public int AppointmentStatusId { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}