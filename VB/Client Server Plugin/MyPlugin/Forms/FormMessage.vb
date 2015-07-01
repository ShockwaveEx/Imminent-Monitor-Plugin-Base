Imports Imminent
Imports Imminent.GUI
Imports Imminent.IServerVars
Public Class FormMessage

    Private IServerClient As IServerClient
    Sub New(_IServerClient As IServerClient)
        InitializeComponent()
        IServerClient = _IServerClient
        Me.Text = String.Format("Message - {0}", IServerClient.IServerState.UserName)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IServerNetworkActions.SendToClient(IServerClient, Command.Message, TextBox1.Text)
    End Sub

End Class