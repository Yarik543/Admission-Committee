using AdmissionCommittee.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace AdmissionCommittee
{
    public partial class MainForm : Form
    {

        private BindingList<Applicant> applicants = new BindingList<Applicant>();

        private readonly string dataFile = "applicants.json";
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

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "ФИО" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Пол" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthDate", HeaderText = "Дата рождения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EduForm", HeaderText = "Форма обучения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MathScore", HeaderText = "Математика" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RusScore", HeaderText = "Русский" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ITScore", HeaderText = "Информатика" });

            // Добавляем вычисляемый столбец (без DataPropertyName)
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Сумма",
                Name = "colTotalScore"
            });

            dgvAdmission.CellFormatting += dgvAdmission_CellFormatting;
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

        private void LoadData()
        {
            if (File.Exists(dataFile))
            {
                var json = File.ReadAllText(dataFile);
                var list = JsonSerializer.Deserialize<BindingList<Applicant>>(json);
                applicants = list ?? new BindingList<Applicant>();
            }
            else
            {
                // если файла нет — создаём пустой список
                applicants = new BindingList<Applicant>();
            }

            dgvAdmission.DataSource = applicants;
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(applicants, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFile, json);
        }

        private void AfterDataChenged()
        {
            SaveData();
            UpdateStats();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            var form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                applicants.Add(form.ApplicantData);
                AfterDataChenged();
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow == null) return;
            var selected = (Applicant)dgvAdmission.CurrentRow.DataBoundItem;

            var form = new EditForm(selected);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var index = applicants.IndexOf(selected);
                applicants[index] = form.ApplicantData;
                dgvAdmission.Refresh();
                AfterDataChenged();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dgvAdmission.CurrentRow == null) return;
            var selected = (Applicant)dgvAdmission.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Удалить {selected.FullName}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                applicants.Remove(selected);
                AfterDataChenged();
            }
        }

        private void UpdateStats()
        {
            lblTotal.Text = $"Всего абитуриентов: {applicants.Count}";
            lblPassed.Text = $"Прошли (сумма >150): {applicants.Count(a => a.MathScore + a.RusScore + a.ITScore > 150)}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveData();
            base.OnFormClosing(e);
        }
    }
}
