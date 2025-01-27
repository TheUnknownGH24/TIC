<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPURPOSE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPURPOSE))
        Me.txtSHOWPURPOSE = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'txtSHOWPURPOSE
        '
        Me.txtSHOWPURPOSE.Enabled = False
        Me.txtSHOWPURPOSE.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSHOWPURPOSE.ForeColor = System.Drawing.Color.Black
        Me.txtSHOWPURPOSE.Location = New System.Drawing.Point(12, 12)
        Me.txtSHOWPURPOSE.Name = "txtSHOWPURPOSE"
        Me.txtSHOWPURPOSE.Size = New System.Drawing.Size(828, 551)
        Me.txtSHOWPURPOSE.TabIndex = 0
        Me.txtSHOWPURPOSE.Text = ""
        '
        'frmPURPOSE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(852, 575)
        Me.Controls.Add(Me.txtSHOWPURPOSE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPURPOSE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSHOWPURPOSE As System.Windows.Forms.RichTextBox
End Class
