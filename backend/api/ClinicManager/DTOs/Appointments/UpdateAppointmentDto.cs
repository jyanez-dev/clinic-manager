using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Appointments
{
	public class UpdateAppointmentDto
	{
		[Required]
		public int AppointmentId { get; set; }

		[Required]
		public int PatientId { get; set; }

		[Required]
		public int EmployeeId { get; set; }

		[Required]
		public DateTime? AppointmentDateTime { get; set; }

		[Required]
		public int AppointmentStatusId { get; set; }

		[Required]
		public int EditUser { get; set; }

		public string? Observation { get; set; }
		public string? Description { get; set; }

		public decimal? Amount { get; set; }
	}
}