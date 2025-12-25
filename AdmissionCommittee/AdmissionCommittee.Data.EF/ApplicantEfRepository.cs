using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Data.EF
{
    public class ApplicantEfRepository : IApplicantRepository
    {
        private readonly AdmissionCommitteeDbContext _context;

        // DbContext приходит из DI
        public ApplicantEfRepository(AdmissionCommitteeDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Applicant>> GetAllAsync()
        {
            return await _context.Applicants
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Applicant applicant)
        {
            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var applicant = await _context.Applicants
                .FirstOrDefaultAsync(a => a.Id == id);

            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
            }
        }
    }
}