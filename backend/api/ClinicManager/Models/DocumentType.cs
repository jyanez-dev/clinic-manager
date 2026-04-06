namespace ClinicManager.Models
{
	public class DocumentType
	{
		public int DocTypeId { get; set; }
		public string Description { get; set; } = string.Empty;

		public ICollection<Patient>? Patients { get; set; }
	}
}
