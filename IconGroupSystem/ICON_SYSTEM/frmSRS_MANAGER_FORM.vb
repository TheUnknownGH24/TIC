Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSRS_MANAGER_FORM

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

    Sub LoadITEMList()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("stock_on_hand").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtDESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles txtDESCRIPTION.TextChanged

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `itemname` like '%" & txtDESCRIPTION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("stock_on_hand").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick

        txtITEMID.Text = DataGridView2.CurrentRow.Cells(0).Value
        txtITEMCODE.Text = DataGridView2.CurrentRow.Cells(1).Value
        txtDESCRIPTION.Text = DataGridView2.CurrentRow.Cells(2).Value
        txtUNIT.Text = DataGridView2.CurrentRow.Cells(3).Value
        txtSTOCK.Text = DataGridView2.CurrentRow.Cells(4).Value

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


    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If txtITEMCODE.Text = String.Empty Then
            MsgBox("Item is not Available in Warehouse, Please select Specific Item!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtSTOCK.Text = String.Empty Or txtSTOCK.Text = 0 Then
            MsgBox("No Available Stock!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtQTY.Text = String.Empty Or txtUNIT.Text = String.Empty Or txtDESCRIPTION.Text = String.Empty Or txtREMARKS.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        Try

            dataGridView1.Rows.Add(txtQTY.Text, txtUNIT.Text, txtDESCRIPTION.Text, txtREMARKS.Text, txtITEMID.Text)

            txtQTY.Text = ""
            txtUNIT.Text = ""
            txtDESCRIPTION.Text = ""
            txtREMARKS.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try


    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtQTY.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtUNIT.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREMARKS.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtITEMID.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString

                load_itemdetails()

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)
                update.Cells(0).Value = txtQTY.Text
                update.Cells(1).Value = txtUNIT.Text
                update.Cells(2).Value = txtDESCRIPTION.Text
                update.Cells(3).Value = txtREMARKS.Text
                update.Cells(4).Value = txtITEMID.Text

                txtQTY.Text = ""
                txtUNIT.Text = ""
                txtDESCRIPTION.Text = ""
                txtREMARKS.Text = ""
                txtITEMID.Text = ""
                txtSTOCK.Text = ""
                txtITEMCODE.Text = ""

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
            cm = New MySqlCommand("Update tblsrs_request set date_needed=@date_needed, manager_approval=@manager_approval, manager_comment=@manager_comment where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_needed", txtDATENEEDED.Text)

                .AddWithValue("@manager_approval", "APPROVED")
                .AddWithValue("@manager_comment", txtCOMMENT.Text & " - " & DateTimePicker1.Value)

            End With
            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInSRSList()
            SaveInSRSList()
            btnSAVE.Enabled = False

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInSRSList()

        cm = New MySqlCommand("DELETE FROM tblsrs_request_list WHERE `srs_no` like '%" & txtCONTROL.Text & "%'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub DisplaySRS()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tblsrs_request where transaction_no = '" & txtTRANSAC.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInSRSList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tblsrs_request_list (srs_no, quantity, unit, description, remarks, item_id) values(@srs_no, @quantity, @unit, @description, @remarks, @item_id)", cn)
            With cm.Parameters
                .AddWithValue("@srs_no", txtCONTROL.Text)

                .AddWithValue("@quantity", row.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row.Cells("UNIT").Value)
                .AddWithValue("@description", row.Cells("DESCRIPTION").Value)
                .AddWithValue("@remarks", row.Cells("REMARKS").Value)
                .AddWithValue("@item_id", row.Cells("ITEM_ID").Value)
            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next
        MsgBox("Supply Requisition has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Sub LoadREQUESTList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblsrs_request_list where `srs_no` like '%" & txtCONTROL.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("description").ToString, dr.Item("remarks").ToString, dr.Item("item_id").ToString)


        End While
        dr.Close()
        cn.Close()

    End Sub

    Sub load_itemdetails()

        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `id` like '%" & txtITEMID.Text & "%'", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtUNIT.Text = dr("uom").ToString()
            txtSTOCK.Text = dr("stock_on_hand").ToString()
            txtITEMCODE.Text = dr("itemcode").ToString()

        End While

        dr.Close()
        cn.Close()

    End Sub

End Class