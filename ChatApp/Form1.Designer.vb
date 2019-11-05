Partial Public Class Form1
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblConnections = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.rtbConOut = New System.Windows.Forms.RichTextBox()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.statusStrip1.SuspendLayout()
        Me.toolStripContainer1.ContentPanel.SuspendLayout()
        Me.toolStripContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1, Me.lblConnections})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 341)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(331, 23)
        Me.statusStrip1.TabIndex = 0
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(78, 18)
        Me.toolStripStatusLabel1.Text = "Connections"
        '
        'lblConnections
        '
        Me.lblConnections.Name = "lblConnections"
        Me.lblConnections.Size = New System.Drawing.Size(15, 18)
        Me.lblConnections.Text = "0"
        '
        'toolStripContainer1
        '
        '
        'toolStripContainer1.ContentPanel
        '
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.rtbConOut)
        Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(331, 341)
        Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolStripContainer1.LeftToolStripPanelVisible = False
        Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.toolStripContainer1.Name = "toolStripContainer1"
        Me.toolStripContainer1.RightToolStripPanelVisible = False
        Me.toolStripContainer1.Size = New System.Drawing.Size(331, 341)
        Me.toolStripContainer1.TabIndex = 2
        Me.toolStripContainer1.Text = "toolStripContainer1"
        Me.toolStripContainer1.TopToolStripPanelVisible = False
        '
        'rtbConOut
        '
        Me.rtbConOut.BackColor = System.Drawing.Color.RoyalBlue
        Me.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbConOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbConOut.ForeColor = System.Drawing.Color.Yellow
        Me.rtbConOut.Location = New System.Drawing.Point(0, 0)
        Me.rtbConOut.Name = "rtbConOut"
        Me.rtbConOut.ShowSelectionMargin = True
        Me.rtbConOut.Size = New System.Drawing.Size(331, 341)
        Me.rtbConOut.TabIndex = 2
        Me.rtbConOut.Text = "Server V1"
        '
        'NotifyIcon
        '
        Me.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "S.K.Bくん"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(331, 364)
        Me.Controls.Add(Me.toolStripContainer1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SKB_Server"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.toolStripContainer1.ResumeLayout(False)
        Me.toolStripContainer1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private lblConnections As System.Windows.Forms.ToolStripStatusLabel
    Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Private rtbConOut As System.Windows.Forms.RichTextBox
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
End Class