namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    partial class ChooseCriteriaManagerView
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
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancle = new System.Windows.Forms.Button();
            this.LbxCriteria = new System.Windows.Forms.CheckedListBox();
            this.lbxBackground = new System.Windows.Forms.ListBox();
            this.ChbxAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(111, 174);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Location = new System.Drawing.Point(192, 174);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 23);
            this.BtnCancle.TabIndex = 5;
            this.BtnCancle.Text = "Abbrechen";
            this.BtnCancle.UseVisualStyleBackColor = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // LbxCriteria
            // 
            this.LbxCriteria.CheckOnClick = true;
            this.LbxCriteria.FormattingEnabled = true;
            this.LbxCriteria.Location = new System.Drawing.Point(12, 33);
            this.LbxCriteria.Name = "LbxCriteria";
            this.LbxCriteria.Size = new System.Drawing.Size(256, 139);
            this.LbxCriteria.TabIndex = 6;
            this.LbxCriteria.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbxCriteria_MouseUp);
            // 
            // lbxBackground
            // 
            this.lbxBackground.FormattingEnabled = true;
            this.lbxBackground.Items.AddRange(new object[] {
            " "});
            this.lbxBackground.Location = new System.Drawing.Point(12, 4);
            this.lbxBackground.Name = "lbxBackground";
            this.lbxBackground.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxBackground.Size = new System.Drawing.Size(256, 30);
            this.lbxBackground.TabIndex = 8;
            // 
            // ChbxAll
            // 
            this.ChbxAll.AutoSize = true;
            this.ChbxAll.BackColor = System.Drawing.Color.White;
            this.ChbxAll.Location = new System.Drawing.Point(15, 11);
            this.ChbxAll.Name = "ChbxAll";
            this.ChbxAll.Size = new System.Drawing.Size(43, 17);
            this.ChbxAll.TabIndex = 9;
            this.ChbxAll.Text = "Alle";
            this.ChbxAll.UseVisualStyleBackColor = false;
            this.ChbxAll.CheckedChanged += new System.EventHandler(this.ChbxAll_CheckedChanged);
            // 
            // ChooseCriteriaManagerV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 209);
            this.Controls.Add(this.ChbxAll);
            this.Controls.Add(this.lbxBackground);
            this.Controls.Add(this.LbxCriteria);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ChooseCriteriaManagerV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kriteriumswahl";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseCriteriaManagerV_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancle;
        private System.Windows.Forms.CheckedListBox LbxCriteria;
        private System.Windows.Forms.ListBox lbxBackground;
        private System.Windows.Forms.CheckBox ChbxAll;
    }
}