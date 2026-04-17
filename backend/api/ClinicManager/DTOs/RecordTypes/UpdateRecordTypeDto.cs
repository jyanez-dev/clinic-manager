namespace ClinicManager.DTOs.RecordTypes
{
	public class UpdateRecordTypeDto
	{
		public int RecordTypeId { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
