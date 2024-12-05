<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmITEM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmITEM))
        Me.txtITEMCODE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPLUS = New System.Windows.Forms.TextBox()
        Me.txtCOUNT = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.txtMOTHERCLASS = New System.Windows.Forms.ComboBox()
        Me.txtUOM = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtSUBCLASS_3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSUBCLASS_2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSUBCLASS_1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnUPDATE = New System.Windows.Forms.Button()
        Me.txtCLASSIFICATION = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtITEMCODE
        '
        Me.txtITEMCODE.BackColor = System.Drawing.Color.Silver
        Me.txtITEMCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtITEMCODE.Enabled = False
        Me.txtITEMCODE.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtITEMCODE.Location = New System.Drawing.Point(265, 21)
        Me.txtITEMCODE.Name = "txtITEMCODE"
        Me.txtITEMCODE.Size = New System.Drawing.Size(628, 27)
        Me.txtITEMCODE.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(220, 46)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ITEM DATA"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.txtPLUS)
        Me.Panel1.Controls.Add(Me.txtCOUNT)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Location = New System.Drawing.Point(11, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(899, 62)
        Me.Panel1.TabIndex = 25
        '
        'txtPLUS
        '
        Me.txtPLUS.BackColor = System.Drawing.Color.Silver
        Me.txtPLUS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPLUS.Enabled = False
        Me.txtPLUS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPLUS.Location = New System.Drawing.Point(496, 21)
        Me.txtPLUS.Name = "txtPLUS"
        Me.txtPLUS.Size = New System.Drawing.Size(68, 31)
        Me.txtPLUS.TabIndex = 25
        Me.txtPLUS.Visible = False
        '
        'txtCOUNT
        '
        Me.txtCOUNT.BackColor = System.Drawing.Color.Silver
        Me.txtCOUNT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCOUNT.Enabled = False
        Me.txtCOUNT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOUNT.Location = New System.Drawing.Point(422, 21)
        Me.txtCOUNT.Name = "txtCOUNT"
        Me.txtCOUNT.Size = New System.Drawing.Size(68, 31)
        Me.txtCOUNT.TabIndex = 24
        Me.txtCOUNT.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(899, 10)
        Me.Panel2.TabIndex = 21
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DimGray
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(769, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 46)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "CLOSE"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.Silver
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Enabled = False
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(364, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(52, 31)
        Me.txtID.TabIndex = 23
        Me.txtID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ITEM CODE"
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(769, 343)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(124, 49)
        Me.btnSAVE.TabIndex = 13
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.txtMOTHERCLASS)
        Me.GroupBox1.Controls.Add(Me.txtUOM)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtSUBCLASS_3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtSUBCLASS_2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSUBCLASS_1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnUPDATE)
        Me.GroupBox1.Controls.Add(Me.txtCLASSIFICATION)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtITEMNAME)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtITEMCODE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSAVE)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gray
        Me.GroupBox1.Location = New System.Drawing.Point(11, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(899, 406)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Red
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(829, 141)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(64, 31)
        Me.Button6.TabIndex = 44
        Me.Button6.Text = "+"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Yellow
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(695, 141)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(128, 31)
        Me.Button7.TabIndex = 43
        Me.Button7.Text = "REFRESH"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'txtMOTHERCLASS
        '
        Me.txtMOTHERCLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMOTHERCLASS.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOTHERCLASS.FormattingEnabled = True
        Me.txtMOTHERCLASS.Location = New System.Drawing.Point(265, 141)
        Me.txtMOTHERCLASS.Name = "txtMOTHERCLASS"
        Me.txtMOTHERCLASS.Size = New System.Drawing.Size(424, 28)
        Me.txtMOTHERCLASS.TabIndex = 42
        '
        'txtUOM
        '
        Me.txtUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtUOM.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOM.FormattingEnabled = True
        Me.txtUOM.Location = New System.Drawing.Point(265, 301)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.Size = New System.Drawing.Size(424, 28)
        Me.txtUOM.TabIndex = 41
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(829, 301)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(64, 31)
        Me.Button4.TabIndex = 40
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Red
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(829, 101)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(64, 31)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "+"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Yellow
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(695, 301)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 31)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "REFRESH"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Yellow
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(695, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 31)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "REFRESH"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtSUBCLASS_3
        '
        Me.txtSUBCLASS_3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUBCLASS_3.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUBCLASS_3.Location = New System.Drawing.Point(265, 261)
        Me.txtSUBCLASS_3.Name = "txtSUBCLASS_3"
        Me.txtSUBCLASS_3.Size = New System.Drawing.Size(628, 27)
        Me.txtSUBCLASS_3.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(10, 264)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(239, 23)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "SIZE/MEASURE/WEIGHT"
        '
        'txtSUBCLASS_2
        '
        Me.txtSUBCLASS_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUBCLASS_2.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUBCLASS_2.Location = New System.Drawing.Point(265, 221)
        Me.txtSUBCLASS_2.Name = "txtSUBCLASS_2"
        Me.txtSUBCLASS_2.Size = New System.Drawing.Size(628, 27)
        Me.txtSUBCLASS_2.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(10, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(175, 23)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "COLOR / VARIANT"
        '
        'txtSUBCLASS_1
        '
        Me.txtSUBCLASS_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUBCLASS_1.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUBCLASS_1.Location = New System.Drawing.Point(265, 181)
        Me.txtSUBCLASS_1.Name = "txtSUBCLASS_1"
        Me.txtSUBCLASS_1.Size = New System.Drawing.Size(628, 27)
        Me.txtSUBCLASS_1.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(10, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 23)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "BRAND"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 23)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "GENERIC NAME"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 23)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "CLASSIFICATION"
        '
        'btnUPDATE
        '
        Me.btnUPDATE.BackColor = System.Drawing.Color.Blue
        Me.btnUPDATE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUPDATE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPDATE.ForeColor = System.Drawing.Color.White
        Me.btnUPDATE.Location = New System.Drawing.Point(12, 343)
        Me.btnUPDATE.Name = "btnUPDATE"
        Me.btnUPDATE.Size = New System.Drawing.Size(124, 49)
        Me.btnUPDATE.TabIndex = 21
        Me.btnUPDATE.Text = "UPDATE"
        Me.btnUPDATE.UseVisualStyleBackColor = False
        '
        'txtCLASSIFICATION
        '
        Me.txtCLASSIFICATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCLASSIFICATION.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCLASSIFICATION.FormattingEnabled = True
        Me.txtCLASSIFICATION.Location = New System.Drawing.Point(265, 101)
        Me.txtCLASSIFICATION.Name = "txtCLASSIFICATION"
        Me.txtCLASSIFICATION.Size = New System.Drawing.Size(424, 28)
        Me.txtCLASSIFICATION.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 23)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "UOM"
        '
        'txtITEMNAME
        '
        Me.txtITEMNAME.BackColor = System.Drawing.Color.Silver
        Me.txtITEMNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtITEMNAME.Enabled = False
        Me.txtITEMNAME.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtITEMNAME.Location = New System.Drawing.Point(265, 61)
        Me.txtITEMNAME.Name = "txtITEMNAME"
        Me.txtITEMNAME.Size = New System.Drawing.Size(628, 27)
        Me.txtITEMNAME.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 23)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "ITEM NAME"
        '
        'frmITEM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(922, 490)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmITEM"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtITEMCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSAVE As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtITEMNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUPDATE As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCLASSIFICATION As System.Windows.Forms.ComboBox
    Friend WithEvents txtSUBCLASS_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSUBCLASS_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSUBCLASS_3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents txtMOTHERCLASS As System.Windows.Forms.ComboBox
    Friend WithEvents txtCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents txtPLUS As System.Windows.Forms.TextBox
End Class
