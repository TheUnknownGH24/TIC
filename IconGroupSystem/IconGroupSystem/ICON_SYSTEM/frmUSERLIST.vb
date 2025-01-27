Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmUSERLIST

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_login where `employee_name` like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("employee_code").ToString, dr.Item("employee_name").ToString, dr.Item("domain").ToString, dr.Item("department").ToString, dr.Item("department_code").ToString, dr.Item("position").ToString, dr.Item("password").ToString, dr.Item("type").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Sub LoadUSERList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_login", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("employee_code").ToString, dr.Item("employee_name").ToString, dr.Item("domain").ToString, dr.Item("department").ToString, dr.Item("department_code").ToString, dr.Item("position").ToString, dr.Item("password").ToString, dr.Item("type").ToString, dr.Item("classification").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadUSERList()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "colUPDATE" Then
            With frmUSER_FORM
                cn.Open()
                cm = New MySqlCommand("select * from tbl_login where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read

                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtEMPLOYEECODE.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtEMPLOYEENAME.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtDOMAIN.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtDERPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtDEPCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtPOSITION.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                    .txtPASSWORD.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                    .txtTYPE.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                    .txtCLASS.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString

                End While
                dr.Close()
                cn.Close()
                .btnSAVE.Enabled = False
                .btnUPDATE.Enabled = True
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub frmUSERLIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            Else

                e.Cancel = True

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub
End Class