namespace ClinicManager.DTOs.AppointmentStatus
{
	public class UpdateAppointmentStatusDto
	{
		public int AppointmentStatusId { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}