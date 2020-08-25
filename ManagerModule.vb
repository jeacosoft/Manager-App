Imports System.Data.SQLite
Module ManagerModule
    Public connection As SQLiteConnection
    Sub connect()
        Try
            connection = New SQLiteConnection("Data Source=  ManaBase.db; Version = 3")
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
        Catch ex As Exception
            MsgBox("Connection Failed!")
        End Try
    End Sub
End Module
