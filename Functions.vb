Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing.Printing

Module Functions
    Public Const downloadedImagesFolder As String = "C:\MyParty\DownloadedImages"
    Private Const HWND_BROADCAST As Long = &HFFFF&
    Private Const WM_WININICHANGE As Long = &H1A
    Public DBCon As MySqlConnection
    Public storeID As Integer
    Public selectedOrder As Integer
    Public originalImagePath As String
    Public loggedUser As String
    Public downloadPath As String
    Public destinationPath As String
    Public WithEvents m_PrintDocument As PrintDocument

    Private Declare Function WriteProfileString Lib "kernel32" Alias "WriteProfileStringA" _
    (ByVal lpszSection As String, ByVal lpszKeyName As String, _
    ByVal lpszString As String) As Long

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
         (ByVal hwnd As Long, ByVal wMsg As Long, _
         ByVal wParam As Long, ByVal lparam As String) As Long

    Public Sub openConnection()
        DBCon = New MySqlConnection
        DBCon.ConnectionString = My.Settings.MySQLConnectionString
        DBCon.Open()
    End Sub

    Public Sub closeConnection()
        DBCon.Close()
    End Sub

    Public Sub createDownloadFolder()
        If (Not System.IO.Directory.Exists(downloadedImagesFolder)) Then
            System.IO.Directory.CreateDirectory(downloadedImagesFolder)
        End If
    End Sub

    Public Sub m_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles m_PrintDocument.PrintPage
        'Load the picture
        Dim myPicture As System.Drawing.Image = System.Drawing.Image.FromFile(destinationPath)
        'Print the Image.  'e' is the Print events that the printer provides.  In e is a graphics object on hwich you can draw.
        '10, 10 is the position to print the picture.  
        e.Graphics.DrawImage(myPicture, 10, 10)
        ' There's only one page.
        e.HasMorePages = False
    End Sub

    Public Sub SetDefaultPrinter(ByVal PrinterName As String, _
    ByVal DriverName As String, ByVal PrinterPort As String)
        Dim DeviceLine As String

        'rebuild a valid device line string
        DeviceLine = PrinterName & "," & DriverName & "," & PrinterPort

        'Store the new printer information in the
        '[WINDOWS] section of the WIN.INI file for
        'the DEVICE= item
        Call WriteProfileString("windows", "Device", DeviceLine)

        'Cause all applications to reload the INI file
        'Call SendMessage(HWND_BROADCAST, WM_WININICHANGE, 0, "windows")

    End Sub

    Public Sub updateImageStatus(ByVal id As Integer)
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "UPDATE tOrderItem SET uPrinted=1 WHERE uOrderItem=" & id
        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            closeConnection()
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while updating the image status. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Public Sub updateOrderStatus(ByVal id As Integer)
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "UPDATE tOrder SET orders_status=3 WHERE orders_id=" & id
        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            closeConnection()
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while updating the order status. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Public Function fixDownloadPath(ByRef path As String)
        Dim fixedPath As String
        fixedPath = path
        path = fixedPath.Replace(".jpg", "-highres.jpg")
        Return path
    End Function

    Public Function fixDestinationPath(ByRef path As String)
        Dim fixedPath As String
        fixedPath = path
        path = fixedPath.Replace("upload/", "downloadedImages/")
        Return path
    End Function

    Public Function getFileName(ByVal path As String)
        Dim fileName As String
        fileName = path.Substring(path.LastIndexOf("/") + 1)
        Return fileName
    End Function

    Public Function downloadImage(ByVal URL As String, ByVal destination As String) As Boolean
        On Error GoTo downloadError
        My.Computer.Network.DownloadFile(URL, destination)
        downloadImage = True
downloadError:
        downloadImage = False
    End Function

    Public Function getPrinter(ByVal tipo As String)
        Dim printerName As String
        Dim printerID As Integer
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "SELECT uPrinter FROM tPrinterConfig WHERE uType=" & tipo

        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            printerID = myCommand.ExecuteScalar

            SQLOrders = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            printerName = myCommand.ExecuteScalar

            closeConnection()

            Return printerName
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while retrieving the printer name. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
            Return False
        End Try
    End Function

    Public Function imageListIsEmpty() As Boolean
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "SELECT COUNT(*) FROM tOrderItem WHERE uPrinted <> 1 AND uOrder=" & selectedOrder

        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders

            Dim t As Integer = CInt(myCommand.ExecuteScalar)
            If t = 0 Then
                Return True
            Else
                Return False
            End If
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while updating the order status. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
            Return False
        End Try

    End Function

    Public Function checkIfPrinterListIsEmpty()
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "SELECT * FROM tPrinterConfig" ' --> "SELECT * FROM tPrinter WHERE uPC=" & computerID
        Try
            openConnection()
            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders

            Dim t As Integer = CInt(myCommand.ExecuteScalar())

            If t = 0 Then
                'It's empty
                Return True
            Else
                'Has records
                Return False
            End If
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while reading the printers names. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
            Return False
        End Try
    End Function
End Module
