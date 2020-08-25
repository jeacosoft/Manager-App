Imports System.Data.SQLite
Public Class Server
	'Dim location As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
	Dim filename As String = "ManaBase.db"
	Dim fullPath As String = System.IO.Path.Combine(filename)
	Public connectionString As String = String.Format("Data Source = {0}", fullPath)
	Dim fulPath As String = System.IO.Path.Combine(filename)

	Public Sub createDataBase()
        If Not duplicateDataBase(fullPath) Then
			Dim createTable As String = "CREATE TABLE 'usertable' (
									'UserID'	INTEGER PRIMARY KEY AUTOINCREMENT,
									'Name'	TEXT,
									'Sex'	TEXT,
									'Designation'	TEXT,
									'Username'	TEXT,
									'Password'	TEXT
								);"

            Using sqlConn As New SQLiteConnection(connectionString)
                Dim cmd As New SQLiteCommand(createTable, sqlConn)
                sqlConn.Open()
                cmd.ExecuteNonQuery()

            End Using


            Dim createTable2 As String = "CREATE TABLE 'accountable' (
	                                       'Name'	TEXT,
	                                        'TransactionType'	TEXT,
	                                        'AmountPaid'	REAL,
	                                        'Balance'	REAL,
	                                        'ItemName'	TEXT,
	                                        'Quantity'	NUMERIC,
	                                        'Price'	REAL,
	                                        'TotalAmount'	REAL,
	                                        'DailyIncome'	REAL,
	                                        'TotalExpenses'	REAL,
	                                        'DailyBalance'	REAL,
	                                        'Date'	TEXT,
	                                        'StudentName'	TEXT,
	                                        'Class'	TEXT,
	                                        'PaidAmount'	REAL,
	                                        'TotalFees'	REAL,
	                                        'Balances'	TEXT    
                                                    );"

            Using sqlConn As New SQLiteConnection(connectionString)
                Dim cmd As New SQLiteCommand(createTable2, sqlConn)
                sqlConn.Open()
                cmd.ExecuteNonQuery()

            End Using

            Dim createTable3 As String = " CREATE TABLE 'payrolltable2' (
	                                                        'StaffID'	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                                        'Surname'	TEXT,
	                                                        'Othername'	TEXT,
	                                                        'Qualification'	TEXT,
	                                                        'Level'	INTEGER,
	                                                        'Designation'	TEXT,
	                                                        'BasicSalary'	REAL,
	                                                        'TotalAllowance'	REAL,
	                                                        'TaxPercentage'	REAL,
	                                                        'Tax'	REAL,
	                                                        'GrossPay'	REAL,
	                                                        'NetPay'	REAL,
	                                                        'Passport'	BLOB,
	                                                        'Date'	TEXT
                                                        );"



			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable3, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using




			Dim createTable4 As String = " CREATE TABLE 'stafftable' (
												'StaffID'	INTEGER PRIMARY KEY AUTOINCREMENT,
												'Surname'	TEXT,
												'Othername'	TEXT,
												'Sex'	TEXT,
												'DOB'	TEXT,
												'MaritalStatus'	TEXT,
												'Qualification'	TEXT,
												'SchoolAttended'	TEXT,
												'CourseOfStudy'	TEXT,
												'Telephone'	NUMERIC,
												'Address'	TEXT,
												'Designation'	TEXT,
												'Passport'	BLOB,
												'Date'	TEXT
											     );"
			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable4, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using


			Dim createTable5 As String = "CREATE TABLE 'storetable' (
										'ItemID'	INTEGER PRIMARY KEY AUTOINCREMENT,
										'ItemName'	TEXT,
										'Discription'	TEXT,
										'Quantity'	NUMERIC,
										'BulkPrice'	REAL,
										'UnitPrice'	REAL,
										'SalesPrice'	REAL,
										'ExpectedProfits'	REAL,
										'TotalItemOut'	NUMERIC,
										'Date'	TEXT
									);"


			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable5, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using


			Dim createTable6 As String = "CREATE TABLE 'studentable' (
											'StudentID'	INTEGER PRIMARY KEY AUTOINCREMENT,
											'Surname'	TEXT,
											'Othernames'	TEXT,
											'Sex'	TEXT,
											'DOB'	TEXT,
											'Age'	NUMERIC,
											'Class'	TEXT,
											'Address'	TEXT,
											'PhoneNo'	NUMERIC,
											'Sponsor'	TEXT,
											'SchoolTransportation'	TEXT,
											'Section'	TEXT,
											'TransportationFees'	INTEGER,
											'TuitionFees'	INTEGER,
											'TotalFees'	INTEGER,
											'AmountPaid'	INTEGER,
											'BalancePayment'	INTEGER,
											'Passport'	BLOB,
											'Date'	TEXT
										);"


			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable6, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using



			Dim createTable8 As String = "CREATE TABLE 'expenditure' (
										'ID'	INTEGER PRIMARY KEY AUTOINCREMENT,
										'Authorizer'	TEXT,
										'Designtion'	TEXT,
										'Amount'	REAL,
										'Purpose'	TEXT,
										'Discription'	TEXT,
										'Date'	TEXT
									);"

			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable8, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using



			Dim createTable9 As String = "	CREATE TABLE 'companyname' (
											'CompanyName'	TEXT
										);"
			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable9, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using


			Dim createTable10 As String = "CREATE TABLE 'accountablestudent' (
										'StudentID'	INTEGER PRIMARY KEY AUTOINCREMENT,
										'Name'	TEXT,
										'Class'	TEXT,
										'AmountPaid'	REAL,
										'TotalFees'	REAL,
										'Balance'	REAL,
										'Date'	TEXT
									);"

			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable10, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using


			Dim createTable11 As String = "CREATE TABLE 'accountablestaff' (
										'StaffID'	INTEGER PRIMARY KEY AUTOINCREMENT,
										'StaffName'	TEXT,
										'Designation'	TEXT,
										'Amount'	REAL,
										'NetSalary'	REAL,
										'Balance'	REAL,
										'Date'	TEXT
									);"
			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable11, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using


			Dim createTable12 As String = "CREATE TABLE 'analysistable' (
	                                      'ID'	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                      'DailyIncome'   	REAL,
	                                      'DailyExpenses'	REAL,
	                                      'DailyBalance'	REAL,
	                                       'Date'	        TEXT
                                               );"
			Using sqlConn As New SQLiteConnection(connectionString)
				Dim cmd As New SQLiteCommand(createTable12, sqlConn)
				sqlConn.Open()
				cmd.ExecuteNonQuery()

			End Using
		End If
    End Sub


    Private Function duplicateDataBase(fullPath As String) As Boolean
        Return System.IO.File.Exists(fullPath)


    End Function

    Public Sub insertUsername(ByVal username As String, ByVal password As String)
        Using sqlConn As New SQLiteConnection(connectionString)
            Dim inserUserQuery As String = "insert into usertable(username, password) VALUES (@user, @psw)"
            Dim cmd As New SQLiteCommand(inserUserQuery, sqlConn)
            cmd.Parameters.AddWithValue("@user", username)
            cmd.Parameters.AddWithValue("@psw", password)
            ' cmd.Parameters.AddWithValue("@psw", password)
            sqlConn.Open()
            cmd.ExecuteNonQuery()


        End Using

    End Sub



End Class
