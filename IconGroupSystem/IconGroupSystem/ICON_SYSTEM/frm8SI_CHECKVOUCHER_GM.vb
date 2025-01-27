Public Class frm8SI_CHECKVOUCHER_GM

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

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
        DataGridView2.Columns.Insert(23, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_checkvoucher where `cv_no` like '%" & TextBox3.Text & "%' AND `manager_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `coo_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("cv_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("supplier_name").ToString, dr.Item("payee_name").ToString, dr.Item("reference_code").ToString, dr.Item("subreference_code").ToString, dr.Item("checkvoucher_date").ToString, dr.Item("check_no").ToString, dr.Item("bank_branch").ToString, dr.Item("check_date").ToString, dr.Item("particulars").ToString, dr.Item("amount_due").ToString, dr.Item("debit_total").ToString, dr.Item("credit_total").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

        End While

        dr.Close()

        cn.Close()

    End Sub

    Sub LoadCVList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_checkvoucher where `manager_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `coo_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("cv_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("supplier_name").ToString, dr.Item("payee_name").ToString, dr.Item("reference_code").ToString, dr.Item("subreference_code").ToString, dr.Item("checkvoucher_date").ToString, dr.Item("check_no").ToString, dr.Item("bank_branch").ToString, dr.Item("check_date").ToString, dr.Item("particulars").ToString, dr.Item("amount_due").ToString, dr.Item("debit_total").ToString, dr.Item("credit_total").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadAccountTitle()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_checkvoucher_accounttitle where `cv_no` like '" & txtCONTROL.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("account_code").ToString, dr.Item("account_title").ToString, dr.Item("dep_code").ToString, dr.Item("debit").ToString, dr.Item("credit").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Sub LoadBankAccount()

        txtBANK.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from a_8si_bank", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtBANK.Items.Add(dr.Item("bank_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        LoadBankAccount()

        txtCONTROL.Text = ""
        txtCONTROL.Text = String.Empty
        txtDEBITTOTAL.Text = ""
        txtCREDITTOTAL.Text = String.Empty
        dataGridView1.Rows.Clear()

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_checkvoucher where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPCODE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtSUPPLIER.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtPAYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString

                txtREFERENCECODE.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString
                txtSUBREFERENCECODE.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString

                txtCHECKVOUCHERDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString
                txtCHECKNO.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString
                txtBANK.Text = DataGridView2.Rows(e.RowIndex).Cells(14).Value.ToString
                txtCHECKDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString

                txtPARTICULARS.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString

                txtAMOUNTDUE.Text = DataGridView2.Rows(e.RowIndex).Cells(17).Value.ToString
                txtDEBITTOTAL.Text = DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString
                txtCREDITTOTAL.Text = DataGridView2.Rows(e.RowIndex).Cells(19).Value.ToString

                txtFINANCE.Text = DataGridView2.Rows(e.RowIndex).Cells(20).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadAccountTitle()

            btnAPPROVED.Enabled = True
            btnDISAPPROVED.Enabled = True
            btnRETURN.Enabled = True

        End If

    End Sub

    Private Sub txtAMOUNTDUE_Leave(sender As Object, e As EventArgs)

        If txtAMOUNTDUE.Text = String.Empty Then

            Exit Sub

        Else

            txtAMOUNTDUE.Text = CDbl(txtAMOUNTDUE.Text).ToString("#,##0.00")

        End If

    End Sub

    Private Sub btnAPPROVED_Click(sender As Object, e As EventArgs) Handles btnAPPROVED.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_checkvoucher set gm_approval=@gm_approval, gm_comment=@gm_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@gm_approval", "APPROVED")
                .AddWithValue("@gm_comment", txtGM.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadCVList()

            btnAPPROVED.Enabled = False
            btnDISAPPROVED.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("Check Voucher has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub btnDISAPPROVED_Click(sender As Object, e As EventArgs) Handles btnDISAPPROVED.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_checkvoucher set gm_approval=@gm_approval, gm_comment=@gm_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@gm_approval", "DISAPPROVED")
                .AddWithValue("@gm_comment", txtGM.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "DEACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            DisapprovedUpdate()
            LoadCVList()

            btnAPPROVED.Enabled = False
            btnDISAPPROVED.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("Check Voucher has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DisapprovedUpdate()

        If txtCODE.Text = "CALIQ" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_cashadvance_liquidation set status=@status where cano_liquidation=@cano_liquidation", cn)

            With cm.Parameters

                .AddWithValue("@cano_liquidation", txtREFERENCE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtCODE.Text = "CA" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_cashadvance set status=@status where ca_no=@ca_no", cn)

            With cm.Parameters

                .AddWithValue("@ca_no", txtREFERENCE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtCODE.Text = "PAYRE" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_paymentrequest set status=@status where controlno=@controlno", cn)

            With cm.Parameters

                .AddWithValue("@controlno", txtREFERENCE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtCODE.Text = "REIM" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_reimbursement set status=@status where reimbursementno=@reimbursementno", cn)

            With cm.Parameters

                .AddWithValue("@reimbursementno", txtREFERENCE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtCODE.Text = "RF" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_rf_replenishment set status=@status where rf_no=@rf_no", cn)

            With cm.Parameters

                .AddWithValue("@rf_no", txtREFERENCE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        End If

    End Sub



    Private Sub btnRETURN_Click(sender As Object, e As EventArgs) Handles btnRETURN.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_checkvoucher set manager_approval=@manager_approval, gm_approval=@gm_approval, gm_comment=@gm_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@gm_approval", "FOR APPROVAL")
                .AddWithValue("@gm_comment", txtGM.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "RETURNED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadCVList()

            btnAPPROVED.Enabled = False
            btnDISAPPROVED.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("Check Voucher has been Successfully Return!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub frm8SI_CHECKVOUCHER_GM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub txtREFERENCE_TextChanged(sender As Object, e As EventArgs) Handles txtREFERENCE.TextChanged

        Dim s As String = txtREFERENCE.Text
        Dim i As Integer = s.IndexOf("_")
        Dim TinCombo As String = s.Substring(i + 1, s.IndexOf("_", i + 1) - i - 1)
        txtCODE.Text = TinCombo

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPARTICULARS.Text
            .ShowDialog()

        End With

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINANCE.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtGM.Text
            .ShowDialog()

        End With

    End Sub
End Class