namespace ClinicManager.Models
{
	public class EmployeeSpecialty
	{
		public int EmployeeId { get; set; }
		public Employee? Employee { get; set; }

		public int SpecialtyId { get; set; }
		public Specialty? Specialty { get; set; }

		public DateTime CreateDate { get; set; }
		public int CreateUser { get; set; }
	}
}
