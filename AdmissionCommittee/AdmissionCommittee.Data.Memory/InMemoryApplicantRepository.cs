using AdmissionCommittee.Abstractions;
using AdmissionCommittee.Abstractions.Contracts;

namespace AdmissionCommittee.Data.Memory
{
    public class InMemoryApplicantRepository : IApplicantRepository
    {
        private readonly List<ApplicantDto> applicants = new();

        public IEnumerable<ApplicantDto> GetAll()
            => applicants;

        public void Add(ApplicantDto applicant)
            => applicants.Add(applicant);

        public void Update(ApplicantDto applicant)
        {
            // позже
        }

        public void Delete(ApplicantDto applicant)
            => applicants.Remove(applicant);
    }
}