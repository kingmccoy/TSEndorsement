<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFlashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFlashScreen))
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.ProgressBarDBConn = New System.Windows.Forms.ProgressBar()
        Me.BgWorkerFlashScreen = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.Image = Global.TS_Endorsement.My.Resources.Resources.ts_logo_no_background
        Me.PictureBoxLogo.Location = New System.Drawing.Point(12, 12)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(776, 402)
        Me.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxLogo.TabIndex = 0
        Me.PictureBoxLogo.TabStop = False
        '
        'ProgressBarDBConn
        '
        Me.ProgressBarDBConn.Location = New System.Drawing.Point(12, 420)
        Me.ProgressBarDBConn.Name = "ProgressBarDBConn"
        Me.ProgressBarDBConn.Size = New System.Drawing.Size(776, 23)
        Me.ProgressBarDBConn.TabIndex = 1
        '
        'BgWorkerFlashScreen
        '
        '
        'FrmFlashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ProgressBarDBConn)
        Me.Controls.Add(Me.PictureBoxLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmFlashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents ProgressBarDBConn As ProgressBar
    Friend WithEvents BgWorkerFlashScreen As System.ComponentModel.BackgroundWorker
End Class
