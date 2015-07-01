Imports Imminent
Public Class Main
    Implements IClientMain

#Region " Global Variables "
    Public IClientNetworkActions As IClientNetworkActions
#End Region

#Region " Constructor "
    Sub New(_IClientNetworkActions As IClientNetworkActions)
        'Set global instances to instance passed through constructor, this is 100% needed otherwise your plugin will not operate
        IClientNetworkActions = _IClientNetworkActions
    End Sub
#End Region

#Region " Events "
    Public Sub ReceivedPacket(params() As Object) Implements IClientMain.ReceivedPacket
        Dim header As Command = DirectCast(params(0), Command) 'Cast header to type of command
        ParseCommand(header, params) 'Parse header and parameters to "ParseCommand"
    End Sub

    Public Sub StateChanged(connected As Boolean) Implements IClientMain.StateChanged
        Select Case connected
            Case False
                'Disconnected
            Case True
                'Connected
        End Select
    End Sub

    Public Sub Unload() Implements IClientMain.Unload
        'This event gets raised when the plugin is disabled, please terminate all loops, threads and forms in this method.
    End Sub

#End Region

#Region " Packet Handlers "
    Private Sub ParseCommand(header As Command, params As Object())
        Select Case header
            Case Command.Message
                Dim text As String = DirectCast(params(1), String) 'Casting params(1) to typeof string
                HandleMessagePacket(text)
        End Select
    End Sub

    Private Sub HandleMessagePacket(text As String)
        MsgBox(text) 'Show server inputted message
    End Sub

#End Region

End Class
