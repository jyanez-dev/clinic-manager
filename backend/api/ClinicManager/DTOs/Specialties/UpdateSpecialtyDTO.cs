using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Specialties
{
    public class UpdateSpecialtyDTO
    {
        [Required]
        public int SpecialtyId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
