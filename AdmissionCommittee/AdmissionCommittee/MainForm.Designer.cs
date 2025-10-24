namespace AdmissionCommittee
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Addbtn = new Button();
            Editbtn = new Button();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 122);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(843, 321);
            dataGridView1.TabIndex = 0;
            // 
            // Addbtn
            // 
            Addbtn.BackColor = SystemColors.ActiveCaption;
            Addbtn.Location = new Point(12, 464);
            Addbtn.Name = "Addbtn";
            Addbtn.Size = new Size(94, 29);
            Addbtn.TabIndex = 1;
            Addbtn.Text = "Добавить";
            Addbtn.UseVisualStyleBackColor = false;
            // 
            // Editbtn
            // 
            Editbtn.BackColor = Color.FromArgb(192, 192, 0);
            Editbtn.Location = new Point(698, 464);
            Editbtn.Name = "Editbtn";
            Editbtn.Size = new Size(123, 29);
            Editbtn.TabIndex = 2;
            Editbtn.Text = "Редактировать";
            Editbtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 192);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 125);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 29F);
            label1.Location = new Point(175, 40);
            label1.Name = "label1";
            label1.Size = new Size(485, 66);
            label1.TabIndex = 0;
            label1.Text = "Приемная комиссия";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 529);
            Controls.Add(panel1);
            Controls.Add(Editbtn);
            Controls.Add(Addbtn);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Приемная комиссия";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Addbtn;
        private Button Editbtn;
        private Panel panel1;
        private Label label1;
    }
}
