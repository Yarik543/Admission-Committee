using AdmissionCommittee.Abstractions;
using AdmissionCommittee.Abstractions.Contracts;

namespace AdmissionCommittee.Data.Memory
{
    /// <summary>
    /// In-memory реализация репозитория абитуриентов
    /// (хранение данных в оперативной памяти)
    /// </summary>
    public class InMemoryApplicantRepository : IApplicantRepository
    {
        private readonly List<ApplicantDto> applicants = new();

        public IEnumerable<ApplicantDto> GetAll()
            => applicants;

        public ApplicantDto? GetById(Guid id)
            => applicants.FirstOrDefault(a => a.Id == id);

        public void Add(ApplicantDto applicant)
        {
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            applicants.Add(applicant);
        }

        public void Update(ApplicantDto applicant)
        {
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            var existing = GetById(applicant.Id);
            if (existing == null)
                return;

            existing.FullName = applicant.FullName;
            existing.Gender = applicant.Gender;
            existing.BirthDate = applicant.BirthDate;
            existing.EduForm = applicant.EduForm;
            existing.MathScore = applicant.MathScore;
            existing.RusScore = applicant.RusScore;
            existing.ITScore = applicant.ITScore;
        }

        public void Delete(Guid id)
        {
            var existing = GetById(id);
            if (existing != null)
                applicants.Remove(existing);
        }
    }
}