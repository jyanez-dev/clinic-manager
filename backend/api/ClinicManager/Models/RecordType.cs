namespace ClinicManager.Models
{
	public class RecordType
	{
		public int RecordTypeId { get; set; }
		public string Name { get; set; } = string.Empty;

		//public ICollection<MedicalRecord>? MedicalRecords { get; set; }
	}
}