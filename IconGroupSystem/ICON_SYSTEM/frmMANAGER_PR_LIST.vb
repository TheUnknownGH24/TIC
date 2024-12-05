﻿Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmMANAGER_PR_LIST

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadPRList()

    End Sub

    Sub LoadPRList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblpurchasedrequest where `MANAGER_APPROVAL` = 'FOR APPROVAL' ", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = "MANAGER_APPROVAL"
            .Text = "DISPLAY_AND_APPROVED"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        dataGridView1.Columns.Insert(11, colApproval)

    End Sub



    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick


        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            With frmMANAGER_PR_APPROVAL
                cn.Open()
                cm = New MySqlCommand("select * from tblpurchasedrequest where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read
                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtCONTROL.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtTRANSACTION.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtEMPLOYEE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString

                    .txtSUPPLIER_1.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                    .txtSUPPLIER_2.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                    .txtSUPPLIER_3.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
                End While
                dr.Close()
                cn.Close()
                .LoadPURCHASEDList()
                .Supplier_sum()
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblpurchasedrequest where pr_no like '%" & txtSEARCHNAME.Text & "%' AND `MANAGER_APPROVAL` = 'FOR APPROVAL'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub
End Class