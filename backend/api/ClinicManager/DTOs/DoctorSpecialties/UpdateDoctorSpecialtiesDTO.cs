namespace ClinicManager.DTOs.DoctorSpecialties
{
    public class UpdateDoctorSpecialtiesDTO
    {
        public List<int> SpecialtyIds { get; set; } = new();
        public int EditUser { get; set; }
    }
}
