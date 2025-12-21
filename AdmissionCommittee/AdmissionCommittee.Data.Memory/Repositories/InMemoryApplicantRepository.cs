using AdmissionCommittee.Abstractions;
using AdmissionCommittee.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionCommittee.Data.Memory.Repositories
{
    public class InMemoryApplicantRepository : IApplicantRepository
    {
        private readonly List<Applicant> _items = new();

        public IReadOnlyList<Applicant> GetAll()
        {
            return _items;
        }

        public void Add(Applicant applicant)
        {
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            _items.Add(applicant);
        }

        public void Update(Applicant applicant)
        {
            // ничего не делаем:
            // объект уже изменён по ссылке
        }

        public void Remove(Guid id)
        {
            var applicant = _items.FirstOrDefault(a => a.Id == id);
            if (applicant != null)
            {
                _items.Remove(applicant);
            }
        }

        public int CountWithTotalScoreGreaterThan(int score)
        {
            return _items.Count(a =>
                a.MathScore + a.RusScore + a.ITScore > score);
        }

        public void Delete(Applicant applicant)
        {
            var existing = _items.FirstOrDefault(a => a.Id == applicant.Id);
            if (existing != null)
                _items.Remove(existing);
        }
    }
}