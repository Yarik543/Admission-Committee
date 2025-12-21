using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Application.Services
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
            => repository.Add(applicant);

        public void Update(Applicant applicant)
            => repository.Update(applicant);

        public void Remove(Guid id)
            => repository.Remove(id);

        public int CountAll()
            => repository.GetAll().Count;

        public int CountPassed(int minTotalScore)
        {
            return repository.GetAll()
                .Count(a => a.MathScore + a.RusScore + a.ITScore > minTotalScore);
        }
    }
}