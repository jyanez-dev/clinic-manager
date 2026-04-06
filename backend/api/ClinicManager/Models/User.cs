using System.Numerics;
using System;
using System.Collections.Generic;

namespace ClinicManager.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? EditDate { get; set; }

		// Navigation properties
		public ICollection<UserRole>? UserRoles { get; set; }
		public Doctor? Doctor { get; set; }
	}
}