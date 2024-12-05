<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm3COMMENT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm3COMMENT))
        Me.txtCOMMENT_1 = New System.Windows.Forms.RichTextBox()
        Me.txtCOMMENT_2 = New System.Windows.Forms.RichTextBox()
        Me.txtCOMMENT_3 = New System.Windows.Forms.RichTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCOMMENT_1
        '
        Me.txtCOMMENT_1.Enabled = False
        Me.txtCOMMENT_1.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOMMENT_1.ForeColor = System.Drawing.Color.Black
        Me.txtCOMMENT_1.Location = New System.Drawing.Point(12, 35)
        Me.txtCOMMENT_1.Name = "txtCOMMENT_1"
        Me.txtCOMMENT_1.Size = New System.Drawing.Size(828, 157)
        Me.txtCOMMENT_1.TabIndex = 1
        Me.txtCOMMENT_1.Text = ""
        '
        'txtCOMMENT_2
        '
        Me.txtCOMMENT_2.Enabled = False
        Me.txtCOMMENT_2.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOMMENT_2.ForeColor = System.Drawing.Color.Black
        Me.txtCOMMENT_2.Location = New System.Drawing.Point(12, 234)
        Me.txtCOMMENT_2.Name = "txtCOMMENT_2"
        Me.txtCOMMENT_2.Size = New System.Drawing.Size(828, 157)
        Me.txtCOMMENT_2.TabIndex = 2
        Me.txtCOMMENT_2.Text = ""
        '
        'txtCOMMENT_3
        '
        Me.txtCOMMENT_3.Enabled = False
        Me.txtCOMMENT_3.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOMMENT_3.ForeColor = System.Drawing.Color.Black
        Me.txtCOMMENT_3.Location = New System.Drawing.Point(12, 431)
        Me.txtCOMMENT_3.Name = "txtCOMMENT_3"
        Me.txtCOMMENT_3.Size = New System.Drawing.Size(828, 157)
        Me.txtCOMMENT_3.TabIndex = 3
        Me.txtCOMMENT_3.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(12, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(216, 24)
        Me.Label12.TabIndex = 114
        Me.Label12.Text = "ENDORSED COMMENT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(12, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "FINANCE COMMENT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(12, 404)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 24)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "FINAL COMMENT"
        '
        'frm3COMMENT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(852, 601)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCOMMENT_3)
        Me.Controls.Add(Me.txtCOMMENT_2)
        Me.Controls.Add(Me.txtCOMMENT_1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm3COMMENT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCOMMENT_1 As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCOMMENT_2 As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCOMMENT_3 As System.Windows.Forms.RichTextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
End Class
