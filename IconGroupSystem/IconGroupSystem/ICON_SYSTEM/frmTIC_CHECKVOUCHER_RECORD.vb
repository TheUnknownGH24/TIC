Public Class frmTIC_CHECKVOUCHER_RECORD

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
        DataGridView2.Columns.Insert(27, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged



    End Sub

    Sub LoadCVList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_checkvoucher", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("cv_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("supplier_name").ToString, dr.Item("payee_name").ToString, dr.Item("reference_code").ToString, dr.Item("subreference_code").ToString, dr.Item("checkvoucher_date").ToString, dr.Item("check_no").ToString, dr.Item("bank_branch").ToString, dr.Item("check_date").ToString, dr.Item("particulars").ToString, dr.Item("amount_due").ToString, dr.Item("debit_total").ToString, dr.Item("credit_total").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString, dr.Item("status").ToString, dr.Item("manager_approval").ToString, dr.Item("gm_approval").ToString, dr.Item("coo_approval").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadAccountTitle()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_checkvoucher_accounttitle where `cv_no` like '" & txtCONTROL.Text & "'", cn)
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
        cm = New MySqlCommand("select * from a_tic_bank", cn)
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
            cm = New MySqlCommand("select * from tbl_tic_checkvoucher where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
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
                txtGM.Text = DataGridView2.Rows(e.RowIndex).Cells(21).Value.ToString
                txtCOO.Text = DataGridView2.Rows(e.RowIndex).Cells(22).Value.ToString

                txtSTATUS.Text = DataGridView2.Rows(e.RowIndex).Cells(23).Value.ToString

                txtAPPROVED1.Text = DataGridView2.Rows(e.RowIndex).Cells(24).Value.ToString
                txtAPPROVED2.Text = DataGridView2.Rows(e.RowIndex).Cells(25).Value.ToString
                txtAPPROVED3.Text = DataGridView2.Rows(e.RowIndex).Cells(26).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadAccountTitle()

        End If

    End Sub

    Private Sub txtAMOUNTDUE_Leave(sender As Object, e As EventArgs) Handles txtAMOUNTDUE.Leave

        If txtAMOUNTDUE.Text = String.Empty Then

            Exit Sub

        Else

            txtAMOUNTDUE.Text = CDbl(txtAMOUNTDUE.Text).ToString("#,##0.00")

        End If

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        If txtSTATUS.Text = "DEACTIVE" Then

            MsgBox("Selected Data is DEACTIVE!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()

        End If

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
        e.Graphics.DrawString("REFERENCE#", sign, Brushes.Black, 50, 210)

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

            If txtAPPROVED1.Text = "FOR APPROVAL" Then
                e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign2, left)
            Else
                e.Graphics.DrawString("JOSEPH RAINVILLE CASTASUS", sign, Brushes.Black, sign2, left)
            End If

            If txtAPPROVED2.Text = "FOR APPROVAL" Then
                e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign3, left)
            Else
                e.Graphics.DrawString("LERMA STA. CRUZ", sign, Brushes.Black, sign3, left)
            End If


            If txtAPPROVED3.Text = "FOR APPROVAL" Then
                e.Graphics.DrawString("_______________________________", sign, Brushes.Black, sign4, left)
            Else
                e.Graphics.DrawString("DIVINA GRACIA YAPJUANGCO", sign, Brushes.Black, sign4, left)
            End If

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

    Private Sub frmTIC_CHECKVOUCHER_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtCOO.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_checkvoucher where `cv_no` like '%" & TextBox3.Text & "%' or `supplier_name` like '%" & TextBox3.Text & "%' or `amount_due` like '%" & TextBox3.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("cv_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("supplier_name").ToString, dr.Item("payee_name").ToString, dr.Item("reference_code").ToString, dr.Item("subreference_code").ToString, dr.Item("checkvoucher_date").ToString, dr.Item("check_no").ToString, dr.Item("bank_branch").ToString, dr.Item("check_date").ToString, dr.Item("particulars").ToString, dr.Item("amount_due").ToString, dr.Item("debit_total").ToString, dr.Item("credit_total").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString, dr.Item("status").ToString, dr.Item("manager_approval").ToString, dr.Item("gm_approval").ToString, dr.Item("coo_approval").ToString)

        End While

        dr.Close()

        cn.Close()

    End Sub
End Class