namespace ClinicManager.Models
{
	public class Doctor
	{
		public int DoctorId { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }

		public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int CreateUser { get; set; }
        public int? EditUser { get; set; }


        public ICollection<Appointment>? Appointments { get; set; }
	}
}