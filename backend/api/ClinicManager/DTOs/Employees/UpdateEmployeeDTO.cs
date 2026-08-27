using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Employees
{
	public class UpdateEmployeeDTO
	{
		[Required]
		public int EmployeeId { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public string FirstName1 { get; set; } = string.Empty;

		[Required]
		public string LastName1 { get; set; } = string.Empty;

		[Required]
		public int EditUser { get; set; } 

		public string? DocNum { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		public bool Status { get; set; }

		public string Observation { get; set; }

		public short Sex { get; set; }  // 0=unknown, 1=male, 2=female

		public int? DocTypeId { get; set; }
		public string? Address { get; set; }
		public string? FirstName2 { get; set; }
		public string? LastName2 { get; set; }
		public DateOnly? BirthDate { get; set; }
		public string? Tel1 { get; set; }
		public string? Tel2 { get; set; }
		public string? Mobile1 { get; set; }
		public string? Mobile2 { get; set; }
		


	}
}
