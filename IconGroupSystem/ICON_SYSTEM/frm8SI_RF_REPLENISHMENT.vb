Public Class frm8SI_RF_REPLENISHMENT

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

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtTOTALLIQUIDATION.TextChanged

        Dim TOTALPRICE As Decimal = 0

        TOTALPRICE = CDbl(txtTOTALCASHADVANCE.Text).ToString("#,##0.00") - CDbl(txtTOTALLIQUIDATION.Text).ToString("#,##0.00")

        txtTOTALBALANCE.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If txtTOTALCASHADVANCE.Text = String.Empty Then
            MsgBox("Please Input Revolving Fund !", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtCATEGORIES.Text = String.Empty Or txtSUPPLIER.Text = String.Empty Or txtDATERECEIPT.Text = String.Empty Or txtRECEIPTNO.Text = String.Empty Or txtRECEIPTAMOUNT.Text = String.Empty Or txtREMARKS.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        '========================================================================================

        Try

            dataGridView1.Rows.Add(txtCATEGORIES.Text, txtDATERECEIPT.Text, txtSUPPLIER.Text, txtRECEIPTNO.Text, CDbl(txtRECEIPTAMOUNT.Text).ToString("#,##0.00"), txtREMARKS.Text)

            '=========================================================================================



            txtCATEGORIES.SelectedIndex = -1
            txtSUPPLIER.Text = ""
            txtDATERECEIPT.Text = ""
            txtRECEIPTNO.Text = ""
            txtRECEIPTAMOUNT.Text = ""
            txtREMARKS.Text = ""

            btnSAVE.Enabled = True

            Supplier_sum()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Sub Supplier_sum()

        Dim TOTALPRICE As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1

            TOTALPRICE += dataGridView1.Rows(i).Cells(4).Value

        Next

        txtTOTALLIQUIDATION.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

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
                txtCATEGORIES.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtDATERECEIPT.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtSUPPLIER.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtRECEIPTNO.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtRECEIPTAMOUNT.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString

                Supplier_sum()

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtCATEGORIES.Text
                update.Cells(1).Value = txtDATERECEIPT.Text
                update.Cells(2).Value = txtSUPPLIER.Text
                update.Cells(3).Value = txtRECEIPTNO.Text
                update.Cells(4).Value = txtRECEIPTAMOUNT.Text
                update.Cells(5).Value = txtREMARKS.Text

                txtCATEGORIES.Text = ""
                txtDATERECEIPT.Text = ""
                txtRECEIPTNO.Text = ""
                txtSUPPLIER.Text = ""
                txtRECEIPTAMOUNT.Text = ""
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

    Private Sub txtRECEIPTAMOUNT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRECEIPTAMOUNT.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtPURPOSE.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_8si_rf_replenishment (reference, date, employee, department, depcode, purpose, revolving_fund, total_liquidation, unreplenish, endorsed_approval, endorsed_comment, finance_approval, finance_comment, final_approval, final_comment, date_time, status) values(@reference, @date, @employee, @department, @depcode, @purpose, @revolving_fund, @total_liquidation, @unreplenish, @endorsed_approval, @endorsed_comment, @finance_approval, @finance_comment, @final_approval, @final_comment, @date_time, @status)", cn)
            With cm.Parameters
                .AddWithValue("@reference", txtREFERENCE.Text)
                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@employee", txtEMPLOYEE.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@depcode", txtDEPCODE.Text)
                .AddWithValue("@purpose", txtPURPOSE.Text)

                .AddWithValue("@revolving_fund", txtTOTALCASHADVANCE.Text)
                .AddWithValue("@total_liquidation", txtTOTALLIQUIDATION.Text)
                .AddWithValue("@unreplenish", txtTOTALBALANCE.Text)

                .AddWithValue("@endorsed_approval", "FOR APPROVAL")
                .AddWithValue("@endorsed_comment", " ")

                .AddWithValue("@finance_approval", "FOR APPROVAL")
                .AddWithValue("@finance_comment", " ")

                .AddWithValue("@final_approval", "FOR APPROVAL")
                .AddWithValue("@final_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DisplayCANO()
            SaveInCAList()

            btnPRINT.Enabled = True

            btnSAVE.Enabled = False
            button3.Enabled = False

            dataGridView1.Enabled = False

            txtPURPOSE.Enabled = False

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DisplayCANO()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_8si_rf_replenishment where `reference` = '" & txtREFERENCE.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInCAList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_rf_replenishment_list (rf_no, expense_categories, date_of_receipt, supplier_name, receipt_no, receipt_amount, remarks) values(@rf_no, @expense_categories, @date_of_receipt, @supplier_name, @receipt_no, @receipt_amount, @remarks)", cn)
            With cm.Parameters

                .AddWithValue("@rf_no", txtCONTROL.Text)

                .AddWithValue("@expense_categories", row.Cells("EXPENSE_CATEGORIES").Value)
                .AddWithValue("@date_of_receipt", row.Cells("DATE_OF_RECEIPT").Value)
                .AddWithValue("@supplier_name", row.Cells("SUPPLIER_NAME").Value)
                .AddWithValue("@receipt_no", row.Cells("RECEIPT_NO").Value)
                .AddWithValue("@receipt_amount", row.Cells("RECEIPT_AMOUNT").Value)
                .AddWithValue("@remarks", row.Cells("REMARKS").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

        MsgBox("RF Replenishment has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmSUPPLIER_FINANCE

            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()

        End With

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged



    End Sub

    Private Sub DataGridView3_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView3.DoubleClick

        txtSUPPLIER.Text = DataGridView3.CurrentRow.Cells(1).Value

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Document.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 1100)
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

        Dim rect1 As New Rectangle(50, 80, 1000, 25)

        Dim brush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush, rect1)

        e.Graphics.DrawRectangle(Pens.Black, rect1)

        e.Graphics.DrawImage(Me.PictureBox1.Image, 440, 30, PictureBox1.Width - 15, PictureBox1.Height - 25)

        e.Graphics.DrawString("RF REPLENISHMENT FORM", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim sign11 As New Font("Arial Black", 8, FontStyle.Underline)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)

        Dim line As New Font("CAMBRIA", 10, FontStyle.Bold)
        Dim lin2 As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim lin3 As New Font("CAMBRIA", 8, FontStyle.Bold)

        Dim lineerror As New Font("CAMBRIA", 8, FontStyle.Strikeout)


        e.Graphics.DrawString("RF_REPLENISHMENT#", sign, Brushes.Black, 530, 120)
        e.Graphics.DrawString("DEPARTMENT", sign, Brushes.Black, 530, 140)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 120)
        e.Graphics.DrawString("EMPLOYEE NAME", sign, Brushes.Black, 50, 140)
        e.Graphics.DrawString("TRANSACTION#", sign, Brushes.Black, 50, 160)
        e.Graphics.DrawString("PURPOSE", sign, Brushes.Black, 50, 180)

        e.Graphics.DrawString(":", title, Brushes.Black, 690, 120)
        e.Graphics.DrawString(":", title, Brushes.Black, 690, 140)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 120)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 140)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 160)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 180)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 700, 118)
        e.Graphics.DrawString(txtDEPARTMENT.Text, title, Brushes.Black, 700, 140)

        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 230, 120)
        e.Graphics.DrawString(txtEMPLOYEE.Text, title, Brushes.Black, 230, 140)
        e.Graphics.DrawString(txtREFERENCE.Text, title, Brushes.Black, 230, 160)
        e.Graphics.DrawString(txtPURPOSE.Text, title, Brushes.Black, 230, 180)

        '================================================================================

        Dim y As Integer = 230

        y += 17

        Dim total_liquidation As New Rectangle(50, 220, 180, 17)
        Dim total_ca As New Rectangle(50, 240, 180, 17)
        Dim total_balance As New Rectangle(50, 260, 180, 17)

        Dim totalbrush1 As SolidBrush = New SolidBrush(Color.Black)
        Dim totalbrush2 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(totalbrush1, total_liquidation)
        e.Graphics.FillRectangle(totalbrush1, total_ca)
        e.Graphics.FillRectangle(totalbrush2, total_balance)

        e.Graphics.DrawRectangle(Pens.White, total_liquidation)
        e.Graphics.DrawRectangle(Pens.White, total_ca)
        e.Graphics.DrawRectangle(Pens.White, total_balance)

        e.Graphics.DrawString("TOTAL LIQUIDATION", line, Brushes.White, total_liquidation, left)
        e.Graphics.DrawString("REVOLVING FUND", line, Brushes.White, total_ca, left)
        e.Graphics.DrawString("UNREPLENISH", line, Brushes.White, total_balance, left)

        '============================================================================


        Dim amount_liquidation As New Rectangle(230, 220, 150, 17)
        Dim amount_ca As New Rectangle(230, 240, 150, 17)
        Dim amount_balance As New Rectangle(230, 260, 150, 17)

        Dim amountbrush1 As SolidBrush = New SolidBrush(Color.Black)
        Dim amountbrush2 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(totalbrush1, amount_liquidation)
        e.Graphics.FillRectangle(totalbrush1, amount_ca)
        e.Graphics.FillRectangle(totalbrush2, amount_balance)

        e.Graphics.DrawRectangle(Pens.White, amount_liquidation)
        e.Graphics.DrawRectangle(Pens.White, amount_ca)
        e.Graphics.DrawRectangle(Pens.White, amount_balance)

        e.Graphics.DrawString(txtTOTALLIQUIDATION.Text, line, Brushes.White, amount_liquidation, right)
        e.Graphics.DrawString(txtTOTALCASHADVANCE.Text, line, Brushes.White, amount_ca, right)
        e.Graphics.DrawString(txtTOTALBALANCE.Text, line, Brushes.White, amount_balance, right)

        '============================================================================

        Dim title1 As New Rectangle(50, 290, 150, 14)
        Dim title2 As New Rectangle(200, 290, 150, 14)
        Dim title3 As New Rectangle(350, 290, 150, 14)
        Dim title4 As New Rectangle(500, 290, 150, 14)
        Dim title5 As New Rectangle(650, 290, 100, 14)
        Dim title6 As New Rectangle(750, 290, 300, 14)

        Dim brushtotal3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brushtotal3, title1)
        e.Graphics.FillRectangle(brushtotal3, title2)
        e.Graphics.FillRectangle(brushtotal3, title3)
        e.Graphics.FillRectangle(brushtotal3, title4)
        e.Graphics.FillRectangle(brushtotal3, title5)
        e.Graphics.FillRectangle(brushtotal3, title6)

        e.Graphics.DrawRectangle(Pens.White, title1)
        e.Graphics.DrawRectangle(Pens.White, title2)
        e.Graphics.DrawRectangle(Pens.White, title3)
        e.Graphics.DrawRectangle(Pens.White, title4)
        e.Graphics.DrawRectangle(Pens.White, title5)
        e.Graphics.DrawRectangle(Pens.White, title6)

        e.Graphics.DrawString("EXPENSE CATEGORIES", lin2, Brushes.White, title1, center)
        e.Graphics.DrawString("DATE OF RECEIPT", lin2, Brushes.White, title2, center)
        e.Graphics.DrawString("SUPPLIER NAME", lin2, Brushes.White, title3, center)
        e.Graphics.DrawString("RECEIPT NO.", lin2, Brushes.White, title4, center)
        e.Graphics.DrawString("AMOUNT", lin2, Brushes.White, title5, center)
        e.Graphics.DrawString("REMARKS", lin2, Brushes.White, title6, center)

        '================================================================================

        Dim d As Integer = 290

        For i = 0 To dataGridView1.Rows.Count - 1

            d += 18

            Dim data0 As New Rectangle(50, d, 150, 14)
            Dim data1 As New Rectangle(200, d, 150, 14)
            Dim data2 As New Rectangle(350, d, 150, 14)
            Dim data3 As New Rectangle(500, d, 150, 14)
            Dim data4 As New Rectangle(650, d, 100, 14)
            Dim data5 As New Rectangle(750, d, 300, 14)

            Dim databrush As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(databrush, data0)
            e.Graphics.FillRectangle(databrush, data1)
            e.Graphics.FillRectangle(databrush, data2)
            e.Graphics.FillRectangle(databrush, data3)
            e.Graphics.FillRectangle(databrush, data4)
            e.Graphics.FillRectangle(databrush, data5)

            e.Graphics.DrawRectangle(Pens.Black, data0)
            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)
            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(0).Value, lin2, Brushes.Black, data0, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(1).Value, lin2, Brushes.Black, data1, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(2).Value, lin2, Brushes.Black, data2, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(3).Value, lin2, Brushes.Black, data3, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(4).Value, lin2, Brushes.Black, data4, right)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(5).Value, lin2, Brushes.Black, data5, left)

            '================================================================================

            Dim p As Integer = 700

            p += 18

            Dim label1 As New Rectangle(50, p, 200, 20)
            Dim label2 As New Rectangle(250, p, 190, 20)
            Dim label4 As New Rectangle(700, p, 230, 20)
            Dim label5 As New Rectangle(930, p, 230, 20)

            Dim brush6 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush6, label1)
            e.Graphics.FillRectangle(brush6, label2)
            e.Graphics.FillRectangle(brush6, label4)
            e.Graphics.FillRectangle(brush6, label5)

            e.Graphics.DrawRectangle(Pens.White, label1)
            e.Graphics.DrawRectangle(Pens.White, label2)
            e.Graphics.DrawRectangle(Pens.White, label4)
            e.Graphics.DrawRectangle(Pens.White, label5)

            e.Graphics.DrawString("PREPARED BY:", sign, Brushes.Black, label1, left)
            e.Graphics.DrawString("ENDORSED BY:", sign, Brushes.Black, label2, left)
            e.Graphics.DrawString("REVIEWED BY:", sign, Brushes.Black, label4, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, label5, left)

            '=============================================================================

            Dim s As Integer = 740

            s += 18

            Dim sign1 As New Rectangle(50, s, 200, 20)
            Dim sign2 As New Rectangle(250, s, 190, 20)
            Dim sign4 As New Rectangle(700, s, 230, 20)
            Dim sign5 As New Rectangle(930, s, 230, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign4)
            e.Graphics.FillRectangle(brush7, sign5)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign4)
            e.Graphics.DrawRectangle(Pens.White, sign5)

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign11, Brushes.Black, sign1, left)
            e.Graphics.DrawString("_____________________", sign11, Brushes.Black, sign2, left)
            e.Graphics.DrawString("_____________________", sign11, Brushes.Black, sign4, left)
            e.Graphics.DrawString("_____________________", sign11, Brushes.Black, sign5, left)

            '=============================================================================

            Dim l As Integer = 760

            l += 18

            Dim position1 As New Rectangle(50, l, 200, 20)
            Dim position2 As New Rectangle(250, l, 190, 20)
            Dim position4 As New Rectangle(700, l, 230, 20)
            Dim position5 As New Rectangle(930, l, 230, 20)

            Dim brush8 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush8, position1)
            e.Graphics.FillRectangle(brush8, position2)
            e.Graphics.FillRectangle(brush8, position4)
            e.Graphics.FillRectangle(brush8, position5)

            e.Graphics.DrawRectangle(Pens.White, position1)
            e.Graphics.DrawRectangle(Pens.White, position2)
            e.Graphics.DrawRectangle(Pens.White, position4)
            e.Graphics.DrawRectangle(Pens.White, position5)

            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, position1, left)
            e.Graphics.DrawString("DEPARTMENT MANAGER", label, Brushes.Black, position2, left)
            e.Graphics.DrawString("FINANCE MANAGER", label, Brushes.Black, position4, left)
            e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, position5, left)

        Next

    End Sub

    Private Sub txtTOTALCASHADVANCE_Leave(sender As Object, e As EventArgs) Handles txtTOTALCASHADVANCE.Leave

        txtTOTALCASHADVANCE.Text = CDbl(txtTOTALCASHADVANCE.Text).ToString("#,##0.00")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Do you want to Reset ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            txtCONTROL.Text = ""
            txtCONTROL.Text = String.Empty
            txtPURPOSE.Text = ""

            txtTOTALCASHADVANCE.Text = CDbl(0).ToString("#,##0.00")
            txtTOTALLIQUIDATION.Text = CDbl(0).ToString("#,##0.00")

            txtCONTROL.Text = ""

            txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")

            dataGridView1.Rows.Clear()

            btnPRINT.Enabled = False

            btnSAVE.Enabled = True
            button3.Enabled = True

            dataGridView1.Enabled = True

            txtPURPOSE.Enabled = True

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub frm8SI_RF_REPLENISHMENT_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        DataGridView3.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance where supplier_name like '%" & TextBox1.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub
End Class