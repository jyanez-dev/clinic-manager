// ========================
// User.cs
// ========================
namespace ClinicManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }

        // Navigation properties
        public ICollection<UserRole>? UserRoles { get; set; }
        public Doctor? Doctor { get; set; }
    }
}

// ========================
// Role.cs
// ========================
namespace ClinicManager.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}

// ========================
// UserRole.cs
// ========================
namespace ClinicManager.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}

// ========================
// Doctor.cs
// ========================
namespace ClinicManager.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public string? Specialty { get; set; }
        public bool Active { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}

// ========================
// DocumentType.cs
// ========================
namespace ClinicManager.Models
{
    public class DocumentType
    {
        public int DocTypeId { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Patient>? Patients { get; set; }
    }
}

// ========================
// Patient.cs
// ========================
namespace ClinicManager.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? DocNum { get; set; }
        public string? Address { get; set; }
        public string FirstName1 { get; set; } = string.Empty;
        public string? FirstName2 { get; set; }
        public string LastName1 { get; set; } = string.Empty;
        public string? LastName2 { get; set; }
        public int? DocTypeId { get; set; }
        public DocumentType? DocType { get; set; }
        public DateTime? BirthDate { get; set; }
        public short Sex { get; set; }  // 0=unknown, 1=male, 2=female
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Email { get; set; }
        public string? Obs { get; set; }
        public bool Status { get; set; } = true;
        public int? CreateUser { get; set; }
        public User? CreateUserNav { get; set; }
        public DateTime CreateDate { get; set; }
        public int? EditUser { get; set; }
        public User? EditUserNav { get; set; }
        public DateTime? EditDate { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
    }
}

// ========================
// AppointmentStatus.cs
// ========================
namespace ClinicManager.Models
{
    public class AppointmentStatus
    {
        public int AppointmentStatusId { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Appointment>? Appointments { get; set; }
    }
}

// ========================
// Appointment.cs
// ========================
namespace ClinicManager.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public DateTime? AppointmentDateTime { get; set; }
        public int AppointmentStatusId { get; set; } = 1;
        public AppointmentStatus? AppointmentStatus { get; set; }

        public string? Observation { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }

        public int? CreateUser { get; set; }
        public User? CreateUserNav { get; set; }
        public DateTime CreateDate { get; set; }
        public int? EditUser { get; set; }
        public User? EditUserNav { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

// ========================
// RecordType.cs
// ========================
namespace ClinicManager.Models
{
    public class RecordType
    {
        public int RecordTypeId { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
    }
}

// ========================
// MedicalRecord.cs
// ========================
namespace ClinicManager.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public string? RecordNumber { get; set; }

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int RecordTypeId { get; set; } = 1;
        public RecordType? RecordType { get; set; }

        public int? CreateUser { get; set; }
        public User? CreateUserNav { get; set; }
        public DateTime CreateDate { get; set; }

        public int? EditUser { get; set; }
        public User? EditUserNav { get; set; }
        public DateTime? EditDate { get; set; }
    }
}