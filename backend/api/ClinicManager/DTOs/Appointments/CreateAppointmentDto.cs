using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Appointments
{
	public class CreateAppointmentDto
	{
		[Required]
		public int PatientId { get; set; }

		[Required]
		public int DoctorId { get; set; }

		[Required]
		public DateTime? AppointmentDateTime { get; set; }

		[Required]
		public int AppointmentStatusId { get; set; }

		public string? Description { get; set; }

		public decimal? Amount { get; set; }
	}
}