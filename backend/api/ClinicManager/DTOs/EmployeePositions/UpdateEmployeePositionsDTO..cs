namespace ClinicManager.DTOs.EmployeePositions
{
	public class UpdateEmployeePositionsDTO
	{
		public List<int> positionIds { get; set; } = new();
		public int EditUser { get; set; }
	}
}
