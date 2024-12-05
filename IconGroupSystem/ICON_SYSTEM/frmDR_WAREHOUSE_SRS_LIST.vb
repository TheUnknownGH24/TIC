Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmDR_WAREHOUSE_SRS_LIST

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
        cm = New MySqlCommand("select * from tblsrs_request where `manager_approval` like 'APPROVED' OR `gm_approval` like 'APPROVED' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("transaction_no").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsrs_request where `srs_no` like '%" & txtSEARCHNAME.Text & "%' AND `gm_approval` = 'APPROVED' OR `manager_approval` = 'APPROVED'", cn)
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
            .Text = "CREATE_DR"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        dataGridView1.Columns.Insert(9, colApproval)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            With frmDR_WAREHOUSE_SRS_FORM
                cn.Open()
                cm = New MySqlCommand("select * from tblsrs_request where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read

                    .txtREF.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString & "-" & dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtREQUESTOR.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtPLATFORMS.Text = "SUPPLY REQUISITION"
                    .txtDATENEEDED.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString

                    .txtSRS.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString

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