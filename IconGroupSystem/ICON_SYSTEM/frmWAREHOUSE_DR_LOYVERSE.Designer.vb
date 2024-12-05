<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWAREHOUSE_DR_LOYVERSE
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWAREHOUSE_DR_LOYVERSE))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtFILEPATH = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCREATE = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnBROWSE = New System.Windows.Forms.Button()
        Me.txtSHEETS = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDISPLAY = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPLATFORMS = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtTRANSAC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Receipt_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Receipt_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variant_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modifiers_applied = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gross_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Discounts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Net_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost_of_goods = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gross_profit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taxes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Store = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cashier_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer_contacts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtFILEPATH
        '
        Me.txtFILEPATH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFILEPATH.Enabled = False
        Me.txtFILEPATH.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFILEPATH.Location = New System.Drawing.Point(5, 28)
        Me.txtFILEPATH.Name = "txtFILEPATH"
        Me.txtFILEPATH.Size = New System.Drawing.Size(453, 31)
        Me.txtFILEPATH.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "FILE PATH"
        '
        'btnCREATE
        '
        Me.btnCREATE.BackColor = System.Drawing.Color.Red
        Me.btnCREATE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCREATE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCREATE.ForeColor = System.Drawing.Color.White
        Me.btnCREATE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCREATE.Location = New System.Drawing.Point(309, 5)
        Me.btnCREATE.Name = "btnCREATE"
        Me.btnCREATE.Size = New System.Drawing.Size(291, 35)
        Me.btnCREATE.TabIndex = 27
        Me.btnCREATE.Text = "SAVE"
        Me.btnCREATE.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Red
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(1163, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 73)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "CREATE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnBROWSE
        '
        Me.btnBROWSE.BackColor = System.Drawing.Color.Yellow
        Me.btnBROWSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBROWSE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBROWSE.ForeColor = System.Drawing.Color.Black
        Me.btnBROWSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBROWSE.Location = New System.Drawing.Point(464, 26)
        Me.btnBROWSE.Name = "btnBROWSE"
        Me.btnBROWSE.Size = New System.Drawing.Size(140, 35)
        Me.btnBROWSE.TabIndex = 11
        Me.btnBROWSE.Text = "BROWSE"
        Me.btnBROWSE.UseVisualStyleBackColor = False
        '
        'txtSHEETS
        '
        Me.txtSHEETS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSHEETS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSHEETS.FormattingEnabled = True
        Me.txtSHEETS.Location = New System.Drawing.Point(5, 89)
        Me.txtSHEETS.Name = "txtSHEETS"
        Me.txtSHEETS.Size = New System.Drawing.Size(453, 31)
        Me.txtSHEETS.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(1, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "SHEETS"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Silver
        Me.GroupBox2.Controls.Add(Me.btnDISPLAY)
        Me.GroupBox2.Controls.Add(Me.btnBROWSE)
        Me.GroupBox2.Controls.Add(Me.txtSHEETS)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFILEPATH)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(5, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(610, 131)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        '
        'btnDISPLAY
        '
        Me.btnDISPLAY.BackColor = System.Drawing.Color.Blue
        Me.btnDISPLAY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDISPLAY.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDISPLAY.ForeColor = System.Drawing.Color.White
        Me.btnDISPLAY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDISPLAY.Location = New System.Drawing.Point(464, 85)
        Me.btnDISPLAY.Name = "btnDISPLAY"
        Me.btnDISPLAY.Size = New System.Drawing.Size(140, 35)
        Me.btnDISPLAY.TabIndex = 12
        Me.btnDISPLAY.Text = "DISPLAY"
        Me.btnDISPLAY.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnCREATE)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(621, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 45)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Blue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(10, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(291, 35)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "EXTRACT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblPLATFORMS
        '
        Me.lblPLATFORMS.AutoSize = True
        Me.lblPLATFORMS.BackColor = System.Drawing.Color.Transparent
        Me.lblPLATFORMS.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLATFORMS.ForeColor = System.Drawing.Color.Red
        Me.lblPLATFORMS.Location = New System.Drawing.Point(896, 13)
        Me.lblPLATFORMS.Name = "lblPLATFORMS"
        Me.lblPLATFORMS.Size = New System.Drawing.Size(290, 46)
        Me.lblPLATFORMS.TabIndex = 23
        Me.lblPLATFORMS.Text = "DIRECT SALES"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1226, 10)
        Me.Panel2.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.lblPLATFORMS)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(5, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1226, 63)
        Me.Panel1.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 46)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "IMPORT EXCEL FILE"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 30
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(5, 207)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Aqua
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(610, 464)
        Me.DataGridView1.TabIndex = 126
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.ColumnHeadersHeight = 30
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date_, Me.Receipt_number, Me.Receipt_type, Me.Category, Me.SKU, Me.Item, Me.Variant_, Me.Modifiers_applied, Me.Quantity, Me.Gross_sales, Me.Discounts, Me.Net_sales, Me.Cost_of_goods, Me.Gross_profit, Me.Taxes, Me.POS, Me.Store, Me.Cashier_name, Me.Customer_name, Me.Customer_contacts, Me.Comment, Me.Status})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.Location = New System.Drawing.Point(621, 121)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Aqua
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(610, 513)
        Me.DataGridView2.TabIndex = 127
        '
        'txtTRANSAC
        '
        Me.txtTRANSAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRANSAC.Enabled = False
        Me.txtTRANSAC.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRANSAC.Location = New System.Drawing.Point(819, 640)
        Me.txtTRANSAC.Name = "txtTRANSAC"
        Me.txtTRANSAC.Size = New System.Drawing.Size(412, 31)
        Me.txtTRANSAC.TabIndex = 129
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(621, 643)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 23)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "TRANSACTION_NO"
        '
        'Date_
        '
        Me.Date_.HeaderText = "Date"
        Me.Date_.Name = "Date_"
        '
        'Receipt_number
        '
        Me.Receipt_number.HeaderText = "Receipt number"
        Me.Receipt_number.Name = "Receipt_number"
        '
        'Receipt_type
        '
        Me.Receipt_type.HeaderText = "Receipt type"
        Me.Receipt_type.Name = "Receipt_type"
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.Name = "Category"
        '
        'SKU
        '
        Me.SKU.HeaderText = "SKU"
        Me.SKU.Name = "SKU"
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        '
        'Variant_
        '
        Me.Variant_.HeaderText = "Variant"
        Me.Variant_.Name = "Variant_"
        '
        'Modifiers_applied
        '
        Me.Modifiers_applied.HeaderText = "Modifiers applied"
        Me.Modifiers_applied.Name = "Modifiers_applied"
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        '
        'Gross_sales
        '
        Me.Gross_sales.HeaderText = "Gross sales"
        Me.Gross_sales.Name = "Gross_sales"
        '
        'Discounts
        '
        Me.Discounts.HeaderText = "Discounts"
        Me.Discounts.Name = "Discounts"
        '
        'Net_sales
        '
        Me.Net_sales.HeaderText = "Net sales"
        Me.Net_sales.Name = "Net_sales"
        '
        'Cost_of_goods
        '
        Me.Cost_of_goods.HeaderText = "Cost of goods"
        Me.Cost_of_goods.Name = "Cost_of_goods"
        '
        'Gross_profit
        '
        Me.Gross_profit.HeaderText = "Gross profit"
        Me.Gross_profit.Name = "Gross_profit"
        '
        'Taxes
        '
        Me.Taxes.HeaderText = "Taxes"
        Me.Taxes.Name = "Taxes"
        '
        'POS
        '
        Me.POS.HeaderText = "POS"
        Me.POS.Name = "POS"
        '
        'Store
        '
        Me.Store.HeaderText = "Store"
        Me.Store.Name = "Store"
        '
        'Cashier_name
        '
        Me.Cashier_name.HeaderText = "Cashier name"
        Me.Cashier_name.Name = "Cashier_name"
        '
        'Customer_name
        '
        Me.Customer_name.HeaderText = "Customer name"
        Me.Customer_name.Name = "Customer_name"
        '
        'Customer_contacts
        '
        Me.Customer_contacts.HeaderText = "Customer contacts"
        Me.Customer_contacts.Name = "Customer_contacts"
        '
        'Comment
        '
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'frmWAREHOUSE_DR_LOYVERSE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1236, 675)
        Me.Controls.Add(Me.txtTRANSAC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWAREHOUSE_DR_LOYVERSE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents txtFILEPATH As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCREATE As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnBROWSE As System.Windows.Forms.Button
    Friend WithEvents txtSHEETS As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDISPLAY As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPLATFORMS As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Public WithEvents txtTRANSAC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Receipt_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Receipt_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variant_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modifiers_applied As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gross_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Discounts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Net_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost_of_goods As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gross_profit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taxes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Store As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cashier_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Customer_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Customer_contacts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
