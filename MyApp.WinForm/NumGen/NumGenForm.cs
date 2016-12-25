using MyApp.WinForm.Core;
using System;
using System.Windows.Forms;

namespace MyApp.WinForm.NumGen
{
    internal partial class NumGenForm : Form, INumGenView
    {
        public NumGenForm()
        {
            InitializeComponent();
        }

        public event EventHandler ChangeButtonClick;

        public void ChangeNumber(int number)
        {
            this.label1.Text = number.ToString();
        }

        public void Show(IView owner)
        {
            this.Show((IWin32Window)owner);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (ChangeButtonClick != null)
            {
                ChangeButtonClick(this, e);
            }
        }
    }
}
