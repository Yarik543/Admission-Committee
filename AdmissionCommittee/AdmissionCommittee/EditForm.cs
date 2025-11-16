using AdmissionCommittee.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class EditForm : Form
    {
        public Applicant ApplicantData { get; private set; }

        public EditForm(Applicant? existing = null)
        {
            InitializeComponent();
            cmbEduForm.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;

            // если абитуриент передан — редактируем, иначе создаём нового
            ApplicantData = existing ?? new Applicant();

            // если редактируем — заполняем поля формы
            if (existing != null)
            {
                txtFullName.Text = existing.FullName;
                cmbGender.SelectedItem = existing.Gender;
                dateBDate.Value = existing.BirthDate;
                cmbEduForm.SelectedItem = existing.EduForm;
                numMathScore.Value = existing.MathScore;
                numRussianScore.Value = existing.RusScore;
                numInformaticsScore.Value = existing.ITScore;
            }
        }

        //Метод валидации модели через атрибуты
        
        private bool ValidateApplicant(Applicant applicant)
        {
            var context = new ValidationContext(applicant);
            var results = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(applicant, context, results, true);

            if (!valid)
            {
                string msg = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return valid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ApplicantData.FullName = txtFullName.Text;
            ApplicantData.Gender = cmbGender.SelectedItem.ToString();
            ApplicantData.BirthDate = dateBDate.Value;
            ApplicantData.EduForm = cmbEduForm.SelectedItem.ToString();
            ApplicantData.MathScore = (int)numMathScore.Value;
            ApplicantData.RusScore = (int)numRussianScore.Value;
            ApplicantData.ITScore = (int)numInformaticsScore.Value;

            //Проверяем модель через Validator
            if (!ValidateApplicant(ApplicantData))
            {
                return; // ошибки уже 
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
