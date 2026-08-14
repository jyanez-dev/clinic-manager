namespace ClinicManager.DTOs.EmployeeSpecialties
{
	public class UpdateEmployeeSpecialtiesDTO
	{
		public List<int> SpecialtyIds { get; set; } = new();
		public int EditUser { get; set; }
	}
}
