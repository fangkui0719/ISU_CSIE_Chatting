<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmChatServerSetup
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
        Me.ServerIPAddressTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ServerPortNoTextBox = New System.Windows.Forms.TextBox
        Me.btnSetup = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ServerIPAddressTextBox
        '
        Me.ServerIPAddressTextBox.Location = New System.Drawing.Point(120, 16)
        Me.ServerIPAddressTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ServerIPAddressTextBox.Name = "ServerIPAddressTextBox"
        Me.ServerIPAddressTextBox.Size = New System.Drawing.Size(150, 23)
        Me.ServerIPAddressTextBox.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "聊天室伺服器："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "通訊埠："
        '
        'ServerPortNoTextBox
        '
        Me.ServerPortNoTextBox.Location = New System.Drawing.Point(120, 47)
        Me.ServerPortNoTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ServerPortNoTextBox.Name = "ServerPortNoTextBox"
        Me.ServerPortNoTextBox.Size = New System.Drawing.Size(150, 23)
        Me.ServerPortNoTextBox.TabIndex = 8
        '
        'btnSetup
        '
        Me.btnSetup.Location = New System.Drawing.Point(114, 77)
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.Size = New System.Drawing.Size(75, 23)
        Me.btnSetup.TabIndex = 9
        Me.btnSetup.Text = "設定"
        Me.btnSetup.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(195, 77)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'fmChatServerSetup
        '
        Me.AcceptButton = Me.btnSetup
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(288, 115)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSetup)
        Me.Controls.Add(Me.ServerPortNoTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ServerIPAddressTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmChatServerSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "聊天室伺服器設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ServerIPAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ServerPortNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnSetup As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
