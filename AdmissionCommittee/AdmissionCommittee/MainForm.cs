using AdmissionCommittee.Models;
using System.ComponentModel;

namespace AdmissionCommittee
{
    public partial class MainForm : Form
    {

        private DataGridView dgv;
        private Button btnAdd;
        private BindingList<Applicant> applicants;
        public MainForm()
        {
            InitializeComponent();

            applicants = new BindingList<Applicant>();
            dgv.DataSource = applicants;
        }


    }
}
