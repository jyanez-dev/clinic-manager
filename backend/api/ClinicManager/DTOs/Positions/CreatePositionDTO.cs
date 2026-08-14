using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Positions
{
	public class CreatePositionDTO
	{
		[Required]
		public string Name { get; set; } = string.Empty;
	}
}
