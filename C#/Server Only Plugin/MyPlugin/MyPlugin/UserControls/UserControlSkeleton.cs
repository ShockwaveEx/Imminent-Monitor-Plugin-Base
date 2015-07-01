using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MyPlugin.UserControls
{
    public partial class UserControlSkeleton : UserControl
    {
        public UserControlSkeleton()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TextBox1.Text);
        }
    }
}
