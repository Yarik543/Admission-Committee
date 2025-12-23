using Microsoft.EntityFrameworkCore;
using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Data.EF;

public class AdmissionCommitteeDbContext : DbContext
{
    public DbSet<Applicant> Applicants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=AdmissionCommitteeDb;Trusted_Connection=True;");
    }
}