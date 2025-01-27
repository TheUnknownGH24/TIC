﻿Public Class frmWAREHOUSE_MIR_FINAL

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = ""
            .Text = ">"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView2.Columns.Insert(19, colApproval)

    End Sub

    Sub LoadIPRList()

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_mir where `manager_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("mir_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("production_no").ToString, dr.Item("production_name").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_mir where mir_no like '%" & TextBox1.Text & "%' AND `manager_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("mir_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("production_no").ToString, dr.Item("production_name").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        dataGridView1.Rows.Clear()
        txtMANAGERCOMMENT.Text = ""
        txtMANAGERCOMMENT.Text = String.Empty

        txtGMCOMMENT.Text = ""
        txtGMCOMMENT.Text = String.Empty

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_mir where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString

                txtDATEREQUIRED.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtREQUESTOR.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtPRODUCTIONNO.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtPRODUCTIONNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadMIRITEMLIST()

            btnSAVE.Enabled = True
            btnPRINT.Enabled = True
            btnDISSAVE.Enabled = True

        End If

    End Sub

    Sub LoadMIRITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_mir_item where `mir_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("item_code").ToString, dr.Item("item_name").ToString, dr.Item("classification").ToString, dr.Item("uom").ToString, dr.Item("qty_requested").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_mir set final_name=@final_name, final_approval=@final_approval, final_comment=@final_comment, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@final_name", txtNAME.Text)
                    .AddWithValue("@final_approval", "APPROVED")
                    .AddWithValue("@final_comment", txtGMCOMMENT.Text & "-" & DateTimePicker1.Value)

                    .AddWithValue("@status", "ACTIVE")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                LoadIPRList()

                btnSAVE.Enabled = False
                btnPRINT.Enabled = False
                btnDISSAVE.Enabled = False

                MsgBox("Material Issuance has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_mir set manager_approval=@manager_approval, final_name=@final_name, final_approval=@final_approval, final_comment=@final_comment, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@manager_approval", "FOR APPROVAL")

                    .AddWithValue("@final_name", txtNAME.Text)
                    .AddWithValue("@final_approval", "FOR APPROVAL")
                    .AddWithValue("@final_comment", txtGMCOMMENT.Text & "-" & DateTimePicker1.Value)

                    .AddWithValue("@status", "RETURNED")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                LoadIPRList()

                btnSAVE.Enabled = False
                btnPRINT.Enabled = False
                btnDISSAVE.Enabled = False

                MsgBox("Material Issuance has been Successfully Returned!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub btnDISSAVE_Click(sender As Object, e As EventArgs) Handles btnDISSAVE.Click

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_mir set final_name=@final_name, final_approval=@final_approval, final_comment=@final_comment, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@final_name", txtNAME.Text)
                    .AddWithValue("@final_approval", "DISAPPROVED")
                    .AddWithValue("@final_comment", txtGMCOMMENT.Text & "-" & DateTimePicker1.Value)

                    .AddWithValue("@status", "DEACTIVE")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                LoadIPRList()

                btnSAVE.Enabled = False
                btnPRINT.Enabled = False
                btnDISSAVE.Enabled = False

                MsgBox("Material Issuance has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub frmWAREHOUSE_IPR_MANAGER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPRODUCTIONNO.Text
            .ShowDialog()

        End With


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPRODUCTIONNAME.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtGMCOMMENT.Text
            .ShowDialog()

        End With

    End Sub


End Class