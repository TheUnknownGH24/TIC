Imports System.Data.OleDb

Public Class frmDR_LAZADA

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub btnBROWSE_Click(sender As Object, e As EventArgs) Handles btnBROWSE.Click

        OpenFileDialog1.Filter = "Excel|*.xls;*.xlsx"
        OpenFileDialog1.ShowDialog()
        txtFILEPATH.Text = OpenFileDialog1.FileName

        Dim filepath As String = txtFILEPATH.Text
        Dim connstring As String = String.Empty
        If filepath.EndsWith(".xls") Then
            connstring = String.Format("Provider=Microsoft.Jet.Oledb.4.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        Else
            connstring = String.Format("Provider=Microsoft.Ace.Oledb.12.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        End If
        Dim conn As New OleDbConnection(connstring)
        conn.Open()
        txtSHEETS.DataSource = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        txtSHEETS.DisplayMember = "Table_Name"
        txtSHEETS.ValueMember = "Table_Name"
        conn.Close()
        btnBROWSE.Enabled = True
        btnDISPLAY.Enabled = True
        txtSEARCHNAME.Enabled = False

    End Sub

    Private Sub btnDISPLAY_Click(sender As Object, e As EventArgs) Handles btnDISPLAY.Click

        Dim filepath As String = txtFILEPATH.Text
        Dim connstring As String = String.Empty
        If filepath.EndsWith(".xls") Then
            connstring = String.Format("Provider=Microsoft.Jet.Oledb.4.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        Else
            connstring = String.Format("Provider=Microsoft.Ace.Oledb.12.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        End If
        Dim cmd As New OleDbDataAdapter("Select * from[" & txtSHEETS.Text & "" & "]", connstring)
        cmd.TableMappings.Add("Table", "Table")
        Dim dt As New DataSet
        cmd.Fill(dt)
        dataGridView1.DataSource = dt.Tables(0)

        Dim checkboxcol As New DataGridViewCheckBoxColumn
        With checkboxcol
            .Width = 50
            .Name = "checkboxcol"
            .HeaderText = "#"
            .DefaultCellStyle.NullValue = False
        End With
        dataGridView1.Columns.Insert(0, checkboxcol)
        btnBROWSE.Enabled = True
        btnDISPLAY.Enabled = True
        txtSEARCHNAME.Enabled = True
        btnCREATE.Enabled = False

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        Dim filepath As String = txtFILEPATH.Text
        Dim connstring As String = String.Empty
        If filepath.EndsWith(".xls") Then
            connstring = String.Format("Provider=Microsoft.Jet.Oledb.4.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        Else
            connstring = String.Format("Provider=Microsoft.Ace.Oledb.12.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        End If
        Dim conn As New OleDbConnection(connstring)
        conn.Open()
        Dim cmd As New OleDbCommand("Select * from[" & txtSHEETS.Text & "" & "] where `orderNumber` like '%' +@parm1+ '%'", conn)
        cmd.Parameters.AddWithValue("@parm1", txtSEARCHNAME.Text)
        Dim da As New OleDbDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        dataGridView1.DataSource = dt
        conn.Close()

    End Sub

    Private Sub btnCREATE_Click(sender As Object, e As EventArgs) Handles btnCREATE.Click

        If txtADDRESS.Text = String.Empty Then

            MsgBox("Youre Selected Order is Cancelled", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Dim chkbox As New DataGridViewCheckBoxColumn

            For Each row As DataGridViewRow In dataGridView1.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells(0)

                cell.Value = True
            Next

            frmWAREHOUSE_DR.txtSO_NO.Text = Me.txtSO_NO.Text
            frmWAREHOUSE_DR.txtSOLDTO.Text = Me.txtSOLDTO.Text
            frmWAREHOUSE_DR.txtADDRESS.Text = Me.txtADDRESS.Text
            frmWAREHOUSE_DR.txtPLATFORMS.Text = Me.lblPLATFORMS.Text

            Dim dt2 As New DataTable
            dt2.Columns.Add("PRODUCT_NAME")
            dt2.Columns.Add("GROSS_SALES")
            dt2.Columns.Add("QUANTITY")
            dt2.Columns.Add("TOTAL")
            For Each row As DataGridViewRow In Me.dataGridView1.Rows
                Dim ischecked As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                If ischecked Then
                    dt2.Rows.Add(row.Cells(52).Value, row.Cells(48).Value, row.Cells(53).Value, row.Cells(48).Value)
                End If
            Next
            frmWAREHOUSE_DR.dataGridView1.DataSource = dt2
            dt2.Columns.Add("PRODUCT_CODE")

            frmWAREHOUSE_DR.ShowDialog()
            frmWAREHOUSE_DR.txtNOTE.Enabled = True

        End If

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        txtSEARCHNAME.Text = dataGridView1.CurrentRow.Cells(13).Value
        txtSO_NO.Text = dataGridView1.CurrentRow.Cells(13).Value
        txtSOLDTO.Text = dataGridView1.CurrentRow.Cells(17).Value
        txtADDRESS.Text = dataGridView1.CurrentRow.Cells(21).Value

        btnBROWSE.Enabled = True
        btnDISPLAY.Enabled = True
        txtSEARCHNAME.Enabled = True
        btnCREATE.Enabled = True

    End Sub
End Class