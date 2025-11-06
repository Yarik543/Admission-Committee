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

            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "ФИО" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Пол" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthDate", HeaderText = "Дата рождения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EduForm", HeaderText = "Форма обучения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MathScore", HeaderText = "Математика" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RusScore", HeaderText = "Русский" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ITScore", HeaderText = "Информатика" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalScore", HeaderText = "Сумма" });

            dgvAdmission.DataSource = applicants;
        }

        private void LoadData()
        {
            if (File.Exists(dataFile))
            {
                var json = File.ReadAllText(dataFile);
                var list = JsonSerializer.Deserialize<BindingList<Applicant>>(json);
                applicants = list ?? new BindingList<Applicant>();
                dgvAdmission.DataSource = applicants;
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

        private void Addbtn_Click(object sender, EventArgs e)
        {
            var form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                applicants.Add(form.ApplicantData);
                SaveData();
                UpdateStats();
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
                SaveData();
                UpdateStats();
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
                SaveData();
                UpdateStats();
            }
        }

        private void UpdateStats()
        {
            lblTotal.Text = $"Всего абитуриентов: {applicants.Count}";
            lblPassed.Text = $"Прошли (сумма >150): {applicants.Count(a => a.TotalScore > 150)}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveData();
            base.OnFormClosing(e);
        }
    }
}
