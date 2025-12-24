using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Data.EF
{
    public class ApplicantEfRepository : IApplicantRepository
    {
        public async Task<IReadOnlyList<Applicant>> GetAllAsync()
        {
            using var context = new AdmissionCommitteeDbContext();
            return await context.Applicants
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Applicant applicant)
        {
            using var context = new AdmissionCommitteeDbContext();
            await context.Applicants.AddAsync(applicant);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Applicant applicant)
        {
            using var context = new AdmissionCommitteeDbContext();
            context.Applicants.Update(applicant);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            using var context = new AdmissionCommitteeDbContext();

            var applicant = await context.Applicants
                .FirstOrDefaultAsync(a => a.Id == id);

            if (applicant != null)
            {
                context.Applicants.Remove(applicant);
                await context.SaveChangesAsync();
            }
        }
    }
}