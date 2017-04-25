namespace Brockhaus.Arbeitszeugnisgenerator.View.Forms
{
    partial class ChooseCriteriaEditorView
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
            this.BtnRemoveCriteria = new System.Windows.Forms.Button();
            this.BtnEditCriteria = new System.Windows.Forms.Button();
            this.BtnAddCriteria = new System.Windows.Forms.Button();
            this.BtnCancle = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.LbxCriteria = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            // 
            // BtnRemoveCriteria
            // 
            this.BtnRemoveCriteria.Location = new System.Drawing.Point(12, 41);
            this.BtnRemoveCriteria.Name = "BtnRemoveCriteria";
            this.BtnRemoveCriteria.Size = new System.Drawing.Size(119, 23);
            this.BtnRemoveCriteria.TabIndex = 5;
            this.BtnRemoveCriteria.Text = "Kriterium löschen";
            this.BtnRemoveCriteria.UseVisualStyleBackColor = true;
            this.BtnRemoveCriteria.Click += new System.EventHandler(this.BtnRemoveCriteria_Click);
            // 
            // BtnEditCriteria
            // 
            this.BtnEditCriteria.Location = new System.Drawing.Point(12, 70);
            this.BtnEditCriteria.Name = "BtnEditCriteria";
            this.BtnEditCriteria.Size = new System.Drawing.Size(119, 23);
            this.BtnEditCriteria.TabIndex = 4;
            this.BtnEditCriteria.Text = "Kriterium bearbeiten";
            this.BtnEditCriteria.UseVisualStyleBackColor = true;
            this.BtnEditCriteria.Click += new System.EventHandler(this.BtnEditCriteria_Click);
            // 
            // BtnAddCriteria
            // 
            this.BtnAddCriteria.Location = new System.Drawing.Point(12, 12);
            this.BtnAddCriteria.Name = "BtnAddCriteria";
            this.BtnAddCriteria.Size = new System.Drawing.Size(119, 23);
            this.BtnAddCriteria.TabIndex = 3;
            this.BtnAddCriteria.Text = "Kriterium hinzufügen";
            this.BtnAddCriteria.UseVisualStyleBackColor = true;
            this.BtnAddCriteria.Click += new System.EventHandler(this.BtnAddCriteria_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Location = new System.Drawing.Point(302, 178);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 23);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "Abbrechen";
            this.BtnCancle.UseVisualStyleBackColor = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(221, 178);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 7;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LbxCriteria
            // 
            this.LbxCriteria.FormattingEnabled = true;
            this.LbxCriteria.Location = new System.Drawing.Point(150, 12);
            this.LbxCriteria.Name = "LbxCriteria";
            this.LbxCriteria.Size = new System.Drawing.Size(227, 160);
            this.LbxCriteria.TabIndex = 10;
            this.LbxCriteria.SelectedIndexChanged += new System.EventHandler(this.LbxCriteria_SelectedIndexChanged);
            // 
            // ChooseCriteriaEditorV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 208);
            this.Controls.Add(this.LbxCriteria);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnRemoveCriteria);
            this.Controls.Add(this.BtnEditCriteria);
            this.Controls.Add(this.BtnAddCriteria);
            this.KeyPreview = true;
            this.Name = "ChooseCriteriaEditorV";
            this.Text = "Kriterien bearbeiten";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRemoveCriteria;
        private System.Windows.Forms.Button BtnEditCriteria;
        private System.Windows.Forms.Button BtnAddCriteria;
        private System.Windows.Forms.Button BtnCancle;
        public System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.ListBox LbxCriteria;
    }
}