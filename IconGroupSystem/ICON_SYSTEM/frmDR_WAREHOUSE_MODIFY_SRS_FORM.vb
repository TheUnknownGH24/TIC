Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.OleDb

Public Class frmDR_WAREHOUSE_MODIFY_SRS_FORM

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Sub LoadITEMList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbldeliveryreceipt_warehouse_list where `dr_no` like '%" & txtDRNO.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("description").ToString, dr.Item("remarks").ToString, dr.Item("item_id").ToString, dr.Item("quantity_issued").ToString, dr.Item("remaining").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtQTY_KeyPress(sender As Object, e As KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub


    Private Sub button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If txtQTY.Text = String.Empty Or txtUNIT.Text = String.Empty Or txtDESCRIPTION.Text = String.Empty Or txtREMARKS.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        Try

            dataGridView1.Rows.Add(txtQTY.Text, txtUNIT.Text, txtDESCRIPTION.Text, txtREMARKS.Text)

            txtQTY.Text = ""
            txtUNIT.Text = ""
            txtDESCRIPTION.Text = ""
            txtREMARKS.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

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

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Dim i1 As Integer
        Dim i2 As Integer
        For i1 = 0 To Me.dataGridView1.Columns.Count - 1
            For i2 = 0 To Me.dataGridView1.Rows.Count - 1
                If String.IsNullOrEmpty(Me.dataGridView1.Item(i1, i2).Value) Then
                    MsgBox("If out stock please input '0' in Quantity Issued and Fill the Remarks", vbOKOnly + vbCritical, "CONFIRMATION")
                    Return
                End If
            Next
        Next

        '=========================================================================================================================

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbldeliveryreceipt_warehouse set date_needed=@date_needed, modified_date=@modified_date where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@date_needed", txtDATENEEDED.Text)

                .AddWithValue("@modified_date", txtDATE.Value)

            End With

            cm.ExecuteNonQuery()
            cn.Close()
            DeleteInDRSRSList()
            SaveInDRList()

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInDRSRSList()

        cm = New MySqlCommand("DELETE FROM tbldeliveryreceipt_warehouse_list WHERE `reference` like '%" & txtREF.Text & "%'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub DisplayDR()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbldeliveryreceipt_warehouse where sales_orderno = '" & txtREF.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtDRNO.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInDRList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbldeliveryreceipt_warehouse_list (dr_no, reference, quantity, unit, description, remarks, item_id, quantity_issued, remaining) values(@dr_no, @reference, @quantity, @unit, @description, @remarks, @item_id, @quantity_issued, @remaining)", cn)
            With cm.Parameters

                .AddWithValue("@dr_no", txtDRNO.Text)
                .AddWithValue("@reference", txtREF.Text)

                .AddWithValue("@quantity", row.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row.Cells("UNIT").Value)
                .AddWithValue("@description", row.Cells("DESCRIPTION").Value)
                .AddWithValue("@remarks", row.Cells("REMARKS").Value)
                .AddWithValue("@item_id", row.Cells("ITEM_ID").Value)
                .AddWithValue("@quantity_issued", row.Cells("QTY_ISSUED").Value)
                .AddWithValue("@remaining", row.Cells("REMAINING").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next
        MsgBox("Delivery Receipt has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Public Sub reloadtext(ByVal sql As String)
        Try
            cn.Open()
            With cm
                .Connection = cn
                .CommandText = sql
            End With
            dt = New DataTable
            adp = New MySqlDataAdapter(sql, cn)
            adp.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message & "reloadtext", vbCritical)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
                adp.Dispose()
            End If
        End Try
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

    Private Sub dataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)

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

    Private Sub txtQTYISSUED_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQTYISSUED.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub dataGridView1_CellContentClick_2(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

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

                If txtITEMID.Text = update.Cells(4).Value Then

                    update.Cells(0).Value = txtQTY.Text
                    update.Cells(1).Value = txtUNIT.Text
                    update.Cells(2).Value = txtDESCRIPTION.Text
                    update.Cells(3).Value = txtREMARKS.Text
                    update.Cells(4).Value = txtITEMID.Text
                    update.Cells(5).Value = txtQTYISSUED.Text
                    update.Cells(6).Value = txtREMAINING.Text

                    update_item()

                    txtQTY.Text = ""
                    txtUNIT.Text = ""
                    txtDESCRIPTION.Text = ""
                    txtREMARKS.Text = ""
                    txtITEMID.Text = ""
                    txtQTYISSUED.Text = ""
                    txtREMAINING.Text = ""
                    txtSTOCK.Text = ""
                    txtITEMCODE.Text = ""

                Else

                    MsgBox("Selected Item Not Match", vbOKOnly + vbCritical, "CONFIRMATION")
                    Return

                End If

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


    Private Sub txtQTYISSUED_TextChanged(sender As Object, e As EventArgs) Handles txtQTYISSUED.TextChanged

        If txtQTYISSUED.Text = String.Empty Then
            txtREMAINING.Text = ""
            Return
        End If

        If CDbl(txtSTOCK.Text) < CDbl(txtQTYISSUED.Text) Then
            MsgBox("Stock is not enough!", vbCritical + vbOKOnly, "CONFIRMATION")
            txtQTYISSUED.Text = ""
            Return
        End If

        If CDbl(txtQTY.Text) < CDbl(txtQTYISSUED.Text) Then
            MsgBox("Quantity Issued is Greater than Quantity Request!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If CDbl(txtSTOCK.Text) >= CDbl(txtQTYISSUED.Text) Then

            txtREMAINING.Text = txtSTOCK.Text - txtQTYISSUED.Text

        End If


    End Sub

    Sub update_item()

        Try

            If txtQTYISSUED.Text = String.Empty Then

                MsgBox("Please input quantity issued!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tblitem set stock_on_hand=@stock_on_hand where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtITEMID.Text)
                    .AddWithValue("@stock_on_hand", txtREMAINING.Text)

                End With

                cm.ExecuteNonQuery()
                cn.Close()

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub CheckEmptyCellOnRowThenRemove()
        Dim rw As DataGridViewRow

        Dim rowToDelete As Int32

        If DataGridView1.RowCount > 1 Then
            For r = DataGridView1.RowCount - 2 To 0 Step -1
                rw = DataGridView1.Rows(r)
                rw.Selected = True
                Dim strCheck As String = ""
                For c = 0 To DataGridView1.ColumnCount - 1
                    If Not IsNothing(rw.Cells(c).Value) Then
                        strCheck = strCheck & rw.Cells(c).Value.ToString.Trim
                    End If
                Next
                If strCheck = "" Then
                    rowToDelete = Me.DataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected)
                    If rowToDelete > -1 Then
                        Me.DataGridView1.Rows.RemoveAt(rowToDelete)
                    End If
                End If
                rw.Selected = False
            Next
        End If
    End Sub

End Class