using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Roles
{
	public class CreateRoleDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
	}
}
