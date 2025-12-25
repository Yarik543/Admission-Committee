using Microsoft.EntityFrameworkCore;
using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Data.EF
{
    public class AdmissionCommitteeDbContext : DbContext
    {
        // Конструктор для DI / AddDbContext
        public AdmissionCommitteeDbContext(DbContextOptions<AdmissionCommitteeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }

        // OnConfiguring можно удалить, если используем DI и конфигурацию в Program.cs
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AdmissionCommitteeDb;Trusted_Connection=True;");
        // }
    }
}