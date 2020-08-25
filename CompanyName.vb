Imports System.Data.SQLite
Public Class Company_Name
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click





        Try
            connect()

            Dim cmd As New SQLiteCommand
            If GunaTextBox1.Text = "" Then
                MsgBox("Please Enter the company name", MessageBoxIcon.Exclamation, "error")
                GunaTextBox1.Focus()
                Exit Sub
            End If
            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to save this as the company name?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                cmd.Connection = connection

                cmd.CommandText = " Insert into companyname (CompanyName) Values(@cn)"
                cmd.Parameters.Add(New SQLiteParameter("@cn", GunaTextBox1.Text))


                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("The Company's Name has been Submited successfully, Restart the App to display the name")
            End If
        Catch ex As Exception
            MsgBox("Oops!! An Error has occured")
        End Try
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        connect()
        Try
            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Change the Company Name?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                Dim cmd As New SQLiteCommand
                cmd.Connection = connection

                cmd.CommandText = "update companyname set CompanyName = @cn"
                cmd.Parameters.Add(New SQLiteParameter("@cn", GunaTextBox1.Text))

                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("The Company's Name has been Updated successfully, Restart the App to display the name")
            End If
        Catch ex As Exception
            MsgBox("Oops!! An Error has occured")

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Enter Company Name" Then
            GunaButton1.Show()

        Else
            GunaButton2.Show()
            GunaButton1.Visible = False


        End If
    End Sub


End Class