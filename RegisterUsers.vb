Imports System.Data.SQLite
Public Class RegisterUsers
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        connect()
        Try
            If GunaTextBoxname.Text = "" Then
                MsgBox("Please Enter the name of the user ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxname.Focus()
                Exit Sub
            End If

            If GunaComboBoxsex.Text = "" Then
                MsgBox("Please Enter choose the sex of the user", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxsex.Focus()
                Exit Sub
            End If

            If GunaTextBoxdesg.Text = "" Then
                MsgBox("Please Enter the user's designation", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdesg.Focus()
                Exit Sub
            End If



            If GunaTextBoxusername.Text = "" Then
                MsgBox("Please Enter Username for the user", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxusername.Focus()
                Exit Sub
            End If
            If GunaTextBoxpassword.Text = "" Then
                MsgBox("Please Enter password for this account", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxpassword.Focus()
                Exit Sub
            End If


            Dim cmd As New SQLiteCommand
            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to creat this account?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else



                cmd.Connection = connection

                cmd.CommandText = " Insert into usertable (Name, Sex,Designation,Username,Password) Values(@nm, @sx,@dg,@usn,@psw)"
                cmd.Parameters.Add(New SQLiteParameter("@nm", GunaTextBoxname.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sx", GunaComboBoxsex.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dg", GunaTextBoxdesg.Text))
                cmd.Parameters.Add(New SQLiteParameter("@usn", GunaTextBoxusername.Text))
                cmd.Parameters.Add(New SQLiteParameter("@psw", GunaTextBoxpassword.Text))

                ' cmd.Parameters.Ad

                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Account Created successfully")

            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please Try again")
        End Try

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        GunaTextBoxname.Text = "Name"
        GunaComboBoxsex.Text = "Sex"
        GunaTextBoxdesg.Text = "Designation"
        GunaTextBoxusername.Text = "Username"
        GunaTextBoxpassword.Text = "Password"
    End Sub

    Private Sub GunaTextBoxname_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxname.Enter


        GunaTextBoxname.Text = ""
    End Sub

    Private Sub GunaTextBoxdesg_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxdesg.Enter
        GunaTextBoxdesg.Text = ""
    End Sub

    Private Sub GunaTextBoxusername_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxusername.Enter
        GunaTextBoxusername.Text = ""
    End Sub

    Private Sub GunaTextBoxpassword_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxpassword.Enter
        GunaTextBoxpassword.Text = ""
    End Sub
End Class