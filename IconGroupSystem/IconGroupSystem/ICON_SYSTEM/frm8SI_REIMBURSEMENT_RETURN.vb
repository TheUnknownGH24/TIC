Public Class frm8SI_REIMBURSEMENT_RETURN

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
        DataGridView2.Columns.Insert(13, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `reimbursementno` like '%" & TextBox3.Text & "%' AND `STATUS` = 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        ElseIf txtDEP.Text = "DRS - ADMIN" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `reimbursementno` like '%" & TextBox3.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        ElseIf txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (CENTRAL AND NORTH LUZON)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (NCR AND SOUTH LUZON)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (MINDANAO)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (VISAYAS)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `reimbursementno` like '%" & TextBox3.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND employee like '%" & txtNAME.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()


        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `reimbursementno` like '%" & TextBox3.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        End If

    End Sub

    Sub LoadREIMList()


        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `STATUS` = 'RETURNED' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtDEP.Text = "DRS - ADMIN" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `STATUS` = 'RETURNED' AND `department` like 'DIRECT SELLING - OPERATIONS' OR `department` like 'DIRECT SELLING - OPERATIONS - (CENTRAL AND NORTH LUZON)' OR `department` like 'DIRECT SELLING - OPERATIONS - (MINDANAO)' OR `department` like 'DIRECT SELLING - OPERATIONS - (NCR AND SOUTH LUZON)' OR `department` like 'DIRECT SELLING - OPERATIONS - (VISAYAS)'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (CENTRAL AND NORTH LUZON)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (NCR AND SOUTH LUZON)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (MINDANAO)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS - (VISAYAS)" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND employee like '%" & txtNAME.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_reimbursement where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPCODE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString
                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString

                txtTOTALLIQUIDATION.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString
                txtFINANCE.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtFINAL.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadREIMITEMLIST()

            btnSAVE.Enabled = True
            Button1.Enabled = False
            button3.Enabled = True

            dataGridView1.Enabled = True

        End If

    End Sub

    Sub LoadREIMITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_reimbursement_list where `reimbursementno` like '%" & txtCONTROL.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("expense_categories").ToString, dr.Item("date_of_receipt").ToString, dr.Item("supplier_name").ToString, dr.Item("receipt_no").ToString, dr.Item("receipt_amount").ToString, dr.Item("remarks").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_reimbursement set purpose=@purpose, total_liquidation=@total_liquidation, date_time=@date_time, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@total_liquidation", txtTOTALLIQUIDATION.Text)

                .AddWithValue("@purpose", txtPURPOSE.Text)
                .AddWithValue("@date_time", DateTimePicker1.Value)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            DeleteInREQUESTList()
            LoadREIMList()
            SaveInREIMList()

            btnSAVE.Enabled = False
            Button1.Enabled = True
            button3.Enabled = False

            dataGridView1.Enabled = False

            MsgBox("Reimbursement has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInREQUESTList()

        cm = New MySqlCommand("DELETE FROM tbl_8si_reimbursement_list WHERE `reimbursementno` like '" & txtCONTROL.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub SaveInREIMList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_reimbursement_list (reimbursementno, expense_categories, date_of_receipt, supplier_name, receipt_no, receipt_amount, remarks) values(@reimbursementno, @expense_categories, @date_of_receipt, @supplier_name, @receipt_no, @receipt_amount, @remarks)", cn)
            With cm.Parameters

                .AddWithValue("@reimbursementno", txtCONTROL.Text)

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

        MsgBox("Reimbursement has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


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

        e.Graphics.DrawString("REIMBURSEMENT FORM", header, Brushes.White, rect1, center)

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


        e.Graphics.DrawString("REIMBURSEMENT#", sign, Brushes.Black, 530, 120)
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

        Dim totalbrush1 As SolidBrush = New SolidBrush(Color.Black)
        Dim totalbrush2 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(totalbrush1, total_liquidation)

        e.Graphics.DrawRectangle(Pens.White, total_liquidation)

        e.Graphics.DrawString("TOTAL REIMBURSEMENT", line, Brushes.White, total_liquidation, left)

        '============================================================================


        Dim amount_liquidation As New Rectangle(230, 220, 150, 17)

        Dim amountbrush1 As SolidBrush = New SolidBrush(Color.Black)
        Dim amountbrush2 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(totalbrush1, amount_liquidation)

        e.Graphics.DrawRectangle(Pens.White, amount_liquidation)

        e.Graphics.DrawString(txtTOTALLIQUIDATION.Text, line, Brushes.White, amount_liquidation, right)

        '============================================================================

        Dim title1 As New Rectangle(50, 240, 150, 14)
        Dim title2 As New Rectangle(200, 240, 150, 14)
        Dim title3 As New Rectangle(350, 240, 150, 14)
        Dim title4 As New Rectangle(500, 240, 150, 14)
        Dim title5 As New Rectangle(650, 240, 100, 14)
        Dim title6 As New Rectangle(750, 240, 300, 14)

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

        Dim d As Integer = 240

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

            Dim label1 As New Rectangle(50, p, 230, 20)
            Dim label2 As New Rectangle(280, p, 230, 20)
            Dim label3 As New Rectangle(510, p, 230, 20)
            Dim label4 As New Rectangle(740, p, 230, 20)

            Dim brush6 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush6, label1)
            e.Graphics.FillRectangle(brush6, label2)
            e.Graphics.FillRectangle(brush6, label3)
            e.Graphics.FillRectangle(brush6, label4)

            e.Graphics.DrawRectangle(Pens.White, label1)
            e.Graphics.DrawRectangle(Pens.White, label2)
            e.Graphics.DrawRectangle(Pens.White, label3)
            e.Graphics.DrawRectangle(Pens.White, label4)

            e.Graphics.DrawString("PREPARED BY:", sign, Brushes.Black, label1, left)
            e.Graphics.DrawString("CHECKED BY:", sign, Brushes.Black, label2, left)
            e.Graphics.DrawString("RECOMMENDED BY:", sign, Brushes.Black, label3, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, label4, left)

            '=============================================================================

            Dim s As Integer = 740

            s += 18

            Dim sign1 As New Rectangle(50, s, 230, 20)
            Dim sign2 As New Rectangle(280, s, 230, 20)
            Dim sign3 As New Rectangle(510, s, 230, 20)
            Dim sign4 As New Rectangle(740, s, 230, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign3)
            e.Graphics.FillRectangle(brush7, sign4)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign3)
            e.Graphics.DrawRectangle(Pens.White, sign4)

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign11, Brushes.Black, sign1, left)
            e.Graphics.DrawString("_____________________", sign11, Brushes.Black, sign2, left)
            e.Graphics.DrawString("JOSEPH RAINVILLE CASTASUS", sign11, Brushes.Black, sign3, left)
            e.Graphics.DrawString("LERMA STA. CRUZ", sign11, Brushes.Black, sign4, left)

            '=============================================================================

            Dim l As Integer = 760

            l += 18

            Dim position1 As New Rectangle(50, l, 220, 20)
            Dim position2 As New Rectangle(280, l, 220, 20)
            Dim position3 As New Rectangle(510, l, 220, 20)
            Dim position4 As New Rectangle(740, l, 220, 20)

            Dim brush8 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush8, position1)
            e.Graphics.FillRectangle(brush8, position2)
            e.Graphics.FillRectangle(brush8, position3)
            e.Graphics.FillRectangle(brush8, position4)

            e.Graphics.DrawRectangle(Pens.White, position1)
            e.Graphics.DrawRectangle(Pens.White, position2)
            e.Graphics.DrawRectangle(Pens.White, position3)
            e.Graphics.DrawRectangle(Pens.White, position4)

            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, position1, left)
            e.Graphics.DrawString("DEPARTMENT MANAGER", label, Brushes.Black, position2, left)
            e.Graphics.DrawString("FINANCE MANAGER", label, Brushes.Black, position3, left)
            e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, position4, left)

        Next

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

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If txtCATEGORIES.Text = String.Empty Or txtSUPPLIER.Text = String.Empty Or txtDATERECEIPT.Text = String.Empty Or txtRECEIPTNO.Text = String.Empty Or txtRECEIPTAMOUNT.Text = String.Empty Or txtREMARKS.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        '=========================================================================================


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
            'btnPRINT.Enabled = True

            Supplier_sum()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Private Sub frm8SI_REIMBURSEMENT_RETURN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged



    End Sub

    Private Sub DataGridView3_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView3.DoubleClick

        txtSUPPLIER.Text = DataGridView3.CurrentRow.Cells(1).Value

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINAL.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

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