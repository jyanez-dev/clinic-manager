using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Users
{
	public class UpdateUserDto
	{
		[Required]
		public int UserId { get; set; }

		[Required]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		public string LastName { get; set; } = string.Empty;

		[Required]
		public string UserName { get; set; } = string.Empty;

		[EmailAddress]
		public string? Email { get; set; }

		public string? Phone { get; set; }

		public bool IsActive { get; set; }
	}
}