using System.ComponentModel.DataAnnotations;

namespace ClinicManager.Models
{
	public class DocumentType
	{
		[Key]
		public int DocTypeId { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<Patient>? Patients { get; set; }
	}
}
