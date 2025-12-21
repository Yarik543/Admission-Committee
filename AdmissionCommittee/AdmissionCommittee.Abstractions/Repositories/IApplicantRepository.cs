using System;
using System.Collections.Generic;
using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Abstractions.Repositories
{
    public interface IApplicantRepository
    {
        IReadOnlyList<Applicant> GetAll();
        void Add(Applicant applicant);
        void Update(Applicant applicant);
        void Remove(Guid id);
    }
}