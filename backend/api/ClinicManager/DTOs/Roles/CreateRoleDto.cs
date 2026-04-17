using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Roles
{
	public class CreateRoleDto
	{
		[Required]
		public string RoleName { get; set; } = string.Empty;
	}
}
