using Brockhaus.PraktikumZeugnisGenerator.View.UC;
using System.Collections.Generic;

namespace Brockhaus.PraktikumZeugnisGenerator.View.Forms
{
    partial class MainWindowView
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
            this.components = new System.ComponentModel.Container();
            this.LblCriteriaCaption = new System.Windows.Forms.Label();
            this.BtnAddCriteria = new System.Windows.Forms.Button();
            this.TlpCriteriaButtonContainer = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.BtnChooseTemplate = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.FlpMainContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.FlpCriteriaContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kriterienBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datengrundlageErstellenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vorlageAuswählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTipMailmerge = new System.Windows.Forms.ToolTip(this.components);
            this.IdInternDetails = new Brockhaus.PraktikumZeugnisGenerator.View.UC.InternDetailsV();
            this.TlpCriteriaButtonContainer.SuspendLayout();
            this.FlpMainContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // LblCriteriaCaption
            // 
            this.LblCriteriaCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LblCriteriaCaption.AutoSize = true;
            this.LblCriteriaCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LblCriteriaCaption.Location = new System.Drawing.Point(30, 327);
            this.LblCriteriaCaption.Name = "LblCriteriaCaption";
            this.LblCriteriaCaption.Size = new System.Drawing.Size(204, 26);
            this.LblCriteriaCaption.TabIndex = 7;
            this.LblCriteriaCaption.Text = "Bewertungskriterien";
            this.LblCriteriaCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnAddCriteria
            // 
            this.BtnAddCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TlpCriteriaButtonContainer.SetColumnSpan(this.BtnAddCriteria, 10);
            this.BtnAddCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.BtnAddCriteria.Location = new System.Drawing.Point(3, 3);
            this.BtnAddCriteria.Name = "BtnAddCriteria";
            this.BtnAddCriteria.Size = new System.Drawing.Size(634, 42);
            this.BtnAddCriteria.TabIndex = 17;
            this.BtnAddCriteria.Text = "+";
            this.BtnAddCriteria.UseVisualStyleBackColor = true;
            this.BtnAddCriteria.Click += new System.EventHandler(this.BtnAddCriteria_Click);
            // 
            // TlpCriteriaButtonContainer
            // 
            this.TlpCriteriaButtonContainer.AutoSize = true;
            this.TlpCriteriaButtonContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpCriteriaButtonContainer.ColumnCount = 6;
            this.TlpCriteriaButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpCriteriaButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TlpCriteriaButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.TlpCriteriaButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.TlpCriteriaButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.TlpCriteriaButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.TlpCriteriaButtonContainer.Controls.Add(this.BtnAddCriteria, 0, 0);
            this.TlpCriteriaButtonContainer.Controls.Add(this.BtnGenerate, 5, 1);
            this.TlpCriteriaButtonContainer.Controls.Add(this.BtnChooseTemplate, 4, 1);
            this.TlpCriteriaButtonContainer.Controls.Add(this.BtnSave, 3, 1);
            this.TlpCriteriaButtonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TlpCriteriaButtonContainer.Location = new System.Drawing.Point(3, 9);
            this.TlpCriteriaButtonContainer.MaximumSize = new System.Drawing.Size(630, 0);
            this.TlpCriteriaButtonContainer.MinimumSize = new System.Drawing.Size(640, 0);
            this.TlpCriteriaButtonContainer.Name = "TlpCriteriaButtonContainer";
            this.TlpCriteriaButtonContainer.RowCount = 2;
            this.TlpCriteriaButtonContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCriteriaButtonContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCriteriaButtonContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpCriteriaButtonContainer.Size = new System.Drawing.Size(640, 77);
            this.TlpCriteriaButtonContainer.TabIndex = 3;
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenerate.BackColor = System.Drawing.Color.Snow;
            this.BtnGenerate.Location = new System.Drawing.Point(529, 51);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(108, 23);
            this.BtnGenerate.TabIndex = 20;
            this.BtnGenerate.Text = "Zeugnis generieren";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // BtnChooseTemplate
            // 
            this.BtnChooseTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChooseTemplate.BackColor = System.Drawing.Color.Snow;
            this.BtnChooseTemplate.Location = new System.Drawing.Point(417, 51);
            this.BtnChooseTemplate.Name = "BtnChooseTemplate";
            this.BtnChooseTemplate.Size = new System.Drawing.Size(106, 23);
            this.BtnChooseTemplate.TabIndex = 19;
            this.BtnChooseTemplate.Text = "Vorlage auswählen";
            this.BtnChooseTemplate.UseVisualStyleBackColor = true;
            this.BtnChooseTemplate.Click += new System.EventHandler(this.BtnChooseTemplate_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.Snow;
            this.BtnSave.Location = new System.Drawing.Point(306, 51);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(105, 23);
            this.BtnSave.TabIndex = 18;
            this.BtnSave.Text = "Speichern";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FlpMainContainer
            // 
            this.FlpMainContainer.AutoSize = true;
            this.FlpMainContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlpMainContainer.Controls.Add(this.FlpCriteriaContainer);
            this.FlpMainContainer.Controls.Add(this.TlpCriteriaButtonContainer);
            this.FlpMainContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpMainContainer.Location = new System.Drawing.Point(29, 356);
            this.FlpMainContainer.Name = "FlpMainContainer";
            this.FlpMainContainer.Size = new System.Drawing.Size(646, 89);
            this.FlpMainContainer.TabIndex = 5;
            // 
            // FlpCriteriaContainer
            // 
            this.FlpCriteriaContainer.AutoSize = true;
            this.FlpCriteriaContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlpCriteriaContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlpCriteriaContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpCriteriaContainer.Location = new System.Drawing.Point(3, 3);
            this.FlpCriteriaContainer.MaximumSize = new System.Drawing.Size(666, 0);
            this.FlpCriteriaContainer.Name = "FlpCriteriaContainer";
            this.FlpCriteriaContainer.Size = new System.Drawing.Size(640, 0);
            this.FlpCriteriaContainer.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.kriterienBearbeitenToolStripMenuItem,
            this.datengrundlageErstellenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.speichernUnterToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.speichernUnterToolStripMenuItem.Text = "Speichern unter";
            this.speichernUnterToolStripMenuItem.Click += new System.EventHandler(this.speichernUnterToolStripMenuItem_Click);
            // 
            // kriterienBearbeitenToolStripMenuItem
            // 
            this.kriterienBearbeitenToolStripMenuItem.Name = "kriterienBearbeitenToolStripMenuItem";
            this.kriterienBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.kriterienBearbeitenToolStripMenuItem.Text = "Kriterien bearbeiten";
            this.kriterienBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.kriterienBearbeitenToolStripMenuItem_Click);
            // 
            // datengrundlageErstellenToolStripMenuItem
            // 
            this.datengrundlageErstellenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vorlageAuswählenToolStripMenuItem});
            this.datengrundlageErstellenToolStripMenuItem.Name = "datengrundlageErstellenToolStripMenuItem";
            this.datengrundlageErstellenToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.datengrundlageErstellenToolStripMenuItem.Text = "Vorlage";
            // 
            // vorlageAuswählenToolStripMenuItem
            // 
            this.vorlageAuswählenToolStripMenuItem.Name = "vorlageAuswählenToolStripMenuItem";
            this.vorlageAuswählenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.vorlageAuswählenToolStripMenuItem.Text = "Vorlage Auswählen";
            this.vorlageAuswählenToolStripMenuItem.Click += new System.EventHandler(this.BtnChooseTemplate_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // informationenToolStripMenuItem
            // 
            this.informationenToolStripMenuItem.Name = "informationenToolStripMenuItem";
            this.informationenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.informationenToolStripMenuItem.Text = "Informationen";
            this.informationenToolStripMenuItem.Click += new System.EventHandler(this.informationenToolStripMenuItem_Click);
            // 
            // IdInternDetails
            // 
            this.IdInternDetails.Location = new System.Drawing.Point(15, 27);
            this.IdInternDetails.Name = "IdInternDetails";
            this.IdInternDetails.Size = new System.Drawing.Size(687, 297);
            this.IdInternDetails.TabIndex = 6;
            this.IdInternDetails.Load += new System.EventHandler(this.IdInternDetails_Load);
            // 
            // MainWindowView
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(719, 461);
            this.Controls.Add(this.IdInternDetails);
            this.Controls.Add(this.FlpMainContainer);
            this.Controls.Add(this.LblCriteriaCaption);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(735, 9999999);
            this.MinimumSize = new System.Drawing.Size(735, 500);
            this.Name = "MainWindowView";
            this.Text = "Arbeitszeugnis-Generator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindowV_KeyDown);
            this.TlpCriteriaButtonContainer.ResumeLayout(false);
            this.FlpMainContainer.ResumeLayout(false);
            this.FlpMainContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblCriteriaCaption;
        private System.Windows.Forms.Button BtnAddCriteria;
        private System.Windows.Forms.TableLayoutPanel TlpCriteriaButtonContainer;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.FlowLayoutPanel FlpMainContainer;
        private System.Windows.Forms.FlowLayoutPanel FlpCriteriaContainer;
        private InternDetailsV IdInternDetails;
        private System.Windows.Forms.Button BtnChooseTemplate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernUnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kriterienBearbeitenToolStripMenuItem;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ToolStripMenuItem datengrundlageErstellenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vorlageAuswählenToolStripMenuItem;
        private System.Windows.Forms.ToolTip ToolTipMailmerge;
    }
}