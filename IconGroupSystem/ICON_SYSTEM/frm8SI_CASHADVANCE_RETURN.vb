Public Class frm8SI_CASHADVANCE_RETURN

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Sub LoadCAList()

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where `STATUS` = 'RETURNED' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1

                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)
            End While

            dr.Close()
            cn.Close()

ElseIf txtNAME.Text = "DEV-JENNALYN VALLE ALFABETE" Or txtNAME.Text = "OPS-JENNALYN VALLE ALFABETE" Or txtNAME.Text = "BC-JENNALYN VALLE ALFABETE" Or txtNAME.Text = "RACHEL MEDRANO" Or txtNAME.Text = "CHARLOTTE DAYRIT" Then
            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where `STATUS` = 'RETURNED' and `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1

                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)
            End While

            dr.Close()
            cn.Close()

        ElseIf txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - BUSINESS DEV" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where employee like '%" & txtNAME.Text & "%' AND `STATUS` = 'RETURNED' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1

                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)
            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where `STATUS` = 'RETURNED' and `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1

                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)
            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadCAITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_cashadvancelist where `ca_no` like '%" & txtCONTROL.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("expenses_categories").ToString, dr.Item("amount").ToString)

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
            .Text = "VIEW"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView2.Columns.Insert(14, colApproval)

    End Sub

    Sub Supplier_sum()

        Dim TOTALPRICE As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALPRICE += dataGridView1.Rows(i).Cells(1).Value
        Next

        txtTOTALAMOUNT.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where ca_no like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()

ElseIf txtNAME.Text = "DEV-JENNALYN VALLE ALFABETE" Or txtNAME.Text = "OPS-JENNALYN VALLE ALFABETE" Or txtNAME.Text = "BC-JENNALYN VALLE ALFABETE" Or txtNAME.Text = "RACHEL MEDRANO" Or txtNAME.Text = "CHARLOTTE DAYRIT" Then
            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where ca_no like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        ElseIf txtDEPARTMENTDATA.Text = "DIRECT SELLING - OPERATIONS" Or txtDEPARTMENTDATA.Text = "DIRECT SELLING - BUSINESS DEV" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where employee like '%" & txtNAME.Text & "%' AND ca_no like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()


        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where ca_no like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

            cn.Close()

        End If


    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_cashadvance set total_amount=@total_amount, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@total_amount", txtTOTALAMOUNT.Text)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()


            DeleteInCVList()
            SaveInCAList()

            LoadCAList()

            btnSAVE.Enabled = False
            Button1.Enabled = True
            button3.Enabled = False

            dataGridView1.Enabled = False


            MsgBox("Cash Advance has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInCVList()

        cm = New MySqlCommand("DELETE FROM tbl_8si_cashadvancelist WHERE `ca_no` like '" & txtCONTROL.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub SaveInCAList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_cashadvancelist (ca_no, expenses_categories, amount) values(@ca_no, @expenses_categories, @amount)", cn)
            With cm.Parameters

                .AddWithValue("@ca_no", txtCONTROL.Text)

                .AddWithValue("@expenses_categories", row.Cells("EXPENSE_CATEGORIES").Value)
                .AddWithValue("@amount", row.Cells("AMOUNT").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

        MsgBox("Cash Advance has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

        e.Graphics.DrawString("CASH ADVANCE FORM", header, Brushes.White, rect1, center)

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

        Dim box1 As New Rectangle(50, 250, 600, 20)
        Dim box2 As New Rectangle(650, 250, 150, 20)

        Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, box1)
        e.Graphics.FillRectangle(brush3, box2)

        e.Graphics.DrawRectangle(Pens.White, box1)
        e.Graphics.DrawRectangle(Pens.White, box2)

        e.Graphics.DrawString("EXPENSE CATEGORIES", line, Brushes.White, box1, center)
        e.Graphics.DrawString("AMOUNT", line, Brushes.White, box2, center)

        '================================================================================

        Dim y As Integer = 260

        For i = 0 To dataGridView1.Rows.Count - 1
            y += 18

            Dim data1 As New Rectangle(50, y, 600, 20)
            Dim data2 As New Rectangle(650, y, 150, 20)

            Dim brush5 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush5, data1)
            e.Graphics.FillRectangle(brush5, data2)

            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(0).Value, data, Brushes.Black, data1, right)
            e.Graphics.DrawString(CDbl(dataGridView1.Rows(i).Cells(1).Value).ToString("#,##0.00"), data, Brushes.Black, data2, right)

            Dim x As Integer = 700

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
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title4, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title5, left)

            '=============================================================================

            Dim s As Integer = 740

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

            Dim l As Integer = 760

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


        Next

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_cashadvance where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
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

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtFINANCECOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString
                txtFINALCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadCAITEMLIST()
            Supplier_sum()

            btnSAVE.Enabled = True
            Button1.Enabled = False
            button3.Enabled = True

            dataGridView1.Enabled = True

        End If

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

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtEXPENSECATEGORIES.Text
                update.Cells(1).Value = txtAMOUNT.Text

                txtEXPENSECATEGORIES.Text = ""
                txtAMOUNT.Text = ""

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows(0).Index)

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

        If txtEXPENSECATEGORIES.Text = String.Empty Or txtAMOUNT.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        '=========================================================================================

        For i As Integer = 0 To dataGridView1.Rows.Count - 1

            If txtEXPENSECATEGORIES.Text = dataGridView1.Rows(i).Cells(0).Value.ToString() Then

                MsgBox("Expense Categories Already used!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

        Next

        '=========================================================================================

        Try

            dataGridView1.Rows.Add(txtEXPENSECATEGORIES.Text, CDbl(txtAMOUNT.Text))

            '=========================================================================================

            txtEXPENSECATEGORIES.SelectedIndex = -1
            txtAMOUNT.Text = ""
            btnSAVE.Enabled = True
            Button1.Enabled = True

            Supplier_sum()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Private Sub frm8SI_CASHADVANCE_RETURN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

        If txtDATENEEDED.Text <= Date.Now Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATENEEDED.Text = Now.AddDays(1)
            txtDATENEEDED.Focus()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINANCECOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINALCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub
End Class