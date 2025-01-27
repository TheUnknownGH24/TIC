Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmITEMLIST

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


    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where itemname like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString, dr.Item("mother_class").ToString, dr.Item("sub_class_1").ToString, dr.Item("sub_class_2").ToString, dr.Item("sub_class_3").ToString)

        End While

        dr.Close()
        cn.Close()


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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmITEM
            .StartPosition = FormStartPosition.CenterScreen
            .btnUPDATE.Enabled = False
            .btnUPDATE.Visible = False
            .ShowDialog()
        End With

    End Sub

    Sub LoadITEMList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblitem", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString, dr.Item("mother_class").ToString, dr.Item("sub_class_1").ToString, dr.Item("sub_class_2").ToString, dr.Item("sub_class_3").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadITEMList()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        LoadClassification()
        LoadUOM()
        LoadGENERICNAME()

        If colname = "colUPDATE" Then
            cn.Open()
            cm = New MySqlCommand("select * from tblitem where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtITEMCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtITEMNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtUOM.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtCLASSIFICATION.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                txtMOTHERCLASS.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                txtSUBCLASS_1.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                txtSUBCLASS_2.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                txtSUBCLASS_3.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString

                txtITEMCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnUPDATE.Enabled = True

        End If
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
                cm = New MySqlCommand("Update tblitem set itemcode=@itemcode, itemname=@itemname, uom=@uom, classification=@classification, mother_class=@mother_class, sub_class_1=@sub_class_1, sub_class_2=@sub_class_2, sub_class_3=@sub_class_3 where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
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
                MsgBox("Product has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

                LoadITEMList()

                btnUPDATE.Enabled = False
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try


    End Sub

    Private Sub txtMOTHERCLASS_Leave(sender As Object, e As EventArgs) Handles txtMOTHERCLASS.Leave

        loadCOUNT()

    End Sub

    Private Sub txtMOTHERCLASS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtMOTHERCLASS.SelectedIndexChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

    End Sub

    Private Sub txtSUBCLASS_1_TextChanged(sender As Object, e As EventArgs) Handles txtSUBCLASS_1.TextChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text


    End Sub

    Private Sub txtCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCLASSIFICATION.SelectedIndexChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text

        'LoadGENERICNAME()

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

    Private Sub txtITEMNAME_TextChanged(sender As Object, e As EventArgs) Handles txtITEMNAME.TextChanged

    End Sub

    Private Sub txtSUBCLASS_2_TextChanged(sender As Object, e As EventArgs) Handles txtSUBCLASS_2.TextChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text


    End Sub

    Private Sub txtSUBCLASS_3_TextChanged(sender As Object, e As EventArgs) Handles txtSUBCLASS_3.TextChanged

        txtITEMCODE.Text = GetInitials(txtCLASSIFICATION.Text) & Consonants(txtMOTHERCLASS.Text) & txtPLUS.Text

        txtITEMNAME.Text = txtMOTHERCLASS.Text & " " & txtSUBCLASS_1.Text & " " & txtSUBCLASS_2.Text & " " & txtSUBCLASS_3.Text


    End Sub

    Private Sub frmITEMLIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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