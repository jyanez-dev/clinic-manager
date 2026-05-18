using ClinicManager.Models;

namespace ClinicManager.DTOs.DoctorSpecialties
{
    public class DoctorSpecialtyDTO
    {
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }

        public int SpecialtyId { get; set; }
        public string? SpecialtyName  { get; set; } 


    }
}

