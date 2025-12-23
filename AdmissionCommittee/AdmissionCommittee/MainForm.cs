using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Data.Memory.Repositories;
using AdmissionCommittee.Domain.Entities;
using AdmissionCommittee.Services;
using System.ComponentModel;
using AdmissionCommittee.Data.EF;
using System.Linq;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class MainForm : Form
    {
        private BindingList<Applicant> applicants = new();
        private readonly IApplicantService service; // Сервис для работы с абитуриентами

        public MainForm()
        {
            InitializeComponent();

            // Создаём репозиторий из NuGet-пакета
            var repository = new ApplicantEfRepository(); // класс из BD
            service = new ApplicantService(repository);

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
                DataPropertyName = nameof(Applicant.BirthDate),
                HeaderText = "Дата рождения",
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
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
            var list = service.GetAll();

            applicants = new BindingList<Applicant>(list.ToList());
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
                LoadData();
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

            if (confirm != DialogResult.Yes)
                return;

            service.Remove(selected.Id);
            LoadData();
            UpdateStats();
        }

        private void UpdateStats()
        {
            lblTotal.Text = $"Всего абитуриентов: {service.CountAll()}";
            lblPassed.Text = $"Прошли (сумма > 150): {service.CountPassed(150)}";
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
                service.Add(form.ApplicantData);
                LoadData();
                UpdateStats();
            }
        }
    }
}
