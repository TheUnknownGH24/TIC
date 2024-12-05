<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPRODUCT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPRODUCT))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPRODUCTCODE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.btnUPDATE = New System.Windows.Forms.Button()
        Me.btnUPLOADIMAGE = New System.Windows.Forms.Button()
        Me.btnRESET = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtWEIGHT = New System.Windows.Forms.CheckBox()
        Me.txtSTATUS = New System.Windows.Forms.ComboBox()
        Me.txtPRICE = New System.Windows.Forms.TextBox()
        Me.txtCATEGORY = New System.Windows.Forms.ComboBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DESCRIPTION"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtPRODUCTCODE)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.txtCODE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnSAVE)
        Me.GroupBox1.Controls.Add(Me.btnUPDATE)
        Me.GroupBox1.Controls.Add(Me.btnUPLOADIMAGE)
        Me.GroupBox1.Controls.Add(Me.btnRESET)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txtWEIGHT)
        Me.GroupBox1.Controls.Add(Me.txtSTATUS)
        Me.GroupBox1.Controls.Add(Me.txtPRICE)
        Me.GroupBox1.Controls.Add(Me.txtCATEGORY)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPTION)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(955, 366)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'txtPRODUCTCODE
        '
        Me.txtPRODUCTCODE.Enabled = False
        Me.txtPRODUCTCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRODUCTCODE.Location = New System.Drawing.Point(153, 64)
        Me.txtPRODUCTCODE.Name = "txtPRODUCTCODE"
        Me.txtPRODUCTCODE.Size = New System.Drawing.Size(532, 31)
        Me.txtPRODUCTCODE.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "CODE"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Red
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(639, 146)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(46, 35)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "+"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'txtCODE
        '
        Me.txtCODE.Enabled = False
        Me.txtCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCODE.Location = New System.Drawing.Point(153, 22)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(532, 31)
        Me.txtCODE.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "ID"
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(301, 292)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(124, 46)
        Me.btnSAVE.TabIndex = 13
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'btnUPDATE
        '
        Me.btnUPDATE.BackColor = System.Drawing.Color.Blue
        Me.btnUPDATE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUPDATE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPDATE.ForeColor = System.Drawing.Color.White
        Me.btnUPDATE.Location = New System.Drawing.Point(431, 292)
        Me.btnUPDATE.Name = "btnUPDATE"
        Me.btnUPDATE.Size = New System.Drawing.Size(124, 46)
        Me.btnUPDATE.TabIndex = 12
        Me.btnUPDATE.Text = "UPDATE"
        Me.btnUPDATE.UseVisualStyleBackColor = False
        '
        'btnUPLOADIMAGE
        '
        Me.btnUPLOADIMAGE.BackColor = System.Drawing.Color.Red
        Me.btnUPLOADIMAGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUPLOADIMAGE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPLOADIMAGE.ForeColor = System.Drawing.Color.White
        Me.btnUPLOADIMAGE.Location = New System.Drawing.Point(701, 250)
        Me.btnUPLOADIMAGE.Name = "btnUPLOADIMAGE"
        Me.btnUPLOADIMAGE.Size = New System.Drawing.Size(240, 46)
        Me.btnUPLOADIMAGE.TabIndex = 14
        Me.btnUPLOADIMAGE.Text = "UPLOAD IMAGE"
        Me.btnUPLOADIMAGE.UseVisualStyleBackColor = False
        '
        'btnRESET
        '
        Me.btnRESET.BackColor = System.Drawing.Color.Yellow
        Me.btnRESET.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRESET.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRESET.ForeColor = System.Drawing.Color.Black
        Me.btnRESET.Location = New System.Drawing.Point(561, 292)
        Me.btnRESET.Name = "btnRESET"
        Me.btnRESET.Size = New System.Drawing.Size(124, 46)
        Me.btnRESET.TabIndex = 1
        Me.btnRESET.Text = "RESET"
        Me.btnRESET.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(701, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(240, 223)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'txtWEIGHT
        '
        Me.txtWEIGHT.AutoSize = True
        Me.txtWEIGHT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWEIGHT.ForeColor = System.Drawing.Color.White
        Me.txtWEIGHT.Location = New System.Drawing.Point(153, 267)
        Me.txtWEIGHT.Name = "txtWEIGHT"
        Me.txtWEIGHT.Size = New System.Drawing.Size(110, 27)
        Me.txtWEIGHT.TabIndex = 10
        Me.txtWEIGHT.Text = "WEIGHT"
        Me.txtWEIGHT.UseVisualStyleBackColor = True
        '
        'txtSTATUS
        '
        Me.txtSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSTATUS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSTATUS.FormattingEnabled = True
        Me.txtSTATUS.Items.AddRange(New Object() {"ACTIVATE", "DEACTIVATE"})
        Me.txtSTATUS.Location = New System.Drawing.Point(153, 230)
        Me.txtSTATUS.Name = "txtSTATUS"
        Me.txtSTATUS.Size = New System.Drawing.Size(532, 31)
        Me.txtSTATUS.TabIndex = 9
        '
        'txtPRICE
        '
        Me.txtPRICE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRICE.Location = New System.Drawing.Point(153, 189)
        Me.txtPRICE.Name = "txtPRICE"
        Me.txtPRICE.Size = New System.Drawing.Size(532, 31)
        Me.txtPRICE.TabIndex = 8
        '
        'txtCATEGORY
        '
        Me.txtCATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCATEGORY.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCATEGORY.FormattingEnabled = True
        Me.txtCATEGORY.Location = New System.Drawing.Point(153, 148)
        Me.txtCATEGORY.Name = "txtCATEGORY"
        Me.txtCATEGORY.Size = New System.Drawing.Size(480, 31)
        Me.txtCATEGORY.TabIndex = 7
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDESCRIPTION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(153, 106)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(532, 31)
        Me.txtDESCRIPTION.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 23)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "STATUS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PRICE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CATEGORY"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DimGray
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(805, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 46)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "CLOSE"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(12, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 63)
        Me.Panel1.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(955, 10)
        Me.Panel2.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(336, 46)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "PRODUCT ENTRY"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmPRODUCT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(978, 447)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPRODUCT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSTATUS As System.Windows.Forms.ComboBox
    Friend WithEvents txtPRICE As System.Windows.Forms.TextBox
    Friend WithEvents txtCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtWEIGHT As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btnUPLOADIMAGE As System.Windows.Forms.Button
    Friend WithEvents btnSAVE As System.Windows.Forms.Button
    Friend WithEvents btnUPDATE As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnRESET As System.Windows.Forms.Button
    Friend WithEvents txtCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtPRODUCTCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
