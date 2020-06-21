using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class HospitalDBContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }
   
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        public virtual DbSet<Prescription_Medicament> PrescribedMedicaments { get; set; }
        
        public virtual DbSet<Medicament> Medicament { get; set; }

        public HospitalDBContext()
        {

        }
        public HospitalDBContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(z => new { z.IdPrescription, z.IdMedicament });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Gerro", LastName = "There", Email = "GerroThere@general.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Hello", LastName = "there", Email = "Hellothere@general.com" }
                    
                    );
            modelBuilder.Entity<Patient>().HasData(
                    new Patient { IdPatient = 1, FirstName = "TausenTausen", LastName = "TausenTausen", BirthDate = new DateTime(2000, 10, 10) },

                    new Patient { IdPatient = 2, FirstName = "TausenTausen", LastName = "TausenTausen", BirthDate = new DateTime(2000, 10, 10) }
                    );
            modelBuilder.Entity<Medicament>().HasData(new Medicament
                    {
                        IdMedicament = 1,
                        Name = "TausenTausen",
                        Type = "Tausen",

                        Description = "TausenTausen"
                    },new Medicament
                    {
                        IdMedicament = 2,

                        Name = "TausenTausen",
                        Type = "Tausen",

                        Description = "TausenTausen"
                    });
            modelBuilder.Entity<Prescription>().HasData(new Prescription()
                {
                    IdPrescription = 1,
                    IdDoctor =1,
                    IdPatient = 1,
                    Date = new DateTime(2000,10,10),
                    DueDate = new DateTime(2000,10,10)
                });



            modelBuilder.Entity<Prescription_Medicament>().HasData(new Prescription_Medicament()
                {
                    IdPrescription = 1,
                    IdMedicament = 2,
                    Details = "TausenTausen",
                    Dose = 1000
                });
        }
    }
}
