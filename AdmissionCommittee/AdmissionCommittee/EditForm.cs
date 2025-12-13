using AdmissionCommittee.Extensions;
using AdmissionCommittee.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class EditForm : Form
    {
        public Applicant ApplicantData { get; private set; }

        private Applicant workingCopy;

        public EditForm(Applicant? existing = null)
        {
            InitializeComponent();
            cmbEduForm.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;

            // создаём копию, чтобы не трогать оригинал, пока пользователь не нажал OK
            workingCopy = existing != null
                ? new Applicant
                {
                    FullName = existing.FullName,
                    Gender = existing.Gender,
                    BirthDate = existing.BirthDate,
                    EduForm = existing.EduForm,
                    MathScore = existing.MathScore,
                    RusScore = existing.RusScore,
                    ITScore = existing.ITScore
                }
                : new Applicant();

            //дата по умолчанию
            if (workingCopy.BirthDate < dateBDate.MinDate)
                workingCopy.BirthDate = DateTime.Now.AddYears(-18);

            //заполняем combobox
            if (existing == null)
            {
                workingCopy.Gender = cmbGender.Items[0].ToString();
                workingCopy.EduForm = cmbEduForm.Items[0].ToString();
            }

            ApplicantData = workingCopy;

            InitBindings();
        }

        private void InitBindings()
        {
            txtFullName.BindControl(ApplicantData, c => c.Text, m => m.FullName, errorProvider1);
            cmbGender.BindControl(ApplicantData, c => c.Text, m => m.Gender, errorProvider1);
            dateBDate.BindControl(ApplicantData, c => c.Value, m => m.BirthDate, errorProvider1);
            cmbEduForm.BindControl(ApplicantData, c => c.Text, m => m.EduForm, errorProvider1);
            numMathScore.BindControl(ApplicantData, c => c.Value, m => m.MathScore, errorProvider1);
            numRussianScore.BindControl(ApplicantData, c => c.Value, m => m.RusScore, errorProvider1);
            numInformaticsScore.BindControl(ApplicantData, c => c.Value, m => m.ITScore, errorProvider1);
        }

        //Метод валидации модели через атрибуты

        private bool ValidateModel()
        {
            var context = new ValidationContext(ApplicantData);
            var results = new System.Collections.Generic.List<ValidationResult>();

            bool valid = Validator.TryValidateObject(ApplicantData, context, results, true);

            if (!valid)
            {
                string msg = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return valid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateModel())
                return;

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
