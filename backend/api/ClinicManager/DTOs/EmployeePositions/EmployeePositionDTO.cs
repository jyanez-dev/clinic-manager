namespace ClinicManager.DTOs.EmployeePositions
{
	public class EmployeePositionDTO
	{
		public int EmployeeId { get; set; }
		public string? EmployeeName { get; set; }

		public int PositionId { get; set; }
		public string? PositionName { get; set; }

		public int CreateUser { get; set; }

		public string? UserName { get; set; }
	}
}
