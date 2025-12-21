using System;
using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.Domain.Entities
{
    /// <summary>
    /// Абитуриент приёмной комиссии
    /// </summary>
    public class Applicant
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле «{0}» обязательно.")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле «{0}» обязательно.")]
        [Display(Name = "Пол")]
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Дата рождения")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Поле «{0}» обязательно.")]
        [Display(Name = "Форма обучения")]
        public string EduForm { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "{0} должен быть от {1} до {2}.")]
        [Display(Name = "Математика")]
        public int MathScore { get; set; }

        [Range(1, 100, ErrorMessage = "{0} должен быть от {1} до {2}.")]
        [Display(Name = "Русский язык")]
        public int RusScore { get; set; }

        [Range(1, 100, ErrorMessage = "{0} должен быть от {1} до {2}.")]
        [Display(Name = "Информатика")]
        public int ITScore { get; set; }
    }
}