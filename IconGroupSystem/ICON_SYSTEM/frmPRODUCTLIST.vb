Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmPRODUCTLIST

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmPRODUCT
            .btnSAVE.Enabled = True
            .btnUPDATE.Enabled = True
            .StartPosition = FormStartPosition.CenterScreen
            .ClearProduct()
            .LoadCategory()
            .ShowDialog()
        End With
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

    Sub LoadProductList()
        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblproduct", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("product_code").ToString, dr.Item("description").ToString, dr.Item("price").ToString, dr.Item("category").ToString, dr.Item("weight"), dr.Item("image"), dr.Item("status").ToString)

        End While
        dr.Close()
        cn.Close()

        For i = 0 To dataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = dataGridView1.Rows(i)
            r.Height = 100
        Next

        Dim imagecolumn = DirectCast(dataGridView1.Columns("Column8"), DataGridViewImageColumn)
        imagecolumn.ImageLayout = DataGridViewImageCellLayout.Stretch
    End Sub



    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "colUPDATE" Then
            With frmPRODUCT
                cn.Open()
                cm = New MySqlCommand("select image from tblproduct where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read
                    Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New MemoryStream(array)
                    Dim bitmap As New System.Drawing.Bitmap(ms)
                    .PictureBox1.BackgroundImage = bitmap
                    .txtCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtPRODUCTCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtPRICE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtCATEGORY.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtWEIGHT.Checked = CBool(dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString)
                    .txtSTATUS.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                End While
                dr.Close()
                cn.Close()
                .LoadCategory()
                .btnSAVE.Enabled = False
                .btnUPDATE.Enabled = True
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If

    End Sub

    Private Sub frmPRODUCTLIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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