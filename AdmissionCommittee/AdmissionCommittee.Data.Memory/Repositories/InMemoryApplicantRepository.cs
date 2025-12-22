using System;
using System.Collections.Generic;
using System.Linq;
using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Domain.Entities;

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
            // объект уже обновлён по ссылке
        }

        public void Remove(Guid id)
        {
            var applicant = _items.FirstOrDefault(a => a.Id == id);
            if (applicant != null)
                _items.Remove(applicant);
        }
    }
}