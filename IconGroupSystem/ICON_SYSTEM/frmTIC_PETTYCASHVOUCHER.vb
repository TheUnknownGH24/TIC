Public Class frmTIC_PETTYCASHVOUCHER

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

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If txtEXPENSECATEGORIES.Text = String.Empty Or txtAMOUNT.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        '=========================================================================================

        'For i As Integer = 0 To dataGridView1.Rows.Count - 1
        '
        '        If txtEXPENSECATEGORIES.Text = dataGridView1.Rows(i).Cells(0).Value.ToString() Then
        '
        '        MsgBox("Expense Categories Already used!", vbCritical + vbOKOnly, "CONFIRMATION")
        '        Return
        '
        '        End If
        '
        'Next

        '=========================================================================================

        Try

            dataGridView1.Rows.Add(txtEXPENSECATEGORIES.Text, CDbl(txtAMOUNT.Text), txtREMARKS.Text)

            '=========================================================================================

            txtEXPENSECATEGORIES.SelectedIndex = -1
            txtAMOUNT.Text = ""
            txtREMARKS.Text = ""
            btnSAVE.Enabled = True

            Supplier_sum()

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString())

        End Try

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtEXPENSECATEGORIES.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtAMOUNT.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtEXPENSECATEGORIES.Text
                update.Cells(1).Value = txtAMOUNT.Text
                update.Cells(2).Value = txtREMARKS.Text

                txtEXPENSECATEGORIES.Text = ""
                txtAMOUNT.Text = ""
                txtREMARKS.Text = ""

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

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtDATENEEDED.Text < Now.AddDays(-1) Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATENEEDED.Focus()
            Return

        End If

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        Dim myFormat = "MM/dd/yyyy"

        If txtTOTALAMOUNT.Text >= 1001 Then

            MsgBox("Petty Cash below Php 1,000.00!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtPURPOSE.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_tic_pettycash (transaction_no, date, employee, department, depcode, date_needed, purpose, amount, endorsed_approval, endorsed_comment, finance_approval, finance_comment, final_approval, final_comment, date_time, status) values(@transaction_no, @date, @employee, @department, @depcode, @date_needed, @purpose, @amount, @endorsed_approval, @endorsed_comment, @finance_approval, @finance_comment, @final_approval, @final_comment, @date_time, @status)", cn)
            With cm.Parameters

                .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@employee", txtEMPLOYEE.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@depcode", txtDEPCODE.Text)
                .AddWithValue("@date_needed", Format(CDate(txtDATENEEDED.Text), myFormat))
                .AddWithValue("@purpose", txtPURPOSE.Text)
                .AddWithValue("@amount", txtTOTALAMOUNT.Text)

                .AddWithValue("@endorsed_approval", "FOR APPROVAL")
                .AddWithValue("@endorsed_comment", " ")

                .AddWithValue("@finance_approval", "FOR APPROVAL")
                .AddWithValue("@finance_comment", " ")

                .AddWithValue("@final_approval", "FOR RELEASE")
                .AddWithValue("@final_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DisplayPCVNO()
            SaveInPCVList()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True
            button3.Enabled = False

            dataGridView1.Enabled = False
            txtPURPOSE.Enabled = False

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DisplayPCVNO()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_tic_pettycash where transaction_no = '" & txtTRANSACTION.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInPCVList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_tic_pettycashlist (pcv_no, expenses_categories, amount, remarks) values(@pcv_no, @expenses_categories, @amount, @remarks)", cn)
            With cm.Parameters

                .AddWithValue("@pcv_no", txtCONTROL.Text)

                .AddWithValue("@expenses_categories", row.Cells("EXPENSE_CATEGORIES").Value)
                .AddWithValue("@amount", row.Cells("AMOUNT").Value)
                .AddWithValue("@remarks", row.Cells("REMARKS").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

        MsgBox("Petty Cash Voucher has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Sub Supplier_sum()

        Dim TOTALPRICE As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALPRICE += dataGridView1.Rows(i).Cells(1).Value
        Next

        txtTOTALAMOUNT.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Do you want to Reset ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            txtPURPOSE.Text = ""
            txtTOTALAMOUNT.Text = ""
            txtCONTROL.Text = ""

            txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

            dataGridView1.Rows.Clear()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = False
            button3.Enabled = True

            dataGridView1.Enabled = True
            txtPURPOSE.Enabled = True

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

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

        e.Graphics.DrawString("PETTY CASH VOUCHER", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim line As New Font("Arial Black", 10, FontStyle.Bold)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)

        e.Graphics.DrawString("CONTROL#", sign, Brushes.Black, 530, 150)
        e.Graphics.DrawString("DATE NEEDED", sign, Brushes.Black, 530, 170)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 150)
        e.Graphics.DrawString("EMPLOYEE NAME", sign, Brushes.Black, 50, 170)
        e.Graphics.DrawString("DEPARTMENT", sign, Brushes.Black, 50, 190)
        e.Graphics.DrawString("PURPOSE", sign, Brushes.Black, 50, 210)

        e.Graphics.DrawString(":", title, Brushes.Black, 620, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 620, 170)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 170)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 190)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 210)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 630, 150)
        e.Graphics.DrawString(txtDATENEEDED.Text, title, Brushes.Black, 630, 170)

        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 230, 150)
        e.Graphics.DrawString(txtEMPLOYEE.Text, title, Brushes.Black, 230, 170)
        e.Graphics.DrawString(txtDEPARTMENT.Text, title, Brushes.Black, 230, 190)
        e.Graphics.DrawString(txtPURPOSE.Text, title, Brushes.Black, 230, 210)

        'Dim rect2 As New Rectangle(50, 300, 750, 25)
        'Dim brush2 As SolidBrush = New SolidBrush(Color.Red)
        'e.Graphics.FillRectangle(brush2, rect2)

        'e.Graphics.DrawRectangle(Pens.Black, rect2)

        'e.Graphics.DrawString("R E Q U E S T  L I S T", header, Brushes.White, rect2, center)

        '================================================================================

        Dim box1 As New Rectangle(50, 250, 200, 20)
        Dim box2 As New Rectangle(250, 250, 150, 20)
        Dim box3 As New Rectangle(400, 250, 400, 20)

        Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, box1)
        e.Graphics.FillRectangle(brush3, box2)
        e.Graphics.FillRectangle(brush3, box3)

        e.Graphics.DrawRectangle(Pens.White, box1)
        e.Graphics.DrawRectangle(Pens.White, box2)
        e.Graphics.DrawRectangle(Pens.White, box3)

        e.Graphics.DrawString("EXPENSE CATEGORIES", line, Brushes.White, box1, center)
        e.Graphics.DrawString("AMOUNT", line, Brushes.White, box2, center)
        e.Graphics.DrawString("REMARKS", line, Brushes.White, box3, center)

        '================================================================================

        Dim y As Integer = 255

        For i = 0 To dataGridView1.Rows.Count - 1
            y += 18

            Dim data1 As New Rectangle(50, y, 200, 20)
            Dim data2 As New Rectangle(250, y, 150, 20)
            Dim data3 As New Rectangle(400, y, 400, 20)

            Dim brush5 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush5, data1)
            e.Graphics.FillRectangle(brush5, data2)
            e.Graphics.FillRectangle(brush5, data3)

            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)
            e.Graphics.DrawRectangle(Pens.Black, data3)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(0).Value, data, Brushes.Black, data1, left)
            e.Graphics.DrawString(CDbl(dataGridView1.Rows(i).Cells(1).Value).ToString("#,##0.00"), data, Brushes.Black, data2, right)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(2).Value, data, Brushes.Black, data3, left)

            Dim t As Integer = 500

            t += 18

            Dim total1 As New Rectangle(50, t, 600, 20)
            Dim total2 As New Rectangle(650, t, 150, 20)


            Dim brushtotal As SolidBrush = New SolidBrush(Color.Red)
            e.Graphics.FillRectangle(brushtotal, total1)
            e.Graphics.FillRectangle(brushtotal, total2)


            e.Graphics.DrawRectangle(Pens.Black, total1)
            e.Graphics.DrawRectangle(Pens.Black, total2)


            e.Graphics.DrawString("GRAND TOTAL", data, Brushes.White, total1, right)
            e.Graphics.DrawString(txtTOTALAMOUNT.Text, data, Brushes.White, total2, right)

            '=============================================================================

            Dim x As Integer = 600

            x += 18

            Dim title1 As New Rectangle(50, x, 189, 20)
            Dim title2 As New Rectangle(239, x, 189, 20)
            Dim title3 As New Rectangle(428, x, 189, 20)
            Dim title4 As New Rectangle(617, x, 189, 20)

            Dim brush6 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush6, title1)
            e.Graphics.FillRectangle(brush6, title2)
            e.Graphics.FillRectangle(brush6, title3)
            e.Graphics.FillRectangle(brush6, title4)

            e.Graphics.DrawRectangle(Pens.White, title1)
            e.Graphics.DrawRectangle(Pens.White, title2)
            e.Graphics.DrawRectangle(Pens.White, title3)
            e.Graphics.DrawRectangle(Pens.White, title4)

            e.Graphics.DrawString("PREPARED BY:", sign, Brushes.Black, title1, left)
            e.Graphics.DrawString("ENDORSED BY:", sign, Brushes.Black, title2, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title3, left)
            e.Graphics.DrawString("RELEASED BY:", sign, Brushes.Black, title4, left)

            '=============================================================================

            Dim s As Integer = 640

            s += 18

            Dim sign1 As New Rectangle(50, s, 189, 20)
            Dim sign2 As New Rectangle(239, s, 189, 20)
            Dim sign3 As New Rectangle(428, s, 189, 20)
            Dim sign4 As New Rectangle(617, s, 189, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign3)
            e.Graphics.FillRectangle(brush7, sign4)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign3)
            e.Graphics.DrawRectangle(Pens.White, sign4)

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign, Brushes.Black, sign1, left)
            e.Graphics.DrawString("__________________________", sign, Brushes.Black, sign2, left)
            e.Graphics.DrawString("__________________________", sign, Brushes.Black, sign3, left)
            e.Graphics.DrawString("__________________________", sign, Brushes.Black, sign4, left)

            '=============================================================================

            Dim l As Integer = 660

            l += 18

            Dim label1 As New Rectangle(50, l, 189, 20)
            Dim label2 As New Rectangle(239, l, 189, 20)
            Dim label3 As New Rectangle(428, l, 189, 20)
            Dim label4 As New Rectangle(617, l, 189, 20)

            Dim brush8 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush8, label1)
            e.Graphics.FillRectangle(brush8, label2)
            e.Graphics.FillRectangle(brush8, label3)
            e.Graphics.FillRectangle(brush8, label4)

            e.Graphics.DrawRectangle(Pens.White, label1)
            e.Graphics.DrawRectangle(Pens.White, label2)
            e.Graphics.DrawRectangle(Pens.White, label3)
            e.Graphics.DrawRectangle(Pens.White, label4)

            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, label1, left)
            e.Graphics.DrawString("DEPARTMENT MANAGER", label, Brushes.Black, label2, left)
            e.Graphics.DrawString("FINANCE MANAGER", label, Brushes.Black, label3, left)
            e.Graphics.DrawString("RELEASER", label, Brushes.Black, label4, left)


        Next

    End Sub


    Private Sub frmTIC_PETTYCASHVOUCHER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub txtDATENEEDED_ValueChanged(sender As Object, e As EventArgs) Handles txtDATENEEDED.ValueChanged

        If txtDATENEEDED.Text < Now.AddDays(-1) Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATENEEDED.Text = Date.Now
            txtDATENEEDED.Focus()

        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub
End Class