using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.DTOs.Users
{
	public class CreateUserDto
	{
		[Required]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		public string LastName { get; set; } = string.Empty;

		[Required]
		public string UserName { get; set; } = string.Empty;

		[Required]
		public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public int CreateUser { get; set; }

        [EmailAddress]
		public string? EmailAddress { get; set; }
		public string? Phone { get; set; }

	}
}