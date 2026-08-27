using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Employees
{
	public class EmployeeDTO
	{
		public int EmployeeId { get; set; }
		public int UserId { get; set; }
		public string FirstName1 { get; set; } = string.Empty;
		public string LastName1 { get; set; } = string.Empty;
		public int? DocTypeId { get; set; }
		[Required]
		public string? DocNum { get; set; }
		public string? Email { get; set; }
		public int CreateUser { get; set; }

		public string? Observation { get; set; }

		public short Sex { get; set; }  // 0=unknown, 1=male, 2=female


		public string? Address { get; set; }
		public string? FirstName2 { get; set; }
		public string? LastName2 { get; set; }

		public DateOnly? BirthDate { get; set; }

		public string? Tel1 { get; set; }
		public string? Tel2 { get; set; }
		public string? Mobile1 { get; set; }
		public string? Mobile2 { get; set; }
		public bool Status { get; set; }



	}
}
