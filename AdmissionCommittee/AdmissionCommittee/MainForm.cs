using AdmissionCommittee.Models;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class MainForm : Form
    {
        private BindingList<Applicant> applicants = new BindingList<Applicant>();
        public MainForm()
        {
            InitializeComponent();
            InitGrid();
            UpdateStats();
        }

        private void InitGrid()
        {
            dgvAdmission.AutoGenerateColumns = false;
            dgvAdmission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmission.ReadOnly = true;

            dgvAdmission.Columns.Clear();

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "ФИО" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Пол" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthDate", HeaderText = "Дата рождения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EduForm", HeaderText = "Форма обучения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MathScore", HeaderText = "Математика" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RusScore", HeaderText = "Русский" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ITScore", HeaderText = "Информатика" });

            dgvAdmission.DataSource = applicants;
        }


        // Считаем сумму прямо при отображении строки
        private void dgvAdmission_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAdmission.Columns[e.ColumnIndex].Name == "colTotalScore")
            {
                var applicant = dgvAdmission.Rows[e.RowIndex].DataBoundItem as Applicant;
                if (applicant != null)
                {
                    e.Value = applicant.MathScore + applicant.RusScore + applicant.ITScore;
                }
            }
        }


        private void AfterDataChenged()
        {
            UpdateStats();
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow == null) return;

            var selected = (Applicant)dgvAdmission.CurrentRow.DataBoundItem;
            var form = new EditForm(selected);

            if (form.ShowDialog() == DialogResult.OK)
            {
                dgvAdmission.Refresh();
                UpdateStats();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow == null) return;

            var selected = (Applicant)dgvAdmission.CurrentRow.DataBoundItem;
            applicants.Remove(selected);
            UpdateStats();
        }

        private void UpdateStats()
        {
            lblTotal.Text = $"Всего абитуриентов: {applicants.Count}";
            lblPassed.Text = $"Прошли (сумма >150): {applicants.Count(a => a.MathScore + a.RusScore + a.ITScore > 150)}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void Addbtn_Click_1(object sender, EventArgs e)
        {
            var form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                applicants.Add(form.ApplicantData);
                UpdateStats();
            }
        }
    }
}
