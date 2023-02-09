Imports MySql.Data.MySqlClient
Module Connection
    Public conn_access As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Application.StartupPath & "\Database\BIX_TRANSPORTATION.accdb; Jet OLEDB:Database Password=orosageadmin;")
    Public datareader_access As OleDb.OleDbDataReader
    Public cmd_access As New OleDb.OleDbCommand


    Public Sub ExecuteQueryAccess(query As String)
        If conn_access.State = 1 Then conn_access.Close()
        conn_access.Open()
        cmd_access.CommandText = query
        cmd_access.Connection = conn_access
        cmd_access.ExecuteNonQuery()
    End Sub

    Public conn_mysql As New MySqlConnection("Server=10.10.2.200;User Id=ogdi;password=techsup@ids;SslMode=none;Database=phpmy1_orogrande_com_ph")
    'Public conn_mysql As New MySqlConnection("Server=localhost;User id=root;password=local;SslMode=none;Database=db_test;convert zero datetime=True")
    Public datareader_mysql As MySqlDataReader
    Public cmd_mysql As New MySqlCommand
    Public table As New DataTable
    Public internet_connection As Boolean


    Public Sub ExecuteQueryMySQL(query As String)
        'Dim cmd As New MySqlCommand(query, conn)

        conn_mysql.Open()
        cmd_mysql.CommandText = query
        cmd_mysql.Connection = conn_mysql
        cmd_mysql.ExecuteNonQuery()
    End Sub

    Public Sub checkconnection()
        Try
            conn_mysql.Open()
            internet_connection = True
            conn_mysql.Close()
        Catch ex As Exception
            internet_connection = False
        End Try
    End Sub
End Module
