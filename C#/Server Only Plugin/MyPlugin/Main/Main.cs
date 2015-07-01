using System;
using System.Collections.Generic;
using System.Text;
using Imminent;
using Imminent.GUI;
using Imminent.IServerVars;
using MyPlugin.UserControls;

namespace MyPlugin.Main
{
    public class Main : IServerMain //This is 100% needed for all plugins to operate
    {

        public IServerGUI IServerGUI;
        public IServerNetworkActions IServerNetworkActions;

        public Main(IServerNetworkActions _IServerNetworkActions, IServerGUI _IServerGUI)
        {
            //Set global instances to instance passed through constructor, this is 100% needed otherwise your plugin will not operate
            IServerGUI = _IServerGUI;
            IServerNetworkActions = _IServerNetworkActions;
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            //Where you initialize all of your GUI controls
            AddTabControl();
            //AddNormalContextItem()  'Uncomment this if you want just a standalone contextitem
            AddContextItemWithChildren();
        }

        private void AddTabControl()
        {
            TabItem T = new TabItem
            {
                Contents = new UserControlSkeleton(),
                Name = "Your Feature"
            };
            //Initializing a new TabItem, the "Contents" variable will be the contents of your tab control, a simple UserControl
            IServerGUI.AddTabItem(T);
            //Adding the above TabItem to Imminent Monitors main form
        }

        private void AddContextItemWithChildren()
        {
            List<ContextItem> Children = new List<ContextItem>();
            ContextItem ChildItem = new ContextItem
            {
                Clicked = HandleContextItemClicked, //This method gets called when your context item is clicked
                Name = "Your Feature"
            };

            //Creating child item
            Children.Add(ChildItem);
            //Adding child item

            ContextItem C = new ContextItem();
            C.Name = "Client";
            //Your Category, can even be an existing category in Imminent Monitor
            C.Children = Children.ToArray();

            IServerGUI.AddContextItem(C);
            // Adding the context item

        }

        private void AddNormalContextItem()
        {
            ContextItem C = new ContextItem
            {
                Name = "Your Feature",
                Clicked = HandleContextItemClicked //This method gets called when your context item is clicked
            };
            //We can add an image if we like using the .Image property
            IServerGUI.AddContextItem(C);
        }


        //A Clicked handler must always take an array of clients as a parameter
        private void HandleContextItemClicked(IServerClient[] clients)
        {
            if (clients.Length == 0)
                return;
            //If no clients where selected, do nothing
        }


        //Network events

        public void IClientConnectedStateChanged(bool connected, IServerClient client)
        {
               //When a new client connects to Imminent Monitor
        }

        public void IClientPacketReceived(IServerClient client, object[] @params)
        {
              //When a Client with the same plugin loaded sends you a packet
        }

        //General Event

        public void Unload()
        {
             //This event gets raised when the plugin is disabled, please terminate all loops, threads and forms in this method.
        }

    }
}
