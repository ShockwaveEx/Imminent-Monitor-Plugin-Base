using Imminent.IServerVars;
using MyPlugin.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPlugin.Forms
{
    public partial class FormMessage : Form
    {
        private IServerClient IServerClient;

        public FormMessage(IServerClient _IServerClient)
        {
	        InitializeComponent();
	        IServerClient = _IServerClient;
	        this.Text = string.Format("Message - {0}", IServerClient.IServerState.UserName);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Variables.iServerNetworkActions.SendToClient(IServerClient, Main.Variables.Command.Message, TextBox1.Text);
        }
    }
}
