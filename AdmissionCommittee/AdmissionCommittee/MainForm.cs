using AdmissionCommittee.Models;
using System;
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

            dgvAdmission.AutoGenerateColumns = false;

            // Настройка колонок грида
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "ФИО" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Пол" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthDate", HeaderText = "Дата рождения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EduForm", HeaderText = "Форма обучения" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MathScore", HeaderText = "Математика" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RusScore", HeaderText = "Русский" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ITScore", HeaderText = "Информатика" });
            dgvAdmission.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalScore", HeaderText = "Сумма" });

            dgvAdmission.DataSource = applicants;

            // Добавим тестовую запись
            applicants.Add(new Applicant
            {
                FullName = "Иванов Иван Иванович",
                Gender = "Мужской",
                BirthDate = new DateTime(2005, 3, 14),
                EduForm = "Очное",
                MathScore = 60,
                RusScore = 45,
                ITScore = 65
            });

            UpdateStats();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            var form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                applicants.Add(form.ApplicantData);
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
                // Обновляем объект в BindingList
                var index = applicants.IndexOf(selected);
                applicants[index] = form.ApplicantData;
                dgvAdmission.Refresh();
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
                UpdateStats();
            }
        }

        private void UpdateStats()
        {
            lblTotal.Text = $"Всего абитуриентов: {applicants.Count}";
            lblPassed.Text = $"Прошли (сумма >150): {applicants.Count(a => a.TotalScore > 150)}";
        }
    }
}
