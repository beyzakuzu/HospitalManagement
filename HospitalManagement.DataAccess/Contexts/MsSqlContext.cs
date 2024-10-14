using Microsoft.EntityFrameworkCore;
using Core.Entities;
using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement.DataAccess.Contexts;
public class MsSqlContext : DbContext
{

    public MsSqlContext(DbContextOptions<MsSqlContext> opt) : base(opt)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1907; Database=Hospital_db; User=sa; Password=admin123456789; TrustServerCertificate=true",
            b => b.MigrationsAssembly("HospitalManagement.DataAccess"));
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

   
}


