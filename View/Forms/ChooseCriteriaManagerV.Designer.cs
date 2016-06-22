namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    partial class ChooseCriteriaManagerV
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
            this.BtnAddCriteria = new System.Windows.Forms.Button();
            this.BtnEditCriteria = new System.Windows.Forms.Button();
            this.BtnRemoveCriteria = new System.Windows.Forms.Button();
            this.LbxCriteria = new System.Windows.Forms.ListBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAddCriteria
            // 
            this.BtnAddCriteria.Location = new System.Drawing.Point(12, 12);
            this.BtnAddCriteria.Name = "BtnAddCriteria";
            this.BtnAddCriteria.Size = new System.Drawing.Size(119, 23);
            this.BtnAddCriteria.TabIndex = 0;
            this.BtnAddCriteria.Text = "Kriterium hinzufügen";
            this.BtnAddCriteria.UseVisualStyleBackColor = true;
            this.BtnAddCriteria.Click += new System.EventHandler(this.BtnAddCriteria_Click);
            // 
            // BtnEditCriteria
            // 
            this.BtnEditCriteria.Location = new System.Drawing.Point(12, 70);
            this.BtnEditCriteria.Name = "BtnEditCriteria";
            this.BtnEditCriteria.Size = new System.Drawing.Size(119, 23);
            this.BtnEditCriteria.TabIndex = 1;
            this.BtnEditCriteria.Text = "Kriterium bearbeiten";
            this.BtnEditCriteria.UseVisualStyleBackColor = true;
            this.BtnEditCriteria.Click += new System.EventHandler(this.BtnEditCriteria_Click);
            // 
            // BtnRemoveCriteria
            // 
            this.BtnRemoveCriteria.Location = new System.Drawing.Point(12, 41);
            this.BtnRemoveCriteria.Name = "BtnRemoveCriteria";
            this.BtnRemoveCriteria.Size = new System.Drawing.Size(119, 23);
            this.BtnRemoveCriteria.TabIndex = 2;
            this.BtnRemoveCriteria.Text = "Kriterium löschen";
            this.BtnRemoveCriteria.UseVisualStyleBackColor = true;
            this.BtnRemoveCriteria.Click += new System.EventHandler(this.BtnRemoveCriteria_Click);
            // 
            // LbxCriteria
            // 
            this.LbxCriteria.FormattingEnabled = true;
            this.LbxCriteria.HorizontalScrollbar = true;
            this.LbxCriteria.Location = new System.Drawing.Point(137, 12);
            this.LbxCriteria.Name = "LbxCriteria";
            this.LbxCriteria.Size = new System.Drawing.Size(243, 160);
            this.LbxCriteria.TabIndex = 3;
            this.LbxCriteria.SelectedIndexChanged += new System.EventHandler(this.LbxCriteria_SelectedIndexChanged);
            this.LbxCriteria.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbxCriteria_MouseDoubleClick);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(224, 178);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Location = new System.Drawing.Point(305, 178);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 23);
            this.BtnCancle.TabIndex = 5;
            this.BtnCancle.Text = "Abbrechen";
            this.BtnCancle.UseVisualStyleBackColor = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // ChooseCriteriaManagerV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 209);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LbxCriteria);
            this.Controls.Add(this.BtnRemoveCriteria);
            this.Controls.Add(this.BtnEditCriteria);
            this.Controls.Add(this.BtnAddCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ChooseCriteriaManagerV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kriterium Auswahl";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseCriteriaManagerV_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAddCriteria;
        private System.Windows.Forms.Button BtnEditCriteria;
        private System.Windows.Forms.Button BtnRemoveCriteria;
        private System.Windows.Forms.ListBox LbxCriteria;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancle;
    }
}