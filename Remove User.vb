Imports System.Data.SQLite
Public Class Remove_User
    Private Sub GunaContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Try
            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Remove this User?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                connect()
                Dim cmd As New SQLiteCommand
                cmd.Connection = connection
                cmd.CommandText = "Delete from usertable  where Username = @id"
                cmd.Parameters.AddWithValue("@id", GunaTextBoxrem.Text)
                Dim msg As Integer = cmd.ExecuteNonQuery()
                MsgBox(msg & "User was Removed successfully")
                connection.Close()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class