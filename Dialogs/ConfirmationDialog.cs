using System;
using System.Windows.Forms;

namespace Brockhaus.PraktikumZeugnisGenerator.Dialogs
{
    public partial class ConfirmationDialog : Form
    {
        public ConfirmationDialog(string title, string text)
        {
            InitializeComponent();
            LblText.Text = text;
            Text = title;
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();

        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();

        }

        private void ConfirmationDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                BtnNo_Click(sender, e);
            }
        }
    }
}
