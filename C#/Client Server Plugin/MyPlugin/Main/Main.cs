using Imminent;
using Imminent.GUI;
using Imminent.IServerVars;
using MyPlugin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlugin.Main
{
    public class Main : IServerMain //This is 100% needed for all plugins to operate
    {
        public FormMessage FormMessageHandle;

        public Main(IServerNetworkActions _IServerNetworkActions, IServerGUI _IServerGUI)
        {
            //Set global instances to instance passed through constructor, this is 100% needed otherwise your plugin will not operate
            Variables.iServerGUI = _IServerGUI;
            Variables.iServerNetworkActions = _IServerNetworkActions;
            InitializeGUI();
            //Calling our GUI method See the Region "GUI"
        }

        public void IClientConnectedStateChanged(bool connected, IServerClient client)
        {
            //When a new client connects to Imminent Monitor
        }

        public void IClientPacketReceived(IServerClient client, object[] @params)
        {
            //When a Client with the same plugin loaded sends you a packet
        }

        public void Unload()
        {
           FormMessageHandle.Close();
            //This event gets raised when the plugin is disabled, please terminate all loops, threads and forms in this method.
        }

        private void InitializeGUI()
        {
            //Where you initalize all of your GUI controls
            //AddNormalContextItem()  'Uncomment this if you want just a standalone contextitem
            AddContextItemWithChildren();
        }

        private void AddNormalContextItem()
        {
            ContextItem C = new ContextItem
            {
                Name = "Your Feature",
                Clicked = HandleContextItemClicked
            };
            //We can add an image if we like using the .Image property
            Variables.iServerGUI.AddContextItem(C);
        }

        private void AddContextItemWithChildren()
        {
            List<ContextItem> Children = new List<ContextItem>();
            ContextItem ChildItem = new ContextItem
            {
                Clicked = HandleContextItemClicked,
                Name = "Your Feature"
            };
            //Creating child item 'We can add an image if we like using the .Image property
            Children.Add(ChildItem);
            //Adding child item

            ContextItem C = new ContextItem();
            C.Name = "Client";
            //Your Category, can even be an existing category in Imminent Monitor
            C.Children = Children.ToArray();

            Variables.iServerGUI.AddContextItem(C);
            // Adding the context item

        }

        //A Clicked handler must always take an array of clients as a parameter
        private void HandleContextItemClicked(IServerClient[] clients)
        {
            if (clients.Length == 0)
                return;
            //If no clients where selected, do nothing

            FormMessage F = new FormMessage(clients[0]);
            F.Show();

            FormMessageHandle = F;
            //We keep an instance of this because we will need to close it in the unload event
        }


    }
}
