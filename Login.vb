Imports System.Data.SQLite
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        connect()
        Dim adapter As New SQLiteDataAdapter()
        Dim table As New DataTable()
        Dim command As New SQLiteCommand("SELECT  Username, Password FROM `usertable` WHERE `Username` = @usn AND `Password` = @pass", connection)


        command.Parameters.Add("@usn", SqlDbType.VarChar).Value = GunaTextBoxusn.Text
        command.Parameters.Add("@pass", SqlDbType.VarChar).Value = GunaTextBoxpsw.Text

        If GunaTextBoxusn.Text.Trim() = "" Or GunaTextBoxusn.Text.Trim().ToLower() = "username" Then
            MessageBox.Show("Please Enter your Username to continue", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            GunaTextBoxusn.Focus()


        Else
            adapter.SelectCommand = command
            adapter.Fill(table)
            If table.Rows.Count > 0 Then

                Dim result As DialogResult = MessageBox.Show("WELCOME MY ON BOARD!!! YOU CAN NOW PROCEED", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                If result = DialogResult.Cancel Then

                Else
                    Me.Hide()
                    MessageBox.Show("Thanks for using our App!  We encourage You to be couscious when entering any value to avoid vatal error.  CLICK 'OK' TO CONTINUE.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ACCOUNT_MANAGER.Show()
                End If

            Else
                MessageBox.Show("Incorrect Username or Password please enter the correct data to continues", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            End If

        End If

    End Sub

    Private Sub GunaTextBoxusn_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxusn.Enter
        GunaTextBoxusn.Text = ""
    End Sub

    Private Sub GunaTextBoxusn_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxusn.Leave
        If GunaTextBoxusn.Text = "" Then
            GunaTextBoxusn.Text = "Username"
        End If
    End Sub

    Private Sub GunaTextBoxpsw_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxpsw.Enter
        GunaTextBoxpsw.Text = ""
    End Sub

    Private Sub GunaTextBoxpsw_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxpsw.Leave
        If GunaTextBoxpsw.Text = "" Then
            GunaTextBoxpsw.Text = "Password"
        End If
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        GunaTextBoxusn.Text = "Username"
        GunaTextBoxpsw.Text = "Password"
    End Sub
End Class