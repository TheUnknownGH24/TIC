Public Class frm8SI_PETTYCASHVOUCHER_RECORD

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
        DataGridView2.Columns.Insert(18, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Or txtDEPARTMENTDATA.Text = "FINANCE DEPARTMENT" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pettycash where `pcv_no` like '%" & TextBox3.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

            End While

            dr.Close()

            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pettycash where `pcv_no` like '%" & TextBox3.Text & "%' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

            End While

            dr.Close()

            cn.Close()

        End If


    End Sub

    Sub LoadPCVList()


        If txtTYPE.Text = "ADMINISTRATOR" Or txtDEPARTMENTDATA.Text = "FINANCE DEPARTMENT" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pettycash", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pettycash where `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

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
            cm = New MySqlCommand("select * from tbl_8si_pettycash where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPCODE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString
                txtDATENEEDED.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString

                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtTOTALAMOUNT.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtRELEASER.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString
                txtFINAL.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString

                txtSTATUS.Text = DataGridView2.Rows(e.RowIndex).Cells(14).Value.ToString

                txtAPPROVED1.Text = DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString
                txtAPPROVED2.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString
                txtAPPROVED3.Text = DataGridView2.Rows(e.RowIndex).Cells(17).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadPCVITEMLIST()

            btnSAVE.Enabled = True


        End If

    End Sub

    Sub LoadPCVITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pettycashlist where `pcv_no` like '%" & txtCONTROL.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("expenses_categories").ToString, dr.Item("amount").ToString, dr.Item("remarks").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

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

            Dim title1 As New Rectangle(50, x, 161, 20)
            Dim title2 As New Rectangle(211, x, 161, 20)
            Dim title3 As New Rectangle(372, x, 161, 20)
            Dim title4 As New Rectangle(533, x, 161, 20)
            Dim title5 As New Rectangle(694, x, 161, 20)

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
            e.Graphics.DrawString("ENDORSED BY:", sign, Brushes.Black, title2, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title3, left)
            e.Graphics.DrawString("RELEASED BY:", sign, Brushes.Black, title4, left)
            e.Graphics.DrawString("RECEIVED BY:", sign, Brushes.Black, title5, left)

            '=============================================================================

            Dim s As Integer = 640

            s += 18

            Dim sign1 As New Rectangle(50, s, 161, 20)
            Dim sign2 As New Rectangle(211, s, 161, 20)
            Dim sign3 As New Rectangle(372, s, 161, 20)
            Dim sign4 As New Rectangle(533, s, 161, 20)
            Dim sign5 As New Rectangle(694, s, 161, 20)

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
            e.Graphics.DrawString("__________________________", sign, Brushes.Black, sign2, left)
            e.Graphics.DrawString("__________________________", sign, Brushes.Black, sign3, left)

            '====================================

            If txtAPPROVED3.Text = "FOR RELEASE" Then

                e.Graphics.DrawString("__________________________", sign, Brushes.Black, sign4, left)

            Else

                e.Graphics.DrawString("JOSEPH RAINVILLE CASTASUS", sign, Brushes.Black, sign4, left)

            End If

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign, Brushes.Black, sign5, left)

            '=============================================================================

            Dim l As Integer = 660

            l += 18

            Dim label1 As New Rectangle(50, l, 161, 20)
            Dim label2 As New Rectangle(211, l, 161, 20)
            Dim label3 As New Rectangle(372, l, 161, 20)
            Dim label4 As New Rectangle(533, l, 161, 20)
            Dim label5 As New Rectangle(694, l, 161, 20)

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
            e.Graphics.DrawString("RELEASER", label, Brushes.Black, label4, left)
            e.Graphics.DrawString("RECEIVER", label, Brushes.Black, label5, left)


        Next

    End Sub

    Private Sub frm8SI_PETTYCASHVOUCHER_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtRELEASER.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINAL.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub
End Class