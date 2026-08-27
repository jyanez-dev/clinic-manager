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
		public int? DocTypeId { get; set; }
		[Required]
		public string? DocNum { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
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


		/*
		 * 
		 * public User? User { get; set; }
		public string DocNum { get; set; }
		public string? Address { get; set; }
		public string FirstName1 { get; set; } = string.Empty;
		public string? FirstName2 { get; set; }
		public string LastName1 { get; set; } = string.Empty;
		public string? LastName2 { get; set; }
		public int? DocTypeId { get; set; }
		public DocumentType? DocType { get; set; }
		public DateTime? BirthDate { get; set; }
		public short Sex { get; set; }  // 0=unknown, 1=male, 2=female
		public string? Tel1 { get; set; }
		public string? Tel2 { get; set; }
		public string? Mobile1 { get; set; }
		public string? Mobile2 { get; set; }
		public string? Email { get; set; }
		public string? Observation { get; set; }
		public bool Status { get; set; } = true;
		public int CreateUser { get; set; }
		[ForeignKey("CreateUser")]
		public User? CreateUserNav { get; set; }
		public DateTime CreateDate { get; set; }
		public int? EditUser { get; set; }
		[ForeignKey("EditUser")]
		public User? EditUserNav { get; set; }
		public DateTime? EditDate { get; set; }
		 * 
		 * 
		 * 
		 * */







	}
}
