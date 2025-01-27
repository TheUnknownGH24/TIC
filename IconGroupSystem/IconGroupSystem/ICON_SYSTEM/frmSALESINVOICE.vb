Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Drawing.Printing

Public Class frmSALESINVOICE

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click


        If txtSO_NO.Text = "" Then

            MsgBox("All fields are Required", vbOKOnly + vbCritical, "CONFIRMATION")
        Else
            reloadtext_si("Select * from tblsaleinvoice where sales_order='" & txtSO_NO.Text & "' ")
            If dt.Rows.Count > 0 Then
                MsgBox("Sales Order Already Exist", vbOKOnly + vbCritical, "CONFIRMATION")

            Else

                If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblsaleinvoice (sales_order, soldto, address, platforms, note, date) values(@sales_order, @soldto, @address, @platforms, @note, @date)", cn)
                    With cm.Parameters
                        .AddWithValue("@sales_order", txtSO_NO.Text)
                        .AddWithValue("@soldto", txtSOLDTO.Text)
                        .AddWithValue("@address", txtADDRESS.Text)
                        .AddWithValue("@platforms", txtPLATFORMS.Text)
                        .AddWithValue("@note", txtNOTE.Text)
                        .AddWithValue("@date", txtDATE.Text)
                    End With
                    cm.ExecuteNonQuery()
                    cn.Close()
                    DisplaySI()
                    SaveInSIList()
                    txtNOTE.Enabled = False

                Else

                    MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

                End If

            End If
        End If

    End Sub

    Sub DisplaySI()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tblsaleinvoice where sales_order = '" & txtSO_NO.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtSINO.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInSIList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tblsalesinvoice_list (si_no, so_no,item_code, item_name, gross_sales, quantity, gross_profit) values(@si_no, @so_no,@item_code, @item_name, @gross_sales, @quantity, @gross_profit)", cn)
            With cm.Parameters

                .AddWithValue("@si_no", txtSINO.Text)
                .AddWithValue("@so_no", txtSO_NO.Text)

                .AddWithValue("@item_code", row.Cells("SKU_CODE").Value)
                .AddWithValue("@item_name", row.Cells("ITEM_NAME").Value)
                .AddWithValue("@gross_sales", row.Cells("UNIT_PRICE").Value)
                .AddWithValue("@quantity", row.Cells("QUANTITY").Value)
                .AddWithValue("@gross_profit", row.Cells("TOTAL").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next
        MsgBox("Sales Invoice has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Public Sub reloadtext_si(ByVal sql As String)
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

End Class