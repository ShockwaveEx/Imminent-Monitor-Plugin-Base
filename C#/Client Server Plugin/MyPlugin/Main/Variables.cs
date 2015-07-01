using Imminent;
using Imminent.GUI;
using MyPlugin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlugin.Main
{
    public class Variables
    {
        public static IServerGUI iServerGUI;

        public static IServerNetworkActions iServerNetworkActions;


        public enum Command : byte
        {
            Message = 0
        }

    }
}
