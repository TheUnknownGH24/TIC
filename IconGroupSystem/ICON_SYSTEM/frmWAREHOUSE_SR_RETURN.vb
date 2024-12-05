Public Class frmWAREHOUSE_SR_RETURN

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Sub LoadClassification()

        txtSEARCHCLASSIFICATION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblclassification", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSEARCHCLASSIFICATION.Items.Add(dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadITEM()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If txtSEARCHCLASSIFICATION.Text = "" Or txtSEARCHCLASSIFICATION.Text = String.Empty Then

            MsgBox("Please Select Classification!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `itemname` like '%" & txtSEARCHNAME.Text & "%' AND  `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSEARCHCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHCLASSIFICATION.SelectedIndexChanged

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

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick

        txtITEMCODE.Text = DataGridView2.CurrentRow.Cells(0).Value
        txtITEMDESCRIPTION.Text = DataGridView2.CurrentRow.Cells(1).Value
        txtUOM.Text = DataGridView2.CurrentRow.Cells(2).Value
        txtCLASSIFICATION.Text = DataGridView2.CurrentRow.Cells(3).Value

    End Sub

    Private Sub frmWAREHOUSE_IPR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub txtDATEREQUIRED_ValueChanged(sender As Object, e As EventArgs) Handles txtDATEREQUIRED.ValueChanged

        If txtDATEREQUIRED.Text <= Date.Now Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATEREQUIRED.Text = Now.AddDays(1)
            txtDATEREQUIRED.Focus()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If txtITEMCODE.Text = String.Empty Or txtITEMDESCRIPTION.Text = String.Empty Or txtCLASSIFICATION.Text = String.Empty Or txtUOM.Text = String.Empty Or txtQTYREQUESTED.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        For i As Integer = 0 To dataGridView1.Rows.Count - 1

            If txtITEMCODE.Text = dataGridView1.Rows(i).Cells(0).Value.ToString() Then

                MsgBox("Item Already in List of Data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

        Next

        '=========================================================================================

        Try

            dataGridView1.Rows.Add(txtITEMCODE.Text, txtITEMDESCRIPTION.Text, txtCLASSIFICATION.Text, txtUOM.Text, txtQTYREQUESTED.Text)

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

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtITEMCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtITEMDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCLASSIFICATION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtUOM.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtQTYREQUESTED.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

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

        If txtPURPOSE.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_warehouse_sr set date_required=@date_required, purpose=@purpose, classification=@classification, date_time=@date_time, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@date_required", txtDATEREQUIRED.Text)
                .AddWithValue("@purpose", txtPURPOSE.Text)
                .AddWithValue("@classification", txtSEARCHCLASSIFICATION.Text)

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DeleteInSRList()
            SaveInISRList()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True
            Button2.Enabled = False

            dataGridView1.Enabled = False

            txtDATEREQUIRED.Enabled = False
            txtPURPOSE.Enabled = False
            txtSEARCHCLASSIFICATION.Enabled = False

            MsgBox("Stock Replenishment Request has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInSRList()

        cm = New MySqlCommand("DELETE FROM tbl_warehouse_sr_item WHERE `sr_no` like '" & txtCONTROL.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub SaveInISRList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_sr_item (sr_no, item_code, item_name, classification, uom, qty_requested) values(@sr_no, @item_code, @item_name, @classification, @uom, @qty_requested)", cn)

            With cm.Parameters

                .AddWithValue("@sr_no", txtCONTROL.Text)

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

    '==================================================================================================================

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
        DataGridView3.Columns.Insert(19, colApproval)

    End Sub

    Sub LoadIPRList()

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView3.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_sr where `status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView3.Rows.Add(i, dr.Item("id").ToString, dr.Item("sr_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("warehouse").ToString, dr.Item("classification").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView3.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_sr where `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND `status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView3.Rows.Add(i, dr.Item("id").ToString, dr.Item("sr_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("warehouse").ToString, dr.Item("classification").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView3.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_sr where sr_no like '%" & TextBox1.Text & "%' AND `status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView3.Rows.Add(i, dr.Item("id").ToString, dr.Item("sr_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("warehouse").ToString, dr.Item("classification").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView3.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_sr where sr_no like '%" & TextBox1.Text & "%' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%' AND `status` like 'RETURNED' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView3.Rows.Add(i, dr.Item("id").ToString, dr.Item("sr_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("warehouse").ToString, dr.Item("classification").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub DataGridView3_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView3.CurrentCellDirtyStateChanged

        DataGridView3.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Sub LoadSRITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_sr_item where `sr_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("item_code").ToString, dr.Item("item_name").ToString, dr.Item("classification").ToString, dr.Item("uom").ToString, dr.Item("qty_requested").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

        If dataGridView1.CurrentCell Is Nothing Then

            txtSEARCHCLASSIFICATION.Enabled = True

        Else

            txtSEARCHCLASSIFICATION.Enabled = False

        End If

    End Sub

    Private Sub frmWAREHOUSE_IPR_MANAGER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtGMCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

        dataGridView1.Rows.Clear()
        txtMANAGERCOMMENT.Text = ""
        txtMANAGERCOMMENT.Text = String.Empty

        txtGMCOMMENT.Text = ""
        txtGMCOMMENT.Text = String.Empty

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_sr where id like '" & DataGridView3.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView3.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView3.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView3.Rows(e.RowIndex).Cells(4).Value.ToString

                txtDATEREQUIRED.Text = DataGridView3.Rows(e.RowIndex).Cells(5).Value.ToString
                txtREQUESTOR.Text = DataGridView3.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPARTMENT.Text = DataGridView3.Rows(e.RowIndex).Cells(7).Value.ToString

                txtPURPOSE.Text = DataGridView3.Rows(e.RowIndex).Cells(8).Value.ToString
                txtWAREHOUSE.Text = DataGridView3.Rows(e.RowIndex).Cells(9).Value.ToString
                txtSEARCHCLASSIFICATION.Text = DataGridView3.Rows(e.RowIndex).Cells(10).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView3.Rows(e.RowIndex).Cells(11).Value.ToString & " - " & DataGridView3.Rows(e.RowIndex).Cells(13).Value.ToString

                txtGMCOMMENT.Text = DataGridView3.Rows(e.RowIndex).Cells(14).Value.ToString & " - " & DataGridView3.Rows(e.RowIndex).Cells(16).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnSAVE.Enabled = True
            btnPRINT.Enabled = False
            Button2.Enabled = True

            dataGridView1.Enabled = True

            txtDATEREQUIRED.Enabled = True
            txtPURPOSE.Enabled = True
            txtSEARCHCLASSIFICATION.Enabled = True

            LoadSRITEMLIST()

        End If

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

    End Sub
End Class