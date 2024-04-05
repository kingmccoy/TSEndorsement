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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.LblQtyEndorsed = New System.Windows.Forms.Label()
        Me.TBoxQtyEndorsed = New System.Windows.Forms.TextBox()
        Me.LblModel = New System.Windows.Forms.Label()
        Me.LblSerialNo = New System.Windows.Forms.Label()
        Me.TBoxSerialNo = New System.Windows.Forms.TextBox()
        Me.LblPPONo = New System.Windows.Forms.Label()
        Me.TBoxPPONo = New System.Windows.Forms.TextBox()
        Me.LblPPOQty = New System.Windows.Forms.Label()
        Me.TBoxPPOQty = New System.Windows.Forms.TextBox()
        Me.LblLotNo = New System.Windows.Forms.Label()
        Me.TBoxLotNo = New System.Windows.Forms.TextBox()
        Me.LblWorkOrder = New System.Windows.Forms.Label()
        Me.TBoxWorkOrder = New System.Windows.Forms.TextBox()
        Me.LblStation = New System.Windows.Forms.Label()
        Me.LblFailureSymptoms = New System.Windows.Forms.Label()
        Me.TBoxFailureSymptoms = New System.Windows.Forms.TextBox()
        Me.LblEndorsedBy = New System.Windows.Forms.Label()
        Me.TBoxEndorsedBy = New System.Windows.Forms.TextBox()
        Me.LblDateFailed = New System.Windows.Forms.Label()
        Me.LblEndorsementDate = New System.Windows.Forms.Label()
        Me.LblWorkWeek = New System.Windows.Forms.Label()
        Me.TBoxWorkweek = New System.Windows.Forms.TextBox()
        Me.LblAnalysis = New System.Windows.Forms.Label()
        Me.TBoxTSAnalysis = New System.Windows.Forms.TextBox()
        Me.LblActionTaken = New System.Windows.Forms.Label()
        Me.TBoxTSActionTaken = New System.Windows.Forms.TextBox()
        Me.LblLoc1 = New System.Windows.Forms.Label()
        Me.TBoxTSLocation1 = New System.Windows.Forms.TextBox()
        Me.LblDefectType = New System.Windows.Forms.Label()
        Me.TBoxTSDefectType = New System.Windows.Forms.TextBox()
        Me.DTPDateFailed = New System.Windows.Forms.DateTimePicker()
        Me.DTPEndorsementDate = New System.Windows.Forms.DateTimePicker()
        Me.BtnEndorse = New System.Windows.Forms.Button()
        Me.BtnInformationClear = New System.Windows.Forms.Button()
        Me.LblEndorsementNo = New System.Windows.Forms.Label()
        Me.TboxEndorsementNo = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageEndorsement = New System.Windows.Forms.TabPage()
        Me.ChkBoxEndtSerialNo = New System.Windows.Forms.CheckBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GBoxData = New System.Windows.Forms.GroupBox()
        Me.BtnReturn = New System.Windows.Forms.Button()
        Me.BtnEndorseAnotherModel = New System.Windows.Forms.Button()
        Me.CBoxStation = New System.Windows.Forms.ComboBox()
        Me.BtnDataClear = New System.Windows.Forms.Button()
        Me.GBoxInformation = New System.Windows.Forms.GroupBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnScan = New System.Windows.Forms.Button()
        Me.CBoxModel = New System.Windows.Forms.ComboBox()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.GBoxEndorsmentData = New System.Windows.Forms.GroupBox()
        Me.LblNewQty = New System.Windows.Forms.Label()
        Me.LblNewEndorsedQty = New System.Windows.Forms.Label()
        Me.LblTotalQty = New System.Windows.Forms.Label()
        Me.LblTotalEndorsedQty = New System.Windows.Forms.Label()
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
        Me.GBoxRcvEndtData = New System.Windows.Forms.GroupBox()
        Me.DGVRcvEndtData = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblEndtTotalQty = New System.Windows.Forms.Label()
        Me.LblRcvEndtTotalQty = New System.Windows.Forms.Label()
        Me.GBoxRcvSearchInfo = New System.Windows.Forms.GroupBox()
        Me.BtnRcvReset = New System.Windows.Forms.Button()
        Me.lblRcvReceiverName = New System.Windows.Forms.Label()
        Me.LblRcvRcvdDate = New System.Windows.Forms.Label()
        Me.LblRcvReceiver = New System.Windows.Forms.Label()
        Me.LblRcvStatus = New System.Windows.Forms.Label()
        Me.LblRcvReceivedDateTitle = New System.Windows.Forms.Label()
        Me.BtnRcvSubmit = New System.Windows.Forms.Button()
        Me.BtnRcvCheckData = New System.Windows.Forms.Button()
        Me.LblRcvEndtNo = New System.Windows.Forms.Label()
        Me.TBoxRcvEndtNo = New System.Windows.Forms.TextBox()
        Me.LblRcvReceivedBy = New System.Windows.Forms.Label()
        Me.TBoxRcvReceivedBy = New System.Windows.Forms.TextBox()
        Me.TabPageTS = New System.Windows.Forms.TabPage()
        Me.LblTSDataQRCode = New System.Windows.Forms.Label()
        Me.LblTSTimeStamp = New System.Windows.Forms.Label()
        Me.LblTSDataSerialNumber = New System.Windows.Forms.Label()
        Me.BtnTSUpdate = New System.Windows.Forms.Button()
        Me.GBoxTSInformation = New System.Windows.Forms.GroupBox()
        Me.LblTSVerification = New System.Windows.Forms.Label()
        Me.BtnTSClear = New System.Windows.Forms.Button()
        Me.lblTSReceiverName = New System.Windows.Forms.Label()
        Me.LblTSReceiver = New System.Windows.Forms.Label()
        Me.LblTSRcvdDate = New System.Windows.Forms.Label()
        Me.LblTSReceivedDateTitle = New System.Windows.Forms.Label()
        Me.BtnTSSearch = New System.Windows.Forms.Button()
        Me.TboxTSSerialNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBoxTSData = New System.Windows.Forms.GroupBox()
        Me.LblRemarks = New System.Windows.Forms.Label()
        Me.LblDateRepaired = New System.Windows.Forms.Label()
        Me.TBoxTSRepairedBy = New System.Windows.Forms.TextBox()
        Me.LblRepairedBy = New System.Windows.Forms.Label()
        Me.TBoxTSStatus = New System.Windows.Forms.TextBox()
        Me.DTPTSDateRepaired = New System.Windows.Forms.DateTimePicker()
        Me.TBoxTSRemarks = New System.Windows.Forms.TextBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TBoxTSLocation2 = New System.Windows.Forms.TextBox()
        Me.LblLoc2 = New System.Windows.Forms.Label()
        Me.LblLoc3 = New System.Windows.Forms.Label()
        Me.TBoxTSLocation3 = New System.Windows.Forms.TextBox()
        Me.LblLoc4 = New System.Windows.Forms.Label()
        Me.LblLoc5 = New System.Windows.Forms.Label()
        Me.TBoxTSLocation5 = New System.Windows.Forms.TextBox()
        Me.TBoxTSLocation4 = New System.Windows.Forms.TextBox()
        Me.TabPageInquiry = New System.Windows.Forms.TabPage()
        Me.DTTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSTS = New Endorsement.DSTS()
        Me.ErrorProviderEndorsement = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPageEndorsement.SuspendLayout()
        Me.GBoxData.SuspendLayout()
        Me.GBoxInformation.SuspendLayout()
        Me.GBoxEndorsmentData.SuspendLayout()
        CType(Me.DGVEndorsementData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTEndorsementDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSEndorsementData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageReceiving.SuspendLayout()
        Me.GBoxRcvEndtData.SuspendLayout()
        CType(Me.DGVRcvEndtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxRcvSearchInfo.SuspendLayout()
        Me.TabPageTS.SuspendLayout()
        Me.GBoxTSInformation.SuspendLayout()
        Me.GBoxTSData.SuspendLayout()
        Me.TabPageInquiry.SuspendLayout()
        CType(Me.DTTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSTS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderEndorsement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblQtyEndorsed
        '
        Me.LblQtyEndorsed.AutoSize = True
        Me.LblQtyEndorsed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQtyEndorsed.Location = New System.Drawing.Point(6, 263)
        Me.LblQtyEndorsed.Name = "LblQtyEndorsed"
        Me.LblQtyEndorsed.Size = New System.Drawing.Size(103, 13)
        Me.LblQtyEndorsed.TabIndex = 12
        Me.LblQtyEndorsed.Text = "Quantity Endorsed"
        '
        'TBoxQtyEndorsed
        '
        Me.TBoxQtyEndorsed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxQtyEndorsed.Location = New System.Drawing.Point(6, 279)
        Me.TBoxQtyEndorsed.Name = "TBoxQtyEndorsed"
        Me.TBoxQtyEndorsed.Size = New System.Drawing.Size(123, 22)
        Me.TBoxQtyEndorsed.TabIndex = 13
        Me.TBoxQtyEndorsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblModel
        '
        Me.LblModel.AutoSize = True
        Me.LblModel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModel.Location = New System.Drawing.Point(6, 59)
        Me.LblModel.Name = "LblModel"
        Me.LblModel.Size = New System.Drawing.Size(40, 13)
        Me.LblModel.TabIndex = 2
        Me.LblModel.Text = "Model"
        '
        'LblSerialNo
        '
        Me.LblSerialNo.AutoSize = True
        Me.LblSerialNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSerialNo.Location = New System.Drawing.Point(6, 18)
        Me.LblSerialNo.Name = "LblSerialNo"
        Me.LblSerialNo.Size = New System.Drawing.Size(56, 13)
        Me.LblSerialNo.TabIndex = 0
        Me.LblSerialNo.Text = "Serial No."
        '
        'TBoxSerialNo
        '
        Me.TBoxSerialNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxSerialNo.Location = New System.Drawing.Point(6, 34)
        Me.TBoxSerialNo.Name = "TBoxSerialNo"
        Me.TBoxSerialNo.Size = New System.Drawing.Size(123, 22)
        Me.TBoxSerialNo.TabIndex = 1
        Me.TBoxSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPPONo
        '
        Me.LblPPONo.AutoSize = True
        Me.LblPPONo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPONo.Location = New System.Drawing.Point(6, 99)
        Me.LblPPONo.Name = "LblPPONo"
        Me.LblPPONo.Size = New System.Drawing.Size(72, 13)
        Me.LblPPONo.TabIndex = 4
        Me.LblPPONo.Text = "PPO Number"
        '
        'TBoxPPONo
        '
        Me.TBoxPPONo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxPPONo.Location = New System.Drawing.Point(6, 115)
        Me.TBoxPPONo.Name = "TBoxPPONo"
        Me.TBoxPPONo.Size = New System.Drawing.Size(123, 22)
        Me.TBoxPPONo.TabIndex = 5
        Me.TBoxPPONo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPPOQty
        '
        Me.LblPPOQty.AutoSize = True
        Me.LblPPOQty.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPOQty.Location = New System.Drawing.Point(6, 140)
        Me.LblPPOQty.Name = "LblPPOQty"
        Me.LblPPOQty.Size = New System.Drawing.Size(75, 13)
        Me.LblPPOQty.TabIndex = 6
        Me.LblPPOQty.Text = "PPO Quantity"
        '
        'TBoxPPOQty
        '
        Me.TBoxPPOQty.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxPPOQty.Location = New System.Drawing.Point(6, 156)
        Me.TBoxPPOQty.Name = "TBoxPPOQty"
        Me.TBoxPPOQty.Size = New System.Drawing.Size(123, 22)
        Me.TBoxPPOQty.TabIndex = 7
        Me.TBoxPPOQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblLotNo
        '
        Me.LblLotNo.AutoSize = True
        Me.LblLotNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLotNo.Location = New System.Drawing.Point(6, 181)
        Me.LblLotNo.Name = "LblLotNo"
        Me.LblLotNo.Size = New System.Drawing.Size(67, 13)
        Me.LblLotNo.TabIndex = 8
        Me.LblLotNo.Text = "Lot Number"
        '
        'TBoxLotNo
        '
        Me.TBoxLotNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxLotNo.Location = New System.Drawing.Point(6, 197)
        Me.TBoxLotNo.Name = "TBoxLotNo"
        Me.TBoxLotNo.Size = New System.Drawing.Size(123, 22)
        Me.TBoxLotNo.TabIndex = 9
        Me.TBoxLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblWorkOrder
        '
        Me.LblWorkOrder.AutoSize = True
        Me.LblWorkOrder.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWorkOrder.Location = New System.Drawing.Point(6, 222)
        Me.LblWorkOrder.Name = "LblWorkOrder"
        Me.LblWorkOrder.Size = New System.Drawing.Size(68, 13)
        Me.LblWorkOrder.TabIndex = 10
        Me.LblWorkOrder.Text = "Work Order"
        '
        'TBoxWorkOrder
        '
        Me.TBoxWorkOrder.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxWorkOrder.Location = New System.Drawing.Point(6, 238)
        Me.TBoxWorkOrder.Name = "TBoxWorkOrder"
        Me.TBoxWorkOrder.Size = New System.Drawing.Size(123, 22)
        Me.TBoxWorkOrder.TabIndex = 11
        Me.TBoxWorkOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblStation
        '
        Me.LblStation.AutoSize = True
        Me.LblStation.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStation.Location = New System.Drawing.Point(149, 19)
        Me.LblStation.Name = "LblStation"
        Me.LblStation.Size = New System.Drawing.Size(44, 13)
        Me.LblStation.TabIndex = 2
        Me.LblStation.Text = "Station"
        '
        'LblFailureSymptoms
        '
        Me.LblFailureSymptoms.AutoSize = True
        Me.LblFailureSymptoms.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFailureSymptoms.Location = New System.Drawing.Point(292, 19)
        Me.LblFailureSymptoms.Name = "LblFailureSymptoms"
        Me.LblFailureSymptoms.Size = New System.Drawing.Size(97, 13)
        Me.LblFailureSymptoms.TabIndex = 4
        Me.LblFailureSymptoms.Text = "Failure Symptoms"
        '
        'TBoxFailureSymptoms
        '
        Me.TBoxFailureSymptoms.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxFailureSymptoms.Location = New System.Drawing.Point(292, 34)
        Me.TBoxFailureSymptoms.Name = "TBoxFailureSymptoms"
        Me.TBoxFailureSymptoms.Size = New System.Drawing.Size(123, 22)
        Me.TBoxFailureSymptoms.TabIndex = 5
        Me.TBoxFailureSymptoms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblEndorsedBy
        '
        Me.LblEndorsedBy.AutoSize = True
        Me.LblEndorsedBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndorsedBy.Location = New System.Drawing.Point(6, 18)
        Me.LblEndorsedBy.Name = "LblEndorsedBy"
        Me.LblEndorsedBy.Size = New System.Drawing.Size(74, 13)
        Me.LblEndorsedBy.TabIndex = 0
        Me.LblEndorsedBy.Text = "Endorsed by:"
        '
        'TBoxEndorsedBy
        '
        Me.TBoxEndorsedBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxEndorsedBy.Location = New System.Drawing.Point(6, 34)
        Me.TBoxEndorsedBy.Name = "TBoxEndorsedBy"
        Me.TBoxEndorsedBy.Size = New System.Drawing.Size(123, 22)
        Me.TBoxEndorsedBy.TabIndex = 1
        Me.TBoxEndorsedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblDateFailed
        '
        Me.LblDateFailed.AutoSize = True
        Me.LblDateFailed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDateFailed.Location = New System.Drawing.Point(6, 304)
        Me.LblDateFailed.Name = "LblDateFailed"
        Me.LblDateFailed.Size = New System.Drawing.Size(65, 13)
        Me.LblDateFailed.TabIndex = 14
        Me.LblDateFailed.Text = "Date Failed"
        '
        'LblEndorsementDate
        '
        Me.LblEndorsementDate.AutoSize = True
        Me.LblEndorsementDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndorsementDate.Location = New System.Drawing.Point(6, 345)
        Me.LblEndorsementDate.Name = "LblEndorsementDate"
        Me.LblEndorsementDate.Size = New System.Drawing.Size(102, 13)
        Me.LblEndorsementDate.TabIndex = 16
        Me.LblEndorsementDate.Text = "Endorsement Date"
        '
        'LblWorkWeek
        '
        Me.LblWorkWeek.AutoSize = True
        Me.LblWorkWeek.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWorkWeek.Location = New System.Drawing.Point(6, 386)
        Me.LblWorkWeek.Name = "LblWorkWeek"
        Me.LblWorkWeek.Size = New System.Drawing.Size(62, 13)
        Me.LblWorkWeek.TabIndex = 18
        Me.LblWorkWeek.Text = "Workweek"
        '
        'TBoxWorkweek
        '
        Me.TBoxWorkweek.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxWorkweek.Location = New System.Drawing.Point(6, 402)
        Me.TBoxWorkweek.Name = "TBoxWorkweek"
        Me.TBoxWorkweek.ReadOnly = True
        Me.TBoxWorkweek.Size = New System.Drawing.Size(123, 22)
        Me.TBoxWorkweek.TabIndex = 19
        Me.TBoxWorkweek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblAnalysis
        '
        Me.LblAnalysis.AutoSize = True
        Me.LblAnalysis.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnalysis.Location = New System.Drawing.Point(6, 18)
        Me.LblAnalysis.Name = "LblAnalysis"
        Me.LblAnalysis.Size = New System.Drawing.Size(48, 13)
        Me.LblAnalysis.TabIndex = 0
        Me.LblAnalysis.Text = "Analysis"
        '
        'TBoxTSAnalysis
        '
        Me.TBoxTSAnalysis.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSAnalysis.Location = New System.Drawing.Point(6, 34)
        Me.TBoxTSAnalysis.Name = "TBoxTSAnalysis"
        Me.TBoxTSAnalysis.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSAnalysis.TabIndex = 1
        Me.TBoxTSAnalysis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblActionTaken
        '
        Me.LblActionTaken.AutoSize = True
        Me.LblActionTaken.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblActionTaken.Location = New System.Drawing.Point(6, 100)
        Me.LblActionTaken.Name = "LblActionTaken"
        Me.LblActionTaken.Size = New System.Drawing.Size(73, 13)
        Me.LblActionTaken.TabIndex = 4
        Me.LblActionTaken.Text = "Action Taken"
        '
        'TBoxTSActionTaken
        '
        Me.TBoxTSActionTaken.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSActionTaken.Location = New System.Drawing.Point(6, 116)
        Me.TBoxTSActionTaken.Name = "TBoxTSActionTaken"
        Me.TBoxTSActionTaken.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSActionTaken.TabIndex = 5
        Me.TBoxTSActionTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblLoc1
        '
        Me.LblLoc1.AutoSize = True
        Me.LblLoc1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLoc1.Location = New System.Drawing.Point(6, 141)
        Me.LblLoc1.Name = "LblLoc1"
        Me.LblLoc1.Size = New System.Drawing.Size(60, 13)
        Me.LblLoc1.TabIndex = 6
        Me.LblLoc1.Text = "Location 1"
        '
        'TBoxTSLocation1
        '
        Me.TBoxTSLocation1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSLocation1.Location = New System.Drawing.Point(6, 157)
        Me.TBoxTSLocation1.Name = "TBoxTSLocation1"
        Me.TBoxTSLocation1.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSLocation1.TabIndex = 7
        Me.TBoxTSLocation1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblDefectType
        '
        Me.LblDefectType.AutoSize = True
        Me.LblDefectType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefectType.Location = New System.Drawing.Point(6, 59)
        Me.LblDefectType.Name = "LblDefectType"
        Me.LblDefectType.Size = New System.Drawing.Size(66, 13)
        Me.LblDefectType.TabIndex = 2
        Me.LblDefectType.Text = "Defect Type"
        '
        'TBoxTSDefectType
        '
        Me.TBoxTSDefectType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSDefectType.Location = New System.Drawing.Point(6, 75)
        Me.TBoxTSDefectType.Name = "TBoxTSDefectType"
        Me.TBoxTSDefectType.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSDefectType.TabIndex = 3
        Me.TBoxTSDefectType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DTPDateFailed
        '
        Me.DTPDateFailed.Checked = False
        Me.DTPDateFailed.CustomFormat = "MMM dd, yyyy"
        Me.DTPDateFailed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPDateFailed.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPDateFailed.Location = New System.Drawing.Point(6, 320)
        Me.DTPDateFailed.Name = "DTPDateFailed"
        Me.DTPDateFailed.Size = New System.Drawing.Size(123, 22)
        Me.DTPDateFailed.TabIndex = 15
        '
        'DTPEndorsementDate
        '
        Me.DTPEndorsementDate.Checked = False
        Me.DTPEndorsementDate.CustomFormat = "MMM dd, yyyy"
        Me.DTPEndorsementDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEndorsementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPEndorsementDate.Location = New System.Drawing.Point(6, 361)
        Me.DTPEndorsementDate.Name = "DTPEndorsementDate"
        Me.DTPEndorsementDate.Size = New System.Drawing.Size(123, 22)
        Me.DTPEndorsementDate.TabIndex = 17
        '
        'BtnEndorse
        '
        Me.BtnEndorse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEndorse.Location = New System.Drawing.Point(421, 32)
        Me.BtnEndorse.Name = "BtnEndorse"
        Me.BtnEndorse.Size = New System.Drawing.Size(59, 26)
        Me.BtnEndorse.TabIndex = 6
        Me.BtnEndorse.Text = "Endorse"
        Me.BtnEndorse.UseVisualStyleBackColor = True
        '
        'BtnInformationClear
        '
        Me.BtnInformationClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInformationClear.Location = New System.Drawing.Point(70, 430)
        Me.BtnInformationClear.Name = "BtnInformationClear"
        Me.BtnInformationClear.Size = New System.Drawing.Size(59, 26)
        Me.BtnInformationClear.TabIndex = 21
        Me.BtnInformationClear.Text = "Clear"
        Me.BtnInformationClear.UseVisualStyleBackColor = True
        '
        'LblEndorsementNo
        '
        Me.LblEndorsementNo.AutoSize = True
        Me.LblEndorsementNo.Location = New System.Drawing.Point(6, 11)
        Me.LblEndorsementNo.Name = "LblEndorsementNo"
        Me.LblEndorsementNo.Size = New System.Drawing.Size(96, 13)
        Me.LblEndorsementNo.TabIndex = 0
        Me.LblEndorsementNo.Text = "Endorsement No."
        '
        'TboxEndorsementNo
        '
        Me.TboxEndorsementNo.Location = New System.Drawing.Point(108, 6)
        Me.TboxEndorsementNo.Name = "TboxEndorsementNo"
        Me.TboxEndorsementNo.ReadOnly = True
        Me.TboxEndorsementNo.Size = New System.Drawing.Size(47, 22)
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
        Me.TabControl1.Size = New System.Drawing.Size(1121, 568)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 1
        '
        'TabPageEndorsement
        '
        Me.TabPageEndorsement.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageEndorsement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TabPageEndorsement.Controls.Add(Me.ChkBoxEndtSerialNo)
        Me.TabPageEndorsement.Controls.Add(Me.BtnCancel)
        Me.TabPageEndorsement.Controls.Add(Me.GBoxData)
        Me.TabPageEndorsement.Controls.Add(Me.GBoxInformation)
        Me.TabPageEndorsement.Controls.Add(Me.BtnSubmit)
        Me.TabPageEndorsement.Controls.Add(Me.GBoxEndorsmentData)
        Me.TabPageEndorsement.Controls.Add(Me.LblEndorsementNo)
        Me.TabPageEndorsement.Controls.Add(Me.TboxEndorsementNo)
        Me.TabPageEndorsement.Location = New System.Drawing.Point(4, 22)
        Me.TabPageEndorsement.Name = "TabPageEndorsement"
        Me.TabPageEndorsement.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageEndorsement.Size = New System.Drawing.Size(1113, 542)
        Me.TabPageEndorsement.TabIndex = 0
        Me.TabPageEndorsement.Text = "Endorsement"
        '
        'ChkBoxEndtSerialNo
        '
        Me.ChkBoxEndtSerialNo.AutoSize = True
        Me.ChkBoxEndtSerialNo.Enabled = False
        Me.ChkBoxEndtSerialNo.Location = New System.Drawing.Point(161, 79)
        Me.ChkBoxEndtSerialNo.Name = "ChkBoxEndtSerialNo"
        Me.ChkBoxEndtSerialNo.Size = New System.Drawing.Size(114, 17)
        Me.ChkBoxEndtSerialNo.TabIndex = 6
        Me.ChkBoxEndtSerialNo.Text = "No serial number"
        Me.ChkBoxEndtSerialNo.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(980, 43)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(127, 30)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GBoxData
        '
        Me.GBoxData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxData.Controls.Add(Me.BtnReturn)
        Me.GBoxData.Controls.Add(Me.BtnEndorseAnotherModel)
        Me.GBoxData.Controls.Add(Me.CBoxStation)
        Me.GBoxData.Controls.Add(Me.BtnDataClear)
        Me.GBoxData.Controls.Add(Me.LblFailureSymptoms)
        Me.GBoxData.Controls.Add(Me.TBoxSerialNo)
        Me.GBoxData.Controls.Add(Me.LblStation)
        Me.GBoxData.Controls.Add(Me.TBoxFailureSymptoms)
        Me.GBoxData.Controls.Add(Me.BtnEndorse)
        Me.GBoxData.Controls.Add(Me.LblSerialNo)
        Me.GBoxData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxData.Location = New System.Drawing.Point(161, 6)
        Me.GBoxData.Name = "GBoxData"
        Me.GBoxData.Size = New System.Drawing.Size(813, 67)
        Me.GBoxData.TabIndex = 3
        Me.GBoxData.TabStop = False
        Me.GBoxData.Text = "Data"
        '
        'BtnReturn
        '
        Me.BtnReturn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReturn.Location = New System.Drawing.Point(551, 32)
        Me.BtnReturn.Name = "BtnReturn"
        Me.BtnReturn.Size = New System.Drawing.Size(92, 26)
        Me.BtnReturn.TabIndex = 9
        Me.BtnReturn.Text = "Return"
        Me.BtnReturn.UseVisualStyleBackColor = True
        '
        'BtnEndorseAnotherModel
        '
        Me.BtnEndorseAnotherModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEndorseAnotherModel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEndorseAnotherModel.Location = New System.Drawing.Point(667, 32)
        Me.BtnEndorseAnotherModel.Name = "BtnEndorseAnotherModel"
        Me.BtnEndorseAnotherModel.Size = New System.Drawing.Size(140, 26)
        Me.BtnEndorseAnotherModel.TabIndex = 8
        Me.BtnEndorseAnotherModel.Text = "Endorse Another"
        Me.BtnEndorseAnotherModel.UseVisualStyleBackColor = True
        '
        'CBoxStation
        '
        Me.CBoxStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxStation.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBoxStation.FormattingEnabled = True
        Me.CBoxStation.Location = New System.Drawing.Point(149, 35)
        Me.CBoxStation.Name = "CBoxStation"
        Me.CBoxStation.Size = New System.Drawing.Size(123, 21)
        Me.CBoxStation.TabIndex = 3
        '
        'BtnDataClear
        '
        Me.BtnDataClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDataClear.Location = New System.Drawing.Point(486, 32)
        Me.BtnDataClear.Name = "BtnDataClear"
        Me.BtnDataClear.Size = New System.Drawing.Size(59, 26)
        Me.BtnDataClear.TabIndex = 7
        Me.BtnDataClear.Text = "Clear"
        Me.BtnDataClear.UseVisualStyleBackColor = True
        '
        'GBoxInformation
        '
        Me.GBoxInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxInformation.Controls.Add(Me.BtnReset)
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
        Me.GBoxInformation.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxInformation.Location = New System.Drawing.Point(6, 34)
        Me.GBoxInformation.Name = "GBoxInformation"
        Me.GBoxInformation.Size = New System.Drawing.Size(149, 502)
        Me.GBoxInformation.TabIndex = 2
        Me.GBoxInformation.TabStop = False
        Me.GBoxInformation.Text = "Information"
        '
        'BtnReset
        '
        Me.BtnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReset.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReset.Location = New System.Drawing.Point(6, 462)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(123, 30)
        Me.BtnReset.TabIndex = 22
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnScan
        '
        Me.BtnScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnScan.Location = New System.Drawing.Point(6, 430)
        Me.BtnScan.Name = "BtnScan"
        Me.BtnScan.Size = New System.Drawing.Size(59, 26)
        Me.BtnScan.TabIndex = 20
        Me.BtnScan.Text = "Scan"
        Me.BtnScan.UseVisualStyleBackColor = True
        '
        'CBoxModel
        '
        Me.CBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxModel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBoxModel.FormattingEnabled = True
        Me.CBoxModel.Location = New System.Drawing.Point(6, 75)
        Me.CBoxModel.Name = "CBoxModel"
        Me.CBoxModel.Size = New System.Drawing.Size(123, 21)
        Me.CBoxModel.TabIndex = 3
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSubmit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(980, 11)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(127, 30)
        Me.BtnSubmit.TabIndex = 4
        Me.BtnSubmit.Text = "Submit"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'GBoxEndorsmentData
        '
        Me.GBoxEndorsmentData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxEndorsmentData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GBoxEndorsmentData.Controls.Add(Me.LblNewQty)
        Me.GBoxEndorsmentData.Controls.Add(Me.LblNewEndorsedQty)
        Me.GBoxEndorsmentData.Controls.Add(Me.LblTotalQty)
        Me.GBoxEndorsmentData.Controls.Add(Me.LblTotalEndorsedQty)
        Me.GBoxEndorsmentData.Controls.Add(Me.DGVEndorsementData)
        Me.GBoxEndorsmentData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxEndorsmentData.Location = New System.Drawing.Point(161, 101)
        Me.GBoxEndorsmentData.Margin = New System.Windows.Forms.Padding(2)
        Me.GBoxEndorsmentData.Name = "GBoxEndorsmentData"
        Me.GBoxEndorsmentData.Padding = New System.Windows.Forms.Padding(2)
        Me.GBoxEndorsmentData.Size = New System.Drawing.Size(949, 436)
        Me.GBoxEndorsmentData.TabIndex = 7
        Me.GBoxEndorsmentData.TabStop = False
        Me.GBoxEndorsmentData.Text = "Endorsement Data"
        '
        'LblNewQty
        '
        Me.LblNewQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblNewQty.AutoSize = True
        Me.LblNewQty.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewQty.Location = New System.Drawing.Point(144, 417)
        Me.LblNewQty.Name = "LblNewQty"
        Me.LblNewQty.Size = New System.Drawing.Size(13, 15)
        Me.LblNewQty.TabIndex = 2
        Me.LblNewQty.Text = "0"
        '
        'LblNewEndorsedQty
        '
        Me.LblNewEndorsedQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblNewEndorsedQty.AutoSize = True
        Me.LblNewEndorsedQty.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewEndorsedQty.Location = New System.Drawing.Point(5, 417)
        Me.LblNewEndorsedQty.Name = "LblNewEndorsedQty"
        Me.LblNewEndorsedQty.Size = New System.Drawing.Size(133, 15)
        Me.LblNewEndorsedQty.TabIndex = 1
        Me.LblNewEndorsedQty.Text = "New endorsed quantity:"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.Location = New System.Drawing.Point(908, 416)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(13, 15)
        Me.LblTotalQty.TabIndex = 4
        Me.LblTotalQty.Text = "0"
        '
        'LblTotalEndorsedQty
        '
        Me.LblTotalEndorsedQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalEndorsedQty.AutoSize = True
        Me.LblTotalEndorsedQty.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalEndorsedQty.Location = New System.Drawing.Point(767, 416)
        Me.LblTotalEndorsedQty.Name = "LblTotalEndorsedQty"
        Me.LblTotalEndorsedQty.Size = New System.Drawing.Size(135, 15)
        Me.LblTotalEndorsedQty.TabIndex = 3
        Me.LblTotalEndorsedQty.Text = "Total endorsed quantity:"
        '
        'DGVEndorsementData
        '
        Me.DGVEndorsementData.AllowUserToAddRows = False
        Me.DGVEndorsementData.AllowUserToDeleteRows = False
        Me.DGVEndorsementData.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DGVEndorsementData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVEndorsementData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVEndorsementData.AutoGenerateColumns = False
        Me.DGVEndorsementData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVEndorsementData.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVEndorsementData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVEndorsementData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVEndorsementData.ColumnHeadersHeight = 20
        Me.DGVEndorsementData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20})
        Me.DGVEndorsementData.DataSource = Me.DTEndorsementDataBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVEndorsementData.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVEndorsementData.Location = New System.Drawing.Point(5, 20)
        Me.DGVEndorsementData.Name = "DGVEndorsementData"
        Me.DGVEndorsementData.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVEndorsementData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVEndorsementData.RowHeadersVisible = False
        Me.DGVEndorsementData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVEndorsementData.Size = New System.Drawing.Size(941, 394)
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
        Me.TabPageReceiving.Controls.Add(Me.GBoxRcvEndtData)
        Me.TabPageReceiving.Controls.Add(Me.LblEndtTotalQty)
        Me.TabPageReceiving.Controls.Add(Me.LblRcvEndtTotalQty)
        Me.TabPageReceiving.Controls.Add(Me.GBoxRcvSearchInfo)
        Me.TabPageReceiving.Location = New System.Drawing.Point(4, 22)
        Me.TabPageReceiving.Name = "TabPageReceiving"
        Me.TabPageReceiving.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageReceiving.Size = New System.Drawing.Size(1113, 542)
        Me.TabPageReceiving.TabIndex = 3
        Me.TabPageReceiving.Text = "Receiving"
        '
        'GBoxRcvEndtData
        '
        Me.GBoxRcvEndtData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxRcvEndtData.Controls.Add(Me.DGVRcvEndtData)
        Me.GBoxRcvEndtData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxRcvEndtData.Location = New System.Drawing.Point(6, 80)
        Me.GBoxRcvEndtData.Name = "GBoxRcvEndtData"
        Me.GBoxRcvEndtData.Size = New System.Drawing.Size(1101, 431)
        Me.GBoxRcvEndtData.TabIndex = 1
        Me.GBoxRcvEndtData.TabStop = False
        Me.GBoxRcvEndtData.Text = "Endorsement Data"
        '
        'DGVRcvEndtData
        '
        Me.DGVRcvEndtData.AllowUserToAddRows = False
        Me.DGVRcvEndtData.AllowUserToDeleteRows = False
        Me.DGVRcvEndtData.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DGVRcvEndtData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGVRcvEndtData.AutoGenerateColumns = False
        Me.DGVRcvEndtData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVRcvEndtData.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVRcvEndtData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVRcvEndtData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVRcvEndtData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVRcvEndtData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30})
        Me.DGVRcvEndtData.DataSource = Me.DTEndorsementDataBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVRcvEndtData.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGVRcvEndtData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVRcvEndtData.Location = New System.Drawing.Point(3, 18)
        Me.DGVRcvEndtData.Name = "DGVRcvEndtData"
        Me.DGVRcvEndtData.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVRcvEndtData.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGVRcvEndtData.RowHeadersVisible = False
        Me.DGVRcvEndtData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVRcvEndtData.Size = New System.Drawing.Size(1095, 410)
        Me.DGVRcvEndtData.TabIndex = 0
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn21.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn21.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "model"
        Me.DataGridViewTextBoxColumn22.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn22.HeaderText = "Model"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "serial_no"
        Me.DataGridViewTextBoxColumn23.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn23.HeaderText = "Serial No"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "ppo_no"
        Me.DataGridViewTextBoxColumn24.HeaderText = "PPO No"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "ppo_qty"
        Me.DataGridViewTextBoxColumn25.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn25.HeaderText = "PPO Qty"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "lot_no"
        Me.DataGridViewTextBoxColumn26.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn26.HeaderText = "Lot No"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "work_order"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Work Order"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "station"
        Me.DataGridViewTextBoxColumn28.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn28.HeaderText = "Station"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "failure_symptoms"
        Me.DataGridViewTextBoxColumn29.FillWeight = 130.0!
        Me.DataGridViewTextBoxColumn29.HeaderText = "Failure Symptoms"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "endorsed_by"
        Me.DataGridViewTextBoxColumn30.HeaderText = "Endorsed By"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'LblEndtTotalQty
        '
        Me.LblEndtTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEndtTotalQty.AutoSize = True
        Me.LblEndtTotalQty.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndtTotalQty.Location = New System.Drawing.Point(1064, 514)
        Me.LblEndtTotalQty.Name = "LblEndtTotalQty"
        Me.LblEndtTotalQty.Size = New System.Drawing.Size(13, 15)
        Me.LblEndtTotalQty.TabIndex = 3
        Me.LblEndtTotalQty.Text = "0"
        '
        'LblRcvEndtTotalQty
        '
        Me.LblRcvEndtTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRcvEndtTotalQty.AutoSize = True
        Me.LblRcvEndtTotalQty.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvEndtTotalQty.Location = New System.Drawing.Point(952, 514)
        Me.LblRcvEndtTotalQty.Name = "LblRcvEndtTotalQty"
        Me.LblRcvEndtTotalQty.Size = New System.Drawing.Size(106, 15)
        Me.LblRcvEndtTotalQty.TabIndex = 2
        Me.LblRcvEndtTotalQty.Text = "Endorsed quantity:"
        '
        'GBoxRcvSearchInfo
        '
        Me.GBoxRcvSearchInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.BtnRcvReset)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.lblRcvReceiverName)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.LblRcvRcvdDate)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.LblRcvReceiver)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.LblRcvStatus)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.LblRcvReceivedDateTitle)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.BtnRcvSubmit)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.BtnRcvCheckData)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.LblRcvEndtNo)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.TBoxRcvEndtNo)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.LblRcvReceivedBy)
        Me.GBoxRcvSearchInfo.Controls.Add(Me.TBoxRcvReceivedBy)
        Me.GBoxRcvSearchInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxRcvSearchInfo.Location = New System.Drawing.Point(6, 6)
        Me.GBoxRcvSearchInfo.Name = "GBoxRcvSearchInfo"
        Me.GBoxRcvSearchInfo.Size = New System.Drawing.Size(1101, 68)
        Me.GBoxRcvSearchInfo.TabIndex = 0
        Me.GBoxRcvSearchInfo.TabStop = False
        Me.GBoxRcvSearchInfo.Text = "Search Information"
        '
        'BtnRcvReset
        '
        Me.BtnRcvReset.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRcvReset.Location = New System.Drawing.Point(416, 32)
        Me.BtnRcvReset.Name = "BtnRcvReset"
        Me.BtnRcvReset.Size = New System.Drawing.Size(59, 26)
        Me.BtnRcvReset.TabIndex = 6
        Me.BtnRcvReset.Text = "Reset"
        Me.BtnRcvReset.UseVisualStyleBackColor = True
        '
        'lblRcvReceiverName
        '
        Me.lblRcvReceiverName.AutoSize = True
        Me.lblRcvReceiverName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRcvReceiverName.Location = New System.Drawing.Point(935, 39)
        Me.lblRcvReceiverName.Name = "lblRcvReceiverName"
        Me.lblRcvReceiverName.Size = New System.Drawing.Size(62, 21)
        Me.lblRcvReceiverName.TabIndex = 11
        Me.lblRcvReceiverName.Text = "MACKY"
        Me.lblRcvReceiverName.Visible = False
        '
        'LblRcvRcvdDate
        '
        Me.LblRcvRcvdDate.AutoSize = True
        Me.LblRcvRcvdDate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvRcvdDate.Location = New System.Drawing.Point(935, 18)
        Me.LblRcvRcvdDate.Name = "LblRcvRcvdDate"
        Me.LblRcvRcvdDate.Size = New System.Drawing.Size(137, 21)
        Me.LblRcvRcvdDate.TabIndex = 10
        Me.LblRcvRcvdDate.Text = "February 28, 2024"
        Me.LblRcvRcvdDate.Visible = False
        '
        'LblRcvReceiver
        '
        Me.LblRcvReceiver.AutoSize = True
        Me.LblRcvReceiver.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvReceiver.Location = New System.Drawing.Point(833, 39)
        Me.LblRcvReceiver.Name = "LblRcvReceiver"
        Me.LblRcvReceiver.Size = New System.Drawing.Size(96, 21)
        Me.LblRcvReceiver.TabIndex = 9
        Me.LblRcvReceiver.Text = "Received by:"
        Me.LblRcvReceiver.Visible = False
        '
        'LblRcvStatus
        '
        Me.LblRcvStatus.AutoSize = True
        Me.LblRcvStatus.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvStatus.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblRcvStatus.Location = New System.Drawing.Point(484, 12)
        Me.LblRcvStatus.Name = "LblRcvStatus"
        Me.LblRcvStatus.Size = New System.Drawing.Size(328, 47)
        Me.LblRcvStatus.TabIndex = 7
        Me.LblRcvStatus.Text = "ALREADY RECEIVED"
        Me.LblRcvStatus.Visible = False
        '
        'LblRcvReceivedDateTitle
        '
        Me.LblRcvReceivedDateTitle.AutoSize = True
        Me.LblRcvReceivedDateTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvReceivedDateTitle.Location = New System.Drawing.Point(818, 18)
        Me.LblRcvReceivedDateTitle.Name = "LblRcvReceivedDateTitle"
        Me.LblRcvReceivedDateTitle.Size = New System.Drawing.Size(111, 21)
        Me.LblRcvReceivedDateTitle.TabIndex = 8
        Me.LblRcvReceivedDateTitle.Text = "Received Date:"
        Me.LblRcvReceivedDateTitle.Visible = False
        '
        'BtnRcvSubmit
        '
        Me.BtnRcvSubmit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRcvSubmit.Location = New System.Drawing.Point(351, 32)
        Me.BtnRcvSubmit.Name = "BtnRcvSubmit"
        Me.BtnRcvSubmit.Size = New System.Drawing.Size(59, 26)
        Me.BtnRcvSubmit.TabIndex = 5
        Me.BtnRcvSubmit.Text = "Submit"
        Me.BtnRcvSubmit.UseVisualStyleBackColor = True
        '
        'BtnRcvCheckData
        '
        Me.BtnRcvCheckData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRcvCheckData.Location = New System.Drawing.Point(135, 32)
        Me.BtnRcvCheckData.Name = "BtnRcvCheckData"
        Me.BtnRcvCheckData.Size = New System.Drawing.Size(81, 26)
        Me.BtnRcvCheckData.TabIndex = 2
        Me.BtnRcvCheckData.Text = "Check Data"
        Me.BtnRcvCheckData.UseVisualStyleBackColor = True
        '
        'LblRcvEndtNo
        '
        Me.LblRcvEndtNo.AutoSize = True
        Me.LblRcvEndtNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvEndtNo.Location = New System.Drawing.Point(6, 18)
        Me.LblRcvEndtNo.Name = "LblRcvEndtNo"
        Me.LblRcvEndtNo.Size = New System.Drawing.Size(96, 13)
        Me.LblRcvEndtNo.TabIndex = 0
        Me.LblRcvEndtNo.Text = "Endorsement No."
        '
        'TBoxRcvEndtNo
        '
        Me.TBoxRcvEndtNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxRcvEndtNo.Location = New System.Drawing.Point(6, 34)
        Me.TBoxRcvEndtNo.Name = "TBoxRcvEndtNo"
        Me.TBoxRcvEndtNo.Size = New System.Drawing.Size(123, 22)
        Me.TBoxRcvEndtNo.TabIndex = 1
        Me.TBoxRcvEndtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblRcvReceivedBy
        '
        Me.LblRcvReceivedBy.AutoSize = True
        Me.LblRcvReceivedBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcvReceivedBy.Location = New System.Drawing.Point(222, 18)
        Me.LblRcvReceivedBy.Name = "LblRcvReceivedBy"
        Me.LblRcvReceivedBy.Size = New System.Drawing.Size(69, 13)
        Me.LblRcvReceivedBy.TabIndex = 3
        Me.LblRcvReceivedBy.Text = "Received By:"
        '
        'TBoxRcvReceivedBy
        '
        Me.TBoxRcvReceivedBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxRcvReceivedBy.Location = New System.Drawing.Point(222, 34)
        Me.TBoxRcvReceivedBy.Name = "TBoxRcvReceivedBy"
        Me.TBoxRcvReceivedBy.Size = New System.Drawing.Size(123, 22)
        Me.TBoxRcvReceivedBy.TabIndex = 4
        Me.TBoxRcvReceivedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPageTS
        '
        Me.TabPageTS.Controls.Add(Me.LblTSDataQRCode)
        Me.TabPageTS.Controls.Add(Me.LblTSTimeStamp)
        Me.TabPageTS.Controls.Add(Me.LblTSDataSerialNumber)
        Me.TabPageTS.Controls.Add(Me.BtnTSUpdate)
        Me.TabPageTS.Controls.Add(Me.GBoxTSInformation)
        Me.TabPageTS.Controls.Add(Me.GBoxTSData)
        Me.TabPageTS.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTS.Name = "TabPageTS"
        Me.TabPageTS.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTS.Size = New System.Drawing.Size(1113, 542)
        Me.TabPageTS.TabIndex = 1
        Me.TabPageTS.Text = "TS"
        '
        'LblTSDataQRCode
        '
        Me.LblTSDataQRCode.AutoSize = True
        Me.LblTSDataQRCode.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSDataQRCode.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTSDataQRCode.Location = New System.Drawing.Point(239, 79)
        Me.LblTSDataQRCode.Name = "LblTSDataQRCode"
        Me.LblTSDataQRCode.Size = New System.Drawing.Size(131, 37)
        Me.LblTSDataQRCode.TabIndex = 2
        Me.LblTSDataQRCode.Text = "QR CODE"
        Me.LblTSDataQRCode.Visible = False
        '
        'LblTSTimeStamp
        '
        Me.LblTSTimeStamp.AutoSize = True
        Me.LblTSTimeStamp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSTimeStamp.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTSTimeStamp.Location = New System.Drawing.Point(6, 312)
        Me.LblTSTimeStamp.Name = "LblTSTimeStamp"
        Me.LblTSTimeStamp.Size = New System.Drawing.Size(203, 17)
        Me.LblTSTimeStamp.TabIndex = 4
        Me.LblTSTimeStamp.Text = "Last update: March 25, 2024 21:23"
        Me.LblTSTimeStamp.Visible = False
        '
        'LblTSDataSerialNumber
        '
        Me.LblTSDataSerialNumber.AutoSize = True
        Me.LblTSDataSerialNumber.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSDataSerialNumber.Location = New System.Drawing.Point(5, 79)
        Me.LblTSDataSerialNumber.Name = "LblTSDataSerialNumber"
        Me.LblTSDataSerialNumber.Size = New System.Drawing.Size(228, 37)
        Me.LblTSDataSerialNumber.TabIndex = 1
        Me.LblTSDataSerialNumber.Text = "SERIAL NUMBER:"
        '
        'BtnTSUpdate
        '
        Me.BtnTSUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTSUpdate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTSUpdate.Location = New System.Drawing.Point(1026, 315)
        Me.BtnTSUpdate.Name = "BtnTSUpdate"
        Me.BtnTSUpdate.Size = New System.Drawing.Size(81, 26)
        Me.BtnTSUpdate.TabIndex = 5
        Me.BtnTSUpdate.Text = "Update"
        Me.BtnTSUpdate.UseVisualStyleBackColor = True
        '
        'GBoxTSInformation
        '
        Me.GBoxTSInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxTSInformation.Controls.Add(Me.LblTSVerification)
        Me.GBoxTSInformation.Controls.Add(Me.BtnTSClear)
        Me.GBoxTSInformation.Controls.Add(Me.lblTSReceiverName)
        Me.GBoxTSInformation.Controls.Add(Me.LblTSReceiver)
        Me.GBoxTSInformation.Controls.Add(Me.LblTSRcvdDate)
        Me.GBoxTSInformation.Controls.Add(Me.LblTSReceivedDateTitle)
        Me.GBoxTSInformation.Controls.Add(Me.BtnTSSearch)
        Me.GBoxTSInformation.Controls.Add(Me.TboxTSSerialNo)
        Me.GBoxTSInformation.Controls.Add(Me.Label1)
        Me.GBoxTSInformation.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxTSInformation.Location = New System.Drawing.Point(6, 6)
        Me.GBoxTSInformation.Name = "GBoxTSInformation"
        Me.GBoxTSInformation.Size = New System.Drawing.Size(1101, 70)
        Me.GBoxTSInformation.TabIndex = 0
        Me.GBoxTSInformation.TabStop = False
        Me.GBoxTSInformation.Text = "Information"
        '
        'LblTSVerification
        '
        Me.LblTSVerification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTSVerification.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSVerification.ForeColor = System.Drawing.Color.DarkRed
        Me.LblTSVerification.Location = New System.Drawing.Point(319, 12)
        Me.LblTSVerification.Name = "LblTSVerification"
        Me.LblTSVerification.Size = New System.Drawing.Size(493, 47)
        Me.LblTSVerification.TabIndex = 4
        Me.LblTSVerification.Text = "UNVERIFIED"
        Me.LblTSVerification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTSVerification.Visible = False
        '
        'BtnTSClear
        '
        Me.BtnTSClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTSClear.Location = New System.Drawing.Point(232, 32)
        Me.BtnTSClear.Name = "BtnTSClear"
        Me.BtnTSClear.Size = New System.Drawing.Size(81, 26)
        Me.BtnTSClear.TabIndex = 3
        Me.BtnTSClear.Text = "Clear"
        Me.BtnTSClear.UseVisualStyleBackColor = True
        '
        'lblTSReceiverName
        '
        Me.lblTSReceiverName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTSReceiverName.AutoSize = True
        Me.lblTSReceiverName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSReceiverName.Location = New System.Drawing.Point(935, 39)
        Me.lblTSReceiverName.Name = "lblTSReceiverName"
        Me.lblTSReceiverName.Size = New System.Drawing.Size(62, 21)
        Me.lblTSReceiverName.TabIndex = 8
        Me.lblTSReceiverName.Text = "MACKY"
        Me.lblTSReceiverName.Visible = False
        '
        'LblTSReceiver
        '
        Me.LblTSReceiver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTSReceiver.AutoSize = True
        Me.LblTSReceiver.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSReceiver.Location = New System.Drawing.Point(833, 39)
        Me.LblTSReceiver.Name = "LblTSReceiver"
        Me.LblTSReceiver.Size = New System.Drawing.Size(96, 21)
        Me.LblTSReceiver.TabIndex = 6
        Me.LblTSReceiver.Text = "Received by:"
        Me.LblTSReceiver.Visible = False
        '
        'LblTSRcvdDate
        '
        Me.LblTSRcvdDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTSRcvdDate.AutoSize = True
        Me.LblTSRcvdDate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSRcvdDate.Location = New System.Drawing.Point(935, 18)
        Me.LblTSRcvdDate.Name = "LblTSRcvdDate"
        Me.LblTSRcvdDate.Size = New System.Drawing.Size(137, 21)
        Me.LblTSRcvdDate.TabIndex = 7
        Me.LblTSRcvdDate.Text = "February 28, 2024"
        Me.LblTSRcvdDate.Visible = False
        '
        'LblTSReceivedDateTitle
        '
        Me.LblTSReceivedDateTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTSReceivedDateTitle.AutoSize = True
        Me.LblTSReceivedDateTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTSReceivedDateTitle.Location = New System.Drawing.Point(818, 18)
        Me.LblTSReceivedDateTitle.Name = "LblTSReceivedDateTitle"
        Me.LblTSReceivedDateTitle.Size = New System.Drawing.Size(111, 21)
        Me.LblTSReceivedDateTitle.TabIndex = 5
        Me.LblTSReceivedDateTitle.Text = "Received Date:"
        Me.LblTSReceivedDateTitle.Visible = False
        '
        'BtnTSSearch
        '
        Me.BtnTSSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTSSearch.Location = New System.Drawing.Point(145, 32)
        Me.BtnTSSearch.Name = "BtnTSSearch"
        Me.BtnTSSearch.Size = New System.Drawing.Size(81, 26)
        Me.BtnTSSearch.TabIndex = 2
        Me.BtnTSSearch.Text = "Search"
        Me.BtnTSSearch.UseVisualStyleBackColor = True
        '
        'TboxTSSerialNo
        '
        Me.TboxTSSerialNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TboxTSSerialNo.Location = New System.Drawing.Point(6, 34)
        Me.TboxTSSerialNo.Name = "TboxTSSerialNo"
        Me.TboxTSSerialNo.Size = New System.Drawing.Size(123, 22)
        Me.TboxTSSerialNo.TabIndex = 1
        Me.TboxTSSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serial No."
        '
        'GBoxTSData
        '
        Me.GBoxTSData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBoxTSData.BackColor = System.Drawing.SystemColors.Control
        Me.GBoxTSData.Controls.Add(Me.LblRemarks)
        Me.GBoxTSData.Controls.Add(Me.LblDateRepaired)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSRepairedBy)
        Me.GBoxTSData.Controls.Add(Me.LblRepairedBy)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSStatus)
        Me.GBoxTSData.Controls.Add(Me.DTPTSDateRepaired)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSRemarks)
        Me.GBoxTSData.Controls.Add(Me.LblStatus)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSLocation2)
        Me.GBoxTSData.Controls.Add(Me.LblLoc2)
        Me.GBoxTSData.Controls.Add(Me.LblLoc3)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSLocation3)
        Me.GBoxTSData.Controls.Add(Me.LblLoc4)
        Me.GBoxTSData.Controls.Add(Me.LblLoc5)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSLocation5)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSLocation4)
        Me.GBoxTSData.Controls.Add(Me.LblLoc1)
        Me.GBoxTSData.Controls.Add(Me.LblAnalysis)
        Me.GBoxTSData.Controls.Add(Me.LblDefectType)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSLocation1)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSDefectType)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSActionTaken)
        Me.GBoxTSData.Controls.Add(Me.TBoxTSAnalysis)
        Me.GBoxTSData.Controls.Add(Me.LblActionTaken)
        Me.GBoxTSData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxTSData.Location = New System.Drawing.Point(6, 119)
        Me.GBoxTSData.Name = "GBoxTSData"
        Me.GBoxTSData.Size = New System.Drawing.Size(1101, 190)
        Me.GBoxTSData.TabIndex = 3
        Me.GBoxTSData.TabStop = False
        Me.GBoxTSData.Text = "Data"
        '
        'LblRemarks
        '
        Me.LblRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemarks.Location = New System.Drawing.Point(736, 141)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(50, 13)
        Me.LblRemarks.TabIndex = 22
        Me.LblRemarks.Text = "Remarks"
        '
        'LblDateRepaired
        '
        Me.LblDateRepaired.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDateRepaired.AutoSize = True
        Me.LblDateRepaired.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDateRepaired.Location = New System.Drawing.Point(736, 59)
        Me.LblDateRepaired.Name = "LblDateRepaired"
        Me.LblDateRepaired.Size = New System.Drawing.Size(80, 13)
        Me.LblDateRepaired.TabIndex = 18
        Me.LblDateRepaired.Text = "Date Repaired"
        '
        'TBoxTSRepairedBy
        '
        Me.TBoxTSRepairedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBoxTSRepairedBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSRepairedBy.Location = New System.Drawing.Point(736, 34)
        Me.TBoxTSRepairedBy.Name = "TBoxTSRepairedBy"
        Me.TBoxTSRepairedBy.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSRepairedBy.TabIndex = 17
        Me.TBoxTSRepairedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblRepairedBy
        '
        Me.LblRepairedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRepairedBy.AutoSize = True
        Me.LblRepairedBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRepairedBy.Location = New System.Drawing.Point(736, 18)
        Me.LblRepairedBy.Name = "LblRepairedBy"
        Me.LblRepairedBy.Size = New System.Drawing.Size(71, 13)
        Me.LblRepairedBy.TabIndex = 16
        Me.LblRepairedBy.Text = "Repaired by:"
        '
        'TBoxTSStatus
        '
        Me.TBoxTSStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBoxTSStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSStatus.Location = New System.Drawing.Point(736, 116)
        Me.TBoxTSStatus.Name = "TBoxTSStatus"
        Me.TBoxTSStatus.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSStatus.TabIndex = 21
        Me.TBoxTSStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DTPTSDateRepaired
        '
        Me.DTPTSDateRepaired.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTPTSDateRepaired.Checked = False
        Me.DTPTSDateRepaired.CustomFormat = "MMM dd, yyyy"
        Me.DTPTSDateRepaired.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTSDateRepaired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTSDateRepaired.Location = New System.Drawing.Point(736, 75)
        Me.DTPTSDateRepaired.Name = "DTPTSDateRepaired"
        Me.DTPTSDateRepaired.Size = New System.Drawing.Size(347, 22)
        Me.DTPTSDateRepaired.TabIndex = 19
        '
        'TBoxTSRemarks
        '
        Me.TBoxTSRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBoxTSRemarks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSRemarks.Location = New System.Drawing.Point(736, 157)
        Me.TBoxTSRemarks.Name = "TBoxTSRemarks"
        Me.TBoxTSRemarks.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSRemarks.TabIndex = 23
        Me.TBoxTSRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblStatus
        '
        Me.LblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Location = New System.Drawing.Point(736, 100)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(39, 13)
        Me.LblStatus.TabIndex = 20
        Me.LblStatus.Text = "Status"
        '
        'TBoxTSLocation2
        '
        Me.TBoxTSLocation2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TBoxTSLocation2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSLocation2.Location = New System.Drawing.Point(371, 34)
        Me.TBoxTSLocation2.Name = "TBoxTSLocation2"
        Me.TBoxTSLocation2.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSLocation2.TabIndex = 9
        Me.TBoxTSLocation2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblLoc2
        '
        Me.LblLoc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblLoc2.AutoSize = True
        Me.LblLoc2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLoc2.Location = New System.Drawing.Point(371, 18)
        Me.LblLoc2.Name = "LblLoc2"
        Me.LblLoc2.Size = New System.Drawing.Size(60, 13)
        Me.LblLoc2.TabIndex = 8
        Me.LblLoc2.Text = "Location 2"
        '
        'LblLoc3
        '
        Me.LblLoc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblLoc3.AutoSize = True
        Me.LblLoc3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLoc3.Location = New System.Drawing.Point(371, 59)
        Me.LblLoc3.Name = "LblLoc3"
        Me.LblLoc3.Size = New System.Drawing.Size(60, 13)
        Me.LblLoc3.TabIndex = 10
        Me.LblLoc3.Text = "Location 3"
        '
        'TBoxTSLocation3
        '
        Me.TBoxTSLocation3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TBoxTSLocation3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSLocation3.Location = New System.Drawing.Point(371, 75)
        Me.TBoxTSLocation3.Name = "TBoxTSLocation3"
        Me.TBoxTSLocation3.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSLocation3.TabIndex = 11
        Me.TBoxTSLocation3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblLoc4
        '
        Me.LblLoc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblLoc4.AutoSize = True
        Me.LblLoc4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLoc4.Location = New System.Drawing.Point(371, 100)
        Me.LblLoc4.Name = "LblLoc4"
        Me.LblLoc4.Size = New System.Drawing.Size(60, 13)
        Me.LblLoc4.TabIndex = 12
        Me.LblLoc4.Text = "Location 4"
        '
        'LblLoc5
        '
        Me.LblLoc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblLoc5.AutoSize = True
        Me.LblLoc5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLoc5.Location = New System.Drawing.Point(371, 141)
        Me.LblLoc5.Name = "LblLoc5"
        Me.LblLoc5.Size = New System.Drawing.Size(60, 13)
        Me.LblLoc5.TabIndex = 14
        Me.LblLoc5.Text = "Location 5"
        '
        'TBoxTSLocation5
        '
        Me.TBoxTSLocation5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TBoxTSLocation5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSLocation5.Location = New System.Drawing.Point(371, 157)
        Me.TBoxTSLocation5.Name = "TBoxTSLocation5"
        Me.TBoxTSLocation5.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSLocation5.TabIndex = 15
        Me.TBoxTSLocation5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBoxTSLocation4
        '
        Me.TBoxTSLocation4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TBoxTSLocation4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTSLocation4.Location = New System.Drawing.Point(371, 116)
        Me.TBoxTSLocation4.Name = "TBoxTSLocation4"
        Me.TBoxTSLocation4.Size = New System.Drawing.Size(347, 22)
        Me.TBoxTSLocation4.TabIndex = 13
        Me.TBoxTSLocation4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPageInquiry
        '
        Me.TabPageInquiry.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageInquiry.Controls.Add(Me.GroupBox2)
        Me.TabPageInquiry.Controls.Add(Me.GroupBox1)
        Me.TabPageInquiry.Location = New System.Drawing.Point(4, 22)
        Me.TabPageInquiry.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPageInquiry.Name = "TabPageInquiry"
        Me.TabPageInquiry.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPageInquiry.Size = New System.Drawing.Size(1113, 542)
        Me.TabPageInquiry.TabIndex = 2
        Me.TabPageInquiry.Text = "Inquiry"
        '
        'DTTSBindingSource
        '
        Me.DTTSBindingSource.DataMember = "DTTS"
        Me.DTTSBindingSource.DataSource = Me.DSTS
        '
        'DSTS
        '
        Me.DSTS.DataSetName = "DSTS"
        Me.DSTS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ErrorProviderEndorsement
        '
        Me.ErrorProviderEndorsement.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderEndorsement.ContainerControl = Me
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1121, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem1.Text = "&File"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1103, 70)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(232, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 26)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(145, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 26)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(6, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 22)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Serial No."
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1103, 456)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Summary"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1121, 592)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1137, 631)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
        Me.TabPageReceiving.ResumeLayout(False)
        Me.TabPageReceiving.PerformLayout()
        Me.GBoxRcvEndtData.ResumeLayout(False)
        CType(Me.DGVRcvEndtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxRcvSearchInfo.ResumeLayout(False)
        Me.GBoxRcvSearchInfo.PerformLayout()
        Me.TabPageTS.ResumeLayout(False)
        Me.TabPageTS.PerformLayout()
        Me.GBoxTSInformation.ResumeLayout(False)
        Me.GBoxTSInformation.PerformLayout()
        Me.GBoxTSData.ResumeLayout(False)
        Me.GBoxTSData.PerformLayout()
        Me.TabPageInquiry.ResumeLayout(False)
        CType(Me.DTTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSTS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderEndorsement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblQtyEndorsed As Label
    Friend WithEvents TBoxQtyEndorsed As TextBox
    Friend WithEvents LblModel As Label
    Friend WithEvents LblSerialNo As Label
    Friend WithEvents TBoxSerialNo As TextBox
    Friend WithEvents LblPPONo As Label
    Friend WithEvents TBoxPPONo As TextBox
    Friend WithEvents LblPPOQty As Label
    Friend WithEvents TBoxPPOQty As TextBox
    Friend WithEvents LblLotNo As Label
    Friend WithEvents TBoxLotNo As TextBox
    Friend WithEvents LblWorkOrder As Label
    Friend WithEvents TBoxWorkOrder As TextBox
    Friend WithEvents LblStation As Label
    Friend WithEvents TBoxFailureSymptoms As TextBox
    Friend WithEvents LblEndorsedBy As Label
    Friend WithEvents TBoxEndorsedBy As TextBox
    Friend WithEvents LblDateFailed As Label
    Friend WithEvents LblEndorsementDate As Label
    Friend WithEvents LblWorkWeek As Label
    Friend WithEvents TBoxWorkweek As TextBox
    Friend WithEvents LblAnalysis As Label
    Friend WithEvents TBoxTSAnalysis As TextBox
    Friend WithEvents LblActionTaken As Label
    Friend WithEvents TBoxTSActionTaken As TextBox
    Friend WithEvents LblLoc1 As Label
    Friend WithEvents TBoxTSLocation1 As TextBox
    Friend WithEvents LblDefectType As Label
    Friend WithEvents TBoxTSDefectType As TextBox
    Friend WithEvents DTPDateFailed As DateTimePicker
    Friend WithEvents DTPEndorsementDate As DateTimePicker
    Friend WithEvents BtnEndorse As Button
    Friend WithEvents BtnInformationClear As Button
    Friend WithEvents LblEndorsementNo As Label
    Friend WithEvents TboxEndorsementNo As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageEndorsement As TabPage
    Friend WithEvents TabPageTS As TabPage
    Friend WithEvents TabPageInquiry As TabPage
    Friend WithEvents LblFailureSymptoms As Label
    Friend WithEvents GBoxEndorsmentData As GroupBox
    Friend WithEvents GBoxInformation As GroupBox
    Friend WithEvents GBoxData As GroupBox
    Friend WithEvents TabPageReceiving As TabPage
    Friend WithEvents ErrorProviderEndorsement As ErrorProvider
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
    Friend WithEvents LblTotalEndorsedQty As Label
    Friend WithEvents LblTotalQty As Label
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
    Friend WithEvents BtnEndorseAnotherModel As Button
    Friend WithEvents LblNewQty As Label
    Friend WithEvents LblNewEndorsedQty As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnReturn As Button
    Friend WithEvents DGVRcvEndtData As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
    Friend WithEvents GBoxRcvSearchInfo As GroupBox
    Friend WithEvents TBoxRcvReceivedBy As TextBox
    Friend WithEvents LblRcvReceivedBy As Label
    Friend WithEvents LblEndtTotalQty As Label
    Friend WithEvents LblRcvEndtTotalQty As Label
    Friend WithEvents BtnRcvSubmit As Button
    Friend WithEvents BtnRcvCheckData As Button
    Friend WithEvents LblRcvEndtNo As Label
    Friend WithEvents TBoxRcvEndtNo As TextBox
    Friend WithEvents GBoxRcvEndtData As GroupBox
    Friend WithEvents LblRcvReceiver As Label
    Friend WithEvents LblRcvStatus As Label
    Friend WithEvents LblRcvReceivedDateTitle As Label
    Friend WithEvents LblRcvRcvdDate As Label
    Friend WithEvents lblRcvReceiverName As Label
    Friend WithEvents BtnRcvReset As Button
    Friend WithEvents TboxTSSerialNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GBoxTSInformation As GroupBox
    Friend WithEvents BtnTSSearch As Button
    Friend WithEvents LblTSRcvdDate As Label
    Friend WithEvents LblTSReceivedDateTitle As Label
    Friend WithEvents lblTSReceiverName As Label
    Friend WithEvents LblTSReceiver As Label
    Friend WithEvents GBoxTSData As GroupBox
    Friend WithEvents BtnTSClear As Button
    Friend WithEvents LblRemarks As Label
    Friend WithEvents LblDateRepaired As Label
    Friend WithEvents TBoxTSRepairedBy As TextBox
    Friend WithEvents LblRepairedBy As Label
    Friend WithEvents TBoxTSStatus As TextBox
    Friend WithEvents TBoxTSRemarks As TextBox
    Friend WithEvents DTPTSDateRepaired As DateTimePicker
    Friend WithEvents LblStatus As Label
    Friend WithEvents TBoxTSLocation2 As TextBox
    Friend WithEvents LblLoc2 As Label
    Friend WithEvents LblLoc3 As Label
    Friend WithEvents TBoxTSLocation3 As TextBox
    Friend WithEvents LblLoc4 As Label
    Friend WithEvents LblLoc5 As Label
    Friend WithEvents TBoxTSLocation5 As TextBox
    Friend WithEvents TBoxTSLocation4 As TextBox
    Friend WithEvents BtnTSUpdate As Button
    Friend WithEvents LblTSVerification As Label
    Friend WithEvents LblTSTimeStamp As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DTTSBindingSource As BindingSource
    Friend WithEvents DSTS As DSTS
    Friend WithEvents LblTSDataQRCode As Label
    Friend WithEvents LblTSDataSerialNumber As Label
    Friend WithEvents ChkBoxEndtSerialNo As CheckBox
    Friend WithEvents FileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label7 As Label
End Class
