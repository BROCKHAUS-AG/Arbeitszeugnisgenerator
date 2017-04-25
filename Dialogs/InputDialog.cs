using System;
using System.Windows.Forms;

namespace Brockhaus.PraktikumZeugnisGenerator.Dialogs
{
    public partial class InputDialog : Form
    {
        public string InputText;

        public InputDialog(string title, string message)
        {
            InitializeComponent();
            Text = title;
            LblText.Text = message;
            this.ActiveControl = TxtName;
        }


        #region Windows Forms Control EventHandler

        private void BtnOk_Click(object sender, EventArgs e)
        {
            InputText = TxtName.Text;
            DialogResult = DialogResult.OK;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk_Click(sender, null);
            }
        }
       /* private void BtnTake_Click(object sender, EventArgs e)
        {
            if (viewState == ViewState.IsRefreshing) return;
            presenter.UpdateBackup();
            CriteriasWrapper.Instance.SaveCriteriaWrapper();
        }
        */
        private void InputDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                BtnCancel_Click(sender, e);
            }
        }
        #endregion

    }
}
