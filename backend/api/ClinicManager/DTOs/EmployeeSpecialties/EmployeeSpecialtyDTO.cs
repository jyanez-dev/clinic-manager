using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.EmployeeSpecialties
{
	public class EmployeeSpecialtyDTO
	{
		public int EmployeeId { get; set; }
		public string? EmployeeName { get; set; }

		public int SpecialtyId { get; set; }
		public string? SpecialtyName { get; set; }

		public int CreateUser { get; set; }

		public string? UserName { get; set; }

	}
}
