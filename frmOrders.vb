Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.IO

Public Class frmOrders
    Private prtSettings As PrinterSettings
    Public imageTypeID As Integer
    Public selectedImageID As Integer
    Public printerListEmpty As Boolean
    Private WithEvents m_PrintDocuments As PrintDocument

    Private Sub fillOrdersTable()
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQLOrders As String

        SQLOrders = "SELECT orders_id,customers_name,date_purchased,orders_status FROM tOrder WHERE uStore=" & (storeID).ToString & " AND orders_status= 2"

        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            dgvOrders.DataSource = myData
            dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Catch exError As MySqlException
            MessageBox.Show("An error occurred while filling the stores table. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Private Sub getImagesAssociatedToSelectedOrder()
        Dim SQLOrders As String
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable

        SQLOrders = "SELECT cImage FROM tOrderItem WHERE uOrder=" & (selectedOrder).ToString & " AND uPrinted <> 1"

        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            dgvImages.DataSource = myData
            dgvImages.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Catch exError As MySqlException
            MessageBox.Show("An error occurred while retrieving the store name. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Private Sub getImageTypeAndID()
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String
        Dim SQLImageID As String

        originalImagePath = dgvImages.CurrentCell.Value

        SQLOrders = "SELECT uType FROM tOrderItem WHERE cImage= '" & originalImagePath & "'"
        SQLImageID = "SELECT uOrderItem FROM tOrderItem WHERE cImage= '" & originalImagePath & "'"

        Try
            openConnection()
            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders

            'Guarda en la var imageTypeID el tipo de la imagen seleccionada.
            imageTypeID = myCommand.ExecuteScalar

            'Guarda el ID de la imagen seleccionada en selectedImageID
            myCommand.CommandText = SQLImageID
            selectedImageID = CInt(myCommand.ExecuteScalar)

        Catch exError As MySqlException
            MessageBox.Show("An Error Occurred. " & exError.Number & " – " & exError.Message & -" - " & SQLOrders)
        End Try
    End Sub

    Private Function getStoreName()
        Dim myCommand As New MySqlCommand
        Dim nombreStore As String
        Dim SQLOrders As String

        SQLOrders = "SELECT cName FROM tStore WHERE uStore=" & (storeID).ToString

        Try
            openConnection()
            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            nombreStore = myCommand.ExecuteScalar

            closeConnection()

            Return nombreStore

        Catch exError As MySqlException
            MessageBox.Show("An error occurred while retrieving the store name. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
            Return False
        End Try

    End Function

    Private Sub frmOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        createDownloadFolder()
        fillOrdersTable()
        printerListEmpty = checkIfPrinterListIsEmpty()
        grpBox.Text = "Store ID: " & (storeID).ToString & " - " & getStoreName()
        btnPrintLabel.Enabled = True

        'Inicializa el timer para que haga update cada un minuto
        tmrUpdate.Enabled = True
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings

        If printerListEmpty = True Then
            lblPrinterConfig.Text = "The printers configuration is empty. This is required to continue."
            btnPrinterConfig.Focus()
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        frmStores.Show()
        Me.Close()
    End Sub

    Private Sub dgvOrders_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOrders.RowHeaderMouseClick
        selectedOrder = dgvOrders.CurrentCell.Value
        getImagesAssociatedToSelectedOrder()

        downloadPath = ""
        destinationPath = ""
        btnPreview.Enabled = False
        btnPrint.Enabled = False
        btnPrintLabel.Enabled = True
        dgvImages.ClearSelection()

        frmLabel.uOrderID = (selectedOrder).ToString

        lblSelectedOrder.Text = "Selected Order: #" & (selectedOrder).ToString
    End Sub

    Private Sub dgvImages_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvImages.RowHeaderMouseClick
        getImageTypeAndID()

        downloadPath = My.Settings.ServerIP & fixDownloadPath(originalImagePath)
        'downloadPath --> "http://192.168.84.100/" & "orders/imagename-highres.jpg"

        destinationPath = downloadedImagesFolder & "\" & getFileName(downloadPath)
        'destinationPath = "C:\MyParty\DownloadedImages" & "\" & "imagename-highres.jpg"

        btnPreview.Enabled = True
        If printerListEmpty = True Then
            btnPrint.Enabled = False
        Else
            btnPrint.Enabled = True
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim impresora As String
        Dim PrintDialog1 As New PrintDialog()

        impresora = getPrinter(imageTypeID)

        prtSettings = New PrinterSettings

        downloadImage(downloadPath, destinationPath)

        m_PrintDocument = New PrintDocument

        SetDefaultPrinter(impresora, "", "")

        PrintDialog1.Document = m_PrintDocument
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            m_PrintDocument.Print()
            updateImageStatus(selectedImageID)
            getImagesAssociatedToSelectedOrder()
            dgvImages.ClearSelection()
        End If

        If imageListIsEmpty() = True Then
            updateOrderStatus(selectedOrder)
            dgvOrders.ClearSelection()
            selectedOrder = 0
            lblSelectedOrder.Text = "Selected Order: #"
        End If

        fillOrdersTable()

        'Limpio variables y refresh
        downloadPath = ""
        destinationPath = ""
        selectedImageID = 0
    End Sub

    Private Sub btnPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLabel.Click
        frmLabel.ShowDialog()
    End Sub

    '---- ToolTips ----

    'Private Sub dgvImages_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvImages.MouseHover
    '    ToolTip1.Show("Click on the left arrow of the desired row to select an image to print", dgvImages)
    'End Sub

    'Private Sub btnRefresh_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.MouseHover
    '    ToolTip1.Show("Refreshes the Orders list", dgvOrders)
    'End Sub

    'Private Sub btnPreview_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.MouseHover
    '    ToolTip1.Show("Shows a preview of the selected image", btnPreview)
    'End Sub

    'Private Sub btnPrint_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.MouseHover
    '    ToolTip1.Show("Prints the selected image", btnPrint)
    'End Sub

    'Private Sub btnPrintLabel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintLabel.MouseHover
    '    ToolTip1.Show("Shows a popup window with information of the actual store", btnPrintLabel)
    'End Sub


End Class