Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmTIC_REQUESTSLIP

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Dim PPD As New PrintPreviewDialog
    Dim Longpaper As Integer

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


        If txtQTY.Text = String.Empty Or txtUNIT.Text = String.Empty Or txtDESCRIP.Text = String.Empty Or txtREMARKS.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        Try

            dataGridView1.Rows.Add(txtQTY.Text, txtUNIT.Text, txtDESCRIP.Text, txtREMARKS.Text)

            txtQTY.Text = ""
            txtDESCRIP.Text = ""
            txtREMARKS.Text = ""
            btnSAVE.Enabled = True

            txtCLASSIFICATION.Enabled = False


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try


    End Sub


    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

        If dataGridView1.Columns(e.ColumnIndex).Name = "QUANTITY" Then
            If String.IsNullOrEmpty(e.ToString) Then
                btnSAVE.Enabled = False
                btnPRINT.Enabled = False
            Else
                btnSAVE.Enabled = True
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
                txtDESCRIP.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)
                update.Cells(0).Value = txtQTY.Text
                update.Cells(2).Value = txtDESCRIP.Text
                update.Cells(3).Value = txtREMARKS.Text

                txtQTY.Text = ""
                txtDESCRIP.Text = ""
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

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_tic_requestslip (transaction_no, date_now, employee_name, department, date_needed, manager_approval, manager_comment, gm_approval, gm_comment, date_time, modified_date, status) values(@transaction_no, @date_now, @employee_name, @department, @date_needed, @manager_approval, @manager_comment, @gm_approval, @gm_comment, @date_time, @modified_date, @status)", cn)
            With cm.Parameters
                .AddWithValue("@transaction_no", txtTRANSAC.Text)
                .AddWithValue("@date_now", txtDATE.Text)
                .AddWithValue("@employee_name", txtEMPLOYEE.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@manager_comment", " ")
                .AddWithValue("@gm_approval", "FOR APPROVAL")
                .AddWithValue("@gm_comment", " ")
                .AddWithValue("@date_time", txtDATE.Value)
                .AddWithValue("@modified_date", " ")
                .AddWithValue("@status", "ACTIVE")
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DisplaySLIP()
            SaveInSLIPList()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DisplaySLIP()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_tic_requestslip where transaction_no = '" & txtTRANSAC.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInSLIPList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_tic_requestsliplist (controlno, transaction_no, quantity, unit, description, remarks) values(@controlno, @transaction_no, @quantity, @unit, @description, @remarks)", cn)
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
        MsgBox("Request has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick

        txtDESCRIP.Text = DataGridView2.CurrentRow.Cells(0).Value

    End Sub

    Sub LoadITEM()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblmotherclass", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("generic_name").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCLASSIFICATION.SelectedIndexChanged

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblmotherclass where `classification` like '%" & txtCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("generic_name").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadClassification()

        txtCLASSIFICATION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblclassification", cn)
        dr = cm.ExecuteReader
        While dr.Read


            txtCLASSIFICATION.Items.Add(dr.Item("classification").ToString)

        End While

        dr.Close()
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


            Dim x As Integer = 700

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

            Dim s As Integer = 740

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

            Dim l As Integer = 760

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()

    End Sub

    Private Sub txtDESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles txtDESCRIPTION.TextChanged



    End Sub

    Private Sub frmTIC_REQUESTSLIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmTIC_REQUESTSLIP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblmotherclass where `generic_name` like '%" & txtDESCRIPTION.Text & "%' AND  `classification` like '%" & txtCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("generic_name").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub
End Class
