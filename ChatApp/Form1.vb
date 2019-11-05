Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports NetComm
Imports Microsoft.Win32

Partial Public Class Form1
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    Private server As NetComm.Host = New Host(3330) ' Listens on port 3330.
    Private Delegate Sub DisplayInformationDelegate(ByVal s As String)
    Private clientList As New ArrayList() ' Share amongst all instances of the Clients
    Private mstrSep As String = "##Enigma##"
    Private lngNewVer As Long = 0

    Public Sub New()
        InitializeComponent()
        AddHandler server.ConnectionClosed, AddressOf Server_ConnectionClosed
        AddHandler server.DataReceived, AddressOf Server_DataReceived
        AddHandler server.DataTransferred, AddressOf Server_DataTransferred
        AddHandler server.errEncounter, AddressOf ServerErrEncounter
        AddHandler server.lostConnection, AddressOf ServerLostConnection
        AddHandler server.onConnection, AddressOf ServerOnConnection
        server.StartConnection()
        rtbConOut.AppendText(Environment.NewLine)
    End Sub

    Private Sub FrmClient_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            NotifyIcon.Visible = True
            NotifyIcon.ShowBalloonTip(1, "Chat Server", "Running Minimized", ToolTipIcon.Info)
        End If

    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon.Visible = False

    End Sub

    Private Sub ServerOnConnection(ByVal id As String)
        DisplayInformation(String.Format("Client {0} Connected", id))
        clientList.Add(id)
        lblConnections.Text = clientList.Count.ToString
        SendClientList()
    End Sub

    Private Sub SendClientList()
        DisplayInformation("Sending Client List to all") ' This is not how we would normally do this
        Dim strUserName As String = clientList.Count & " Members."
        For Each cid2 As String In clientList
            strUserName = strUserName & " (" & cid2 & ")"
        Next cid2
        For Each cid As String In clientList
            Dim d() As Byte = ConvertStringToBytes("CList::" & strUserName)
            server.SendData(cid, d)
        Next cid
    End Sub

    Private Sub ServerLostConnection(ByVal id As String)
        DisplayInformation(String.Format("Client {0} Lost Connection", id))
        clientList.Remove(id)
        lblConnections.Text = clientList.Count.ToString
    End Sub

    Private Sub ServerErrEncounter(ByVal ex As Exception)
        DisplayInformation("Server Error " & ex.Message)
    End Sub

    Private Sub Server_DataTransferred(ByVal sender As String, ByVal recipient As String, ByVal data() As Byte)
        Dim senderId As String = CStr(sender)
        If recipient = "0" Then
            DisplayInformation("Received Command From Client " & senderId)
            Dim strData As String = ConvertBytesToString(data)
            If strData.Equals("CLOSING") Then
                DisplayInformation("Client " & senderId & " is Closing")
                clientList.Remove(senderId)
                lblConnections.Text = clientList.Count.ToString
                SendClientList()
            ElseIf strData.StartsWith("CVer::") Then
                Dim lngUserVer As Long = CLng(strData.Replace("CVer::", ""))
                If lngUserVer > lngNewVer Then
                    lngNewVer = lngUserVer
                End If
                For Each id As String In clientList
                    server.SendData(id, ConvertStringToBytes("NEWVer::" & lngNewVer.ToString))
                Next id
            Else
                For Each id As String In clientList
                    If id <> senderId Then ' Don't send this message to the client that sent the message in the first place
                        server.SendData(id, data)
                    End If
                Next id
            End If
        Else
            DisplayInformation("Received Command From Client " & senderId & " for Client " & recipient)
        End If
    End Sub

    Private Sub Server_DataReceived(ByVal iD As String, ByVal data() As Byte)
        Dim strData As String = ConvertBytesToString(data)
        If strData = "CLOSING" Then
            DisplayInformation("Client " & iD & " has closed")
        End If
        If strData.StartsWith("CVer::") Then
            DisplayInformation("Client " & iD & " using Ver:" & strData.Replace("CVer::", ""))
        End If
    End Sub

    Private Sub Server_ConnectionClosed()
        DisplayInformation("Connection Was Closed")
    End Sub

    Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
        Return UnicodeEncoding.Unicode.GetString(bytes)
    End Function

    Private Function ConvertStringToBytes(ByVal str As String) As Byte()
        Return UnicodeEncoding.Unicode.GetBytes(str)
    End Function

    Private Sub DisplayInformation(ByVal s As String)
        Dim strTime As String = DateTime.Now.ToLongTimeString
        If Me.rtbConOut.InvokeRequired Then
            Dim d As New DisplayInformationDelegate(AddressOf DisplayInformation)
            Me.rtbConOut.Invoke(d, New Object() {s})
        Else
            Me.rtbConOut.AppendText(strTime & " " & s & Environment.NewLine)
        End If
        rtbConOut.SelectionStart = rtbConOut.Text.Length
        rtbConOut.ScrollToCaret()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using subKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If subKey.GetValue("SKB_Server") Is Nothing Then
                subKey.SetValue("SKB_Server", """" & Application.ExecutablePath & """")
                subKey.Close()
            End If
        End Using
    End Sub
End Class