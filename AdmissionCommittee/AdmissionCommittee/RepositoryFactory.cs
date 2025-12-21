using AdmissionCommittee.Abstractions;
using AdmissionCommittee.Data.Memory.Repositories;

public static class RepositoryFactory
{
    public static IApplicantRepository Create()
    {
        return new InMemoryApplicantRepository();
    }
}