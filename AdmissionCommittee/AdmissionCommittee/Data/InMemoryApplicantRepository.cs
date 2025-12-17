using System.ComponentModel;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Data
{
    public class InMemoryApplicantRepository
    {
        private readonly BindingList<Applicant> applicants = new();

        public BindingList<Applicant> GetAll()
        {
            return applicants;
        }

        public void Add(Applicant applicant)
        {
            applicants.Add(applicant);
        }

        public void Delete(Applicant applicant)
        {
            applicants.Remove(applicant);
        }
    }
}