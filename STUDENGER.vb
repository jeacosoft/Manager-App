Imports System.Data.SQLite
Imports System.Drawing.Imaging
Imports System.IO


Public Class STUDENGER
    Dim actx As Double
    Private imgFormat As ImageFormat
    Public Property SqliteDbType As Object

    Private Sub STUDENGER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaDateTimePicker1.Value = DateTime.Now


        GunaTextBoxTPFES.Visible = False
        GunaLabel14.Visible = False
        GunaGroupBox3.Visible = False
        GunaLabel13.Visible = False
        GunaTextBoxpd.Visible = False
        GunaLabelBAL.Visible = False
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

    'code to extract data from the database and display on the datagrid
    Sub showData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from studentable", connection)
        'Dim dt As New DataTable
        Dim ds As New DataSet
        da.Fill(ds, "studentable")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "studentable"
        connection.Clone()
        da.Dispose()
    End Sub

    Private Sub GunaTextBox10_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxSearch.Enter
        GunaTextBoxSearch.Text = ""
    End Sub


    Private Sub GunaTextBoxSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxSearch.KeyUp
        'searching the database 
        ' Try


        If GunaComboBox1.Text = "Surname" Then
                connect()
                cmd = New SQLiteCommand("select * from studentable where Surname like '%" + GunaTextBoxSearch.Text + "%'", connection)


                da = New SQLiteDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "studentable")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "studentable"
                cmd.Dispose()
                ds.Dispose()
                connection.Close()
            ElseIf GunaComboBox1.Text = "Othername" Then

                connect()
                cmd = New SQLiteCommand("select * from studentable where Othernames like '%" + GunaTextBoxSearch.Text + "%'", connection)


                da = New SQLiteDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "studentable")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "studentable"
                cmd.Dispose()
                ds.Dispose()
                connection.Close()
            ElseIf GunaComboBox1.Text = "Class" Then
                connect()
            cmd = New SQLiteCommand("select * from studentable where Class like '%" & GunaTextBoxSearch.Text & "%'", connection)


            da = New SQLiteDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "studentable")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "studentable"
                cmd.Dispose()
                ds.Dispose()
                connection.Close()
            Else
                MsgBox("Please select your search Key from th COMBOBOX above")
            End If
            ' Catch ex As Exception

        'End Try
    End Sub



    Private Sub GunaTextBoxpd_Leave(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click


        'PICTURE UPLOAD
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Choose Image (*.JPG;*.PNG; *.GIF)|*.bmp;*.gif;*.jpg"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            GunaPictureBoxPASS.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If





    End Sub

    Private Sub GunaTextBoxTUTN_KeyUp_1(sender As Object, e As KeyEventArgs) Handles GunaTextBoxTUTN.KeyUp
        Dim tt As Double
        tt = Val(GunaTextBoxTPFES.Text) + Val(GunaTextBoxTUTN.Text)
        GunaLabelTTFEES.Text = System.Convert.ToString(tt)
        GunaLabelTTFEES.Text = tt.ToString("")

    End Sub



    Private Sub GunaRadioButtonYES_CheckedChanged_1(sender As Object, e As EventArgs) Handles GunaRadioButtonYES.CheckedChanged
        If GunaRadioButtonYES.Checked Then
            GunaTextBoxTPFES.Visible = True
            GunaLabel14.Visible = True
            GunaGroupBox3.Visible = True
            GunaLabel13.Visible = True
            GunaRadioButtonNO.Visible = False

        Else
            GunaTextBoxTPFES.Visible = False
            GunaLabel14.Visible = False
            GunaGroupBox3.Visible = False
            GunaLabel13.Visible = False



        End If
    End Sub

    Private Sub GunaTextBoxpd_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxpd.KeyUp
        'Balance of payment

        Try
            Dim BAL As Double
            Dim ttfes As Double = CDbl(GunaLabelTTFEES.Text)
            Dim paid As Double = CDbl(GunaTextBoxpd.Text)
            BAL = ttfes - paid
            GunaLabelBAL.Text = System.Convert.ToString(BAL)
            GunaLabelBAL.Text = BAL.ToString("")
        Catch ex As Exception

        End Try
    End Sub
    Function image64(ByVal image As Image, ByVal format As System.Drawing.Imaging.ImageFormat) As String
        Try


            Dim img As New MemoryStream
            image.Save(img, format)
            Dim imagebyte() As Byte = img.ToArray()
            Dim Base64String As String = Convert.ToBase64String(imagebyte)
            Return Base64String
        Catch ex As Exception

        End Try
    End Function
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click





        GunaDateTimePicker1.Value = DateTime.Now
        Dim rel As String = String.Empty

        Dim tp As String = String.Empty
        Dim sect As String = String.Empty

        ' adding the radiobutton value
        If GunaRadioButtonYES.Checked = True Then
            tp = "YES"
        ElseIf GunaRadioButtonNO.Checked = True Then
            tp = "NO"

        End If
        If GunaRadioButtonMON.Checked = True Then
            sect = "MORNING"
        ElseIf GunaRadioButtonAFTN.Checked = True Then
            sect = "AFTERNOON"
        ElseIf GunaRadioButtonBOTH.Checked = True Then
            sect = "BOTH"
        End If

        If GunaRadioButtonPAR.Checked = True Then


            rel = "Parent"

        ElseIf GunaRadioButtonGDN.Checked = True Then
            rel = "Guidian"
        End If


        'inserting into the database and datavalidation

        Try




            connect()





            Dim cmd As New SQLiteCommand
            If GunaComboBoxSX.Text = "" Then
                MsgBox("Please Enter the candidate Gender", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxSN.Focus()
                Exit Sub
            End If

            If GunaTextBoxSN.Text = "" Then
                MsgBox("Please Enter the candidate Surname", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxSN.Focus()
                Exit Sub
            End If


            If GunaTextBoxON.Text = "" Then
                MsgBox("Please Enter the candidate Othername", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxON.Focus()
                Exit Sub
            End If

            ' 


            If Not IsNumeric(GunaTextBoxAGE.Text) Then
                MsgBox("Please Make Sure you Enter Figure Only", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAGE.Focus()
                Exit Sub
            End If
            If GunaTextBoxAGE.Text = "" Then
                MsgBox("Please Enter the candidate Age", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAGE.Focus()
                Exit Sub
            End If

            If GunaTextBoxCLS.Text = "" Then
                MsgBox("Please Enter the candidate Class", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxCLS.Focus()
                Exit Sub
            End If

            If Not IsNumeric(GunaTextBoxTEL.Text) Then
                MsgBox("Please Enter Phone number with Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTEL.Focus()
                Exit Sub
            End If

            If GunaTextBoxTEL.Text = "" Then
                MsgBox("Please Enter the Sponsor's Phone Number", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTEL.Focus()
                Exit Sub
            End If

            If GunaTextBoxADD.Text = "" Then
                MsgBox("Please Enter the Sponsor's Address", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxADD.Focus()
                Exit Sub
            End If



            If Not IsNumeric(GunaTextBoxTUTN.Text) Then
                MsgBox("Please Enter Figures", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTUTN.Focus()
                Exit Sub
            End If
            If GunaTextBoxTUTN.Text = "" Then
                MsgBox("Please Enter Tuition Fees", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTUTN.Focus()
                Exit Sub
            End If

            If IsNothing(GunaPictureBoxPASS.Image) Then
                MsgBox("Please Upload the candidate Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If

            If GunaPictureBoxPASS.InvokeRequired Then
                MsgBox("Please Upload the candidate Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If
            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else



                cmd.Connection = connection

                cmd.CommandText = " Insert into studentable (Surname, OtherNames,Sex,DOB,Age,Class,Address,PhoneNo,Sponsor,SchoolTransportation, Section,TransportationFees,TuitionFees, TotalFees,AmountPaid,Passport, Date) Values(@snm,  @onm, @sx,@dob,@old, @cls,@ladd,@tel,@sps,@stp,@sct,@tpfe,@ttnf,@ttfes,@atp,@paspt, @date)"
                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxPASS.Image.Save(ms, GunaPictureBoxPASS.Image.RawFormat) ' collecting picture from picturebox to db

                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxSN.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxON.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sx", GunaComboBoxSX.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dob", GunaDateTimePickerDob.Text))
                cmd.Parameters.Add(New SQLiteParameter("@old", GunaTextBoxAGE.Text))
                cmd.Parameters.Add(New SQLiteParameter("@cls", GunaTextBoxCLS.Text))
                cmd.Parameters.AddWithValue("@tel", GunaTextBoxTEL.Text)

                cmd.Parameters.Add(New SQLiteParameter("@ladd", GunaTextBoxADD.Text))

                cmd.Parameters.AddWithValue("@sct", sect)
                cmd.Parameters.AddWithValue("@stp", tp)
                cmd.Parameters.Add(New SQLiteParameter("@tpfe", GunaTextBoxTPFES.Text))
                cmd.Parameters.Add(New SQLiteParameter("@ttnf", GunaTextBoxTUTN.Text))
                cmd.Parameters.Add(New SQLiteParameter("@ttfes", GunaLabelTTFEES.Text))
                cmd.Parameters.Add(New SQLiteParameter("@atp", GunaTextBoxpd.Text))
                cmd.Parameters.AddWithValue("@sps", rel)
                cmd.Parameters.Add(New SQLiteParameter("@paspt", ms.ToArray)) ' inserting picture or image
                cmd.Parameters.Add(New SQLiteParameter("@date", GunaDateTimePicker1.Value.ToShortDateString))


                '.Parameters.AddWithValue("", GunaRadioButtonPAR.Text Or GunaRadioButtonGDN.Text).ResetDbType()



                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("The Candidate Record has been save successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please check that all the fields are filed including the Imagebox then Try again")
        End Try


        ' ACCOUNT_MANAGER.LabelDAILYINCOM.Text = Val(GunaTextBoxpd.Text) + Val(ACCOUNT_MANAGER.LabelDAILYINCOM.Text)
    End Sub

    Private Sub GunaRadioButtonMON_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonMON.CheckedChanged
        If GunaRadioButtonMON.Checked Then
            GunaRadioButtonAFTN.Visible = False
            GunaRadioButtonBOTH.Visible = False

        ElseIf GunaRadioButtonAFTN.Checked Then
            GunaRadioButtonBOTH.Visible = False
            GunaRadioButtonMON.Visible = False

        Else
            GunaRadioButtonMON.Visible = False
            GunaRadioButtonAFTN.Visible = False
        End If
    End Sub

    Private Sub GunaRadioButtonAFTN_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonAFTN.CheckedChanged
        If GunaRadioButtonMON.Checked Then
            GunaRadioButtonAFTN.Visible = False
            GunaRadioButtonBOTH.Visible = False

        ElseIf GunaRadioButtonAFTN.Checked Then
            GunaRadioButtonBOTH.Visible = False
            GunaRadioButtonMON.Visible = False

        Else
            GunaRadioButtonMON.Visible = False
            GunaRadioButtonAFTN.Visible = False
        End If
    End Sub

    Private Sub GunaRadioButtonBOTH_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonBOTH.CheckedChanged
        If GunaRadioButtonMON.Checked Then
            GunaRadioButtonAFTN.Visible = False
            GunaRadioButtonBOTH.Visible = False

        ElseIf GunaRadioButtonAFTN.Checked Then
            GunaRadioButtonBOTH.Visible = False
            GunaRadioButtonMON.Visible = False

        Else
            GunaRadioButtonMON.Visible = False
            GunaRadioButtonAFTN.Visible = False
        End If
    End Sub

    Private Sub GunaRadioButtonNO_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonNO.CheckedChanged


        If GunaRadioButtonYES.Checked Then
            GunaRadioButtonNO.Visible = False

        Else
            GunaRadioButtonYES.Visible = False
        End If
    End Sub

    Private Sub GunaRadioButtonPAR_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonPAR.CheckedChanged

        If GunaRadioButtonPAR.Checked Then
            GunaRadioButtonGDN.Visible = False

        Else
            GunaRadioButtonPAR.Visible = False
        End If
    End Sub

    Private Sub GunaRadioButtonGDN_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonGDN.CheckedChanged
        If GunaRadioButtonPAR.Checked Then
            GunaRadioButtonGDN.Visible = False

        Else
            GunaRadioButtonPAR.Visible = False
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick





        Try





            ' display datagridview data on click
            Dim selectedgr As DataGridViewRow
            selectedgr = DataGridView1.Rows(e.RowIndex)


            'image convertion for display sake
            Dim bytes As [Byte]() = DataGridView1.CurrentRow.Cells(17).Value 'converting image to byte 
            Dim ms As New MemoryStream(bytes) ' parsing byte into memorystream image dispaly
            GunaPictureBoxPASS.Image = Image.FromStream(ms) 'image dispaly onto the picture box


            'Record/data display according to column position on their assigned control or tools
            GunaLabelid.Text = selectedgr.Cells(0).Value
            GunaTextBoxSN.Text = selectedgr.Cells(1).Value
            GunaTextBoxON.Text = selectedgr.Cells(2).Value
            GunaComboBoxSX.Text = selectedgr.Cells(3).Value
            GunaTextBoxAGE.Text = selectedgr.Cells(5).Value
            GunaDateTimePickerDob.Text = selectedgr.Cells(4).Value
            GunaTextBoxCLS.Text = selectedgr.Cells(6).Value

            GunaTextBoxTEL.Text = selectedgr.Cells(8).Value


            GunaTextBoxADD.Text = selectedgr.Cells(7).Value
            GunaGroupBox2.Text = selectedgr.Cells(9).Value
            GunaGroupBox1.Text = selectedgr.Cells(10).Value
            GunaGroupBox3.Text = selectedgr.Cells(11).Value
            GunaTextBoxTPFES.Text = selectedgr.Cells(12).Value
            GunaTextBoxTUTN.Text = selectedgr.Cells(13).Value
            GunaLabelTTFEES.Text = selectedgr.Cells(14).Value
            GunaTextBoxpd.Text = selectedgr.Cells(15).Value
            GunaLabelBAL.Text = selectedgr.Cells(16).Value


        Catch ex As Exception

        End Try
        'choosing the radio buttion to be checked 
        If GunaGroupBox1.Text = "YES" Then
            GunaRadioButtonYES.Checked = True
            GunaRadioButtonNO.Visible = True
        ElseIf GunaGroupBox1.text = "NO" Then
            GunaRadioButtonNO.Checked = True
            GunaRadioButtonYES.Visible = True
        Else
            GunaRadioButtonNO.Checked = False
            GunaRadioButtonYES.Checked = False
            GunaRadioButtonNO.Visible = True
            GunaRadioButtonYES.Visible = True


        End If

        If GunaGroupBox2.Text = "Parent" Then
            GunaRadioButtonPAR.Checked = True
            GunaRadioButtonGDN.Visible = True
        ElseIf GunaGroupBox2.Text = "Guidian" Then
            GunaRadioButtonGDN.Checked = True
            GunaRadioButtonPAR.Visible = True
        Else
            GunaRadioButtonGDN.Checked = False
            GunaRadioButtonPAR.Checked = False

            GunaRadioButtonGDN.Visible = True
            GunaRadioButtonPAR.Visible = True


        End If

        If GunaGroupBox3.Text = "MORNING ONLY" Then
            GunaRadioButtonMON.Checked = True
            GunaRadioButtonAFTN.Visible = True
            GunaRadioButtonBOTH.Visible = True
        ElseIf GunaGroupBox3.Text = "AFTERNOON ONLY" Then
            GunaRadioButtonAFTN.Checked = True
            GunaRadioButtonMON.Visible = True
            GunaRadioButtonBOTH.Visible = True

        ElseIf GunaGroupBox3.Text = "BOTH" Then
            GunaRadioButtonBOTH.Checked = True
            GunaRadioButtonMON.Visible = True
            GunaRadioButtonAFTN.Visible = True
        Else
            GunaRadioButtonMON.Checked = False
            GunaRadioButtonAFTN.Checked = False
            GunaRadioButtonBOTH.Checked = False
            GunaRadioButtonMON.Visible = True
            GunaRadioButtonAFTN.Visible = True
            GunaRadioButtonBOTH.Visible = True

        End If




        If GunaGroupBox1.Text = "YES" Then
            GunaLabel13.Visible = True
            GunaGroupBox3.Visible = True
            GunaLabel14.Visible = True
            GunaTextBoxTPFES.Visible = True


        End If


    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        Try


            Dim head As Integer = DataGridView1.SelectedRows(0).Cells("StudentID").Value

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Delete the Records of this Student?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                connect()
                Dim cmd As New SQLiteCommand
                cmd.Connection = connection
                cmd.CommandText = "Delete from studentable  where StudentID = @id"
                cmd.Parameters.AddWithValue("@id", head)
                Dim msg As Integer = cmd.ExecuteNonQuery()
                MsgBox(msg & "Record is deleted successfully")
                connection.Close()
                showData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        GunaTextBoxSN.Text = ""
        GunaTextBoxON.Text = ""
        GunaComboBoxSX.Text = ""
        ' GunaTextBoxDOB.Text = ""
        GunaTextBoxAGE.Text = ""
        GunaTextBoxCLS.Text = ""
        GunaTextBoxTEL.Text = ""
        GunaRadioButtonPAR.Checked = False
        GunaTextBoxADD.Text = ""
        GunaRadioButtonGDN.Checked = False
        GunaTextBoxTPFES.Text = ""

        GunaTextBoxpd.Text = ""
        GunaTextBoxTUTN.Text = ""
        GunaLabelTTFEES.Text = ""
        GunaLabelBAL.Text = ""


        GunaRadioButtonYES.Checked = False
        GunaRadioButtonPAR.Checked = False
        GunaRadioButtonGDN.Checked = False
        GunaGroupBox2.Text = ""
        GunaRadioButtonMON.Checked = False
        GunaRadioButtonAFTN.Checked = False
        GunaRadioButtonBOTH.Checked = False
        GunaRadioButtonNO.Checked = False


        GunaRadioButtonPAR.Visible = True
        GunaRadioButtonGDN.Visible = True
        GunaGroupBox2.Text = ""
        GunaRadioButtonMON.Visible = True
        GunaRadioButtonAFTN.Visible = True
        GunaRadioButtonBOTH.Visible = True
        GunaRadioButtonYES.Visible = True
        GunaRadioButtonNO.Visible = True
        GunaGroupBox1.Text = ""
        GunaGroupBox3.Text = ""

        GunaPictureBoxPASS.Image = Nothing

    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click
        Try

            'validating and insertion code
            connect()




            Dim cmd As New SQLiteCommand


            If GunaTextBoxSN.Text = "" Then
                MsgBox("Please Enter the candidate Surname", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxSN.Focus()
                Exit Sub
            End If


            If GunaTextBoxON.Text = "" Then
                MsgBox("Please Enter the candidate Othername", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxON.Focus()
                Exit Sub
            End If




            If Not IsNumeric(GunaTextBoxAGE.Text) Then
                MsgBox("Please Make Sure you Enter Figure Only", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAGE.Focus()
                Exit Sub
            End If
            If GunaTextBoxAGE.Text = "" Then
                MsgBox("Please Enter the candidate Age", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAGE.Focus()
                Exit Sub
            End If

            If GunaTextBoxCLS.Text = "" Then
                MsgBox("Please Enter the candidate Class", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxCLS.Focus()
                Exit Sub
            End If

            If Not IsNumeric(GunaTextBoxTEL.Text) Then
                MsgBox("Please Enter Phone number with Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTEL.Focus()
                Exit Sub
            End If

            If GunaTextBoxTEL.Text = "" Then
                MsgBox("Please Enter the Sponsor's Phone Number", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTEL.Focus()
                Exit Sub
            End If

            If GunaTextBoxADD.Text = "" Then
                MsgBox("Please Enter the Sponsor's Address", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxADD.Focus()
                Exit Sub
            End If



            If Not IsNumeric(GunaTextBoxTUTN.Text) Then
                MsgBox("Please Enter Figures", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTUTN.Focus()
                Exit Sub
            End If
            If GunaTextBoxTUTN.Text = "" Then
                MsgBox("Please Enter Tuition Fees", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTUTN.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxpd.Text) Then
                MsgBox("Please Enter Figures ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxpd.Focus()
                Exit Sub
            End If

            If GunaTextBoxpd.Text = "" Then
                MsgBox("Please Enter Filling the Paid Space", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxpd.Focus()
                Exit Sub
            End If

            If GunaPictureBoxPASS.InvokeRequired Then
                MsgBox("Please Upload the candidate Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else

                'insertion code

                cmd.Connection = connection

                cmd.CommandText = "update studentable set Surname = @snm, Othernames = @onm, DOB = @dob, PhoneNo = @tel, Address = @loc,TransportationFees=@tpfe,
TuitionFees= @ttnf,TotalFees = @ttfes where StudentID = @id"

                cmd.Parameters.Add(New SQLiteParameter("@id", GunaLabelid.Text))

                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxSN.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxON.Text))
                ' cmd.Parameters.Add(New SQLiteParameter("@sx", GunaComboBoxSX.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dob", GunaDateTimePickerDob.Text))
                ' cmd.Parameters.Add(New SQLiteParameter("@old", GunaTextBoxAGE.Text))

                cmd.Parameters.AddWithValue("@tel", GunaTextBoxTEL.Text)

                cmd.Parameters.Add(New SQLiteParameter("@loc", GunaTextBoxADD.Text))
                cmd.Parameters.Add(New SQLiteParameter("@tpfe", GunaTextBoxTPFES.Text))
                cmd.Parameters.Add(New SQLiteParameter("@ttnf", GunaTextBoxTUTN.Text))
                cmd.Parameters.Add(New SQLiteParameter("@ttfes", GunaLabelTTFEES.Text))
                ' cmd.Parameters.Add(New SQLiteParameter("@atp", GunaTextBoxpd.Text))
                ' cmd.Parameters.Add(New SQLiteParameter("@bapy", GunaLabelBAL.Text))


                cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("Your Record has been Updatd Successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please Try again")
        End Try
    End Sub

    Private Sub GunaTransfarantPictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub StudentsProfileToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Me.Show()
    End Sub

    Private Sub StaffProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        STAFFOGER.GunaButton7.Visible = True
        STAFFOGER.GunaButton2.Visible = False


        STAFFOGER.Show()
    End Sub

    Private Sub StaffsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffsToolStripMenuItem.Click
        STAFFOGER.Show()

    End Sub

    Private Sub StudentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StudentsToolStripMenuItem1.Click
        GunaButton2.Visible = False
        GunaButton7.Visible = True

        Me.Show()
    End Sub

    Private Sub CreateProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CreateProfileToolStripMenuItem1.Click

        GunaButton7.Visible = False
        GunaButton2.Visible = True
        Me.Show()
    End Sub

    Private Sub RecievePaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecievePaymentToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub CreateProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateProfileToolStripMenuItem.Click
        STAFFOGER.Show()
    End Sub

    Private Sub ViewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProfileToolStripMenuItem.Click
        STAFFOGER.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem.Click
        PAYROLLGER.Show()

    End Sub

    Private Sub RecievePaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecievePaymentToolStripMenuItem1.Click
        Me.Show()
        GunaButton2.Visible = False
        GunaButton7.Visible = True

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to Close this Page?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
        Else

            Me.Close()
        End If
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        ACCOUNT_MANAGER.Show()
        Me.Hide()
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        'PICTURE UPDATE
        connect()
        Try

            Dim cmd As New SQLiteCommand
            cmd.Connection = connection

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Update the payment Record of this Staff?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else
                cmd.CommandText = "update studentable set Passport =@pspt where StudentID = @id"
                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxPASS.Image.Save(ms, GunaPictureBoxPASS.Image.RawFormat)  ' collecting picture from picturebox to db


                cmd.Parameters.AddWithValue("@id", GunaLabelid.Text)
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

    Private Sub GunaTextBoxAGE_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxAGE.Enter
        GunaTextBoxAGE.Text = ""
    End Sub

    Private Sub GunaTextBoxAGE_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxAGE.Leave
        If GunaTextBoxAGE.Text = "" Then
            GunaTextBoxAGE.Text = "Age e.g 26"
        End If
    End Sub

    Private Sub GunaTextBoxDOB_Enter(sender As Object, e As EventArgs)
        'GunaTextBoxDOB.Text = ""
    End Sub

    Private Sub GunaTextBoxDOB_Leave(sender As Object, e As EventArgs)
        ' If GunaTextBoxDOB.Text = "" Then
        ' GunaTextBoxDOB.Text = "dd/mm/yyyy"

        '  End If
    End Sub

    Private Sub GunaTextBoxTEL_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxTEL.Enter
        GunaTextBoxTEL.Text = ""
    End Sub

    Private Sub GunaTextBoxTEL_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxTEL.Leave
        If GunaTextBoxTEL.Text = "" Then
            GunaTextBoxTEL.Text = "+23425587755"
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click





        Dim rel As String = String.Empty

        Dim tp As String = String.Empty
        Dim sect As String = String.Empty

        ' adding the radiobutton value
        If GunaRadioButtonYES.Checked = True Then
            tp = "YES"
        ElseIf GunaRadioButtonNO.Checked = True Then
            tp = "NO"

        End If
        If GunaRadioButtonMON.Checked = True Then
            sect = "MORNING"
        ElseIf GunaRadioButtonAFTN.Checked = True Then
            sect = "AFTERNOON"
        ElseIf GunaRadioButtonBOTH.Checked = True Then
            sect = "BOTH"
        End If

        If GunaRadioButtonPAR.Checked = True Then


            rel = "Parent"

        ElseIf GunaRadioButtonGDN.Checked = True Then
            rel = "Guidian"
        End If


        'inserting into the database and datavalidation

        Try




            connect()





            Dim cmd As New SQLiteCommand
            If GunaComboBoxSX.Text = "" Then
                MsgBox("Please Enter the candidate Gender", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxSN.Focus()
                Exit Sub
            End If

            If GunaTextBoxSN.Text = "" Then
                MsgBox("Please Enter the candidate Surname", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxSN.Focus()
                Exit Sub
            End If


            If GunaTextBoxON.Text = "" Then
                MsgBox("Please Enter the candidate Othername", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxON.Focus()
                Exit Sub
            End If




            If Not IsNumeric(GunaTextBoxAGE.Text) Then
                MsgBox("Please Make Sure you Enter Figure Only", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAGE.Focus()
                Exit Sub
            End If
            If GunaTextBoxAGE.Text = "" Then
                MsgBox("Please Enter the candidate Age", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxAGE.Focus()
                Exit Sub
            End If

            If GunaTextBoxCLS.Text = "" Then
                MsgBox("Please Enter the candidate Class", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxCLS.Focus()
                Exit Sub
            End If

            If Not IsNumeric(GunaTextBoxTEL.Text) Then
                MsgBox("Please Enter Phone number with Numberic Characters ", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTEL.Focus()
                Exit Sub
            End If

            If GunaTextBoxTEL.Text = "" Then
                MsgBox("Please Enter the Sponsor's Phone Number", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTEL.Focus()
                Exit Sub
            End If

            If GunaTextBoxADD.Text = "" Then
                MsgBox("Please Enter the Sponsor's Address", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxADD.Focus()
                Exit Sub
            End If



            If Not IsNumeric(GunaTextBoxTUTN.Text) Then
                MsgBox("Please Enter Figures", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTUTN.Focus()
                Exit Sub
            End If
            If GunaTextBoxTUTN.Text = "" Then
                MsgBox("Please Enter Tuition Fees", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxTUTN.Focus()
                Exit Sub
            End If

            If IsNothing(GunaPictureBoxPASS.Image) Then
                MsgBox("Please Upload the candidate Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If

            If GunaPictureBoxPASS.InvokeRequired Then
                MsgBox("Please Upload the candidate Picture", MessageBoxIcon.Exclamation, "error")
                GunaPictureBoxPASS.Focus()
                Exit Sub
            End If
            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then
            Else



                cmd.Connection = connection

                cmd.CommandText = " Insert into studentable (Surname, OtherNames,Sex,DOB,Age,Class,Address,PhoneNo,Sponsor,SchoolTransportation, Section,TransportationFees,TuitionFees, TotalFees,AmountPaid,Passport) Values(@snm,  @onm, @sx,@dob,@old, @cls,@ladd,@tel,@sps,@stp,@sct,@tpfe,@ttnf,@ttfes,@atp,@paspt)"
                Dim ms As New MemoryStream 'for converting  picture/image to memorystream
                GunaPictureBoxPASS.Image.Save(ms, GunaPictureBoxPASS.Image.RawFormat) ' collecting picture from picturebox to db

                cmd.Parameters.Add(New SQLiteParameter("@snm", GunaTextBoxSN.Text))
                cmd.Parameters.Add(New SQLiteParameter("@onm", GunaTextBoxON.Text))
                cmd.Parameters.Add(New SQLiteParameter("@sx", GunaComboBoxSX.Text))
                cmd.Parameters.Add(New SQLiteParameter("@dob", GunaDateTimePickerDob.Text))
                cmd.Parameters.Add(New SQLiteParameter("@old", GunaTextBoxAGE.Text))
                cmd.Parameters.Add(New SQLiteParameter("@cls", GunaTextBoxCLS.Text))
                cmd.Parameters.AddWithValue("@tel", GunaTextBoxTEL.Text)

                cmd.Parameters.Add(New SQLiteParameter("@ladd", GunaTextBoxADD.Text))

                cmd.Parameters.AddWithValue("@sct", sect)
                cmd.Parameters.AddWithValue("@stp", tp)
                cmd.Parameters.Add(New SQLiteParameter("@tpfe", GunaTextBoxTPFES.Text))
                cmd.Parameters.Add(New SQLiteParameter("@ttnf", GunaTextBoxTUTN.Text))
                cmd.Parameters.Add(New SQLiteParameter("@ttfes", GunaLabelTTFEES.Text))
                cmd.Parameters.Add(New SQLiteParameter("@atp", GunaTextBoxpd.Text))
                cmd.Parameters.AddWithValue("@sps", rel)
                cmd.Parameters.Add(New SQLiteParameter("@paspt", ms.ToArray)) ' inserting picture or image

                '.Parameters.AddWithValue("", GunaRadioButtonPAR.Text Or GunaRadioButtonGDN.Text).ResetDbType()




                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("The Candidate Record has been save successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please check that all the fields are filed including the Imagebox then Try again")
        End Try
    End Sub

    Private Sub GunaGroupBox1_Click(sender As Object, e As EventArgs) Handles GunaGroupBox1.Click

    End Sub

    Private Sub GunaTextBoxCLS_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxCLS.Enter
        GunaTextBoxCLS.Text = ""
    End Sub

    Private Sub GunaTextBoxCLS_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxCLS.Leave
        If GunaTextBoxCLS.Text = "" Then
            GunaTextBoxCLS.Text = " e.g SSS1 OR JSS1"
        End If
    End Sub
End Class