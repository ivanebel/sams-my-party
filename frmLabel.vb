Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.IO

Public Class frmLabel
    Private deliveryName As String
    Private deliveryAddress As String
    Private deliveryCity As String
    Private deliveryZip As String
    Private deliveryState As String
    Private deliveryCountry As String
    Private deliveryCompany As String
    Public uOrderID As String
    Private PrintDialog1 As New PrintDialog
    Private WithEvents m_PrintDocument As PrintDocument
    Private Const HWND_BROADCAST As Long = &HFFFF&
    Private Const WM_WININICHANGE As Long = &H1A

    Private Declare Function WriteProfileString Lib "kernel32" Alias "WriteProfileStringA" _
    (ByVal lpszSection As String, ByVal lpszKeyName As String, _
    ByVal lpszString As String) As Long

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
         (ByVal hwnd As Long, ByVal wMsg As Long, _
         ByVal wParam As Long, ByVal lparam As String) As Long

    Public Sub getInformation()
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "SELECT delivery_name FROM tOrder WHERE orders_id=" & selectedOrder.ToString

        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            deliveryName = myCommand.ExecuteScalar
            SQLOrders = "SELECT delivery_company FROM tOrder WHERE orders_id=" & selectedOrder.ToString
            myCommand.CommandText = SQLOrders
            deliveryCompany = myCommand.ExecuteScalar
            SQLOrders = "SELECT delivery_street_address FROM tOrder WHERE orders_id=" & selectedOrder.ToString
            myCommand.CommandText = SQLOrders
            deliveryAddress = myCommand.ExecuteScalar
            SQLOrders = "SELECT delivery_city FROM tOrder WHERE orders_id=" & selectedOrder.ToString
            myCommand.CommandText = SQLOrders
            deliveryCity = myCommand.ExecuteScalar
            SQLOrders = "SELECT delivery_postcode FROM tOrder WHERE orders_id=" & selectedOrder.ToString
            myCommand.CommandText = SQLOrders
            deliveryZip = myCommand.ExecuteScalar
            SQLOrders = "SELECT delivery_state FROM tOrder WHERE orders_id=" & selectedOrder.ToString
            myCommand.CommandText = SQLOrders
            deliveryState = myCommand.ExecuteScalar
            SQLOrders = "SELECT delivery_country FROM tOrder WHERE orders_id=" & selectedOrder.ToString
            myCommand.CommandText = SQLOrders
            deliveryCountry = myCommand.ExecuteScalar

            closeConnection()
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while getting the delivery information. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Public Sub fillInformation()
        lblAddress.Text = deliveryAddress
        lblName.Text = deliveryName
        lblCity.Text = deliveryCity
        lblCompany.Text = deliveryCompany
        lblState.Text = deliveryState
        lblZip.Text = deliveryZip
        lblCountry.Text = deliveryCountry
    End Sub

    Private Function barcodeURL(ByVal id As Integer) As String
        barcodeURL = "http://www.barcodesinc.com/generator/image.php?code=" & id & "&style=197&type=C128B&width=200&height=75&xres=1&font=3"
        barCodeBox.ImageLocation = barcodeURL
    End Function

    Private Sub frmLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        barcodeURL(selectedOrder)
        getInformation()
        fillInformation()
        Label7.Visible = True
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

        m_PrintDocument = New PrintDocument

        Try
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Label7.Visible = False
                PrintForm1.Print()
            End If
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR printing the label: " & vbCrLf & _
                        ex.Message, "Error", MessageBoxButtons.OK, _
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class