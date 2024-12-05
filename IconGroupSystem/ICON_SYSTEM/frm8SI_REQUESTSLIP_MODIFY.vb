Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frm8SI_REQUESTSLIP_MODIFY

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
            btnPRINT.Enabled = True
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
            cm = New MySqlCommand("Update tbl_8si_requestslip set date_needed=@date_needed, modified_date=@modified_date where id=@id", cn)
            With cm.Parameters
                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@modified_date", txtDATE.Value)
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInREQUESTList()
            SaveInSLIPList()
            btnSAVE.Enabled = False

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

    Sub DisplaySLIP()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_8si_requestslip where transaction_no = '" & txtTRANSAC.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

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

    Sub LoadREQUESTList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_requestsliplist where `controlno` like '%" & txtCONTROL.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("description").ToString, dr.Item("remarks").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtDESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles txtDESCRIPTION.TextChanged

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

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub frm8SI_REQUESTSLIP_MODIFY_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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