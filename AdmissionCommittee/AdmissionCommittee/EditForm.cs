using AdmissionCommittee.Domain.Entities;
using System;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class EditForm : Form
    {
        public Applicant ApplicantData { get; private set; }


        public EditForm(Applicant existing = null)
        {
            InitializeComponent();

            ApplicantData = existing ?? new Applicant();

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


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFullName.Text)
                || cmbGender.SelectedItem == null
                || cmbEduForm.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            ApplicantData.FullName = txtFullName.Text;
            ApplicantData.Gender = cmbGender.SelectedItem.ToString();
            ApplicantData.BirthDate = dateBDate.Value;
            ApplicantData.EduForm = cmbEduForm.SelectedItem.ToString();
            ApplicantData.MathScore = (int)numMathScore.Value;
            ApplicantData.RusScore = (int)numRussianScore.Value;
            ApplicantData.ITScore = (int)numInformaticsScore.Value;

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
