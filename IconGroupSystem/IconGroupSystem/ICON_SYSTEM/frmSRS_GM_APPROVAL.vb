Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSRS_GM_APPROVAL

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

        LoadSRSList()

    End Sub

    Sub LoadSRSList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsrs_request where `manager_approval` like 'APPROVED' AND `gm_approval` like 'FOR APPROVAL' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("transaction_no").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsrs_request where `srs_no` like '%" & txtSEARCHNAME.Text & "%' AND `gm_approval` = 'FOR APPROVAL' AND `manager_approval` like 'APPROVED'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("transaction_no").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = ""
            .Text = "DISPLAY_AND_APPROVED"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        dataGridView1.Columns.Insert(10, colApproval)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            With frmSRS_GM_FORM
                cn.Open()
                cm = New MySqlCommand("select * from tblsrs_request where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read
                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtCONTROL.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtTRANSAC.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtEMPLOYEE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtDEPCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString

                End While
                dr.Close()
                cn.Close()
                .LoadITEMList()
                .LoadPOList()
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If

    End Sub

End Class