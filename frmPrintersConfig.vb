Imports System
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class frmPrintersConfig
    Private tableIsEmpty As Boolean

    Private Sub getPrintersList()
        Dim pd As New PrintDocument
        Dim Impresoras As String

        ' Default printer      
        Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

        ' recorre las impresoras instaladas  
        For Each Impresoras In PrinterSettings.InstalledPrinters
            cbBanderines.Items.Add(Impresoras.ToString)
            cbBanners.Items.Add(Impresoras.ToString)
            cbBomboneras.Items.Add(Impresoras.ToString)
            cbBultos.Items.Add(Impresoras.ToString)
            cbCalendarios.Items.Add(Impresoras.ToString)
            cbChapas.Items.Add(Impresoras.ToString)
            cbChocolates.Items.Add(Impresoras.ToString)
            cbEtiquetas.Items.Add(Impresoras.ToString)
            cbGorros.Items.Add(Impresoras.ToString)
            cbHieleras.Items.Add(Impresoras.ToString)
            cbInvitaciones.Items.Add(Impresoras.ToString)
            cbLlaveros.Items.Add(Impresoras.ToString)
            cbMarcadores.Items.Add(Impresoras.ToString)
            cbMousePads.Items.Add(Impresoras.ToString)
            cbPaletas.Items.Add(Impresoras.ToString)
            cbPinatas.Items.Add(Impresoras.ToString)
            cbPlatos.Items.Add(Impresoras.ToString)
            cbPosters.Items.Add(Impresoras.ToString)
            cbRelojes.Items.Add(Impresoras.ToString)
            cbTarjetas.Items.Add(Impresoras.ToString)
            cbTazas.Items.Add(Impresoras.ToString)
            cbTshirts.Items.Add(Impresoras.ToString)
            cbVelas.Items.Add(Impresoras.ToString)
        Next
    End Sub

    Private Sub readPrintersNames()
        Try
            openConnection()

            Dim myCommand As New MySqlCommand
            Dim printerName As String
            Dim printerID As Integer

            myCommand.Connection = DBCon

            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=1"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbBanners.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=2"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbBultos.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=3"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbCalendarios.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=4"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbChapas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=5"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbEtiquetas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=6"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbHieleras.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=7"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbInvitaciones.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=8"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbLlaveros.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=9"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbMarcadores.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=10"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbMousePads.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=11"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbPlatos.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=12"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbPosters.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=13"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbTarjetas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=14"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbTazas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=15"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbTshirts.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=16"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbVelas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=17"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbBanderines.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=18"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbBomboneras.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=19"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbChocolates.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=20"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbGorros.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=21"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbPaletas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=22"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbPinatas.SelectedItem = printerName
            myCommand.CommandText = "SELECT uPrinter FROM tPrinterConfig WHERE uType=23"
            printerID = myCommand.ExecuteScalar
            myCommand.CommandText = "SELECT cLabel FROM tPrinter WHERE uPrinter=" & printerID
            printerName = myCommand.ExecuteScalar
            cbRelojes.SelectedItem = printerName
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while reading the printers names. " & exError.Number & " – " & exError.Message)
        End Try
    End Sub

    Private Sub addPrintersToTable()
        Dim pd As New PrintDocument
        Dim Impresoras As String
        Dim SQLOrders As String
        Dim myCommand As New MySqlCommand

        Try
            openConnection()

            myCommand.Connection = DBCon

            ' Default printer      
            Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

            ' recorre las impresoras instaladas  
            For Each Impresoras In PrinterSettings.InstalledPrinters
                SQLOrders = "INSERT INTO tPrinter (cLabel) VALUES ('" & Impresoras.ToString & "')"
                myCommand.CommandText = SQLOrders
                myCommand.ExecuteNonQuery()
            Next

            closeConnection()
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while inserting items to the database. " & exError.Number & " – " & exError.Message)
        End Try
    End Sub

    Private Sub addElementsToTable()
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String

        SQLOrders = "INSERT INTO tPrinterConfig (uType, uPrinter) VALUES " _
                    & "(1," & printerId(cbBanners.SelectedItem) & "), " _
                    & "(2," & printerId(cbBultos.SelectedItem) & "), " _
                    & "(3," & printerId(cbCalendarios.SelectedItem) & "), " _
                    & "(4," & printerId(cbChapas.SelectedItem) & "), " _
                    & "(5," & printerId(cbEtiquetas.SelectedItem) & "), " _
                    & "(6," & printerId(cbHieleras.SelectedItem) & "), " _
                    & "(7," & printerId(cbInvitaciones.SelectedItem) & "), " _
                    & "(8," & printerId(cbLlaveros.SelectedItem) & "), " _
                    & "(9," & printerId(cbMarcadores.SelectedItem) & "), " _
                    & "(10," & printerId(cbMousePads.SelectedItem) & "), " _
                    & "(11," & printerId(cbPlatos.SelectedItem) & "), " _
                    & "(12," & printerId(cbPosters.SelectedItem) & "), " _
                    & "(13," & printerId(cbTarjetas.SelectedItem) & "), " _
                    & "(14," & printerId(cbTazas.SelectedItem) & "), " _
                    & "(15," & printerId(cbTshirts.SelectedItem) & "), " _
                    & "(16," & printerId(cbVelas.SelectedItem) & "), " _
                    & "(17," & printerId(cbBanderines.SelectedItem) & "), " _
                    & "(18," & printerId(cbBomboneras.SelectedItem) & "), " _
                    & "(19," & printerId(cbChocolates.SelectedItem) & "), " _
                    & "(20," & printerId(cbGorros.SelectedItem) & "), " _
                    & "(21," & printerId(cbPaletas.SelectedItem) & "), " _
                    & "(22," & printerId(cbPinatas.SelectedItem) & "), " _
                    & "(23," & printerId(cbRelojes.SelectedItem) & ");"
        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            closeConnection()
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while reading the printers names. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Private Sub editElementsFromTable()
        Dim myCommand As New MySqlCommand
        Dim SQLOrders As String
        SQLOrders = ""
        Try
            openConnection()
            myCommand.Connection = DBCon

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbBanners.SelectedItem) _
                        & " WHERE uType=1"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbBultos.SelectedItem) _
                        & " WHERE uType=2"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbCalendarios.SelectedItem) _
                        & " WHERE uType=3"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbChapas.SelectedItem) _
                        & " WHERE uType=4"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbEtiquetas.SelectedItem) _
                        & " WHERE uType=5"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbHieleras.SelectedItem) _
                        & " WHERE uType=6"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbInvitaciones.SelectedItem) _
                        & " WHERE uType=7"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbLlaveros.SelectedItem) _
                        & " WHERE uType=8"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                        & "uPrinter=" & printerId(cbMarcadores.SelectedItem) _
                        & " WHERE uType=9"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbMousePads.SelectedItem) _
                & " WHERE uType=10"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbPlatos.SelectedItem) _
                & " WHERE uType=11"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbPosters.SelectedItem) _
                & " WHERE uType=12"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbTarjetas.SelectedItem) _
                & " WHERE uType=13"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbTazas.SelectedItem) _
                & " WHERE uType=14"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbTshirts.SelectedItem) _
                & " WHERE uType=15"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbVelas.SelectedItem) _
                & " WHERE uType=16"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbBanderines.SelectedItem) _
                & " WHERE uType=17"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbBomboneras.SelectedItem) _
                & " WHERE uType=18"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbChocolates.SelectedItem) _
                & " WHERE uType=19"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbGorros.SelectedItem) _
                & " WHERE uType=20"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbPaletas.SelectedItem) _
                & " WHERE uType=21"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbPinatas.SelectedItem) _
                & " WHERE uType=22"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            SQLOrders = "UPDATE tPrinterConfig SET " _
                & "uPrinter=" & printerId(cbRelojes.SelectedItem) _
                & " WHERE uType=23"
            myCommand.CommandText = SQLOrders
            myCommand.ExecuteNonQuery()

            closeConnection()
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while reading the printers names. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try

    End Sub

    Private Function printerId(ByVal printerName As String) As Integer
        Dim id As Integer
        Dim SQLOrders As String
        Dim myCommand As New MySqlCommand

        SQLOrders = "SELECT uPrinter FROM tPrinter WHERE cLabel='" & printerName & "'" ' & " AND uPC=" & (computerID).toString
        Try
            openConnection()
            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            id = CInt(myCommand.ExecuteScalar())
            Return id
        Catch exError As MySqlException
            MessageBox.Show("An error occurred while reading the printers names. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
            Return False
        End Try
    End Function



    Private Function checkComboBox()
        If cbBanderines.SelectedIndex = -1 Or cbBanners.SelectedIndex = -1 Or cbBomboneras.SelectedIndex = -1 Or
            cbBultos.SelectedIndex = -1 Or cbCalendarios.SelectedIndex = -1 Or cbChapas.SelectedIndex = -1 Or
            cbChocolates.SelectedIndex = -1 Or cbEtiquetas.SelectedIndex = -1 Or cbGorros.SelectedIndex = -1 Or
            cbHieleras.SelectedIndex = -1 Or cbInvitaciones.SelectedIndex = -1 Or cbLlaveros.SelectedIndex = -1 Or
            cbMarcadores.SelectedIndex = -1 Or cbMousePads.SelectedIndex = -1 Or cbPaletas.SelectedIndex = -1 Or
            cbPinatas.SelectedIndex = -1 Or cbPlatos.SelectedIndex = -1 Or cbPosters.SelectedIndex = -1 Or
            cbRelojes.SelectedIndex = -1 Or cbTarjetas.SelectedIndex = -1 Or cbTazas.SelectedIndex = -1 Or
            cbTshirts.SelectedIndex = -1 Or cbVelas.SelectedIndex = -1 Then
            'Then clause
            MsgBox("You must select a valid Printer for each image type.", MsgBoxStyle.Exclamation, "Error")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub frmPrintersConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tableIsEmpty = checkIfPrinterListIsEmpty()
        getPrintersList()
        If tableIsEmpty = False Then
            readPrintersNames()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If checkComboBox() Then
            If tableIsEmpty Then
                addPrintersToTable()
                addElementsToTable()
                Me.Close()
            Else
                editElementsFromTable()
                Me.Close()
            End If
        End If
    End Sub
End Class