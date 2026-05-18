using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Roles
{
	public class UpdateRoleDto
	{
		[Required]
		public int RoleId { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;
	}
}
