Public Class frmWAREHOUSE_SRS_RETURN

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
        DataGridView2.Columns.Insert(20, colApproval)

    End Sub

    Sub LoadIPRList()

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_srs where `STATUS` = 'RETURNED' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("releaser_name").ToString, dr.Item("releaser_approval").ToString, dr.Item("releaser_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_srs where `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("releaser_name").ToString, dr.Item("releaser_approval").ToString, dr.Item("releaser_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_srs where srs_no like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("releaser_name").ToString, dr.Item("releaser_approval").ToString, dr.Item("releaser_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_srs where srs_no like '%" & TextBox1.Text & "%' AND `STATUS` = 'RETURNED' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("srs_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("releaser_name").ToString, dr.Item("releaser_approval").ToString, dr.Item("releaser_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        DataGridView3.Rows.Clear()
        txtMANAGERCOMMENT.Text = ""
        txtMANAGERCOMMENT.Text = String.Empty

        txtHRCOMMENT.Text = ""
        txtHRCOMMENT.Text = String.Empty

        txtRELEASERCOMMENT.Text = ""
        txtRELEASERCOMMENT.Text = String.Empty

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_srs where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString

                txtDATEREQUIRED.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtREQUESTOR.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString

                txtHRCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(14).Value.ToString

                txtRELEASERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(17).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadSRSITEMLIST()

            txtPURPOSE.Enabled = True

            btnSAVE.Enabled = True
            Button5.Enabled = True

            txtDATEREQUIRED.Enabled = True

        End If

    End Sub

    Sub LoadSRSITEMLIST()

        DataGridView3.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_srs_item where `srs_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView3.Rows.Add(dr.Item("item_code").ToString, dr.Item("item_name").ToString, dr.Item("classification").ToString, dr.Item("uom").ToString, dr.Item("qty_requested").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_srs set purpose=@purpose, date_required=@date_required, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@purpose", txtPURPOSE.Text)
                    .AddWithValue("@date_required", txtDATEREQUIRED.Text)

                    .AddWithValue("@status", "ACTIVE")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                DeleteInSRSList()
                SaveInSRSList()

                btnSAVE.Enabled = False
                btnPRINT.Enabled = True
                Button5.Enabled = False

                DataGridView3.Enabled = False

                txtPURPOSE.Enabled = False

                txtDATEREQUIRED.Enabled = False

                LoadIPRList()

                MsgBox("Supply Requisition has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub DeleteInSRSList()

        cm = New MySqlCommand("DELETE FROM tbl_warehouse_srs_item WHERE `srs_no` like '" & txtCONTROL.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtHRCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtRELEASERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    '=======================================================================================================================

    Sub LoadITEM()

        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `classification` = 'OFFICE SUPPLIES'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `itemname` like '%" & txtSEARCHNAME.Text & "%' AND `classification` like 'OFFICE SUPPLIES'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSEARCHCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs)

        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtDATEREQUIRED_ValueChanged(sender As Object, e As EventArgs) Handles txtDATEREQUIRED.ValueChanged

        If txtDATEREQUIRED.Text <= Date.Now Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATEREQUIRED.Text = Now.AddDays(1)
            txtDATEREQUIRED.Focus()

        End If

    End Sub

    Sub SaveInSRSList()

        For Each row As DataGridViewRow In DataGridView3.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_srs_item (srs_no, item_code, item_name, classification, uom, qty_requested) values(@srs_no, @item_code, @item_name, @classification, @uom, @qty_requested)", cn)

            With cm.Parameters

                .AddWithValue("@srs_no", txtCONTROL.Text)

                .AddWithValue("@item_code", row.Cells("ITEM_CODE").Value)
                .AddWithValue("@item_name", row.Cells("ITEM_DESCRIPTION").Value)
                .AddWithValue("@classification", row.Cells("CLASSIFICATION").Value)
                .AddWithValue("@uom", row.Cells("UOM").Value)
                .AddWithValue("@qty_requested", row.Cells("QTY_REQUESTED").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        txtITEMCODE.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtITEMDESCRIPTION.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtUOM.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtCLASSIFICATION.Text = DataGridView1.CurrentRow.Cells(3).Value

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

        Try

            If DataGridView3.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                txtITEMCODE.Text = DataGridView3.Rows(e.RowIndex).Cells(0).Value.ToString
                txtITEMDESCRIPTION.Text = DataGridView3.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCLASSIFICATION.Text = DataGridView3.Rows(e.RowIndex).Cells(2).Value.ToString
                txtUOM.Text = DataGridView3.Rows(e.RowIndex).Cells(3).Value.ToString
                txtQTYREQUESTED.Text = DataGridView3.Rows(e.RowIndex).Cells(4).Value.ToString

            ElseIf DataGridView3.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = DataGridView3.SelectedRows(0)

                update.Cells(0).Value = txtITEMCODE.Text
                update.Cells(1).Value = txtITEMDESCRIPTION.Text
                update.Cells(2).Value = txtCLASSIFICATION.Text
                update.Cells(3).Value = txtUOM.Text
                update.Cells(4).Value = txtQTYREQUESTED.Text

                txtITEMCODE.Text = ""
                txtITEMDESCRIPTION.Text = ""
                txtCLASSIFICATION.Text = ""
                txtUOM.Text = ""
                txtQTYREQUESTED.Text = ""

                txtITEMCODE.Text = String.Empty
                txtITEMDESCRIPTION.Text = String.Empty
                txtCLASSIFICATION.Text = String.Empty
                txtUOM.Text = String.Empty
                txtQTYREQUESTED.Text = String.Empty

            ElseIf DataGridView3.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        DataGridView3.Rows.RemoveAt(DataGridView3.SelectedRows(0).Index)

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)

                End Try

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If txtITEMCODE.Text = String.Empty Or txtITEMDESCRIPTION.Text = String.Empty Or txtCLASSIFICATION.Text = String.Empty Or txtUOM.Text = String.Empty Or txtQTYREQUESTED.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        For i As Integer = 0 To DataGridView3.Rows.Count - 1

            If txtITEMCODE.Text = DataGridView3.Rows(i).Cells(0).Value.ToString() Then

                MsgBox("Item Already in List of Data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

        Next

        '=========================================================================================

        Try

            DataGridView3.Rows.Add(txtITEMCODE.Text, txtITEMDESCRIPTION.Text, txtCLASSIFICATION.Text, txtUOM.Text, txtQTYREQUESTED.Text)

            '=========================================================================================

            txtITEMCODE.Text = ""
            txtITEMDESCRIPTION.Text = ""
            txtCLASSIFICATION.Text = ""
            txtUOM.Text = ""
            txtQTYREQUESTED.Text = ""

            txtITEMCODE.Text = String.Empty
            txtITEMDESCRIPTION.Text = String.Empty
            txtCLASSIFICATION.Text = String.Empty
            txtUOM.Text = String.Empty
            txtQTYREQUESTED.Text = String.Empty


            btnSAVE.Enabled = True

        Catch ex As Exception

            'MessageBox.Show(ex.Message.ToString())

        End Try

    End Sub

    Private Sub frmWAREHOUSE_SRS_RETURN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub DataGridView3_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView3.CurrentCellChanged

        DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DataGridView3.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub
End Class