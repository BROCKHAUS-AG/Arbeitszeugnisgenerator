namespace Brockhaus.PraktikumZeugnisGenerator.View.UC
{
    partial class CriteriaTextSelectionView
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
            this.LblCurEvaluationCriteria = new System.Windows.Forms.Label();
            this.CbxGrade = new System.Windows.Forms.ComboBox();
            this.CbxVariation = new System.Windows.Forms.ComboBox();
            this.LblGradeCaption = new System.Windows.Forms.Label();
            this.LblVariationCaption = new System.Windows.Forms.Label();
            this.LblPredefinedText = new System.Windows.Forms.Label();
            this.BtnExtend = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblCurEvaluationCriteria
            // 
            this.LblCurEvaluationCriteria.AutoSize = true;
            this.LblCurEvaluationCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LblCurEvaluationCriteria.Location = new System.Drawing.Point(22, 10);
            this.LblCurEvaluationCriteria.Name = "LblCurEvaluationCriteria";
            this.LblCurEvaluationCriteria.Size = new System.Drawing.Size(0, 24);
            this.LblCurEvaluationCriteria.TabIndex = 0;
            // 
            // CbxGrade
            // 
            this.CbxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxGrade.BackColor = System.Drawing.Color.Snow;
            this.CbxGrade.FormattingEnabled = true;
            this.CbxGrade.Location = new System.Drawing.Point(79, 59);
            this.CbxGrade.Name = "CbxGrade";
            this.CbxGrade.Size = new System.Drawing.Size(121, 21);
            this.CbxGrade.TabIndex = 4;
            this.CbxGrade.SelectionChangeCommitted += new System.EventHandler(this.CbxGrade_SelectedIndexChanged);
            this.CbxGrade.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CbxGrade_MouseWheel);
            // 
            // CbxVariation
            // 
            this.CbxVariation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxVariation.FormattingEnabled = true;
            this.CbxVariation.Location = new System.Drawing.Point(209, 59);
            this.CbxVariation.Name = "CbxVariation";
            this.CbxVariation.Size = new System.Drawing.Size(121, 21);
            this.CbxVariation.TabIndex = 5;
            this.CbxVariation.SelectedIndexChanged += new System.EventHandler(this.CbxVariation_SelectedIndexChanged);
            this.CbxVariation.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CbxVariation_MouseWheel);

            // 
            // LblGradeCaption
            // 
            this.LblGradeCaption.AutoSize = true;
            this.LblGradeCaption.Location = new System.Drawing.Point(76, 43);
            this.LblGradeCaption.Name = "LblGradeCaption";
            this.LblGradeCaption.Size = new System.Drawing.Size(33, 13);
            this.LblGradeCaption.Text = "Note:";
            // 
            // LblVariationCaption
            // 
            this.LblVariationCaption.AutoSize = true;
            this.BtnExtend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblVariationCaption.Location = new System.Drawing.Point(206, 43);
            this.LblVariationCaption.Name = "LblVariationCaption";
            this.LblVariationCaption.Size = new System.Drawing.Size(49, 13);
            this.LblVariationCaption.Text = "Variante:";
            // 
            // LblPredefinedText
            // 
            this.LblPredefinedText.AutoSize = true;
            this.LblPredefinedText.BackColor = System.Drawing.Color.Snow;
            this.LblPredefinedText.Location = new System.Drawing.Point(336, 10);
            this.LblPredefinedText.MaximumSize = new System.Drawing.Size(250, 70);
            this.LblPredefinedText.MinimumSize = new System.Drawing.Size(250, 70);
            this.LblPredefinedText.Name = "LblPredefinedText";
            this.LblPredefinedText.Padding = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.LblPredefinedText.Size = new System.Drawing.Size(250, 70);
            this.LblPredefinedText.Text = "\r\n";
            // 
            // BtnExtend
            // 
            this.BtnExtend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnExtend.Enabled = false;
            this.BtnExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExtend.Location = new System.Drawing.Point(336, 80);
            this.BtnExtend.Name = "BtnExtend";
            this.BtnExtend.Size = new System.Drawing.Size(250, 17);
            this.BtnExtend.TabIndex = 6;
            this.BtnExtend.Text = "\\/";
            this.BtnExtend.Click += new System.EventHandler(this.BtnExtend_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(592, 35);
            this.BtnEdit.BackColor = System.Drawing.Color.Snow;
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(66, 23);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "Bearbeiten";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(592, 10);
            this.BtnRemove.BackColor = System.Drawing.Color.Snow;
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(66, 23);
            this.BtnRemove.TabIndex = 7;
            this.BtnRemove.Text = "Löschen";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);


            // 
            // BtnUp
            // 
            this.BtnUp.Location = new System.Drawing.Point(13, 30);
            this.BtnUp.BackColor = System.Drawing.Color.Snow;
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(29, 23);
            this.BtnUp.TabIndex = 2;
            this.BtnUp.Text = "/\\";
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Location = new System.Drawing.Point(13, 59);
            this.BtnDown.BackColor = System.Drawing.Color.Snow;
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(29, 23);
            this.BtnDown.TabIndex = 3;
            this.BtnDown.Text = "\\/";
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // CriteriaTextSelectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnUp);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnExtend);
            this.Controls.Add(this.LblPredefinedText);
            this.Controls.Add(this.LblVariationCaption);
            this.Controls.Add(this.LblGradeCaption);
            this.Controls.Add(this.CbxVariation);
            this.Controls.Add(this.CbxGrade);
            this.Controls.Add(this.LblCurEvaluationCriteria);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(660, 0);
            this.MinimumSize = new System.Drawing.Size(660, 100);
            this.Name = "CriteriaTextSelectionView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(660, 108);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label LblCurEvaluationCriteria;
        private System.Windows.Forms.ComboBox CbxGrade;
        private System.Windows.Forms.ComboBox CbxVariation;
        private System.Windows.Forms.Label LblGradeCaption;
        private System.Windows.Forms.Label LblVariationCaption;
        private System.Windows.Forms.Label LblPredefinedText;
        private System.Windows.Forms.Button BtnExtend;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnUp;
        private System.Windows.Forms.Button BtnDown;
    }
}
