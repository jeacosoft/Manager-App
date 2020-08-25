Imports System.Data.SQLite
Public Class TABLE_ANALYSIS

    Sub showData()
        connect()
        Dim da As New SQLiteDataAdapter("select Name,TransactionType,AmountPaid, Balance, Date from accountable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub
    'for data reader for accountable showing details for item sold
    Sub seeData()
        connect()
        Dim da As New SQLiteDataAdapter("select ItemName,Quantity,Price,TotalAmount, Date from accountable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub



    'datareader for accountablestudent
    Sub displayData()
        connect()
        Dim da As New SQLiteDataAdapter("select StudentID,Surname,Othernames,Class,TotalFees,AmountPaid, BalancePayment , Date  from studentable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "studentable")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "studentable"
        connection.Clone()
        da.Dispose()
    End Sub
    Sub ANALYSISData()
        connect()
        Dim da As New SQLiteDataAdapter("select DailyIncome,TotalExpenses,DailyBalance, Date from accountable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub

    'display storetable
    Sub reviewData()
        connect()
        Dim da As New SQLiteDataAdapter("select ItemID,ItemName,Discription,Quantity,SalesPrice,TotalItemOut,Date  from storetable", connection)

        Dim ds As New DataSet
        da.Fill(ds, "storetable")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "storetable"
        connection.Clone()
        da.Dispose()
    End Sub
    'datareader for accountstaff
    Sub viewData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from accountablestaff", connection)
        Dim ds As New DataSet
        da.Fill(ds, "accountablestaff")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "accountablestaff"
        connection.Clone()
        da.Dispose()
    End Sub

    Sub studentData()
        connect()
        Dim da As New SQLiteDataAdapter("select StudentName, Class,PaidAmount,TotalFees,Balances, Date from accountable", connection)
        Dim ds As New DataSet
        da.Fill(ds, "accountable")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "accountable"
        connection.Clone()
        da.Dispose()
    End Sub
    Sub ExpData()
        connect()
        Dim da As New SQLiteDataAdapter("select * from expenditure", connection)
        Dim ds As New DataSet
        da.Fill(ds, "expenditure")

        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataSource = ds
        ACCOUNT_MANAGER.DataGridViewDAILYSUMMARY.DataMember = "expenditure"
        connection.Clone()
        da.Dispose()
    End Sub
    Private Sub GunaRadioButtonact_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonact.CheckedChanged
        If GunaRadioButtonact.Checked = True Then
            showData()
            Me.Hide()

        End If
    End Sub

    Private Sub GunaRadioButtonstp_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonstp.CheckedChanged
        If GunaRadioButtonstp.Checked = True Then
            viewData()
            Me.Hide()

        End If
    End Sub

    Private Sub GunaRadioButtonexp_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonexp.CheckedChanged
        If GunaRadioButtonexp.Checked = True Then
            ExpData()

        End If
        Me.Hide()
    End Sub

    Private Sub GunaRadioButtonsts_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButtonsts.CheckedChanged
        If GunaRadioButtonsts.Checked = True Then
            seeData()

        End If
        Me.Hide()
    End Sub

    Private Sub GunaRadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton5.CheckedChanged
        If GunaRadioButton5.Checked = True Then
            ANALYSISData()

        End If
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub GunaRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton1.CheckedChanged
        If GunaRadioButton1.Checked = True Then
            studentData()
        End If
    End Sub
End Class