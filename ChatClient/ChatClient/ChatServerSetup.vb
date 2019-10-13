Public Class fmChatServerSetup

    Private Sub fmChatServerSetup_Load(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyBase.Load
        '先載入目前的預設值
        ServerIPAddressTextBox.Text = fmMain.ServerIPAddress
        ServerPortNoTextBox.Text = CType(fmMain.ServerPortNo, String)
    End Sub

    Private Sub btnSetup_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles btnSetup.Click
        '將修改過後的設定值，傳回主程式
        fmMain.ServerIPAddress = ServerIPAddressTextBox.Text
        fmMain.ServerPortNo = CType(ServerPortNoTextBox.Text, Integer)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class