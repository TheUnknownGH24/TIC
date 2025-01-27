<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMANAGER_PO_APPROVAL
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMANAGER_PO_APPROVAL))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTRANSACTION = New System.Windows.Forms.Label()
        Me.txtSUPPLIER_3 = New System.Windows.Forms.RadioButton()
        Me.txtSUPPLIER_2 = New System.Windows.Forms.RadioButton()
        Me.txtSUPPLIER_1 = New System.Windows.Forms.RadioButton()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtCONTROL = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSEARCHNAME = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.txtSUPPLIER = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPONO = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtREFERENCE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtDELIVERYADDRESS = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIT_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VAT_AMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtVATTOTAL_1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtGRANDTOTAL_1 = New System.Windows.Forms.TextBox()
        Me.txtTOTALUNIT_1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtREMARKS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtPAYMENTTERMS = New System.Windows.Forms.TextBox()
        Me.txtDATE = New System.Windows.Forms.DateTimePicker()
        Me.txtSHIPPINGMETHOD = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtREQUIREDDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTRANSACTION)
        Me.GroupBox1.Controls.Add(Me.txtSUPPLIER_3)
        Me.GroupBox1.Controls.Add(Me.txtSUPPLIER_2)
        Me.GroupBox1.Controls.Add(Me.txtSUPPLIER_1)
        Me.GroupBox1.Controls.Add(Me.label4)
        Me.GroupBox1.Controls.Add(Me.txtCONTROL)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 197)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        '
        'txtTRANSACTION
        '
        Me.txtTRANSACTION.AutoSize = True
        Me.txtTRANSACTION.Font = New System.Drawing.Font("Arial Black", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRANSACTION.ForeColor = System.Drawing.Color.Red
        Me.txtTRANSACTION.Location = New System.Drawing.Point(318, 25)
        Me.txtTRANSACTION.Name = "txtTRANSACTION"
        Me.txtTRANSACTION.Size = New System.Drawing.Size(207, 33)
        Me.txtTRANSACTION.TabIndex = 122
        Me.txtTRANSACTION.Text = "------------------------"
        '
        'txtSUPPLIER_3
        '
        Me.txtSUPPLIER_3.AutoSize = True
        Me.txtSUPPLIER_3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUPPLIER_3.ForeColor = System.Drawing.Color.Yellow
        Me.txtSUPPLIER_3.Location = New System.Drawing.Point(18, 141)
        Me.txtSUPPLIER_3.Name = "txtSUPPLIER_3"
        Me.txtSUPPLIER_3.Size = New System.Drawing.Size(523, 32)
        Me.txtSUPPLIER_3.TabIndex = 121
        Me.txtSUPPLIER_3.TabStop = True
        Me.txtSUPPLIER_3.Text = "----------------------------------------------------------------------"
        Me.txtSUPPLIER_3.UseVisualStyleBackColor = True
        '
        'txtSUPPLIER_2
        '
        Me.txtSUPPLIER_2.AutoSize = True
        Me.txtSUPPLIER_2.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUPPLIER_2.ForeColor = System.Drawing.Color.Yellow
        Me.txtSUPPLIER_2.Location = New System.Drawing.Point(18, 98)
        Me.txtSUPPLIER_2.Name = "txtSUPPLIER_2"
        Me.txtSUPPLIER_2.Size = New System.Drawing.Size(523, 32)
        Me.txtSUPPLIER_2.TabIndex = 120
        Me.txtSUPPLIER_2.TabStop = True
        Me.txtSUPPLIER_2.Text = "----------------------------------------------------------------------"
        Me.txtSUPPLIER_2.UseVisualStyleBackColor = True
        '
        'txtSUPPLIER_1
        '
        Me.txtSUPPLIER_1.AutoSize = True
        Me.txtSUPPLIER_1.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUPPLIER_1.ForeColor = System.Drawing.Color.Yellow
        Me.txtSUPPLIER_1.Location = New System.Drawing.Point(18, 58)
        Me.txtSUPPLIER_1.Name = "txtSUPPLIER_1"
        Me.txtSUPPLIER_1.Size = New System.Drawing.Size(523, 32)
        Me.txtSUPPLIER_1.TabIndex = 119
        Me.txtSUPPLIER_1.TabStop = True
        Me.txtSUPPLIER_1.Text = "----------------------------------------------------------------------"
        Me.txtSUPPLIER_1.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Arial Black", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Yellow
        Me.label4.Location = New System.Drawing.Point(12, 20)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(67, 33)
        Me.label4.TabIndex = 117
        Me.label4.Text = "PR#"
        '
        'txtCONTROL
        '
        Me.txtCONTROL.Enabled = False
        Me.txtCONTROL.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTROL.Location = New System.Drawing.Point(85, 23)
        Me.txtCONTROL.Name = "txtCONTROL"
        Me.txtCONTROL.Size = New System.Drawing.Size(227, 31)
        Me.txtCONTROL.TabIndex = 118
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtSEARCHNAME)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox4.Location = New System.Drawing.Point(6, 346)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(640, 70)
        Me.GroupBox4.TabIndex = 131
        Me.GroupBox4.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "SEARCH ITEM"
        '
        'txtSEARCHNAME
        '
        Me.txtSEARCHNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSEARCHNAME.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSEARCHNAME.Location = New System.Drawing.Point(169, 25)
        Me.txtSEARCHNAME.Name = "txtSEARCHNAME"
        Me.txtSEARCHNAME.Size = New System.Drawing.Size(454, 31)
        Me.txtSEARCHNAME.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(771, 13)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(123, 24)
        Me.Label22.TabIndex = 93
        Me.Label22.Text = "TOTAL UNIT"
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(1166, 88)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(259, 120)
        Me.btnSAVE.TabIndex = 121
        Me.btnSAVE.Text = "APPROVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'txtSUPPLIER
        '
        Me.txtSUPPLIER.Enabled = False
        Me.txtSUPPLIER.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUPPLIER.Location = New System.Drawing.Point(204, 40)
        Me.txtSUPPLIER.Name = "txtSUPPLIER"
        Me.txtSUPPLIER.Size = New System.Drawing.Size(562, 31)
        Me.txtSUPPLIER.TabIndex = 130
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(13, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1436, 63)
        Me.Panel1.TabIndex = 148
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(764, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(227, 31)
        Me.txtID.TabIndex = 122
        Me.txtID.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DimGray
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(1301, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 46)
        Me.Button5.TabIndex = 121
        Me.Button5.Text = "CLOSE"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(1012, 21)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(283, 31)
        Me.DateTimePicker1.TabIndex = 120
        Me.DateTimePicker1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1436, 10)
        Me.Panel2.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(4, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(476, 46)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "MANAGER PO APPROVAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Black", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(1160, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 33)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "PO#"
        '
        'txtPONO
        '
        Me.txtPONO.Enabled = False
        Me.txtPONO.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONO.Location = New System.Drawing.Point(1166, 51)
        Me.txtPONO.Name = "txtPONO"
        Me.txtPONO.Size = New System.Drawing.Size(259, 31)
        Me.txtPONO.TabIndex = 146
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.DimGray
        Me.GroupBox6.Controls.Add(Me.txtREFERENCE)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.GroupBox5)
        Me.GroupBox6.Controls.Add(Me.dataGridView1)
        Me.GroupBox6.Controls.Add(Me.GroupBox4)
        Me.GroupBox6.Controls.Add(Me.txtSUPPLIER)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.txtVATTOTAL_1)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.txtGRANDTOTAL_1)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.txtTOTALUNIT_1)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 277)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1413, 431)
        Me.GroupBox6.TabIndex = 144
        Me.GroupBox6.TabStop = False
        '
        'txtREFERENCE
        '
        Me.txtREFERENCE.Enabled = False
        Me.txtREFERENCE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREFERENCE.Location = New System.Drawing.Point(6, 40)
        Me.txtREFERENCE.Name = "txtREFERENCE"
        Me.txtREFERENCE.Size = New System.Drawing.Size(192, 31)
        Me.txtREFERENCE.TabIndex = 141
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(2, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 24)
        Me.Label10.TabIndex = 140
        Me.Label10.Text = "PR#"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Yellow
        Me.GroupBox5.Controls.Add(Me.txtDELIVERYADDRESS)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox5.ForeColor = System.Drawing.Color.Gray
        Me.GroupBox5.Location = New System.Drawing.Point(652, 346)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(755, 70)
        Me.GroupBox5.TabIndex = 139
        Me.GroupBox5.TabStop = False
        '
        'txtDELIVERYADDRESS
        '
        Me.txtDELIVERYADDRESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDELIVERYADDRESS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDELIVERYADDRESS.ForeColor = System.Drawing.Color.Black
        Me.txtDELIVERYADDRESS.FormattingEnabled = True
        Me.txtDELIVERYADDRESS.Items.AddRange(New Object() {"WAREHOUSE", "HEAD OFFICE ", "BTTC"})
        Me.txtDELIVERYADDRESS.Location = New System.Drawing.Point(235, 21)
        Me.txtDELIVERYADDRESS.Name = "txtDELIVERYADDRESS"
        Me.txtDELIVERYADDRESS.Size = New System.Drawing.Size(514, 31)
        Me.txtDELIVERYADDRESS.TabIndex = 138
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 24)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "DELIVERY ADDRESS"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeColumns = False
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridView1.ColumnHeadersHeight = 30
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.QUANTITY, Me.UNIT, Me.ITEM_NAME, Me.UNIT_PRICE, Me.VAT_AMOUNT, Me.TOTAL_PRICE})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dataGridView1.EnableHeadersVisualStyles = False
        Me.dataGridView1.Location = New System.Drawing.Point(6, 77)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Aqua
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(1401, 263)
        Me.dataGridView1.TabIndex = 132
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "ID"
        Me.Column7.Name = "Column7"
        Me.Column7.Visible = False
        Me.Column7.Width = 48
        '
        'QUANTITY
        '
        Me.QUANTITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.QUANTITY.HeaderText = "QUANTITY"
        Me.QUANTITY.Name = "QUANTITY"
        Me.QUANTITY.Width = 101
        '
        'UNIT
        '
        Me.UNIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UNIT.HeaderText = "UNIT"
        Me.UNIT.Name = "UNIT"
        Me.UNIT.Width = 66
        '
        'ITEM_NAME
        '
        Me.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ITEM_NAME.HeaderText = "ITEM_NAME"
        Me.ITEM_NAME.Name = "ITEM_NAME"
        '
        'UNIT_PRICE
        '
        Me.UNIT_PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UNIT_PRICE.HeaderText = "UNIT_PRICE"
        Me.UNIT_PRICE.Name = "UNIT_PRICE"
        Me.UNIT_PRICE.Width = 110
        '
        'VAT_AMOUNT
        '
        Me.VAT_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VAT_AMOUNT.HeaderText = "VAT_AMOUNT"
        Me.VAT_AMOUNT.Name = "VAT_AMOUNT"
        Me.VAT_AMOUNT.Width = 122
        '
        'TOTAL_PRICE
        '
        Me.TOTAL_PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TOTAL_PRICE.HeaderText = "GRAND_TOTAL"
        Me.TOTAL_PRICE.Name = "TOTAL_PRICE"
        Me.TOTAL_PRICE.Width = 128
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(200, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 24)
        Me.Label13.TabIndex = 100
        Me.Label13.Text = "SUPPLIER NAME"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(981, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 24)
        Me.Label21.TabIndex = 99
        Me.Label21.Text = "TOTAL VAT"
        '
        'txtVATTOTAL_1
        '
        Me.txtVATTOTAL_1.Enabled = False
        Me.txtVATTOTAL_1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVATTOTAL_1.Location = New System.Drawing.Point(985, 40)
        Me.txtVATTOTAL_1.Name = "txtVATTOTAL_1"
        Me.txtVATTOTAL_1.Size = New System.Drawing.Size(208, 31)
        Me.txtVATTOTAL_1.TabIndex = 98
        Me.txtVATTOTAL_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(1195, 13)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(143, 24)
        Me.Label20.TabIndex = 96
        Me.Label20.Text = "GRAND TOTAL"
        '
        'txtGRANDTOTAL_1
        '
        Me.txtGRANDTOTAL_1.Enabled = False
        Me.txtGRANDTOTAL_1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGRANDTOTAL_1.Location = New System.Drawing.Point(1199, 40)
        Me.txtGRANDTOTAL_1.Name = "txtGRANDTOTAL_1"
        Me.txtGRANDTOTAL_1.Size = New System.Drawing.Size(208, 31)
        Me.txtGRANDTOTAL_1.TabIndex = 97
        Me.txtGRANDTOTAL_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTOTALUNIT_1
        '
        Me.txtTOTALUNIT_1.Enabled = False
        Me.txtTOTALUNIT_1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTALUNIT_1.Location = New System.Drawing.Point(771, 40)
        Me.txtTOTALUNIT_1.Name = "txtTOTALUNIT_1"
        Me.txtTOTALUNIT_1.Size = New System.Drawing.Size(208, 31)
        Me.txtTOTALUNIT_1.TabIndex = 94
        Me.txtTOTALUNIT_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtPONO)
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.btnSAVE)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1436, 714)
        Me.GroupBox2.TabIndex = 147
        Me.GroupBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Yellow
        Me.Panel3.Controls.Add(Me.txtREMARKS)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(13, 216)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1412, 51)
        Me.Panel3.TabIndex = 147
        '
        'txtREMARKS
        '
        Me.txtREMARKS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMARKS.Location = New System.Drawing.Point(122, 11)
        Me.txtREMARKS.Name = "txtREMARKS"
        Me.txtREMARKS.Size = New System.Drawing.Size(1278, 31)
        Me.txtREMARKS.TabIndex = 132
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(13, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 24)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = "REMARKS"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPAYMENTTERMS)
        Me.GroupBox3.Controls.Add(Me.txtDATE)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPINGMETHOD)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtREQUIREDDATE)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(578, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(582, 197)
        Me.GroupBox3.TabIndex = 143
        Me.GroupBox3.TabStop = False
        '
        'txtPAYMENTTERMS
        '
        Me.txtPAYMENTTERMS.Enabled = False
        Me.txtPAYMENTTERMS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAYMENTTERMS.Location = New System.Drawing.Point(204, 100)
        Me.txtPAYMENTTERMS.Name = "txtPAYMENTTERMS"
        Me.txtPAYMENTTERMS.Size = New System.Drawing.Size(360, 31)
        Me.txtPAYMENTTERMS.TabIndex = 142
        '
        'txtDATE
        '
        Me.txtDATE.Enabled = False
        Me.txtDATE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATE.Location = New System.Drawing.Point(204, 20)
        Me.txtDATE.Name = "txtDATE"
        Me.txtDATE.Size = New System.Drawing.Size(360, 31)
        Me.txtDATE.TabIndex = 134
        '
        'txtSHIPPINGMETHOD
        '
        Me.txtSHIPPINGMETHOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSHIPPINGMETHOD.Enabled = False
        Me.txtSHIPPINGMETHOD.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSHIPPINGMETHOD.FormattingEnabled = True
        Me.txtSHIPPINGMETHOD.Items.AddRange(New Object() {"PICK - UP", "DELIVERY", "COD"})
        Me.txtSHIPPINGMETHOD.Location = New System.Drawing.Point(204, 60)
        Me.txtSHIPPINGMETHOD.Name = "txtSHIPPINGMETHOD"
        Me.txtSHIPPINGMETHOD.Size = New System.Drawing.Size(360, 31)
        Me.txtSHIPPINGMETHOD.TabIndex = 136
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(11, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 24)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "DATE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 24)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "SHIPPING METHOD"
        '
        'txtREQUIREDDATE
        '
        Me.txtREQUIREDDATE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREQUIREDDATE.Location = New System.Drawing.Point(204, 142)
        Me.txtREQUIREDDATE.Name = "txtREQUIREDDATE"
        Me.txtREQUIREDDATE.Size = New System.Drawing.Size(360, 31)
        Me.txtREQUIREDDATE.TabIndex = 134
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 24)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "REQUIRED DATE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 24)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "PAYMENT TERMS"
        '
        'frmMANAGER_PO_APPROVAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1461, 797)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMANAGER_PO_APPROVAL"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtTRANSACTION As System.Windows.Forms.Label
    Public WithEvents txtSUPPLIER_3 As System.Windows.Forms.RadioButton
    Public WithEvents txtSUPPLIER_2 As System.Windows.Forms.RadioButton
    Public WithEvents txtSUPPLIER_1 As System.Windows.Forms.RadioButton
    Public WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents txtCONTROL As System.Windows.Forms.TextBox
    Public WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txtSEARCHNAME As System.Windows.Forms.TextBox
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents btnSAVE As System.Windows.Forms.Button
    Public WithEvents txtSUPPLIER As System.Windows.Forms.TextBox
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents Button5 As System.Windows.Forms.Button
    Public WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtPONO As System.Windows.Forms.TextBox
    Public WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Public WithEvents txtREFERENCE As System.Windows.Forms.TextBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents txtDELIVERYADDRESS As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents UNIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents ITEM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents UNIT_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents VAT_AMOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents TOTAL_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents txtVATTOTAL_1 As System.Windows.Forms.TextBox
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents txtGRANDTOTAL_1 As System.Windows.Forms.TextBox
    Public WithEvents txtTOTALUNIT_1 As System.Windows.Forms.TextBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents txtDATE As System.Windows.Forms.DateTimePicker
    Public WithEvents txtSHIPPINGMETHOD As System.Windows.Forms.ComboBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtREQUIREDDATE As System.Windows.Forms.DateTimePicker
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Public WithEvents txtREMARKS As System.Windows.Forms.TextBox
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents txtPAYMENTTERMS As System.Windows.Forms.TextBox
End Class
