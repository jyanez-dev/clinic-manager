using System.ComponentModel.DataAnnotations;

namespace ClinicManager.DTOs.Specialties
{
    public class CreateSpecialtyDTO
    {
        [Required]

        public string Name { get; set; } = string.Empty;

    }
}
