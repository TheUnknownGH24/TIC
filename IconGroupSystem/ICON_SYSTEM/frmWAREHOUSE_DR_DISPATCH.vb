Public Class frmWAREHOUSE_DR_DISPATCH

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
        DataGridView2.Columns.Insert(23, colApproval)

    End Sub

    Sub LoadDRList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_dr where `supervisor_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `STATUS` = 'FOR DISPATCH' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("requestor_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString, dr.Item("dispatch").ToString, dr.Item("recieved").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_dr where dr_no like '%" & TextBox1.Text & "%' AND `supervisor_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `STATUS` = 'FOR DISPATCH' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("requestor_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString, dr.Item("dispatch").ToString, dr.Item("recieved").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        dataGridView1.Rows.Clear()
        txtSUPERVISORCOMMENT.Text = ""
        txtSUPERVISORCOMMENT.Text = String.Empty

        txtMANAGERCOMMENT.Text = ""
        txtMANAGERCOMMENT.Text = String.Empty

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_dr where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtPONO.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString

                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtSUPPLIERNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtSUBREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                'txtRECEIVEDDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtSTATUS.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtWAREHOUSE.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString

                txtSUPERVISORCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadDRITEMLIST()

            btnSAVE.Enabled = True

        End If

    End Sub

    Sub LoadDRITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_dr_item where `dr_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("unit").ToString, dr.Item("qty_loose").ToString, dr.Item("qty_case_bulk").ToString, dr.Item("per_case_bulk").ToString, dr.Item("total_quantity").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString, dr.Item("status").ToString, dr.Item("remaining").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_dr set status=@status, dispatch=@dispatch where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@status", "DISPATCH")
                    .AddWithValue("@dispatch", txtNAME.Text & "-" & DateTimePicker1.Value)

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                DispatchUpdate()
                LoadDRList()

                btnSAVE.Enabled = False

                MsgBox("Delivery Receipt has been Successfully Dispatch!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub DispatchUpdate()

        If txtFINALCODE.Text = "SRS" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_warehouse_srs set request_status=@request_status where srs_no=@srs_no", cn)

            With cm.Parameters

                .AddWithValue("@srs_no", txtPONO.Text)

                .AddWithValue("@request_status", "DISPATCH")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtFINALCODE.Text = "MIR" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_warehouse_mir set request_status=@request_status where mir_no=@mir_no", cn)

            With cm.Parameters

                .AddWithValue("@mir_no", txtPONO.Text)

                .AddWithValue("@request_status", "DISPATCH")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtFINALCODE.Text = "SR" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_warehouse_sr set request_status=@request_status where sr_no=@sr_no", cn)

            With cm.Parameters

                .AddWithValue("@sr_no", txtPONO.Text)

                .AddWithValue("@request_status", "DISPATCH")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtFINALCODE.Text = "IPR" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_warehouse_ipr set request_status=@request_status where ipr_no=@ipr_no", cn)

            With cm.Parameters

                .AddWithValue("@ipr_no", txtPONO.Text)

                .AddWithValue("@request_status", "DISPATCH")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtSUPERVISORCOMMENT.Text
            .ShowDialog()

        End With



    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub


    Private Sub frmWAREHOUSE_DR_MANAGER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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


    Private Sub txtPONO_TextChanged(sender As Object, e As EventArgs) Handles txtPONO.TextChanged

        Dim text1 As String = txtPONO.Text
        Dim index1 As Integer = text1.IndexOfAny("_")

        If index1 > -1 Then
            Dim firstLetter As Char = text1(index1 - 3)
            txtCODE1.Text = firstLetter
        End If

        '==================================================

        Dim text2 As String = txtPONO.Text
        Dim index2 As Integer = text2.IndexOfAny("_")

        If index2 > -1 Then
            Dim secondLetter As Char = text2(index2 - 2)
            txtCODE2.Text = secondLetter
        End If

        '==================================================

        Dim text3 As String = txtPONO.Text
        Dim index3 As Integer = text2.IndexOfAny("_")

        If index3 > -1 Then
            Dim thirdLetter As Char = text3(index3 - 1)
            txtCODE3.Text = thirdLetter
        End If

        '==================================================

        txtFINALCODE.Text = txtCODE1.Text & txtCODE2.Text & txtCODE3.Text

    End Sub


End Class