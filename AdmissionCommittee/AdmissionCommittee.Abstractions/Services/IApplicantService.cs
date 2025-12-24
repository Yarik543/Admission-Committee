using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Abstractions.Services
{
    public interface IApplicantService
    {
        Task<IReadOnlyList<Applicant>> GetAllAsync();
        Task AddAsync(Applicant applicant);
        Task UpdateAsync(Applicant applicant);
        Task RemoveAsync(Guid id);

        int CountAll(IReadOnlyList<Applicant> applicants);
        int CountPassed(IReadOnlyList<Applicant> applicants, int minScore);
    }
}