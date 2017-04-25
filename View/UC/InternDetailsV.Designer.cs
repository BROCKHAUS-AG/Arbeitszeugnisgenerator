namespace Brockhaus.PraktikumZeugnisGenerator.View.UC
{
    partial class InternDetailsV
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblFirstName = new System.Windows.Forms.Label();
            this.LblLastName = new System.Windows.Forms.Label();
            this.LblDateOfBirth = new System.Windows.Forms.Label();
            this.LblFromDate = new System.Windows.Forms.Label();
            this.LblUntilDate = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.DtpUntilDate = new System.Windows.Forms.DateTimePicker();
            this.DtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.DtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.LblExercises = new System.Windows.Forms.Label();
            this.RtxtExercises = new System.Windows.Forms.RichTextBox();
            this.LblDepartment = new System.Windows.Forms.Label();
            this.TxtDepartment = new System.Windows.Forms.TextBox();
            this.LblSex = new System.Windows.Forms.Label();
            this.RbtnMale = new System.Windows.Forms.RadioButton();
            this.RbtnFemale = new System.Windows.Forms.RadioButton();
            this.GboxPersonalData = new System.Windows.Forms.GroupBox();
            this.GboxInternData = new System.Windows.Forms.GroupBox();
            this.RtxtPracticalExperience = new System.Windows.Forms.RichTextBox();
            this.LblPracticalExperience = new System.Windows.Forms.Label();
            this.ChbxBulletPointsExcercises = new System.Windows.Forms.CheckBox();
            this.ChbxBulletPointsPractExp = new System.Windows.Forms.CheckBox();
            this.GboxPersonalData.SuspendLayout();
            this.GboxInternData.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblFirstName
            // 
            this.LblFirstName.AutoSize = true;
            this.LblFirstName.Location = new System.Drawing.Point(7, 52);
            this.LblFirstName.Name = "LblFirstName";
            this.LblFirstName.Size = new System.Drawing.Size(52, 13);
            this.LblFirstName.TabIndex = 2;
            this.LblFirstName.Text = "Vorname:";
            // 
            // LblLastName
            // 
            this.LblLastName.AutoSize = true;
            this.LblLastName.Location = new System.Drawing.Point(7, 78);
            this.LblLastName.Name = "LblLastName";
            this.LblLastName.Size = new System.Drawing.Size(62, 13);
            this.LblLastName.TabIndex = 3;
            this.LblLastName.Text = "Nachname:";
            // 
            // LblDateOfBirth
            // 
            this.LblDateOfBirth.AutoSize = true;
            this.LblDateOfBirth.Location = new System.Drawing.Point(7, 104);
            this.LblDateOfBirth.Name = "LblDateOfBirth";
            this.LblDateOfBirth.Size = new System.Drawing.Size(62, 13);
            this.LblDateOfBirth.TabIndex = 4;
            this.LblDateOfBirth.Text = "Geburtstag:";
            // 
            // LblFromDate
            // 
            this.LblFromDate.AutoSize = true;
            this.LblFromDate.Location = new System.Drawing.Point(6, 52);
            this.LblFromDate.Name = "LblFromDate";
            this.LblFromDate.Size = new System.Drawing.Size(29, 13);
            this.LblFromDate.TabIndex = 5;
            this.LblFromDate.Text = "Von:";
            // 
            // LblUntilDate
            // 
            this.LblUntilDate.AutoSize = true;
            this.LblUntilDate.Location = new System.Drawing.Point(6, 78);
            this.LblUntilDate.Name = "LblUntilDate";
            this.LblUntilDate.Size = new System.Drawing.Size(24, 13);
            this.LblUntilDate.TabIndex = 6;
            this.LblUntilDate.Text = "Bis:";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(75, 52);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(200, 20);
            this.TxtFirstName.TabIndex = 2;
            this.TxtFirstName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.TxtFirstName.Leave += new System.EventHandler(this.TxtFirstName_Leave);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(75, 78);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(200, 20);
            this.TxtLastName.TabIndex = 3;
            this.TxtLastName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtLastName_Leave);
            // 
            // DtpUntilDate
            // 
            this.DtpUntilDate.Location = new System.Drawing.Point(133, 71);
            this.DtpUntilDate.Name = "DtpUntilDate";
            this.DtpUntilDate.Size = new System.Drawing.Size(200, 20);
            this.DtpUntilDate.TabIndex = 7;
            this.DtpUntilDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.DtpUntilDate.Leave += new System.EventHandler(this.DtpUntilDate_Leave);
            // 
            // DtpDateOfBirth
            // 
            this.DtpDateOfBirth.Location = new System.Drawing.Point(75, 104);
            this.DtpDateOfBirth.Name = "DtpDateOfBirth";
            this.DtpDateOfBirth.Size = new System.Drawing.Size(200, 20);
            this.DtpDateOfBirth.TabIndex = 4;
            this.DtpDateOfBirth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.DtpDateOfBirth.Leave += new System.EventHandler(this.DtpDateOfBirth_Leave);
            // 
            // DtpFromDate
            // 
            this.DtpFromDate.Location = new System.Drawing.Point(133, 45);
            this.DtpFromDate.Name = "DtpFromDate";
            this.DtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.DtpFromDate.TabIndex = 6;
            this.DtpFromDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.DtpFromDate.Leave += new System.EventHandler(this.DtpFromDate_Leave);
            // 
            // LblExercises
            // 
            this.LblExercises.AutoSize = true;
            this.LblExercises.Location = new System.Drawing.Point(6, 100);
            this.LblExercises.Name = "LblExercises";
            this.LblExercises.Size = new System.Drawing.Size(56, 13);
            this.LblExercises.TabIndex = 13;
            this.LblExercises.Text = "Aufgaben:";
            // 
            // LblDepartment
            // 
            this.LblDepartment.AutoSize = true;
            this.LblDepartment.Location = new System.Drawing.Point(6, 25);
            this.LblDepartment.Name = "LblDepartment";
            this.LblDepartment.Size = new System.Drawing.Size(54, 13);
            this.LblDepartment.TabIndex = 19;
            this.LblDepartment.Text = "Abteilung:";
            // 
            // TxtDepartment
            // 
            this.TxtDepartment.Location = new System.Drawing.Point(133, 18);
            this.TxtDepartment.Name = "TxtDepartment";
            this.TxtDepartment.Size = new System.Drawing.Size(200, 20);
            this.TxtDepartment.TabIndex = 5;
            this.TxtDepartment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.TxtDepartment.Leave += new System.EventHandler(this.TxtDepartment_Leave);
            // 
            // LblSex
            // 
            this.LblSex.AutoSize = true;
            this.LblSex.Location = new System.Drawing.Point(6, 25);
            this.LblSex.Name = "LblSex";
            this.LblSex.Size = new System.Drawing.Size(64, 13);
            this.LblSex.TabIndex = 21;
            this.LblSex.Text = "Geschlecht:";
            // 
            // RbtnMale
            // 
            this.RbtnMale.AutoSize = true;
            this.RbtnMale.Checked = true;
            this.RbtnMale.Location = new System.Drawing.Point(81, 24);
            this.RbtnMale.Name = "RbtnMale";
            this.RbtnMale.Size = new System.Drawing.Size(67, 17);
            this.RbtnMale.TabIndex = 0;
            this.RbtnMale.TabStop = true;
            this.RbtnMale.Text = "männlich";
            this.RbtnMale.UseVisualStyleBackColor = true;
            this.RbtnMale.CheckedChanged += new System.EventHandler(this.RBtnsSex_CheckedChanged);
            this.RbtnMale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            // 
            // RbtnFemale
            // 
            this.RbtnFemale.AutoSize = true;
            this.RbtnFemale.Location = new System.Drawing.Point(154, 24);
            this.RbtnFemale.Name = "RbtnFemale";
            this.RbtnFemale.Size = new System.Drawing.Size(63, 17);
            this.RbtnFemale.TabIndex = 1;
            this.RbtnFemale.Text = "weiblich";
            this.RbtnFemale.UseVisualStyleBackColor = true;
            this.RbtnFemale.CheckedChanged += new System.EventHandler(this.RBtnsSex_CheckedChanged);
            // 
            // GboxPersonalData
            // 
            this.GboxPersonalData.Controls.Add(this.LblSex);
            this.GboxPersonalData.Controls.Add(this.LblFirstName);
            this.GboxPersonalData.Controls.Add(this.RbtnFemale);
            this.GboxPersonalData.Controls.Add(this.LblLastName);
            this.GboxPersonalData.Controls.Add(this.RbtnMale);
            this.GboxPersonalData.Controls.Add(this.LblDateOfBirth);
            this.GboxPersonalData.Controls.Add(this.TxtFirstName);
            this.GboxPersonalData.Controls.Add(this.TxtLastName);
            this.GboxPersonalData.Controls.Add(this.DtpDateOfBirth);
            this.GboxPersonalData.Location = new System.Drawing.Point(19, 12);
            this.GboxPersonalData.Name = "GboxPersonalData";
            this.GboxPersonalData.Size = new System.Drawing.Size(280, 142);
            this.GboxPersonalData.TabIndex = 24;
            this.GboxPersonalData.TabStop = false;
            this.GboxPersonalData.Text = "Persönliche Daten";
            // 
            // GboxInternData
            // 
            this.GboxInternData.Controls.Add(this.RtxtExercises);
            this.GboxInternData.Controls.Add(this.LblExercises);
            this.GboxInternData.Controls.Add(this.RtxtPracticalExperience);
            this.GboxInternData.Controls.Add(this.LblPracticalExperience);
            this.GboxInternData.Controls.Add(this.LblDepartment);
            this.GboxInternData.Controls.Add(this.LblFromDate);
            this.GboxInternData.Controls.Add(this.TxtDepartment);
            this.GboxInternData.Controls.Add(this.LblUntilDate);
            this.GboxInternData.Controls.Add(this.DtpUntilDate);
            this.GboxInternData.Controls.Add(this.DtpFromDate);
            this.GboxInternData.Controls.Add(this.ChbxBulletPointsPractExp);
            this.GboxInternData.Controls.Add(this.ChbxBulletPointsExcercises);
            this.GboxInternData.Location = new System.Drawing.Point(316, 12);
            this.GboxInternData.Name = "GboxInternData";
            this.GboxInternData.Size = new System.Drawing.Size(339, 282);
            this.GboxInternData.TabIndex = 25;
            this.GboxInternData.TabStop = false;
            this.GboxInternData.Text = "Daten zur Arbeit";
            // 
            // RtxtExercises
            // 
            this.RtxtExercises.Location = new System.Drawing.Point(133, 97);
            this.RtxtExercises.Name = "RtxtExercises";
            this.RtxtExercises.Size = new System.Drawing.Size(200, 81);
            this.RtxtExercises.TabIndex = 21;
            this.RtxtExercises.Text = "";
            this.RtxtExercises.KeyDown += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.RtxtExercises.Leave += new System.EventHandler(this.RtxtExercises_Leave);

            // 
            // RtxtPracticalExperience
            // 
            this.RtxtPracticalExperience.Location = new System.Drawing.Point(133, 184);
            this.RtxtPracticalExperience.Name = "RtxtPracticalExperience";
            this.RtxtPracticalExperience.Size = new System.Drawing.Size(200, 85);
            this.RtxtPracticalExperience.TabIndex = 23;
            this.RtxtPracticalExperience.Text = "";
            this.RtxtPracticalExperience.KeyDown += new System.Windows.Forms.KeyEventHandler(this.All_KeyDown);
            this.RtxtPracticalExperience.Leave += new System.EventHandler(this.RtxtPracticalExperience_Leave);
            // 
            // LblPracticalExperience
            // 
            this.LblPracticalExperience.AutoSize = true;
            this.LblPracticalExperience.Location = new System.Drawing.Point(6, 187);
            this.LblPracticalExperience.Name = "LblPracticalExperience";
            this.LblPracticalExperience.Size = new System.Drawing.Size(109, 13);
            this.LblPracticalExperience.Text = "Praktische Erfahrung:";
            // 
            // ChbxBulletPointsExcercises
            // 
            this.ChbxBulletPointsExcercises.AutoSize = true;
            this.ChbxBulletPointsExcercises.Location = new System.Drawing.Point(9, 117);
            this.ChbxBulletPointsExcercises.Name = "ChbxBulletPointsExcercises";
            this.ChbxBulletPointsExcercises.Size = new System.Drawing.Size(121, 17);
            this.ChbxBulletPointsExcercises.TabIndex = 20;
            this.ChbxBulletPointsExcercises.Text = "Aufzählungszeichen";
            this.ChbxBulletPointsExcercises.UseVisualStyleBackColor = true;
            this.ChbxBulletPointsExcercises.CheckedChanged += new System.EventHandler(this.ChbxBulletPointsExcercises_CheckedChanged);
            // 
            // ChbxBulletPointsPractExp
            // 
            this.ChbxBulletPointsPractExp.AutoSize = true;
            this.ChbxBulletPointsPractExp.Location = new System.Drawing.Point(9, 203);
            this.ChbxBulletPointsPractExp.Name = "ChbxBulletPointsPractExp";
            this.ChbxBulletPointsPractExp.Size = new System.Drawing.Size(121, 17);
            this.ChbxBulletPointsPractExp.TabIndex = 22;
            this.ChbxBulletPointsPractExp.Text = "Aufzählungszeichen";
            this.ChbxBulletPointsPractExp.UseVisualStyleBackColor = true;
            this.ChbxBulletPointsPractExp.CheckedChanged += new System.EventHandler(this.ChbxBulletPointsPractExp_CheckedChanged);
            // 
            // InternDetailsV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GboxInternData);
            this.Controls.Add(this.GboxPersonalData);
            this.Name = "InternDetailsV";
            this.Size = new System.Drawing.Size(662, 297);
            this.GboxPersonalData.ResumeLayout(false);
            this.GboxPersonalData.PerformLayout();
            this.GboxInternData.ResumeLayout(false);
            this.GboxInternData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblFirstName;
        private System.Windows.Forms.Label LblLastName;
        private System.Windows.Forms.Label LblDateOfBirth;
        private System.Windows.Forms.Label LblFromDate;
        private System.Windows.Forms.Label LblUntilDate;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.DateTimePicker DtpUntilDate;
        private System.Windows.Forms.DateTimePicker DtpDateOfBirth;
        private System.Windows.Forms.DateTimePicker DtpFromDate;
        private System.Windows.Forms.Label LblExercises;
        private System.Windows.Forms.RichTextBox RtxtExercises;
        private System.Windows.Forms.Label LblDepartment;
        private System.Windows.Forms.TextBox TxtDepartment;
        private System.Windows.Forms.Label LblSex;
        private System.Windows.Forms.RadioButton RbtnMale;
        private System.Windows.Forms.RadioButton RbtnFemale;
        private System.Windows.Forms.GroupBox GboxPersonalData;
        private System.Windows.Forms.GroupBox GboxInternData;
        private System.Windows.Forms.Label LblPracticalExperience;
        private System.Windows.Forms.RichTextBox RtxtPracticalExperience;
        private System.Windows.Forms.CheckBox ChbxBulletPointsExcercises;
        private System.Windows.Forms.CheckBox ChbxBulletPointsPractExp;
    }
}
