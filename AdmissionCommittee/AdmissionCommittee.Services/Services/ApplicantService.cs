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
        private readonly IApplicantRepository _repository;
        private readonly ILogger<ApplicantService> _logger;

        public ApplicantService(
            IApplicantRepository repository,
            ILogger<ApplicantService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IReadOnlyList<Applicant> GetAll()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = _repository.GetAll();

            stopwatch.Stop();
            _logger.LogInformation(
                "Method {Method} executed in {Elapsed} ms",
                nameof(GetAll),
                stopwatch.ElapsedMilliseconds);

            return result;
        }

        public void Add(Applicant applicant)
        {
            var stopwatch = Stopwatch.StartNew();

            _repository.Add(applicant);

            stopwatch.Stop();
            _logger.LogInformation(
                "Method {Method} executed in {Elapsed} ms",
                nameof(Add),
                stopwatch.ElapsedMilliseconds);
        }

        public void Update(Applicant applicant)
        {
            var stopwatch = Stopwatch.StartNew();

            _repository.Update(applicant);

            stopwatch.Stop();
            _logger.LogInformation(
                "Method {Method} executed in {Elapsed} ms",
                nameof(Update),
                stopwatch.ElapsedMilliseconds);
        }

        public void Remove(Guid id)
        {
            var stopwatch = Stopwatch.StartNew();

            _repository.Remove(id);

            stopwatch.Stop();
            _logger.LogInformation(
                "Method {Method} executed in {Elapsed} ms",
                nameof(Remove),
                stopwatch.ElapsedMilliseconds);
        }

        public int CountAll()
        {
            var stopwatch = Stopwatch.StartNew();

            var count = _repository.GetAll().Count;

            stopwatch.Stop();
            _logger.LogInformation(
                "Method {Method} executed in {Elapsed} ms",
                nameof(CountAll),
                stopwatch.ElapsedMilliseconds);

            return count;
        }

        public int CountPassed(int minTotalScore)
        {
            var stopwatch = Stopwatch.StartNew();

            var count = _repository.GetAll()
                .Count(a => a.MathScore + a.RusScore + a.ITScore > minTotalScore);

            stopwatch.Stop();
            _logger.LogInformation(
                "Method {Method} executed in {Elapsed} ms",
                nameof(CountPassed),
                stopwatch.ElapsedMilliseconds);

            return count;
        }
    }
}