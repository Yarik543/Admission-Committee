using AdmissionCommittee.Models;
using System.ComponentModel;

namespace AdmissionCommittee
{
    public partial class MainForm : Form
    {

        private BindingList<Applicant> applicants;
        public MainForm()
        {
            InitializeComponent();

            applicants = new BindingList<Applicant>();
            dgvAdmission.DataSource = applicants;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Пока просто добавляем тестовую запись
            applicants.Add(new Applicant
            {
                FullName = "Иванов Иван Иванович",
                Gender = "Мужской",
                BirthDate = new DateTime(2002, 5, 20),
                EduForm = "Очное",
                MathScore = 60,
                RusScore = 55,
                ITScore = 70
            });
        }
    }
}
