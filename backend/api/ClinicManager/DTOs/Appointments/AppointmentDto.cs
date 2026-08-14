namespace ClinicManager.DTOs.Appointments
{
	public class AppointmentDto
	{
		public int AppointmentId { get; set; }

		public int PatientId { get; set; }
		public string? PatientName { get; set; }

		public int EmployeeId { get; set; }
		public string? EmployeeName { get; set; }

		public DateTime? AppointmentDateTime { get; set; }
		
		public int AppointmentStatusId { get; set; }
		public string? StatusName { get; set; }

		public string? Observation { get; set; }

		public string? Description { get; set; }
		public decimal? Amount { get; set; }
	}
}