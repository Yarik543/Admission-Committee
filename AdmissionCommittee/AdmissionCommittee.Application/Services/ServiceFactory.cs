using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Abstractions.Services;

namespace AdmissionCommittee.Application.Services
{
    public static class ServiceFactory
    {
        public static IApplicantService CreateApplicantService()
        {
            IApplicantRepository repository = new InMemoryApplicantRepository();
            return new ApplicantService(repository);
        }
    }
}