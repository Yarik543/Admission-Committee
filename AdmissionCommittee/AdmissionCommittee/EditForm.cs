using AdmissionCommittee.Extensions;
using AdmissionCommittee.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class EditForm : Form
    {
        public Applicant ApplicantData { get; private set; }

        private Applicant _workingCopy;
        private ErrorProvider _errorProvider = new ErrorProvider();

        public EditForm(Applicant? existing = null)
        {
            InitializeComponent();
            cmbEduForm.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;

            // создаём копию, чтобы не трогать оригинал, пока пользователь не нажал OK
            _workingCopy = existing != null
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
            if (_workingCopy.BirthDate < dateBDate.MinDate)
                _workingCopy.BirthDate = DateTime.Now.AddYears(-18);

            //заполняем combobox
            if (existing == null)
            {
                _workingCopy.Gender = cmbGender.Items[0].ToString();
                _workingCopy.EduForm = cmbEduForm.Items[0].ToString();
            }

            ApplicantData = _workingCopy;

            InitBindings();
        }

        private void InitBindings()
        {
            txtFullName.BindControl(ApplicantData, c => c.Text, m => m.FullName, _errorProvider);
            cmbGender.BindControl(ApplicantData, c => c.Text, m => m.Gender, _errorProvider);
            dateBDate.BindControl(ApplicantData, c => c.Value, m => m.BirthDate, _errorProvider);
            cmbEduForm.BindControl(ApplicantData, c => c.Text, m => m.EduForm, _errorProvider);
            numMathScore.BindControl(ApplicantData, c => c.Value, m => m.MathScore, _errorProvider);
            numRussianScore.BindControl(ApplicantData, c => c.Value, m => m.RusScore, _errorProvider);
            numInformaticsScore.BindControl(ApplicantData, c => c.Value, m => m.ITScore, _errorProvider);
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
