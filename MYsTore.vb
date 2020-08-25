Imports System.Data.SQLite
Public Class MYsTore



    Sub showData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from storetable", connection)
        'Dim dt As New DataTablestafftable
        Dim ds As New DataSet
        da.Fill(ds, "storetable")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "storetable"
        connection.Clone()
        da.Dispose()
    End Sub

    Public Function inameExist(ByVal iname As String) As Boolean
        'this code check if there is duplicate of Item in the table
        connect()
        Dim table As New DataTable()
        Dim adapter As New SQLiteDataAdapter()
        Dim command As New SQLiteCommand("SELECT  ItemName FROM storetable WHERE ItemName =@itn", connection)
        command.Parameters.Add("@itn", SqlDbType.VarChar).Value = iname
        adapter.SelectCommand = command
        adapter.Fill(table)
        If table.Rows.Count > 0 Then
            Return True
        Else
            Return False

        End If
    End Function
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonSubmit.Click
        ' Dim n As Integer = Val (TextBox.Text )
        Try

            connect()

            GunaDateTimePicker2.Value = DateTime.Now
            Dim iname As String = GunaTextBoxitnm.Text


            Dim cmd As New SQLiteCommand
            If GunaTextBoxitnm.Text = "" Then
                MsgBox("Please Enter the item name", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxitnm.Focus()
                Exit Sub
            End If


            If GunaTextBoxdsp.Text = "" Then
                MsgBox("Please Enter the details of the product", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdsp.Focus()
                Exit Sub
            End If

            If GunaTextBoxqty.Text = "" Then
                MsgBox("Please Enter the quantity of the stock", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqty.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxqty.Text) Then
                MsgBox("Please Enter degits e.g 8,10,20", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqty.Focus()
                Exit Sub
            End If


            If Not IsNumeric(GunaTextBoxbkpr.Text) Then
                MsgBox("Please Enter the whole sale price of the product", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxbkpr.Focus()
                Exit Sub
            End If
            If GunaTextBoxuntpr.Text = "" Then
                MsgBox("Please Enter the single price for the product", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxuntpr.Focus()
                Exit Sub
            End If

            If GunaTextBoxsal.Text = "" Then
                MsgBox("Please Enter the saling price", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxsal.Focus()
                Exit Sub
            End If

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then


            ElseIf inameExist(iname) Then
                MsgBox("This Item is already in the database")
            Else
                ' Dim dat As New DateTime = DateTimePicker1.Value
                cmd.Connection = connection
                cmd.CommandText = " Insert into storetable (ItemName, Discription,Quantity,BulkPrice,UnitPrice,SalesPrice,ExpectedProfits,TotalItemOut, Date)
Values(@inm,  @dsn,@qty,@bpr, @upr,@spr,@expr,@titou, @date)"

                cmd.Parameters.Add(New SQLiteParameter("@inm", iname))
                cmd.Parameters.Add(New SQLiteParameter("@dsn", GunaTextBoxdsp.Text))
                cmd.Parameters.Add(New SQLiteParameter("@qty", GunaTextBoxqty.Text))
                cmd.Parameters.Add(New SQLiteParameter("@bpr", GunaTextBoxbkpr.Text))
                cmd.Parameters.Add(New SQLiteParameter("@upr", GunaTextBoxuntpr.Text))
                cmd.Parameters.Add(New SQLiteParameter("@spr", GunaTextBoxsal.Text))
                cmd.Parameters.AddWithValue("@expr", GunaLabelprof.Text)

                cmd.Parameters.Add(New SQLiteParameter("@titou", GunaLabel1.Text))
                cmd.Parameters.AddWithValue("@date", GunaDateTimePicker2.Value.ToShortDateString)


                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("The  Record has been save successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please check that all the fields are filed  then Try again")
        End Try


    End Sub

    Private Sub MYsTore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaDateTimePicker2.Value = DateTime.Now
        showData()


        'Populating data from the data
        connect()
        Try



            Dim READER As SQLiteDataReader
            Dim cmd As SQLiteCommand = connection.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select ItemName From storetable"
            READER = cmd.ExecuteReader
            If READER.HasRows Then

                While READER.Read

                    GunaComboBox1.Items.Add(READER("ItemName"))

                End While

                READER.Close()
                connection.Close()
            End If
        Catch ex As Exception
        End Try

    End Sub



    Private Sub GunaTextBoxbkpr_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxbkpr.KeyUp
        'calculating the unit price
        Dim qty As Double = Val(GunaTextBoxqty.Text)
        Dim bkpr As Double = Val(GunaTextBoxbkpr.Text)
        Dim unpr As Double = Val(GunaTextBoxuntpr.Text)
        If GunaTextBoxqty.Text = "" Then
            MsgBox("Please Enter the Quantity of Item")
            GunaTextBoxbkpr.Text = ""
        Else


            unpr = bkpr / qty
            GunaTextBoxuntpr.Text = System.Convert.ToString(unpr)
            GunaTextBoxuntpr.Text = unpr.ToString("n")
        End If
    End Sub

    Private Sub GunaTextBoxsal_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxsal.KeyUp
        'calculating the expected profit
        Dim qty As Double = Val(GunaTextBoxqty.Text)
        Dim salpr As Double = Val(GunaTextBoxsal.Text)
        Dim expro As Double = Val(GunaLabelprof.Text)

        expro = qty * salpr
        GunaLabelprof.Text = System.Convert.ToString(expro)
        GunaLabelprof.Text = expro.ToString("")

    End Sub

    Private Sub GunaTextBoxsch_KeyUp(sender As Object, e As KeyEventArgs) Handles GunaTextBoxsch.KeyUp
        'seaching the items from the database
        Try


            connect()
            cmd = New SQLiteCommand("select * from storetable where ItemName like '%" + GunaTextBoxsch.Text + "%'", connection)


            da = New SQLiteDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "storetable")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "storetable"
            cmd.Dispose()
            ds.Dispose()
            connection.Close()

            ' code to search the combobox
            Dim index As Integer
            index = GunaComboBox1.FindString(GunaTextBoxsch.Text)
            GunaComboBox1.SelectedIndex = index
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GunaButtonupd_Click(sender As Object, e As EventArgs) Handles GunaButtonupd.Click
        GunaDateTimePicker2.Value = DateTime.Now



        connect()


        Dim iname As String = GunaTextBoxitnm.Text


        Dim cmd As New SQLiteCommand
        If GunaTextBoxitnm.Text = "" Then
            MsgBox("Please Enter the item name to be updated", MessageBoxIcon.Exclamation, "error")
            GunaTextBoxitnm.Focus()
            Exit Sub
        End If


        If GunaTextBoxqty.Text = "" Then
            MsgBox("Please Enter the quantity of the stock", MessageBoxIcon.Exclamation, "error")
            GunaTextBoxqty.Focus()
            Exit Sub
        End If
        If Not IsNumeric(GunaTextBoxqty.Text) Then
            MsgBox("Please Enter degits e.g 8,10,20", MessageBoxIcon.Exclamation, "error")
            GunaTextBoxqty.Focus()
            Exit Sub
        End If


        If Not IsNumeric(GunaTextBoxbkpr.Text) Then
            MsgBox("Please Enter the whole sale price of the product", MessageBoxIcon.Exclamation, "error")
            GunaTextBoxbkpr.Focus()
            Exit Sub
        End If
        If GunaTextBoxuntpr.Text = "" Then
            MsgBox("Please Enter the single price for the product", MessageBoxIcon.Exclamation, "error")
            GunaTextBoxuntpr.Focus()
            Exit Sub
        End If

        If GunaTextBoxsal.Text = "" Then
            MsgBox("Please Enter the saling price", MessageBoxIcon.Exclamation, "error")
            GunaTextBoxsal.Focus()
            Exit Sub
        End If

        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to update this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then



        Else
            ' Dim dat As New DateTime = DateTimePicker1.Value
            cmd.Connection = connection

            cmd.CommandText = "update storetable set Quantity = Quantity + @qty, BulkPrice = @bpr, UnitPrice = @upr,
SalesPrice=@spr,ExpectedProfits= @expr, Date= @date where ItemName = @inm"


            cmd.Parameters.Add(New SQLiteParameter("@inm", iname))
            cmd.Parameters.Add(New SQLiteParameter("@dsn", GunaTextBoxdsp.Text))
            cmd.Parameters.Add(New SQLiteParameter("@qty", GunaTextBoxqty.Text))
            cmd.Parameters.Add(New SQLiteParameter("@bpr", GunaTextBoxbkpr.Text))
            cmd.Parameters.Add(New SQLiteParameter("@upr", GunaTextBoxuntpr.Text))
            cmd.Parameters.Add(New SQLiteParameter("@spr", GunaTextBoxsal.Text))
            cmd.Parameters.AddWithValue("@expr", GunaLabelprof.Text)

            '  cmd.Parameters.Add(New SQLiteParameter("@titou", GunaLabel1.Text))
            cmd.Parameters.AddWithValue("@date", GunaDateTimePicker2.Value.ToShortDateString)


            Dim recadd As Integer = cmd.ExecuteNonQuery()
            connection.Close()
            MsgBox("The  Record has been save successfully")
            showData()
        End If

    End Sub

    Private Sub GunaButtonRes_Click(sender As Object, e As EventArgs) Handles GunaButtonRes.Click
        GunaTextBoxitnm.Text = "type Item name"
        GunaTextBoxdsp.Text = "Describe the item here"
        GunaTextBoxqty.Text = "0.00 "
        GunaTextBoxbkpr.Text = "0.00"
        GunaTextBoxuntpr.Text = "0.00"
        GunaTextBoxsal.Text = "0.00"
        GunaLabelprof.Text = "0.00"
        GunaLabel1.Text = "0.00"


    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try


            ' display datagridview data on click
            Dim selectedgr As DataGridViewRow
            selectedgr = DataGridView1.Rows(e.RowIndex)

            GunaTextBox1.Text = selectedgr.Cells(0).Value
            GunaTextBoxitnm.Text = selectedgr.Cells(1).Value
            GunaTextBoxdsp.Text = selectedgr.Cells(2).Value
            GunaTextBoxqty.Text = selectedgr.Cells(3).Value
            GunaTextBoxbkpr.Text = selectedgr.Cells(4).Value
            GunaTextBoxuntpr.Text = selectedgr.Cells(5).Value
            GunaTextBoxsal.Text = selectedgr.Cells(6).Value
            GunaLabelprof.Text = selectedgr.Cells(7).Value
            GunaLabel1.Text = selectedgr.Cells(8).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Dim READER As SQLiteDataReader

        'Populating data from the combobox to controls
        connect()
            Try




                Dim cmd As SQLiteCommand = connection.CreateCommand
                cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from storetable where ItemName = '" & GunaComboBox1.Text & "'"
            READER = cmd.ExecuteReader
                If READER.HasRows Then

                    While READER.Read

                        GunaTextBoxitnm.Text = (READER("ItemName"))
                        GunaTextBoxdsp.Text = (READER("Discription"))
                        GunaTextBoxqty.Text = (READER("Quantity"))
                        GunaTextBoxbkpr.Text = (READER("BulkPrice"))
                        GunaTextBoxuntpr.Text = (READER("UnitPrice"))

                        GunaTextBoxsal.Text = (READER("SalesPrice"))
                        GunaLabelprof.Text = (READER("ExpectedProfits"))
                        GunaLabel1.Text = (READER("TotalItemOut"))
                    End While

                    READER.Close()
                    connection.Close()
                End If

            Catch ex As Exception



            End Try


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GunaTextBoxitnm_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxitnm.TextChanged

    End Sub

    Private Sub GunaTextBoxdsp_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxdsp.TextChanged

    End Sub

    Private Sub GunaTextBoxqty_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxqty.TextChanged

    End Sub

    Private Sub GunaTextBoxbkpr_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxbkpr.TextChanged

    End Sub

    Private Sub GunaTextBoxuntpr_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxuntpr.TextChanged

    End Sub

    Private Sub GunaTextBoxsal_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxsal.TextChanged

    End Sub

    Private Sub GunaTextBoxsch_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxsch.Enter
        GunaTextBoxsch.Text = ""
    End Sub

    Private Sub GunaTextBoxsch_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxsch.Leave
        If GunaTextBoxsch.Text = "" Then
            GunaTextBoxsch.Text = "Search for Item"

        End If
    End Sub

    Private Sub GunaTextBoxqty_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxqty.Enter
        GunaTextBoxqty.Text = ""
    End Sub

    Private Sub GunaTextBoxqty_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxqty.Leave
        If GunaTextBoxqty.Text = "" Then
            GunaTextBoxqty.Text = "e.g 45"
        End If
    End Sub

    Private Sub GunaTextBoxbkpr_Enter(sender As Object, e As EventArgs) Handles GunaTextBoxbkpr.Enter
        GunaTextBoxbkpr.Text = ""
    End Sub

    Private Sub GunaTextBoxbkpr_Leave(sender As Object, e As EventArgs) Handles GunaTextBoxbkpr.Leave
        If GunaTextBoxbkpr.Text = "" Then
            GunaTextBoxbkpr.Text = "wholesale price
"
        End If
    End Sub

    Private Sub GunaTextBox1_Enter(sender As Object, e As EventArgs) Handles GunaTextBox1.Enter

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        Try

            connect()


            Dim iname As String = GunaTextBoxitnm.Text


            Dim cmd As New SQLiteCommand
            If GunaTextBoxitnm.Text = "" Then
                MsgBox("Please Enter the item name", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxitnm.Focus()
                Exit Sub
            End If


            If GunaTextBoxdsp.Text = "" Then
                MsgBox("Please Enter the details of the product", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxdsp.Focus()
                Exit Sub
            End If

            If GunaTextBoxqty.Text = "" Then
                MsgBox("Please Enter the quantity of the stock", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqty.Focus()
                Exit Sub
            End If
            If Not IsNumeric(GunaTextBoxqty.Text) Then
                MsgBox("Please Enter degits e.g 8,10,20", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxqty.Focus()
                Exit Sub
            End If


            If Not IsNumeric(GunaTextBoxbkpr.Text) Then
                MsgBox("Please Enter the whole sale price of the product", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxbkpr.Focus()
                Exit Sub
            End If
            If GunaTextBoxuntpr.Text = "" Then
                MsgBox("Please Enter the single price for the product", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxuntpr.Focus()
                Exit Sub
            End If

            If GunaTextBoxsal.Text = "" Then
                MsgBox("Please Enter the saling price", MessageBoxIcon.Exclamation, "error")
                GunaTextBoxsal.Focus()
                Exit Sub
            End If

            Dim result As DialogResult
            result = MessageBox.Show("Are you Sure you want to Save this Record?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.No Then


            ElseIf inameExist(iname) Then
                MsgBox("This Item is already in the database")
            Else
                ' Dim dat As New DateTime = DateTimePicker1.Value
                cmd.Connection = connection
                cmd.CommandText = " Insert into storetable (ItemName, Discription,Quantity,BulkPrice,UnitPrice,SalesPrice,ExpectedProfits,TotalItemOut)
Values(@inm,  @dsn,@qty,@bpr, @upr,@spr,@expr,@titou)"

                cmd.Parameters.Add(New SQLiteParameter("@inm", iname))
                cmd.Parameters.Add(New SQLiteParameter("@dsn", GunaTextBoxdsp.Text))
                cmd.Parameters.Add(New SQLiteParameter("@qty", GunaTextBoxqty.Text))
                cmd.Parameters.Add(New SQLiteParameter("@bpr", GunaTextBoxbkpr.Text))
                cmd.Parameters.Add(New SQLiteParameter("@upr", GunaTextBoxuntpr.Text))
                cmd.Parameters.Add(New SQLiteParameter("@spr", GunaTextBoxsal.Text))
                cmd.Parameters.AddWithValue("@expr", GunaLabelprof.Text)

                cmd.Parameters.Add(New SQLiteParameter("@titou", GunaLabel1.Text))
                ' cmd.Parameters.AddWithValue("@date", dat)


                Dim recadd As Integer = cmd.ExecuteNonQuery()
                connection.Close()
                MsgBox("The  Record has been save successfully")
                showData()
            End If

        Catch ex As Exception
            MsgBox("An Error Occured Please check that all the fields are filed including the Imagebox then Try again")
        End Try

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you Sure you want to close this Page?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.No Then
        Else

            Me.Close()
        End If
    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        ACCOUNT_MANAGER.Show()
        Me.Hide()
    End Sub
End Class