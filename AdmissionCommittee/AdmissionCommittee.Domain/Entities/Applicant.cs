using System;
using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.Domain.Entities
{
    /// <summary>
    /// Абитуриент приёмной комиссии
    /// </summary>
    public class Applicant
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string EduForm { get; set; }

        [Range(0, 100)]
        public int MathScore { get; set; }

        [Range(0, 100)]
        public int RusScore { get; set; }

        [Range(0, 100)]
        public int ITScore { get; set; }
    }
}