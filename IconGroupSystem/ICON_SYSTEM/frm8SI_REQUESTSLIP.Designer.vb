<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm8SI_REQUESTSLIP
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm8SI_REQUESTSLIP))
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EDIT = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.UPDATE = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DELETE = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPRINT = New System.Windows.Forms.Button()
        Me.txtEMPLOYEE = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTRANSAC = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDATE = New System.Windows.Forms.DateTimePicker()
        Me.txtCONTROL = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtDEPARTMENT = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtDATENEEDED = New System.Windows.Forms.DateTimePicker()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.txtREMARKS = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCLASSIFICATION = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDESCRIP = New System.Windows.Forms.TextBox()
        Me.txtUNIT = New System.Windows.Forms.TextBox()
        Me.button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GENERIC_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeColumns = False
        Me.dataGridView1.AllowUserToResizeRows = False
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
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUANTITY, Me.UNIT, Me.DESCRIPTION, Me.REMARKS, Me.EDIT, Me.UPDATE, Me.DELETE})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dataGridView1.EnableHeadersVisualStyles = False
        Me.dataGridView1.Location = New System.Drawing.Point(10, 531)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Aqua
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(1122, 228)
        Me.dataGridView1.TabIndex = 113
        '
        'QUANTITY
        '
        Me.QUANTITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
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
        'DESCRIPTION
        '
        Me.DESCRIPTION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DESCRIPTION.HeaderText = "DESCRIPTION"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.Width = 123
        '
        'REMARKS
        '
        Me.REMARKS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.REMARKS.HeaderText = "REMARKS"
        Me.REMARKS.Name = "REMARKS"
        '
        'EDIT
        '
        Me.EDIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.EDIT.DefaultCellStyle = DataGridViewCellStyle2
        Me.EDIT.HeaderText = ""
        Me.EDIT.Name = "EDIT"
        Me.EDIT.Text = "EDIT"
        Me.EDIT.UseColumnTextForButtonValue = True
        Me.EDIT.Width = 5
        '
        'UPDATE
        '
        Me.UPDATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UPDATE.HeaderText = ""
        Me.UPDATE.Name = "UPDATE"
        Me.UPDATE.Text = "UPDATE"
        Me.UPDATE.UseColumnTextForButtonValue = True
        Me.UPDATE.Width = 5
        '
        'DELETE
        '
        Me.DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.DELETE.DefaultCellStyle = DataGridViewCellStyle3
        Me.DELETE.HeaderText = ""
        Me.DELETE.Name = "DELETE"
        Me.DELETE.Text = "DELETE"
        Me.DELETE.UseColumnTextForButtonValue = True
        Me.DELETE.Width = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPRINT)
        Me.GroupBox2.Controls.Add(Me.txtEMPLOYEE)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtTRANSAC)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtDATE)
        Me.GroupBox2.Controls.Add(Me.txtCONTROL)
        Me.GroupBox2.Controls.Add(Me.label4)
        Me.GroupBox2.Controls.Add(Me.txtDEPARTMENT)
        Me.GroupBox2.Controls.Add(Me.label3)
        Me.GroupBox2.Controls.Add(Me.label2)
        Me.GroupBox2.Controls.Add(Me.txtDATENEEDED)
        Me.GroupBox2.Controls.Add(Me.btnSAVE)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1122, 129)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        '
        'btnPRINT
        '
        Me.btnPRINT.BackColor = System.Drawing.Color.Blue
        Me.btnPRINT.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINT.ForeColor = System.Drawing.Color.White
        Me.btnPRINT.Location = New System.Drawing.Point(985, 67)
        Me.btnPRINT.Name = "btnPRINT"
        Me.btnPRINT.Size = New System.Drawing.Size(125, 54)
        Me.btnPRINT.TabIndex = 127
        Me.btnPRINT.Text = "PRINT"
        Me.btnPRINT.UseVisualStyleBackColor = False
        '
        'txtEMPLOYEE
        '
        Me.txtEMPLOYEE.Enabled = False
        Me.txtEMPLOYEE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMPLOYEE.Location = New System.Drawing.Point(721, 51)
        Me.txtEMPLOYEE.Name = "txtEMPLOYEE"
        Me.txtEMPLOYEE.Size = New System.Drawing.Size(254, 31)
        Me.txtEMPLOYEE.TabIndex = 126
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(535, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 24)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "EMPLOYEE"
        '
        'txtTRANSAC
        '
        Me.txtTRANSAC.Enabled = False
        Me.txtTRANSAC.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRANSAC.Location = New System.Drawing.Point(721, 88)
        Me.txtTRANSAC.Name = "txtTRANSAC"
        Me.txtTRANSAC.Size = New System.Drawing.Size(254, 31)
        Me.txtTRANSAC.TabIndex = 124
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(535, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 24)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "TRANSACTION"
        '
        'txtDATE
        '
        Me.txtDATE.Enabled = False
        Me.txtDATE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDATE.Location = New System.Drawing.Point(161, 14)
        Me.txtDATE.Name = "txtDATE"
        Me.txtDATE.Size = New System.Drawing.Size(359, 31)
        Me.txtDATE.TabIndex = 119
        '
        'txtCONTROL
        '
        Me.txtCONTROL.Enabled = False
        Me.txtCONTROL.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTROL.Location = New System.Drawing.Point(721, 14)
        Me.txtCONTROL.Name = "txtCONTROL"
        Me.txtCONTROL.Size = New System.Drawing.Size(254, 31)
        Me.txtCONTROL.TabIndex = 118
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Arial Black", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Yellow
        Me.label4.Location = New System.Drawing.Point(528, 14)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(162, 33)
        Me.label4.TabIndex = 117
        Me.label4.Text = "CONTROL#"
        '
        'txtDEPARTMENT
        '
        Me.txtDEPARTMENT.Enabled = False
        Me.txtDEPARTMENT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPARTMENT.Location = New System.Drawing.Point(161, 51)
        Me.txtDEPARTMENT.Name = "txtDEPARTMENT"
        Me.txtDEPARTMENT.Size = New System.Drawing.Size(359, 31)
        Me.txtDEPARTMENT.TabIndex = 116
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(4, 91)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(140, 24)
        Me.label3.TabIndex = 115
        Me.label3.Text = "DATE NEEDED"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(4, 54)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(138, 24)
        Me.label2.TabIndex = 114
        Me.label2.Text = "DEPARTMENT"
        '
        'txtDATENEEDED
        '
        Me.txtDATENEEDED.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATENEEDED.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDATENEEDED.Location = New System.Drawing.Point(161, 88)
        Me.txtDATENEEDED.Name = "txtDATENEEDED"
        Me.txtDATENEEDED.Size = New System.Drawing.Size(359, 31)
        Me.txtDATENEEDED.TabIndex = 120
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(985, 10)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(125, 51)
        Me.btnSAVE.TabIndex = 121
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 24)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "DATE"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(132, 11)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(57, 24)
        Me.label6.TabIndex = 9
        Me.label6.Text = "UNIT"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.White
        Me.label7.Location = New System.Drawing.Point(641, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(139, 24)
        Me.label7.TabIndex = 10
        Me.label7.Text = "DESCRIPTION"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.Color.White
        Me.label8.Location = New System.Drawing.Point(8, 78)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(103, 24)
        Me.label8.TabIndex = 11
        Me.label8.Text = "REMARKS"
        '
        'txtQTY
        '
        Me.txtQTY.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTY.Location = New System.Drawing.Point(8, 38)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(108, 27)
        Me.txtQTY.TabIndex = 12
        '
        'txtREMARKS
        '
        Me.txtREMARKS.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMARKS.Location = New System.Drawing.Point(136, 78)
        Me.txtREMARKS.Name = "txtREMARKS"
        Me.txtREMARKS.Size = New System.Drawing.Size(849, 27)
        Me.txtREMARKS.TabIndex = 42
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
        Me.Label5.Location = New System.Drawing.Point(4, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(557, 46)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "8SONAKA INC REQUEST SLIP"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DimGray
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(991, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 46)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "CLOSE"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.txtCLASSIFICATION)
        Me.groupBox1.Controls.Add(Me.Label12)
        Me.groupBox1.Controls.Add(Me.txtDESCRIP)
        Me.groupBox1.Controls.Add(Me.txtUNIT)
        Me.groupBox1.Controls.Add(Me.button3)
        Me.groupBox1.Controls.Add(Me.Label1)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.txtQTY)
        Me.groupBox1.Controls.Add(Me.txtREMARKS)
        Me.groupBox1.Location = New System.Drawing.Point(10, 205)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(1122, 118)
        Me.groupBox1.TabIndex = 111
        Me.groupBox1.TabStop = False
        '
        'txtCLASSIFICATION
        '
        Me.txtCLASSIFICATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCLASSIFICATION.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCLASSIFICATION.FormattingEnabled = True
        Me.txtCLASSIFICATION.Location = New System.Drawing.Point(204, 36)
        Me.txtCLASSIFICATION.Name = "txtCLASSIFICATION"
        Me.txtCLASSIFICATION.Size = New System.Drawing.Size(353, 30)
        Me.txtCLASSIFICATION.TabIndex = 146
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(214, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(168, 24)
        Me.Label12.TabIndex = 145
        Me.Label12.Text = "CLASSIFICATION"
        '
        'txtDESCRIP
        '
        Me.txtDESCRIP.Enabled = False
        Me.txtDESCRIP.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIP.Location = New System.Drawing.Point(563, 39)
        Me.txtDESCRIP.Name = "txtDESCRIP"
        Me.txtDESCRIP.Size = New System.Drawing.Size(547, 27)
        Me.txtDESCRIP.TabIndex = 89
        '
        'txtUNIT
        '
        Me.txtUNIT.Enabled = False
        Me.txtUNIT.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUNIT.Location = New System.Drawing.Point(122, 38)
        Me.txtUNIT.Name = "txtUNIT"
        Me.txtUNIT.Size = New System.Drawing.Size(76, 27)
        Me.txtUNIT.TabIndex = 88
        Me.txtUNIT.Text = "PCS"
        '
        'button3
        '
        Me.button3.BackColor = System.Drawing.Color.Yellow
        Me.button3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button3.ForeColor = System.Drawing.Color.Black
        Me.button3.Location = New System.Drawing.Point(1001, 70)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(109, 40)
        Me.button3.TabIndex = 86
        Me.button3.Text = "ADD"
        Me.button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "QUANTITY"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.ColumnHeadersHeight = 30
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GENERIC_NAME, Me.Column1})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.Location = New System.Drawing.Point(10, 362)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView2.RowHeadersVisible = False
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Aqua
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1122, 163)
        Me.DataGridView2.TabIndex = 144
        '
        'GENERIC_NAME
        '
        Me.GENERIC_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.GENERIC_NAME.HeaderText = "GENERIC_NAME"
        Me.GENERIC_NAME.Name = "GENERIC_NAME"
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "CLASSIFICATION"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 140
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(10, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1122, 63)
        Me.Panel1.TabIndex = 110
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Yellow
        Me.Button2.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(807, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(178, 39)
        Me.Button2.TabIndex = 129
        Me.Button2.Text = "PAGE SETUP"
        Me.Button2.UseVisualStyleBackColor = False
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
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1194, 195)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(584, 165)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(107, 329)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(1025, 27)
        Me.txtDESCRIPTION.TabIndex = 146
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(14, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 24)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "SEARCH"
        '
        'frm8SI_REQUESTSLIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1142, 770)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm8SI_REQUESTSLIP"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents btnPRINT As System.Windows.Forms.Button
    Public WithEvents txtEMPLOYEE As System.Windows.Forms.TextBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents txtTRANSAC As System.Windows.Forms.TextBox
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents txtDATE As System.Windows.Forms.DateTimePicker
    Private WithEvents txtCONTROL As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents txtDEPARTMENT As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtDATENEEDED As System.Windows.Forms.DateTimePicker
    Public WithEvents btnSAVE As System.Windows.Forms.Button
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtQTY As System.Windows.Forms.TextBox
    Private WithEvents txtREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCLASSIFICATION As System.Windows.Forms.ComboBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents GENERIC_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents txtDESCRIP As System.Windows.Forms.TextBox
    Private WithEvents txtUNIT As System.Windows.Forms.TextBox
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Public WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Public WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Public WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EDIT As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents UPDATE As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DELETE As System.Windows.Forms.DataGridViewButtonColumn
    Private WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
End Class
