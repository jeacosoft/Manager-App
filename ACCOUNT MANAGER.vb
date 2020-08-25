Imports System.Data.SQLite
Imports System.IO
Imports System.Drawing.Imaging
Public Class ACCOUNT_MANAGER
    Dim managerDb As String = "managerDb.db" 'declaring the database
    Dim connectionString As String = "Data Source (0); Version = 3; " 'linking the database
    Dim accumdailyINCOME As Double
    Dim acexp As Double
    Dim accumdailysale As Double
    Dim accum As Double
    Dim actx As Double

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub LabelITEMNAME_Click(sender As Object, e As EventArgs) Handles LabelITEMNAME.Click

    End Sub

    Private Sub ComboBoxoption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxoption.SelectedIndexChanged
        If ComboBoxoption.Text = "Recieve Payment From Student" Then
            Labelname.Text = "Student Name"
            LabelCLASS.Text = "Class"
            Labelid.Text = "StudentID"
            LabelCLASS.Visible = True
            TextBoxclass.Visible = True
            LabelBALQTY.Visible = True
            Label6.Visible = True
            Label6.Text = "Balance Fees"
            TextBoxAMT.Visible = True
            GunaLabelPrc.Visible = False
            Labelamt.Text = "Amount"
            Labeltfees.Text = "Total Fees"
            Labeltfees.Visible = True
            TextBox1.Visible = False
            TextBox2.Visible = False
            Labeltfes.Visible = True
            LabelBALQTY.Visible = True
            ' ComboBoxinfo.Visible = False
            ' ComboBoxinfo2.Visible = True
            GunaTransfarantPictureBox2.Visible = False
        ElseIf ComboBoxoption.Text = "SalaryPayment" Then
            Labelname.Text = "StaffName"
            LabelCLASS.Text = "Designation"
            Labeltfees.Text = "Net Salary"
            Labelid.Text = "Staff's ID"
            TextBoxclass.Visible = True
            Labelname.Visible = True
            LabelCLASS.Visible = True
            Labeltfes.Visible = True
            Label6.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            LabelBALQTY.Visible = False
            Labeltfes.Visible = True
            Labeltfees.Visible = True
            GunaLabelPrc.Visible = False
            TextBoxAMT.Visible = True
            Labelamt.Text = "Amount"
            ' ComboBoxinfo.Visible = True
            'ComboBoxinfo2.Visible = False
            GunaTransfarantPictureBox2.Visible = True
        ElseIf ComboBoxoption.Text = "Record Expenses"Then
            Labelname.Text = "Authorizer"
            LabelCLASS.Text = "Designation"
            Labeltfees.Text = "Purpose"
            Labelid.Text = "Date"
            Label6.Text = "Discription"
            Labelamt.Text = "Amount"
            TextBoxclass.Visible = True
            Labelname.Visible = True
            LabelCLASS.Visible = True
            LabelBALQTY.Visible = False
            Labeltfes.Visible = False
            TextBox1.Visible = True
            TextBox2.Visible = True
            Label6.Visible = True
            GunaLabelPrc.Visible = False
            Labeltfees.Visible = True
            TextBoxAMT.Visible = True
        ElseIf ComboBoxoption.Text = "SchoolMall"
            Labelname.Text = "ItemName"
            LabelCLASS.Text = "Price"
            Labeltfees.Text = "Qty in Stock"
            Labelid.Text = "ItemID"
            Label6.Text = "Balance Qty"
            Labelamt.Text = "Quantity"
            GunaLabelPrc.Visible = True
            TextBoxAMT.Visible = True
            TextBoxclass.Visible = False
            Labelname.Visible = True
            LabelCLASS.Visible = True
            LabelBALQTY.Visible = True
            Labeltfes.Visible = True
            TextBox1.Visible = False
            TextBox2.Visible = False
            Label6.Visible = True
            Labeltfees.Visible = True
            GunaTransfarantPictureBox2.Visible = False
        Else
            Labelamt.Text = "Amount"
            TextBoxAMT.Visible = True
            Labelname.Text = "Name"
            LabelCLASS.Visible = True
            TextBoxclass.Visible = True
            LabelCLASS.Text = "Transaction"
            Labeltfees.Text = "Price"
            Labeltfees.Visible = False
            Labelid.Text = "ID"
            Labeltfes.Visible = False
            TextBox1.Visible = false
            TextBox2.Visible = False
            LabelBALQTY.Visible = False
            Labeltfes.Visible = False
            Label6.Visible = False
            Label6.Text = "Balance"
            GunaLabelPrc.Visible = False
            GunaTransfarantPictureBox2.Visible = False

        End If
    End Sub
    'for data reader for accountable
    Sub showData()
        connect()
        Dim da As New SQLiteDataAdapter("select Name,TransactionType,AmountPaid, Balance  from accountable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub
    'for data reader for accountable showing details for item sold
    Sub seeData()
        connect()
        Dim da As New SQLiteDataAdapter("select  ItemName,Quantity,Price,TotalAmount,Date from accountable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub



    'datareader for accountablestudent
    Sub displayData()
        connect()
        Dim da As New SQLiteDataAdapter("select StudentID,Surname,Othernames,Class,TotalFees,AmountPaid, BalancePayment, Date  from studentable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "studentable")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "studentable"
        connection.Clone()
        da.Dispose()
    End Sub
    'display storetable
    Sub reviewData()
        connect()
        Dim da As New SQLiteDataAdapter("select ItemID,ItemName,Discription,Quantity,SalesPrice,TotalItemOut,Date  from storetable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "storetable")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "storetable"
        connection.Clone()
        da.Dispose()
    End Sub
    'datareader for accountstaff
    Sub viewData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from accountablestaff", connection)
        Dim ds As New DataSet
        da.Fill(ds, "accountablestaff")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "accountablestaff"
        connection.Clone()
        da.Dispose()
    End Sub

    Sub studentData()
        connect()
        Dim da As New SQLiteDataAdapter("select StudentName, Class,PaidAmount,TotalFees,Balances from accountable", connection)
        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub

    Sub ExpData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from expenditure", connection)
        Dim ds As New DataSet
        da.Fill(ds, "expenditure")

        DataGridViewDAILYSUMMARY.DataSource = ds
        DataGridViewDAILYSUMMARY.DataMember = "expenditure"
        connection.Clone()
        da.Dispose()
    End Sub




    Private Sub ACCOUNT_MANAGER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaDateTimePicker1.Value = DateTime.Now

        'Populating data from the data
        connect()
        Try



            Dim READER As SQLiteDataReader
            Dim cmd As SQLiteCommand = connection.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select DailyIncome, DailyBalance, TotalExpenses  From accountable"
            READER = cmd.ExecuteReader
            If READER.HasRows Then

                While READER.Read

                    LabelDAILYINCOM.Text = (READER("DailyIncome"))
                    LabelBAL.Text = (READER("DailyBalance"))
                    LabelTTLEXP.Text = (READER("TotalExpenses"))
                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception

        End Try


        'populating from the studentable's into combobox


        connect()
        Try



            Dim READER As SQLiteDataReader
            Dim cmd As SQLiteCommand = connection.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select Othername From payrolltable2"
            READER = cmd.ExecuteReader
            If READER.HasRows Then

                While READER.Read

                    ' ComboBoxinfo.Items.Add(READER("Othername"))

                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception
        End Try

        '

        'populating from the stafftable's into combobox

        connect()
        Try



            Dim READER As SQLiteDataReader
            Dim cmd As SQLiteCommand = connection.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select Othernames From studentable"
            READER = cmd.ExecuteReader
            If READER.HasRows Then

                While READER.Read

                    '  ComboBoxinfo2.Items.Add(READER("Othernames"))

                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception
        End Try
        'populating from companyNametable
        Try
            connect()
            Dim READER As SQLiteDataReader
            Dim cmd As SQLiteCommand = connection.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select CompanyName From companyname"
            READER = cmd.ExecuteReader
            If READER.HasRows Then

                While READER.Read

                    Labelcompanyname.Text = (READER("CompanyName"))

                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception


        End Try

        'creating data

        'hiding onload controls
        LabelCLASS.Visible = False
        TextBoxclass.Visible = False
        TextBox2.Visible = False
        TextBox1.Visible = False
        GunaLabelPrc.Visible = False
        ' ComboBoxinfo.Visible = False
        'ComboBoxinfo2.Visible = False

        'displaying data on te datagridview
        showData()


    End Sub


    'creating the database

    Private Sub TextBoxQty_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxAMT.KeyUp

    End Sub






    Private Sub TextBoxIsearch_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxIsearch.KeyUp
        Dim item As String = TextBoxIsearch.Text
        'searching the database
        Try


            Select Case ComboBoxoption.Text
                Case " Mesc. Transaction"


                    connect()
                    cmd = New SQLiteCommand("select   Name,TransactionType,AmountPaid, Balance, Date from accountable where Name Like '%" + TextBoxIsearch.Text + "%'", connection)


                    da = New SQLiteDataAdapter(cmd)
                    ds = New DataSet
                    da.Fill(ds, "accountable")
                    DataGridViewDAILYSUMMARY.DataSource = ds
                    DataGridViewDAILYSUMMARY.DataMember = "accountable"
                    cmd.Dispose()
                    ds.Dispose()
                    connection.Close()

                Case "Recieve Payment From Student"


                    connect()
                    cmd = New SQLiteCommand("select StudentID,Surname , Othernames,Class,TotalFees,AmountPaid, BalancePayment, Date from studentable where Surname like '%" + TextBoxIsearch.Text + "%'", connection)


                    da = New SQLiteDataAdapter(cmd)
                    ds = New DataSet
                    da.Fill(ds, "studentable")
                    DataGridViewDAILYSUMMARY.DataSource = ds
                    DataGridViewDAILYSUMMARY.DataMember = "studentable"
                    cmd.Dispose()
                    ds.Dispose()
                    connection.Close()

                Case "SalaryPayment"


                    connect()
                    cmd = New SQLiteCommand("select StaffID,Surname , Othername,Designation,NetPay, Passport, Date from payrolltable2 where Surname like '%" + TextBoxIsearch.Text + "%'", connection)


                    da = New SQLiteDataAdapter(cmd)
                    ds = New DataSet
                    da.Fill(ds, " payrolltable2")
                    DataGridViewDAILYSUMMARY.DataSource = ds
                    DataGridViewDAILYSUMMARY.DataMember = " payrolltable2"
                    cmd.Dispose()
                    ds.Dispose()
                    connection.Close()

                    ' code to search the combobox
                    Dim index As Integer
                    'index = ComboBoxinfo.FindString(TextBoxIsearch.Text)
                   ' ComboBoxinfo.SelectedIndex = index

                Case "Record Expenses"


                    connect()
                    cmd = New SQLiteCommand("select * from expenditure where Authorizer like '%" + TextBoxIsearch.Text + "%'", connection)


                    da = New SQLiteDataAdapter(cmd)
                    ds = New DataSet
                    da.Fill(ds, "expenditure")
                    DataGridViewDAILYSUMMARY.DataSource = ds
                    DataGridViewDAILYSUMMARY.DataMember = "expenditure"
                    cmd.Dispose()
                    ds.Dispose()
                    connection.Close()



                    'code to search the combobox
                    ' Dim index As Integer
                    ' Index = GunaComboBoxname.FindString(TextBoxIsearch.Text)
                    ' GunaComboBoxname.SelectedIndex = index
            End Select


        Catch ex As Exception
            MessageBox.Show("Record not found,make sure you spelt then name of item correctly")
        End Try

        If ComboBoxoption.Text = "SchoolMall" Then
            connect()
            cmd = New SQLiteCommand("select ItemID,ItemName,Discription,Quantity,SalesPrice,TotalItemOut, Date from storetable where ItemName like '%" + TextBoxIsearch.Text + "%'", connection)


            da = New SQLiteDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "storetable")
            DataGridViewDAILYSUMMARY.DataSource = ds
            DataGridViewDAILYSUMMARY.DataMember = "storetable"
            cmd.Dispose()
            ds.Dispose()
            connection.Close()

        End If
    End Sub
    Private Sub DataGridViewDAILYSUMMARY_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDAILYSUMMARY.CellClick


        Try
            'displaying the selectedd or clicked datagrid row on the text box
            Dim selectedgr As DataGridViewRow
            Dim makepayment As DataGridViewRow
            makepayment = DataGridViewDAILYSUMMARY.Rows(e.RowIndex)
            selectedgr = DataGridViewDAILYSUMMARY.Rows(e.RowIndex)


            Select Case ComboBoxoption.Text
                Case " Mesc. Transaction"
                    GunaTransfarantPictureBox2.Visible = False
                    ' TextBoxid.Text = selectedgr.Cells(0).Value
                    TextBoxName.Text = selectedgr.Cells(0).Value
                    TextBoxclass.Text = selectedgr.Cells(1).Value
                    TextBoxAMT.Text = selectedgr.Cells(2).Value
                    ' Labeltfes.Text = selectedgr.Cells().Value
                    LabelBALQTY.Text = selectedgr.Cells(3).Value
                ' LabelDAILYINCOM.Text = selectedgr.Cells(5).Value
                'LabelTTLEXP.Text = selectedgr.Cells(6).Value
                ' LabelBAL.Text = selectedgr.Cells(6).Value

                Case "Recieve Payment From Student"
                    GunaTransfarantPictureBox2.Visible = False
                    TextBoxid.Text = selectedgr.Cells(0).Value
                    TextBoxName.Text = selectedgr.Cells(2).Value
                    TextBoxclass.Text = selectedgr.Cells(3).Value
                    TextBoxAMT.Text = selectedgr.Cells(5).Value
                    Labeltfes.Text = selectedgr.Cells(4).Value
                    LabelBALQTY.Text = selectedgr.Cells(6).Value

                    If LabelBALQTY.Text = 0 Then
                        Labelremark.Show()
                        Labelremark.Text = "PAID"

                    End If

                '  GunaTransfarantPictureBox2.Image = selectedgr.Cells(7).Clone
                Case "SalaryPayment"
                    GunaTransfarantPictureBox2.Visible = True
                    'image convertion for display sake
                    Dim bytes As [Byte]() = DataGridViewDAILYSUMMARY.CurrentRow.Cells(5).Value 'converting image to byte 
                    Dim ms As New MemoryStream(bytes) ' parsing byte into memorystream image dispaly
                    GunaTransfarantPictureBox2.Image = Image.FromStream(ms) 'image dispaly onto the picture box


                    TextBoxid.Text = makepayment.Cells(0).Value
                    TextBoxName.Text = makepayment.Cells(1).Value
                    TextBoxclass.Text = makepayment.Cells(2).Value
                    'TextBoxAMT.Text = makepayment.Cells(3).Value
                    Labeltfes.Text = makepayment.Cells(4).Value
                    LabelBALQTY.Text = makepayment.Cells(5).Value

                Case "Record Expenses"
                    GunaTransfarantPictureBox2.Visible = False
                    TextBoxid.Text = makepayment.Cells(6).Value
                    TextBoxName.Text = makepayment.Cells(1).Value
                    TextBoxclass.Text = makepayment.Cells(2).Value
                    TextBoxAMT.Text = makepayment.Cells(3).Value
                    TextBox1.Text = makepayment.Cells(4).Value
                    TextBox2.Text = makepayment.Cells(5).Value


                Case "SchoolMall"
                    GunaTransfarantPictureBox2.Visible = False
                    TextBoxid.Text = makepayment.Cells(0).Value
                    TextBoxName.Text = makepayment.Cells(1).Value
                    'TextBoxclass.Text = makepayment.Cells().Value
                    GunaLabelPrc.Text = makepayment.Cells(4).Value
                    ' TextBox1.Text = makepayment.Cells(4).Value
                    'TextBox2.Text = makepayment.Cells(5).Value
                    Labeltfes.Text = makepayment.Cells(3).Value
                    LabelBALQTY.Text = makepayment.Cells(5).Value
                    Label6.Text = " Total Qty Out"

                Case Else
                    MsgBox("Please select what you want to do from the combobox above")
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to Close this Page?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
        Else
            Application.Exit()

        End If

    End Sub

    Private Sub StaffsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffsToolStripMenuItem.Click
        STAFFOGER.GunaButton2.Visible = False
        STAFFOGER.GunaButton7.Visible = True
        STAFFOGER.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        STUDENGER.Show()
    End Sub

    Private Sub SToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ViewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProfileToolStripMenuItem.Click
        STAFFOGER.GunaButton2.Visible = True
        STAFFOGER.GunaButton7.Visible = False

        STAFFOGER.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem.Click
        STAFFOGER.Show()
    End Sub

    Private Sub PayRollToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PayRollToolStripMenuItem1.Click
        PAYROLLGER.Show()
        PAYROLLGER .GunaButton2 .Visible = true 
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



    Private Sub PaymentRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentRecordToolStripMenuItem.Click
        viewData()

    End Sub

    Private Sub Labeltfees_Click(sender As Object, e As EventArgs) Handles Labeltfees.Click

    End Sub

    Private Sub ButtonCAL_Click(sender As Object, e As EventArgs) Handles ButtonCAL.Click
        If ComboBoxoption.Text = "Choose  What To Do" Then
            MsgBox("Please select the Operation to be carried out from the Combobox above")
        Else


            ' Dim result As DialogResult
            'result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            ' If result = DialogResult.No Then

            'Else

            Dim result2 As DialogResult
            result2 = MessageBox.Show("Are you Sure you want to carry out  this Operation?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result2 = DialogResult.No Then

            Else
                Try
                    connect()


                    Dim qtystk As Integer = CInt(Labeltfes.Text)

                    If qtystk <= 0 Then

                        Dim reminder As DialogResult = MessageBox.Show("You have run out of this stock please contact your Admin", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                        If reminder = DialogResult.OK Then
                            TextBoxAMT.Clear()
                        Else

                        End If

                    End If
                Catch ex As Exception

                End Try
                Try



                    'this will reduce the quantity of stock in database(admintable.Quantity) as it is being sold by quantity on the textboxqty


                    'computing the sales and the amounts
                    Dim AMOUNT As Double
                    ' Dim TTFES As Double
                    Dim subtotal As Double

                    If TextBoxAMT.Text.Trim() = "" Or TextBoxName.Text.Trim() = "" Then
                        MessageBox.Show("PLEASE FILL ALL THE FIELDS TO PROCEED", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        TextBoxAMT.Focus()
                        TextBoxid.Focus()
                        TextBoxName.Focus()


                    ElseIf ComboBoxoption.Text = "Recieve Payment From Student" Or ComboBoxoption.Text = " Mesc. Transaction" Then
                        'converting input data to proper data types and into variable
                        AMOUNT = Val(TextBoxAMT.Text)
                        ' TTFES = Double.Parse(Labeltfees.Text)

                        'performing calculation
                        subtotal = AMOUNT
                        LabelTTLAMT.Text = subtotal.ToString("")


                        'coding for  the accumalation grandtotal
                        ' accum += subtotal
                        'Labelgrdtotal.Text = accum.ToString("c")
                        'accumulation for daily sales
                        accumdailyINCOME += subtotal
                        LabelDAILYINCOM.Text = accumdailyINCOME.ToString("")

                        'calculating for the balance
                        Dim ttds As Double
                        Dim ttexp As Double
                        Dim bala As Double


                        ttds = CDbl(LabelDAILYINCOM.Text)
                        ttexp = CDbl(LabelTTLEXP.Text)
                        bala = ttds - ttexp
                        LabelBAL.Text = System.Convert.ToString(bala)
                        LabelBAL.Text = bala.ToString("")

                        'calculating the balance
                        Dim tfess As Double
                        Dim ttamt As Double


                        tfess = CDbl(Labeltfes.Text)
                        ttamt = CDbl(TextBoxAMT.Text)
                        bala = tfess - ttamt
                        LabelBALQTY.Text = System.Convert.ToString(bala)
                        LabelBALQTY.Text = bala.ToString("")

                    End If
                Catch ex As Exception

                End Try

                Try

                    If ComboBoxoption.Text = "SalaryPayment" Or ComboBoxoption.Text = "Record Expenses" Then

                        'accumualating for the total expenses

                        Dim textamt As Double

                        'conversion

                        textamt = Val(TextBoxAMT.Text)

                        'acumulating the total expenses from expenses book  to labettlexp in form1
                        acexp += textamt
                        LabelTTLEXP.Text = acexp.ToString("")
                        ' daily bal
                        Dim ttds As Double
                        Dim ttexp As Double
                        Dim bal As Double


                        ttds = CDbl(LabelDAILYINCOM.Text)
                        ttexp = CDbl(LabelTTLEXP.Text)
                        bal = ttds - ttexp
                        LabelBAL.Text = System.Convert.ToString(bal)
                        LabelBAL.Text = bal.ToString("")


                        'calculating the balance pay
                        Dim tfes As Double
                        Dim ttamt As Double

                        tfes = CDbl(Labeltfes.Text)
                        ttamt = CDbl(TextBoxAMT.Text)
                        bal = tfes - ttamt
                        LabelBALQTY.Text = System.Convert.ToString(bal)
                        LabelBALQTY.Text = bal.ToString("")


                    ElseIf ComboBoxoption.Text = "SchoolMall" Then
                        Dim AMOUNT2 As Double
                        ' Dim TTFES As Double
                        Dim subtotal2 As Double

                        'converting input data to proper data types and into variable
                        AMOUNT2 = Val(TextBoxAMT.Text)
                        Dim qty As Double = Val(GunaLabelPrc.Text)
                        ' TTFES = Double.Parse(Labeltfees.Text)

                        'performing calculation
                        subtotal2 = AMOUNT2 * qty
                        LabelTTLAMT.Text = subtotal2.ToString("")


                        'coding for  the accumalation grandtotal
                        accum += subtotal2
                        Labelgtl.Text = accum.ToString("")
                        'accumulation for daily sales
                        accumdailyINCOME += subtotal2
                        LabelDAILYINCOM.Text = accumdailyINCOME.ToString("")

                        'calculating for the balance
                        Dim ttds As Double
                        Dim ttexp As Double
                        Dim bal As Double


                        ttds = CDbl(LabelDAILYINCOM.Text)
                        ttexp = CDbl(LabelTTLEXP.Text)
                        bal = ttds - ttexp
                        LabelBAL.Text = System.Convert.ToString(bal)
                        LabelBAL.Text = bal.ToString("")

                        'calculating the balance
                        Dim tfes As Double
                        Dim ttamt As Double


                        tfes = CDbl(Labeltfes.Text)
                        ttamt = CDbl(TextBoxAMT.Text)
                        bal = tfes - ttamt
                        LabelBALQTY.Text = System.Convert.ToString(bal)
                        LabelBALQTY.Text = bal.ToString("")

                    End If

                Catch ex As Exception

                End Try

                ' Try


                'If ComboBoxoption.Text = "SchoolMall" Or ComboBoxoption.Text = "Mesc. Transaction " Or ComboBoxoption.Text = "Recieve Payment From Student" Then

                'Using cmd As New SQLiteCommand("UPDATE accountable SET DailyIncome =di, TotalExpenses =@texp ,DailyBalance = @Db  WHERE Date = @dt", connection)
                'cmd.Parameters.AddWithValue("@di", LabelDAILYINCOM.Text)
                'cmd.Parameters.AddWithValue("@texp", LabelTTLEXP.Text)
                'cmd.Parameters.AddWithValue("@Db", LabelBAL.Text)
                'cmd.Parameters.AddWithValue("@dt", GunaDateTimePicker1.Text)
                'cmd.ExecuteNonQuery()
                'End Using
                'End If
                'Catch ex As Exception

                ' End Try



                Try
                    GunaDateTimePicker1.Value = DateTime.Now
                    If ComboBoxoption.Text = "SchoolMall" Then

                        Using cmd As New SQLiteCommand("UPDATE storetable SET Quantity = Quantity - @QU, TotalItemOut = TotalItemOut + @out, Date = @date  WHERE ItemName = @IN", connection)
                            cmd.Parameters.AddWithValue("@QU", TextBoxAMT.Text)
                            cmd.Parameters.AddWithValue("@out", TextBoxAMT.Text)
                            cmd.Parameters.AddWithValue("@IN", TextBoxName.Text)
                            cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Value)
                            cmd.ExecuteNonQuery()
                        End Using


                    ElseIf ComboBoxoption.Text = "Recieve Payment From Student" Then
                        Using cmd As New SQLiteCommand("UPDATE studentable SET AmountPaid = AmountPaid + @pd,  BalancePayment = (TotalFees - (AmountPaid+@atp)), Date = @dte  WHERE StudentID = @Id", connection)
                            cmd.Parameters.AddWithValue("@pd", TextBoxAMT.Text)

                            cmd.Parameters.AddWithValue("@atp", TextBoxAMT.Text)
                            cmd.Parameters.AddWithValue("@id", TextBoxid.Text)
                            cmd.Parameters.AddWithValue("@dte", GunaDateTimePicker1.Value)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Catch ex As Exception
                End Try

                ' insertion into the database 
                Try
                    connect()

                    If TextBoxAMT.Text = "0.00" Then
                        MsgBox("Please Enter Value into the Amount Box")

                    Else
                        TextBoxAMT.Focus()




                        Dim amt As Double = CDbl(TextBoxAMT.Text)
                        Dim tfes As Double = Val(Labeltfes.Text)
                        Dim cls As String = TextBoxclass.Text
                        Dim dlcom As Double = Val(LabelDAILYINCOM.Text)
                        Dim texp As Double = Val(LabelTTLEXP.Text)
                        Dim bal As Double = Val(LabelBALQTY.Text)
                        Dim dbal As Double = Val(LabelBAL.Text)
                        Dim ntsal As Double = Val(Labeltfes.Text)
                        Dim dsg As String = TextBoxclass.Text
                        Dim trans As String = TextBoxclass.Text


                        Select Case ComboBoxoption.Text

                'insert into accountable
                            Case " Mesc. Transaction"
                                GunaDateTimePicker1.Value = DateTime.Now



                                Dim cmd As New SQLiteCommand

                                cmd.Connection = connection
                                cmd.CommandText = " Insert into accountable (Name, TransactionType,AmountPaid,  Balance, DailyIncome, TotalExpenses,DailyBalance, Date) Values(@nm,@trans,  @amt,@bal,  @dlcom, @texp, @dbal, @date)"
                                cmd.Parameters.AddWithValue("@nm", TextBoxName.Text).ToString()

                                cmd.Parameters.AddWithValue("@trans", trans)
                                cmd.Parameters.AddWithValue("@amt", amt)
                                'cmd.Parameters.AddWithValue("@tfes", tfes)

                                cmd.Parameters.AddWithValue("@bal", bal)
                                cmd.Parameters.AddWithValue("@dlcom", dlcom)
                                cmd.Parameters.AddWithValue("@texp", texp)
                                cmd.Parameters.AddWithValue("@dbal", dbal)
                                cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Value)



                                Dim recadd As Integer = cmd.ExecuteNonQuery()
                                connection.Close()
                                MsgBox("Transaction has been saved successfully")


                                showData()


                                TextBoxAMT.Text = "0.00"
                                'insert into  accountablestudent

                                Exit Sub
                        'insert into accountablestaff


                            Case "Recieve Payment From Student"
                                Dim cmd As New SQLiteCommand




                                cmd.Connection = connection
                                cmd.CommandText = " Insert into accountable (StudentName,Class,PaidAmount ,TotalFees,Balances, Date, DailyIncome,TotalExpenses,DailyBalance )
Values(@snm,@cls,  @amt, @tfs,@bal, @date, @dinc,@texp,@dbal)"
                                cmd.Parameters.AddWithValue("@snm", TextBoxName.Text)
                                cmd.Parameters.AddWithValue("@cls", TextBoxclass.Text)
                                cmd.Parameters.AddWithValue("@amt", TextBoxAMT.Text)
                                cmd.Parameters.AddWithValue("@tfs", Labeltfes.Text)
                                cmd.Parameters.AddWithValue("@bal", LabelBALQTY.Text)
                                cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Value)
                                cmd.Parameters.AddWithValue("@dinc", LabelDAILYINCOM.Text)
                                cmd.Parameters.AddWithValue("@texp", LabelTTLEXP.Text)
                                cmd.Parameters.AddWithValue("@dbal", LabelBAL.Text)


                                Dim recadd As Integer = cmd.ExecuteNonQuery()
                                connection.Close()
                                MsgBox("Payment Recieved and Updated successfully")


                                displayData()
                                Exit Sub


                                TextBoxAMT.Text = "0.00"

                            Case "SalaryPayment"


                                '
                                Dim cmd As New SQLiteCommand

                                cmd.Connection = connection
                                cmd.CommandText = " Insert into accountablestaff (StaffName, Designation,Amount ,NetSalary, Balance, Date) Values(@nm,@dsg,  @amt, @ntsal,@bal, @date)"
                                cmd.Parameters.AddWithValue("@nm", TextBoxName.Text)
                                cmd.Parameters.AddWithValue("@dsg", TextBoxclass.Text)
                                cmd.Parameters.AddWithValue("@amt", TextBoxAMT.Text)
                                cmd.Parameters.AddWithValue("@ntsal", Labeltfes.Text)
                                cmd.Parameters.AddWithValue("@bal", LabelBALQTY.Text)
                                cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Value)



                                Dim recadd As Integer = cmd.ExecuteNonQuery()
                                connection.Close()
                                MsgBox(" Record has been saved successfully")


                                TextBoxAMT.Text = "0.00"



                            Case "Record Expenses"


                                Dim cmd As New SQLiteCommand

                                cmd.Connection = connection
                                cmd.CommandText = " Insert into expenditure (Authorizer, Designtion,Amount ,Purpose,Discription, Date) Values(@nm,@dsg,  @amt, @pse,@dis,@date)"
                                cmd.Parameters.AddWithValue("@nm", TextBoxName.Text)
                                cmd.Parameters.AddWithValue("@dsg", dsg)
                                cmd.Parameters.AddWithValue("@amt", amt)
                                cmd.Parameters.AddWithValue("@pse", TextBox1.Text)
                                cmd.Parameters.AddWithValue("@dis", TextBox2.Text)
                                cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Value)

                                Dim recadd As Integer = cmd.ExecuteNonQuery()
                                connection.Close()
                                MsgBox("Transaction has completed successfully")

                                ExpData()


                                TextBoxAMT.Text = "0.00"
                            Case "SchoolMall"
                                Label6.Text = "Balance Qty"

                                Dim cmd As New SQLiteCommand

                                cmd.Connection = connection
                                cmd.CommandText = " Insert into accountable (ItemName, Quantity,Price ,TotalAmount,DailyIncome,TotalExpenses,DailyBalance,Date)
Values(@inm,@qty,  @pric, @tamt,@dicom,@texp,@dbal,@date)"
                                cmd.Parameters.AddWithValue("@inm", TextBoxName.Text)
                                cmd.Parameters.AddWithValue("@qty", TextBoxAMT.Text)
                                cmd.Parameters.AddWithValue("@pric", GunaLabelPrc.Text)
                                cmd.Parameters.AddWithValue("@tamt", Labelgtl.Text)
                                cmd.Parameters.AddWithValue("@dicom", LabelDAILYINCOM.Text)
                                cmd.Parameters.AddWithValue("@texp", LabelTTLEXP.Text)
                                cmd.Parameters.AddWithValue("@dbal", LabelBAL.Text)
                                cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Value)
                                Dim recadd As Integer = cmd.ExecuteNonQuery()
                                connection.Close()
                                MsgBox("Your Record has been saved successfully")

                                reviewData()

                                TextBoxAMT.Text = "0.00"

                            Case "Choose  What To Do"



                                MsgBox("Please Select the operation you want to carry from the Combobox!! ", MessageBoxIcon.Information, "Error")


                        End Select



                    End If

                Catch ex As Exception
                    MsgBox("Ooops!!! An Error has Occured Please Check that all your entries are correct")

                End Try
            End If
        End If


    End Sub

    Private Sub ButtonRESET_Click(sender As Object, e As EventArgs) Handles ButtonRESET.Click
        Dim result As DialogResult

        connect()

        Try

            If GunaLineTextBoxdel.Text = "ID or Name To Del" Then
                MsgBox("Please make sure you entered the ID Or the Name Of the candidate to be Deleted, Hint: You only type Name when Deleting from account table")
            Else
                If TABLE_ANALYSIS.GunaRadioButtonact.Checked Then
                    'If ComboBoxoption.Text = " Mesc. Transaction" Then

                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from  accountable where Name = @id"
                        cmd.Parameters.AddWithValue("@id", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")
                        DataGridViewDAILYSUMMARY.Refresh()
                        connection.Close()


                        DataGridViewDAILYSUMMARY.Refresh()
                        showData()

                        Exit Sub

                    End If


                ElseIf TABLE_ANALYSIS.GunaRadioButtonexp.Checked Then


                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from  expenditure  where ID = @id"
                        cmd.Parameters.AddWithValue("@id", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")
                        DataGridViewDAILYSUMMARY.Refresh()
                        connection.Close()
                        DataGridViewDAILYSUMMARY.Refresh()
                        ExpData()
                        Exit Sub
                    End If

                ElseIf TABLE_ANALYSIS.GunaRadioButtonstp.Checked Then

                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from accountablestaff  where StaffID = @id"
                        cmd.Parameters.AddWithValue("@id", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")


                        connection.Close()

                        DataGridViewDAILYSUMMARY.Refresh()
                        viewData()

                        Exit Sub

                    End If
                ElseIf TABLE_ANALYSIS.GunaRadioButton5.Checked Then

                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from accountable  where DailyIncome = @id"
                        cmd.Parameters.AddWithValue("@id", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")
                        DataGridViewDAILYSUMMARY.Refresh()
                        connection.Close()
                        DataGridViewDAILYSUMMARY.Refresh()
                        showData()

                        Exit Sub

                    End If


                End If
            End If

        Catch ex As Exception
            MsgBox("Oops!! An Error has Occured, Please Ensure you type the ID of  the RECORD to be Deleted if the error continues type the full name of the candidate")
        End Try
        Dim combo As String = ComboBoxoption.Text


        Try
            Select Case combo
                Case "Recieve Payment From Student"
                    'If ComboBoxoption.Text = " Mesc. Transaction" Then

                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from  studentable where StudentID = @Nm"
                        cmd.Parameters.AddWithValue("@Nm", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")
                        DataGridViewDAILYSUMMARY.Refresh()
                        connection.Close()
                        displayData()

                    End If

                Case " SchoolMall"

                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from  storetable where ItemName = @Nm"
                        cmd.Parameters.AddWithValue("@Nm", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")
                        DataGridViewDAILYSUMMARY.Refresh()
                        connection.Close()
                        reviewData()
                    End If

                Case "SalaryPayment"
                    result = MessageBox.Show("Are you Sure you want to Delete this Record? Note that this Record And its content will be removed from the database", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.No Then
                    Else
                        Dim cmd As New SQLiteCommand
                        cmd.Connection = connection
                        cmd.CommandText = "Delete from  table where ItemName = @Nm"
                        cmd.Parameters.AddWithValue("@Nm", GunaLineTextBoxdel.Text)
                        Dim msg As Integer = cmd.ExecuteNonQuery()
                        MsgBox(msg & "Record was deleted successfully")
                        DataGridViewDAILYSUMMARY.Refresh()
                        connection.Close()
                    End If


            End Select
        Catch ex As Exception

        End Try

    End Sub
    Private bitmap As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim height As Integer = DataGridViewDAILYSUMMARY.Height
        DataGridViewDAILYSUMMARY.Height = DataGridViewDAILYSUMMARY.RowCount * DataGridViewDAILYSUMMARY.RowTemplate.Height
        bitmap = New Bitmap(Me.DataGridViewDAILYSUMMARY.Width, Me.DataGridViewDAILYSUMMARY.Height)
        DataGridViewDAILYSUMMARY.DrawToBitmap(bitmap, New Rectangle(1, 1, Me.DataGridViewDAILYSUMMARY.Width, Me.DataGridViewDAILYSUMMARY.Height))
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
        DataGridViewDAILYSUMMARY.Height = height





    End Sub

    Private Sub RecievePaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        STUDENGER.GunaButton7.Visible = True
        STUDENGER.GunaButton2.Visible = False
        STUDENGER.Show()

    End Sub

    Private Sub UpdateProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UpdateProfileToolStripMenuItem1.Click
        STAFFOGER.GunaButton2.Visible = False
        STAFFOGER.GunaButton7.Visible = True
        STAFFOGER.Show()
    End Sub

    Private Sub CompanysNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanysNameToolStripMenuItem.Click

        Company_Name.Show()


    End Sub

    Private Sub ButtonCLEAR_Click(sender As Object, e As EventArgs) Handles ButtonCLEAR.Click

        TextBoxName.Text = ""
        TextBoxclass.Text = ""
        TextBoxAMT.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        Labeltfes.Text = ""
        LabelBALQTY.Text = ""






    End Sub

    Private Sub ComboBoxinfo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim READER As SQLiteDataReader
        'populating from the studentable's into combobox
        connect()


        ' If ComboBoxinfo.Text = "SalaryPayment" Then
        'Populating data from the combobox to controls


        Dim cmd As SQLiteCommand = connection.CreateCommand
        cmd.CommandType = CommandType.Text
        ' cmd.CommandText = "select  *  from payrolltable2 where Othername = '" & ComboBoxinfo.Text & "'"
            READER = cmd.ExecuteReader
        If READER.HasRows Then

            While READER.Read

                TextBoxName.Text = (READER("Othername"))
                TextBoxclass.Text = (READER("Designation"))
                Labeltfes.Text = (READER("NetPay"))
                '  Dim bytes As [Byte]() = ComboBoxinfo.SelectedItem.Cells(5).Value 'converting image to byte 
                ' Dim ms As New MemoryStream(bytes) ' parsing byte into memorystream image dispaly
                'GunaTransfarantPictureBox2.Image = Image.FromStream(ms) 'image dispaly onto the picture box
                ' GunaTextBox.Text = (READER("BulkPrice"))
                ' GunaTextBoxuntpr.Text = (READER("UnitPrice"))

                'GunaTextBoxsal.Text = (READER("SalesPrice"))
                ' GunaLabelprof.Text = (READER("ExpectedProfits"))
                ' GunaLabel1.Text = (READER("TotalItemOut"))
            End While

            READER.Close()
            connection.Close()
        End If
        '  End If
        ' Catch ex As Exception



        ' End Try

    End Sub

    Private Sub ComboBoxinfo2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RegisterUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterUserToolStripMenuItem.Click
        RegisterUsers.Show()
    End Sub

    Private Sub SchoolMallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolMallToolStripMenuItem.Click
        Remove_User.Show()
    End Sub

    Private Sub Buttonlout_Click(sender As Object, e As EventArgs) Handles Buttonlout.Click
        Me.Hide()

        Login.Show()
        ' Login.GunaTextBoxusn.Text = " Username"
        ' Login.GunaTextBoxpsw.Text = "Passward"

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(bitmap, 0, 0)
        Dim rectprint As RectangleF = e.PageSettings.PrintableArea
        'change the height of to width if printing in landscape mode
        If Me.DataGridViewDAILYSUMMARY.Height - rectprint.Height > 0 Then
            e.HasMorePages = True
        End If
    End Sub

    Private Sub GunaTransfarantPictureBox1_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox1.Click

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        Try
            connect()


            Dim qtystk As Integer = CInt(Labeltfes.Text)

            If qtystk <= 0 Then

                Dim reminder As DialogResult = MessageBox.Show("You have run out of this stock please contact your Admin", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                If reminder = DialogResult.OK Then
                    TextBoxAMT.Clear()
                Else
                    TextBoxAMT.Clear()
                End If

            End If
        Catch ex As Exception

        End Try


        Try




            'this will reduce the quantity of stock in database(admintable.Quantity) as it is being sold by quantity on the textboxqty


            'computing the sales and the amounts
            Dim AMOUNT As Double
            ' Dim TTFES As Double
            Dim subtotal As Double

            If TextBoxAMT.Text.Trim() = "" Or TextBoxName.Text.Trim() = "" Then
                MessageBox.Show("PLEASE FILL ALL THE FIELDS TO PROCEED", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                TextBoxAMT.Focus()
                TextBoxid.Focus()
                TextBoxName.Focus()


            ElseIf ComboBoxoption.Text = "Recieve Payment From Student" Or ComboBoxoption.Text = " Mesc. Transaction" Then
                'converting input data to proper data types and into variable
                AMOUNT = Val(TextBoxAMT.Text)
                ' TTFES = Double.Parse(Labeltfees.Text)

                'performing calculation
                subtotal = AMOUNT
                LabelTTLAMT.Text = subtotal.ToString("")


                'coding for  the accumalation grandtotal
                ' accum += subtotal
                'Labelgrdtotal.Text = accum.ToString("c")
                'accumulation for daily sales
                accumdailyINCOME += subtotal
                LabelDAILYINCOM.Text = accumdailyINCOME.ToString("")

                'calculating for the balance
                Dim ttds As Double
                Dim ttexp As Double
                Dim bala As Double


                ttds = CDbl(LabelDAILYINCOM.Text)
                ttexp = CDbl(LabelTTLEXP.Text)
                bala = ttds - ttexp
                LabelBAL.Text = System.Convert.ToString(bala)
                LabelBAL.Text = bala.ToString("")

                'calculating the balance
                Dim tfess As Double
                Dim ttamt As Double


                tfess = CDbl(Labeltfes.Text)
                ttamt = CDbl(TextBoxAMT.Text)
                bala = tfess - ttamt
                LabelBALQTY.Text = System.Convert.ToString(bala)
                LabelBALQTY.Text = bala.ToString("")

            End If
        Catch ex As Exception

        End Try

        Try

            If ComboBoxoption.Text = "SalaryPayment" Or ComboBoxoption.Text = "Record Expenses" Then

                'accumualating for the total expenses

                Dim textamt As Double

                'conversion

                textamt = Val(TextBoxAMT.Text)

                'acumulating the total expenses from expenses book  to labettlexp in form1
                acexp += textamt
                LabelTTLEXP.Text = acexp.ToString("")
                ' daily bal
                Dim ttds As Double
                Dim ttexp As Double
                Dim bal As Double


                ttds = CDbl(LabelDAILYINCOM.Text)
                ttexp = CDbl(LabelTTLEXP.Text)
                bal = ttds - ttexp
                LabelBAL.Text = System.Convert.ToString(bal)
                LabelBAL.Text = bal.ToString("")


                'calculating the balance pay
                Dim tfes As Double
                Dim ttamt As Double

                tfes = CDbl(Labeltfes.Text)
                ttamt = CDbl(TextBoxAMT.Text)
                bal = tfes - ttamt
                LabelBALQTY.Text = System.Convert.ToString(bal)
                LabelBALQTY.Text = bal.ToString("")


            ElseIf ComboBoxoption.Text = "SchoolMall" Then
                Dim AMOUNT2 As Double
                ' Dim TTFES As Double
                Dim subtotal2 As Double

                'converting input data to proper data types and into variable
                AMOUNT2 = Val(TextBoxAMT.Text)
                Dim qty As Double = Val(GunaLabelPrc.Text)
                ' TTFES = Double.Parse(Labeltfees.Text)

                'performing calculation
                subtotal2 = AMOUNT2 * qty
                LabelTTLAMT.Text = subtotal2.ToString("")


                'coding for  the accumalation grandtotal
                accum += subtotal2
                Labelgtl.Text = accum.ToString("")
                'accumulation for daily sales
                accumdailyINCOME += subtotal2
                LabelDAILYINCOM.Text = accumdailyINCOME.ToString("")

                'calculating for the balance
                Dim ttds As Double
                Dim ttexp As Double
                Dim bal As Double


                ttds = CDbl(LabelDAILYINCOM.Text)
                ttexp = CDbl(LabelTTLEXP.Text)
                bal = ttds - ttexp
                LabelBAL.Text = System.Convert.ToString(bal)
                LabelBAL.Text = bal.ToString("")

                'calculating the balance
                Dim tfes As Double
                Dim ttamt As Double


                tfes = CDbl(Labeltfes.Text)
                ttamt = CDbl(TextBoxAMT.Text)
                bal = tfes - ttamt
                LabelBALQTY.Text = System.Convert.ToString(bal)
                LabelBALQTY.Text = bal.ToString("")

            End If

        Catch ex As Exception

        End Try

        ' insertion into the database 
        Try
            connect()

            If TextBoxAMT.Text = "0.00" Then
                MsgBox("Please Enter Value into the Amount Box")

            Else
                TextBoxAMT.Focus()




                Dim amt As Double = CDbl(TextBoxAMT.Text)
                Dim tfes As Double = Val(Labeltfes.Text)
                Dim cls As String = TextBoxclass.Text
                Dim dlcom As Double = Val(LabelDAILYINCOM.Text)
                Dim texp As Double = Val(LabelTTLEXP.Text)
                Dim bal As Double = Val(LabelBALQTY.Text)
                Dim dbal As Double = Val(LabelBAL.Text)
                Dim ntsal As Double = Val(Labeltfes.Text)
                Dim dsg As String = TextBoxclass.Text
                Dim trans As String = TextBoxclass.Text


                Select Case ComboBoxoption.Text

                'insert into accountable
                    Case " Mesc. Transaction"

                        Dim result As DialogResult
                        result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.No Then


                        Else

                            Dim cmd As New SQLiteCommand

                            cmd.Connection = connection
                            cmd.CommandText = " Insert into accountable (Name, TransactionType,AmountPaid,  Balance, DailyIncome, TotalExpenses,DailyBalance) Values(@nm,@trans,  @amt,@bal,  @dlcom, @texp, @dbal)"
                            cmd.Parameters.AddWithValue("@nm", TextBoxName.Text).ToString()

                            cmd.Parameters.AddWithValue("@trans", trans)
                            cmd.Parameters.AddWithValue("@amt", amt)
                            'cmd.Parameters.AddWithValue("@tfes", tfes)

                            cmd.Parameters.AddWithValue("@bal", bal)
                            cmd.Parameters.AddWithValue("@dlcom", dlcom)
                            cmd.Parameters.AddWithValue("@texp", texp)
                            cmd.Parameters.AddWithValue("@dbal", dbal)




                            Dim recadd As Integer = cmd.ExecuteNonQuery()
                            connection.Close()
                            MsgBox("Your Transaction has been completed successfully")



                        End If
                        TextBoxAMT.Text = "0.00"
                        'insert into  accountablestudent

                        Exit Sub
                'insert into accountablestaff



                    Case "Recieve Payment From Student"
                        Dim cmd As New SQLiteCommand
                        Dim result As DialogResult
                        result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.No Then

                        Else

                            cmd.Connection = connection
                            cmd.CommandText = " Insert into accountablestudent (Name,Class,AmountPaid ,TotalFees,Balance)
Values(@snm,@cls,  @amt, @tfs,@bal)"
                            cmd.Parameters.AddWithValue("@snm", TextBoxName.Text)
                            cmd.Parameters.AddWithValue("@cls", TextBoxclass.Text)
                            cmd.Parameters.AddWithValue("@amt", TextBoxAMT.Text)
                            cmd.Parameters.AddWithValue("@tfs", Labeltfes.Text)
                            cmd.Parameters.AddWithValue("@bal", LabelBALQTY.Text)


                            Dim recadd As Integer = cmd.ExecuteNonQuery()
                            connection.Close()
                            MsgBox("Your Recieved successfully")

                        End If
                        TextBoxAMT.Text = "0.00"

                    Case "SalaryPayment"



                        Dim result As DialogResult
                        result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.No Then
                        Else
                            '
                            Dim cmd As New SQLiteCommand

                            cmd.Connection = connection
                            cmd.CommandText = " Insert into accountablestaff (StaffName, Designation,Amount ,NetSalary, Balance) Values(@nm,@dsg,  @amt, @ntsal,@bal)"
                            cmd.Parameters.AddWithValue("@nm", TextBoxName.Text)
                            cmd.Parameters.AddWithValue("@dsg", TextBoxclass.Text)
                            cmd.Parameters.AddWithValue("@amt", TextBoxAMT.Text)
                            cmd.Parameters.AddWithValue("@ntsal", Labeltfes.Text)
                            cmd.Parameters.AddWithValue("@bal", LabelBALQTY.Text)


                            Dim recadd As Integer = cmd.ExecuteNonQuery()
                            connection.Close()
                            MsgBox("Your Payment made successfully")

                        End If
                        TextBoxAMT.Text = "0.00"



                    Case "Record Expenses"
                        Dim result As DialogResult
                        result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.No Then


                        Else

                            Dim cmd As New SQLiteCommand

                            cmd.Connection = connection
                            cmd.CommandText = " Insert into expenditure (Authorizer, Designtion,Amount ,Purpose,Discription, Date) Values(@nm,@dsg,  @amt, @pse,@dis,@date)"
                            cmd.Parameters.AddWithValue("@nm", TextBoxName.Text)
                            cmd.Parameters.AddWithValue("@dsg", dsg)
                            cmd.Parameters.AddWithValue("@amt", amt)
                            cmd.Parameters.AddWithValue("@pse", TextBox1.Text)
                            cmd.Parameters.AddWithValue("@dis", TextBox2.Text)
                            cmd.Parameters.AddWithValue("@date", TextBoxid.Text)

                            Dim recadd As Integer = cmd.ExecuteNonQuery()
                            connection.Close()
                            MsgBox("Your Record has been saved successfully")

                        End If
                        TextBoxAMT.Text = "0.00"
                    Case "SchoolMall"
                        Dim result As DialogResult
                        result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.No Then


                        Else

                            Dim cmd As New SQLiteCommand

                            cmd.Connection = connection
                            cmd.CommandText = " Insert into accountable (ItemName, Quantity,Price ,TotalAmount,DailyIncome,TotalExpenses,DailyBalance)
Values(@inm,@qty,  @pric, @tamt,@dicom,@texp,@dbal)"
                            cmd.Parameters.AddWithValue("@inm", TextBoxName.Text)
                            cmd.Parameters.AddWithValue("@qty", TextBoxclass.Text)
                            cmd.Parameters.AddWithValue("@pric", TextBoxAMT.Text)
                            cmd.Parameters.AddWithValue("@tamt", LabelTTLAMT.Text)
                            cmd.Parameters.AddWithValue("@dicom", LabelDAILYINCOM.Text)
                            cmd.Parameters.AddWithValue("@texp", LabelTTLEXP.Text)
                            cmd.Parameters.AddWithValue("@dbal", LabelBAL.Text)

                            Dim recadd As Integer = cmd.ExecuteNonQuery()
                            connection.Close()
                            MsgBox("Your Record has been saved successfully")

                        End If


                    Case "Choose  What To Do"



                        MsgBox("Please Select the operation you want to carry from the Combobox!! ", MessageBoxIcon.Information, "Error")


                End Select



            End If

        Catch ex As Exception
            MsgBox("Ooops!!! An Error has Occured Please Check that all your entries are correct")

        End Try

        Try

            If ComboBoxoption.Text = "SchoolMall" Then

                Using cmd As New SQLiteCommand("UPDATE storetable SET Quantity = (Quantity - @QU), TotalItemOut = TotalItemOut + @out, Date = @date  WHERE ItemName = @IN", connection)
                    cmd.Parameters.AddWithValue("@QU", TextBoxAMT.Text)
                    cmd.Parameters.AddWithValue("@out", TextBoxAMT.Text)
                    cmd.Parameters.AddWithValue("@IN", TextBoxName.Text)
                    cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Text)
                    cmd.ExecuteNonQuery()
                End Using


            ElseIf ComboBoxoption.Text = "Recieve Payment From Student" Then
                Using cmd As New SQLiteCommand("UPDATE studentable SET AmountPaid = AmountPaid + @pd,  BalancePayment = (TotalFees - (AmountPaid+@atp)), Date = @date   WHERE StudentID = @Id", connection)
                    cmd.Parameters.AddWithValue("@pd", TextBoxAMT.Text)

                    cmd.Parameters.AddWithValue("@atp", TextBoxAMT.Text)
                    cmd.Parameters.AddWithValue("@date", GunaDateTimePicker1.Text)
                    cmd.Parameters.AddWithValue("@id", TextBoxid.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        Dim height As Integer = DataGridViewDAILYSUMMARY.Height
        DataGridViewDAILYSUMMARY.Height = DataGridViewDAILYSUMMARY.RowCount * DataGridViewDAILYSUMMARY.RowTemplate.Height
        bitmap = New Bitmap(Me.DataGridViewDAILYSUMMARY.Width, Me.DataGridViewDAILYSUMMARY.Height)
        DataGridViewDAILYSUMMARY.DrawToBitmap(bitmap, New Rectangle(1, 1, Me.DataGridViewDAILYSUMMARY.Width, Me.DataGridViewDAILYSUMMARY.Height))
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
        DataGridViewDAILYSUMMARY.Height = height

    End Sub

    Private Sub VIEWTABLES_Click(sender As Object, e As EventArgs) Handles VIEWTABLES.Click
        TABLE_ANALYSIS.Show()
    End Sub

    Private Sub GunaLineTextBoxdel_Enter(sender As Object, e As EventArgs) Handles GunaLineTextBoxdel.Enter
        GunaLineTextBoxdel.Text = ""
    End Sub

    Private Sub GunaLineTextBoxdel_Leave(sender As Object, e As EventArgs) Handles GunaLineTextBoxdel.Leave
        If GunaLineTextBoxdel.Text = "" Then
            GunaLineTextBoxdel.Text = "ID or Name To Del"
        End If
    End Sub

    Private Sub UpdatePayrollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePayrollToolStripMenuItem.Click
        PAYROLLGER.Show()

        PAYROLLGER.GunaButton2.Hide()
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub TextBoxid_TextChanged(sender As Object, e As EventArgs) Handles TextBoxid.TextChanged

    End Sub

    Private Sub Labeltfes_Click(sender As Object, e As EventArgs) Handles Labeltfes.Click

    End Sub

    Private Sub RemoveUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveUserToolStripMenuItem.Click
        MYsTore.Show()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
End Class