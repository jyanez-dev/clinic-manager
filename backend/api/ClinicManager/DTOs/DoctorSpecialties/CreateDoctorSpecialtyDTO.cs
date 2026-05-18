using ClinicManager.Models;

namespace ClinicManager.DTOs.DoctorSpecialties
{
    public class CreateDoctorSpecialtyDTO
    {
        public int DoctorId { get; set; }
        
        public int SpecialtyId { get; set; }
        
        public int CreateUser { get; set; }
    }
}
