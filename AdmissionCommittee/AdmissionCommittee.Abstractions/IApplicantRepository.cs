using AdmissionCommittee.Domain.Entities;

namespace AdmissionCommittee.Abstractions;

public interface IApplicantRepository
{
    IReadOnlyList<Applicant> GetAll();
    void Add(Applicant applicant);
    void Update(Applicant applicant);
    void Delete(Applicant applicant);
}