Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmPOS
    Dim btnHOMECATEGORY As New Button
    Dim pic As New PictureBox
    Dim lblDesc As New Label
    Dim lblPrice As New Label

    Dim _filter As String = ""

    Private Sub button7_Click(sender As Object, e As EventArgs) Handles button7.Click
        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub frmSI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Connection()
        loadHomeCategory()
        loadMenu()

    End Sub

    Private Sub btnMANAGEPRODUCT_Click(sender As Object, e As EventArgs) Handles btnMANAGEPRODUCT.Click
        With frmPRODUCTLIST
            .LoadProductList()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnMANAGETABLE_Click(sender As Object, e As EventArgs) Handles btnMANAGETABLE.Click
    End Sub

    Sub loadHomeCategory()

        cn.Open()
        cm = New MySqlCommand("Select * from tblcategory", cn)
        dr = cm.ExecuteReader
        While dr.Read

            btnHOMECATEGORY = New Button
            btnHOMECATEGORY.Width = 104
            btnHOMECATEGORY.Height = 35
            btnHOMECATEGORY.Text = dr.Item("category").ToString
            btnHOMECATEGORY.FlatStyle = FlatStyle.Popup
            btnHOMECATEGORY.BackColor = Color.FromArgb(75, 207, 250)
            btnHOMECATEGORY.ForeColor = Color.Black
            btnHOMECATEGORY.Font = New Font("Cambria", 12, FontStyle.Bold)
            btnHOMECATEGORY.Cursor = Cursors.Hand
            btnHOMECATEGORY.TextAlign = ContentAlignment.MiddleLeft
            flowLayoutPanel1.Controls.Add(btnHOMECATEGORY)

            AddHandler btnHOMECATEGORY.Click, AddressOf filter_Click

        End While
        cn.Close()

    End Sub

    Public Sub filter_Click(sender As Object, e As EventArgs)

        _filter = sender.text.ToString

        loadMenu()

    End Sub

    Sub loadMenu()
        FlowLayoutPanel2.AutoScroll = True
        FlowLayoutPanel2.Controls.Clear()

        cn.Open()
        cm = New MySqlCommand("select image, id, product_code, description, price, weight, status from tblproduct where category like '" & _filter & "%' order by description", cn)
        dr = cm.ExecuteReader
        While dr.Read

            Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte
            dr.GetBytes(0, 0, array, 0, CInt(len))
            pic = New PictureBox
            pic.Width = 120
            pic.Height = 120
            pic.BackgroundImageLayout = ImageLayout.Stretch

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)
            pic.BackgroundImage = bitmap
            pic.Tag = dr.Item("id").ToString

            lblDesc = New Label
            lblDesc.BackColor = Color.FromArgb(55, 176, 213)
            lblDesc.ForeColor = Color.White
            lblDesc.Text = dr.Item("description").ToString
            lblDesc.Font = New Font("Cambria", 8, FontStyle.Bold)
            lblDesc.TextAlign = ContentAlignment.MiddleCenter
            lblDesc.Dock = DockStyle.Top
            lblDesc.Cursor = Cursors.Hand
            lblDesc.Tag = dr.Item("id").ToString

            lblPrice = New Label
            lblPrice.BackColor = Color.FromArgb(255, 94, 87)
            lblPrice.ForeColor = Color.White
            lblPrice.Text = dr.Item("price").ToString
            lblPrice.Font = New Font("Cambria", 8, FontStyle.Bold)
            lblPrice.TextAlign = ContentAlignment.MiddleCenter
            lblPrice.Dock = DockStyle.Bottom
            lblPrice.Cursor = Cursors.Hand
            lblPrice.AutoSize = True
            lblPrice.Tag = dr.Item("id").ToString

            pic.Controls.Add(lblDesc)
            pic.Controls.Add(lblPrice)
            FlowLayoutPanel2.Controls.Add(pic)
            AddHandler pic.Click, AddressOf select_click
            AddHandler lblDesc.Click, AddressOf select_click
            AddHandler lblPrice.Click, AddressOf select_click

        End While

        cn.Close()

    End Sub

    Public Sub select_click(sender As Object, e As EventArgs)

        If txtSOLDTO.Text = String.Empty Or txtPLATFORMS.Text = String.Empty Or txtSO_NO.Text = String.Empty Then
            MsgBox("Please input data of buyer!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        Try
            Dim price As Double
            Dim weight As Boolean
            Dim id As String = sender.tag.ToString()
            cn.Open()
            cm = New MySqlCommand("select * from tblproduct where id like '" & id & "'", cn)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                price = dr.Item("price").ToString
                weight = CBool(dr.Item("weight").ToString)

            End If
            dr.Close()
            cn.Close()

            With frmQTY
                .AddtoCart(id, price, weight)
                .txtPLATFORMS.Text = Me.txtPLATFORMS.Text
                .txtTRANSDATE.Text = Me.txtTRANSDATE.Text
                .txtSOLDTO.Text = Me.txtSOLDTO.Text
                .txtADDRESS.Text = Me.txtADDRESS.Text
                .txtTERMS.Text = Me.txtTERMS.Text
                .txtSO_NO.Text = Me.txtSO_NO.Text

                .Show()

            End With


        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub

    Private Sub FlowLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel2.Paint

    End Sub
End Class