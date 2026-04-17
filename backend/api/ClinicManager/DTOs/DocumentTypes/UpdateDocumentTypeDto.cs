namespace ClinicManager.DTOs.DocumentTypes
{
	public class UpdateDocumentTypeDto
	{
		public int DocTypeId { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
