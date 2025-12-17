using AdmissionCommittee.Data;
using AdmissionCommittee.Models;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class MainForm : Form
    {
        private readonly InMemoryApplicantRepository repository = new();

        private BindingList<Applicant> applicants;
        public MainForm()
        {
            InitializeComponent();
            InitGrid();
            LoadData();
            UpdateStats();
        }


        private void InitGrid()
        {
            dgvAdmission.AutoGenerateColumns = false;
            dgvAdmission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmission.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmission.MultiSelect = false;
            dgvAdmission.ReadOnly = true;

            dgvAdmission.Columns.Clear();

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName", HeaderText = "ФИО"
            });

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender", HeaderText = "Пол"
            });

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EduForm", HeaderText = "Форма обучения"
            });

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MathScore", HeaderText = "Математика"
            });

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RusScore", HeaderText = "Русский"
            });

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ITScore", HeaderText = "Информатика"
            });

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalScore", HeaderText = "Сумма баллов"
            });

            dgvAdmission.CellFormatting += dgvAdmission_CellFormatting;
        }

        private void LoadData()
        {
            applicants = repository.GetAll();
            dgvAdmission.DataSource = applicants;
        }

        // Считаем сумму прямо при отображении строки
        private void dgvAdmission_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAdmission.Columns[e.ColumnIndex].Name == "TotalScore")
            {
                if (dgvAdmission.Rows[e.RowIndex].DataBoundItem is Applicant a)
                {
                    e.Value = a.MathScore + a.RusScore + a.ITScore;
                }
            }
        }


        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow?.DataBoundItem is not Applicant selected)
                return;

            using var form = new EditForm(selected);

            if (form.ShowDialog() == DialogResult.OK)
            {
                dgvAdmission.Refresh();
                UpdateStats();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow?.DataBoundItem is not Applicant selected)
                return;

            var confirm = MessageBox.Show(
                "Удалить выбранного абитуриента?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                repository.Delete(selected);
                UpdateStats();
            }
        }

        private void UpdateStats()
        {
            lblTotal.Text = $"Всего абитуриентов: {applicants.Count}";

            int passed = applicants.Count(a =>
                a.MathScore + a.RusScore + a.ITScore > 150);

            lblPassed.Text = $"Прошли (сумма > 150): {passed}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void Addbtn_Click_1(object sender, EventArgs e)
        {
            using var form = new EditForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                repository.Add(form.ApplicantData);
                UpdateStats();
            }
        }
    }
}
