Public Class frm8SI_REQUESTSLIP_MANAGER_FORM

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
        cm = New MySqlCommand("select * from tbl_8si_requestsliplist where `controlno` like '%" & txtCONTROL.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("description").ToString, dr.Item("remarks").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click


        If txtQTY.Text = String.Empty Or txtUNIT.Text = String.Empty Or txtDESCRIPTION.Text = String.Empty Or txtREMARKS.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        Try

            dataGridView1.Rows.Add(txtQTY.Text, txtUNIT.Text, txtDESCRIPTION.Text, txtREMARKS.Text)

            txtQTY.Text = ""
            txtDESCRIPTION.Text = ""
            txtREMARKS.Text = ""
            btnUPDATE.Enabled = True
            btnPRINT.Enabled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try


    End Sub


    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

        If dataGridView1.Columns(e.ColumnIndex).Name = "QUANTITY" Then
            If String.IsNullOrEmpty(e.ToString) Then
                btnUPDATE.Enabled = False
                btnPRINT.Enabled = False
            Else
                btnUPDATE.Enabled = True
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
                txtUNIT.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)
                update.Cells(0).Value = txtQTY.Text
                update.Cells(1).Value = txtUNIT.Text
                update.Cells(2).Value = txtDESCRIPTION.Text
                update.Cells(3).Value = txtREMARKS.Text

                txtQTY.Text = ""
                txtUNIT.Text = ""
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

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_requestslip set date_needed=@date_needed, manager_approval=@manager_approval, manager_comment=@manager_comment where id=@id", cn)

            With cm.Parameters
                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@manager_approval", "APPROVED")
                .AddWithValue("@manager_comment", txtCOMMENT.Text & " - " & txtVALUEDATE.Value)
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInREQUESTList()
            SaveInSLIPList()

            LoaDAPPROVALList()

            btnUPDATE.Enabled = False
            btnPRINT.Enabled = False

            MsgBox("Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")


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

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click


        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_requestslip set date_needed=@date_needed, manager_approval=@manager_approval, manager_comment=@manager_comment, status=@status where id=@id", cn)

            With cm.Parameters
                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)
                .AddWithValue("@manager_approval", "DISAPPROVED")
                .AddWithValue("@manager_comment", txtCOMMENT.Text & " - " & txtVALUEDATE.Value)
                .AddWithValue("@status", "DEACTIVE")
            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInREQUESTList()
            SaveInSLIPList()

            LoaDAPPROVALList()

            btnUPDATE.Enabled = False
            btnPRINT.Enabled = False

            MsgBox("Request has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    '========================================================================================================================================================================


    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `controlno` like '%" & txtSEARCHNAME.Text & "%' AND `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `controlno` like '%" & txtSEARCHNAME.Text & "%' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

            End While

            dr.Close()
            cn.Close()


        End If

    End Sub

    Sub LoaDAPPROVALList()


        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

            End While
            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" And txtDEP.Text = "DRS - VP SALES" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `manager_approval` = 'FOR APPROVAL' AND `department` = 'DIRECT SELLING - OPERATIONS' or `manager_approval` = 'ASM APPROVED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND `status` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

            End While
            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `manager_approval` = 'FOR APPROVAL' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND `status` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("date_now").ToString, dr.Item("employee_name").ToString, dr.Item("department").ToString, dr.Item("date_needed").ToString, dr.Item("date_time").ToString)

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
            btnUPDATE.Enabled = True
            btnPRINT.Enabled = True
            LoadREQUESTList()

        End If


    End Sub

    Private Sub frm8SI_REQUESTSLIP_MANAGER_FORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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