Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmPRODUCT

    Public Function GetInitials(ByVal MyText As String) As String
        Dim Initials As String = ""
        Dim AllWords() As String = MyText.Split(" "c)
        For Each Word As String In AllWords
            If Word.Length > 0 Then
                Initials = Initials & Word.Chars(0).ToString.ToUpper
            End If
        Next
        Return Initials
    End Function

    Public Function getNumeric(value As String) As String
        Dim output As StringBuilder = New StringBuilder
        For i = 0 To value.Length - 1
            If IsNumeric(value(i)) Then
                output.Append(value(i))
            End If
        Next
        Return output.ToString()
    End Function


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmCATEGORY

            .ShowDialog()

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnUPLOADIMAGE.Click

        Using ofd As New OpenFileDialog With {.Filter = "(image files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg,|*.jpg|Png,|*.png|Bmp,|*.bmp|Gif,|*.gif|Ico,|*.ico",
                .Multiselect = False, .Title = "Select Image"}

            If ofd.ShowDialog = 1 Then
                PictureBox1.BackgroundImage = Image.FromFile(ofd.FileName)
                OpenFileDialog1.FileName = ofd.FileName

            End If

        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        Try
            If OpenFileDialog1.FileName = "OpenFileDialog1" Then
                MsgBox("Please select image!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtDESCRIPTION.Text = String.Empty Or txtPRICE.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtCATEGORY.Text = String.Empty Or txtSTATUS.Text = String.Empty Then
                MsgBox("Please select data from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Product ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then
                Dim mstream As New MemoryStream
                PictureBox1.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = mstream.GetBuffer

                cn.Open()
                cm = New MySqlCommand("INSERT into tblproduct (description, price, category, weight, image, status) values(@description, @price, @category, @weight, @image, @status)", cn)
                With cm.Parameters
                    .AddWithValue("@description", txtDESCRIPTION.Text)
                    .AddWithValue("@price", CDbl(txtPRICE.Text))
                    .AddWithValue("@category", txtCATEGORY.Text)
                    .AddWithValue("@weight", txtWEIGHT.Checked.ToString)
                    .AddWithValue("@image", arrImage)
                    .AddWithValue("@status", txtSTATUS.Text)
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Product has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")
                ClearProduct()
                With frmPRODUCTLIST
                    .LoadProductList()
                End With
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Sub LoadCategory()

        txtCATEGORY.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblcategory", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtCATEGORY.Items.Add(dr.Item("category").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtPRICE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPRICE.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtPRICE_TextChanged(sender As Object, e As EventArgs) Handles txtPRICE.TextChanged

    End Sub

    Sub ClearProduct()

        txtDESCRIPTION.Clear()
        txtCODE.Text = ""
        txtPRICE.Clear()
        txtCATEGORY.Items.Clear()
        txtSTATUS.Text = ""
        PictureBox1.BackgroundImage = Nothing
        btnSAVE.Enabled = True
        btnUPDATE.Enabled = False
        txtDESCRIPTION.Focus()

        LoadCategory()

    End Sub


    Private Sub btnRESET_Click(sender As Object, e As EventArgs) Handles btnRESET.Click
        ClearProduct()
    End Sub

    Private Sub txtCATEGORY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCATEGORY.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtCATEGORY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCATEGORY.SelectedIndexChanged
        txtPRODUCTCODE.Text = txtCATEGORY.Text & "." & GetInitials(txtDESCRIPTION.Text)
    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click
        Try

            If txtDESCRIPTION.Text = String.Empty Or txtPRICE.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtCATEGORY.Text = String.Empty Or txtSTATUS.Text = String.Empty Then
                MsgBox("Please select data from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Update this Product ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then
                Dim mstream As New MemoryStream
                PictureBox1.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = mstream.GetBuffer

                cn.Open()
                cm = New MySqlCommand("Update tblproduct set product_code=@product_code, description=@description, price=@price, category=@category, weight=@weight, image=@image, status=@status where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@product_code", txtPRODUCTCODE.Text)
                    .AddWithValue("@description", txtDESCRIPTION.Text)
                    .AddWithValue("@price", CDbl(txtPRICE.Text))
                    .AddWithValue("@category", txtCATEGORY.Text)
                    .AddWithValue("@weight", txtWEIGHT.Checked.ToString)
                    .AddWithValue("@image", arrImage)
                    .AddWithValue("@status", txtSTATUS.Text)
                    .AddWithValue("@id", txtCODE.Text)
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Product has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")
                ClearProduct()
                With frmPRODUCTLIST
                    .LoadProductList()
                End With
                Me.Dispose()
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub frmPRODUCT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Connection()

    End Sub

    Private Sub txtDESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles txtDESCRIPTION.TextChanged

        txtPRODUCTCODE.Text = txtCATEGORY.Text & GetInitials(txtDESCRIPTION.Text) & getNumeric(txtDESCRIPTION.Text)

    End Sub

    Private Sub frmPRODUCT_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

