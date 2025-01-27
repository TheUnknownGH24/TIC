Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmITEM

    Public Function Vowels(ByVal S As String) As String
        Dim X As Long
        For X = 1 To Len(S)
            If Mid(S, X, 1) Like "[!AEIOU]" Then Mid(S, X) = " "
        Next
        Vowels = Replace(S, " ", "")
    End Function


    Public Function Consonants(ByVal S As String) As String
        Dim X As Long
        For X = 1 To Len(S)
            If Mid(S, X, 1) Like "[AEIOU]" Then Mid(S, X) = " "
        Next
        Consonants = Replace(S, " ", "")
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()
                frmPRODUCT.LoadCategory()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtITEMNAME.TextChanged

        'txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text)

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If txtITEMNAME.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtCLASSIFICATION.Text = String.Empty Then
                MsgBox("Please select data from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Product ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("INSERT into tblitem (itemcode, itemname, uom, classification, mother_class, sub_class_1, sub_class_2, sub_class_3) values(@itemcode, @itemname, @uom, @classification, @mother_class, @sub_class_1, @sub_class_2, @sub_class_3)", cn)
                With cm.Parameters
                    .AddWithValue("@itemcode", txtITEMCODE.Text)
                    .AddWithValue("@itemname", txtITEMNAME.Text)
                    .AddWithValue("@classification", txtCLASSIFICATION.Text)
                    .AddWithValue("@mother_class", txtMOTHERCLASS.Text)
                    .AddWithValue("@sub_class_1", txtSUBCLASS_1.Text)

                    If txtSUBCLASS_2.Text = String.Empty Then
                        .AddWithValue("@sub_class_2", " ")
                    Else
                        .AddWithValue("@sub_class_2", txtSUBCLASS_2.Text)
                    End If

                    If txtSUBCLASS_3.Text = String.Empty Then
                        .AddWithValue("@sub_class_3", " ")
                    Else
                        .AddWithValue("@sub_class_3", txtSUBCLASS_3.Text)
                    End If

                    .AddWithValue("@uom", txtUOM.Text)
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Item has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtCOUNT.Text = ""
                txtPLUS.Text = ""
                txtITEMCODE.Text = ""
                txtITEMNAME.Text = ""
                txtCLASSIFICATION.Text = ""
                txtMOTHERCLASS.Text = ""
                txtSUBCLASS_1.Text = ""
                txtSUBCLASS_2.Text = ""
                txtSUBCLASS_3.Text = ""
                txtUOM.Text = ""

                txtCLASSIFICATION.Items.Clear()
                txtMOTHERCLASS.Items.Clear()
                txtUOM.Items.Clear()

                LoadUOM()
                LoadClassification()


            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try


    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        Try

            If txtITEMNAME.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtCLASSIFICATION.Text = String.Empty Then
                MsgBox("Please select data from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Update this Item ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tblitem set itemcode=@itemcode, itemname=@itemname, uom=@uom, stock_on_hand=@stock_on_hand where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@itemcode", txtITEMCODE.Text)
                    .AddWithValue("@itemname", txtITEMNAME.Text)
                    .AddWithValue("@uom", txtCLASSIFICATION.Text)

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Product has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")
                With frmITEMLIST
                    .LoadITEMList()
                End With
                Me.Dispose()
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub txtSTOCK_KeyPress(sender As Object, e As KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub txtMOTHERCLASS_TextChanged(sender As Object, e As EventArgs)

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Vowels(txtMOTHERCLASS.Text) & txtCOUNT.Text + 1

    End Sub

    Private Sub txtSUBCLASS_1_TextChanged(sender As Object, e As EventArgs) Handles txtSUBCLASS_1.TextChanged

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text

    End Sub

    Private Sub txtSUBCLASS_2_TextChanged(sender As Object, e As EventArgs) Handles txtSUBCLASS_2.TextChanged

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text

    End Sub

    Private Sub txtSUBCLASS_3_TextChanged(sender As Object, e As EventArgs) Handles txtSUBCLASS_3.TextChanged

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text

    End Sub

    Sub LoadClassification()

        txtCLASSIFICATION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblclassification", cn)
        dr = cm.ExecuteReader
        While dr.Read


            txtCLASSIFICATION.Items.Add(dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadUOM()

        txtUOM.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbluom", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtUOM.Items.Add(dr.Item("uom").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadGENERICNAME()

        txtMOTHERCLASS.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblmotherclass where `classification` like '%" & txtCLASSIFICATION.Text & "%' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtMOTHERCLASS.Items.Add(dr.Item("generic_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadClassification()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        LoadUOM()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmCLASSIFICATION

            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmUOM

            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

        End With

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If txtCLASSIFICATION.Text = String.Empty Then

            Exit Sub

        Else

            LoadGENERICNAME()

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmGENERICNAME

            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

        End With

    End Sub

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


    Private Sub txtCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCLASSIFICATION.SelectedIndexChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text

        LoadGENERICNAME()

    End Sub

    Sub loadCOUNT()

        txtCOUNT.Clear()

        cn.Open()
        Using cm = New MySqlCommand("select count(mother_class) from tblitem where `mother_class` like '%" & txtMOTHERCLASS.Text & "%'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCOUNT.Text = String.Format("{0}", count)

            sum = txtCOUNT.Text + 1

            txtPLUS.Text = Format(sum, "000")

        End Using
        cn.Close()

    End Sub

    Private Sub txtMOTHERCLASS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtMOTHERCLASS.SelectedIndexChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

        loadCOUNT()

    End Sub

    Private Sub txtPLUS_TextChanged(sender As Object, e As EventArgs) Handles txtPLUS.TextChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

    End Sub

    Private Sub txtCOUNT_TextChanged(sender As Object, e As EventArgs) Handles txtCOUNT.TextChanged

    End Sub


    Private Sub txtITEMCODE_TextChanged(sender As Object, e As EventArgs) Handles txtITEMCODE.TextChanged

    End Sub

    Private Sub frmITEM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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