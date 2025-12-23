using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AdmissionCommittee.Data.EF;

namespace AdmissionCommittee.Data.EF
{
    public class ApplicantEfRepository : IApplicantRepository
    {
        private readonly AdmissionCommitteeDbContext _context;

        public ApplicantEfRepository()
        {
            _context = new AdmissionCommitteeDbContext();
            _context.Database.EnsureCreated();
        }

        public IReadOnlyList<Applicant> GetAll()
            => _context.Applicants.AsNoTracking().ToList();

        public void Add(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
        }

        public void Update(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var applicant = _context.Applicants.FirstOrDefault(a => a.Id == id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                _context.SaveChanges();
            }
        }
    }
}