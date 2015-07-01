using System;
using System.Collections.Generic;
using System.Text;
using Imminent;
using System.Windows.Forms;

namespace MyPluginClient
{
    public class Main : IClientMain
    {
        public IClientNetworkActions IClientNetworkActions;

        public Main(IClientNetworkActions _IClientNetworkActions)
        {
            //Set global instances to instance passed through constructor, this is 100% needed otherwise your plugin will not operate
            IClientNetworkActions = _IClientNetworkActions;
        }

        public enum Command : byte
        {
            Message = 0
        }

        public void ReceivedPacket(object[] @params)
        {
            Command header = (Command)@params[0];
            //Cast header to type of command
            //Parse header and parameters to "ParseCommand"
            ParseCommand(header, @params);
        }

        private void ParseCommand(Command header, object[] @params)
        {
            switch (header)
            {
                case Command.Message:
                    string text = (string)@params[1];
                    //Casting params(1) to typeof string
                    HandleMessagePacket(text);
                    break;
            }
        }

        private void HandleMessagePacket(string text)
        {
            MessageBox.Show(text);
            //Show server inputted message
        }

        public void StateChanged(bool connected)
        {
            switch (connected)
            {
                case false:
                    //Disconnected
                    break;
                case true:
                    //Connected
                    break;
            }
        }

        public void Unload()
        {
            //This event gets raised when the plugin is disabled, please terminate all loops, threads and forms in this method.
        }
    }
}
