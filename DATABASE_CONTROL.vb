Imports System.Data.SQLite
Module DATABASE_CONTROL

    Public sql As String
    Public ds As New DataSet
    Public cmd As New SQLiteCommand
    Public dr As SQLiteDataReader
    Public da As SQLiteDataAdapter
    Public dacon As New SQLiteConnection
    Public Sub dacondb()



        Try
            dacon = New SQLiteConnection("datasource =localhost; port = 3306; username = root; password = ""; database = stockertable ")
            dacon.Open()

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


End Module
