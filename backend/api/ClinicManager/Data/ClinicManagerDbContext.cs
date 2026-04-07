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

		// Here you can configure relationships and composite keys
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Example of a composite key for UserRoles
			modelBuilder.Entity<UserRole>()
				.HasKey(ur => new { ur.UserId, ur.RoleId });

			// Relación User ↔ Doctor (1:1)
			modelBuilder.Entity<User>()
				.HasOne(u => u.Doctor)
				.WithOne(d => d.User)
				.HasForeignKey<Doctor>(d => d.UserId);

			// Additional configurations can be added here based on your relationships
		}
	}
}