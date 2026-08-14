using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Positions
{
	public class UpdatePositionDTO
	{
		[Required]	
		public int PositionId { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
	}
}
