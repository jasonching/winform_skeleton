using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp.WinForm.Launcher
{
    internal partial class LauncherForm : Form, ILauncherView
    {
        public event EventHandler NumGenButtonClick;

        public LauncherForm()
        {
            InitializeComponent();
        }

        private void numGenButton_Click(object sender, EventArgs e)
        {
            if (NumGenButtonClick != null)
            {
                NumGenButtonClick(this, e);
            }
        }
    }
}
