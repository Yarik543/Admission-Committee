using AdmissionCommittee.Abstractions.Contracts;

namespace AdmissionCommittee.Abstractions
{
    public interface IApplicantRepository
    {
        IEnumerable<ApplicantDto> GetAll();
        ApplicantDto? GetById(Guid id);

        void Add(ApplicantDto applicant);
        void Update(ApplicantDto applicant);
        void Delete(Guid id);
    }
}