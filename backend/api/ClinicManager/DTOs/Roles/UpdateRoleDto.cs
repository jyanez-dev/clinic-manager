using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Roles
{
	public class UpdateRoleDto
	{
		[Required]
		public int RoleId { get; set; }

		[Required]
		public string RoleName { get; set; } = string.Empty;
	}
}
