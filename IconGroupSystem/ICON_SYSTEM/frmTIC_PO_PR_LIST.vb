Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTIC_PO_PR_LIST

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest where `controlno` like '%" & txtSEARCHNAME.Text & "%' AND `gm_approval` = 'APPROVED' AND `coo_approval` = 'APPROVED' AND `status` = 'ACTIVE' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("date_time").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

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

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        With frmITEM
            .StartPosition = FormStartPosition.CenterScreen
            .btnUPDATE.Enabled = False
            .ShowDialog()
        End With

    End Sub

    Sub LoadREQUESTList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest where `gm_approval` = 'APPROVED' AND `coo_approval` = 'APPROVED' AND `status` = 'ACTIVE' ", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("date_time").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadREQUESTList()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "colUPDATE" Then
            With frmTIC_PO_FORM
                cn.Open()
                cm = New MySqlCommand("select * from tbl_tic_purchasedrequest where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read

                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtCONTROL.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtEMPLOYEE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString


                End While
                dr.Close()
                cn.Close()
                '.LoadPaymentTerms()
                .LoadSupplierList()
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub frmTIC_PO_PR_LIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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