Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Text

Public Class fmMain

    '定義預設通訊埠
    Dim ServerPortNo As Integer = 5001
    '定義執行緒類別
    Dim tcpThread As Thread
    '定義接聽程式類別
    Dim chatListener As TcpListener
    'TCP用戶端的聊天室類別
    Dim ChatClient As Chat

    Private Sub fmMain_Load(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyBase.Load

        '預設通訊埠
        PortTextBox.Text = CType(ServerPortNo, Integer)

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles btnStart.Click

        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        '啟動
        btnStart.Enabled = False
        PortTextBox.Enabled = False
        '啟動伺服器的服務
        '建立執行緒
        tcpThread = New Thread(New ThreadStart(AddressOf StartTcpListener))
        '啟動執行緒
        tcpThread.Start()

        TextBox1.Text = strIPAddress

    End Sub

    Private Sub fmMain_FormClosing(ByVal sender As System.Object, _
                ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                Handles MyBase.FormClosing

        '結束程式前,先停止服務
        StopThread()

    End Sub

    Public Sub StartTcpListener()

        'IP ADDRESS
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        '忽略錯誤執行緒的呼叫
        ListBox.CheckForIllegalCrossThreadCalls = False
        TextBox.CheckForIllegalCrossThreadCalls = False
        Button.CheckForIllegalCrossThreadCalls = False
        '建立IPAddress類別
        Dim localIPAddress As IPAddress = IPAddress.Parse("127.0.0.1")
        '建立TcpListener類別
        chatListener = New TcpListener(localIPAddress, CInt(PortTextBox.Text))
        Try
            '啟動TcpListener類別
            chatListener.Start()

            Do

                '接受客戶端的TcpClient服務
                ChatClient = New Chat
                ChatClient.ChatTcpClient = chatListener.AcceptTcpClient()
                '取得來自客戶端的IP Address
                Dim clientIP As IPAddress = IPAddress.Parse(
                                CType(chatListener.LocalEndpoint,
                                IPEndPoint).Address.ToString())
                ChatClient.RemoteIP = clientIP
                '開始非同步接收資料
                ChatClient.StartReceive()

            Loop
        Catch sk As SocketException
            With LogListBox.Items
                .Add("啟動執行緒發生SocketException錯誤：")
                .Add("                        Message  ：" & sk.Message)
                .Add("                        ErrorCode：" & sk.ErrorCode)
            End With
        Catch ex As Exception
            With LogListBox.Items
                .Add("啟動執行緒不可預期的錯誤：")
                .Add("                 Message：" & ex.Message)
            End With
        End Try
    End Sub

    '停止多執行緒與接聽服務
    Private Sub StopThread()
        If tcpThread Is Nothing Then
            Exit Sub
        End If
        If tcpThread.IsAlive Then
            tcpThread.Abort()
        End If
        '如果已啟動chatListener,就把它停止!
        If Not chatListener Is Nothing Then
            chatListener.Stop()
        End If
    End Sub

    Private Sub LogListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LogListBox.SelectedIndexChanged

    End Sub
End Class

Public Class Chat

    '所有Chat類別的共用屬性,記錄所有的Chat類別
    Public Shared FChatMember As New Hashtable
    '用戶端的TcpClient
    Private FChatTcpClient As TcpClient
    '用戶端的IP位址
    Private FRemoteIP As IPAddress
    '用戶端的暱稱
    Private FAttribName As String
    '接收的資料
    Private FReceiveData() As Byte


    '用戶端的TcpClient類別
    Public Property ChatTcpClient() As TcpClient
        Get
            Return FChatTcpClient
        End Get
        Set(ByVal value As TcpClient)
            FChatTcpClient = value
        End Set
    End Property

    '用戶端的連線IP位址
    Public Property RemoteIP() As IPAddress
        Get
            Return FRemoteIP
        End Get
        Set(ByVal value As IPAddress)
            FRemoteIP = value          
        End Set
    End Property

    '用戶端的暱稱
    Public Property AttribName() As String
        Get
            Return FAttribName
        End Get
        Set(ByVal value As String)
            FAttribName = value
        End Set
    End Property

    Public Sub StartReceive()
        '
        ReDim FReceiveData(FChatTcpClient.ReceiveBufferSize - 1)
        '開始非同步讀取
        FChatTcpClient.GetStream.BeginRead(FReceiveData, 0, _
                                 CInt(FChatTcpClient.ReceiveBufferSize), _
                                 AddressOf ReceiveMessage, Nothing)
    End Sub

    '接收來自客戶端的資料
    Public Sub ReceiveMessage(ByVal ar As IAsyncResult)
        '---read from client---
        Dim bytesRead As Integer
        Try
            '結束非同步的讀取資料
            bytesRead = FChatTcpClient.GetStream.EndRead(ar)
            '用戶端離線
            If bytesRead < 1 Then
                '用戶端TcpClient連線離開()
                '從成員清單移除成員()
                FChatMember.Remove(FRemoteIP)
                '用戶端離開聊天室，廣播告知所有聊天室的成員
                Broadcast("06" + Chr(10) + FAttribName, Nothing)
                Exit Sub
            Else
                '取得接收的資料
                Dim RecvStr As String = Encoding.Default.GetString( _
                                        FReceiveData, 0, bytesRead)
                Dim strCmd As String
                Dim JoinMember As String
                Dim message As String
                '取得接收的命令類型
                strCmd = RecvStr.Substring(0, 2)
                Dim strTemp() As String
                Select Case strCmd
                    Case "01"
                        '命令01 用戶端加入聊天室
                        '命令碼, 用戶端暱稱
                        '分解封包欄位
                        strTemp = RecvStr.Split(Chr(10))
                        '用戶端暱稱
                        JoinMember = strTemp(1)
                        '將用戶端暱稱指派給屬性AttribName
                        FAttribName = JoinMember
                        Try
                            '以暱稱做為Key值
                            FChatMember.Add(FAttribName, Me)
                        Catch ex As Exception
                            '重複的暱稱不加入
                        End Try
                        '回覆命令02
                        '命令碼, 用戶端暱稱
                        Broadcast("02" + Chr(10) + strTemp(1), Nothing)
                    Case "03"
                        '命令03 取得所有在聊天室的成員暱稱
                        '命令碼, 用戶端暱稱
                        Dim MemberList As String = "04"
                        Dim de As DictionaryEntry
                        For Each de In FChatMember
                            '取得所有成員的暱稱
                            MemberList += Chr(10) + _
                               CType(de.Value, Chat).FAttribName
                        Next
                        '回覆命令04
                        '命令碼, 用戶端暱稱, 用戶端暱稱,...
                        Broadcast(MemberList, Nothing)
                    Case "05"
                        '命令05 用戶登出聊天室
                        '命令碼, 用戶端暱稱
                        '分解封包欄位
                        strTemp = RecvStr.Split(Chr(10))
                        '用戶端暱稱
                        JoinMember = strTemp(1)
                        '回覆命令06
                        '命令碼, 用戶端暱稱
                        Broadcast("06" + Chr(10) + strTemp(1), Nothing)
                    Case "07"
                        '命令07 用戶端傳送訊息給朋友
                        '命令碼,傳送訊息者,接收訊息人數,接收訊息人清單...,傳送的訊息
                        Dim ReceiveMemberCount As Integer
                        Dim ReceiveMember As String
                        Dim SendMember As String
                        '分解封包欄位
                        strTemp = RecvStr.Split(Chr(10))
                        '找出接收訊息人數
                        ReceiveMemberCount = CType(strTemp(2), Integer)
                        '傳送訊息者
                        SendMember = strTemp(1)
                        Dim i, iEnd As Integer
                        '封包欄位數
                        iEnd = strTemp.Length
                        For i = 3 To ReceiveMemberCount + 2
                            '接收訊息人暱稱
                            ReceiveMember = strTemp(i)
                            '傳送的訊息
                            message = strTemp(iEnd - 1)
                            '回覆命令08
                            '命令碼,傳送者,傳送訊息
                            Broadcast("08" + Chr(10) + SendMember + Chr(10) +
                                      message, ReceiveMember)
                        Next

                        '全頻
                    Case "09"
                        '命令07 用戶端傳送訊息給朋友
                        '命令碼,傳送訊息者,接收訊息人數,接收訊息人清單...,傳送的訊息
                        Dim ReceiveMemberCount As Integer
                        Dim ReceiveMember As String
                        Dim SendMember As String
                        '分解封包欄位
                        strTemp = RecvStr.Split(Chr(10))
                        '找出接收訊息人數
                        ReceiveMemberCount = CType(strTemp(2), Integer)
                        '傳送訊息者
                        SendMember = strTemp(1)
                        Dim i, iEnd As Integer
                        '封包欄位數
                        iEnd = strTemp.Length
                        For i = 3 To ReceiveMemberCount + 2
                            '接收訊息人暱稱
                            ReceiveMember = strTemp(i)
                            '傳送的訊息
                            message = strTemp(iEnd - 1)
                            '回覆命令08
                            '命令碼,傳送者,傳送訊息
                            Broadcast("10" + Chr(10) + SendMember + Chr(10) +
                                      message, ReceiveMember)
                        Next
                End Select
                '繼續非同步資料讀取
                FChatTcpClient.GetStream.BeginRead(FReceiveData, 0, _
                               CInt(FChatTcpClient.ReceiveBufferSize), _
                               AddressOf ReceiveMessage, Nothing)
            End If
        Catch ode As ObjectDisposedException
            '產生ObjectDisposedException例外
            '從成員清單移除成員
            FChatMember.Remove(FRemoteIP)
            '用戶端離開聊天室，廣播告知所有聊天室的成員
            Broadcast("06" & Chr(10) & FAttribName, Nothing)
        Catch ex As Exception
            '用戶端錯誤，中斷連線
            '從成員清單移除成員
            FChatMember.Remove(FRemoteIP)
            '用戶端離開聊天室，廣播告知所有聊天室的成員
            Broadcast("06" & Chr(10) & FAttribName, Nothing)
        End Try
    End Sub

    '傳送訊息給客戶端
    Public Sub SendMessage(ByVal message As String)
        Try
            '定義資料流物件
            Dim ns As System.Net.Sockets.NetworkStream
            '取得TcpClient類別的資料流
            ns = FChatTcpClient.GetStream
            Dim bytesToSend As Byte() = _
                System.Text.Encoding.Default.GetBytes(message)
            '將傳送的訊息寫入資料流
            ns.Write(bytesToSend, 0, bytesToSend.Length)
            ns.Flush()
        Catch ex As Exception
            '將錯誤訊息加入ListBox控制項
            fmMain.LogListBox.Items.Add(ex.Message)
        End Try
    End Sub

    '廣播訊息給在聊天室所指定的用戶端
    Public Sub Broadcast(ByVal message As String, ByVal user As String)

        '沒有指定使用者,就是要傳送給每一個人
        If user Is Nothing Then
            Dim c As DictionaryEntry
            For Each c In FChatMember
                '廣播訊息
                CType(c.Value, Chat).SendMessage(message)
            Next
        Else
            '傳送訊息給指定的用戶端
            Dim de As DictionaryEntry
            For Each de In FChatMember
                '找出指定用戶端的Chat類別
                If CType(de.Value, Chat).FAttribName = user Then
                    '傳送訊息給指定的用戶端
                    CType(de.Value, Chat).SendMessage(message)
                    Exit For
                End If
            Next
        End If

    End Sub

End Class
