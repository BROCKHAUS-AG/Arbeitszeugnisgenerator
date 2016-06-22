namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    partial class CriteriaEditorV
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
            this.LbxGrade = new System.Windows.Forms.ListBox();
            this.LbxVariation = new System.Windows.Forms.ListBox();
            this.LblGrade = new System.Windows.Forms.Label();
            this.LblVariation = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnAddVariation = new System.Windows.Forms.Button();
            this.BtnRemoveVariation = new System.Windows.Forms.Button();
            this.BtnRenameVariation = new System.Windows.Forms.Button();
            this.RtxtPredefinedText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnTake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtCriteriaName
            // 
            this.TxtCriteriaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TxtCriteriaName.Location = new System.Drawing.Point(12, 12);
            this.TxtCriteriaName.Name = "TxtCriteriaName";
            this.TxtCriteriaName.Size = new System.Drawing.Size(215, 32);
            this.TxtCriteriaName.TabIndex = 0;
            this.TxtCriteriaName.Text = "Belastbarkeit";
            this.TxtCriteriaName.Leave += new System.EventHandler(this.TxtCriteriaName_Leave);
            // 
            // LbxGrade
            // 
            this.LbxGrade.FormattingEnabled = true;
            this.LbxGrade.Location = new System.Drawing.Point(12, 79);
            this.LbxGrade.Name = "LbxGrade";
            this.LbxGrade.Size = new System.Drawing.Size(174, 238);
            this.LbxGrade.TabIndex = 1;
            this.LbxGrade.SelectedIndexChanged += new System.EventHandler(this.LbxGrade_SelectedIndexChanged);
            // 
            // LbxVariation
            // 
            this.LbxVariation.FormattingEnabled = true;
            this.LbxVariation.Location = new System.Drawing.Point(212, 79);
            this.LbxVariation.Name = "LbxVariation";
            this.LbxVariation.Size = new System.Drawing.Size(174, 238);
            this.LbxVariation.TabIndex = 2;
            this.LbxVariation.SelectedIndexChanged += new System.EventHandler(this.LbxVariation_SelectedIndexChanged);
            // 
            // LblGrade
            // 
            this.LblGrade.AutoSize = true;
            this.LblGrade.Location = new System.Drawing.Point(12, 63);
            this.LblGrade.Name = "LblGrade";
            this.LblGrade.Size = new System.Drawing.Size(33, 13);
            this.LblGrade.TabIndex = 3;
            this.LblGrade.Text = "Note:";
            // 
            // LblVariation
            // 
            this.LblVariation.AutoSize = true;
            this.LblVariation.Location = new System.Drawing.Point(207, 63);
            this.LblVariation.Name = "LblVariation";
            this.LblVariation.Size = new System.Drawing.Size(49, 13);
            this.LblVariation.TabIndex = 4;
            this.LblVariation.Text = "Variante:";
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(274, 469);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 6;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnAddVariation
            // 
            this.BtnAddVariation.Location = new System.Drawing.Point(392, 108);
            this.BtnAddVariation.Name = "BtnAddVariation";
            this.BtnAddVariation.Size = new System.Drawing.Size(129, 23);
            this.BtnAddVariation.TabIndex = 7;
            this.BtnAddVariation.Text = "Variante hinzufügen";
            this.BtnAddVariation.UseVisualStyleBackColor = true;
            this.BtnAddVariation.Click += new System.EventHandler(this.BtnAddVariation_Click);
            // 
            // BtnRemoveVariation
            // 
            this.BtnRemoveVariation.Location = new System.Drawing.Point(392, 137);
            this.BtnRemoveVariation.Name = "BtnRemoveVariation";
            this.BtnRemoveVariation.Size = new System.Drawing.Size(129, 23);
            this.BtnRemoveVariation.TabIndex = 8;
            this.BtnRemoveVariation.Text = "Variante löschen";
            this.BtnRemoveVariation.UseVisualStyleBackColor = true;
            this.BtnRemoveVariation.Click += new System.EventHandler(this.BtnRemoveVariation_Click);
            // 
            // BtnRenameVariation
            // 
            this.BtnRenameVariation.Location = new System.Drawing.Point(392, 79);
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
            this.BtnCancel.Location = new System.Drawing.Point(355, 470);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Abbrechen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnTake
            // 
            this.BtnTake.Location = new System.Drawing.Point(436, 470);
            this.BtnTake.Name = "BtnTake";
            this.BtnTake.Size = new System.Drawing.Size(85, 23);
            this.BtnTake.TabIndex = 13;
            this.BtnTake.Text = "Übernehmen";
            this.BtnTake.UseVisualStyleBackColor = true;
            this.BtnTake.Click += new System.EventHandler(this.BtnTake_Click);
            // 
            // CriteriaEditorV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 505);
            this.Controls.Add(this.BtnTake);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RtxtPredefinedText);
            this.Controls.Add(this.BtnRenameVariation);
            this.Controls.Add(this.BtnRemoveVariation);
            this.Controls.Add(this.BtnAddVariation);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblVariation);
            this.Controls.Add(this.LblGrade);
            this.Controls.Add(this.LbxVariation);
            this.Controls.Add(this.LbxGrade);
            this.Controls.Add(this.TxtCriteriaName);
            this.KeyPreview = true;
            this.Name = "CriteriaEditorV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kriterium bearbeiten";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CriteriaEditorV_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCriteriaName;
        private System.Windows.Forms.ListBox LbxGrade;
        private System.Windows.Forms.ListBox LbxVariation;
        private System.Windows.Forms.Label LblGrade;
        private System.Windows.Forms.Label LblVariation;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnAddVariation;
        private System.Windows.Forms.Button BtnRemoveVariation;
        private System.Windows.Forms.Button BtnRenameVariation;
        private System.Windows.Forms.RichTextBox RtxtPredefinedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnTake;
    }
}