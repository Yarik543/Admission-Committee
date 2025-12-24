using System;
using System.Collections.Generic;
using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Abstractions.Repositories
{
    public interface IApplicantRepository
    {
        Task AddAsync(Applicant applicant);
        Task UpdateAsync(Applicant applicant);
        Task RemoveAsync(Guid id);
        Task<IReadOnlyList<Applicant>> GetAllAsync();
    }
}