Imports System.Data.SQLite
Imports System.IO
Imports System.Drawing.Imaging

Public Class PAYROLLGER
    Private Sub GunaTextBox9_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxAllow.KeyUp

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Buttoncal.Click
        Try


            Dim gross As Double
            Dim basic As Double = Val(GunaTextBoxb.Text)
            Dim allow As Double = Val(GunaTextBoxAllow.Text)
            Dim net As Double

            'gross pay

            gross = basic + allow

            GunaLabelGross.Text = System.Convert.ToString(gross)
            GunaLabelGross.Text = gross.ToString("")

            'net pay

            Dim tax As Double = CDbl(GunaTextBoxtax.Text)
            Dim gp As Double = CDbl(GunaLabelGross.Text)
            net = gp - tax
            GunaLabelnet.Text = System.Convert.ToString(net)
            GunaLabelnet.Text = net.ToString("")




        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaTextBoxperc_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxperc.KeyUp
        'tax
        Dim perc As Double = Val(GunaTextBoxperc.Text)
        Dim tax As Double
        Dim basic As Double = Val(GunaTextBoxb.Text)

        tax = basic * perc / 100
        GunaTextBoxtax.Text = System.Convert.ToString(tax)
        GunaTextBoxtax.Text = tax.ToString("")

    End Sub

    Private Sub GunaTextBoxperc_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxperc.Enter
        GunaTextBoxperc.Text = ""
    End Sub

    Private Sub GunaTextBoxperc_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxperc.Leave
        If GunaTextBoxperc.Text = "" Then
            GunaTextBoxperc.Text = "Only % no e.g 2"
        Else



        End If
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        Labelstffid.Text = ""
        GunaTextBoxsn.Text = ""
        GunaTextBoxonm.Text = ""
        GunaTextBoxqtn.Text = ""
        GunaTextBoxlvl.Text = ""
        GunaTextBoxdesgn.Text = ""
        GunaTextBoxb.Text = ""
        GunaTextBoxAllow.Text = ""
        GunaTextBoxperc.Text = "Only % no e.g 2"
        GunaTextBoxtax.Text = ""
        GunaLabelGross.Text = ""
        GunaLabelnet.Text = ""
        GunaPictureBoxpass.Image = Nothing




    End Sub

    Private Sub ComboBoxalt_Enter(sender As Object, e As EventArgs) Handles ComboBoxalt.Enter
        ComboBoxalt.Text = ""
    End Sub

    Private Sub ComboBoxalt_Leave(sender As Object, e As EventArgs) Handles ComboBoxalt.Leave
        If ComboBoxalt.Text = "" Then
            ComboBoxalt.Text = "Search , Update or Del Staff By"
        Else



        End If
    End Sub

    Private Sub GunaTextBoxsearc_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxsearc.Enter
        GunaTextBoxsearc.Text = ""
    End Sub

    Private Sub GunaTextBoxsearc_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxsearc.Leave
        If GunaTextBoxsearc.Text = "" Then
            GunaTextBoxsearc.Text = "Type Staff Name of Id"
        Else



        End If
    End Sub

    Private Sub GunaTextBoxupddel_Enter(sender As Object, e As EventArgs)
        ' GunaTextBoxupddel.Text = ""
    End Sub

    Private Sub GunaTextBoxupddel_Leave(sender As Object, e As EventArgs)
        'If GunaTextBoxupddel.Text = "" Then
        'GunaTextBoxupddel.Text = "Type Staff Name to Update or Del"
        ' Else



        ' End If
    End Sub

    Private Sub PAYROLLGER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaDateTimePicker1.Value = DateTime.Now
        showData()

        'populating the company from the database companyname
        Try
            connect()
            Dim READER As SQLiteDataReader
            Dim cmd As SQLiteCommand = connection.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select CompanyName From companyname"
            READER = cmd.ExecuteReader
            If READER.HasRows Then

                While READER.Read

                    Labelcon.Text = (READER("CompanyName"))

                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception


        End Try
    End Sub
    'to display and load the table data on the datagridview
    Sub showData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from payrolltable2", connection)
        'Dim dt As New DataTablestafftable
        Dim ds As New DataSet
        da.Fill(ds, "payrolltable2")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "payrolltable2"
        connection.Clone()
        da.Dispose()
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Try
            GunaDateTimePicker1.Value = DateTime.Now
            'validating and insertion code
            connect()




            Dim cmd As New SQLiteCommand


            If GunaTextBoxsn.Text = "" Then
                MsgBox("Please Enter the Employee's Surname", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxsn.Focus()
                Exit Sub
            End If


            If GunaTextBoxonm.Text = "" Then
                MsgBox("Please Enter the Employee's Othername", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxonm.Focus()
                Exit Sub
            End If

            If GunaTextBoxqtn.Text = "" Then
                MsgBox("Please Enter the Employee's qualification", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqtn.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxlvl.Text) Then
                MsgBox("Please Enter the Employee's Level", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxlvl.Focus()
                Exit Sub
            End If


            If GunaTextBoxdesgn.Text = "" Then
                MsgBox("Please Make Sure you Entered the Employee's Designation", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdesgn.Focus()
                Exit Sub
            End If
            If GunaTextBoxb.Text = "" Then
                MsgBox("Please Enter the Employee's Basic Salary", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxb.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxb.Text) Then
                MsgBox("Please Check your entry to ensure you entered right datatype, e.g numbers", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxb.Focus()
                Exit Sub
            End If


            If GunaTextBoxAllow.Text = "" Then
                MsgBox("Please Enter the Employee's Total allowance if any if not just put in 0", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAllow.Focus()
                Exit Sub
            End If

            If Not IsNumeric(GunaTextBoxAllow.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAllow.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxperc.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxperc.Focus()
                Exit Sub
            End If

            If GunaTextBoxperc.Text = "" Then
                MsgBox("Please Enter the Tax Rate for the Employee", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxperc.Focus()
                Exit Sub
            End If

            If IsNothing(GunaPictureBoxpass.Image) Then
                MsgBox("Please Upload the Staff Picture", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxperc.Focus()
                Exit Sub
            End If

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else

                'insertion code

                cmd.Connection = connection

                cmd.CommandText = " Insert into payrolltable2 (Surname, OtherName, Qualification,Level,Designation,BasicSalary,TotalAllowance,TaxPercentage,Tax,GrossPay, NetPay, Passport, Date) 
Values(@snm,  @onm, @qual,@lvl,@des, @bs,@all,@perc,@tax,@gros,@net, @pspt, @date)"

                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxpass.Image.Save(ms, GunaPictureBoxpass.Image.RawFormat)  ' collecting picture from picturebox to db

                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxsn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxonm.Text))
                cmd.Parameters.Add(New SQLiteParameter("@qual", GunaTextBoxqtn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@lvl", GunaTextBoxlvl.Text))
                cmd.Parameters.Add(New SQLiteParameter("@des", GunaTextBoxdesgn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@bs", GunaTextBoxb.Text))
                cmd.Parameters.AddWithValue("@all", GunaTextBoxAllow.Text)

                cmd.Parameters.Add(New SQLiteParameter("@perc", GunaTextBoxperc.Text))
                cmd.Parameters.Add(New SQLiteParameter("@tax", GunaTextBoxtax.Text))
                cmd.Parameters.Add(New SQLiteParameter("@gros", GunaLabelGross.Text))
                cmd.Parameters.Add(New SQLiteParameter("@net", GunaLabelnet.Text))
                cmd.Parameters.AddWithValue("@pspt", ms.ToArray) ' inserting picture or image
                cmd.Parameters.Add(New SQLiteParameter("@date", GunaDateTimePicker1.Value.ToShortDateString))



                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Your Record has been Saved Successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please Try again")
        End Try
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click

        'delecting which ever row selected on the datagridview
        Dim head As Integer = DataGridView1.SelectedRows(0).Cells("StaffID").Value

        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to Delete the Records of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
        Else
            connect()
            Dim cmd As New SQLiteCommand
            cmd.Connection = connection
            cmd.CommandText = "Delete from payrolltable2  where StaffID = @id"
            cmd.Parameters.AddWithValue("@id", head)
            Dim msg As Integer = cmd.ExecuteNonQuery()
            MsgBox(msg & "Record is deleted successfully")
            connection.Close()
            showData()
        End If
    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaTransfarantPictureBox5_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox5.Click

    End Sub

    Private Sub GunaTextBoxsearc_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxsearc.KeyUp
        connect()

        If ComboBoxalt.Text = "Staff ID" Then


            cmd = New SQLiteCommand("select * from payrolltable2 where StaffID like '%" + GunaTextBoxsearc.Text + "%'", connection)


            da = New SQLiteDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "payrolltable2")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "payrolltable2"
            cmd.Dispose()
            ds.Dispose()
            connection.Close()

        ElseIf ComboBoxalt.Text = "Staff Name"

            cmd = New SQLiteCommand("select * from payrolltable2 where Surname like '%" + GunaTextBoxsearc.Text + "%'", connection)


            da = New SQLiteDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "payrolltable2")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "payrolltable2"
            cmd.Dispose()
            ds.Dispose()
            connection.Close()

        Else
            MsgBox("Please select your Search Key From the Combobox Above")
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            Dim selectedgr As DataGridViewRow
            selectedgr = DataGridView1.Rows(e.RowIndex)



            'image convertion for display sake

            Dim bytes As [Byte]() = DataGridView1.CurrentRow.Cells(12).Value 'converting image to byte 
                Dim ms As New MemoryStream(bytes)  ' parsing byte into memorystream image dispaly
                GunaPictureBoxpass.Image = Image.FromStream(ms) 'image dispaly onto the picture box




                Labelstffid.Text = selectedgr.Cells(0).Value
                GunaTextBoxsn.Text = selectedgr.Cells(1).Value
                GunaTextBoxonm.Text = selectedgr.Cells(2).Value
                GunaTextBoxqtn.Text = selectedgr.Cells(3).Value
                GunaTextBoxlvl.Text = selectedgr.Cells(4).Value
                GunaTextBoxdesgn.Text = selectedgr.Cells(5).Value
                GunaTextBoxb.Text = selectedgr.Cells(6).Value
                GunaTextBoxAllow.Text = selectedgr.Cells(7).Value


                GunaTextBoxperc.Text = selectedgr.Cells(8).Value
                GunaTextBoxtax.Text = selectedgr.Cells(9).Value
                GunaLabelGross.Text = selectedgr.Cells(10).Value
                GunaLabelnet.Text = selectedgr.Cells(11).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaButton7_Click_1(sender As Object, e As EventArgs) Handles GunaButton7.Click
        Try
            'updating code


            Dim head As Integer = DataGridView1.SelectedRows(0).Cells("StaffID").Value  'To validate onclick selection from gridview 
            connect()



            If GunaTextBoxqtn.Text = "" Then
                MsgBox("Please Enter the Employee's qualification", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqtn.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxlvl.Text) Then
                MsgBox("Please Enter the Employee's Level", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxlvl.Focus()
                Exit Sub
            End If


            If GunaTextBoxdesgn.Text = "" Then
                MsgBox("Please Make Sure you Entered the Employee's Designation", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdesgn.Focus()
                Exit Sub
            End If
            If GunaTextBoxb.Text = "" Then
                MsgBox("Please Enter the Employee's Basic Salary", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxb.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxb.Text) Then
                MsgBox("Please Check your entry to ensure you entered right datatype, e.g numbers", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxb.Focus()
                Exit Sub
            End If


            If GunaTextBoxAllow.Text = "" Then
                MsgBox("Please Enter the Employee's Total allowance if any if not just put in 0", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAllow.Focus()
                Exit Sub
            End If

            If Not IsNumeric(GunaTextBoxAllow.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAllow.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxperc.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxperc.Focus()
                Exit Sub
            End If

            If GunaTextBoxperc.Text = "" Then
                MsgBox("Please Enter the Tax Rate for the Employee", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxperc.Focus()
                Exit Sub
            End If
            Dim cmd As New SQLiteCommand
            cmd.Connection = connection

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Update the payment Record of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                cmd.CommandText = "update payrolltable2 set Qualification=@qual,Level = @lvl, BasicSalary = BasicSalary + @bs ,TotalAllowance=@all,TaxPercentage=@perc,
   Tax = @tax,GrossPay = @gros, NetPay= @net where StaffID = @id"

                cmd.Parameters.AddWithValue("@id", head)
                cmd.Parameters.Add(New SQLiteParameter("@qual", GunaTextBoxqtn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@lvl", GunaTextBoxlvl.Text))
                cmd.Parameters.Add(New SQLiteParameter("@des", GunaTextBoxdesgn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@bs", GunaTextBoxb.Text))
                cmd.Parameters.AddWithValue("@all", GunaTextBoxAllow.Text)

                cmd.Parameters.Add(New SQLiteParameter("@perc", GunaTextBoxperc.Text))
                cmd.Parameters.Add(New SQLiteParameter("@tax", GunaTextBoxtax.Text))
                cmd.Parameters.Add(New SQLiteParameter("@gros", GunaLabelGross.Text))
                cmd.Parameters.Add(New SQLiteParameter("@net", GunaLabelnet.Text))
                Dim msg As Integer = cmd.ExecuteNonQuery()
                MsgBox(msg & "Record is updated successfully")
                connection.Close()
                showData()




            End If
        Catch ex As Exception
            MsgBox("Oops!! An Error has occured Please make sure you  hightlightd the Record Row to be updated")

        End Try
    End Sub

    Private Sub StaffsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffsToolStripMenuItem.Click
        STAFFOGER.GunaButton2.Visible = False
        STAFFOGER.GunaButton7.Visible = True
        STAFFOGER.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        STUDENGER.GunaButton7.Visible = True
        STUDENGER.GunaButton2.Visible = False
        STUDENGER.Show()
    End Sub

    Private Sub ViewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProfileToolStripMenuItem.Click
        STAFFOGER.GunaButton7.Visible = False
        STAFFOGER.GunaButton2.Visible = True
        STAFFOGER.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem.Click
        STAFFOGER.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem1.Click
        Me.Show()
        GunaButton7.Hide()
        GunaButton2.Show()

    End Sub

    Private Sub CreateProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateProfileToolStripMenuItem.Click
        STUDENGER.GunaButton7.Visible = False
        STUDENGER.GunaButton2.Visible = True

        STUDENGER.Show()
    End Sub

    Private Sub ViewProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewProfileToolStripMenuItem1.Click
        STUDENGER.Show()
    End Sub

    Private Sub RecievePaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecievePaymentToolStripMenuItem.Click
        STUDENGER.GunaButton2.Visible = False
        STUDENGER.GunaButton7.Visible = True

        STUDENGER.Show()

    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click


    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click

    End Sub

    Private Sub UpdateProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UpdateProfileToolStripMenuItem1.Click
        STAFFOGER.GunaButton2.Visible = False
        STAFFOGER.GunaButton7.Visible = True
        STAFFOGER.Show()

    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click

        ACCOUNT_MANAGER.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Choose Image (*.JPG;*.PNG; *.GIF)|*.bmp;*.gif;*.jpg"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            GunaPictureBoxpass.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub GunaButtonPIXUPD_Click(sender As Object, e As EventArgs) Handles GunaButtonPIXUPD.Click
        'PICTURE UPDATE
        connect()
        Try

            Dim cmd As New SQLiteCommand
            cmd.Connection = connection

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Update the payment Record of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                cmd.CommandText = "update payrolltable2 set Passport =@pspt where StaffID = @id"
                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxpass.Image.Save(ms, GunaPictureBoxpass.Image.RawFormat)  ' collecting picture from picturebox to db


                cmd.Parameters.AddWithValue("@id", Labelstffid.Text)
                cmd.Parameters.Add(New SQLiteParameter("@pspt", ms.ToArray))

            End If
            Dim msg As Integer = cmd.ExecuteNonQuery()
            MsgBox(msg & "Picture was  updated successfully")
            connection.Close()
            showData()



        Catch ex As Exception
            MsgBox("Oops!! An Error has occured Please make sure you  hightlightd the Record Row to be updated")

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GunaTextBoxqtn_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxqtn.TextChanged

    End Sub

    Private Sub GunaTextBoxlvl_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxlvl.Enter
        GunaTextBoxlvl.Text = ""
    End Sub

    Private Sub GunaTextBoxlvl_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxlvl.Leave
        If GunaTextBoxlvl.Text = "" Then
            GunaTextBoxlvl.Text = "e.g 8"
        End If
    End Sub

    Private Sub GunaTextBoxdesgn_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxdesgn.Enter
        GunaTextBoxdesgn.Text = ""
    End Sub

    Private Sub GunaTextBoxdesgn_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxdesgn.Leave
        If GunaTextBoxdesgn.Text = "" Then
            GunaTextBoxdesgn.Text = "e.g Principal"
        End If

    End Sub

    Private Sub GunaTextBoxqtn_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxqtn.Enter
        GunaTextBoxqtn.Text = ""
    End Sub

    Private Sub GunaTextBoxqtn_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxqtn.Leave
        If GunaTextBoxqtn.Text = "" Then
            GunaTextBoxqtn.Text = "PhD, Hnd, Mst etc"
        End If
    End Sub

    Private Sub UpdatePayRollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePayRollToolStripMenuItem.Click
        GunaButton2.Hide()
        GunaButton7.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to close this Page?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
        Else

            Me.Close()
        End If
    End Sub
End Class