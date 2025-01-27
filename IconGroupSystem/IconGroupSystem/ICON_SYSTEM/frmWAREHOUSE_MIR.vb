Public Class frmWAREHOUSE_MIR

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Sub LoadClassification()

        txtSEARCHCLASSIFICATION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblclassification where `classification` like '%" & txtPM.Text & "%' OR `classification` like '%" & txtRM.Text & "%'", cn)
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
        cm = New MySqlCommand("select * from tblitem where `classification` like '%" & txtPM.Text & "%' OR `classification` like '%" & txtRM.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Sub Search_Item()

        If txtSEARCHNAME.Text = String.Empty Then

            DataGridView2.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("select * from tblitem where `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read

                DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

            End While

            dr.Close()
            cn.Close()

        Else

            DataGridView2.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("select * from tblitem where `itemname` like '%" & txtSEARCHNAME.Text & "%' AND `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read

                DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub txtSEARCHCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs)

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

    Private Sub DataGridView2_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellChanged

        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

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

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtPURPOSE.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtPRODUCTIONNO.Text = "" Then

            MsgBox("Please input Production No!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtPRODUCTIONNAME.Text = "" Then

            MsgBox("Please input Production Name!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_warehouse_mir (date, transactionno, date_required, requestor, department, purpose, production_no, production_name, manager_name, manager_approval, manager_comment, final_name, final_approval, final_comment, date_time, status, request_status) values(@date, @transactionno, @date_required, @requestor, @department, @purpose, @production_no, @production_name, @manager_name, @manager_approval, @manager_comment, @final_name, @final_approval, @final_comment, @date_time, @status, @request_status)", cn)
            With cm.Parameters

                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@transactionno", txtTRANSACTION.Text)
                .AddWithValue("@date_required", txtDATEREQUIRED.Text)
                .AddWithValue("@requestor", txtREQUESTOR.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@purpose", txtPURPOSE.Text)
                .AddWithValue("@production_no", txtPRODUCTIONNO.Text)
                .AddWithValue("@production_name", txtPRODUCTIONNAME.Text)

                .AddWithValue("@manager_name", " ")
                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@manager_comment", " ")

                .AddWithValue("@final_name", " ")
                .AddWithValue("@final_approval", "FOR APPROVAL")
                .AddWithValue("@final_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

                .AddWithValue("@request_status", " ")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DisplaySRS()
            SaveInSRSList()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True
            Button2.Enabled = False

            dataGridView1.Enabled = False

            txtDATEREQUIRED.Enabled = False
            txtPURPOSE.Enabled = False
            txtPRODUCTIONNAME.Enabled = False
            txtPRODUCTIONNO.Enabled = False

            MsgBox("Material Issuance has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DisplaySRS()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_warehouse_mir where `transactionno` = '" & txtTRANSACTION.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInSRSList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_mir_item (mir_no, item_code, item_name, classification, uom, qty_requested) values(@mir_no, @item_code, @item_name, @classification, @uom, @qty_requested)", cn)

            With cm.Parameters

                .AddWithValue("@mir_no", txtCONTROL.Text)

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

    Private Sub btnRESET_Click(sender As Object, e As EventArgs) Handles btnRESET.Click

        Try
            If MsgBox("Do you want to Reset ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                txtCONTROL.Text = ""
                txtPURPOSE.Text = ""
                txtPRODUCTIONNAME.Text = ""
                txtPRODUCTIONNO.Text = ""
                txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

                txtCONTROL.Text = String.Empty
                txtPURPOSE.Text = String.Empty
                txtPRODUCTIONNAME.Text = String.Empty
                txtPRODUCTIONNO.Text = String.Empty

                dataGridView1.Rows.Clear()

                Button2.Enabled = True

                txtDATEREQUIRED.Enabled = True
                txtPURPOSE.Enabled = True
                txtPRODUCTIONNAME.Enabled = True
                txtPRODUCTIONNO.Enabled = True

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub txtSEARCHCLASSIFICATION_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles txtSEARCHCLASSIFICATION.SelectedIndexChanged

        Search_Item()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPRODUCTIONNAME.Text
            .ShowDialog()

        End With

    End Sub


End Class