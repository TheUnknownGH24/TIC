Public Class frm8SI_REQUESTSLIP_RECORD

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub LoadREQUESTList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_requestsliplist where `controlno` like '" & txtCONTROL.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("description").ToString, dr.Item("remarks").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

        If dataGridView1.Columns(e.ColumnIndex).Name = "QUANTITY" Then
            If String.IsNullOrEmpty(e.ToString) Then
                btnPRINT.Enabled = False
            Else
                btnPRINT.Enabled = True
            End If
        End If

    End Sub

    Private Sub txtQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQTY.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub


    Private Sub dataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtQTY.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)
                update.Cells(0).Value = txtQTY.Text
                update.Cells(2).Value = txtDESCRIPTION.Text
                update.Cells(3).Value = txtREMARKS.Text

                txtQTY.Text = ""
                txtDESCRIPTION.Text = ""
                txtREMARKS.Text = ""

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

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs)

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_requestslip set date_needed=@date_needed, gm_approval=@gm_approval, gm_comment=@gm_comment where id=@id", cn)

            With cm.Parameters
                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@gm_approval", "APPROVED")
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInREQUESTList()
            SaveInSLIPList()

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInREQUESTList()

        cm = New MySqlCommand("DELETE FROM tbl_8si_requestsliplist WHERE `controlno` like '%" & txtCONTROL.Text & "%'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub SaveInSLIPList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_requestsliplist (controlno, transaction_no, quantity, unit, description, remarks) values(@controlno, @transaction_no, @quantity, @unit, @description, @remarks)", cn)
            With cm.Parameters
                .AddWithValue("@controlno", txtCONTROL.Text)
                .AddWithValue("@transaction_no", txtTRANSAC.Text)

                .AddWithValue("@quantity", row.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row.Cells("UNIT").Value)
                .AddWithValue("@description", row.Cells("DESCRIPTION").Value)
                .AddWithValue("@remarks", row.Cells("REMARKS").Value)
            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()

        Next

    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs)

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_requestslip set date_needed=@date_needed, gm_approval=@gm_approval, gm_comment=@gm_comment where id=@id", cn)

            With cm.Parameters
                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@gm_approval", "APPROVED")
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInREQUESTList()
            SaveInSLIPList()
            LoadAPPROVALLIST()

            btnPRINT.Enabled = False

            MsgBox("Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub btnRETURN_Click(sender As Object, e As EventArgs)

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_requestslip set MANAGER_APPROVAL=@MANAGER_APPROVAL, GM_APPROVAL=@GM_APPROVAL, gm_comment=@gm_comment, status=@status where id=@id", cn)

            With cm.Parameters
                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@MANAGER_APPROVAL", "FOR APPROVAL")
                .AddWithValue("@GM_APPROVAL", "FOR APPROVAL")

                .AddWithValue("@status", "RETURN")
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInREQUESTList()
            SaveInSLIPList()

            LoadAPPROVALLIST()

            btnPRINT.Enabled = False

            MsgBox("Request has been Successfully Return!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Or txtDEPARTMENTDATA.Text = "PURCHASING DEPARTMENT" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `controlno` like '%" & txtSEARCHNAME.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

            End While
            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `department` like '%" & txtDEPARTMENTDATA.Text & "%' and `controlno` like '%" & txtSEARCHNAME.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

            End While
            dr.Close()
            cn.Close()

        End If


    End Sub

    Sub LoadAPPROVALLIST()

        If txtTYPE.Text = "ADMINISTRATOR" Or txtDEPARTMENTDATA.Text = "PURCHASING DEPARTMENT" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

            End While
            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

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

        If colname = "colUPDATE" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSAC.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDATENEEDED.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

            End While
            dr.Close()
            cn.Close()
            LoadREQUESTList()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()

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
        Dim rect1 As New Rectangle(50, 150, 750, 25)
        Dim brush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush, rect1)

        e.Graphics.DrawRectangle(Pens.Black, rect1)

        e.Graphics.DrawImage(Me.PictureBox1.Image, 225, 30, PictureBox1.Width - 15, PictureBox1.Height - 25)

        e.Graphics.DrawString("PURCHASING REQUEST SLIP", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim line As New Font("Arial Black", 10, FontStyle.Bold)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)


        e.Graphics.DrawString("CONTROL#", sign, Brushes.Black, 530, 200)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 200)
        e.Graphics.DrawString("EMPLOYEE NAME", sign, Brushes.Black, 50, 220)
        e.Graphics.DrawString("DEPARTMENT", sign, Brushes.Black, 50, 240)
        e.Graphics.DrawString("DATE NEEDED", sign, Brushes.Black, 50, 260)

        e.Graphics.DrawString(":", title, Brushes.Black, 620, 200)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 200)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 220)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 240)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 260)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 630, 200)

        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 230, 200)
        e.Graphics.DrawString(txtEMPLOYEE.Text, title, Brushes.Black, 230, 220)
        e.Graphics.DrawString(txtDEPARTMENT.Text, title, Brushes.Black, 230, 240)
        e.Graphics.DrawString(txtDATENEEDED.Text, title, Brushes.Black, 230, 260)

        Dim rect2 As New Rectangle(50, 300, 750, 25)
        Dim brush2 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(brush2, rect2)

        e.Graphics.DrawRectangle(Pens.Black, rect2)

        e.Graphics.DrawString("R E Q U E S T  L I S T", header, Brushes.White, rect2, center)

        '================================================================================

        Dim box1 As New Rectangle(50, 335, 95, 20)
        Dim box2 As New Rectangle(145, 335, 96, 20)
        Dim box3 As New Rectangle(241, 335, 282, 20)
        Dim box4 As New Rectangle(523, 335, 280, 20)

        Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, box1)
        e.Graphics.FillRectangle(brush3, box2)
        e.Graphics.FillRectangle(brush3, box3)
        e.Graphics.FillRectangle(brush3, box4)

        e.Graphics.DrawRectangle(Pens.White, box1)
        e.Graphics.DrawRectangle(Pens.White, box2)
        e.Graphics.DrawRectangle(Pens.White, box3)
        e.Graphics.DrawRectangle(Pens.White, box4)

        e.Graphics.DrawString("QTY", line, Brushes.White, box1, center)
        e.Graphics.DrawString("UNIT", line, Brushes.White, box2, center)
        e.Graphics.DrawString("DESCRIPTION", line, Brushes.White, box3, center)
        e.Graphics.DrawString("REMARKS", line, Brushes.White, box4, center)

        '================================================================================

        Dim y As Integer = 340

        For i = 0 To dataGridView1.Rows.Count - 1
            y += 18

            Dim data1 As New Rectangle(50, y, 95, 20)
            Dim data2 As New Rectangle(145, y, 96, 20)
            Dim data3 As New Rectangle(241, y, 282, 20)
            Dim data4 As New Rectangle(523, y, 280, 20)

            Dim brush5 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush5, data1)
            e.Graphics.FillRectangle(brush5, data2)
            e.Graphics.FillRectangle(brush5, data3)
            e.Graphics.FillRectangle(brush5, data4)

            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)
            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(0).Value, data, Brushes.Black, data1, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(1).Value, data, Brushes.Black, data2, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(2).Value, data, Brushes.Black, data3, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(3).Value, data, Brushes.Black, data4, center)


            Dim x As Integer = 1000

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
            e.Graphics.DrawString("RECIEVED BY:", sign, Brushes.Black, title4, left)

            '=============================================================================

            Dim s As Integer = 1040

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
            e.Graphics.DrawString("______________________________________", sign, Brushes.Black, sign2, left)
            e.Graphics.DrawString("______________________________________", sign, Brushes.Black, sign3, left)
            e.Graphics.DrawString("______________________________________", sign, Brushes.Black, sign4, left)

            '=============================================================================

            Dim l As Integer = 1060

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
            e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, label3, left)
            e.Graphics.DrawString("PURCHASING OFFICER", label, Brushes.Black, label4, left)


        Next

    End Sub

    Private Sub frm8SI_REQUESTSLIP_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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
End Class