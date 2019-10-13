<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ChatMemberListBox = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AttribNameTextBox = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.SendMessageTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MessageHistoryTextBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServerSetupMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoginMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.IPAddressText = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChatMemberListBox
        '
        Me.ChatMemberListBox.FormattingEnabled = True
        Me.ChatMemberListBox.ItemHeight = 16
        Me.ChatMemberListBox.Location = New System.Drawing.Point(0, 0)
        Me.ChatMemberListBox.Name = "ChatMemberListBox"
        Me.ChatMemberListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ChatMemberListBox.Size = New System.Drawing.Size(200, 468)
        Me.ChatMemberListBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(377, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "暱稱："
        '
        'AttribNameTextBox
        '
        Me.AttribNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AttribNameTextBox.Location = New System.Drawing.Point(436, 11)
        Me.AttribNameTextBox.Name = "AttribNameTextBox"
        Me.AttribNameTextBox.Size = New System.Drawing.Size(209, 23)
        Me.AttribNameTextBox.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Location = New System.Drawing.Point(651, 11)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(79, 23)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "登入"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'SendMessageTextBox
        '
        Me.SendMessageTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SendMessageTextBox.Location = New System.Drawing.Point(62, 45)
        Me.SendMessageTextBox.Multiline = True
        Me.SendMessageTextBox.Name = "SendMessageTextBox"
        Me.SendMessageTextBox.Size = New System.Drawing.Size(585, 82)
        Me.SendMessageTextBox.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "訊息："
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(652, 75)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(79, 23)
        Me.btnSend.TabIndex = 12
        Me.btnSend.Text = "傳送訊息"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ChatMemberListBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(737, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 467)
        Me.Panel1.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(737, 467)
        Me.Panel2.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.MessageHistoryTextBox)
        Me.Panel3.Controls.Add(Me.MenuStrip1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(737, 328)
        Me.Panel3.TabIndex = 3
        '
        'MessageHistoryTextBox
        '
        Me.MessageHistoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageHistoryTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageHistoryTextBox.Location = New System.Drawing.Point(0, 24)
        Me.MessageHistoryTextBox.Multiline = True
        Me.MessageHistoryTextBox.Name = "MessageHistoryTextBox"
        Me.MessageHistoryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MessageHistoryTextBox.Size = New System.Drawing.Size(737, 304)
        Me.MessageHistoryTextBox.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(737, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenuItem
        '
        Me.FileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerSetupMenuItem, Me.ToolStripMenuItem1, Me.LoginMenuItem, Me.LogoutMenuItem, Me.ToolStripMenuItem2, Me.ExitMenuItem})
        Me.FileMenuItem.Name = "FileMenuItem"
        Me.FileMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.FileMenuItem.Text = "檔案"
        '
        'ServerSetupMenuItem
        '
        Me.ServerSetupMenuItem.Name = "ServerSetupMenuItem"
        Me.ServerSetupMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ServerSetupMenuItem.Text = "伺服器設定"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(148, 6)
        '
        'LoginMenuItem
        '
        Me.LoginMenuItem.Name = "LoginMenuItem"
        Me.LoginMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.LoginMenuItem.Text = "登入"
        '
        'LogoutMenuItem
        '
        Me.LogoutMenuItem.Name = "LogoutMenuItem"
        Me.LogoutMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.LogoutMenuItem.Text = "登出"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(148, 6)
        '
        'ExitMenuItem
        '
        Me.ExitMenuItem.Name = "ExitMenuItem"
        Me.ExitMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ExitMenuItem.Text = "離開"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.BtnClear)
        Me.Panel4.Controls.Add(Me.IPAddressText)
        Me.Panel4.Controls.Add(Me.CheckBox1)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.AttribNameTextBox)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.btnLogin)
        Me.Panel4.Controls.Add(Me.btnSend)
        Me.Panel4.Controls.Add(Me.SendMessageTextBox)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 328)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(737, 139)
        Me.Panel4.TabIndex = 1
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(652, 105)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(79, 23)
        Me.BtnClear.TabIndex = 19
        Me.BtnClear.Text = "清除訊息"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'IPAddressText
        '
        Me.IPAddressText.Enabled = False
        Me.IPAddressText.Location = New System.Drawing.Point(60, 11)
        Me.IPAddressText.Name = "IPAddressText"
        Me.IPAddressText.Size = New System.Drawing.Size(131, 23)
        Me.IPAddressText.TabIndex = 13
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox1.Location = New System.Drawing.Point(664, 48)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(57, 20)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "私密"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(286, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(85, 23)
        Me.TextBox1.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(197, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "線上人數："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "ＩＰ："
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 467)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "fmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group 2 Chatting"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChatMemberListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AttribNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents SendMessageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MessageHistoryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents FileMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServerSetupMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label2 As Label
    Friend WithEvents IPAddressText As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnClear As Button
End Class
