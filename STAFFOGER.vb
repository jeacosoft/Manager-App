
Imports System.Data.SQLite
Imports System.IO
Imports System.Drawing.Imaging
Public Class STAFFOGER
    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Choose Image (*.JPG;*.PNG; *.GIF)|*.bmp;*.gif;*.jpg"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            GunaPictureBoxPASS.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub GunaTextBoxsearch_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxsearch.Enter
        GunaTextBoxsearch.Text = ""
    End Sub

    Private Sub GunaTextBoxsearch_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxsearch.Leave
        If GunaTextBoxsearch.Text = "" Then
            GunaTextBoxsearch.Text = "Search For Staff Profile"

        Else



        End If
    End Sub

    Private Sub GunaTextBoxupdel_Enter(sender As Object, e As EventArgs)

    End Sub



    Private Sub STAFFOGER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = DateTime.Now
        ' GunaDateTimePicker2.Value = DateTime.Now


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

                    Labelconm.Text = (READER("CompanyName"))

                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception


        End Try

    End Sub
    Sub showData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from stafftable", connection)
        'Dim dt As New DataTablestafftable
        Dim ds As New DataSet
        da.Fill(ds, "stafftable")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "stafftable"
        connection.Clone()
        da.Dispose()
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        GunaTextBoxsn.Text = ""
        GunaTextBoxonm.Text = ""
        GunaComboBoxsx.Text = ""
        ' GunaTextBoxDOB.Text = ""
        GunaComboBoxmst.Text = ""
        GunaTextBoxqul.Text = ""
        GunaTextBoxsch.Text = ""
        GunaTextBoxcst.Text = ""
        GunaTextBoxadd.Text = ""
        GunaTextBoxdsgn.Text = ""
        GunaTextBoxtel.Text = ""
        GunaComboBoxmst.Text = ""

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Try

            'validating and insertion code
            connect()


            DateTimePicker1.Value = DateTime.Now


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

            If GunaComboBoxsx.Text = "" Then
                MsgBox("Please Enter the Employee's Gender", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxsx.Focus()
                Exit Sub
            End If


            If GunaComboBoxmst.Text = "" Then
                MsgBox("Please Make Sure you Entered the Employee's Marital Status", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxmst.Focus()
                Exit Sub
            End If
            If GunaTextBoxqul.Text = "" Then
                MsgBox("Please Enter the Employee's Qualification", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqul.Focus()
                Exit Sub
            End If

            If IsNothing(GunaPictureBoxPASS.Image) Then
                MsgBox("Please Upload the Staff Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If

            If GunaTextBoxsch.Text = "" Then
                MsgBox("Please Enter the Institution attended by the Employee", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxsch.Focus()
                Exit Sub
            End If

            If GunaTextBoxcst.Text = "" Then
                MsgBox("Please Enter the Employee's Course of Study ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxcst.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxtel.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxtel.Focus()
                Exit Sub
            End If

            If GunaTextBoxadd.Text = "" Then
                MsgBox("Please Enter the Employee's Address", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxadd.Focus()
                Exit Sub
            End If
            If GunaTextBoxdsgn.Text = "" Then
                MsgBox("Please Enter the Employee's Designation", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdsgn.Focus()
                Exit Sub
            End If

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else

                'insertion code

                cmd.Connection = connection

                cmd.CommandText = " Insert into stafftable (Surname, OtherName,Sex,DOB,MaritalStatus, Qualification,SchoolAttended,CourseOfStudy,Telephone,Address,Designation,Passport, Date) 
Values(@snm,  @onm,@sx, @dob,@mst,@qul, @sch,@cos,@tel,@loc,@desg,@pspt,@date)"

                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxPASS.Image.Save(ms, GunaPictureBoxPASS.Image.RawFormat)  ' collecting picture from picturebox to db

                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxsn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxonm.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sx", GunaComboBoxsx.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dob", GunaDateTimePicker1.Text))
                cmd.Parameters.Add(New SQLiteParameter("@mst", GunaComboBoxmst.Text))
                cmd.Parameters.Add(New SQLiteParameter("@qul", GunaTextBoxqul.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sch", GunaTextBoxsch.Text))
                cmd.Parameters.AddWithValue("@cos", GunaTextBoxcst.Text)

                cmd.Parameters.Add(New SQLiteParameter("@tel", GunaTextBoxtel.Text))
                cmd.Parameters.Add(New SQLiteParameter("@loc", GunaTextBoxadd.Text))
                cmd.Parameters.Add(New SQLiteParameter("@desg", GunaTextBoxdsgn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@desg", GunaTextBoxdsgn.Text))


                cmd.Parameters.AddWithValue("@pspt", ms.ToArray) ' inserting picture or image
                cmd.Parameters.Add(New SQLiteParameter("@date", DateTimePicker1.Value.ToShortDateString))



                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Your Record has been Saved Successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please check that all the fields are filed including the Imagebox then Try again")
        End Try
    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click



        Try     'validating and insertion code

            Dim head As Integer = DataGridView1.SelectedRows(0).Cells("StaffID").Value
            connect()






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

            If GunaComboBoxsx.Text = "" Then
                MsgBox("Please Enter the Employee's Gender", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxsx.Focus()
                Exit Sub
            End If


            If GunaComboBoxmst.Text = "" Then
                MsgBox("Please Make Sure you Entered the Employee's Marital Status", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxmst.Focus()
                Exit Sub
            End If
            If GunaTextBoxqul.Text = "" Then
                MsgBox("Please Enter the Employee's Qualification", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqul.Focus()
                Exit Sub
            End If



            If GunaTextBoxsch.Text = "" Then
                MsgBox("Please Enter the Institution attended by the Employee", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxsch.Focus()
                Exit Sub
            End If

            If GunaTextBoxcst.Text = "" Then
                MsgBox("Please Enter the Employee's Course of Study ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxcst.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxtel.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxtel.Focus()
                Exit Sub
            End If

            If GunaTextBoxadd.Text = "" Then
                MsgBox("Please Enter the Employee's Address", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxadd.Focus()
                Exit Sub
            End If
            If GunaTextBoxdsgn.Text = "" Then
                MsgBox("Please Enter the Employee's Designation", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdsgn.Focus()
                Exit Sub
            End If
            Dim cmd As New SQLiteCommand
            cmd.Connection = connection

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Update the payment Record of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then


            Else
                cmd.CommandText = "update stafftable set Surname = @snm, Othername = @onm, DOB = @dob,MaritalStatus = @mst, Qualification=@qul,SchoolAttended = @sch, CourseOfStudy = @cos, Telephone = @tel, Address = @loc,Designation=@desg  where StaffID = @id"

                cmd.Parameters.AddWithValue("@id", head)
                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxsn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxonm.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dob", GunaDateTimePicker1.Text))
                cmd.Parameters.Add(New SQLiteParameter("@mst", GunaComboBoxmst.Text))
                cmd.Parameters.Add(New SQLiteParameter("@qul", GunaTextBoxqul.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sch", GunaTextBoxsch.Text))
                cmd.Parameters.AddWithValue("@cos", GunaTextBoxcst.Text)

                cmd.Parameters.Add(New SQLiteParameter("@tel", GunaTextBoxtel.Text))
                cmd.Parameters.Add(New SQLiteParameter("@loc", GunaTextBoxadd.Text))
                cmd.Parameters.Add(New SQLiteParameter("@desg", GunaTextBoxdsgn.Text))

                Dim msg As Integer = cmd.ExecuteNonQuery()
                MsgBox(msg & "" & "Record is updated successfully")
                connection.Close()
                showData()




            End If
        Catch ex As Exception
            MsgBox("Oops!! An Error has occured Please make sure you  hightlightd the Record Row to be updated")

        End Try
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        'delecting which ever row selected on the datagridview
        Try



            Dim head As Integer = DataGridView1.SelectedRows(0).Cells("StaffID").Value

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Delete the Records of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                connect()
                Dim cmd As New SQLiteCommand
                cmd.Connection = connection
                cmd.CommandText = "Delete from stafftable  where StaffID = @id"
                cmd.Parameters.AddWithValue("@id", head)
                Dim msg As Integer = cmd.ExecuteNonQuery()
                MsgBox(msg & "Record is deleted successfully")
                connection.Close()
                showData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaTextBoxsearch_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxsearch.KeyUp
        Try
            cmd = New SQLiteCommand("select * from stafftable where Surname like '%" + GunaTextBoxsearch.Text + "%'", connection)


            da = New SQLiteDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "stafftable")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "stafftable"
            cmd.Dispose()
            ds.Dispose()
            connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to close this Page?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
        Else

            Me.Close()
        End If
    End Sub

    Private Sub StaffsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffsToolStripMenuItem.Click
        GunaButton2.Visible = False
        GunaButton7.Visible = True
        Me.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        STUDENGER.GunaButton7.Visible = True
        STUDENGER.GunaButton2.Visible = False


        STUDENGER.Show()
    End Sub

    Private Sub ViewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProfileToolStripMenuItem.Click
        GunaButton7.Visible = False
        GunaButton2.Visible = True
        Me.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem1.Click
        PAYROLLGER.Show()
        PAYROLLGER.GunaButton2.Show()
        PAYROLLGER.GunaButton7.Hide()
    End Sub

    Private Sub CreateProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateProfileToolStripMenuItem.Click
        STUDENGER.GunaButton7.Visible = False
        STUDENGER.GunaButton2.Visible = True
        GunaButton7.Visible = False
        GunaButton2.Visible = True

        STUDENGER.Show()
    End Sub

    Private Sub ViewProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewProfileToolStripMenuItem1.Click
        STUDENGER.Show()
    End Sub

    Private Sub RecievePaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecievePaymentToolStripMenuItem.Click
        STUDENGER.Show()
        STUDENGER.GunaButton2.Visible = False
        STUDENGER.GunaButton7.Visible = True
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            ' display datagridview data on click
            Dim selectedgr As DataGridViewRow
            selectedgr = DataGridView1.Rows(e.RowIndex)


            'image convertion for display sake

            Dim bytes As [Byte]() = DataGridView1.CurrentRow.Cells(12).Value 'converting image to byte 
                Dim ms As New MemoryStream(bytes)  ' parsing byte into memorystream image dispaly
                GunaPictureBoxPASS.Image = Image.FromStream(MS) 'image dispaly onto the picture box


                'Record/data display according to column position on their assigned control or tools
                GunaLabel14.Text = selectedgr.Cells(0).Value
                GunaTextBoxsn.Text = selectedgr.Cells(1).Value
                GunaTextBoxonm.Text = selectedgr.Cells(2).Value
                GunaComboBoxsx.Text = selectedgr.Cells(3).Value
            GunaDateTimePicker1.Text = selectedgr.Cells(4).Value
            GunaComboBoxmst.Text = selectedgr.Cells(5).Value
                GunaTextBoxqul.Text = selectedgr.Cells(6).Value
                GunaTextBoxsch.Text = selectedgr.Cells(7).Value


                GunaTextBoxcst.Text = selectedgr.Cells(8).Value
                'GunaGroupBox2.Text = selectedgr.Cells(9).Value
                'GunaGroupBox1.Text = selectedgr.Cells(10).Value

                GunaTextBoxtel.Text = selectedgr.Cells(9).Value
                GunaTextBoxadd.Text = selectedgr.Cells(10).Value
                GunaTextBoxdsgn.Text = selectedgr.Cells(11).Value


        Catch ex As Exception

        End Try





    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub UpdateProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UpdateProfileToolStripMenuItem1.Click
        GunaButton2.Visible = False
        GunaButton7.Visible = True

        Me.Show()

    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        ACCOUNT_MANAGER.Show()
        Me.Hide()
    End Sub

    Private Sub CompanyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanyToolStripMenuItem.Click
        Company_Name.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) 
        connect()


        Dim cmd As New SQLiteCommand("select * from stafftable", connection)
        Dim table As New DataTable()
        Dim adapter As New SQLiteDataAdapter(cmd)
        adapter.Fill(table)
        GunaLabel14.Text = table.Rows(0)(0).ToString
        GunaTextBoxsn.Text = table.Rows(0)(1).ToString
        GunaTextBoxonm.Text = table.Rows(0)(2).ToString

        Dim img() As Byte
        'img = table.Rows(0)(12)
        Dim ms As New MemoryStream(img)
        GunaPictureBoxPASS.Image = Image.FromStream(ms)




    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        'PICTURE UPDATE
        connect()
        Try

            Dim cmd As New SQLiteCommand
            cmd.Connection = connection

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Update the payment Record of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                cmd.CommandText = "update stafftable set Passport =@pspt where StaffID = @id"
                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxPASS.Image.Save(ms, GunaPictureBoxPASS.Image.RawFormat)  ' collecting picture from picturebox to db


                cmd.Parameters.AddWithValue("@id", GunaLabel14.Text)
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

    Private Sub GunaTextBoxDOB_Enter(sender As Object, e As EventArgs)
        ' GunaTextBoxDOB.Text = ""
    End Sub

    Private Sub GunaTextBoxDOB_Leave(sender As Object, e As EventArgs)
        ' If GunaTextBoxDOB.Text = "" Then
        'GunaTextBoxDOB.Text = "e.g 2/11/2020"
        ' End If
    End Sub

    Private Sub GunaTextBoxqul_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxqul.Enter
        GunaTextBoxqul.Text = ""
    End Sub

    Private Sub GunaTextBoxqul_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxqul.Leave
        If GunaTextBoxqul.Text = "" Then
            GunaTextBoxqul.Text = "Bsc., Hnd, Mst etc"
        End If

    End Sub

    Private Sub GunaTextBoxtel_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxtel.Enter
        GunaTextBoxtel.Text = ""
    End Sub

    Private Sub GunaTextBoxtel_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxtel.Leave
        If GunaTextBoxtel.Text = "" Then
            GunaTextBoxtel.Text = "phone No: 080256874654"

        End If
    End Sub

    Private Sub GunaTextBoxdsgn_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxdsgn.Enter
        GunaTextBoxdsgn.Text = ""
    End Sub

    Private Sub GunaTextBoxdsgn_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxdsgn.Leave
        If GunaTextBoxdsgn.Text = "" Then
            GunaTextBoxdsgn.Text = "Principal etc"
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try

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

            If GunaComboBoxsx.Text = "" Then
                MsgBox("Please Enter the Employee's Gender", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxsx.Focus()
                Exit Sub
            End If


            If GunaComboBoxmst.Text = "" Then
                MsgBox("Please Make Sure you Entered the Employee's Marital Status", MessageBoxIcon.Exclamation, "error")
                GunaComboBoxmst.Focus()
                Exit Sub
            End If
            If GunaTextBoxqul.Text = "" Then
                MsgBox("Please Enter the Employee's Qualification", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqul.Focus()
                Exit Sub
            End If

            If IsNothing(GunaPictureBoxPASS.Image) Then
                MsgBox("Please Upload the Staff Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If

            If GunaTextBoxsch.Text = "" Then
                MsgBox("Please Enter the Institution attended by the Employee", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxsch.Focus()
                Exit Sub
            End If

            If GunaTextBoxcst.Text = "" Then
                MsgBox("Please Enter the Employee's Course of Study ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxcst.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxtel.Text) Then
                MsgBox("Please Enter only Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxtel.Focus()
                Exit Sub
            End If

            If GunaTextBoxadd.Text = "" Then
                MsgBox("Please Enter the Employee's Address", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxadd.Focus()
                Exit Sub
            End If
            If GunaTextBoxdsgn.Text = "" Then
                MsgBox("Please Enter the Employee's Designation", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdsgn.Focus()
                Exit Sub
            End If

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else

                'insertion code

                cmd.Connection = connection

                cmd.CommandText = " Insert into stafftable (Surname, OtherName,Sex,DOB,MaritalStatus, Qualification,SchoolAttended,CourseOfStudy,Telephone,Address,Designation,Passport) 
Values(@snm,  @onm,@sx, @dob,@mst,@qul, @sch,@cos,@tel,@loc,@desg,@pspt)"

                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxPASS.Image.Save(ms, GunaPictureBoxPASS.Image.RawFormat)  ' collecting picture from picturebox to db

                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxsn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxonm.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sx", GunaComboBoxsx.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dob", GunaDateTimePicker1.Text))
                cmd.Parameters.Add(New SQLiteParameter("@mst", GunaComboBoxmst.Text))
                cmd.Parameters.Add(New SQLiteParameter("@qul", GunaTextBoxqul.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sch", GunaTextBoxsch.Text))
                cmd.Parameters.AddWithValue("@cos", GunaTextBoxcst.Text)

                cmd.Parameters.Add(New SQLiteParameter("@tel", GunaTextBoxtel.Text))
                cmd.Parameters.Add(New SQLiteParameter("@loc", GunaTextBoxadd.Text))
                cmd.Parameters.Add(New SQLiteParameter("@desg", GunaTextBoxdsgn.Text))
                cmd.Parameters.Add(New SQLiteParameter("@desg", GunaTextBoxdsgn.Text))


                cmd.Parameters.AddWithValue("@pspt", ms.ToArray) ' inserting picture or image



                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Your Record has been Saved Successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please check that all the fields are filed including the Imagebox then Try again")
        End Try
    End Sub
End Class