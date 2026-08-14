using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Employees
{
	public class CreateEmployeeDTO
	{

		[Required]
		public int UserId { get; set; }
		[Required]
		public string FirstName1 { get; set; } = string.Empty;
		[Required]
		public string LastName1 { get; set; } = string.Empty;
		[Required]
		public int CreateUser { get; set; }
		[Required]
		public string? DocNum { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
		public string? Observation { get; set; }

		public short Sex { get; set; }  // 0=unknown, 1=male, 2=female
	}
}
