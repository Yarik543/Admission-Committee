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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Присваиваем данные в объект
            ApplicantData.FullName = txtFullName.Text;
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
