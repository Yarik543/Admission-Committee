using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCommittee.Models
{
    public class Applicant
    {
        public string FullName { get; set; }     // ФИО
        public string Gender { get; set; }       // Пол (Мужской / Женский)
        public DateTime BirthDate { get; set; }  // Дата рождения
        public string EduForm { get; set; }      // Форма обучения
        public int MathScore { get; set; }       // Баллы математика
        public int RusScore { get; set; }        // Баллы русский
        public int ITScore { get; set; }         // Баллы информатика

        public int TotalScore => MathScore + RusScore + ITScore;  // Сумма (readonly)
    }
}
