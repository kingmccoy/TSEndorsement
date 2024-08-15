<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdminPass
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
        Me.TboxAdminPass = New System.Windows.Forms.TextBox()
        Me.LblAdminPass = New System.Windows.Forms.Label()
        Me.BtnAdminOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TboxAdminPass
        '
        Me.TboxAdminPass.Location = New System.Drawing.Point(83, 12)
        Me.TboxAdminPass.Name = "TboxAdminPass"
        Me.TboxAdminPass.Size = New System.Drawing.Size(132, 23)
        Me.TboxAdminPass.TabIndex = 1
        '
        'LblAdminPass
        '
        Me.LblAdminPass.AutoSize = True
        Me.LblAdminPass.Location = New System.Drawing.Point(12, 16)
        Me.LblAdminPass.Name = "LblAdminPass"
        Me.LblAdminPass.Size = New System.Drawing.Size(65, 15)
        Me.LblAdminPass.TabIndex = 0
        Me.LblAdminPass.Text = "Passsword:"
        '
        'BtnAdminOk
        '
        Me.BtnAdminOk.Location = New System.Drawing.Point(221, 9)
        Me.BtnAdminOk.Name = "BtnAdminOk"
        Me.BtnAdminOk.Size = New System.Drawing.Size(75, 28)
        Me.BtnAdminOk.TabIndex = 2
        Me.BtnAdminOk.Text = "OK"
        Me.BtnAdminOk.UseVisualStyleBackColor = True
        '
        'FrmAdminPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 48)
        Me.Controls.Add(Me.BtnAdminOk)
        Me.Controls.Add(Me.LblAdminPass)
        Me.Controls.Add(Me.TboxAdminPass)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmAdminPass"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TboxAdminPass As TextBox
    Friend WithEvents LblAdminPass As Label
    Friend WithEvents BtnAdminOk As Button
End Class
