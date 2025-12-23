using AdmissionCommittee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AdmissionCommittee.Data.EF;

namespace AdmissionCommittee.Data.EF
{
    public class AdmissionCommitteeDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=admission.db");
        }
    }
}