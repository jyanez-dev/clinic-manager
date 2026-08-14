namespace ClinicManager.Models
{
	public class EmployeePosition
	{
		public int EmployeeId { get; set; }
		public Employee? Employee { get; set; }

		public int PositionId { get; set; }
		public Position? Position { get; set; }

		public DateTime CreateDate { get; set; }
		public int CreateUser { get; set; }
	}
}
