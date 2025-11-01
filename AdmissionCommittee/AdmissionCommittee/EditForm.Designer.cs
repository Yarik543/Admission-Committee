namespace AdmissionCommittee
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbEduForm = new ComboBox();
            label6 = new Label();
            this.numRussianScore = new NumericUpDown();
            label7 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            dateBDate = new DateTimePicker();
            cmbGender = new ComboBox();
            txtFullName = new TextBox();
            this.numMathScore = new NumericUpDown();
            numInformaticsScore = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.numRussianScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numMathScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInformaticsScore).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 40);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 0;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 95);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 2;
            label2.Text = "Пол";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 149);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 4;
            label3.Text = "Дата рождения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 208);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 5;
            label4.Text = "Форма обучения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 259);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 6;
            label5.Text = "Баллы математика";
            // 
            // cmbEduForm
            // 
            cmbEduForm.FormattingEnabled = true;
            cmbEduForm.Items.AddRange(new object[] { "Очное", "Очно-заочное", "Заочное" });
            cmbEduForm.Location = new Point(256, 210);
            cmbEduForm.Name = "cmbEduForm";
            cmbEduForm.Size = new Size(212, 28);
            cmbEduForm.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 357);
            label6.Name = "label6";
            label6.Size = new Size(152, 20);
            label6.TabIndex = 10;
            label6.Text = "Баллы информатика";
            // 
            // numRussianScore
            // 
            this.numRussianScore.Location = new Point(256, 311);
            this.numRussianScore.Name = "numRussianScore";
            this.numRussianScore.Size = new Size(212, 27);
            this.numRussianScore.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 306);
            label7.Name = "label7";
            label7.Size = new Size(112, 20);
            label7.TabIndex = 12;
            label7.Text = "Баллы русский";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 255, 192);
            btnSave.Location = new Point(23, 423);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 14;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 192, 192);
            btnCancel.Location = new Point(296, 423);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // dateBDate
            // 
            dateBDate.Location = new Point(256, 149);
            dateBDate.Name = "dateBDate";
            dateBDate.Size = new Size(212, 27);
            dateBDate.TabIndex = 16;
            // 
            // cmdGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Мужской", "Женский" });
            cmbGender.Location = new Point(256, 92);
            cmbGender.Name = "cmdGender";
            cmbGender.Size = new Size(212, 28);
            cmbGender.TabIndex = 17;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(178, 37);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(290, 27);
            txtFullName.TabIndex = 18;
            // 
            // numMathScore
            // 
            this.numMathScore.Location = new Point(256, 259);
            this.numMathScore.Name = "numMathScore";
            this.numMathScore.Size = new Size(212, 27);
            this.numMathScore.TabIndex = 19;
            // 
            // numInformaticsScore
            // 
            numInformaticsScore.Location = new Point(256, 357);
            numInformaticsScore.Name = "numInformaticsScore";
            numInformaticsScore.Size = new Size(212, 27);
            numInformaticsScore.TabIndex = 20;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 501);
            Controls.Add(numInformaticsScore);
            Controls.Add(this.numMathScore);
            Controls.Add(txtFullName);
            Controls.Add(cmbGender);
            Controls.Add(dateBDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(this.numRussianScore);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbEduForm);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditForm";
            Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)this.numRussianScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numMathScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInformaticsScore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

        private TextBox txtFullName;
        private ComboBox cmbGender;
        private DateTimePicker dateBDate;
        private ComboBox cmbEduForm;

        private NumericUpDown numMathScore;
        private NumericUpDown numRussianScore;
        private NumericUpDown numInformaticsScore;

        private Button btnSave;
        private Button btnCancel;
    }
}