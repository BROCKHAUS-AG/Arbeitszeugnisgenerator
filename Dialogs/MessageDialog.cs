using System;
using System.Windows.Forms;

namespace Brockhaus.PraktikumZeugnisGenerator.Dialogs
{
    public partial class MessageDialog : Form
    {
        public MessageDialog(string title, string message)
        {
            InitializeComponent();
            Text = title;
            lblMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MessageDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape || e.KeyData == Keys.Enter)
            {
                
                btnOK_Click(sender, e);
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Escape)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
