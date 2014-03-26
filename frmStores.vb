Imports MySql.Data.MySqlClient
Imports System.Xml

Public Class frmStores

    Private Sub fillStoresTable()
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQLOrders As String

        SQLOrders = "SELECT uStore,cName,cIP FROM tStore"

        Try
            openConnection()

            myCommand.Connection = DBCon
            myCommand.CommandText = SQLOrders
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            dgvStores.DataSource = myData
            dgvStores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            btnNext.Enabled = False

            storeID = dgvStores.CurrentCell.Value
            btnNext.Enabled = True
            lblSelectedStore.Text = "Selected ID: " & (dgvStores.CurrentCell.Value).ToString

            closeConnection()

        Catch exError As MySqlException
            MessageBox.Show("An Error Occurred. " & exError.Number & " – " & exError.Message & " - " & SQLOrders)
        End Try
    End Sub

    Private Sub frmStores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillStoresTable()
    End Sub

    Private Sub dgvStores_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStores.RowHeaderMouseClick
        storeID = dgvStores.CurrentCell.Value
        btnNext.Enabled = True
        lblSelectedStore.Text = "Selected Store ID: " & (dgvStores.CurrentCell.Value).ToString
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If storeID >= 1 Then
            frmOrders.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        frmLogin.Show()
        Me.Close()
    End Sub
End Class