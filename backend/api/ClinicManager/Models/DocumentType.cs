using System.ComponentModel.DataAnnotations;

namespace ClinicManager.Models
{
	public class DocumentType
	{
		[Key]
		public int DocTypeId { get; set; }
		public string Description { get; set; } = string.Empty;

		public ICollection<Patient>? Patients { get; set; }
	}
}
