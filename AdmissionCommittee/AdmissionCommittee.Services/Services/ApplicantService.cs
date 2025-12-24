using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdmissionCommittee.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository repository;

        public ApplicantService(
            IApplicantRepository repository,
            ILogger<ApplicantService> logger)
        {
            this.repository = repository;
        }

        public Task<IReadOnlyList<Applicant>> GetAllAsync()
            => repository.GetAllAsync();

        public Task AddAsync(Applicant applicant)
            => repository.AddAsync(applicant);

        public Task UpdateAsync(Applicant applicant)
            => repository.UpdateAsync(applicant);

        public Task RemoveAsync(Guid id)
            => repository.RemoveAsync(id);

        // синхронную статистику можно оставить
        public int CountAll(IReadOnlyList<Applicant> applicants)
    => applicants.Count;

        public int CountPassed(IReadOnlyList<Applicant> applicants, int minScore)
            => applicants.Count(a =>
                a.MathScore + a.RusScore + a.ITScore >= minScore);
    }
}