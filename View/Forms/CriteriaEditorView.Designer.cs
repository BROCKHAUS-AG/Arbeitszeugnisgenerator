namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    partial class CriteriaEditorView
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
            this.TxtCriteriaName = new System.Windows.Forms.TextBox();
            this.LbxVariation = new System.Windows.Forms.ListBox();
            this.BtnAddVariation = new System.Windows.Forms.Button();
            this.BtnRemoveVariation = new System.Windows.Forms.Button();
            this.BtnRenameVariation = new System.Windows.Forms.Button();
            this.RtxtPredefinedText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnTake = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.GboxVaration = new System.Windows.Forms.GroupBox();
            this.GboxGrades = new System.Windows.Forms.GroupBox();
            this.GboxVaration.SuspendLayout();
            this.GboxGrades.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtCriteriaName
            // 
            this.TxtCriteriaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TxtCriteriaName.Location = new System.Drawing.Point(12, 12);
            this.TxtCriteriaName.Name = "TxtCriteriaName";
            this.TxtCriteriaName.Size = new System.Drawing.Size(509, 32);
            this.TxtCriteriaName.TabIndex = 0;
            this.TxtCriteriaName.Text = "Belastbarkeit";
            this.TxtCriteriaName.Leave += new System.EventHandler(this.TxtCriteriaName_Leave);
            // 
            // LbxVariation
            // 
            this.LbxVariation.FormattingEnabled = true;
            this.LbxVariation.Location = new System.Drawing.Point(6, 18);
            this.LbxVariation.Name = "LbxVariation";
            this.LbxVariation.Size = new System.Drawing.Size(174, 238);
            this.LbxVariation.TabIndex = 2;
            this.LbxVariation.SelectedIndexChanged += new System.EventHandler(this.LbxVariation_SelectedIndexChanged);
            // 
            // BtnAddVariation
            // 
            this.BtnAddVariation.Location = new System.Drawing.Point(182, 55);
            this.BtnAddVariation.Name = "BtnAddVariation";
            this.BtnAddVariation.Size = new System.Drawing.Size(129, 23);
            this.BtnAddVariation.TabIndex = 7;
            this.BtnAddVariation.Text = "Variante hinzufügen";
            this.BtnAddVariation.UseVisualStyleBackColor = true;
            this.BtnAddVariation.Click += new System.EventHandler(this.BtnAddVariation_Click);
            // 
            // BtnRemoveVariation
            // 
            this.BtnRemoveVariation.Location = new System.Drawing.Point(182, 84);
            this.BtnRemoveVariation.Name = "BtnRemoveVariation";
            this.BtnRemoveVariation.Size = new System.Drawing.Size(129, 23);
            this.BtnRemoveVariation.TabIndex = 8;
            this.BtnRemoveVariation.Text = "Variante löschen";
            this.BtnRemoveVariation.UseVisualStyleBackColor = true;
            this.BtnRemoveVariation.Click += new System.EventHandler(this.BtnRemoveVariation_Click);
            // 
            // BtnRenameVariation
            // 
            this.BtnRenameVariation.Location = new System.Drawing.Point(182, 26);
            this.BtnRenameVariation.Name = "BtnRenameVariation";
            this.BtnRenameVariation.Size = new System.Drawing.Size(129, 23);
            this.BtnRenameVariation.TabIndex = 9;
            this.BtnRenameVariation.Text = "Variante umbennen";
            this.BtnRenameVariation.UseVisualStyleBackColor = true;
            this.BtnRenameVariation.Click += new System.EventHandler(this.BtnRenameVariation_Click);
            // 
            // RtxtPredefinedText
            // 
            this.RtxtPredefinedText.DetectUrls = false;
            this.RtxtPredefinedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtxtPredefinedText.Location = new System.Drawing.Point(12, 353);
            this.RtxtPredefinedText.Name = "RtxtPredefinedText";
            this.RtxtPredefinedText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RtxtPredefinedText.Size = new System.Drawing.Size(509, 104);
            this.RtxtPredefinedText.TabIndex = 10;
            this.RtxtPredefinedText.Text = "";
            this.RtxtPredefinedText.Leave += new System.EventHandler(this.RtxtPredefinedText_Leave);
            //
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vordefinierter Text:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(446, 470);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Abbrechen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnTake
            // 
            this.BtnTake.Location = new System.Drawing.Point(355, 470);
            this.BtnTake.Name = "BtnTake";
            this.BtnTake.Size = new System.Drawing.Size(85, 23);
            this.BtnTake.TabIndex = 13;
            this.BtnTake.Text = "Übernehmen";
            this.BtnTake.UseVisualStyleBackColor = true;
            this.BtnTake.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Sehr Gut";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioGroup_ChecktChange);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(42, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Gut";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioGroup_ChecktChange);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 72);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(84, 17);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Befriedigend";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioGroup_ChecktChange);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 95);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(84, 17);
            this.radioButton4.TabIndex = 17;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Ausreichend";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.RadioGroup_ChecktChange);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 118);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(78, 17);
            this.radioButton5.TabIndex = 18;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Mangelhaft";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.RadioGroup_ChecktChange);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 141);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(87, 17);
            this.radioButton6.TabIndex = 19;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Ungenügend";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.RadioGroup_ChecktChange);
            // 
            // GboxVaration
            // 
            this.GboxVaration.Controls.Add(this.LbxVariation);
            this.GboxVaration.Controls.Add(this.BtnRenameVariation);
            this.GboxVaration.Controls.Add(this.BtnAddVariation);
            this.GboxVaration.Controls.Add(this.BtnRemoveVariation);
            this.GboxVaration.Location = new System.Drawing.Point(193, 63);
            this.GboxVaration.Name = "GboxVaration";
            this.GboxVaration.Size = new System.Drawing.Size(328, 264);
            this.GboxVaration.TabIndex = 20;
            this.GboxVaration.TabStop = false;
            this.GboxVaration.Text = "Varianten";
            // 
            // GboxGrades
            // 
            this.GboxGrades.Controls.Add(this.radioButton1);
            this.GboxGrades.Controls.Add(this.radioButton2);
            this.GboxGrades.Controls.Add(this.radioButton6);
            this.GboxGrades.Controls.Add(this.radioButton3);
            this.GboxGrades.Controls.Add(this.radioButton5);
            this.GboxGrades.Controls.Add(this.radioButton4);
            this.GboxGrades.Location = new System.Drawing.Point(12, 63);
            this.GboxGrades.Name = "GboxGrades";
            this.GboxGrades.Size = new System.Drawing.Size(159, 264);
            this.GboxGrades.TabIndex = 21;
            this.GboxGrades.TabStop = false;
            this.GboxGrades.Text = "Note";
            // 
            // CriteriaEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 505);
            this.Controls.Add(this.GboxGrades);
            this.Controls.Add(this.GboxVaration);
            this.Controls.Add(this.BtnTake);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RtxtPredefinedText);
            this.Controls.Add(this.TxtCriteriaName);
            this.KeyPreview = true;
            this.Name = "CriteriaEditorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kriterium bearbeiten";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CriteriaEditorV_KeyDown);
            this.GboxVaration.ResumeLayout(false);
            this.GboxGrades.ResumeLayout(false);
            this.GboxGrades.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCriteriaName;
        private System.Windows.Forms.ListBox LbxVariation;
        //private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnAddVariation;
        private System.Windows.Forms.Button BtnRemoveVariation;
        private System.Windows.Forms.Button BtnRenameVariation;
        private System.Windows.Forms.RichTextBox RtxtPredefinedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnTake;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.GroupBox GboxVaration;
        private System.Windows.Forms.GroupBox GboxGrades;
    }
}