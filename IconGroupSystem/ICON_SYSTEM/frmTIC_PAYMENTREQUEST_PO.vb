Public Class frmTIC_PAYMENTREQUEST_PO

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Public Function AmountInWords(ByVal nAmount As String, Optional ByVal wAmount _
                 As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then _
            tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                    > (CLng(intAmount.ToString.Trim.Length / 3)), _
                  CLng(intAmount.ToString.Trim.Length / 3) + 1, _
                    CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim, _
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = _
                {"", "One", "Two", "Three", _
                  "Four", "Five", _
                  "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", _
                "Eleven", "Twelve", "Thirteen", _
                  "Fourteen", "Fifteen", _
                  "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", _
                "Twenty", "Thirty", _
                  "Forty", "Fifty", "Sixty", _
                  "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", _
                "Thousand", "Million", _
                  "Billion", "Trillion", _
                  "Quadrillion", "Quintillion"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                If nHundred > 0 Then wAmount = wAmount & _
                Ones(nHundred) & " Hundred " 'This is for hundreds                
                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If
                wAmount = wAmount & HMBT(nSet) & " "
                wAmount = AmountInWords(CStr(CLng(nAmount) - _
                  (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
            Else
                If Val(nAmount) = 0 Then nAmount = nAmount & _
                tempDecValue : tempDecValue = String.Empty
                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount = _
                  Trim(AmountInWords(CStr(Math.Round(Val(nAmount), 2) * 100), _
                  wAmount.Trim & " Pesos And ", 1)) & " Cents"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Encountered: " & ex.Message, _
              "Convert Numbers To Words", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount = _
          IIf(InStr(wAmount.Trim.ToLower, "pesos"), _
          wAmount.Trim, wAmount.Trim & " Pesos")

        'Display the result
        Return wAmount
    End Function


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

    Private Sub txtAMOUNT_TextChanged(sender As Object, e As EventArgs) Handles txtAMOUNT.TextChanged

        txtAMOUNTWORDS.Text = AmountInWords(txtAMOUNT.Text)

        txtLESSAMOUNT.Text = txtPOAMOUNT.Text - txtAMOUNT.Text

    End Sub

    Private Sub txtMODERELEASE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtMODERELEASE.SelectedIndexChanged

        If txtMODERELEASE.Text = "DEPOSIT" Then

            txtACCOUNTNAME.Enabled = True
            txtACCOUNTNO.Enabled = True
            txtBANKNAME.Enabled = True

        Else

            txtACCOUNTNAME.Enabled = False
            txtACCOUNTNO.Enabled = False
            txtBANKNAME.Enabled = False

        End If

        '================================================

        If txtMODERELEASE.Text = "OTHERS" Then

            txtOTHERS.Enabled = True

        Else

            txtOTHERS.Enabled = False

        End If

        '================================================


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtDATENEEDED.Text < Now.AddDays(-1) Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATENEEDED.Focus()
            Return

        End If

        If txtPAYMENTTYPE.Text = "" Or txtDATENEEDED.Text = "" Or txtMODEPAYMENT.Text = "" Or txtMODERELEASE.Text = "" Or txtSUPPLIER_SELECT.Text = "" Or txtAMOUNT.Text = "" Or txtAMOUNTWORDS.Text = "" Or txtREMARKS.Text = "" Or txtREFERENCECODE.Text = "" Then

            MsgBox("Please complete data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtMODERELEASE.Text = "OTHERS" Then

            If txtOTHERS.Text = "" Then

                MsgBox("Please complete data!", vbOKOnly + vbCritical, "CONFIRMATION")
                Return

            End If

        End If

        If txtMODERELEASE.Text = "DEPOSIT" Then

            If txtACCOUNTNAME.Text = "" Or txtACCOUNTNO.Text = "" Or txtBANKNAME.Text = "" Then

                MsgBox("Please complete data!", vbOKOnly + vbCritical, "CONFIRMATION")
                Return

            End If

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_tic_paymentrequest (transaction_no, employee, department, depcode, type_payment, date_needed, mode_payment, date, mode_release, supplier_name, account_name, account_no, bank_name, amount, amount_words, payment_remarks, reference_code, sub_referencecode, manager_approval, manager_comment, finance_approval, finance_comment, gm_approval, gm_comment, coo_approval, coo_comment, date_time, status) values(@transaction_no, @employee, @department, @depcode, @type_payment, @date_needed, @mode_payment, @date, @mode_release, @supplier_name, @account_name, @account_no, @bank_name, @amount, @amount_words, @payment_remarks, @reference_code, @sub_referencecode, @manager_approval, @manager_comment, @finance_approval, @finance_comment, @gm_approval, @gm_comment, @coo_approval, @coo_comment, @date_time, @status)", cn)

            With cm.Parameters

                .AddWithValue("@transaction_no", txtPONO.Text)
                .AddWithValue("@employee", txtEMPLOYEE.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@depcode", txtDEPCODE.Text)

                .AddWithValue("@type_payment", txtPAYMENTTYPE.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@mode_payment", txtMODEPAYMENT.Text)
                .AddWithValue("@date", DateTimePicker1.Value)

                If txtMODERELEASE.Text = "OTHERS" Then

                    .AddWithValue("@mode_release", txtOTHERS.Text)

                Else

                    .AddWithValue("@mode_release", txtMODERELEASE.Text)

                End If

                .AddWithValue("@supplier_name", txtSUPPLIER_SELECT.Text)

                If txtMODERELEASE.Text = "DEPOSIT" Then

                    .AddWithValue("@account_name", txtACCOUNTNAME.Text)
                    .AddWithValue("@account_no", txtACCOUNTNO.Text)
                    .AddWithValue("@bank_name", txtBANKNAME.Text)

                Else

                    .AddWithValue("@account_name", " ")
                    .AddWithValue("@account_no", " ")
                    .AddWithValue("@bank_name", " ")

                End If

                .AddWithValue("@amount", txtAMOUNT.Text)
                .AddWithValue("@amount_words", txtAMOUNTWORDS.Text)
                .AddWithValue("@payment_remarks", txtREMARKS.Text)

                .AddWithValue("@reference_code", txtREFERENCECODE.Text)
                .AddWithValue("@sub_referencecode", txtSUBREFERENCECODE.Text)

                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@manager_comment", " ")

                .AddWithValue("@finance_approval", "FOR APPROVAL")
                .AddWithValue("@finance_comment", " ")

                .AddWithValue("@gm_approval", "FOR APPROVAL")
                .AddWithValue("@gm_comment", " ")

                .AddWithValue("@coo_approval", "FOR APPROVAL")
                .AddWithValue("@coo_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()
            DisplayNO()

            PO_UPDATE()
            LoadPOList()

            MsgBox("Payment Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub PO_UPDATE()

        If txtLESSAMOUNT.Text = 0 Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_tic_purchasedorder set status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@status", "ON-GOING CV")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        Else

            Exit Sub

        End If

    End Sub

    Sub DisplayNO()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_tic_paymentrequest where transaction_no = '" & txtPONO.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

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

        e.Graphics.DrawString("P A Y M E N T  R E Q U E S T", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim line As New Font("Arial Black", 10, FontStyle.Bold)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)

        e.Graphics.DrawString("CONTROL#", sign, Brushes.Black, 500, 150)
        e.Graphics.DrawString("DATE NEEDED", sign, Brushes.Black, 500, 170)
        e.Graphics.DrawString("MODE OF PAYMENT", sign, Brushes.Black, 500, 190)
        e.Graphics.DrawString("MODE OF RELEASE", sign, Brushes.Black, 500, 210)
        e.Graphics.DrawString("SUB REFERENCE", sign, Brushes.Black, 500, 230)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 150)
        e.Graphics.DrawString("EMPLOYEE NAME", sign, Brushes.Black, 50, 170)
        e.Graphics.DrawString("DEPARTMENT", sign, Brushes.Black, 50, 190)
        e.Graphics.DrawString("TYPE OF PAYMENT", sign, Brushes.Black, 50, 210)
        e.Graphics.DrawString("REFERENCE", sign, Brushes.Black, 50, 210)

        e.Graphics.DrawString(":", title, Brushes.Black, 620, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 620, 170)
        e.Graphics.DrawString(":", title, Brushes.Black, 620, 190)
        e.Graphics.DrawString(":", title, Brushes.Black, 620, 210)
        e.Graphics.DrawString(":", title, Brushes.Black, 620, 230)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 170)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 190)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 210)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 230)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 630, 150)
        e.Graphics.DrawString(txtDATENEEDED.Text, title, Brushes.Black, 630, 170)
        e.Graphics.DrawString(txtMODEPAYMENT.Text, title, Brushes.Black, 630, 190)

        If txtMODERELEASE.Text = "OTHERS" Then

            e.Graphics.DrawString(txtOTHERS.Text, title, Brushes.Black, 630, 210)

        Else

            e.Graphics.DrawString(txtMODERELEASE.Text, title, Brushes.Black, 630, 210)

        End If
        e.Graphics.DrawString(txtSUBREFERENCECODE.Text, title, Brushes.Black, 630, 230)

        e.Graphics.DrawString(DateTimePicker1.Value, title, Brushes.Black, 230, 150)
        e.Graphics.DrawString(txtEMPLOYEE.Text, title, Brushes.Black, 230, 170)
        e.Graphics.DrawString(txtDEPARTMENT.Text, title, Brushes.Black, 230, 190)
        e.Graphics.DrawString(txtPAYMENTTYPE.Text, title, Brushes.Black, 230, 210)
        e.Graphics.DrawString(txtREFERENCECODE.Text, title, Brushes.Black, 230, 230)

        '=======================================================================================

        Dim rect2 As New Rectangle(50, 250, 750, 20)
        Dim brush2 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(brush2, rect2)

        e.Graphics.DrawRectangle(Pens.Black, rect2)

        e.Graphics.DrawString("", header, Brushes.White, rect2, center)

        '=======================================================================================

        e.Graphics.DrawString("SUPPLIER NAME", sign, Brushes.Black, 50, 280)

        e.Graphics.DrawString("IF MODE OF RELEASE IS DEPOSIT", label, Brushes.Black, 100, 300)

        e.Graphics.DrawString("ACCOUNT NAME", sign, Brushes.Black, 100, 320)
        e.Graphics.DrawString("ACCOUNT NO", sign, Brushes.Black, 100, 340)
        e.Graphics.DrawString("BANK NAME", sign, Brushes.Black, 100, 360)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 280)

        e.Graphics.DrawString(":", title, Brushes.Black, 250, 320)
        e.Graphics.DrawString(":", title, Brushes.Black, 250, 340)
        e.Graphics.DrawString(":", title, Brushes.Black, 250, 360)

        e.Graphics.DrawString(txtSUPPLIER_SELECT.Text, title, Brushes.Black, 280, 280)

        e.Graphics.DrawString(txtACCOUNTNAME.Text, title, Brushes.Black, 280, 320)
        e.Graphics.DrawString(txtACCOUNTNO.Text, title, Brushes.Black, 280, 340)
        e.Graphics.DrawString(txtBANKNAME.Text, title, Brushes.Black, 280, 360)

        '=======================================================================================

        Dim box1 As New Rectangle(50, 400, 200, 20)
        Dim box2 As New Rectangle(250, 400, 550, 20)

        Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, box1)
        e.Graphics.FillRectangle(brush3, box2)

        e.Graphics.DrawRectangle(Pens.White, box1)
        e.Graphics.DrawRectangle(Pens.White, box2)

        e.Graphics.DrawString("AMOUNT", line, Brushes.White, box1, center)
        e.Graphics.DrawString("AMOUNT IN WORDS", line, Brushes.White, box2, center)

        '=======================================================================================

        Dim amount As New Rectangle(50, 423, 200, 20)
        Dim words As New Rectangle(250, 423, 550, 20)

        Dim box As SolidBrush = New SolidBrush(Color.White)
        e.Graphics.FillRectangle(box, amount)
        e.Graphics.FillRectangle(box, words)

        e.Graphics.DrawRectangle(Pens.Black, amount)
        e.Graphics.DrawRectangle(Pens.Black, words)

        e.Graphics.DrawString(txtAMOUNT.Text, line, Brushes.Black, amount, right)
        e.Graphics.DrawString(txtAMOUNTWORDS.Text, line, Brushes.Black, words, left)

        '=======================================================================================

        Dim remarks As New Rectangle(50, 470, 750, 20)

        Dim remarksbrush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(remarksbrush, remarks)

        e.Graphics.DrawRectangle(Pens.White, remarks)

        e.Graphics.DrawString("PAYMENT REMARKS", line, Brushes.White, remarks, left)

        '=======================================================================================

        Dim comment As New Rectangle(50, 493, 750, 70)

        Dim commentbox As SolidBrush = New SolidBrush(Color.White)
        e.Graphics.FillRectangle(commentbox, comment)

        e.Graphics.DrawRectangle(Pens.Black, comment)

        e.Graphics.DrawString(txtREMARKS.Text, sign, Brushes.Black, comment, left)

        '=======================================================================================


        'S I G N A T U R E =====================================================================

        Dim x As Integer = 600

        x += 18

        Dim title1 As New Rectangle(20, x, 162, 20)
        Dim title2 As New Rectangle(182, x, 162, 20)
        Dim title3 As New Rectangle(344, x, 162, 20)
        Dim title4 As New Rectangle(520, x, 162, 20)
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

        e.Graphics.DrawString("REQUESTED BY:", sign, Brushes.Black, title1, left)
        e.Graphics.DrawString("ENDORSED BY:", sign, Brushes.Black, title2, left)
        e.Graphics.DrawString("REVIEWED BY:", sign, Brushes.Black, title3, left)
        e.Graphics.DrawString("RECOMMENEDED BY:", sign, Brushes.Black, title4, left)
        e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title5, left)

        '=============================================================================

        Dim s As Integer = 640

        s += 18

        Dim sign1 As New Rectangle(20, s, 162, 20)
        Dim sign2 As New Rectangle(182, s, 162, 20)
        Dim sign3 As New Rectangle(344, s, 162, 20)
        Dim sign4 As New Rectangle(520, s, 162, 20)
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

        Dim l As Integer = 660

        l += 18

        Dim label1 As New Rectangle(20, l, 162, 20)
        Dim label2 As New Rectangle(182, l, 162, 20)
        Dim label3 As New Rectangle(344, l, 162, 20)
        Dim label4 As New Rectangle(520, l, 162, 20)
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
        e.Graphics.DrawString("DEPARTMENT MANAGER", label, Brushes.Black, label2, left)
        e.Graphics.DrawString("FINANCE MANAGER", label, Brushes.Black, label3, left)
        e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, label4, left)
        e.Graphics.DrawString("CHIEF OPERATING OFFICER", label, Brushes.Black, label5, left)


    End Sub

    '===================================================================================================

    Sub LoadPOList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorder where `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'FOR APPROVAL' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorder where `po_no` like '%" & TextBox1.Text & "%' AND `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'FOR APPROVAL' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

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
        DataGridView2.Columns.Insert(14, colApproval)

    End Sub

    Sub LoadItemList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorderlist where `po_no` like '" & txtPAYMENTTYPE.Text & "' and supplier_name like '" & txtSUPPLIER_SELECT.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Sub Supplier_sum()

        Dim GRANDTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            GRANDTOTAL_1 += dataGridView1.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        txtPOAMOUNT.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.00")

        txtAMOUNT.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.00")

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_tic_purchasedorder where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtPAYMENTTYPE.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtPONO.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATENEEDED.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtSUPPLIER_SELECT.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString

            End While
            dr.Close()
            cn.Close()
            LoadItemList()
            Supplier_sum()

            btnSAVE.Enabled = True

        End If

    End Sub

    Private Sub frmTIC_PAYMENTREQUEST_PO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtREMARKS.Text
            .ShowDialog()

        End With

    End Sub
End Class