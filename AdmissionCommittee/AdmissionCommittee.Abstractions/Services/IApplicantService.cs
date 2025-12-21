using AdmissionCommittee.Domain.Entities;
using System.Collections.Generic;

namespace AdmissionCommittee.Abstractions.Services
{
    public interface IApplicantService
    {
        IReadOnlyList<Applicant> GetAll();

        void Add(Applicant applicant);
        void Update(Applicant applicant);
        void Remove(Guid id);

        int CountAll();
        int CountPassed(int minTotalScore);
    }
}