namespace Brockhaus.PraktikumZeugnisGenerator.Dialogs
{
    partial class ConfirmationDialog
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
            this.BtnNo = new System.Windows.Forms.Button();
            this.BtnYes = new System.Windows.Forms.Button();
            this.LblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnNo
            // 
            this.BtnNo.Location = new System.Drawing.Point(138, 56);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(75, 23);
            this.BtnNo.TabIndex = 1;
            this.BtnNo.Text = "Nein";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // BtnYes
            // 
            this.BtnYes.Location = new System.Drawing.Point(57, 56);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(75, 23);
            this.BtnYes.TabIndex = 2;
            this.BtnYes.Text = "Ja";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // LblText
            // 
            this.LblText.AutoSize = true;
            this.LblText.Location = new System.Drawing.Point(12, 9);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(35, 13);
            this.LblText.TabIndex = 3;
            this.LblText.Text = "label1";
            // 
            // ConfirmationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 91);
            this.Controls.Add(this.LblText);
            this.Controls.Add(this.BtnYes);
            this.Controls.Add(this.BtnNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "YesNoDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmationDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNo;
        private System.Windows.Forms.Button BtnYes;
        private System.Windows.Forms.Label LblText;
    }
}