using AdmissionCommittee.Abstractions.Contracts;

namespace AdmissionCommittee.Abstractions
{
    public interface IApplicantRepository
    {
        IEnumerable<ApplicantDto> GetAll();
        void Add(ApplicantDto applicant);
        void Update(ApplicantDto applicant);
        void Delete(ApplicantDto applicant);
    }
}