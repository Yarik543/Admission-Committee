using AdmissionCommittee.Models;
using System;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class EditForm : Form
    {
        public Applicant ApplicantData { get; private set; }

        public EditForm()
        {
            InitializeComponent();
            ApplicantData = new Applicant();
        }

        public EditForm(Applicant existing) : this()
        {
            // Заполняем поля данными
            txtFullName.Text = existing.FullName;
            cmbGender.SelectedItem = existing.Gender;
            dateBDate.Value = existing.BirthDate;
            cmbEduForm.SelectedItem = existing.EduForm;
            numMathScore.Value = existing.MathScore;
            numRussianScore.Value = existing.RusScore;
            numInformaticsScore.Value = existing.ITScore;

            ApplicantData = existing;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbGender.Text))
            {
                MessageBox.Show("Выберите пол.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbEduForm.Text))
            {
                MessageBox.Show("Выберите форму обучения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numMathScore.Value <= 0 || numRussianScore.Value <= 0 || numInformaticsScore.Value <= 0)
            {
                MessageBox.Show("Баллы должны быть больше 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            ApplicantData.FullName = txtFullName.Text.Trim();
            ApplicantData.Gender = cmbGender.Text;
            ApplicantData.BirthDate = dateBDate.Value;
            ApplicantData.EduForm = cmbEduForm.Text;
            ApplicantData.MathScore = (int)numMathScore.Value;
            ApplicantData.RusScore = (int)numRussianScore.Value;
            ApplicantData.ITScore = (int)numInformaticsScore.Value;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
