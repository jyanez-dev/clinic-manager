namespace ClinicManager.Models
{
    public class DoctorSpecialty
    {
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public int SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}
