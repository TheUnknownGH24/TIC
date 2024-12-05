<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm8SI_CASHADVANCE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm8SI_CASHADVANCE))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtDATE = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTOTALAMOUNT = New System.Windows.Forms.TextBox()
        Me.btnPRINT = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.button3 = New System.Windows.Forms.Button()
        Me.txtAMOUNT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEXPENSECATEGORIES = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDEPARTMENT = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDEPCODE = New System.Windows.Forms.TextBox()
        Me.txtPURPOSE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDATENEEDED = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEMPLOYEE = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCONTROL = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtTRANSACTION = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.EXPENSE_CATEGORIES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EDIT = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.UPDATE = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DELETE = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox6.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDATE
        '
        Me.txtDATE.Enabled = False
        Me.txtDATE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATE.Location = New System.Drawing.Point(175, 21)
        Me.txtDATE.Name = "txtDATE"
        Me.txtDATE.Size = New System.Drawing.Size(299, 31)
        Me.txtDATE.TabIndex = 119
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.txtTOTALAMOUNT)
        Me.GroupBox6.Location = New System.Drawing.Point(858, 215)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(276, 95)
        Me.GroupBox6.TabIndex = 158
        Me.GroupBox6.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(3, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(159, 24)
        Me.Label22.TabIndex = 93
        Me.Label22.Text = "TOTAL AMOUNT"
        '
        'txtTOTALAMOUNT
        '
        Me.txtTOTALAMOUNT.Enabled = False
        Me.txtTOTALAMOUNT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTALAMOUNT.Location = New System.Drawing.Point(5, 46)
        Me.txtTOTALAMOUNT.Name = "txtTOTALAMOUNT"
        Me.txtTOTALAMOUNT.Size = New System.Drawing.Size(261, 31)
        Me.txtTOTALAMOUNT.TabIndex = 94
        Me.txtTOTALAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPRINT
        '
        Me.btnPRINT.BackColor = System.Drawing.Color.Blue
        Me.btnPRINT.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINT.ForeColor = System.Drawing.Color.White
        Me.btnPRINT.Location = New System.Drawing.Point(966, 53)
        Me.btnPRINT.Name = "btnPRINT"
        Me.btnPRINT.Size = New System.Drawing.Size(150, 40)
        Me.btnPRINT.TabIndex = 122
        Me.btnPRINT.Text = "PRINT"
        Me.btnPRINT.UseVisualStyleBackColor = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.button3)
        Me.groupBox1.Controls.Add(Me.txtAMOUNT)
        Me.groupBox1.Controls.Add(Me.Label3)
        Me.groupBox1.Controls.Add(Me.txtEXPENSECATEGORIES)
        Me.groupBox1.Controls.Add(Me.Label1)
        Me.groupBox1.Location = New System.Drawing.Point(13, 215)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(839, 95)
        Me.groupBox1.TabIndex = 155
        Me.groupBox1.TabStop = False
        '
        'button3
        '
        Me.button3.BackColor = System.Drawing.Color.Yellow
        Me.button3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button3.ForeColor = System.Drawing.Color.Black
        Me.button3.Location = New System.Drawing.Point(697, 31)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(135, 46)
        Me.button3.TabIndex = 118
        Me.button3.Text = "ADD"
        Me.button3.UseVisualStyleBackColor = False
        '
        'txtAMOUNT
        '
        Me.txtAMOUNT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAMOUNT.Location = New System.Drawing.Point(429, 45)
        Me.txtAMOUNT.Name = "txtAMOUNT"
        Me.txtAMOUNT.Size = New System.Drawing.Size(262, 31)
        Me.txtAMOUNT.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(507, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 24)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "AMOUNT"
        '
        'txtEXPENSECATEGORIES
        '
        Me.txtEXPENSECATEGORIES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtEXPENSECATEGORIES.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEXPENSECATEGORIES.FormattingEnabled = True
        Me.txtEXPENSECATEGORIES.Items.AddRange(New Object() {"Prepaid Load", "Notarial Fees", "Fuel", "Fares", "Toll Fees", "Parking Fees", "Shipping Fees", "Meals/Snacks", "Accommodation/s", "Pantry Supplies", "Office Supplies", "Maintenance/Repairs", "Service Charge", "Others"})
        Me.txtEXPENSECATEGORIES.Location = New System.Drawing.Point(10, 45)
        Me.txtEXPENSECATEGORIES.Name = "txtEXPENSECATEGORIES"
        Me.txtEXPENSECATEGORIES.Size = New System.Drawing.Size(413, 31)
        Me.txtEXPENSECATEGORIES.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "EXPENSES CATEGORIES"
        '
        'txtDEPARTMENT
        '
        Me.txtDEPARTMENT.Enabled = False
        Me.txtDEPARTMENT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPARTMENT.Location = New System.Drawing.Point(175, 95)
        Me.txtDEPARTMENT.Name = "txtDEPARTMENT"
        Me.txtDEPARTMENT.Size = New System.Drawing.Size(205, 31)
        Me.txtDEPARTMENT.TabIndex = 116
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtDEPCODE)
        Me.GroupBox2.Controls.Add(Me.txtPURPOSE)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtDATENEEDED)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtEMPLOYEE)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtDATE)
        Me.GroupBox2.Controls.Add(Me.btnPRINT)
        Me.GroupBox2.Controls.Add(Me.txtCONTROL)
        Me.GroupBox2.Controls.Add(Me.label4)
        Me.GroupBox2.Controls.Add(Me.txtDEPARTMENT)
        Me.GroupBox2.Controls.Add(Me.label2)
        Me.GroupBox2.Controls.Add(Me.btnSAVE)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1122, 140)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Yellow
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(966, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 40)
        Me.Button1.TabIndex = 132
        Me.Button1.Text = "RESET"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtDEPCODE
        '
        Me.txtDEPCODE.Enabled = False
        Me.txtDEPCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPCODE.Location = New System.Drawing.Point(386, 95)
        Me.txtDEPCODE.Name = "txtDEPCODE"
        Me.txtDEPCODE.Size = New System.Drawing.Size(88, 31)
        Me.txtDEPCODE.TabIndex = 131
        '
        'txtPURPOSE
        '
        Me.txtPURPOSE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPURPOSE.Location = New System.Drawing.Point(660, 94)
        Me.txtPURPOSE.Name = "txtPURPOSE"
        Me.txtPURPOSE.Size = New System.Drawing.Size(251, 31)
        Me.txtPURPOSE.TabIndex = 130
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(492, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 24)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "PURPOSE"
        '
        'txtDATENEEDED
        '
        Me.txtDATENEEDED.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATENEEDED.Location = New System.Drawing.Point(660, 57)
        Me.txtDATENEEDED.Name = "txtDATENEEDED"
        Me.txtDATENEEDED.Size = New System.Drawing.Size(299, 31)
        Me.txtDATENEEDED.TabIndex = 128
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(490, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 24)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "DATE NEEDED"
        '
        'txtEMPLOYEE
        '
        Me.txtEMPLOYEE.Enabled = False
        Me.txtEMPLOYEE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMPLOYEE.Location = New System.Drawing.Point(175, 58)
        Me.txtEMPLOYEE.Name = "txtEMPLOYEE"
        Me.txtEMPLOYEE.Size = New System.Drawing.Size(299, 31)
        Me.txtEMPLOYEE.TabIndex = 126
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(14, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 24)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "EMPLOYEE"
        '
        'txtCONTROL
        '
        Me.txtCONTROL.Enabled = False
        Me.txtCONTROL.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTROL.Location = New System.Drawing.Point(660, 19)
        Me.txtCONTROL.Name = "txtCONTROL"
        Me.txtCONTROL.Size = New System.Drawing.Size(299, 31)
        Me.txtCONTROL.TabIndex = 118
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Arial Black", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Yellow
        Me.label4.Location = New System.Drawing.Point(482, 18)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(162, 33)
        Me.label4.TabIndex = 117
        Me.label4.Text = "CONTROL#"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(13, 94)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(138, 24)
        Me.label2.TabIndex = 114
        Me.label2.Text = "DEPARTMENT"
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(965, 11)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(150, 40)
        Me.btnSAVE.TabIndex = 121
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(13, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 24)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "DATE"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.txtTRANSACTION)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(12, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1122, 63)
        Me.Panel1.TabIndex = 154
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(391, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(301, 86)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 159
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtTRANSACTION
        '
        Me.txtTRANSACTION.Enabled = False
        Me.txtTRANSACTION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRANSACTION.Location = New System.Drawing.Point(712, 23)
        Me.txtTRANSACTION.Name = "txtTRANSACTION"
        Me.txtTRANSACTION.Size = New System.Drawing.Size(34, 31)
        Me.txtTRANSACTION.TabIndex = 131
        Me.txtTRANSACTION.Visible = False
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(752, 23)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(34, 31)
        Me.txtID.TabIndex = 130
        Me.txtID.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(792, 23)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(192, 31)
        Me.DateTimePicker1.TabIndex = 129
        Me.DateTimePicker1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1122, 10)
        Me.Panel2.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(579, 46)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "8SONAKA INC CASH ADVANCE"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DimGray
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(990, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 46)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "CLOSE"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeColumns = False
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dataGridView1.ColumnHeadersHeight = 30
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EXPENSE_CATEGORIES, Me.AMOUNT, Me.EDIT, Me.UPDATE, Me.DELETE})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dataGridView1.EnableHeadersVisualStyles = False
        Me.dataGridView1.Location = New System.Drawing.Point(12, 316)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Aqua
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(1123, 439)
        Me.dataGridView1.TabIndex = 157
        '
        'EXPENSE_CATEGORIES
        '
        Me.EXPENSE_CATEGORIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EXPENSE_CATEGORIES.HeaderText = "EXPENSE_CATEGORIES"
        Me.EXPENSE_CATEGORIES.Name = "EXPENSE_CATEGORIES"
        '
        'AMOUNT
        '
        Me.AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.AMOUNT.DefaultCellStyle = DataGridViewCellStyle7
        Me.AMOUNT.HeaderText = "AMOUNT"
        Me.AMOUNT.Name = "AMOUNT"
        Me.AMOUNT.Width = 92
        '
        'EDIT
        '
        Me.EDIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EDIT.HeaderText = "EDIT"
        Me.EDIT.Name = "EDIT"
        Me.EDIT.Text = "EDIT"
        Me.EDIT.ToolTipText = "EDIT"
        Me.EDIT.UseColumnTextForButtonValue = True
        Me.EDIT.Width = 46
        '
        'UPDATE
        '
        Me.UPDATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UPDATE.HeaderText = "UPDATE"
        Me.UPDATE.Name = "UPDATE"
        Me.UPDATE.Text = "UPDATE"
        Me.UPDATE.ToolTipText = "UPDATE"
        Me.UPDATE.UseColumnTextForButtonValue = True
        Me.UPDATE.Width = 66
        '
        'DELETE
        '
        Me.DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DELETE.HeaderText = "DELETE"
        Me.DELETE.Name = "DELETE"
        Me.DELETE.Text = "DELETE"
        Me.DELETE.ToolTipText = "DELETE"
        Me.DELETE.UseColumnTextForButtonValue = True
        Me.DELETE.Width = 65
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(917, 94)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(42, 31)
        Me.Button2.TabIndex = 140
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frm8SI_CASHADVANCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1147, 770)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm8SI_CASHADVANCE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtDATE As System.Windows.Forms.DateTimePicker
    Public WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents txtTOTALAMOUNT As System.Windows.Forms.TextBox
    Public WithEvents btnPRINT As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents button3 As System.Windows.Forms.Button
    Public WithEvents txtAMOUNT As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents txtEXPENSECATEGORIES As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtDEPARTMENT As System.Windows.Forms.TextBox
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents txtDEPCODE As System.Windows.Forms.TextBox
    Public WithEvents txtPURPOSE As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents txtDATENEEDED As System.Windows.Forms.DateTimePicker
    Private WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents txtEMPLOYEE As System.Windows.Forms.TextBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents txtCONTROL As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Public WithEvents btnSAVE As System.Windows.Forms.Button
    Private WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents txtTRANSACTION As System.Windows.Forms.TextBox
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Private WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Public WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Public WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Public WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EXPENSE_CATEGORIES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AMOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EDIT As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents UPDATE As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DELETE As System.Windows.Forms.DataGridViewButtonColumn
    Public WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents Button2 As System.Windows.Forms.Button
End Class
