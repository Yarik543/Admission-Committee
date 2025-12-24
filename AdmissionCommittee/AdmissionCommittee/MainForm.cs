using AdmissionCommittee.Abstractions.Services;
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

            var repository = new ApplicantEfRepository();
            service = new ApplicantService(repository);

            InitGrid();
            _ = LoadDataAsync();
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

        private async Task LoadDataAsync()
        {
            var list = await service.GetAllAsync();
            applicants = new BindingList<Applicant>(list.ToList());
            dgvAdmission.DataSource = applicants;
            UpdateStats(list);
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


        private async void Editbtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow?.DataBoundItem is not Applicant selected)
                return;

            using var form = new EditForm(selected);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await service.UpdateAsync(form.ApplicantData);
                await LoadDataAsync();
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
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

            await service.RemoveAsync(selected.Id);
            await LoadDataAsync();
        }

        private void UpdateStats(IReadOnlyList<Applicant> list)
        {
            lblTotal.Text = $"Всего абитуриентов: {service.CountAll(list)}";
            lblPassed.Text =
                $"Прошли (сумма > 150): {service.CountPassed(list, 150)}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private async void Addbtn_Click_1(object sender, EventArgs e)
        {
            using var form = new EditForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                await service.AddAsync(form.ApplicantData);
                await LoadDataAsync();
            }
        }
    }
}
