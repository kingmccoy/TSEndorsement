<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblQtyEndorsed = New System.Windows.Forms.Label()
        Me.TBoxQtyEndorsed = New System.Windows.Forms.TextBox()
        Me.LblModel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBoxSerialNo = New System.Windows.Forms.TextBox()
        Me.LblPPONo = New System.Windows.Forms.Label()
        Me.TBoxPPONo = New System.Windows.Forms.TextBox()
        Me.LblPPOQty = New System.Windows.Forms.Label()
        Me.TBoxPPOQty = New System.Windows.Forms.TextBox()
        Me.LblLotNo = New System.Windows.Forms.Label()
        Me.TBoxLotNo = New System.Windows.Forms.TextBox()
        Me.LblWorkOrder = New System.Windows.Forms.Label()
        Me.TBoxWorkOrder = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TBoxFailureSymptoms = New System.Windows.Forms.TextBox()
        Me.LblEndorsedBy = New System.Windows.Forms.Label()
        Me.TBoxEndorsedBy = New System.Windows.Forms.TextBox()
        Me.LblDateFailed = New System.Windows.Forms.Label()
        Me.LblEndorsementDate = New System.Windows.Forms.Label()
        Me.LblWorkWeek = New System.Windows.Forms.Label()
        Me.TBoxWorkweek = New System.Windows.Forms.TextBox()
        Me.LblValidatedBy = New System.Windows.Forms.Label()
        Me.TBoxValidatedBy = New System.Windows.Forms.TextBox()
        Me.LblAnalysis = New System.Windows.Forms.Label()
        Me.TBoxAnalysis = New System.Windows.Forms.TextBox()
        Me.LblActionTaken = New System.Windows.Forms.Label()
        Me.TBoxActionTaken = New System.Windows.Forms.TextBox()
        Me.LblLoc1 = New System.Windows.Forms.Label()
        Me.TBoxLocation1 = New System.Windows.Forms.TextBox()
        Me.LblLoc2 = New System.Windows.Forms.Label()
        Me.TBoxLocation2 = New System.Windows.Forms.TextBox()
        Me.LblLoc3 = New System.Windows.Forms.Label()
        Me.TBoxLocation3 = New System.Windows.Forms.TextBox()
        Me.LblLoc4 = New System.Windows.Forms.Label()
        Me.TBoxLocation4 = New System.Windows.Forms.TextBox()
        Me.LblLoc5 = New System.Windows.Forms.Label()
        Me.TBoxLocation5 = New System.Windows.Forms.TextBox()
        Me.LblRepairedBy = New System.Windows.Forms.Label()
        Me.TBoxRepairedBy = New System.Windows.Forms.TextBox()
        Me.LblDateRepaired = New System.Windows.Forms.Label()
        Me.LblDefectType = New System.Windows.Forms.Label()
        Me.TBoxDefectType = New System.Windows.Forms.TextBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TBoxStatus = New System.Windows.Forms.TextBox()
        Me.LblRemarks = New System.Windows.Forms.Label()
        Me.TBoxRemarks = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DTPDateFailed = New System.Windows.Forms.DateTimePicker()
        Me.DTPEndorsementDate = New System.Windows.Forms.DateTimePicker()
        Me.BtnEndorse = New System.Windows.Forms.Button()
        Me.BtnInformationClear = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TboxEndorsementNo = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageEndorsement = New System.Windows.Forms.TabPage()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.GBoxData = New System.Windows.Forms.GroupBox()
        Me.CBoxStation = New System.Windows.Forms.ComboBox()
        Me.BtnDataClear = New System.Windows.Forms.Button()
        Me.GBoxInformation = New System.Windows.Forms.GroupBox()
        Me.BtnScan = New System.Windows.Forms.Button()
        Me.CBoxModel = New System.Windows.Forms.ComboBox()
        Me.GBoxEndorsmentData = New System.Windows.Forms.GroupBox()
        Me.LblCount = New System.Windows.Forms.Label()
        Me.LblEndorsedCount = New System.Windows.Forms.Label()
        Me.DGVEndorsementData = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTEndorsementDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSEndorsementData = New Endorsement.DSEndorsementData()
        Me.TabPageReceiving = New System.Windows.Forms.TabPage()
        Me.TabPageTS = New System.Windows.Forms.TabPage()
        Me.TabPageInquiry = New System.Windows.Forms.TabPage()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPageEndorsement.SuspendLayout()
        Me.GBoxData.SuspendLayout()
        Me.GBoxInformation.SuspendLayout()
        Me.GBoxEndorsmentData.SuspendLayout()
        CType(Me.DGVEndorsementData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTEndorsementDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSEndorsementData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageTS.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblQtyEndorsed
        '
        Me.LblQtyEndorsed.AutoSize = True
        Me.LblQtyEndorsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQtyEndorsed.Location = New System.Drawing.Point(7, 19)
        Me.LblQtyEndorsed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblQtyEndorsed.Name = "LblQtyEndorsed"
        Me.LblQtyEndorsed.Size = New System.Drawing.Size(105, 15)
        Me.LblQtyEndorsed.TabIndex = 0
        Me.LblQtyEndorsed.Text = "Quantity Endorsed"
        '
        'TBoxQtyEndorsed
        '
        Me.TBoxQtyEndorsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxQtyEndorsed.Location = New System.Drawing.Point(7, 37)
        Me.TBoxQtyEndorsed.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxQtyEndorsed.Name = "TBoxQtyEndorsed"
        Me.TBoxQtyEndorsed.Size = New System.Drawing.Size(143, 23)
        Me.TBoxQtyEndorsed.TabIndex = 1
        Me.TBoxQtyEndorsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblModel
        '
        Me.LblModel.AutoSize = True
        Me.LblModel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModel.Location = New System.Drawing.Point(7, 63)
        Me.LblModel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblModel.Name = "LblModel"
        Me.LblModel.Size = New System.Drawing.Size(41, 15)
        Me.LblModel.TabIndex = 2
        Me.LblModel.Text = "Model"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 19)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Serial No."
        '
        'TBoxSerialNo
        '
        Me.TBoxSerialNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxSerialNo.Location = New System.Drawing.Point(7, 37)
        Me.TBoxSerialNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxSerialNo.Name = "TBoxSerialNo"
        Me.TBoxSerialNo.Size = New System.Drawing.Size(143, 23)
        Me.TBoxSerialNo.TabIndex = 1
        Me.TBoxSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPPONo
        '
        Me.LblPPONo.AutoSize = True
        Me.LblPPONo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPONo.Location = New System.Drawing.Point(7, 107)
        Me.LblPPONo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPPONo.Name = "LblPPONo"
        Me.LblPPONo.Size = New System.Drawing.Size(77, 15)
        Me.LblPPONo.TabIndex = 4
        Me.LblPPONo.Text = "PPO Number"
        '
        'TBoxPPONo
        '
        Me.TBoxPPONo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxPPONo.Location = New System.Drawing.Point(7, 125)
        Me.TBoxPPONo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxPPONo.Name = "TBoxPPONo"
        Me.TBoxPPONo.Size = New System.Drawing.Size(143, 23)
        Me.TBoxPPONo.TabIndex = 5
        Me.TBoxPPONo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPPOQty
        '
        Me.LblPPOQty.AutoSize = True
        Me.LblPPOQty.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPOQty.Location = New System.Drawing.Point(7, 151)
        Me.LblPPOQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPPOQty.Name = "LblPPOQty"
        Me.LblPPOQty.Size = New System.Drawing.Size(79, 15)
        Me.LblPPOQty.TabIndex = 6
        Me.LblPPOQty.Text = "PPO Quantity"
        '
        'TBoxPPOQty
        '
        Me.TBoxPPOQty.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxPPOQty.Location = New System.Drawing.Point(7, 169)
        Me.TBoxPPOQty.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxPPOQty.Name = "TBoxPPOQty"
        Me.TBoxPPOQty.Size = New System.Drawing.Size(143, 23)
        Me.TBoxPPOQty.TabIndex = 7
        Me.TBoxPPOQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblLotNo
        '
        Me.LblLotNo.AutoSize = True
        Me.LblLotNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLotNo.Location = New System.Drawing.Point(7, 195)
        Me.LblLotNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLotNo.Name = "LblLotNo"
        Me.LblLotNo.Size = New System.Drawing.Size(71, 15)
        Me.LblLotNo.TabIndex = 8
        Me.LblLotNo.Text = "Lot Number"
        '
        'TBoxLotNo
        '
        Me.TBoxLotNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxLotNo.Location = New System.Drawing.Point(7, 213)
        Me.TBoxLotNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxLotNo.Name = "TBoxLotNo"
        Me.TBoxLotNo.Size = New System.Drawing.Size(143, 23)
        Me.TBoxLotNo.TabIndex = 9
        Me.TBoxLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblWorkOrder
        '
        Me.LblWorkOrder.AutoSize = True
        Me.LblWorkOrder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWorkOrder.Location = New System.Drawing.Point(7, 239)
        Me.LblWorkOrder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblWorkOrder.Name = "LblWorkOrder"
        Me.LblWorkOrder.Size = New System.Drawing.Size(68, 15)
        Me.LblWorkOrder.TabIndex = 10
        Me.LblWorkOrder.Text = "Work Order"
        '
        'TBoxWorkOrder
        '
        Me.TBoxWorkOrder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxWorkOrder.Location = New System.Drawing.Point(7, 257)
        Me.TBoxWorkOrder.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxWorkOrder.Name = "TBoxWorkOrder"
        Me.TBoxWorkOrder.Size = New System.Drawing.Size(143, 23)
        Me.TBoxWorkOrder.TabIndex = 11
        Me.TBoxWorkOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 63)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Station"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 107)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Failure Symptoms"
        '
        'TBoxFailureSymptoms
        '
        Me.TBoxFailureSymptoms.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxFailureSymptoms.Location = New System.Drawing.Point(7, 125)
        Me.TBoxFailureSymptoms.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxFailureSymptoms.Name = "TBoxFailureSymptoms"
        Me.TBoxFailureSymptoms.Size = New System.Drawing.Size(143, 23)
        Me.TBoxFailureSymptoms.TabIndex = 5
        Me.TBoxFailureSymptoms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblEndorsedBy
        '
        Me.LblEndorsedBy.AutoSize = True
        Me.LblEndorsedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndorsedBy.Location = New System.Drawing.Point(7, 283)
        Me.LblEndorsedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEndorsedBy.Name = "LblEndorsedBy"
        Me.LblEndorsedBy.Size = New System.Drawing.Size(75, 15)
        Me.LblEndorsedBy.TabIndex = 12
        Me.LblEndorsedBy.Text = "Endorsed by:"
        '
        'TBoxEndorsedBy
        '
        Me.TBoxEndorsedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxEndorsedBy.Location = New System.Drawing.Point(7, 301)
        Me.TBoxEndorsedBy.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxEndorsedBy.Name = "TBoxEndorsedBy"
        Me.TBoxEndorsedBy.Size = New System.Drawing.Size(143, 23)
        Me.TBoxEndorsedBy.TabIndex = 13
        Me.TBoxEndorsedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblDateFailed
        '
        Me.LblDateFailed.AutoSize = True
        Me.LblDateFailed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDateFailed.Location = New System.Drawing.Point(7, 327)
        Me.LblDateFailed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDateFailed.Name = "LblDateFailed"
        Me.LblDateFailed.Size = New System.Drawing.Size(65, 15)
        Me.LblDateFailed.TabIndex = 14
        Me.LblDateFailed.Text = "Date Failed"
        '
        'LblEndorsementDate
        '
        Me.LblEndorsementDate.AutoSize = True
        Me.LblEndorsementDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndorsementDate.Location = New System.Drawing.Point(7, 371)
        Me.LblEndorsementDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEndorsementDate.Name = "LblEndorsementDate"
        Me.LblEndorsementDate.Size = New System.Drawing.Size(104, 15)
        Me.LblEndorsementDate.TabIndex = 16
        Me.LblEndorsementDate.Text = "Endorsement Date"
        '
        'LblWorkWeek
        '
        Me.LblWorkWeek.AutoSize = True
        Me.LblWorkWeek.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWorkWeek.Location = New System.Drawing.Point(7, 415)
        Me.LblWorkWeek.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblWorkWeek.Name = "LblWorkWeek"
        Me.LblWorkWeek.Size = New System.Drawing.Size(62, 15)
        Me.LblWorkWeek.TabIndex = 18
        Me.LblWorkWeek.Text = "Workweek"
        '
        'TBoxWorkweek
        '
        Me.TBoxWorkweek.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxWorkweek.Location = New System.Drawing.Point(7, 433)
        Me.TBoxWorkweek.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxWorkweek.Name = "TBoxWorkweek"
        Me.TBoxWorkweek.ReadOnly = True
        Me.TBoxWorkweek.Size = New System.Drawing.Size(143, 23)
        Me.TBoxWorkweek.TabIndex = 19
        Me.TBoxWorkweek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblValidatedBy
        '
        Me.LblValidatedBy.AutoSize = True
        Me.LblValidatedBy.Location = New System.Drawing.Point(7, 3)
        Me.LblValidatedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblValidatedBy.Name = "LblValidatedBy"
        Me.LblValidatedBy.Size = New System.Drawing.Size(74, 15)
        Me.LblValidatedBy.TabIndex = 0
        Me.LblValidatedBy.Text = "Validated by:"
        '
        'TBoxValidatedBy
        '
        Me.TBoxValidatedBy.Location = New System.Drawing.Point(7, 22)
        Me.TBoxValidatedBy.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxValidatedBy.Name = "TBoxValidatedBy"
        Me.TBoxValidatedBy.Size = New System.Drawing.Size(116, 23)
        Me.TBoxValidatedBy.TabIndex = 1
        '
        'LblAnalysis
        '
        Me.LblAnalysis.AutoSize = True
        Me.LblAnalysis.Location = New System.Drawing.Point(7, 49)
        Me.LblAnalysis.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAnalysis.Name = "LblAnalysis"
        Me.LblAnalysis.Size = New System.Drawing.Size(50, 15)
        Me.LblAnalysis.TabIndex = 0
        Me.LblAnalysis.Text = "Analysis"
        '
        'TBoxAnalysis
        '
        Me.TBoxAnalysis.Location = New System.Drawing.Point(7, 68)
        Me.TBoxAnalysis.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxAnalysis.Name = "TBoxAnalysis"
        Me.TBoxAnalysis.Size = New System.Drawing.Size(116, 23)
        Me.TBoxAnalysis.TabIndex = 1
        '
        'LblActionTaken
        '
        Me.LblActionTaken.AutoSize = True
        Me.LblActionTaken.Location = New System.Drawing.Point(7, 95)
        Me.LblActionTaken.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblActionTaken.Name = "LblActionTaken"
        Me.LblActionTaken.Size = New System.Drawing.Size(75, 15)
        Me.LblActionTaken.TabIndex = 0
        Me.LblActionTaken.Text = "Action Taken"
        '
        'TBoxActionTaken
        '
        Me.TBoxActionTaken.Location = New System.Drawing.Point(7, 114)
        Me.TBoxActionTaken.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxActionTaken.Name = "TBoxActionTaken"
        Me.TBoxActionTaken.Size = New System.Drawing.Size(116, 23)
        Me.TBoxActionTaken.TabIndex = 1
        '
        'LblLoc1
        '
        Me.LblLoc1.AutoSize = True
        Me.LblLoc1.Location = New System.Drawing.Point(7, 141)
        Me.LblLoc1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLoc1.Name = "LblLoc1"
        Me.LblLoc1.Size = New System.Drawing.Size(62, 15)
        Me.LblLoc1.TabIndex = 0
        Me.LblLoc1.Text = "Location 1"
        '
        'TBoxLocation1
        '
        Me.TBoxLocation1.Location = New System.Drawing.Point(7, 160)
        Me.TBoxLocation1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxLocation1.Name = "TBoxLocation1"
        Me.TBoxLocation1.Size = New System.Drawing.Size(116, 23)
        Me.TBoxLocation1.TabIndex = 1
        '
        'LblLoc2
        '
        Me.LblLoc2.AutoSize = True
        Me.LblLoc2.Location = New System.Drawing.Point(7, 187)
        Me.LblLoc2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLoc2.Name = "LblLoc2"
        Me.LblLoc2.Size = New System.Drawing.Size(62, 15)
        Me.LblLoc2.TabIndex = 0
        Me.LblLoc2.Text = "Location 2"
        '
        'TBoxLocation2
        '
        Me.TBoxLocation2.Location = New System.Drawing.Point(7, 206)
        Me.TBoxLocation2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxLocation2.Name = "TBoxLocation2"
        Me.TBoxLocation2.Size = New System.Drawing.Size(116, 23)
        Me.TBoxLocation2.TabIndex = 1
        '
        'LblLoc3
        '
        Me.LblLoc3.AutoSize = True
        Me.LblLoc3.Location = New System.Drawing.Point(7, 233)
        Me.LblLoc3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLoc3.Name = "LblLoc3"
        Me.LblLoc3.Size = New System.Drawing.Size(62, 15)
        Me.LblLoc3.TabIndex = 0
        Me.LblLoc3.Text = "Location 3"
        '
        'TBoxLocation3
        '
        Me.TBoxLocation3.Location = New System.Drawing.Point(7, 252)
        Me.TBoxLocation3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxLocation3.Name = "TBoxLocation3"
        Me.TBoxLocation3.Size = New System.Drawing.Size(116, 23)
        Me.TBoxLocation3.TabIndex = 1
        '
        'LblLoc4
        '
        Me.LblLoc4.AutoSize = True
        Me.LblLoc4.Location = New System.Drawing.Point(7, 279)
        Me.LblLoc4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLoc4.Name = "LblLoc4"
        Me.LblLoc4.Size = New System.Drawing.Size(62, 15)
        Me.LblLoc4.TabIndex = 0
        Me.LblLoc4.Text = "Location 4"
        '
        'TBoxLocation4
        '
        Me.TBoxLocation4.Location = New System.Drawing.Point(7, 298)
        Me.TBoxLocation4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxLocation4.Name = "TBoxLocation4"
        Me.TBoxLocation4.Size = New System.Drawing.Size(116, 23)
        Me.TBoxLocation4.TabIndex = 1
        '
        'LblLoc5
        '
        Me.LblLoc5.AutoSize = True
        Me.LblLoc5.Location = New System.Drawing.Point(185, 3)
        Me.LblLoc5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLoc5.Name = "LblLoc5"
        Me.LblLoc5.Size = New System.Drawing.Size(62, 15)
        Me.LblLoc5.TabIndex = 0
        Me.LblLoc5.Text = "Location 5"
        '
        'TBoxLocation5
        '
        Me.TBoxLocation5.Location = New System.Drawing.Point(185, 22)
        Me.TBoxLocation5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxLocation5.Name = "TBoxLocation5"
        Me.TBoxLocation5.Size = New System.Drawing.Size(116, 23)
        Me.TBoxLocation5.TabIndex = 1
        '
        'LblRepairedBy
        '
        Me.LblRepairedBy.AutoSize = True
        Me.LblRepairedBy.Location = New System.Drawing.Point(185, 49)
        Me.LblRepairedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRepairedBy.Name = "LblRepairedBy"
        Me.LblRepairedBy.Size = New System.Drawing.Size(72, 15)
        Me.LblRepairedBy.TabIndex = 0
        Me.LblRepairedBy.Text = "Repaired by:"
        '
        'TBoxRepairedBy
        '
        Me.TBoxRepairedBy.Location = New System.Drawing.Point(185, 68)
        Me.TBoxRepairedBy.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxRepairedBy.Name = "TBoxRepairedBy"
        Me.TBoxRepairedBy.Size = New System.Drawing.Size(116, 23)
        Me.TBoxRepairedBy.TabIndex = 1
        '
        'LblDateRepaired
        '
        Me.LblDateRepaired.AutoSize = True
        Me.LblDateRepaired.Location = New System.Drawing.Point(185, 95)
        Me.LblDateRepaired.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDateRepaired.Name = "LblDateRepaired"
        Me.LblDateRepaired.Size = New System.Drawing.Size(80, 15)
        Me.LblDateRepaired.TabIndex = 0
        Me.LblDateRepaired.Text = "Date Repaired"
        '
        'LblDefectType
        '
        Me.LblDefectType.AutoSize = True
        Me.LblDefectType.Location = New System.Drawing.Point(185, 141)
        Me.LblDefectType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDefectType.Name = "LblDefectType"
        Me.LblDefectType.Size = New System.Drawing.Size(68, 15)
        Me.LblDefectType.TabIndex = 0
        Me.LblDefectType.Text = "Defect Type"
        '
        'TBoxDefectType
        '
        Me.TBoxDefectType.Location = New System.Drawing.Point(185, 160)
        Me.TBoxDefectType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxDefectType.Name = "TBoxDefectType"
        Me.TBoxDefectType.Size = New System.Drawing.Size(116, 23)
        Me.TBoxDefectType.TabIndex = 1
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Location = New System.Drawing.Point(185, 187)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(39, 15)
        Me.LblStatus.TabIndex = 0
        Me.LblStatus.Text = "Status"
        '
        'TBoxStatus
        '
        Me.TBoxStatus.Location = New System.Drawing.Point(185, 206)
        Me.TBoxStatus.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxStatus.Name = "TBoxStatus"
        Me.TBoxStatus.Size = New System.Drawing.Size(116, 23)
        Me.TBoxStatus.TabIndex = 1
        '
        'LblRemarks
        '
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.Location = New System.Drawing.Point(185, 233)
        Me.LblRemarks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(52, 15)
        Me.LblRemarks.TabIndex = 0
        Me.LblRemarks.Text = "Remarks"
        '
        'TBoxRemarks
        '
        Me.TBoxRemarks.Location = New System.Drawing.Point(185, 252)
        Me.TBoxRemarks.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TBoxRemarks.Name = "TBoxRemarks"
        Me.TBoxRemarks.Size = New System.Drawing.Size(116, 23)
        Me.TBoxRemarks.TabIndex = 1
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.CustomFormat = "MMM dd, yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(185, 114)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 23)
        Me.DateTimePicker1.TabIndex = 2
        '
        'DTPDateFailed
        '
        Me.DTPDateFailed.Checked = False
        Me.DTPDateFailed.CustomFormat = "MMM dd, yyyy"
        Me.DTPDateFailed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPDateFailed.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPDateFailed.Location = New System.Drawing.Point(7, 345)
        Me.DTPDateFailed.Name = "DTPDateFailed"
        Me.DTPDateFailed.Size = New System.Drawing.Size(143, 23)
        Me.DTPDateFailed.TabIndex = 15
        '
        'DTPEndorsementDate
        '
        Me.DTPEndorsementDate.Checked = False
        Me.DTPEndorsementDate.CustomFormat = "MMM dd, yyyy"
        Me.DTPEndorsementDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEndorsementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPEndorsementDate.Location = New System.Drawing.Point(7, 389)
        Me.DTPEndorsementDate.Name = "DTPEndorsementDate"
        Me.DTPEndorsementDate.Size = New System.Drawing.Size(143, 23)
        Me.DTPEndorsementDate.TabIndex = 17
        '
        'BtnEndorse
        '
        Me.BtnEndorse.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEndorse.Location = New System.Drawing.Point(7, 154)
        Me.BtnEndorse.Name = "BtnEndorse"
        Me.BtnEndorse.Size = New System.Drawing.Size(69, 23)
        Me.BtnEndorse.TabIndex = 6
        Me.BtnEndorse.Text = "Endorse"
        Me.BtnEndorse.UseVisualStyleBackColor = True
        '
        'BtnInformationClear
        '
        Me.BtnInformationClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInformationClear.Location = New System.Drawing.Point(81, 462)
        Me.BtnInformationClear.Name = "BtnInformationClear"
        Me.BtnInformationClear.Size = New System.Drawing.Size(69, 23)
        Me.BtnInformationClear.TabIndex = 21
        Me.BtnInformationClear.Text = "Clear"
        Me.BtnInformationClear.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(7, 10)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(99, 15)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Endorsement No."
        '
        'TboxEndorsementNo
        '
        Me.TboxEndorsementNo.Location = New System.Drawing.Point(114, 6)
        Me.TboxEndorsementNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TboxEndorsementNo.Name = "TboxEndorsementNo"
        Me.TboxEndorsementNo.ReadOnly = True
        Me.TboxEndorsementNo.Size = New System.Drawing.Size(61, 23)
        Me.TboxEndorsementNo.TabIndex = 1
        Me.TboxEndorsementNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageEndorsement)
        Me.TabControl1.Controls.Add(Me.TabPageReceiving)
        Me.TabControl1.Controls.Add(Me.TabPageTS)
        Me.TabControl1.Controls.Add(Me.TabPageInquiry)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1176, 833)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
        '
        'TabPageEndorsement
        '
        Me.TabPageEndorsement.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageEndorsement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TabPageEndorsement.Controls.Add(Me.BtnCancel)
        Me.TabPageEndorsement.Controls.Add(Me.BtnSubmit)
        Me.TabPageEndorsement.Controls.Add(Me.GBoxData)
        Me.TabPageEndorsement.Controls.Add(Me.GBoxInformation)
        Me.TabPageEndorsement.Controls.Add(Me.GBoxEndorsmentData)
        Me.TabPageEndorsement.Controls.Add(Me.Label27)
        Me.TabPageEndorsement.Controls.Add(Me.TboxEndorsementNo)
        Me.TabPageEndorsement.Location = New System.Drawing.Point(4, 24)
        Me.TabPageEndorsement.Name = "TabPageEndorsement"
        Me.TabPageEndorsement.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageEndorsement.Size = New System.Drawing.Size(1168, 805)
        Me.TabPageEndorsement.TabIndex = 0
        Me.TabPageEndorsement.Text = "Endorsement"
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(6, 768)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(170, 31)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(6, 731)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(170, 31)
        Me.BtnSubmit.TabIndex = 4
        Me.BtnSubmit.Text = "Submit"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'GBoxData
        '
        Me.GBoxData.Controls.Add(Me.CBoxStation)
        Me.GBoxData.Controls.Add(Me.BtnDataClear)
        Me.GBoxData.Controls.Add(Me.Label9)
        Me.GBoxData.Controls.Add(Me.TBoxSerialNo)
        Me.GBoxData.Controls.Add(Me.Label8)
        Me.GBoxData.Controls.Add(Me.TBoxFailureSymptoms)
        Me.GBoxData.Controls.Add(Me.BtnEndorse)
        Me.GBoxData.Controls.Add(Me.Label3)
        Me.GBoxData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxData.Location = New System.Drawing.Point(6, 535)
        Me.GBoxData.Name = "GBoxData"
        Me.GBoxData.Size = New System.Drawing.Size(170, 191)
        Me.GBoxData.TabIndex = 3
        Me.GBoxData.TabStop = False
        Me.GBoxData.Text = "Data"
        '
        'CBoxStation
        '
        Me.CBoxStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxStation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBoxStation.FormattingEnabled = True
        Me.CBoxStation.Location = New System.Drawing.Point(7, 81)
        Me.CBoxStation.Name = "CBoxStation"
        Me.CBoxStation.Size = New System.Drawing.Size(143, 23)
        Me.CBoxStation.TabIndex = 3
        '
        'BtnDataClear
        '
        Me.BtnDataClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDataClear.Location = New System.Drawing.Point(81, 154)
        Me.BtnDataClear.Name = "BtnDataClear"
        Me.BtnDataClear.Size = New System.Drawing.Size(69, 23)
        Me.BtnDataClear.TabIndex = 7
        Me.BtnDataClear.Text = "Clear"
        Me.BtnDataClear.UseVisualStyleBackColor = True
        '
        'GBoxInformation
        '
        Me.GBoxInformation.Controls.Add(Me.BtnScan)
        Me.GBoxInformation.Controls.Add(Me.CBoxModel)
        Me.GBoxInformation.Controls.Add(Me.LblQtyEndorsed)
        Me.GBoxInformation.Controls.Add(Me.TBoxQtyEndorsed)
        Me.GBoxInformation.Controls.Add(Me.DTPEndorsementDate)
        Me.GBoxInformation.Controls.Add(Me.DTPDateFailed)
        Me.GBoxInformation.Controls.Add(Me.LblDateFailed)
        Me.GBoxInformation.Controls.Add(Me.LblModel)
        Me.GBoxInformation.Controls.Add(Me.LblEndorsementDate)
        Me.GBoxInformation.Controls.Add(Me.BtnInformationClear)
        Me.GBoxInformation.Controls.Add(Me.TBoxEndorsedBy)
        Me.GBoxInformation.Controls.Add(Me.LblEndorsedBy)
        Me.GBoxInformation.Controls.Add(Me.LblWorkWeek)
        Me.GBoxInformation.Controls.Add(Me.TBoxWorkweek)
        Me.GBoxInformation.Controls.Add(Me.LblPPONo)
        Me.GBoxInformation.Controls.Add(Me.TBoxPPONo)
        Me.GBoxInformation.Controls.Add(Me.LblPPOQty)
        Me.GBoxInformation.Controls.Add(Me.TBoxPPOQty)
        Me.GBoxInformation.Controls.Add(Me.LblLotNo)
        Me.GBoxInformation.Controls.Add(Me.TBoxLotNo)
        Me.GBoxInformation.Controls.Add(Me.LblWorkOrder)
        Me.GBoxInformation.Controls.Add(Me.TBoxWorkOrder)
        Me.GBoxInformation.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxInformation.Location = New System.Drawing.Point(6, 35)
        Me.GBoxInformation.Name = "GBoxInformation"
        Me.GBoxInformation.Size = New System.Drawing.Size(170, 494)
        Me.GBoxInformation.TabIndex = 2
        Me.GBoxInformation.TabStop = False
        Me.GBoxInformation.Text = "Information"
        '
        'BtnScan
        '
        Me.BtnScan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnScan.Location = New System.Drawing.Point(7, 462)
        Me.BtnScan.Name = "BtnScan"
        Me.BtnScan.Size = New System.Drawing.Size(69, 23)
        Me.BtnScan.TabIndex = 20
        Me.BtnScan.Text = "Scan"
        Me.BtnScan.UseVisualStyleBackColor = True
        '
        'CBoxModel
        '
        Me.CBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxModel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBoxModel.FormattingEnabled = True
        Me.CBoxModel.Location = New System.Drawing.Point(7, 81)
        Me.CBoxModel.Name = "CBoxModel"
        Me.CBoxModel.Size = New System.Drawing.Size(143, 23)
        Me.CBoxModel.TabIndex = 3
        '
        'GBoxEndorsmentData
        '
        Me.GBoxEndorsmentData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxEndorsmentData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GBoxEndorsmentData.Controls.Add(Me.LblCount)
        Me.GBoxEndorsmentData.Controls.Add(Me.LblEndorsedCount)
        Me.GBoxEndorsmentData.Controls.Add(Me.DGVEndorsementData)
        Me.GBoxEndorsmentData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxEndorsmentData.Location = New System.Drawing.Point(181, 6)
        Me.GBoxEndorsmentData.Margin = New System.Windows.Forms.Padding(2)
        Me.GBoxEndorsmentData.Name = "GBoxEndorsmentData"
        Me.GBoxEndorsmentData.Padding = New System.Windows.Forms.Padding(2)
        Me.GBoxEndorsmentData.Size = New System.Drawing.Size(982, 793)
        Me.GBoxEndorsmentData.TabIndex = 6
        Me.GBoxEndorsmentData.TabStop = False
        Me.GBoxEndorsmentData.Text = "Endorsement Data"
        '
        'LblCount
        '
        Me.LblCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCount.AutoSize = True
        Me.LblCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCount.Location = New System.Drawing.Point(934, 770)
        Me.LblCount.Name = "LblCount"
        Me.LblCount.Size = New System.Drawing.Size(13, 15)
        Me.LblCount.TabIndex = 2
        Me.LblCount.Text = "0"
        '
        'LblEndorsedCount
        '
        Me.LblEndorsedCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEndorsedCount.AutoSize = True
        Me.LblEndorsedCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndorsedCount.Location = New System.Drawing.Point(835, 770)
        Me.LblEndorsedCount.Name = "LblEndorsedCount"
        Me.LblEndorsedCount.Size = New System.Drawing.Size(93, 15)
        Me.LblEndorsedCount.TabIndex = 1
        Me.LblEndorsedCount.Text = "Endorsed count:"
        '
        'DGVEndorsementData
        '
        Me.DGVEndorsementData.AllowUserToAddRows = False
        Me.DGVEndorsementData.AllowUserToDeleteRows = False
        Me.DGVEndorsementData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVEndorsementData.AutoGenerateColumns = False
        Me.DGVEndorsementData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVEndorsementData.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVEndorsementData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVEndorsementData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEndorsementData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20})
        Me.DGVEndorsementData.DataSource = Me.DTEndorsementDataBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVEndorsementData.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGVEndorsementData.Location = New System.Drawing.Point(5, 18)
        Me.DGVEndorsementData.Name = "DGVEndorsementData"
        Me.DGVEndorsementData.ReadOnly = True
        Me.DGVEndorsementData.RowHeadersVisible = False
        Me.DGVEndorsementData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVEndorsementData.Size = New System.Drawing.Size(972, 749)
        Me.DGVEndorsementData.TabIndex = 0
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn11.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn11.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "model"
        Me.DataGridViewTextBoxColumn12.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn12.HeaderText = "Model"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "serial_no"
        Me.DataGridViewTextBoxColumn13.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn13.HeaderText = "Serial No"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "ppo_no"
        Me.DataGridViewTextBoxColumn14.HeaderText = "PPO No"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "ppo_qty"
        Me.DataGridViewTextBoxColumn15.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn15.HeaderText = "PPO Qty"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "lot_no"
        Me.DataGridViewTextBoxColumn16.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn16.HeaderText = "Lot No"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "work_order"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Work Order"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "station"
        Me.DataGridViewTextBoxColumn18.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn18.HeaderText = "Station"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "failure_symptoms"
        Me.DataGridViewTextBoxColumn19.FillWeight = 130.0!
        Me.DataGridViewTextBoxColumn19.HeaderText = "Failure Symptoms"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "endorsed_by"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Endorsed By"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DTEndorsementDataBindingSource
        '
        Me.DTEndorsementDataBindingSource.DataMember = "DTEndorsementData"
        Me.DTEndorsementDataBindingSource.DataSource = Me.DSEndorsementData
        '
        'DSEndorsementData
        '
        Me.DSEndorsementData.DataSetName = "DSEndorsementData"
        Me.DSEndorsementData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabPageReceiving
        '
        Me.TabPageReceiving.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageReceiving.Location = New System.Drawing.Point(4, 24)
        Me.TabPageReceiving.Name = "TabPageReceiving"
        Me.TabPageReceiving.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageReceiving.Size = New System.Drawing.Size(1168, 805)
        Me.TabPageReceiving.TabIndex = 3
        Me.TabPageReceiving.Text = "Receiving"
        '
        'TabPageTS
        '
        Me.TabPageTS.Controls.Add(Me.LblValidatedBy)
        Me.TabPageTS.Controls.Add(Me.DateTimePicker1)
        Me.TabPageTS.Controls.Add(Me.LblLoc5)
        Me.TabPageTS.Controls.Add(Me.TBoxLocation4)
        Me.TabPageTS.Controls.Add(Me.TBoxLocation5)
        Me.TabPageTS.Controls.Add(Me.LblLoc4)
        Me.TabPageTS.Controls.Add(Me.LblRepairedBy)
        Me.TabPageTS.Controls.Add(Me.TBoxLocation3)
        Me.TabPageTS.Controls.Add(Me.TBoxRepairedBy)
        Me.TabPageTS.Controls.Add(Me.LblLoc3)
        Me.TabPageTS.Controls.Add(Me.LblDateRepaired)
        Me.TabPageTS.Controls.Add(Me.TBoxLocation2)
        Me.TabPageTS.Controls.Add(Me.LblDefectType)
        Me.TabPageTS.Controls.Add(Me.LblLoc2)
        Me.TabPageTS.Controls.Add(Me.TBoxValidatedBy)
        Me.TabPageTS.Controls.Add(Me.TBoxLocation1)
        Me.TabPageTS.Controls.Add(Me.TBoxDefectType)
        Me.TabPageTS.Controls.Add(Me.LblLoc1)
        Me.TabPageTS.Controls.Add(Me.LblAnalysis)
        Me.TabPageTS.Controls.Add(Me.TBoxRemarks)
        Me.TabPageTS.Controls.Add(Me.LblStatus)
        Me.TabPageTS.Controls.Add(Me.TBoxActionTaken)
        Me.TabPageTS.Controls.Add(Me.TBoxAnalysis)
        Me.TabPageTS.Controls.Add(Me.LblRemarks)
        Me.TabPageTS.Controls.Add(Me.TBoxStatus)
        Me.TabPageTS.Controls.Add(Me.LblActionTaken)
        Me.TabPageTS.Location = New System.Drawing.Point(4, 24)
        Me.TabPageTS.Name = "TabPageTS"
        Me.TabPageTS.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTS.Size = New System.Drawing.Size(1168, 805)
        Me.TabPageTS.TabIndex = 1
        Me.TabPageTS.Text = "TS"
        '
        'TabPageInquiry
        '
        Me.TabPageInquiry.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageInquiry.Location = New System.Drawing.Point(4, 24)
        Me.TabPageInquiry.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPageInquiry.Name = "TabPageInquiry"
        Me.TabPageInquiry.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPageInquiry.Size = New System.Drawing.Size(1168, 805)
        Me.TabPageInquiry.TabIndex = 2
        Me.TabPageInquiry.Text = "Inquiry"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1176, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.Endorsement.My.Resources.Resources.silicon_labs
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1176, 857)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmMain"
        Me.Text = "Endorsement"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageEndorsement.ResumeLayout(False)
        Me.TabPageEndorsement.PerformLayout()
        Me.GBoxData.ResumeLayout(False)
        Me.GBoxData.PerformLayout()
        Me.GBoxInformation.ResumeLayout(False)
        Me.GBoxInformation.PerformLayout()
        Me.GBoxEndorsmentData.ResumeLayout(False)
        Me.GBoxEndorsmentData.PerformLayout()
        CType(Me.DGVEndorsementData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTEndorsementDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSEndorsementData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageTS.ResumeLayout(False)
        Me.TabPageTS.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblQtyEndorsed As Label
    Friend WithEvents TBoxQtyEndorsed As TextBox
    Friend WithEvents LblModel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TBoxSerialNo As TextBox
    Friend WithEvents LblPPONo As Label
    Friend WithEvents TBoxPPONo As TextBox
    Friend WithEvents LblPPOQty As Label
    Friend WithEvents TBoxPPOQty As TextBox
    Friend WithEvents LblLotNo As Label
    Friend WithEvents TBoxLotNo As TextBox
    Friend WithEvents LblWorkOrder As Label
    Friend WithEvents TBoxWorkOrder As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TBoxFailureSymptoms As TextBox
    Friend WithEvents LblEndorsedBy As Label
    Friend WithEvents TBoxEndorsedBy As TextBox
    Friend WithEvents LblDateFailed As Label
    Friend WithEvents LblEndorsementDate As Label
    Friend WithEvents LblWorkWeek As Label
    Friend WithEvents TBoxWorkweek As TextBox
    Friend WithEvents LblValidatedBy As Label
    Friend WithEvents TBoxValidatedBy As TextBox
    Friend WithEvents LblAnalysis As Label
    Friend WithEvents TBoxAnalysis As TextBox
    Friend WithEvents LblActionTaken As Label
    Friend WithEvents TBoxActionTaken As TextBox
    Friend WithEvents LblLoc1 As Label
    Friend WithEvents TBoxLocation1 As TextBox
    Friend WithEvents LblLoc2 As Label
    Friend WithEvents TBoxLocation2 As TextBox
    Friend WithEvents LblLoc3 As Label
    Friend WithEvents TBoxLocation3 As TextBox
    Friend WithEvents LblLoc4 As Label
    Friend WithEvents TBoxLocation4 As TextBox
    Friend WithEvents LblLoc5 As Label
    Friend WithEvents TBoxLocation5 As TextBox
    Friend WithEvents LblRepairedBy As Label
    Friend WithEvents TBoxRepairedBy As TextBox
    Friend WithEvents LblDateRepaired As Label
    Friend WithEvents LblDefectType As Label
    Friend WithEvents TBoxDefectType As TextBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents TBoxStatus As TextBox
    Friend WithEvents LblRemarks As Label
    Friend WithEvents TBoxRemarks As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DTPDateFailed As DateTimePicker
    Friend WithEvents DTPEndorsementDate As DateTimePicker
    Friend WithEvents BtnEndorse As Button
    Friend WithEvents BtnInformationClear As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents TboxEndorsementNo As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageEndorsement As TabPage
    Friend WithEvents TabPageTS As TabPage
    Friend WithEvents TabPageInquiry As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents GBoxEndorsmentData As GroupBox
    Friend WithEvents GBoxInformation As GroupBox
    Friend WithEvents GBoxData As GroupBox
    Friend WithEvents TabPageReceiving As TabPage
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents BtnDataClear As Button
    Friend WithEvents BtnScan As Button
    Friend WithEvents CBoxModel As ComboBox
    Friend WithEvents CBoxStation As ComboBox
    Friend WithEvents DGVEndorsementData As DataGridView
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SerialnoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PponoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PpoqtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotnoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WorkorderDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FailuresymptomsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EndorsedbyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DTEndorsementDataBindingSource As BindingSource
    Friend WithEvents DSEndorsementData As DSEndorsementData
    Friend WithEvents BtnSubmit As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LblEndorsedCount As Label
    Friend WithEvents LblCount As Label
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
End Class
