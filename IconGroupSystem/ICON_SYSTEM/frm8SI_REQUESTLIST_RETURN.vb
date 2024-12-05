Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm8SI_REQUESTLIST_RETURN

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_requestslip where `controlno` like '%" & txtSEARCHNAME.Text & "%' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'RETURN' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString, dr.Item("gm_comment").ToString)

        End While

        dr.Close()
        cn.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        With frmITEM
            .StartPosition = FormStartPosition.CenterScreen
            .btnUPDATE.Enabled = False
            .ShowDialog()
        End With

    End Sub

    Sub LoadREQUESTList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_requestslip where `gm_approval` = 'FOR APPROVAL' AND `status` = 'RETURN' ", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString, dr.Item("gm_comment").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadREQUESTList()

    End Sub

    Private Sub dataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "colUPDATE" Then
            With frm8SI_REQUESTSLIP_RETURN
                cn.Open()
                cm = New MySqlCommand("select * from tbl_8si_requestslip where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read

                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtCONTROL.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtTRANSAC.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtEMPLOYEE.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtDATENEEDED.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                    .txtCOMMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString

                End While
                dr.Close()
                cn.Close()
                .btnSAVE.Enabled = True
                .LoadREQUESTList()
                .LoadITEM()
                .LoadClassification()
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If

    End Sub


    Private Sub frm8SI_REQUESTLIST_RETURN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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