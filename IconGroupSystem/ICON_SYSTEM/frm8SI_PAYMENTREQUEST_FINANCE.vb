Public Class frm8SI_PAYMENTREQUEST_FINANCE

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub txtAMOUNT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAMOUNT.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub txtAMOUNT_Leave(sender As Object, e As EventArgs) Handles txtAMOUNT.Leave

        txtAMOUNT.Text = CDbl(txtAMOUNT.Text).ToString("#,##0.00")

    End Sub

    '===================================================================================================

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPCODE.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtPAYMENTTYPE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString
                txtDATENEEDED.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtMODEPAYMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString

                txtMODERELEASE.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtSUPPLIER_SELECT.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString
                txtACCOUNTNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString
                txtACCOUNTNO.Text = DataGridView2.Rows(e.RowIndex).Cells(14).Value.ToString
                txtBANKNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString
                txtAMOUNT.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString
                txtAMOUNTWORDS.Text = DataGridView2.Rows(e.RowIndex).Cells(17).Value.ToString
                txtREMARKS.Text = DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString
                txtREFERENCECODE.Text = DataGridView2.Rows(e.RowIndex).Cells(19).Value.ToString
                txtSUBREFERENCECODE.Text = DataGridView2.Rows(e.RowIndex).Cells(20).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(21).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnAPPROVED.Enabled = True
            btnDISAPPROVED.Enabled = True
            btnRETURN.Enabled = True

        End If

    End Sub

    Sub LoadList()

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where `manager_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `gm_approval` = 'FOR APPROVAL' AND `coo_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

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
            .Text = ">"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView2.Columns.Insert(25, colApproval)

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where controlno like '%" & TextBox1.Text & "%' AND `manager_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `gm_approval` = 'FOR APPROVAL' AND `coo_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()

            cn.Close()

    End Sub

    Private Sub btnAPPROVED_Click(sender As Object, e As EventArgs) Handles btnAPPROVED.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_paymentrequest set finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "APPROVED")
                .AddWithValue("@finance_comment", txtFINANCE.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadList()

            btnAPPROVED.Enabled = False
            btnDISAPPROVED.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("Payment Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub btnDISAPPROVED_Click(sender As Object, e As EventArgs) Handles btnDISAPPROVED.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_paymentrequest set finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "DISAPPROVED")
                .AddWithValue("@finance_comment", txtFINANCE.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "DEACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadList()

            btnAPPROVED.Enabled = False
            btnDISAPPROVED.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("Payment Request has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub btnRETURN_Click(sender As Object, e As EventArgs) Handles btnRETURN.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_paymentrequest set manager_approval=@manager_approval, finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@finance_approval", "FOR APPROVAL")
                .AddWithValue("@finance_comment", txtFINANCE.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "RETURNED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadList()

            btnAPPROVED.Enabled = False
            btnDISAPPROVED.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("Payment Request has been Successfully Return!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub frm8SI_PAYMENTREQUEST_FINANCE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtREMARKS.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINANCE.Text
            .ShowDialog()

        End With

    End Sub
End Class