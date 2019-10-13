Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Text

Public Class fmMain

    '記憶是否登入伺服器的旗標
    Dim IsLogin As Boolean
    '伺服器的位址
    Public ServerIPAddress As String
    '伺服器的通訊埠
    Public ServerPortNo As Integer
    '用戶端的TcpClient物件
    Private ClientChat As TcpClient
    '接收資料的變數
    Private data() As Byte

    Private Sub fmMain_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load

        '系統初始設定
        '
        '尚未登入伺服器
        IsLogin = False
        '預設伺服器IP位址(就是自己)
        ServerIPAddress = "127.0.0.1"
        '預設伺服器的通訊埠
        ServerPortNo = 5001
        '控制項狀態
        BtnState()
        Button.CheckForIllegalCrossThreadCalls = False
    End Sub

    '更改伺服器的設定
    Private Sub ServerSetupMenuItem_Click(ByVal sender As System.Object,
                ByVal e As System.EventArgs) _
                Handles ServerSetupMenuItem.Click

        '只有再未登入的情況,才可以修改伺服器的設定
        If Not IsLogin Then
            '叫出伺服器設定的視窗
            Dim TfmChatServerSetup As New fmChatServerSetup
            TfmChatServerSetup.ShowDialog()
        End If
    End Sub

    '登入伺服器
    Private Sub LoginMenuItem_Click(ByVal sender As System.Object,
                ByVal e As System.EventArgs) _
                Handles LoginMenuItem.Click

        If Not IsLogin Then
            LoginChat()
        End If

    End Sub

    '登出伺服器
    Private Sub LogoutMenuItem_Click(ByVal sender As System.Object,
                ByVal e As System.EventArgs) _
                Handles LogoutMenuItem.Click

        If IsLogin Then
            LogoutChat()
        End If

    End Sub

    '離開程式
    Private Sub ExitMenuItem_Click(ByVal sender As System.Object,
                ByVal e As System.EventArgs) _
                Handles ExitMenuItem.Click
        Me.Close()
    End Sub

    '登入/登出伺服器
    Private Sub btnLogin_Click(ByVal sender As System.Object,
                ByVal e As System.EventArgs) _
                Handles btnLogin.Click



        If Not IsLogin Then
            '登入伺服器
            LoginChat()
            TextBox1.Text = 1
        Else
            '登出伺服器
            LogoutChat()

        End If

    End Sub

    '登入伺服器程序
    Private Sub LoginChat()


        '沒有輸入暱稱,不可以登入伺服器
        If AttribNameTextBox.Text = "" Then
            MessageBox.Show("請輸入暱稱！", "警告",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            '建立TcpClient類別
            ClientChat = New TcpClient
            '連接至伺服器
            ClientChat.Connect(ServerIPAddress, ServerPortNo)
            ReDim data(ClientChat.ReceiveBufferSize - 1)
            '傳送登入的命令01
            '命令碼,登入者
            SendMessage("01" + Chr(10) + AttribNameTextBox.Text)
            '開始非同步的讀取
            ClientChat.GetStream.BeginRead(
               data, 0, CInt(ClientChat.ReceiveBufferSize),
               AddressOf ReceiveMessage, Nothing)
            '暫停1秒
            Thread.Sleep(1000)
            '傳送重整聊天室成員清單
            '命令碼,登入者
            SendMessage("03" + Chr(10) + AttribNameTextBox.Text)
            '登入
            IsLogin = True
        Catch ex As Exception
            MessageBox.Show("登入聊天室發生錯誤！" + vbCrLf + vbCrLf +
                            ex.Message, "錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            '登出
            IsLogin = False
        End Try
        '改變控制項的狀態
        BtnState()
    End Sub

    '登出聊天室
    Private Sub LogoutChat()
        '中斷與伺服器的連線
        Disconnect()
        '清除所有聊天室的成員清單
        ChatMemberListBox.Items.Clear()
        '改變控制項的狀態
        BtnState()
    End Sub

    '中斷與伺服器的連線
    Public Sub Disconnect()
        Try
            '傳送離開聊天室的命令
            '命令碼,登出者
            SendMessage("05" + Chr(10) + AttribNameTextBox.Text)
            '關閉資料流
            ClientChat.GetStream.Close()
            '關閉TcpClient
            ClientChat.Close()
            IsLogin = False
        Catch ex As Exception
            MessageBox.Show("登出聊天室發生錯誤！" + vbCrLf + vbCrLf +
                            ex.Message, "錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '改變控制項的狀態
    Private Sub BtnState()
        'IP Address
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        If IsLogin Then
            '如果是登入
            btnLogin.Text = "登出"
            btnSend.Enabled = True
            LoginMenuItem.Enabled = False
            LogoutMenuItem.Enabled = True
            ServerSetupMenuItem.Enabled = False
            AttribNameTextBox.Enabled = False
            IPAddressText.Text = strIPAddress
        Else
            '如果示登出
            btnLogin.Text = "登入"
            btnSend.Enabled = False
            LoginMenuItem.Enabled = True
            LogoutMenuItem.Enabled = False
            ServerSetupMenuItem.Enabled = True
            AttribNameTextBox.Enabled = True
            IPAddressText.Text = ""
        End If
    End Sub

    '傳送訊息按鈕
    Private Sub btnSend_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles btnSend.Click

        'count 作為checkbox1判斷
        Dim count As Char
        If CheckBox1.Checked = True Then
            count = "a"
        Else
            count = "b"
        End If

        '以checkbox決定全頻或私密
        Select Case count
            Case "a"
                '沒選擇聊天對象無法傳送訊息
                If ChatMemberListBox.SelectedItems.Count < 1 Then
                    MessageBox.Show("請至少選擇一名要聊天的對象！", "警告",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Dim ReceiveMemberList As String
                Dim ReceiveMemberCount As Integer
                '找出所選擇聊天人數
                ReceiveMemberCount = ChatMemberListBox.SelectedItems.Count
                '找出所有選擇的聊天對象
                ReceiveMemberList = ""
                For Each member In ChatMemberListBox.SelectedItems
                    ReceiveMemberList += member + Chr(10)
                Next
                '命令碼,傳送訊息者,接收訊息人數,接收訊息人清單...,傳送的訊息
                SendMessage("07" + Chr(10) + AttribNameTextBox.Text + Chr(10) +
                            CType(ReceiveMemberCount, String) + Chr(10) +
                            ReceiveMemberList + SendMessageTextBox.Text)
                '將傳送訊息加入對話記錄
                MessageHistoryTextBox.Text += "[私密]" + AttribNameTextBox.Text +
                                              ": " + SendMessageTextBox.Text +
                                              vbCrLf
                '清除已發送的訊息
                SendMessageTextBox.Text = ""
            Case "b"
                Dim ReceiveMemberList As String
                Dim ReceiveMemberCount As Integer
                '找出所選擇聊天人數
                ReceiveMemberCount = ChatMemberListBox.Items.Count
                '找出所有選擇的聊天對象
                ReceiveMemberList = ""
                For Each member In ChatMemberListBox.Items
                    ReceiveMemberList += member + Chr(10)
                Next
                '命令碼,傳送訊息者,接收訊息人數,接收訊息人清單...,傳送的訊息
                SendMessage("09" + Chr(10) + AttribNameTextBox.Text + Chr(10) +
                            CType(ReceiveMemberCount, String) + Chr(10) +
                            ReceiveMemberList + SendMessageTextBox.Text)
                '將傳送訊息加入對話記錄
                MessageHistoryTextBox.Text += "[全頻]" + AttribNameTextBox.Text +
                                              ": " + SendMessageTextBox.Text +
                                              vbCrLf
                '清除已發送的訊息
                SendMessageTextBox.Text = ""
        End Select
    End Sub

    '傳送訊息給伺服器
    Public Sub SendMessage(ByVal message As String)
        Try
            '將要傳送的訊息寫入資料流
            Dim ns As NetworkStream
            SyncLock ClientChat.GetStream
                ns = ClientChat.GetStream
                Dim bytesToSend As Byte() =
                   Encoding.Default.GetBytes(message)
                ns.Write(bytesToSend, 0, bytesToSend.Length)
            End SyncLock
        Catch ex As Exception
            MessageBox.Show("傳送訊息發生錯誤！" + vbCrLf + vbCrLf +
                            ex.Message, "錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '接收來自伺服器的訊息
    Public Sub ReceiveMessage(ByVal ar As IAsyncResult)

        Try
            Dim bytesRead As Integer
            bytesRead = ClientChat.GetStream.EndRead(ar)
            If bytesRead < 1 Then
                Exit Sub
            Else
                Dim RecvStr As String = Encoding.Default.GetString(
                                        data, 0, bytesRead)
                Dim strCmd As String
                Dim strTemp() As String
                '找出命令類型
                strCmd = RecvStr.Substring(0, 2)
                '分解每一個封包的欄位
                strTemp = RecvStr.Split(Chr(10))
                Select Case strCmd
                    Case "02"
                        '命令02:有朋友加入聊天室
                        '命令碼, 加入者暱稱, 是否成功加入聊天室
                        Dim JoinMember As String

                        '暱稱
                        JoinMember = strTemp(1)
                        '將朋友加入聊天室成員清單
                        Me.Invoke(New delAddMemberList(
                                  AddressOf Me.AddMemberList), JoinMember)
                    Case "04"
                        '命令04:接收聊天室的成員清單
                        '命令碼, 成員暱稱.....
                        Dim i, iL As Integer
                        '找出封包欄位數量
                        iL = strTemp.Length
                        '逐一將朋友加入聊天室成員清單
                        For i = 1 To iL - 1
                            Me.Invoke(New delAddMemberList(
                                      AddressOf Me.AddMemberList), strTemp(i))
                        Next
                    Case "06"
                        '命令06:有朋友離開入聊天室
                        '命令碼, 離開者暱稱
                        Dim JoinMember As String
                        '暱稱
                        JoinMember = strTemp(1)
                        '將朋友從聊天室成員清單移除
                        Me.Invoke(New delRemoveMemberList(
                                  AddressOf Me.RemoveMemberList), JoinMember)
                    Case "08"
                        '命令08:接收訊息
                        '命令碼, 發送者暱稱, 訊息
                        Dim SendMember, Message As String
                        '發送者暱稱
                        SendMember = strTemp(1)
                        '訊息
                        Message = strTemp(2)
                        '將聊天訊息加入對話記錄
                        Me.Invoke(New delUpdateHistory(
                                  AddressOf Me.UpdateHistory), "[私密]" + SendMember +
                                  ": " + Message)
                    Case "10"
                        '命令10:接收全頻訊息
                        '命令碼, 發送者暱稱, 訊息
                        Dim SendMember, Message As String
                        '發送者暱稱
                        SendMember = strTemp(1)
                        '訊息
                        Message = strTemp(2)
                        '將聊天訊息加入對話記錄
                        Me.Invoke(New delUpdateHistory(
                                  AddressOf Me.UpdateHistory), "[全頻]" + SendMember +
                                  ": " + Message)
                End Select
            End If
            '繼續非同步讀取
            ClientChat.GetStream.BeginRead(data, 0,
                       CInt(ClientChat.ReceiveBufferSize),
                            AddressOf ReceiveMessage, Nothing)
        Catch ode As ObjectDisposedException
            '
        Catch iie As IO.IOException
            '
            Me.Invoke(New delUpdateHistory(AddressOf Me.UpdateHistory),
                                           "伺服器強制關閉連線!")
            '關閉資料流
            ClientChat.GetStream.Close()
            '關閉TcpClient
            ClientChat.Close()
            '狀態為未登入
            IsLogin = False
            '改變控制項的狀態
            BtnState()
        Catch ex As Exception
            MessageBox.Show("聊天室發生不可預期的錯誤！" &
                            vbCrLf & vbCrLf &
                            ex.Message, "錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '整理聊天室的成員清單
    Public Delegate Sub delAddMemberList(ByVal str As String)
    Public Sub AddMemberList(ByVal str As String)
        '成員是自己,不加入聊天室成員清單
        If str = AttribNameTextBox.Text Then
            Exit Sub
        End If
        '要加入的成員不在聊天室成員清單, 才加入
        If ChatMemberListBox.Items.IndexOf(str) < 0 Then
            ChatMemberListBox.Items.Add(str)
            Me.Invoke(New delUpdateHistory(
                                  AddressOf Me.UpdateHistory), "[系統]" + str +
                                  "加入了聊天室！")
        End If
        TextBox1.Text = 1 + ChatMemberListBox.Items.Count

    End Sub

    '移除離開聊天室的成員清單
    Public Delegate Sub delRemoveMemberList(ByVal str As String)
    Public Sub RemoveMemberList(ByVal str As String)
        If ChatMemberListBox.Items.IndexOf(str) >= 0 Then
            ChatMemberListBox.Items.RemoveAt(
               ChatMemberListBox.Items.IndexOf(str))
            Me.Invoke(New delUpdateHistory(
                                  AddressOf Me.UpdateHistory), "[系統]" + str +
                                  "離開了聊天室！")
        End If
    End Sub

    '更新聊天記錄
    Public Delegate Sub delUpdateHistory(ByVal str As String)
    Public Sub UpdateHistory(ByVal str As String)
        MessageHistoryTextBox.Text += str + vbCrLf
    End Sub

    '私密選擇判斷

    Private Sub ChatMemberListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChatMemberListBox.SelectedIndexChanged

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub AttribNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles AttribNameTextBox.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub FileMenuItem_Click(sender As Object, e As EventArgs) Handles FileMenuItem.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub SendMessageTextBox_TextChanged(sender As Object, e As EventArgs) Handles SendMessageTextBox.TextChanged

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub MessageHistoryTextBox_TextChanged(sender As Object, e As EventArgs) Handles MessageHistoryTextBox.TextChanged

    End Sub

    Private Sub IPAddressText_TextChanged(sender As Object, e As EventArgs) Handles IPAddressText.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        MessageHistoryTextBox.Text = ""
    End Sub

End Class
