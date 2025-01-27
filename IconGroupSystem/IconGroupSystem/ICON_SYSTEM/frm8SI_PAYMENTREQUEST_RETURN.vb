Public Class frm8SI_PAYMENTREQUEST_RETURN

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

                txtDATA.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString

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
                txtFINANCE.Text = DataGridView2.Rows(e.RowIndex).Cells(22).Value.ToString
                txtGM.Text = DataGridView2.Rows(e.RowIndex).Cells(23).Value.ToString
                txtCOO.Text = DataGridView2.Rows(e.RowIndex).Cells(24).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnSAVE.Enabled = True
            btnPRINT.Enabled = False

            LoadSupplierList()

        End If

    End Sub

    Sub LoadList()

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where `STATUS` = 'RETURNED' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

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

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where controlno like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_paymentrequest where controlno like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        End If

    End Sub

    Private Sub txtAMOUNT_TextChanged(sender As Object, e As EventArgs) Handles txtAMOUNT.TextChanged

        txtAMOUNTWORDS.Text = AmountInWords(txtAMOUNT.Text)

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
        e.Graphics.DrawString("REFERENCE", sign, Brushes.Black, 50, 230)

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
        e.Graphics.DrawString(txtMODERELEASE.Text, title, Brushes.Black, 630, 210)
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

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtDATENEEDED.Text < Now.AddDays(-1) Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATENEEDED.Focus()
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_paymentrequest set type_payment=@type_payment, date_needed=@date_needed, mode_payment=@mode_payment, date=@date, mode_release=@mode_release, account_name=@account_name, account_no=@account_no, bank_name=@bank_name, amount=@amount, amount_words=@amount_words, payment_remarks=@payment_remarks, reference_code=@reference_code, sub_referencecode=@sub_referencecode, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@type_payment", txtPAYMENTTYPE.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@mode_payment", txtMODEPAYMENT.Text)
                .AddWithValue("@date", DateTimePicker1.Value)

                .AddWithValue("@mode_release", txtMODERELEASE.Text)

                .AddWithValue("@account_name", txtACCOUNTNAME.Text)
                .AddWithValue("@account_no", txtACCOUNTNO.Text)
                .AddWithValue("@bank_name", txtBANKNAME.Text)


                .AddWithValue("@amount", txtAMOUNT.Text)
                .AddWithValue("@amount_words", txtAMOUNTWORDS.Text)
                .AddWithValue("@payment_remarks", txtREMARKS.Text)

                .AddWithValue("@reference_code", txtREFERENCECODE.Text)
                .AddWithValue("@sub_referencecode", txtSUBREFERENCECODE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadList()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True

            MsgBox("Payment Request has been Successfully Updated!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

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


    Private Sub txtDATA_TextChanged(sender As Object, e As EventArgs) Handles txtDATA.TextChanged

        If txtDATA.Text = "PICK-UP" Then

            txtMODERELEASE.Text = "PICK-UP"

        ElseIf txtDATA.Text = "DEPOSIT" Then

            txtMODERELEASE.Text = "DEPOSIT"

        Else

            txtMODERELEASE.Text = "OTHERS"
            txtOTHERS.Text = txtDATA.Text

        End If

    End Sub

    Private Sub frm8SI_PAYMENTREQUEST_RETURN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub txtSUPPLIER_TextChanged(sender As Object, e As EventArgs) Handles txtSUPPLIER.TextChanged



    End Sub

    Private Sub DataGridView3_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView3.DoubleClick

        txtSUPPLIER_SELECT.Text = DataGridView3.CurrentRow.Cells(1).Value

    End Sub

    Sub LoadSupplierList()

        DataGridView3.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance", cn)
        dr = cm.ExecuteReader
        While dr.Read

            DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtCOO.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtREMARKS.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        DataGridView3.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance where supplier_name like '%" & txtSUPPLIER.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub
End Class