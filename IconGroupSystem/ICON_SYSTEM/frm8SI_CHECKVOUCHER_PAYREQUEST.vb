Public Class frm8SI_CHECKVOUCHER_PAYREQUEST

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        With frm3COMMENT

            .txtCOMMENT_1.Text = txtCOMMENT_1.Text
            .txtCOMMENT_2.Text = txtCOMMENT_2.Text
            .txtCOMMENT_3.Text = txtCOMMENT_3.Text
            .ShowDialog()

        End With

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
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where controlno like '%" & TextBox1.Text & "%' AND `manager_approval` = 'APPROVED' AND `finance_approval` = 'APPROVED' AND `gm_approval` = 'APPROVED' AND `coo_approval` = 'APPROVED' AND `STATUS` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()

            cn.Close()

    End Sub

    Sub LoadList()

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where `manager_approval` = 'APPROVED' AND `finance_approval` = 'APPROVED' AND `gm_approval` = 'APPROVED' AND `coo_approval` = 'APPROVED' AND `STATUS` = 'ACTIVE' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()
            cn.Close()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmACCOUNTTITLE

            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()

        End With

    End Sub


    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged



    End Sub

    Sub LoadAccountTitle()

        DataGridView3.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from b_8si_account_title", cn)
        dr = cm.ExecuteReader
        While dr.Read

            DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("account_code").ToString, dr.Item("account_title").ToString, dr.Item("depcode_1").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub


    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If txtACCTCODE.Text = String.Empty Or txtACCTTITLE.Text = String.Empty Or txtACCTDEPCODE.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtDEBIT.Text = String.Empty Then

            If txtCREDIT.Text = String.Empty Then
                MsgBox("Please Input Credit Amount!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

        End If

        If txtCREDIT.Text = String.Empty Then

            If txtDEBIT.Text = String.Empty Then
                MsgBox("Please Input Debit Amount!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

        End If


        '=========================================================================================


        Try

            If txtCREDIT.Text = String.Empty Then

                dataGridView1.Rows.Add(txtACCTCODE.Text, txtACCTTITLE.Text, txtACCTDEPCODE.Text, CDbl(txtDEBIT.Text).ToString("#,##0.00"), CDbl(0).ToString("#,##0.00"))

            ElseIf txtDEBIT.Text = String.Empty Then

                dataGridView1.Rows.Add(txtACCTCODE.Text, txtACCTTITLE.Text, txtACCTDEPCODE.Text, CDbl(0).ToString("#,##0.00"), CDbl(txtCREDIT.Text).ToString("#,##0.00"))

                'Else
                '
                '                dataGridView1.Rows.Add(txtACCTCODE.Text, txtACCTTITLE.Text, txtACCTDEPCODE.Text, CDbl(txtDEBIT.Text).ToString("#,##0.00"), CDbl(txtCREDIT.Text).ToString("#,##0.00"))

            End If

            '=========================================================================================

            txtACCTCODE.Text = ""
            txtACCTTITLE.Text = ""
            txtACCTDEPCODE.SelectedIndex = -1
            txtDEBIT.Text = ""
            txtCREDIT.Text = ""

            btnSAVE.Enabled = True
            btnPRINT.Enabled = True

            Supplier_sum()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Sub Supplier_sum()

        Dim TOTALDEBIT As Decimal = 0
        Dim TOTALCREDIT As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALDEBIT += dataGridView1.Rows(i).Cells(3).Value
        Next

        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALCREDIT += dataGridView1.Rows(i).Cells(4).Value
        Next

        txtDEBITTOTAL.Text = CDbl(TOTALDEBIT).ToString("#,##0.00")
        txtCREDITTOTAL.Text = CDbl(TOTALCREDIT).ToString("#,##0.00")

    End Sub

    Private Sub DataGridView3_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView3.DoubleClick

        txtACCTCODE.Text = DataGridView3.CurrentRow.Cells(1).Value
        txtACCTTITLE.Text = DataGridView3.CurrentRow.Cells(2).Value
        txtACCTDEPCODE.Text = DataGridView3.CurrentRow.Cells(3).Value


        LoadDepCode()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Add Account title!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtDEBITTOTAL.Text <> txtCREDITTOTAL.Text Then

            MsgBox("Debit Total Amount and Credit Total Amount not Tally!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtREFERENCECODE.Text = "" Or txtSUBREFERENCECODE.Text = "" Or txtCHECKVOUCHERDATE.Text = "" Or txtCHECKNO.Text = "" Or txtBANK.Text = "" Or txtCHECKDATE.Text = "" Then

            MsgBox("Please Complete Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_8si_checkvoucher (reference, date, employee, department, depcode, supplier_name, payee_name, reference_code, subreference_code, checkvoucher_date, check_no, bank_branch, check_date, particulars, amount_due, debit_total, credit_total, manager_approval, manager_comment, gm_approval, gm_comment, coo_approval, coo_comment, date_time, status) values(@reference, @date, @employee, @department, @depcode, @supplier_name, @payee_name, @reference_code, @subreference_code, @checkvoucher_date, @check_no, @bank_branch, @check_date, @particulars, @amount_due, @debit_total, @credit_total, @manager_approval, @manager_comment, @gm_approval, @gm_comment, @coo_approval, @coo_comment, @date_time, @status)", cn)
            With cm.Parameters

                .AddWithValue("@reference", txtREFERENCE.Text)
                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@employee", txtEMPLOYEE.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@depcode", txtDEPCODE.Text)

                .AddWithValue("@supplier_name", txtSUPPLIER.Text)
                .AddWithValue("@payee_name", txtPAYEE.Text)

                .AddWithValue("@reference_code", txtREFERENCECODE.Text)
                .AddWithValue("@subreference_code", txtSUBREFERENCECODE.Text)

                .AddWithValue("@checkvoucher_date", txtCHECKVOUCHERDATE.Text)
                .AddWithValue("@check_no", txtCHECKNO.Text)
                .AddWithValue("@bank_branch", txtBANK.Text)
                .AddWithValue("@check_date", txtCHECKDATE.Text)

                .AddWithValue("@particulars", txtPARTICULARS.Text)

                .AddWithValue("@amount_due", txtAMOUNTDUE.Text)

                .AddWithValue("@debit_total", txtDEBITTOTAL.Text)
                .AddWithValue("@credit_total", txtCREDITTOTAL.Text)

                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@manager_comment", " ")

                .AddWithValue("@gm_approval", "FOR APPROVAL")
                .AddWithValue("@gm_comment", " ")

                .AddWithValue("@coo_approval", "FOR APPROVAL")
                .AddWithValue("@coo_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DisplayCVNO()
            SaveInCVList()

            CV_UPDATE()
            LoadList()

            btnSAVE.Enabled = False
            button3.Enabled = False
            btnPRINT.Enabled = True

            dataGridView1.Enabled = False

            txtPARTICULARS.Enabled = False
            txtCHECKVOUCHERDATE.Enabled = False
            txtCHECKNO.Enabled = False
            txtBANK.Enabled = False
            txtCHECKDATE.Enabled = False

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub CV_UPDATE()

        cn.Open()
        cm = New MySqlCommand("Update tbl_8si_paymentrequest set status=@status where id=@id", cn)

        With cm.Parameters

            .AddWithValue("@id", txtID.Text)
            .AddWithValue("@status", "CV PROCESSING")

        End With

        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub DisplayCVNO()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_8si_checkvoucher where `reference` = '" & txtREFERENCE.Text & "' ORDER BY id DESC LIMIT 1", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInCVList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_checkvoucher_accounttitle (cv_no, account_code, account_title, dep_code, debit, credit) values(@cv_no, @account_code, @account_title, @dep_code, @debit, @credit)", cn)
            With cm.Parameters

                .AddWithValue("@cv_no", txtCONTROL.Text)

                .AddWithValue("@account_code", row.Cells("account_code").Value)
                .AddWithValue("@account_title", row.Cells("account_title").Value)
                .AddWithValue("@dep_code", row.Cells("dep_code").Value)
                .AddWithValue("@debit", row.Cells("debit").Value)
                .AddWithValue("@credit", row.Cells("credit").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

        MsgBox("Check Voucher has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

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

        txtCHECKVOUCHERDATE.Text = Now.Date

        txtACCTDEPCODE.SelectedIndex = -1


        txtCHECKNO.Text = String.Empty
        txtCHECKNO.Text = ""

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString

                txtSUPPLIER.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString
                txtPAYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString

                txtAMOUNTDUE.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString

                txtPARTICULARS.Text = DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString
                txtREFERENCECODE.Text = DataGridView2.Rows(e.RowIndex).Cells(19).Value.ToString
                txtSUBREFERENCECODE.Text = DataGridView2.Rows(e.RowIndex).Cells(20).Value.ToString

                txtCOMMENT_1.Text = DataGridView2.Rows(e.RowIndex).Cells(21).Value.ToString
                txtCOMMENT_2.Text = DataGridView2.Rows(e.RowIndex).Cells(22).Value.ToString
                txtCOMMENT_3.Text = DataGridView2.Rows(e.RowIndex).Cells(24).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnSAVE.Enabled = True
            btnPRINT.Enabled = False
            button3.Enabled = True

            dataGridView1.Enabled = True

            txtPARTICULARS.Enabled = True
            txtCHECKVOUCHERDATE.Enabled = True
            txtCHECKNO.Enabled = True
            txtBANK.Enabled = True
            txtCHECKDATE.Enabled = True

            LoadSupplierList()

        End If

    End Sub

    Private Sub txtAMOUNTDUE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAMOUNTDUE.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub txtCREDIT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCREDIT.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub txtDEBIT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDEBIT.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub txtAMOUNTDUE_Leave(sender As Object, e As EventArgs) Handles txtAMOUNTDUE.Leave

        If txtAMOUNTDUE.Text = String.Empty Then

            Exit Sub

        Else

            txtAMOUNTDUE.Text = CDbl(txtAMOUNTDUE.Text).ToString("#,##0.00")

        End If

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()

    End Sub


    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim header As New Font("Arial Black", 12, FontStyle.Regular)
        Dim f8b As New Font("Verdana", 8, FontStyle.Regular)

        Dim left As New StringFormat
        Dim center As New StringFormat
        Dim right As New StringFormat

        left.Alignment = StringAlignment.Near
        center.Alignment = StringAlignment.Center
        right.Alignment = StringAlignment.Far

        'height, width, length, 
        Dim rect1 As New Rectangle(50, 100, 750, 25)
        Dim brush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush, rect1)

        e.Graphics.DrawRectangle(Pens.Black, rect1)

        e.Graphics.DrawImage(Me.PictureBox1.Image, 320, 30, PictureBox1.Width - 15, PictureBox1.Height - 25)

        e.Graphics.DrawString("PAYMENT VOUCHER", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim line As New Font("Arial Black", 10, FontStyle.Bold)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)

        e.Graphics.DrawString("VOUCHER#", sign, Brushes.Black, 530, 150)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 150)
        e.Graphics.DrawString("EMPLOYEE NAME", sign, Brushes.Black, 50, 170)
        e.Graphics.DrawString("DEPARTMENT", sign, Brushes.Black, 50, 190)
        e.Graphics.DrawString("PAYRE#", sign, Brushes.Black, 50, 210)

        e.Graphics.DrawString(":", title, Brushes.Black, 620, 150)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 170)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 190)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 210)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 630, 150)

        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 230, 150)
        e.Graphics.DrawString(txtEMPLOYEE.Text, title, Brushes.Black, 230, 170)
        e.Graphics.DrawString(txtDEPARTMENT.Text, title, Brushes.Black, 230, 190)
        e.Graphics.DrawString(txtREFERENCE.Text, title, Brushes.Black, 230, 210)

        '================================================================================

        Dim box1 As New Rectangle(50, 240, 150, 20)
        Dim box2 As New Rectangle(50, 260, 150, 20)

        Dim box3 As New Rectangle(200, 240, 600, 20)
        Dim box4 As New Rectangle(200, 260, 600, 20)

        Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, box1)
        e.Graphics.FillRectangle(brush3, box2)

        Dim brush03 As SolidBrush = New SolidBrush(Color.White)
        e.Graphics.FillRectangle(brush03, box3)
        e.Graphics.FillRectangle(brush03, box4)

        e.Graphics.DrawRectangle(Pens.White, box1)
        e.Graphics.DrawRectangle(Pens.White, box2)

        e.Graphics.DrawRectangle(Pens.Black, box3)
        e.Graphics.DrawRectangle(Pens.Black, box4)

        e.Graphics.DrawString("SUPPLIER NAME", line, Brushes.White, box1, left)
        e.Graphics.DrawString("PAYEE NAME", line, Brushes.White, box2, left)

        e.Graphics.DrawString(txtSUPPLIER.Text, line, Brushes.Black, box3, left)
        e.Graphics.DrawString(txtPAYEE.Text, line, Brushes.Black, box4, left)

        '================================================================================

        e.Graphics.DrawString("REFERENCE", sign, Brushes.Black, 530, 300)
        e.Graphics.DrawString("SUB-REFERENCE", sign, Brushes.Black, 530, 320)

        e.Graphics.DrawString("VOUCHER DATE", sign, Brushes.Black, 50, 300)
        e.Graphics.DrawString("CHECK NO", sign, Brushes.Black, 50, 320)
        e.Graphics.DrawString("BRANK/BRANCH", sign, Brushes.Black, 50, 340)
        e.Graphics.DrawString("CHECK DATE", sign, Brushes.Black, 50, 360)

        e.Graphics.DrawString(":", title, Brushes.Black, 620, 300)
        e.Graphics.DrawString(":", title, Brushes.Black, 620, 320)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 300)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 320)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 340)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 360)

        e.Graphics.DrawString(txtREFERENCECODE.Text, title, Brushes.Black, 630, 300)
        e.Graphics.DrawString(txtSUBREFERENCECODE.Text, title, Brushes.Black, 630, 320)

        e.Graphics.DrawString(txtCHECKVOUCHERDATE.Text, title, Brushes.Black, 230, 300)
        e.Graphics.DrawString(txtCHECKNO.Text, title, Brushes.Black, 230, 320)
        e.Graphics.DrawString(txtBANK.Text, title, Brushes.Black, 230, 340)
        e.Graphics.DrawString(txtCHECKDATE.Text, title, Brushes.Black, 230, 360)

        '================================================================================

        Dim totalamount1 As New Rectangle(530, 360, 100, 20)
        Dim totalamount2 As New Rectangle(630, 360, 170, 20)

        Dim brushtotalamount As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brushtotalamount, totalamount1)

        Dim brushtotalamount1 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(brushtotalamount1, totalamount2)

        e.Graphics.DrawRectangle(Pens.White, totalamount1)
        e.Graphics.DrawRectangle(Pens.White, totalamount2)

        e.Graphics.DrawString("AMOUNT DUE", title, Brushes.White, totalamount1, left)
        e.Graphics.DrawString(txtAMOUNTDUE.Text, title, Brushes.White, totalamount2, right)

        '================================================================================

        Dim remarks As New Rectangle(50, 400, 750, 20)

        Dim remarksbrush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(remarksbrush, remarks)

        e.Graphics.DrawRectangle(Pens.White, remarks)

        e.Graphics.DrawString("PARTICULARS", line, Brushes.White, remarks, left)

        '=======================================================================================

        Dim comment As New Rectangle(50, 420, 750, 70)

        Dim commentbox As SolidBrush = New SolidBrush(Color.White)
        e.Graphics.FillRectangle(commentbox, comment)

        e.Graphics.DrawRectangle(Pens.Black, comment)

        e.Graphics.DrawString(txtPARTICULARS.Text, sign, Brushes.Black, comment, left)

        '=======================================================================================

        Dim actlabel1 As New Rectangle(50, 520, 100, 18)
        Dim actlabel2 As New Rectangle(150, 520, 300, 18)
        Dim actlabel3 As New Rectangle(450, 520, 110, 18)
        Dim actlabel4 As New Rectangle(560, 520, 120, 18)
        Dim actlabel5 As New Rectangle(680, 520, 120, 18)

        Dim labelbrush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, actlabel1)
        e.Graphics.FillRectangle(brush3, actlabel2)
        e.Graphics.FillRectangle(brush3, actlabel3)
        e.Graphics.FillRectangle(brush3, actlabel4)
        e.Graphics.FillRectangle(brush3, actlabel5)

        e.Graphics.DrawRectangle(Pens.White, actlabel1)
        e.Graphics.DrawRectangle(Pens.White, actlabel2)
        e.Graphics.DrawRectangle(Pens.White, actlabel3)
        e.Graphics.DrawRectangle(Pens.White, actlabel4)
        e.Graphics.DrawRectangle(Pens.White, actlabel5)

        e.Graphics.DrawString("ACCT.CODE", data, Brushes.White, actlabel1, center)
        e.Graphics.DrawString("ACCOUNT TITLE", data, Brushes.White, actlabel2, center)
        e.Graphics.DrawString("DEP.CODE", data, Brushes.White, actlabel3, center)
        e.Graphics.DrawString("DEBIT", data, Brushes.White, actlabel4, center)
        e.Graphics.DrawString("CREDIT", data, Brushes.White, actlabel5, center)

        '=======================================================================================

        Dim y As Integer = 520

        For i = 0 To dataGridView1.Rows.Count - 1
            y += 18

            Dim data1 As New Rectangle(50, y, 100, 20)
            Dim data2 As New Rectangle(150, y, 300, 20)
            Dim data3 As New Rectangle(450, y, 110, 20)
            Dim data4 As New Rectangle(560, y, 120, 20)
            Dim data5 As New Rectangle(680, y, 120, 20)

            Dim brush5 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush5, data1)
            e.Graphics.FillRectangle(brush5, data2)
            e.Graphics.FillRectangle(brush5, data3)
            e.Graphics.FillRectangle(brush5, data4)
            e.Graphics.FillRectangle(brush5, data5)

            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)
            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(0).Value, data, Brushes.Black, data1, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(1).Value, data, Brushes.Black, data2, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(2).Value, data, Brushes.Black, data3, left)
            e.Graphics.DrawString(CDbl(dataGridView1.Rows(i).Cells(3).Value).ToString("#,##0.00"), data, Brushes.Black, data4, right)
            e.Graphics.DrawString(CDbl(dataGridView1.Rows(i).Cells(4).Value).ToString("#,##0.00"), data, Brushes.Black, data5, right)

            '=============================================================================

            Dim x As Integer = 900

            x += 18

            Dim title1 As New Rectangle(20, x, 162, 20)
            Dim title2 As New Rectangle(182, x, 162, 20)
            Dim title3 As New Rectangle(344, x, 162, 20)
            Dim title4 As New Rectangle(506, x, 162, 20)
            Dim title5 As New Rectangle(668, x, 162, 20)

            Dim brush6 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush6, title1)
            e.Graphics.FillRectangle(brush6, title2)
            e.Graphics.FillRectangle(brush6, title3)
            e.Graphics.FillRectangle(brush6, title4)
            e.Graphics.FillRectangle(brush6, title5)

            e.Graphics.DrawRectangle(Pens.White, title1)
            e.Graphics.DrawRectangle(Pens.White, title2)
            e.Graphics.DrawRectangle(Pens.White, title3)
            e.Graphics.DrawRectangle(Pens.White, title4)
            e.Graphics.DrawRectangle(Pens.White, title5)

            e.Graphics.DrawString("PREPARED BY:", sign, Brushes.Black, title1, left)
            e.Graphics.DrawString("REVIEWED BY:", sign, Brushes.Black, title2, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title3, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title4, left)
            e.Graphics.DrawString("RECEIVED BY:", sign, Brushes.Black, title5, left)

            '=============================================================================

            Dim s As Integer = 940

            s += 18

            Dim sign1 As New Rectangle(20, s, 162, 20)
            Dim sign2 As New Rectangle(182, s, 162, 20)
            Dim sign3 As New Rectangle(344, s, 162, 20)
            Dim sign4 As New Rectangle(506, s, 162, 20)
            Dim sign5 As New Rectangle(668, s, 162, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign3)
            e.Graphics.FillRectangle(brush7, sign4)
            e.Graphics.FillRectangle(brush7, sign5)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign3)
            e.Graphics.DrawRectangle(Pens.White, sign4)
            e.Graphics.DrawRectangle(Pens.White, sign5)

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign, Brushes.Black, sign1, left)
            e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign2, left)
            e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign3, left)
            e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign4, left)
            e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign5, left)

            '=============================================================================

            Dim l As Integer = 960

            l += 18

            Dim label1 As New Rectangle(20, l, 162, 20)
            Dim label2 As New Rectangle(182, l, 162, 20)
            Dim label3 As New Rectangle(344, l, 162, 20)
            Dim label4 As New Rectangle(506, l, 162, 20)
            Dim label5 As New Rectangle(668, l, 162, 20)

            Dim brush8 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush8, label1)
            e.Graphics.FillRectangle(brush8, label2)
            e.Graphics.FillRectangle(brush8, label3)
            e.Graphics.FillRectangle(brush8, label4)
            e.Graphics.FillRectangle(brush8, label5)

            e.Graphics.DrawRectangle(Pens.White, label1)
            e.Graphics.DrawRectangle(Pens.White, label2)
            e.Graphics.DrawRectangle(Pens.White, label3)
            e.Graphics.DrawRectangle(Pens.White, label4)
            e.Graphics.DrawRectangle(Pens.White, label5)

            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, label1, left)
            e.Graphics.DrawString("FINANCE MANAGER", label, Brushes.Black, label2, left)
            e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, label3, left)
            e.Graphics.DrawString("CHIEF OPERATING OFFICE", label, Brushes.Black, label4, left)
            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, label5, left)


        Next

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtACCTCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtACCTTITLE.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtACCTDEPCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtDEBIT.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtCREDIT.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString

                Supplier_sum()

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtACCTCODE.Text
                update.Cells(1).Value = txtACCTTITLE.Text
                update.Cells(2).Value = txtACCTDEPCODE.Text
                update.Cells(3).Value = txtDEBIT.Text
                update.Cells(4).Value = txtCREDIT.Text

                txtACCTCODE.Text = ""
                txtACCTTITLE.Text = ""
                txtACCTDEPCODE.Text = ""
                txtDEBIT.Text = ""
                txtCREDIT.Text = ""

                Supplier_sum()

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows(0).Index)

                        Supplier_sum()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)

                End Try

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frm8SI_CHECKVOUCHER_PAYREQUEST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button4_Click(sender As Object, e As EventArgs)

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPARTICULARS.Text
            .ShowDialog()

        End With


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPARTICULARS.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        DataGridView3.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from b_8si_account_title where account_title like '%" & TextBox5.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("account_code").ToString, dr.Item("account_title").ToString, dr.Item("depcode_1").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        DataGridView4.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance where supplier_name like '%" & TextBox2.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView4.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()


    End Sub

    Private Sub DataGridView4_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView4.DoubleClick

        If txtSUPPLIER.Text = String.Empty Then

            txtSUPPLIER.Text = DataGridView4.CurrentRow.Cells(1).Value

        ElseIf txtSUPPLIER.Text <> "" And txtPAYEE.Text = String.Empty Then

            txtPAYEE.Text = DataGridView4.CurrentRow.Cells(1).Value

        Else

            MsgBox("Both Supplier Name and Payee Name has Value!", vbInformation + vbOKOnly, "CONFIRMATION")

        End If

    End Sub

    Sub LoadSupplierList()

        DataGridView4.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance", cn)
        dr = cm.ExecuteReader
        While dr.Read

            DataGridView4.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        txtPAYEE.Text = String.Empty
        txtPAYEE.Text = ""

    End Sub

    Sub LoadDepCode()

        txtACCTDEPCODE.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from b_8si_account_title where `account_code` like '%" & txtACCTCODE.Text & "%' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtACCTDEPCODE.Items.Add(dr.Item("depcode_1").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_2").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_3").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_4").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_5").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_6").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_7").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_8").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_9").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_10").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_11").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_12").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_13").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_14").ToString)
            txtACCTDEPCODE.Items.Add(dr.Item("depcode_15").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

End Class