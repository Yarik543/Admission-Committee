using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;

        public ApplicantService(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<Applicant> GetAll()
            => _repository.GetAll();

        public void Add(Applicant applicant)
            => _repository.Add(applicant);

        public void Update(Applicant applicant)
            => _repository.Update(applicant);

        public void Remove(Guid id)
            => _repository.Remove(id);

        public int CountAll()
            => _repository.GetAll().Count;

        public int CountPassed(int minTotalScore)
            => _repository.GetAll()
                .Count(a => a.MathScore + a.RusScore + a.ITScore > minTotalScore);
    }
}