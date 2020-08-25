Imports System.Data.SQLite
Public Class stare

    Dim value As Integer = 50






    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If value = 600 Then
            Timer1.Stop()

            Login.Show()
            Me.Hide()

        Else
            value += 5

        End If

        If value = 100 Then
            GunaTransfarantPictureBox1.Show()
        ElseIf value = 200 Then
            GunaTransfarantPictureBox1.Hide()
            GunaTransfarantPictureBox2.Visible = True
        ElseIf value = 300 Then
            GunaTransfarantPictureBox1.Hide()
            GunaTransfarantPictureBox2.Hide()
            GunaTransfarantPictureBox3.Show()
        ElseIf value = 400 Then
            GunaTransfarantPictureBox1.Hide()
            GunaTransfarantPictureBox2.Hide()
            GunaTransfarantPictureBox3.Hide()
            GunaTransfarantPictureBox4.Show()

        ElseIf value = 500 Then
            GunaTransfarantPictureBox1.Hide()
            GunaTransfarantPictureBox2.Hide()
            GunaTransfarantPictureBox3.Hide()
            GunaTransfarantPictureBox4.Show()

            GunaTransfarantPictureBox1.Show()



        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult
        Timer1.Stop()


        result = MessageBox.Show("Are you Sure you want to Exit this Program?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
            Timer1.Start()

        Else
            Application.Exit()
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaTransfarantPictureBox2_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox2.Click

    End Sub

    Private Sub stare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class