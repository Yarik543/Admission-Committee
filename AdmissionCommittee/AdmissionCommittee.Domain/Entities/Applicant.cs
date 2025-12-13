using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCommittee.Domain.Entities
{
    /// <summary>
    /// Информация об абитуриенте
    /// </summary>
    public class Applicant
    {
        /// <summary>
        /// ФИО
        /// </summary>
        [Required(ErrorMessage = "Поле {0} обязательно.")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [Required(ErrorMessage = "Поле {0} обязательно.")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Поле {0} обязательно.")]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Required(ErrorMessage = "Поле {0} обязательно.")]
        [Display(Name = "Форма обучения")]
        public string EduForm { get; set; }

        /// <summary>
        /// Баллы математика
        /// </summary>
        [Range(1, 100, ErrorMessage = "{0} должен быть от {1} до {2}.")]
        [Display(Name = "Баллы по математике")]
        public int MathScore { get; set; }

        /// <summary>
        /// Баллы русский
        /// </summary>
        [Range(1, 100, ErrorMessage = "{0} должен быть от {1} до {2}.")]
        [Display(Name = "Баллы по русскому")]
        public int RusScore { get; set; }

        /// <summary>
        /// Баллы информатика
        /// </summary>
        [Range(1, 100, ErrorMessage = "{0} должен быть от {1} до {2}.")]
        [Display(Name = "Баллы по информатике")]
        public int ITScore { get; set; }
    }
}
