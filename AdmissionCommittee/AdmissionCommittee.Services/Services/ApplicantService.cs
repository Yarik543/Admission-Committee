using AdmissionCommittee.Abstractions;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionCommittee.Services.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository repository;

        public ApplicantService(IApplicantRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyList<Applicant> GetAll()
            => repository.GetAll();

        public void Add(Applicant applicant)
        {
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            repository.Add(applicant);
        }

        public void Update(Applicant applicant)
        {
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            repository.Update(applicant);
        }

        public void Remove(Guid id)
            => repository.Remove(id);

        public int CountAll()
            => repository.GetAll().Count;

        public int CountPassed(int minTotalScore)
            => repository
                .GetAll()
                .Count(a =>
                    a.MathScore + a.RusScore + a.ITScore >= minTotalScore);
    }
}