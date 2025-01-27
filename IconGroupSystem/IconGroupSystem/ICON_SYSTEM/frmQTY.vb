Imports MySql.Data.MySqlClient

Public Class frmQTY
    Dim id As String
    Dim price As Double

    Private Sub frmQTY_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        ElseIf e.KeyCode = Keys.Enter Then
            cn.Open()
            cm = New MySqlCommand("insert into tblsalesinvoice (sales_orderno, platforms, trans_date, sold_to, address, terms, pid, price, qty) values (@sales_orderno, @platforms, @trans_date, @sold_to, @address, @terms, @pid, @price, @qty)", cn)
            With cm
                If txtQTY.Text = String.Empty Then

                    Me.Dispose()

                Else

                    .Parameters.AddWithValue("@sales_orderno", txtSO_NO.Text)
                    .Parameters.AddWithValue("@platforms", txtPLATFORMS.Text)
                    .Parameters.AddWithValue("@trans_date", txtTRANSDATE.Value)
                    .Parameters.AddWithValue("@sold_to", txtSOLDTO.Text)
                    .Parameters.AddWithValue("@address", txtADDRESS.Text)
                    .Parameters.AddWithValue("@terms", txtTERMS.Text)
                    .Parameters.AddWithValue("@pid", id)
                    .Parameters.AddWithValue("@price", price)
                    .Parameters.AddWithValue("@qty", CDbl(txtQTY.Text))
                    .ExecuteNonQuery()

                End If

            End With
            cn.Close()

            cn.Open()
            cm = New MySqlCommand("update tblsalesinvoice set total = price * qty", cn)
            cm.ExecuteNonQuery()
            cn.Close()

            LoadCartview()

            Me.Dispose()

        End If

    End Sub

    Private Sub frmQTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        frmPOS.loadMenu()
    End Sub


    Sub AddtoCart(ByVal id As String, ByVal price As Double, weight As Boolean)

        If weight = False Then lblQTY.Text = "QUANTITY" Else lblQTY.Text = "Weight"

        Me.price = price
        Me.id = id

    End Sub

    Private Sub txtQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQTY.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 48
            Case 8
            Case 13
            Case Else
                e.Handled = True
        End Select

    End Sub


    Sub LoadCartview()

        Dim _total As Double

        With frmPOS

            frmPOS.dataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("select c.id, p.description, c.price, c.qty, c.total from tblsalesinvoice as c inner join tblproduct as p on p.id = c.pid where c.sales_orderno like '" & txtSO_NO.Text & "' ", cn)
            dr = cm.ExecuteReader
            While dr.Read
                _total = CDbl(dr.Item("total")).ToString
                .dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("description").ToString, dr.Item("price").ToString, dr.Item("qty").ToString, dr.Item("total").ToString)
            End While
            dr.Close()
            cn.Close()

            .txtTOTAL.Text = Format(_total, "#,##0.00")

        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub txtQTY_TextChanged(sender As Object, e As EventArgs) Handles txtQTY.TextChanged

    End Sub
End Class