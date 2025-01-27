Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Module dbconnection

    Public cn As New MySqlConnection
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader

    Sub Connection()

        cn = New MySqlConnection

        Try

            With cn

                '----- localhost -----' 
                '.ConnectionString = "server=localhost;user id=root;password=;database=db_icongroup"

                '----- company host -----' 
                .ConnectionString = "server=db4free.net; user id=ryanicongroup; password=sample1+1; database=db_icongroup; pooling=true; SslMode=none; old guids=true"

            End With

        Catch ex As Exception

            MsgBox("Unable to connect. Check your Internet Connection! ", vbOKOnly + vbExclamation, "CONNECTION")

            'MsgBox(ex.Message, vbOKOnly + vbExclamation, "CONNECTION")

            cn.Close()

        End Try

    End Sub

End Module
