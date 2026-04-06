using Microsoft.EntityFrameworkCore;
using ClinicManager.Models;

namespace ClinicManager.Data
{
	public class ClinicManagerDbContext : DbContext
	{
		public ClinicManagerDbContext(DbContextOptions<ClinicManagerDbContext> options)
			: base(options)
		{
		}

		// Tablas
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<DocumentType> DocumentTypes { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<RecordType> RecordTypes { get; set; }
		public DbSet<MedicalRecord> MedicalRecords { get; set; }

		// Si quieres, aquí se pueden configurar relaciones y llaves compuestas
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Ejemplo de llave compuesta para UserRoles
			modelBuilder.Entity<UserRole>()
				.HasKey(ur => new { ur.UserId, ur.RoleId });

			// Relación User ↔ Doctor (1:1)
			modelBuilder.Entity<User>()
				.HasOne(u => u.Doctor)
				.WithOne(d => d.User)
				.HasForeignKey<Doctor>(d => d.UserId);

			// Aquí se pueden agregar más configuraciones según tus relaciones
		}
	}
}