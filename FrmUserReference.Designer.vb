<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserReference
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
        Me.LblUser = New System.Windows.Forms.Label()
        Me.BtnUserOk = New System.Windows.Forms.Button()
        Me.CboxUser = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LblUser
        '
        Me.LblUser.AutoSize = True
        Me.LblUser.Location = New System.Drawing.Point(12, 20)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(33, 13)
        Me.LblUser.TabIndex = 0
        Me.LblUser.Text = "User:"
        '
        'BtnUserOk
        '
        Me.BtnUserOk.Location = New System.Drawing.Point(178, 12)
        Me.BtnUserOk.Name = "BtnUserOk"
        Me.BtnUserOk.Size = New System.Drawing.Size(75, 28)
        Me.BtnUserOk.TabIndex = 2
        Me.BtnUserOk.Text = "OK"
        Me.BtnUserOk.UseVisualStyleBackColor = True
        '
        'CboxUser
        '
        Me.CboxUser.FormattingEnabled = True
        Me.CboxUser.Location = New System.Drawing.Point(51, 16)
        Me.CboxUser.Name = "CboxUser"
        Me.CboxUser.Size = New System.Drawing.Size(121, 21)
        Me.CboxUser.TabIndex = 3
        '
        'FrmUserReference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 50)
        Me.Controls.Add(Me.CboxUser)
        Me.Controls.Add(Me.BtnUserOk)
        Me.Controls.Add(Me.LblUser)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmUserReference"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Endorsement User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblUser As Label
    Friend WithEvents BtnUserOk As Button
    Friend WithEvents CboxUser As ComboBox
End Class
