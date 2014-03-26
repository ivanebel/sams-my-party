Imports MySql.Data.MySqlClient

Public Class frmLogin

    Private Function userExists(ByVal user As String, ByVal pass As String) As Boolean
        Dim bConnectionSuccessful As Boolean = True

        Try
            openConnection()

            Dim sel As New System.Text.StringBuilder
            sel.Append("SELECT COUNT(*) FROM tUser WHERE cLogin = ?user AND cPasswd = MD5(?password)")

            Dim cmd As New MySqlCommand(sel.ToString, DBCon)
            cmd.Parameters.Add("?user", MySqlDbType.VarChar)
            cmd.Parameters.Add("?password", MySqlDbType.VarChar)
            cmd.Parameters("?user").Value = user
            cmd.Parameters("?password").Value = pass

            Dim t As Integer = CInt(cmd.ExecuteScalar())

            closeConnection()

            If t = 0 Then
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR while connecting to the database: " & vbCrLf & _
                        ex.Message, "Check username", MessageBoxButtons.OK, _
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            bConnectionSuccessful = False
            Return False

        Finally
            If bConnectionSuccessful = False Then
                loggedUser = txtUser.Text
            End If
        End Try

        Return True
    End Function

    Private Sub login()
        If txtPassword.Text = "" Or txtUser.Text = "" Then
            MsgBox("You need to fill in all the user information", MsgBoxStyle.OkOnly, "Error")
        Else
            If userExists(Me.txtUser.Text, Me.txtPassword.Text) Then
                loggedUser = txtUser.Text
                frmStores.Show()
            End If
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        login()
        Me.Hide()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            login()
            Me.Hide()
        End If
    End Sub

    Private Sub btnLogin_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseHover
        ToolTip1.Show("Click to Login", btnLogin)
    End Sub

    Private Sub txtUser_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUser.MouseHover
        ToolTip1.Show("Insert the Username provided", txtUser)
    End Sub

    Private Sub txtPassword_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.MouseHover
        ToolTip1.Show("Insert the password", txtPassword)
    End Sub
End Class
