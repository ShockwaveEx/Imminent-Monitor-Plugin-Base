Imports Imminent
Imports Imminent.GUI
Imports Imminent.IServerVars
Public Class Main
    Implements IServerMain 'This is 100% needed for all plugins to operate

#Region " Variables "
    Public IServerGUI As IServerGUI
    Public IServerNetworkActions As IServerNetworkActions
#End Region

#Region " Constructor "
    Sub New(_IServerNetworkActions As IServerNetworkActions, _IServerGUI As IServerGUI)
        'Set global instances to instance passed through constructor, this is 100% needed otherwise your plugin will not operate
        IServerGUI = _IServerGUI
        IServerNetworkActions = _IServerNetworkActions
        InitializeGUI() 'Calling our GUI method See the Region "GUI"
    End Sub

#End Region

#Region " Events "
    Public Sub IClientConnectedStateChanged(connected As Boolean, client As IServerClient) Implements Imminent.IServerMain.IClientConnectedStateChanged
        'When a new client connects to Imminent Monitor
    End Sub

    Public Sub IClientPacketReceived(client As IServerClient, params() As Object) Implements Imminent.IServerMain.IClientPacketReceived
        'When a Client with the same plugin loaded sends you a packet
    End Sub

    Public Sub Unload() Implements Imminent.IServerMain.Unload
        'This event gets raised when the plugin is disabled, please terminate all loops, threads and forms in this method.
    End Sub
#End Region

#Region " GUI "
    Private Sub InitializeGUI()
        'Where you initalize all of your GUI controls
        AddTabControl()
        'AddNormalContextItem()  'Uncomment this if you want just a standalone contextitem
        AddContextItemWithChildren()
    End Sub

    Private Sub AddNormalContextItem()
        Dim C As New ContextItem With {.Name = "Your Feature", .Clicked = AddressOf HandleContextItemClicked} 'We can add an image if we like using the .Image property
        IServerGUI.AddContextItem(C)
    End Sub
    Private Sub AddContextItemWithChildren()

        Dim Children As New List(Of ContextItem)
        Dim ChildItem As New ContextItem() With {.Clicked = AddressOf HandleContextItemClicked, .Name = "Your Feature"} 'Creating child item
        Children.Add(ChildItem) 'Adding child item

        Dim C As New ContextItem
        C.Name = "Client" 'Your Category, can even be an existing category in Imminent Monitor
        C.Children = Children.ToArray()

        IServerGUI.AddContextItem(C) ' Adding the context item

    End Sub
    Private Sub AddTabControl()
        Dim T As New TabItem With {.Contents = New UserControlSkeleton, .Name = "Your Feature"} 'Initializing a new TabItem, the "Contents" variable will be the contents of your tab control, a simple UserControl
        IServerGUI.AddTabItem(T) 'Adding the above TabItem to Imminent Monitors main form
    End Sub

#Region " Context Item Clicked Handlers "
    Private Sub HandleContextItemClicked(clients As IServerClient()) 'A Clicked handler must always take an array of clients as a parameter
        If clients.Length = 0 Then Return 'If no clients where selected, do nothing
    End Sub

#End Region

#End Region

End Class
