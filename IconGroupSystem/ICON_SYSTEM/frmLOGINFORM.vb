Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class frmLOGINFORM

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Dim command As New MySqlCommand("SELECT `employee_name`, `password` FROM `tbl_login` WHERE `employee_name` = @username AND `password` = @password", cn)

        command.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUSERNAME.Text
        command.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtPASSWORD.Text

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count = 0 Then

            MsgBox("Invalid Username or Password!", vbOKOnly + vbCritical, "VALIDATION")

        Else

            MsgBox("SUCCESSFULLY LOGGED IN !", vbOKOnly + vbInformation, "VALIDATION")

            Dim home_form As New frm1HOME()
            home_form.Show()
            home_form.txtHOMENAME.Text = txtUSERNAME.Text
            home_form.txtHOMEDEPCODE.Text = txtDEPCODE.Text
            home_form.txtHOMEDEPARTMENT.Text = txtDOMAIN.Text
            home_form.txtPOSITION.Text = txtPOSITION.Text
            home_form.txtHOMETYPE.Text = txtTYPE.Text
            home_form.txtHOMEID.Text = txtID.Text
            home_form.txtHOMEDEPARTMENT.Text = txtDEPARTMENT.Text
            home_form.txtHOMECLASS.Text = txtCLASS.Text
            home_form.txtWAREHOUSE_POSITION.Text = txtWAREHOUSE_POSITION.Text
            home_form.txtWAREHOUSESHARED.Text = txtWAREHOUSESHARED.Text
            home_form.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

            Me.Hide()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()
                frmPRODUCT.LoadCategory()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If txtPASSWORD.UseSystemPasswordChar = True Then

            txtPASSWORD.UseSystemPasswordChar = False

        Else

            txtPASSWORD.UseSystemPasswordChar = True

        End If

    End Sub

    Private Sub frmLOGINFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Connection()

    End Sub

    Private Sub frmLOGINFORM_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        cn.Open()
        cm = New MySqlCommand("select `employee_name` from tbl_login", cn)
        dr = cm.ExecuteReader
        Dim mydata As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        While dr.Read

            mydata.Add(dr.GetString(0))

        End While


        txtUSERNAME.AutoCompleteCustomSource = mydata

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtUSERNAME_Leave(sender As Object, e As EventArgs) Handles txtUSERNAME.Leave

        cn.Open()
        cm = New MySqlCommand("select * from tbl_login where `employee_name` like '%" & txtUSERNAME.Text & "%'", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtID.Text = dr("id").ToString()
            txtDOMAIN.Text = dr("domain").ToString()
            txtDEPCODE.Text = dr("department_code").ToString()
            txtPOSITION.Text = dr("position").ToString()
            txtTYPE.Text = dr("type").ToString()
            txtDEPARTMENT.Text = dr("department").ToString()
            txtCLASS.Text = dr("classification").ToString()

        End While

        dr.Close()
        cn.Close()

        SHOW_WAREHOUSE()

    End Sub

    Public Function GetInitials(ByVal MyText As String) As String

        Dim Initials As String = ""
        Dim AllWords() As String = MyText.Split(" ")
        For Each Word As String In AllWords
            If Word.Length > 0 Then
                Initials = Initials & Word.Chars(0).ToString.ToUpper
            End If
        Next
        Return Initials

    End Function

    Private Sub txtPASSWORD_TextChanged(sender As Object, e As EventArgs) Handles txtPASSWORD.TextChanged

        txtCODE.Text = GetInitials(txtPASSWORD.Text)

    End Sub


    Private Sub txtCODE_TextChanged(sender As Object, e As EventArgs) Handles txtCODE.TextChanged

        If txtCODE.Text = "A" Then

            cn.Open()
            cm = New MySqlCommand("select * from tbl_login where `employee_name` like '%" & txtUSERNAME.Text & "%' ORDER BY id ASC LIMIT 1", cn)

            dr = cm.ExecuteReader

            While dr.Read

                txtDEPARTMENT.Text = dr("department").ToString()

            End While

            dr.Close()
            cn.Close()

        ElseIf txtCODE.Text = "B" Then

            cn.Open()
            cm = New MySqlCommand("select * from tbl_login where `employee_name` like '%" & txtUSERNAME.Text & "%' ORDER BY id DESC LIMIT 1", cn)

            dr = cm.ExecuteReader

            While dr.Read

                txtDEPARTMENT.Text = dr("department").ToString()

            End While

            dr.Close()
            cn.Close()

        Else

            Exit Sub

        End If

    End Sub

    Sub SHOW_WAREHOUSE()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_area where `employee_name` like '%" & txtUSERNAME.Text & "%'", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtWAREHOUSE_POSITION.Text = dr("position").ToString()
            txtWAREHOUSESHARED.Text = dr("shared").ToString()
            txtWAREHOUSENAME.Text = dr("warehouse_name").ToString()

        End While

        dr.Close()
        cn.Close()

    End Sub

End Class