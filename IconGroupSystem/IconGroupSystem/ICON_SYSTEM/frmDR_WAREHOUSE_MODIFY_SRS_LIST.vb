Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmDR_WAREHOUSE_MODIFY_SRS_LIST

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

        LoadDRSRSList()

    End Sub

    Sub LoadDRSRSList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbldeliveryreceipt_warehouse where `manager_approval` like 'APPROVED' OR `gm_approval` like 'FOR APPROVAL' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("platforms").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsrs_request where `srs_no` like '%" & txtSEARCHNAME.Text & "%' AND `gm_approval` = 'FOR APPROVAL' OR `manager_approval` = 'APPROVED'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("platforms").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

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
            .Text = "MODIFY"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        dataGridView1.Columns.Insert(10, colApproval)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then

            With frmDR_WAREHOUSE_MODIFY_SRS_FORM
                cn.Open()
                cm = New MySqlCommand("select * from tbldeliveryreceipt_warehouse where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader

                While dr.Read

                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtDRNO.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtREF.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtREQUESTOR.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtPLATFORMS.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                    .txtDATENEEDED.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString

                End While

                dr.Close()
                cn.Close()
                .LoadITEMList()
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()

            End With

        End If

    End Sub


End Class