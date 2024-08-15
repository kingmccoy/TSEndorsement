Imports System.Data.Common
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Infrastructure.DependencyResolution
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Linq.Expressions
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Messaging
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Endorsement.DSTSEndorsementData

Public Class FrmMain
    'Private dbCon As New SQLiteConnection("Data Source=" & System.Windows.Forms.Application.StartupPath & "\endorsement_proposal.db;Version=3;FailIfMissing=True;")
    Dim DateNow, TimeNow As String
    Dim Invalid_ppoNumber, Invalid_lotNumber, Invalid_workOrder, Invalid_serialNumber As Boolean
    Dim FailureSymptoms As String

    Public i As String ' DataGridView ID number
    Public dgvRow As DataGridViewRow ' DataGridView Current Row
    Public dgvIntRow As Integer ' DataGridView Current Row as Integer

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Set Datagridview Column Header Fontstyle
        DgvPPORegPPORecords.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Bold)
        DGVEndorsementData.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Bold)
        DGVRcvEndtData.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Bold)
        DGVTSEndorsementData.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Bold)
        DgvInqSummary.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Bold)
        DgvUID.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Bold)

        'Set Datagridview Default Cell Fontstyle
        DgvPPORegPPORecords.DefaultCellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
        DGVEndorsementData.DefaultCellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
        DGVRcvEndtData.DefaultCellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
        DGVTSEndorsementData.DefaultCellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
        DgvInqSummary.DefaultCellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
        DgvUID.DefaultCellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)

        Dim workweek = DatePart("ww", DTPEndorsementDate.Value)
        TBoxWorkweek.Text = Format(workweek, "00")
        'db local checking
        Load_CurrentUser()
        Check_User()

        Me.Text = "Endorsement - " & user

        If dbConn.State = ConnectionState.Connecting And dbConn.State = ConnectionState.Open Then
            dbConn.Close()
        End If

        'SQL Server checking
        Load_PPO_Records(DgvPPORegPPORecords)
        Load_Latest_EndorsementNo()
        Load_Model_Variant()
        Load_Station_Inquiry()
        DropTempEndorsementTable() ' Drop the temporary endorsement table
        DropTempTSEndorsementTable() ' Drop the temporary TS endorsement table for scanning serials

        CBoxModel.Enabled = False

        TBoxLotNo.ReadOnly = True
        TBoxPPONo.ReadOnly = True
        TboxMaterial.ReadOnly = True
        TboxModel.ReadOnly = True
        TBoxPPOQty.ReadOnly = True
        TBoxWorkOrder.ReadOnly = True
        TBoxQtyEndorsed.ReadOnly = True
        DTPEndorsementDate.Enabled = False

        'DTPDateFailed.Enabled = False

        BtnEndorseAnotherModel.Enabled = False

        GBoxData.Enabled = False
        BtnEndorseAnotherModel.Enabled = False
        BtnSubmit.Enabled = False
        BtnCancel.Enabled = False
    End Sub

    Public Sub Check_User()
        If user = "Test Engineer" Then
            If Not (TabControl1.TabPages.Contains(TabPageReceiving) And TabControl1.TabPages.Contains(TabPageTS)) Then
                TabControl1.TabPages.Insert(0, TabPagePPOReg)
                TabControl1.TabPages.Insert(1, TabPageUID)
                TabControl1.TabPages.Insert(3, TabPageReceiving)
                TabControl1.TabPages.Insert(4, TabPageTS)
                TabControl1.TabPages.Insert(5, TabPageInquiry)
            End If
        ElseIf user = "Production" Then
            TabControl1.TabPages.Remove(TabPagePPOReg)
            TabControl1.TabPages.Remove(TabPageUID)
            TabControl1.TabPages.Remove(TabPageReceiving)
            TabControl1.TabPages.Remove(TabPageTS)
            TabControl1.TabPages.Remove(TabPageInquiry)
        End If
    End Sub

    Private Sub BtnInformationClear_Click(sender As Object, e As EventArgs) Handles BtnInformationClear.Click
        TBoxLotNo.Clear()
        TBoxPPONo.Clear()
        TboxMaterial.Clear()
        TBoxWorkOrder.Clear()
        TBoxQtyEndorsed.Clear()
        DTPEndorsementDate.Value = Today

        CBoxModel.Text = Nothing
    End Sub

    Private Sub Reset_Fillup_Form()
        GBoxInformation.Enabled = True
        TBoxEndorsedBy.ReadOnly = False
        TBoxQtyEndorsed.Clear()
        CBoxModel.Text = Nothing
        TBoxSerialNo.Clear()
        TBoxPPONo.Clear()
        TBoxPPOQty.Clear()
        TBoxLotNo.Clear()
        TBoxWorkOrder.Clear()
        CBoxStation.Text = Nothing
        'TBoxFailureSymptoms.Clear()
        TBoxEndorsedBy.Clear()
        BtnScan.Enabled = True
        BtnReset.Enabled = True

        GBoxData.Enabled = False
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        'TBoxFailureSymptoms.Clear()
        CBoxFailureSymptoms.Text = Nothing
        BtnSubmit.Enabled = False
        BtnCancel.Enabled = False

        DGVEndorsementData.DataSource = Nothing
        LblNewQty.Text = 0.ToString
        LblTotalQty.Text = 0.ToString

        LotNumber_List.Clear()
        Model_List.Clear()
        EndorsedQty_list.Clear()
    End Sub

    Private Sub BtnEndorse_Click(sender As Object, e As EventArgs) Handles BtnEndorse.Click
        If ChkBoxEndtSerialNo.Checked = True And TBoxSerialNo.Enabled = False Then
            If CBoxStation.Text = Nothing Or CBoxFailureSymptoms.Text = Nothing Then
                'If CBoxStation.Text = Nothing Or CBoxFailureSymptoms.Text.Length = 0 Then
                MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information 1", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            If TBoxSerialNo.TextLength = 0 Or CBoxStation.Text = Nothing Or CBoxFailureSymptoms.Text = Nothing Then
                'If TBoxSerialNo.TextLength = 0 Or CBoxStation.Text = Nothing Or TBoxFailureSymptoms.Text.Length = 0 Then
                MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information 2", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If Invalid_serialNumber = True Then
            MessageBox.Show("Please ensure all fields with an error mark are in the correct format.", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            Try
                ' Construct the SQL query with parameterization to prevent SQL injection
                Dim dbQuery As String = "SELECT * FROM uid WHERE uid = @uid"
                dbConn.Open()

                Using dbCmd As New SqlCommand(dbQuery, dbConn)
                    dbCmd.Parameters.AddWithValue("@uid", TBoxSerialNo.Text.Substring(6))

                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader()
                        If dbReader.HasRows Then
                            dbConn.Close()

                            ' Check if the UID exists for the specified lot number
                            Dim dbQuery1 As String = "SELECT * FROM uid WHERE uid = @uid AND lot_no = @lot_no"
                            dbConn.Open()
                            Using dbCmd1 As New SqlCommand(dbQuery1, dbConn)
                                dbCmd1.Parameters.AddWithValue("@uid", TBoxSerialNo.Text.Substring(6))
                                dbCmd1.Parameters.AddWithValue("@lot_no", TBoxLotNo.Text)

                                Using dbReader1 As SqlDataReader = dbCmd1.ExecuteReader()
                                    If dbReader1.HasRows Then
                                        ' UID exists for the specified lot number, you can process further if needed
                                    Else
                                        ' UID does not belong to the specified lot number
                                        MessageBox.Show($"The UID you entered does not belong to lot number {TBoxLotNo.Text}. Please check the UID and lot number, and try again.",
                                                        "Wrong UID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Return
                                    End If
                                End Using
                            End Using
                            dbConn.Close()
                        Else
                            ' UID does not exist
                            MessageBox.Show("The UID you entered hasn't been uploaded yet. Please upload the laser UID and try again.",
                                "UID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using
                dbConn.Close()

            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try



            Try
                Dim Query = "SELECT serial_no FROM TempEndorsement WHERE serial_no='" & TBoxSerialNo.Text & "'"
                dbConn.Open()
                Using dbCmd As New SqlCommand(Query, dbConn)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            MessageBox.Show(dbReader("serial_no") & vbCrLf & vbCrLf & "Serial have already scanned.", "Duplicate Serial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            TBoxSerialNo.Clear()
                            Return
                        End If
                    End Using
                End Using
                dbConn.Close()

                Dim Query1 = "SELECT serial_no FROM Endorsement WHERE serial_no='" & TBoxSerialNo.Text & "'"
                dbConn.Open()
                Using dbCmd As New SqlCommand(Query1, dbConn)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            MessageBox.Show(dbReader("serial_no") & vbCrLf & vbCrLf & "Serial have already endorsed.", "Duplicate Serial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            TBoxSerialNo.Clear()
                            Return
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Captururing Duplicate Serial.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            Try
                DateNow = DateTime.Now.ToString("MMMM dd, yyyy")
                TimeNow = DateTime.Now.ToString("HH:mm:ss")
                Dim StoredProcedure As String = "InsertTempEndorsementData"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure

                    ' Add parameters with proper data types
                    dbCmd.Parameters.AddWithValue("@endorsement_no", TboxEndorsementNo.Text)
                    dbCmd.Parameters.AddWithValue("@qty_endorsed", Integer.Parse(TBoxQtyEndorsed.Text))
                    dbCmd.Parameters.AddWithValue("@qty", 1)
                    dbCmd.Parameters.AddWithValue("@model", TboxModel.Text)
                    dbCmd.Parameters.AddWithValue("@serial_no", If(ChkBoxEndtSerialNo.Checked = True, "N/A", TBoxSerialNo.Text))
                    dbCmd.Parameters.AddWithValue("@ppo_no", TBoxPPONo.Text)
                    dbCmd.Parameters.AddWithValue("@ppo_qty", Integer.Parse(TBoxPPOQty.Text))
                    dbCmd.Parameters.AddWithValue("@lot_no", TBoxLotNo.Text)
                    dbCmd.Parameters.AddWithValue("@work_order", TBoxWorkOrder.Text)
                    dbCmd.Parameters.AddWithValue("@station", CBoxStation.Text)
                    'dbCmd.Parameters.AddWithValue("@failure_symptoms", TBoxFailureSymptoms.Text)
                    dbCmd.Parameters.AddWithValue("@failure_symptoms", CBoxFailureSymptoms.Text)
                    dbCmd.Parameters.AddWithValue("@endorsed_by", TBoxEndorsedBy.Text)
                    dbCmd.Parameters.AddWithValue("@date_failed", DTPDateFailed.Value)
                    dbCmd.Parameters.AddWithValue("@endorsement_date", DTPEndorsementDate.Value)
                    dbCmd.Parameters.AddWithValue("@workweek", TBoxWorkweek.Text)
                    dbCmd.Parameters.AddWithValue("@date", DateNow)
                    dbCmd.Parameters.AddWithValue("@time", TimeNow)

                    ' Execute the query
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()

                ' Load updated data
                Load_TempEndorsementData()
                Count_TempEndorsement()

                ' Clear the serial number textbox
                TBoxSerialNo.Clear()

                ' Clear the DataGridview selection
                DGVEndorsementData.ClearSelection()

                BtnReturn.Enabled = False

                'BtnEndorseAnotherModel.Enabled = True
                LblNewQty.Text += 1
                If TBoxSerialNo.Enabled = True Then
                    TBoxSerialNo.Focus()
                Else
                    LblSerialNo.Focus()
                End If
            Catch ex As FormatException
                ' Handle format exceptions (e.g., parsing integers)
                MessageBox.Show("Please enter valid numeric values for quantity fields.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As SqlException
                ' Handle database-related errors
                MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                ' Handle other types of exceptions
                MessageBox.Show(ex.Message, "Error Endorsing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Close the database connection
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            If LblNewQty.Text = TBoxQtyEndorsed.Text Then ' executes if new endorsed qty is equal to qty endorsed
                'GBoxData.Enabled = False
                TBoxSerialNo.Clear()
                CBoxStation.Text = Nothing
                'TBoxFailureSymptoms.Clear()
                CBoxFailureSymptoms.Text = Nothing

                TBoxSerialNo.Enabled = False
                CBoxStation.Enabled = False
                'TBoxFailureSymptoms.Enabled = False
                CBoxFailureSymptoms.Enabled = False

                BtnEndorse.Enabled = False
                BtnDataClear.Enabled = False

                BtnEndorseAnotherModel.Enabled = True
                BtnSubmit.Enabled = True

                ChkBoxEndtSerialNo.Checked = False
                ChkBoxEndtSerialNo.Enabled = False
                LblSerialNo.Focus()
            Else
                BtnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnEndorseEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles TBoxSerialNo.KeyDown, CBoxStation.KeyDown, CBoxFailureSymptoms.KeyDown, DTPDateFailed.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEndorse.PerformClick()
        End If
    End Sub

    'Private Sub Load_FailureSymptoms()
    '    Try
    '        Dim DbTable As New DSFailureSymptoms.DTFailureSymptomsDataTable
    '        'Dim Query = "SELECT DISTINCT failure_symptoms FROM endorsement WHERE station='" & CBoxStation.Text & "'"
    '        Dim Query = "SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS id, failure_symptoms FROM (SELECT DISTINCT failure_symptoms FROM endorsement WHERE station='" & CBoxStation.Text & "') AS distinct_symptoms;"
    '        'Dim Query = "SELECT DISTINCT * FROM endorsement WHERE station='" & CBoxStation.Text & "'"
    '        dbConn.Open()
    '        Using dbCmd As New SqlCommand(Query, dbConn)
    '            Using dbAdapter As New SqlDataAdapter(dbCmd)
    '                dbAdapter.Fill(DbTable)
    '            End Using
    '        End Using
    '        dbConn.Close()
    '        CBoxFailureSymptoms.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        CBoxFailureSymptoms.DataSource = DbTable
    '        CBoxFailureSymptoms.DisplayMember = "failure_symptoms"
    '        CBoxFailureSymptoms.Text = Nothing
    '    Catch ex As SqlException
    '        MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If dbConn.State = ConnectionState.Open Then
    '            dbConn.Close()
    '        End If
    '    End Try
    'End Sub

    Private Sub DTPEndorsementDate_ValueChanged(sender As Object, e As EventArgs) Handles DTPEndorsementDate.ValueChanged
        Dim workweek = DatePart("ww", DTPEndorsementDate.Value)
        TBoxWorkweek.Text = Format(workweek, "00")
    End Sub

    Private Sub TBoxQtyEndorsed_TextChanged(sender As Object, e As EventArgs) Handles TBoxQtyEndorsed.TextChanged
        TBoxQtyEndorsed.MaxLength = 6

        Dim Qty = Regex.Match(TBoxQtyEndorsed.Text, "[0-9]+")

        'If TBoxQtyEndorsed.Text.Length > 0 Then
        '    If TBoxQtyEndorsed.Text = Qty.Value Then
        '        ErrorProvider1.SetError(TBoxQtyEndorsed, Nothing)
        '    Else
        '        ErrorProvider1.SetError(TBoxQtyEndorsed, "Only number are allowed")
        '    End If
        'Else
        '    If TBoxQtyEndorsed.Text.Length = 0 Then
        '        ErrorProvider1.SetError(TBoxQtyEndorsed, Nothing)
        '    End If
        'End If
    End Sub

    Private Sub TBoxPPONo_TextChanged(sender As Object, e As EventArgs) Handles TBoxPPONo.TextChanged
        TBoxPPONo.MaxLength = 10

        Dim PPONum = "[0-9]{10}"
        If TBoxPPONo.Text.Length > 0 Then
            If Regex.IsMatch(TBoxPPONo.Text, PPONum) Then
                ErrorProviderEndorsement.SetError(TBoxPPONo, Nothing)
                Invalid_ppoNumber = False
            Else
                ErrorProviderEndorsement.SetError(TBoxPPONo, "Invalid PPO number")
                Invalid_ppoNumber = True
            End If
        Else
            If TBoxPPONo.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TBoxPPONo, Nothing)
                Invalid_ppoNumber = False
            End If
        End If
    End Sub

    Private Sub TBoxQtyEndorsed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxQtyEndorsed.KeyPress
        If TBoxQtyEndorsed.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If

        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private CBoxModelPreviousValue As String
    Private CboxModelIndex As Integer

    Private Sub CBoxModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxModel.SelectedIndexChanged
        Load_Station(CBoxStation, CBoxModel.Text, "station")
        Load_Station(CboxInqStation, CboxInqModel.Text, "station")

        '    If CBoxModel.Text = Nothing Then
        '        TBoxPPONo.ReadOnly = True
        '        TBoxPPOQty.ReadOnly = True
        '        TBoxLotNo.ReadOnly = True
        '        TBoxWorkOrder.ReadOnly = True
        '        TBoxQtyEndorsed.ReadOnly = True
        '        'DTPDateFailed.Enabled = False
        '        DTPEndorsementDate.Enabled = False

        '        CBoxStation.DataSource = Nothing
        '    Else
        '        TBoxPPONo.ReadOnly = False
        '        TBoxPPOQty.ReadOnly = False
        '        TBoxLotNo.ReadOnly = False
        '        TBoxWorkOrder.ReadOnly = False
        '        TBoxQtyEndorsed.ReadOnly = False
        '        'DTPDateFailed.Enabled = True
        '        DTPEndorsementDate.Enabled = True
        '    End If

        '    ' Clears the value if selected item is not equal from the previous
        '    If CBoxModel.Text <> CBoxModelPreviousValue Then
        '        TBoxPPONo.Clear()
        '        TBoxPPOQty.Clear()
        '        TBoxLotNo.Clear()
        '        TBoxWorkOrder.Clear()
        '        TBoxQtyEndorsed.Clear()
        '    End If

        '    CBoxModelPreviousValue = CBoxModel.Text
    End Sub

    Private Sub CBoxModel_TextChanged(sender As Object, e As EventArgs) Handles CBoxModel.TextChanged
        'If CBoxModel.Text = Nothing Then
        '    TBoxPPONo.ReadOnly = True
        '    TBoxPPOQty.ReadOnly = True
        '    TBoxLotNo.ReadOnly = True
        '    TBoxWorkOrder.ReadOnly = True
        '    TBoxQtyEndorsed.ReadOnly = True
        '    DTPDateFailed.Enabled = False
        '    DTPEndorsementDate.Enabled = False

        '    CBoxStation.DataSource = Nothing
        'Else
        '    TBoxPPONo.ReadOnly = False
        '    TBoxPPOQty.ReadOnly = False
        '    TBoxLotNo.ReadOnly = False
        '    TBoxWorkOrder.ReadOnly = False
        '    TBoxQtyEndorsed.ReadOnly = False
        '    DTPDateFailed.Enabled = True
        '    DTPEndorsementDate.Enabled = True
        'End If
    End Sub

    Private Sub TBoxPPONo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxPPONo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TBoxPPONo.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TBoxPPOQty_TextChanged(sender As Object, e As EventArgs) Handles TBoxPPOQty.TextChanged
        TBoxPPOQty.MaxLength = 6

        'Dim Qty = Regex.Match(TBoxPPOQty.Text, "[0-9]+")

        'If TBoxPPOQty.Text.Length > 0 Then
        '    If TBoxPPOQty.Text = Qty.Value Then
        '        ErrorProvider1.Clear()
        '    Else
        '        ErrorProvider1.SetError(TBoxPPOQty, "Only number are allowed")
        '    End If
        'Else
        '    If TBoxPPOQty.Text.Length = 0 Then
        '        ErrorProvider1.SetError(TBoxPPOQty, Nothing)
        '    End If
        'End If
    End Sub

    Private Sub TBoxPPOQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxPPOQty.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TBoxPPOQty.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TBoxLotNo_TextChanged(sender As Object, e As EventArgs) Handles TBoxLotNo.TextChanged
        TBoxLotNo.MaxLength = 10

        Dim LotNum = Regex.Match(TBoxLotNo.Text, "^71[0-9]{5}\.(?:[2-9]|[1-9][0-9])$")

        If TBoxLotNo.Text.Length > 0 Then
            If TBoxLotNo.Text = LotNum.Value Then
                ErrorProviderEndorsement.SetError(TBoxLotNo, Nothing)
                'TBoxWorkOrder.ReadOnly = False
                'TBoxQtyEndorsed.ReadOnly = False
                'DTPEndorsementDate.Enabled = True
                Invalid_lotNumber = False
            Else
                ErrorProviderEndorsement.SetError(TBoxLotNo, "Invalid lot number")
                TBoxWorkOrder.ReadOnly = True
                TBoxQtyEndorsed.ReadOnly = True
                DTPEndorsementDate.Enabled = False
                Invalid_lotNumber = True
                TBoxWorkOrder.Clear()
                TBoxQtyEndorsed.Clear()
            End If
        Else
            If TBoxLotNo.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TBoxLotNo, Nothing)
                TBoxWorkOrder.ReadOnly = True
                TBoxQtyEndorsed.ReadOnly = True
                DTPEndorsementDate.Enabled = False
                Invalid_lotNumber = False
            End If
        End If

        If Invalid_lotNumber = False Then
            Try
                Dim dbQuery = "SELECT * FROM ppo WHERE lot_no = '" & TBoxLotNo.Text & "'"
                dbConn.Open()
                Using dbCmd As New SqlCommand(dbQuery, dbConn)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            ErrorProviderEndorsement.SetError(TBoxLotNo, Nothing)
                            TBoxPPONo.Text = dbReader("ppo_no").ToString
                            TboxMaterial.Text = dbReader("material_no").ToString
                            TboxModel.Text = dbReader("model").ToString
                            TBoxPPOQty.Text = dbReader("ppo_qty").ToString
                            TBoxWorkOrder.ReadOnly = False
                            TBoxQtyEndorsed.ReadOnly = False
                            DTPEndorsementDate.Enabled = True
                        ElseIf Not dbReader.HasRows Then
                            If TBoxLotNo.Text.Length = 0 Then
                                ErrorProviderEndorsement.SetError(TBoxLotNo, Nothing)
                            Else
                                ErrorProviderEndorsement.SetError(TBoxLotNo, "No record found")
                            End If

                            TBoxPPONo.Clear()
                            TboxMaterial.Clear()
                            TboxModel.Clear()
                            TBoxPPOQty.Clear()
                            TBoxWorkOrder.ReadOnly = True
                            TBoxQtyEndorsed.ReadOnly = True
                            DTPEndorsementDate.Enabled = False
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            Load_Station(CBoxStation, TboxModel.Text, "station")
            'Load_Station(CboxInqStation, CboxInqModel.Text, "station")
        ElseIf Invalid_lotNumber = True Then
            TBoxPPONo.Clear()
            TboxMaterial.Clear()
            TboxModel.Clear()
            TBoxPPOQty.Clear()
        End If
    End Sub

    Private Sub TBoxLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxLotNo.KeyPress
        If TBoxLotNo.TextLength = 0 Then
            If e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
            If TBoxLotNo.TextLength > 0 Then
                If e.KeyChar = "." Then
                    e.Handled = False
                End If
            End If
        End If

        If TBoxLotNo.Text.Contains(".") Then
            If e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TBoxWorkOrder_TextChanged(sender As Object, e As EventArgs) Handles TBoxWorkOrder.TextChanged
        TBoxWorkOrder.MaxLength = 7
        TBoxWorkOrder.CharacterCasing = CharacterCasing.Upper

        Dim RegexWorkOrder = Regex.Match(TBoxWorkOrder.Text, "WO[0-9]{5}")

        If TBoxWorkOrder.Text.Length > 0 Then
            If TBoxWorkOrder.Text = RegexWorkOrder.Value Then
                ErrorProviderEndorsement.SetError(TBoxWorkOrder, Nothing)
                Invalid_workOrder = False
            Else
                ErrorProviderEndorsement.SetError(TBoxWorkOrder, "Invalid work order")
                Invalid_workOrder = True
            End If
        Else
            If TBoxWorkOrder.TextLength = 0 Then
                ErrorProviderEndorsement.SetError(TBoxWorkOrder, Nothing)
                Invalid_workOrder = False
            End If
        End If
    End Sub

    Private TBoxEndorsedByModified As Boolean = False

    Private Sub TBoxEndorsedBy_TextChanged(sender As Object, e As EventArgs) Handles TBoxEndorsedBy.TextChanged
        TBoxEndorsedBy.CharacterCasing = CharacterCasing.Upper
        TBoxEndorsedByModified = True

        If TBoxEndorsedBy.TextLength > 0 Then
            CBoxModel.Enabled = True

            TBoxLotNo.ReadOnly = False
            'TboxMaterial.ReadOnly = False
            'TboxModel.ReadOnly = False
            'TBoxPPONo.ReadOnly = False
            'TBoxPPOQty.ReadOnly = False
            'TBoxWorkOrder.ReadOnly = False
            'TBoxQtyEndorsed.ReadOnly = False
        Else
            CBoxModel.Enabled = False

            TBoxLotNo.ReadOnly = True
            'TboxMaterial.ReadOnly = True
            'TboxModel.ReadOnly = True
            'TBoxPPONo.ReadOnly = True
            'TBoxPPOQty.ReadOnly = True
            'TBoxWorkOrder.ReadOnly = True
            'TBoxQtyEndorsed.ReadOnly = True
        End If
    End Sub

    Private Sub TBoxEndorsedBy_Leave(sender As Object, e As EventArgs) Handles TBoxEndorsedBy.Leave
        ' Check if the TextBox has been modified and if it's not already disabled
        If TBoxEndorsedByModified AndAlso TBoxEndorsedBy.ReadOnly = False Then
            ' Disable the TextBox
            TBoxEndorsedBy.ReadOnly = True
        End If
    End Sub

    Private Sub TBoxSerialNo_TextChanged(sender As Object, e As EventArgs) Handles TBoxSerialNo.TextChanged
        TBoxSerialNo.MaxLength = 11
        TBoxSerialNo.CharacterCasing = CharacterCasing.Upper

        Dim RegexSerialNo = Regex.Match(TBoxSerialNo.Text, "[0-9]{2}[0-9]{2}BC[2-9A-HJ-NP-Z]{5}")

        If TBoxSerialNo.Text.Length > 0 Then
            If TBoxSerialNo.Text = RegexSerialNo.Value Then
                ErrorProviderEndorsement.SetError(TBoxSerialNo, Nothing)
                Invalid_serialNumber = False
            Else
                ErrorProviderEndorsement.SetError(TBoxSerialNo, "Invalid serial number")
                Invalid_serialNumber = True
            End If
        Else
            If TBoxSerialNo.TextLength = 0 Then
                ErrorProviderEndorsement.SetError(TBoxSerialNo, Nothing)
                Invalid_serialNumber = False
            End If
        End If
    End Sub

    Private Sub TBoxSerialNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxSerialNo.KeyPress
        ' Allow digits (0-9), letters, and control characters (such as newline, tab, and carriage return)
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a digit, letter, or control character, ignore it
            e.Handled = True
        End If
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Try
            Dim StoredProcedure = "InserTempToEndorsementData"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error Submitting data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Send_eMail(TboxEndorsementNo, TBoxEndorsedBy, LblTotalQty)
        Load_Latest_EndorsementNo()
        Reset_Fillup_Form()
    End Sub

    Public LotNumber_List As New List(Of String)
    Public Model_List As New List(Of String)
    Public EndorsedQty_List As New List(Of Int32)

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
        If TBoxEndorsedBy.TextLength = 0 Or TBoxLotNo.TextLength = 0 Or TBoxPPONo.TextLength = 0 Or TboxMaterial.TextLength = 0 Or TboxModel.TextLength = 0 Or TBoxPPOQty.TextLength = 0 Or TBoxWorkOrder.TextLength = 0 Or TBoxQtyEndorsed.TextLength = 0 Then
            MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'If TBoxQtyEndorsed.TextLength = 0 Or CBoxModel.Text = Nothing Or TBoxPPONo.TextLength = 0 Or TBoxPPOQty.TextLength = 0 Or TBoxLotNo.TextLength = 0 Or TBoxWorkOrder.TextLength = 0 Or TBoxEndorsedBy.TextLength = 0 Then
        '    MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If

        If Invalid_ppoNumber = True Or Invalid_lotNumber = True Or Invalid_workOrder Then
            MessageBox.Show("Please ensure all fields with an error mark are in the correct format.", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            GBoxInformation.Enabled = False
            GBoxData.Enabled = True
            BtnEndorseAnotherModel.Enabled = False

            TBoxSerialNo.Enabled = True
            CBoxStation.Enabled = True
            'TBoxFailureSymptoms.Enabled = True
            CBoxFailureSymptoms.Enabled = True
            BtnEndorse.Enabled = True
            BtnDataClear.Enabled = True
            BtnReturn.Enabled = True

            BtnSubmit.Enabled = True
            BtnCancel.Enabled = True

            ChkBoxEndtSerialNo.Enabled = True
            TBoxSerialNo.Focus()

            If Not LotNumber_List.Contains(TBoxLotNo.Text) Then
                LotNumber_List.Add(TBoxLotNo.Text)
                Model_List.Add(TboxModel.Text)
                EndorsedQty_List.Add(TBoxQtyEndorsed.Text)
            End If

            Try
                Dim StoredProcedure = "CreateTempEndorsementTable"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()

                ' Check if TempEndorsement have already data then BtnSubmit will Enable
                dbConn.Open()
                Dim Query = "SELECT * FROM TempEndorsement"
                Using dbCmd As New SqlCommand(Query, dbConn)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            BtnSubmit.Enabled = True
                        Else
                            BtnSubmit.Enabled = False
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                ' Handle database-related errors
                'MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                ' Handle other types of exceptions
                'MessageBox.Show(ex.Message, "Error Opening Scanning Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Close the database connection
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub BtnScanEnter_KeyPress(sender As Object, e As KeyEventArgs) Handles TBoxQtyEndorsed.KeyDown, CBoxModel.KeyDown, TBoxPPONo.KeyDown, TBoxPPOQty.KeyDown, TBoxLotNo.KeyDown, TBoxWorkOrder.KeyDown, TBoxEndorsedBy.KeyDown, DTPEndorsementDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnScan.PerformClick()
        End If
    End Sub

    Private Sub BtnEndorseAnotherModel_Click(sender As Object, e As EventArgs) Handles BtnEndorseAnotherModel.Click
        GBoxInformation.Enabled = True
        BtnReset.Enabled = False
        GBoxData.Enabled = False
        CBoxModel.Text = Nothing
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        'TBoxFailureSymptoms.Clear()
        CBoxFailureSymptoms.Text = Nothing
        LblNewQty.Text = 0
        TBoxLotNo.Clear()
        TBoxWorkOrder.Clear()
        TBoxQtyEndorsed.Clear()
        'BtnScan.Enabled = False
        'BtnDataClear.Enabled = False
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        'Send_eMail(TboxEndorsementNo, TBoxEndorsedBy, LblTotalQty) 'this is for trial sending
        Dim dialogResult As DialogResult = MessageBox.Show("Do you want to cancel endorsement?" & vbCrLf & vbCrLf & "Please take note that it will remove all the data you've scanned.", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialogResult = DialogResult.Yes Then
            'GBoxData.Enabled = False
            'GBoxInformation.Enabled = True
            'BtnSubmit.Enabled = False
            'BtnCancel.Enabled = False

            Reset_Fillup_Form()

            Try
                Dim StoredProcedure = "DropTempEndorsementTable"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()
            Catch ex As Exception
                dbConn.Close()
                MessageBox.Show(ex.Message, "Error Cancelling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            DGVEndorsementData.DataSource = Nothing
            LblTotalQty.Text = 0
            TBoxSerialNo.Clear()
            CBoxStation.Text = Nothing
            'TBoxFailureSymptoms.Clear()
            CBoxFailureSymptoms.Text = Nothing
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        CBoxModel.Text = Nothing
        TBoxEndorsedBy.Clear()
        TBoxEndorsedBy.ReadOnly = False

        BtnInformationClear.PerformClick()
    End Sub

    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles BtnReturn.Click
        Dim iLot = LotNumber_List.IndexOf(TBoxLotNo.Text)

        LotNumber_List.Remove(TBoxLotNo.Text)
        Model_List.RemoveAt(iLot)
        EndorsedQty_List.RemoveAt(iLot)

        GBoxInformation.Enabled = True
        BtnDataClear.PerformClick()
        GBoxData.Enabled = False
        ChkBoxEndtSerialNo.Enabled = False
        GBoxInformation.Focus()
    End Sub

    Private Sub BtnDataClear_Click(sender As Object, e As EventArgs) Handles BtnDataClear.Click
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        'TBoxFailureSymptoms.Clear()
        CBoxFailureSymptoms.Text = Nothing
        DTPDateFailed.Value = Today
    End Sub

    'Private Sub TBoxFailureSymptoms_TextChanged(sender As Object, e As EventArgs)
    '    TBoxFailureSymptoms.CharacterCasing = CharacterCasing.Upper
    'End Sub

    Private Sub CBoxFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles CBoxFailureSymptoms.TextChanged
        Dim selectionStart As Integer = CBoxFailureSymptoms.SelectionStart
        CBoxFailureSymptoms.Text = CBoxFailureSymptoms.Text.ToUpper()
        CBoxFailureSymptoms.SelectionStart = selectionStart
        'CBoxFailureSymptoms.SelectionLength = 0
    End Sub

    'Private Sub TBoxFailureSymptoms_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If TBoxFailureSymptoms.TextLength = 0 Then
    '        If e.KeyChar = ChrW(Keys.Space) Then
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Sub CBoxFailureSymptoms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBoxFailureSymptoms.KeyPress
        If CBoxFailureSymptoms.Text.Length = 0 Then
            If e.KeyChar = ChrW(Keys.Space) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtnRcvCheckData_Click(sender As Object, e As EventArgs) Handles BtnRcvCheckData.Click
        Try
            If TBoxRcvEndtNo.Text = Nothing Then

                Return
            End If

            Dim dbTable As New DSEndorsementData.DTEndorsementDataDataTable
            Dim StoredProcedure = "LoadEndorsementData"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtNo", TBoxRcvEndtNo.Text)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.NextResult()
                    dbReader.Read()
                    If dbReader.HasRows Then
                        If Not dbReader.IsDBNull(dbReader.GetOrdinal("receiver")) Then
                            LblRcvStatus.ForeColor = Color.DarkGreen
                            LblRcvStatus.Text = "ALREADY RECEIVED"
                        Else
                            LblRcvStatus.ForeColor = Color.DarkRed
                            LblRcvStatus.Text = "NOT YET RECEIVED" ' or any other default value or message
                            BtnRcvSubmit.Enabled = True
                        End If

                        LblRcvStatus.Visible = True
                        LblRcvReceivedDateTitle.Visible = True

                        If Not dbReader.IsDBNull(dbReader.GetOrdinal("date")) Then
                            'LblRcvRcvdDate.ForeColor = SystemColors.ControlText
                            LblRcvRcvdDate.ForeColor = Color.DarkGreen
                            LblRcvRcvdDate.Text = Convert.ToDateTime(dbReader("date")).ToString("MMMM dd, yyyy")
                        Else
                            LblRcvRcvdDate.ForeColor = Color.DarkRed
                            LblRcvRcvdDate.Text = "N/A" ' or any other default value or message
                        End If

                        LblRcvRcvdDate.Visible = True
                        LblRcvReceiver.Visible = True

                        If Not dbReader.IsDBNull(dbReader.GetOrdinal("receiver")) Then
                            'lblRcvReceiverName.ForeColor = SystemColors.ControlText
                            lblRcvReceiverName.ForeColor = Color.DarkGreen
                            lblRcvReceiverName.Text = dbReader("receiver")
                        Else
                            lblRcvReceiverName.ForeColor = Color.DarkRed
                            lblRcvReceiverName.Text = "N/A" ' or any other default value or message
                        End If

                        lblRcvReceiverName.Visible = True
                    Else
                        LblRcvStatus.Visible = True
                        LblRcvStatus.Text = "NO RECORD FOUND"
                        LblRcvStatus.ForeColor = Color.DarkRed

                        'LblRcvStatus.Text = Nothing
                        'LblRcvStatus.Visible = False

                        LblRcvReceivedDateTitle.Visible = False
                        LblRcvRcvdDate.Text = Nothing
                        LblRcvRcvdDate.Visible = False

                        LblRcvReceiver.Visible = False
                        lblRcvReceiverName.Text = Nothing
                        lblRcvReceiverName.Visible = False
                        BtnRcvSubmit.Enabled = False
                    End If
                End Using
            End Using
            dbConn.Close()

            If LblRcvStatus.Text = "ALREADY RECEIVED" Then
                BtnRcvSubmit.Enabled = False
                'Else
                '    BtnRcvSubmit.Enabled = True
            End If

            Dim Query = "SELECT COUNT(id) AS id FROM Endorsement WHERE endorsement_no='" & TBoxRcvEndtNo.Text & "'"
            dbConn.Open()
            Using dbCmd As New SqlCommand(Query, dbConn)
                Dim Count As Integer = dbCmd.ExecuteScalar
                LblEndtTotalQty.Text = Count
            End Using
            dbConn.Close()

            DGVRcvEndtData.DataSource = dbTable
            DGVRcvEndtData.ClearSelection()
        Catch ex As SqlException
            ' Handle database-related errors
            'MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Handle other types of exceptions
            MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub TBoxRcvEndtNo_TextChanged(sender As Object, e As EventArgs) Handles TBoxRcvEndtNo.TextChanged
        TBoxRcvEndtNo.MaxLength = 9
    End Sub

    Private Sub BtnRcvReset_Click(sender As Object, e As EventArgs) Handles BtnRcvReset.Click
        TBoxRcvEndtNo.Clear()
        TBoxRcvReceivedBy.Clear()
        LblRcvStatus.Visible = False
        LblRcvReceivedDateTitle.Visible = False
        LblRcvRcvdDate.Visible = False
        LblRcvReceiver.Visible = False
        lblRcvReceiverName.Visible = False
        DGVRcvEndtData.DataSource = Nothing
        LblEndtTotalQty.Text = 0
        BtnRcvSubmit.Enabled = False
    End Sub

    Private Sub BtnRcvSubmit_Click(sender As Object, e As EventArgs) Handles BtnRcvSubmit.Click
        If TBoxRcvEndtNo.Text = Nothing Or TBoxRcvReceivedBy.Text = Nothing Then
            MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        DateNow = DateTime.Now.ToString("MMMM dd, yyyy")
        TimeNow = DateTime.Now.ToString("HH:mm:ss")

        Try
            Dim StoredProcedure = "InsertReceivingData"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtNo", TBoxRcvEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@receiver", TBoxRcvReceivedBy.Text)
                dbCmd.Parameters.AddWithValue("@date", DateNow)
                dbCmd.Parameters.AddWithValue("@time", TimeNow)
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
            BtnRcvReset.PerformClick()
        Catch ex As SqlException
            ' Handle database-related errors
            MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Handle other types of exceptions
            MessageBox.Show(ex.Message, "Error Submitting Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub TBoxRcvEndtNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxRcvEndtNo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DropTempEndorsementTable()
    End Sub

    Dim DGVTShasRows As Boolean

    Private Sub BtnTSSearch_Click(sender As Object, e As EventArgs) Handles BtnTSSearch.Click
        Load_TSData_For_Update(CBoxTSAnalysis, "analysis")
        Load_TSData_For_Update(CBoxTSDefectType, "defect_type")
        Load_TSData_For_Update(CBoxTSActionTaken, "action_taken")
        Load_TSData_For_Update(CBoxTSLocation1, "location1")
        Load_TSData_For_Update(CBoxTSLocation2, "location2")
        Load_TSData_For_Update(CBoxTSLocation3, "location3")
        Load_TSData_For_Update(CBoxTSLocation4, "location4")
        Load_TSData_For_Update(CBoxTSTrueFailed, "true_failed")
        Load_TSData_For_Update(CBoxTSStatus, "status")

        Timer1.Stop()

        If TSNoSerial = False Then
            If ErrorProviderEndorsement.GetError(TboxTSSerialNo) = "Invalid serial number" Then
                'MessageBox.Show("The input serial number is invalid.", " Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblTSVerification.Visible = True
                LblTSVerification.Text = "INVALID SERIAL NUMBER"
                LblTSVerification.ForeColor = Color.DarkRed
                GBoxTSData.Enabled = False
                BtnTSUpdate.Enabled = False
                Return
            End If

            If TboxTSSerialNo.TextLength = 0 Then
                LblTSVerification.Visible = True
                LblTSVerification.Text = "NO SERIAL NUMBER"
                LblTSVerification.ForeColor = Color.DarkRed
                GBoxTSData.Enabled = False
                BtnTSUpdate.Enabled = False
                Return
            End If

            Try
                Dim StoredProcedure = "GetTSData"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@serialNo", TboxTSSerialNo.Text)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            LblTSRcvdDate.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_received")), dbReader.GetDateTime(dbReader.GetOrdinal("date_received")).ToString("MMMM dd, yyyy"), "N/A")
                            lblTSReceiverName.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("receiver")), dbReader.GetString(dbReader.GetOrdinal("receiver")), "N/A")

                            LblTSDataQRCode.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("serial_no")), dbReader.GetString(dbReader.GetOrdinal("serial_no")), "")

                            'TBoxTSAnalysis.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("analysis")), dbReader.GetString(dbReader.GetOrdinal("analysis")), "")
                            CBoxTSAnalysis.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("analysis")), dbReader.GetString(dbReader.GetOrdinal("analysis")), "")
                            'TBoxTSActionTaken.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("action_taken")), dbReader.GetString(dbReader.GetOrdinal("action_taken")), "")
                            CBoxTSActionTaken.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("action_taken")), dbReader.GetString(dbReader.GetOrdinal("action_taken")), "")
                            'TBoxTSLocation1.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location1")), dbReader.GetString(dbReader.GetOrdinal("location1")), "")
                            CBoxTSLocation1.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location1")), dbReader.GetString(dbReader.GetOrdinal("location1")), "")
                            'TBoxTSLocation2.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location2")), dbReader.GetString(dbReader.GetOrdinal("location2")), "")
                            CBoxTSLocation2.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location2")), dbReader.GetString(dbReader.GetOrdinal("location2")), "")
                            'TBoxTSLocation3.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location3")), dbReader.GetString(dbReader.GetOrdinal("location3")), "")
                            CBoxTSLocation3.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location3")), dbReader.GetString(dbReader.GetOrdinal("location3")), "")
                            'TBoxTSLocation4.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location4")), dbReader.GetString(dbReader.GetOrdinal("location4")), "")
                            CBoxTSLocation4.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location4")), dbReader.GetString(dbReader.GetOrdinal("location4")), "")
                            'TBoxTSLocation5.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location5")), dbReader.GetString(dbReader.GetOrdinal("location5")), "")
                            CBoxTSTrueFailed.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("true_failed")), dbReader.GetString(dbReader.GetOrdinal("true_failed")), "")
                            TBoxTSRepairedBy.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("repaired_by")), dbReader.GetString(dbReader.GetOrdinal("repaired_by")), "")
                            DTPTSDateRepaired.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_repaired")), dbReader.GetDateTime(dbReader.GetOrdinal("date_repaired")).ToString(), "")
                            'TBoxTSDefectType.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("defect_type")), dbReader.GetString(dbReader.GetOrdinal("defect_type")), "")
                            CBoxTSDefectType.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("defect_type")), dbReader.GetString(dbReader.GetOrdinal("defect_type")), "")
                            'TBoxTSStatus.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("status")), dbReader.GetString(dbReader.GetOrdinal("status")), "")
                            CBoxTSStatus.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("status")), dbReader.GetString(dbReader.GetOrdinal("status")), "")
                            TBoxTSRemarks.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("remarks")), dbReader.GetString(dbReader.GetOrdinal("remarks")), "")
                            'LblTSRcvdDate.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_received")), dbReader.GetString(dbReader.GetOrdinal("date_received")), "N/A")

                            Dim DateTS = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date")), dbReader.GetDateTime(dbReader.GetOrdinal("date")).ToString("MMMM dd, yyyy"), "")
                            Dim TimeTS = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("time")), dbReader.GetTimeSpan(dbReader.GetOrdinal("time")).ToString("hh\:mm\:ss"), "")


                            'Get value to the declared original data of the TS Search
                            'analysis = TBoxTSAnalysis.Text
                            analysis = CBoxTSAnalysis.Text
                            'action_taken = TBoxTSActionTaken.Text
                            action_taken = CBoxTSActionTaken.Text
                            'location1 = TBoxTSLocation1.Text
                            location1 = CBoxTSLocation1.Text
                            'location2 = TBoxTSLocation2.Text
                            location2 = CBoxTSLocation2.Text
                            'location3 = TBoxTSLocation3.Text
                            location3 = CBoxTSLocation3.Text
                            'location4 = TBoxTSLocation4.Text
                            location4 = CBoxTSLocation4.Text
                            'location5 = TBoxTSLocation5.Text         
                            true_failed = CBoxTSTrueFailed.Text
                            repaired_by = TBoxTSRepairedBy.Text
                            date_repaired = DTPTSDateRepaired.Value.ToString("MMM dd, yyyy")
                            'defect_type = TBoxTSDefectType.Text
                            defect_type = CBoxTSDefectType.Text
                            'status = TBoxTSStatus.Text
                            status = CBoxTSStatus.Text
                            remarks = TBoxTSRemarks.Text

                            LblTSTimeStamp.Visible = True
                            'LblTSReceivedDateTitle.Visible = True
                            'LblTSRcvdDate.Visible = True
                            'LblTSReceiver.Visible = True
                            'lblTSReceiverName.Visible = True
                            LblTSDataQRCode.Visible = True
                            GBoxTSData.Enabled = True
                            BtnTSUpdate.Enabled = True

                            'Check if already recevied or not yet received
                            If dbReader.IsDBNull(dbReader.GetOrdinal("receiver")) And dbReader.IsDBNull(dbReader.GetOrdinal("date_received")) And dbReader.IsDBNull(dbReader.GetOrdinal("time_received")) Then
                                ClearFetchData()
                                LblTSVerification.ForeColor = Color.DarkRed
                                LblTSVerification.Text = "NOT YET RECEIVED" ' or any other default value or message
                                'LblTSRcvdDate.ForeColor = Color.DarkRed
                                'lblTSReceiverName.ForeColor = Color.DarkRed
                                LblTSVerification.Visible = True

                                'LblTSReceivedDateTitle.Visible = False
                                'LblTSRcvdDate.Visible = False
                                'LblTSRcvdDate.Text = Nothing
                                'LblTSReceiver.Visible = False
                                'lblTSReceiverName.Visible = False
                                'lblTSReceiverName.Text = Nothing

                                LblTSTimeStamp.Text = Nothing
                                LblTSDataQRCode.Text = Nothing
                                LblTSDataQRCode.Visible = False
                                GBoxTSData.Enabled = False
                                BtnTSUpdate.Enabled = False
                            Else
                                'Check if verified or unverified
                                If dbReader.IsDBNull(dbReader.GetOrdinal("repaired_by")) Or dbReader.IsDBNull(dbReader.GetOrdinal("date_repaired")) Or dbReader.IsDBNull(dbReader.GetOrdinal("status")) Then
                                    LblTSVerification.Visible = True
                                    LblTSRcvdDate.ForeColor = SystemColors.ControlText
                                    lblTSReceiverName.ForeColor = SystemColors.ControlText
                                    LblTSVerification.ForeColor = Color.DarkRed
                                    LblTSVerification.Text = "UNVERIFIED" ' or any other default value or message
                                    GBoxData.Enabled = False

                                    LblTSReceivedDateTitle.Visible = True
                                    LblTSRcvdDate.Visible = True
                                    LblTSReceiver.Visible = True
                                    lblTSReceiverName.Visible = True


                                    LblTSTimeStamp.Text = Nothing
                                    LblTSDataQRCode.Visible = True
                                    'GBoxTSData.Enabled = True
                                    'BtnTSUpdate.Enabled = True

                                    'TBoxTSAnalysis.Focus()
                                    CBoxTSAnalysis.Focus()

                                    'TBoxTSAnalysis_TextChanged(sender, e)
                                    CBoxTSAnalysis_TextChanged(sender, e)
                                    'TBoxTSDefectType_TextChanged(sender, e)
                                    CBoxTSDefectType_TextChanged(sender, e)
                                    'TBoxTSActionTaken_TextChanged(sender, e)
                                    CBoxTSActionTaken_TextChanged(sender, e)
                                    TBoxTSRepairedBy_TextChanged(sender, e)
                                    'TBoxTSStatus_TextChanged(sender, e)
                                    CBoxTSStatus_TextChanged(sender, e)
                                Else
                                    LblTSVerification.ForeColor = Color.DarkGreen
                                    LblTSVerification.Text = Nothing ' or any other default value or message
                                    GBoxData.Enabled = True

                                    'TBoxTSAnalysis_TextChanged(sender, e)
                                    CBoxTSAnalysis_TextChanged(sender, e)
                                    'TBoxTSDefectType_TextChanged(sender, e)
                                    CBoxTSDefectType_TextChanged(sender, e)
                                    'TBoxTSActionTaken_TextChanged(sender, e)
                                    CBoxTSActionTaken_TextChanged(sender, e)
                                    TBoxTSRepairedBy_TextChanged(sender, e)
                                    'TBoxTSStatus_TextChanged(sender, e)
                                    CBoxTSStatus_TextChanged(sender, e)

                                    LblTSReceivedDateTitle.Visible = True
                                    LblTSRcvdDate.Visible = True
                                    LblTSReceiver.Visible = True
                                    lblTSReceiverName.Visible = True
                                    LblTSTimeStamp.Text = "Last update: " & DateTS & " " & TimeTS
                                    LblTSDataQRCode.Visible = True
                                    'GBoxTSData.Enabled = True
                                    'BtnTSUpdate.Enabled = True
                                End If
                            End If
                        Else
                            ClearFetchData()
                            LblTSRcvdDate.ForeColor = SystemColors.ControlText
                            lblTSReceiverName.ForeColor = SystemColors.ControlText
                            LblTSVerification.ForeColor = Color.DarkRed
                            LblTSVerification.Text = "NO RECORD FOUND" ' or any other default value or message
                            LblTSVerification.Visible = True
                            LblTSDataQRCode.Visible = False
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Searching Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            Try
                Dim StoredProcedure = "CreateTempTSEndorsementTable"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            Try
                Dim StoredProcedure = "InserTempToTSEndorsementData"
                Dim dbTable As New DSTSEndorsementData.DTTSEndtDataDataTable
                dbTablewSerial = dbTable
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@serialNo", TboxTSSerialNo.Text)
                    Using dbAdapter As New SqlDataAdapter(dbCmd)
                        dbAdapter.Fill(dbTable)
                    End Using
                End Using
                dbConn.Close()
                DGVTSEndorsementData.DataSource = dbTablewSerial
                'DGVTSEndorsementData.ClearSelection()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        End If

        If TSNoSerial = True Then
            If TboxTSEndtNo.Text = Nothing And TboxTSFailureSymptoms.Text = Nothing Then
                'MessageBox.Show("The input serial number is invalid.", " Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblTSVerification.Visible = True
                LblTSVerification.Text = "NO DATA TO SEARCH"
                LblTSVerification.ForeColor = Color.DarkRed
                Return
            End If

            Try
                Dim StoredProcedure = "GetTSDataNoSerial"
                Dim dbTable As New DSTSEndorsementData.DTTSEndTDataNoSerialDataTable
                dbTablewoSerial = dbTable
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@endtNo", TboxTSEndtNo.Text)
                    dbCmd.Parameters.AddWithValue("@failureSymptoms", TboxTSFailureSymptoms.Text)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            DGVTShasRows = True
                        Else
                            DGVTShasRows = False
                            ClearFetchData()
                            LblTSRcvdDate.ForeColor = SystemColors.ControlText
                            lblTSReceiverName.ForeColor = SystemColors.ControlText
                            LblTSVerification.ForeColor = Color.DarkRed
                            LblTSVerification.Text = "NO RECORD FOUND" ' or any other default value or message
                            DGVTSEndorsementData.DataSource = Nothing
                            LblTSVerification.Visible = True
                            LblTSDataQRCode.Visible = False

                            GBoxTSData.Enabled = False
                            BtnTSUpdate.Enabled = False
                            Return
                        End If
                    End Using
                End Using
                dbConn.Close()

                If DGVTShasRows = True Then
                    dbConn.Open()
                    Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                        dbCmd.CommandType = CommandType.StoredProcedure
                        dbCmd.Parameters.AddWithValue("@endtNo", TboxTSEndtNo.Text)
                        dbCmd.Parameters.AddWithValue("@failureSymptoms", TboxTSFailureSymptoms.Text)
                        Using dbAdapter As New SqlDataAdapter(dbCmd)
                            dbAdapter.Fill(dbTable)
                        End Using
                    End Using
                    dbConn.Close()
                    DGVTSEndorsementData.DataSource = dbTablewoSerial
                    DGVTSEndorsementData.ClearSelection()
                    LblTSDataQRCode.Text = Nothing
                    LblTSVerification.Text = Nothing
                    LblTSReceivedDateTitle.Visible = False
                    LblTSRcvdDate.Visible = False
                    LblTSRcvdDate.Text = Nothing
                    LblTSReceiver.Visible = False
                    lblTSReceiverName.Visible = False
                    lblTSReceiverName.Text = Nothing
                    'TBoxTSAnalysis.Clear()
                    CBoxTSAnalysis.Text = Nothing
                    CBoxTSAnalysis.Text = Nothing
                    'ErrorProviderEndorsement.SetError(TBoxTSAnalysis, Nothing)
                    ErrorProviderEndorsement.SetError(CBoxTSAnalysis, Nothing)
                    'TBoxTSActionTaken.Clear()
                    CBoxTSActionTaken.Text = Nothing
                    'ErrorProviderEndorsement.SetError(TBoxTSActionTaken, Nothing)
                    ErrorProviderEndorsement.SetError(CBoxTSActionTaken, Nothing)
                    'TBoxTSLocation1.Clear()
                    CBoxTSLocation1.Text = Nothing
                    'TBoxTSLocation2.Clear()
                    CBoxTSLocation2.Text = Nothing
                    'TBoxTSLocation3.Clear()
                    CBoxTSLocation3.Text = Nothing
                    'TBoxTSLocation4.Clear()
                    CBoxTSLocation4.Text = Nothing
                    'TBoxTSLocation5.Clear()
                    CBoxTSTrueFailed.Text = Nothing
                    TBoxTSRepairedBy.Clear()
                    ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, Nothing)
                    DTPTSDateRepaired.ResetText()
                    'TBoxTSDefectType.Clear()
                    CBoxTSDefectType.Text = Nothing
                    'ErrorProviderEndorsement.SetError(TBoxTSDefectType, Nothing)
                    ErrorProviderEndorsement.SetError(CBoxTSDefectType, Nothing)
                    'TBoxTSStatus.Clear()
                    CBoxTSStatus.Text = Nothing
                    'ErrorProviderEndorsement.SetError(TBoxTSStatus, Nothing)
                    ErrorProviderEndorsement.SetError(CBoxTSStatus, Nothing)
                    TBoxTSRemarks.Clear()
                    LblTSTimeStamp.Text = Nothing

                    GBoxTSData.Enabled = False
                    BtnTSUpdate.Enabled = False
                End If
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub TboxTSSerialNo_TextChanged(sender As Object, e As EventArgs) Handles TboxTSSerialNo.TextChanged
        TboxTSSerialNo.MaxLength = 11
        TboxTSSerialNo.CharacterCasing = CharacterCasing.Upper

        Dim RegexSerialNo = Regex.Match(TboxTSSerialNo.Text, "[0-9]{2}[0-9]{2}BC[2-9A-HJ-NP-Z]{5}")

        If TboxTSSerialNo.Text.Length > 0 Then
            If TboxTSSerialNo.Text = RegexSerialNo.Value Then
                ErrorProviderEndorsement.SetError(TboxTSSerialNo, Nothing)
            Else
                ErrorProviderEndorsement.SetError(TboxTSSerialNo, "Invalid serial number")
                ClearFetchData()
            End If
        Else
            If TboxTSSerialNo.TextLength = 0 Then
                ErrorProviderEndorsement.SetError(TboxTSSerialNo, Nothing)
            End If
        End If
    End Sub

    Private Sub BtnTSClear_Click(sender As Object, e As EventArgs) Handles BtnTSClear.Click
        If ChkBoxTSSerialNo.Checked = True Then
            TboxTSEndtNo.Clear()
            TboxTSFailureSymptoms.Clear()
            DGVTSEndorsementData.DataSource = Nothing
        ElseIf ChkBoxTSSerialNo.Checked = False Then
            TboxTSSerialNo.Clear()
        End If

        ClearFetchData()
    End Sub

    Private Sub ClearFetchData()
        i = Nothing
        LblTSDataQRCode.Text = Nothing
        LblTSVerification.Visible = False
        LblTSVerification.Text = Nothing
        LblTSReceivedDateTitle.Visible = False
        LblTSRcvdDate.Visible = False
        LblTSRcvdDate.Text = Nothing
        LblTSReceiver.Visible = False
        lblTSReceiverName.Visible = False
        lblTSReceiverName.Text = Nothing
        'TBoxTSAnalysis.Clear()
        CBoxTSAnalysis.Text = Nothing
        'ErrorProviderEndorsement.SetError(TBoxTSAnalysis, Nothing)
        ErrorProviderEndorsement.SetError(CBoxTSAnalysis, Nothing)
        'TBoxTSActionTaken.Clear()
        CBoxTSActionTaken.Text = Nothing
        'ErrorProviderEndorsement.SetError(TBoxTSActionTaken, Nothing)
        ErrorProviderEndorsement.SetError(CBoxTSActionTaken, Nothing)
        'TBoxTSLocation1.Clear()
        CBoxTSLocation1.Text = Nothing
        'TBoxTSLocation2.Clear()
        CBoxTSLocation2.Text = Nothing
        'TBoxTSLocation3.Clear()
        CBoxTSLocation3.Text = Nothing
        'TBoxTSLocation4.Clear()
        CBoxTSLocation4.Text = Nothing
        'TBoxTSLocation5.Clear()
        CBoxTSTrueFailed.Text = Nothing
        TBoxTSRepairedBy.Clear()
        ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, Nothing)
        DTPTSDateRepaired.ResetText()
        'TBoxTSDefectType.Clear()
        CBoxTSDefectType.Text = Nothing
        'ErrorProviderEndorsement.SetError(TBoxTSDefectType, Nothing)
        ErrorProviderEndorsement.SetError(CBoxTSDefectType, Nothing)
        'TBoxTSStatus.Clear()
        CBoxTSStatus.Text = Nothing
        'ErrorProviderEndorsement.SetError(TBoxTSStatus, Nothing)
        ErrorProviderEndorsement.SetError(CBoxTSStatus, Nothing)
        TBoxTSRemarks.Clear()
        LblTSTimeStamp.Text = Nothing

        GBoxTSData.Enabled = False
        BtnTSUpdate.Enabled = False

        'TboxTSEndtNo.Clear()
        'TboxTSFailureSymptoms.Clear()
    End Sub

    Dim analysis, defect_type, action_taken, location1, location2, location3, location4, true_failed, repaired_by, date_repaired, status, remarks As String 'Use to verify the original value of TS Data before updating

    Private Sub BtnTSUpdate_Click(sender As Object, e As EventArgs) Handles BtnTSUpdate.Click
        If analysis = CBoxTSAnalysis.Text And defect_type = CBoxTSDefectType.Text And action_taken = CBoxTSActionTaken.Text And location1 = CBoxTSLocation1.Text And location2 = CBoxTSLocation2.Text And location3 = CBoxTSLocation3.Text And location4 = CBoxTSLocation4.Text And true_failed = CBoxTSTrueFailed.Text And repaired_by = TBoxTSRepairedBy.Text And date_repaired = DTPTSDateRepaired.Value.ToString("MMM dd, yyyy") And status = CBoxTSStatus.Text And remarks = TBoxTSRemarks.Text Then
            'If analysis = TBoxTSAnalysis.Text And defect_type = TBoxTSDefectType.Text Then
            MessageBox.Show("No changes found on the data.", "Unable to Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If TSNoSerial = False Then
            ' check if already received
            Try
                Dim StoredProcedure = "GetTSData"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@serialNo", TboxTSSerialNo.Text)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            If dbReader.IsDBNull(dbReader.GetOrdinal("receiver")) Or dbReader.IsDBNull(dbReader.GetOrdinal("date_received")) Then
                                MessageBox.Show("Serial number: " & TboxTSSerialNo.Text & vbCrLf & vbCrLf & "This serial number has not been received yet." & vbCrLf & vbCrLf & "Unable to proceed!", "Unreceived Serial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                dbConn.Close()
                                Return
                            End If
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            If CBoxTSAnalysis.Text = Nothing Or CBoxTSDefectType.Text = Nothing Or CBoxTSActionTaken.Text = Nothing Or TBoxTSRepairedBy.Text = Nothing Or CBoxTSStatus.Text = Nothing Then
                MessageBox.Show("Please ensure the required fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                DateNow = DateTime.Now.ToString("MMMM dd, yyyy")
                TimeNow = DateTime.Now.ToString("HH:mm:ss")
                Dim StoredProcedure = "UpdateTSData"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@serialNo", LblTSDataQRCode.Text)
                    'dbCmd.Parameters.AddWithValue("@analysis", TBoxTSAnalysis.Text)
                    dbCmd.Parameters.AddWithValue("@analysis", CBoxTSAnalysis.Text)
                    'dbCmd.Parameters.AddWithValue("@actionTaken", TBoxTSActionTaken.Text)
                    dbCmd.Parameters.AddWithValue("@actionTaken", CBoxTSActionTaken.Text)
                    'dbCmd.Parameters.AddWithValue("@location1", TBoxTSLocation1.Text)
                    dbCmd.Parameters.AddWithValue("@location1", CBoxTSLocation1.Text)
                    'dbCmd.Parameters.AddWithValue("@location2", TBoxTSLocation2.Text)
                    dbCmd.Parameters.AddWithValue("@location2", CBoxTSLocation2.Text)
                    'dbCmd.Parameters.AddWithValue("@location3", TBoxTSLocation3.Text)
                    dbCmd.Parameters.AddWithValue("@location3", CBoxTSLocation3.Text)
                    'dbCmd.Parameters.AddWithValue("@location4", TBoxTSLocation4.Text)
                    dbCmd.Parameters.AddWithValue("@location4", CBoxTSLocation4.Text)
                    'dbCmd.Parameters.AddWithValue("@location5", TBoxTSLocation5.Text)
                    dbCmd.Parameters.AddWithValue("@trueFailed", CBoxTSTrueFailed.Text)
                    dbCmd.Parameters.AddWithValue("@repairedBy", TBoxTSRepairedBy.Text)
                    dbCmd.Parameters.AddWithValue("@dateRepaired", DTPTSDateRepaired.Value)
                    'dbCmd.Parameters.AddWithValue("@defectType", TBoxTSDefectType.Text)
                    dbCmd.Parameters.AddWithValue("@defectType", CBoxTSDefectType.Text)
                    'dbCmd.Parameters.AddWithValue("@status", TBoxTSStatus.Text)
                    dbCmd.Parameters.AddWithValue("@status", CBoxTSStatus.Text)
                    dbCmd.Parameters.AddWithValue("@remarks", TBoxTSRemarks.Text)
                    dbCmd.Parameters.AddWithValue("@date", DateNow)
                    dbCmd.Parameters.AddWithValue("@time", TimeNow)
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()
                LblTSTimeStamp.Visible = True
                LblTSVerification.Text = "RECORD UPDATED"
                LblTSVerification.ForeColor = Color.DarkGreen
                Timer1.Interval = 250
                Timer1.Start()

                dbConn.Open()
                Using dbCmd As New SqlCommand("GetTSData", dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@serialNo", TboxTSSerialNo.Text)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            LblTSTimeStamp.Text = "Last update: " & dbReader.GetDateTime(dbReader.GetOrdinal("date")).ToString("MMMM dd, yyyy") & " " & dbReader.GetTimeSpan(dbReader.GetOrdinal("time")).ToString("hh\:mm\:ss")
                        End If
                    End Using
                End Using
                dbConn.Close()
                TboxTSSerialNo.Focus()
                TboxTSSerialNo.SelectAll()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        End If

        If TSNoSerial = True Then
            Try
                Dim StoredProcedure = "GetTSDataByID"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@id", i)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            If dbReader.IsDBNull(dbReader.GetOrdinal("receiver")) Or dbReader.IsDBNull(dbReader.GetOrdinal("date_received")) Then
                                MessageBox.Show("Serial number: " & TboxTSSerialNo.Text & vbCrLf & vbCrLf & "This serial number has not been received yet." & vbCrLf & vbCrLf & "Unable to proceed!", "Unreceived Serial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                dbConn.Close()
                                Return
                            End If
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            If CBoxTSAnalysis.Text = Nothing Or CBoxTSDefectType.Text = Nothing Or CBoxTSActionTaken.Text = Nothing Or TBoxTSRepairedBy.Text = Nothing Or CBoxTSStatus.Text = Nothing Then
                MessageBox.Show("Please ensure the required fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                DateNow = DateTime.Now.ToString("MMMM dd, yyyy")
                TimeNow = DateTime.Now.ToString("HH:mm:ss")
                Dim StoredProcedure = "UpdateTSDataNoSerial"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@id", i)
                    'dbCmd.Parameters.AddWithValue("@analysis", TBoxTSAnalysis.Text)
                    dbCmd.Parameters.AddWithValue("@analysis", CBoxTSAnalysis.Text)
                    'dbCmd.Parameters.AddWithValue("@actionTaken", TBoxTSActionTaken.Text)
                    dbCmd.Parameters.AddWithValue("@actionTaken", CBoxTSActionTaken.Text)
                    'dbCmd.Parameters.AddWithValue("@location1", TBoxTSLocation1.Text)
                    dbCmd.Parameters.AddWithValue("@location1", CBoxTSLocation1.Text)
                    'dbCmd.Parameters.AddWithValue("@location2", TBoxTSLocation2.Text)
                    dbCmd.Parameters.AddWithValue("@location2", CBoxTSLocation2.Text)
                    'dbCmd.Parameters.AddWithValue("@location3", TBoxTSLocation3.Text)
                    dbCmd.Parameters.AddWithValue("@location3", CBoxTSLocation3.Text)
                    'dbCmd.Parameters.AddWithValue("@location4", TBoxTSLocation4.Text)
                    dbCmd.Parameters.AddWithValue("@location4", CBoxTSLocation4.Text)
                    'dbCmd.Parameters.AddWithValue("@location5", TBoxTSLocation5.Text)
                    dbCmd.Parameters.AddWithValue("@trueFailed", CBoxTSTrueFailed.Text)
                    dbCmd.Parameters.AddWithValue("@repairedBy", TBoxTSRepairedBy.Text)
                    dbCmd.Parameters.AddWithValue("@dateRepaired", DTPTSDateRepaired.Value)
                    'dbCmd.Parameters.AddWithValue("@defectType", TBoxTSDefectType.Text)
                    dbCmd.Parameters.AddWithValue("@defectType", CBoxTSDefectType.Text)
                    'dbCmd.Parameters.AddWithValue("@status", TBoxTSStatus.Text)
                    dbCmd.Parameters.AddWithValue("@status", CBoxTSStatus.Text)
                    dbCmd.Parameters.AddWithValue("@remarks", TBoxTSRemarks.Text)
                    dbCmd.Parameters.AddWithValue("@date", DateNow)
                    dbCmd.Parameters.AddWithValue("@time", TimeNow)
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()
                LblTSTimeStamp.Visible = True
                LblTSVerification.Text = "RECORD UPDATED"
                LblTSVerification.ForeColor = Color.DarkGreen
                Timer1.Interval = 250
                Timer1.Start()

                dbConn.Open()
                Using dbCmd As New SqlCommand("GetTSDataByID", dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@id", i)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            LblTSTimeStamp.Text = "Last update: " & dbReader.GetDateTime(dbReader.GetOrdinal("date")).ToString("MMMM dd, yyyy") & " " & dbReader.GetTimeSpan(dbReader.GetOrdinal("time")).ToString("hh\:mm\:ss")
                        End If
                    End Using
                End Using
                dbConn.Close()
                TboxTSSerialNo.Focus()
                TboxTSSerialNo.SelectAll()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            'Update latest table
            Try
                Dim StoredProcedure = "GetTSDataNoSerial"
                Dim dbTable As New DSTSEndorsementData.DTTSEndTDataNoSerialDataTable
                dbTablewoSerial = dbTable
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbCmd.Parameters.AddWithValue("@endtNo", TboxTSEndtNo.Text)
                    dbCmd.Parameters.AddWithValue("@failureSymptoms", TboxTSFailureSymptoms.Text)
                    Using dbAdapter As New SqlDataAdapter(dbCmd)
                        dbAdapter.Fill(dbTable)
                        DGVTSEndorsementData.DataSource = dbTablewoSerial
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        End If
    End Sub

    'Private Sub TBoxTSDefectType_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSDefectType.TextChanged
    '    TBoxTSDefectType.CharacterCasing = CharacterCasing.Upper
    '    If TBoxTSDefectType.TextLength = 0 Then
    '        ErrorProviderEndorsement.SetError(TBoxTSDefectType, "Please fill the information")
    '    Else
    '        ErrorProviderEndorsement.SetError(TBoxTSDefectType, Nothing)
    '    End If
    'End Sub

    'Private Sub TBoxTSAnalysis_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSAnalysis.TextChanged
    '    TBoxTSAnalysis.CharacterCasing = CharacterCasing.Upper
    '    If TBoxTSAnalysis.TextLength = 0 Then
    '        ErrorProviderEndorsement.SetError(TBoxTSAnalysis, "Please fill the information")
    '    Else
    '        ErrorProviderEndorsement.SetError(TBoxTSAnalysis, Nothing)
    '    End If
    'End Sub 

    'Private Sub TBoxTSActionTaken_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSActionTaken.TextChanged
    '    TBoxTSActionTaken.CharacterCasing = CharacterCasing.Upper
    '    If TBoxTSActionTaken.TextLength = 0 Then
    '        ErrorProviderEndorsement.SetError(TBoxTSActionTaken, "Please fill the information")
    '    Else
    '        ErrorProviderEndorsement.SetError(TBoxTSActionTaken, Nothing)
    '    End If
    'End Sub

    'Private Sub TBoxTSLocation1_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation1.TextChanged
    '    TBoxTSLocation1.CharacterCasing = CharacterCasing.Upper
    '    'If TBoxTSLocation1.TextLength = 0 Then
    '    '    ErrorProviderEndorsement.SetError(TBoxTSLocation1, "Please fill the information")
    '    'Else
    '    '    ErrorProviderEndorsement.SetError(TBoxTSLocation1, Nothing)
    '    'End If
    'End Sub

    'Private Sub TBoxTSLocation2_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation2.TextChanged
    '    TBoxTSLocation2.CharacterCasing = CharacterCasing.Upper
    'End Sub

    'Private Sub TBoxTSLocation3_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation3.TextChanged
    '    TBoxTSLocation3.CharacterCasing = CharacterCasing.Upper
    'End Sub

    'Private Sub TBoxTSLocation4_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation4.TextChanged
    '    TBoxTSLocation4.CharacterCasing = CharacterCasing.Upper
    'End Sub

    'Private Sub TBoxTSLocation5_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation5.TextChanged
    '    TBoxTSLocation5.CharacterCasing = CharacterCasing.Upper
    'End Sub

    Private Sub TBoxTSRepairedBy_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSRepairedBy.TextChanged
        TBoxTSRepairedBy.CharacterCasing = CharacterCasing.Upper
        If TBoxTSRepairedBy.TextLength = 0 Then
            ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, Nothing)
        End If
    End Sub

    'Private Sub TBoxTSStatus_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSStatus.TextChanged
    '    TBoxTSStatus.CharacterCasing = CharacterCasing.Upper
    '    If TBoxTSStatus.TextLength = 0 Then
    '        ErrorProviderEndorsement.SetError(TBoxTSStatus, "Please fill the information")
    '    Else
    '        ErrorProviderEndorsement.SetError(TBoxTSStatus, Nothing)
    '    End If
    'End Sub

    Private Sub TBoxTSRemarks_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSRemarks.TextChanged
        TBoxTSRemarks.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private elapsedTime As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblTSVerification.Visible = Not LblTSVerification.Visible

        elapsedTime += Timer1.Interval

        If elapsedTime >= 5000 Then
            Timer1.Stop()
            elapsedTime = 0
        End If
    End Sub

    Private Sub TBoxRcvReceivedBy_TextChanged(sender As Object, e As EventArgs) Handles TBoxRcvReceivedBy.TextChanged
        TBoxRcvReceivedBy.MaxLength = 30
        TBoxRcvReceivedBy.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub ChkBoxEndtSerialNo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBoxEndtSerialNo.CheckedChanged
        If ChkBoxEndtSerialNo.Checked = True Then
            TBoxSerialNo.Enabled = False
            TBoxSerialNo.Clear()
        Else
            If ChkBoxEndtSerialNo.Checked = False Then
                If TBoxSerialNo.Enabled = True Then
                    TBoxSerialNo.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub CBoxStation_TextChanged(sender As Object, e As EventArgs) Handles CBoxStation.TextChanged
        If CBoxStation.Text.Length = 0 Then
            CBoxFailureSymptoms.DropDownHeight = 106
        End If

        'Load_FailureSymptoms()
    End Sub

    Private Sub CBoxStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxStation.SelectedIndexChanged
        Load_FailureSymptoms(CBoxFailureSymptoms, CBoxStation.Text)
        'FailureSymptoms = CBoxStation.Text
    End Sub

    Private Sub BtnInqSearch_Click(sender As Object, e As EventArgs) Handles BtnInqSearch.Click
        'If InquerywDate = False Then
        '    Load_Inquiry()
        '    Load_InquiryDataCount()
        'ElseIf InquerywDate = True Then
        '    Load_InquirywDate()
        '    Load_InquiryDateFailed()
        '    Load_InquirywDateDataCount()
        'End If

        If Inquiry = True Then 'Inquiry witout endorsement number and dates
            Load_Inquiry()
            Load_InquiryCount()
            Load_InquiryUnverifiedCount()
        End If

        If InquiryEndtNo = True Then 'Inquiry with endorsement number and dates
            Load_InquiryEndtNo()
            Load_InquiryEndtNoCount()
            Load_InquiryEndtNoUnverifiedCount()
        End If

        '-----------------------
        If InquirywDateFailed = True Then 'Inquiry with date failed
            Load_InquiryDateFailed()
            Load_InquiryDateFailedCount()
            Load_InquiryDateFailedUnverifiedCount()
        End If

        '-----------------------
        If InquirywEndtDate = True Then 'Inquiry with endorsement date
            Load_InquiryEndtDate()
            Load_InquiryEndtDateCount()
            Load_InquiryEndtDateUnverifiedCount()
        End If

        '-----------------------
        If InquirywTSDate = True Then 'Inquiry with TS date
            Load_InquiryTSDate()
            Load_InquiryTSDateCount()
            Load_InquiryTSDateUnverifiedCount() 'For verification if applicable
        End If


        '-----------------------
        If InquiryDateFailedEndt = True Then 'Inquiry with Date Failed and Endorsement Date
            Load_InquiryDateFailedEndt()
            Load_InquiryDateFailedEndtCount()
            Load_InquiryDateFailedEndtUnverifiedCount()
        End If

        '-----------------------
        If InquiryDateFailedTS = True Then 'Inquiry with Date Failed and TS Date
            Load_InquiryDateFailedTS()
            Load_InquiryDateFailedTSCount()
            Load_InquiryDateFailedTSUnverifiedCount()
        End If

        '-----------------------
        If InquiryDateEndtTS = True Then 'Inquiry with Endorsement Date and TS Date
            Load_InquiryEndtDateTS()
            Load_InquiryEndtDateTSCount()
            Load_InquiryEndtDateTSUnverifiedCount()
        End If

        '-----------------------
        If InquiryFailedEndtTS = True Then 'Inquiry with Date Failed, Endorsement Date, and TS date
            Load_InquiryFailedEndtTS()
            Load_InquiryFailedEndtTSCount()
            Load_InquiryFailedEndtTSUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoDateFailed = True Then
            Load_InquiryEndtNoDateFailed()
            Load_InquiryEndtNoDateFailedCount()
            Load_InquiryEndtNoDateFailedUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoEndtDate = True Then
            Load_InquiryEndtNoEndtDate()
            Load_InquiryEndtNoEndtDateCount()
            Load_InquiryEndtNoEndtDateUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoTS = True Then
            Load_InquiryEndtNoTSDate()
            Load_InquiryEndtNoTSDateCount()
            Load_InquiryEndtNoTSDateUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoDateFailedEndtDate = True Then
            Load_InquiryEndtNoDateFailedEndt()
            Load_InquiryEndtNoDateFailedEndtCount()
            Load_InquiryEndtNoDateFailedEndtUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoDateFailedTS = True Then
            Load_InquiryEndtNoDateFailedTS()
            Load_InquiryEndtNoDateFailedTSCount()
            Load_InquiryEndtNoDateFailedTSUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoEndtDateTS = True Then
            Load_InquiryEndtNoEndtDateTS()
            Load_InquiryEndtNoEndtDateTSCount()
            Load_InquiryEndtNoEndtDateTSUnverifiedCount()
        End If

        '-----------------------
        If InquiryEndtNoFailedEndtDateTS = True Then
            Load_InquiryEndtNoFailedEndtTS()
            Load_InquiryEndtNoFailedEndtTSCount()
            Load_InquiryEndtNoFailedEndtTSUnverifiedCount()
        End If

        'MsgBox(Inquiry, InquirywDateFailed & InquirywEndtDate & InquirywTSDate)
        'MsgBox(InquiryDateFailedEndt & InquiryDateFailedTS & InquiryDateEndtTS & InquiryFailedEndtTS)
    End Sub

    Dim Inquiry As Boolean = True 'default search witout endorsement number and dates
    Dim InquiryEndtNo As Boolean 'Search with endorsement number without dates ---new done
    Dim InquirywDateFailed, InquirywEndtDate, InquirywTSDate As Boolean 'single combobox
    Dim InquiryDateFailedEndt, InquiryDateFailedTS, InquiryDateEndtTS As Boolean 'dual combobox
    Dim InquiryEndtNoDateFailed, InquiryEndtNoEndtDate, InquiryEndtNoTS As Boolean 'dual combobox with endorsement number ----new

    Dim InquiryFailedEndtTS As Boolean 'multiple combobox
    Dim InquiryEndtNoDateFailedEndtDate, InquiryEndtNoDateFailedTS, InquiryEndtNoEndtDateTS As Boolean 'multiple combobox with endorsement number all posible search ---new

    Dim TSNoSerial As Boolean
    Dim dbTablewSerial, dbTablewoSerial As DataTable

    Private Sub DGVTSEndorsementData_SelectionChanged(sender As Object, e As EventArgs) Handles DGVTSEndorsementData.SelectionChanged
        If TSNoSerial = True Then
            Dim iRowIndex As Integer
            Dim iRow As String

            For n As Integer = 0 To DGVTSEndorsementData.SelectedCells.Count - 1
                iRowIndex = DGVTSEndorsementData.SelectedCells.Item(n).RowIndex
                iRow = DGVTSEndorsementData.Rows(iRowIndex).Cells(0).Value.ToString
                i = iRow
                'MsgBox(n)
                'MsgBox(i & " & Row index " & Format(iRowIndex) & " " & iRowIndex)
            Next

            dgvIntRow = iRowIndex
            'MsgBox("selection change " & i)


            'Fetch Data
            If i <> 0 Then
                If DGVTShasRows = True Then
                    If dbConn.State = ConnectionState.Open Then
                        dbConn.Close()
                    End If

                    Try
                        Dim StoredProcedure = "GetTSDataByID"
                        Dim dbTable As New DataTable
                        dbConn.Open()
                        Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                            dbCmd.CommandType = CommandType.StoredProcedure
                            dbCmd.Parameters.AddWithValue("@id", i)
                            Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                                dbReader.Read()
                                If dbReader.HasRows Then
                                    'MsgBox("has value")

                                    'LblTSDataQRCode.Text = i
                                    LblTSRcvdDate.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_received")), dbReader.GetDateTime(dbReader.GetOrdinal("date_received")).ToString("MMMM dd, yyyy"), "N/A")
                                    lblTSReceiverName.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("receiver")), dbReader.GetString(dbReader.GetOrdinal("receiver")), "N/A")
                                    LblTSDataQRCode.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("serial_no")), dbReader.GetString(dbReader.GetOrdinal("serial_no")), "")

                                    'TBoxTSAnalysis.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("analysis")), dbReader.GetString(dbReader.GetOrdinal("analysis")), "")
                                    CBoxTSAnalysis.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("analysis")), dbReader.GetString(dbReader.GetOrdinal("analysis")), "")
                                    'TBoxTSActionTaken.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("action_taken")), dbReader.GetString(dbReader.GetOrdinal("action_taken")), "")
                                    CBoxTSActionTaken.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("action_taken")), dbReader.GetString(dbReader.GetOrdinal("action_taken")), "")
                                    'TBoxTSLocation1.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location1")), dbReader.GetString(dbReader.GetOrdinal("location1")), "")
                                    CBoxTSLocation1.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location1")), dbReader.GetString(dbReader.GetOrdinal("location1")), "")
                                    'TBoxTSLocation2.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location2")), dbReader.GetString(dbReader.GetOrdinal("location2")), "")
                                    CBoxTSLocation2.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location2")), dbReader.GetString(dbReader.GetOrdinal("location2")), "")
                                    'TBoxTSLocation3.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location3")), dbReader.GetString(dbReader.GetOrdinal("location3")), "")
                                    CBoxTSLocation3.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location3")), dbReader.GetString(dbReader.GetOrdinal("location3")), "")
                                    'TBoxTSLocation4.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location4")), dbReader.GetString(dbReader.GetOrdinal("location4")), "")
                                    CBoxTSLocation4.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location4")), dbReader.GetString(dbReader.GetOrdinal("location4")), "")
                                    'TBoxTSLocation5.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location5")), dbReader.GetString(dbReader.GetOrdinal("location5")), "")
                                    CBoxTSTrueFailed.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("true_failed")), dbReader.GetString(dbReader.GetOrdinal("true_failed")), "")
                                    TBoxTSRepairedBy.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("repaired_by")), dbReader.GetString(dbReader.GetOrdinal("repaired_by")), "")
                                    TBoxTSRepairedBy.Visible = True
                                    DTPTSDateRepaired.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_repaired")), dbReader.GetDateTime(dbReader.GetOrdinal("date_repaired")).ToString(), "")
                                    'TBoxTSDefectType.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("defect_type")), dbReader.GetString(dbReader.GetOrdinal("defect_type")), "")
                                    CBoxTSDefectType.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("defect_type")), dbReader.GetString(dbReader.GetOrdinal("defect_type")), "")
                                    'TBoxTSStatus.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("status")), dbReader.GetString(dbReader.GetOrdinal("status")), "")
                                    CBoxTSStatus.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("status")), dbReader.GetString(dbReader.GetOrdinal("status")), "")
                                    TBoxTSRemarks.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("remarks")), dbReader.GetString(dbReader.GetOrdinal("remarks")), "")

                                    Dim DateTS = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date")), dbReader.GetDateTime(dbReader.GetOrdinal("date")).ToString("MMMM dd, yyyy"), "")
                                    Dim TimeTS = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("time")), dbReader.GetTimeSpan(dbReader.GetOrdinal("time")).ToString("hh\:mm\:ss"), "")

                                    'Get value to the declared original data of the TS Search
                                    'analysis = TBoxTSAnalysis.Text
                                    analysis = CBoxTSAnalysis.Text
                                    'action_taken = TBoxTSActionTaken.Text
                                    action_taken = CBoxTSActionTaken.Text
                                    'location1 = TBoxTSLocation1.Text
                                    location1 = CBoxTSLocation1.Text
                                    'location2 = TBoxTSLocation2.Text
                                    location2 = CBoxTSLocation2.Text
                                    'location3 = TBoxTSLocation3.Text
                                    location3 = CBoxTSLocation3.Text
                                    'location4 = TBoxTSLocation4.Text
                                    location4 = CBoxTSLocation4.Text
                                    'location5 = TBoxTSLocation5.Text
                                    true_failed = CBoxTSTrueFailed.Text
                                    repaired_by = TBoxTSRepairedBy.Text
                                    date_repaired = DTPTSDateRepaired.Value.ToString("MMM dd, yyyy")
                                    'defect_type = TBoxTSDefectType.Text
                                    defect_type = CBoxTSDefectType.Text
                                    'status = TBoxTSStatus.Text
                                    status = CBoxTSStatus.Text
                                    remarks = TBoxTSRemarks.Text

                                    LblTSTimeStamp.Visible = True
                                    'LblTSReceivedDateTitle.Visible = True
                                    'LblTSRcvdDate.Visible = True
                                    'LblTSReceiver.Visible = True
                                    'lblTSReceiverName.Visible = True
                                    LblTSDataQRCode.Visible = True
                                    'GBoxTSData.Enabled = True
                                    'BtnTSUpdate.Enabled = True

                                    'Check if already recevied or not yet received
                                    If dbReader.IsDBNull(dbReader.GetOrdinal("receiver")) And dbReader.IsDBNull(dbReader.GetOrdinal("date_received")) And dbReader.IsDBNull(dbReader.GetOrdinal("time_received")) Then
                                        ClearFetchData()
                                        LblTSVerification.ForeColor = Color.DarkRed
                                        LblTSVerification.Text = "NOT YET RECEIVED" ' or any other default value or message
                                        LblTSVerification.Visible = True
                                        LblTSTimeStamp.Text = Nothing
                                        LblTSDataQRCode.Text = Nothing
                                        LblTSDataQRCode.Visible = False
                                        GBoxTSData.Enabled = False
                                        BtnTSUpdate.Enabled = False
                                    Else
                                        'Check if verified or unverified
                                        If dbReader.IsDBNull(dbReader.GetOrdinal("repaired_by")) Or dbReader.IsDBNull(dbReader.GetOrdinal("date_repaired")) Or dbReader.IsDBNull(dbReader.GetOrdinal("status")) Then
                                            LblTSVerification.Visible = True
                                            LblTSRcvdDate.ForeColor = SystemColors.ControlText
                                            lblTSReceiverName.ForeColor = SystemColors.ControlText
                                            LblTSVerification.ForeColor = Color.DarkRed
                                            LblTSVerification.Text = "UNVERIFIED" ' or any other default value or message
                                            GBoxData.Enabled = False

                                            LblTSReceivedDateTitle.Visible = True
                                            LblTSRcvdDate.Visible = True
                                            LblTSReceiver.Visible = True
                                            lblTSReceiverName.Visible = True

                                            LblTSTimeStamp.Text = Nothing
                                            LblTSDataQRCode.Visible = True

                                            GBoxTSData.Enabled = False
                                            BtnTSUpdate.Enabled = False

                                            'TBoxTSAnalysis.Focus()
                                            CBoxTSAnalysis.Focus()

                                            'TBoxTSAnalysis_TextChanged(sender, e)
                                            CBoxTSAnalysis_TextChanged(sender, e)
                                            'TBoxTSDefectType_TextChanged(sender, e)
                                            CBoxTSDefectType_TextChanged(sender, e)
                                            'TBoxTSActionTaken_TextChanged(sender, e)
                                            CBoxTSActionTaken_TextChanged(sender, e)
                                            TBoxTSRepairedBy_TextChanged(sender, e)
                                            'TBoxTSStatus_TextChanged(sender, e)
                                            CBoxTSStatus_TextChanged(sender, e)
                                        Else
                                            LblTSVerification.ForeColor = Color.DarkGreen
                                            LblTSVerification.Text = Nothing ' or any other default value or message
                                            'GBoxData.Enabled = True

                                            'TBoxTSAnalysis_TextChanged(sender, e)
                                            CBoxTSAnalysis_TextChanged(sender, e)
                                            'TBoxTSDefectType_TextChanged(sender, e)
                                            CBoxTSDefectType_TextChanged(sender, e)
                                            'TBoxTSActionTaken_TextChanged(sender, e)
                                            CBoxTSActionTaken_TextChanged(sender, e)
                                            TBoxTSRepairedBy_TextChanged(sender, e)
                                            'TBoxTSStatus_TextChanged(sender, e)
                                            CBoxTSStatus_TextChanged(sender, e)

                                            LblTSReceivedDateTitle.Visible = True
                                            LblTSRcvdDate.Visible = True
                                            LblTSReceiver.Visible = True
                                            lblTSReceiverName.Visible = True
                                            LblTSTimeStamp.Text = "Last update: " & DateTS & " " & TimeTS
                                            LblTSDataQRCode.Visible = True
                                            'GBoxTSData.Enabled = True
                                            'BtnTSUpdate.Enabled = True
                                        End If
                                    End If
                                End If
                            End Using
                        End Using
                        dbConn.Close()
                    Catch ex As SqlException
                        MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        If dbConn.State = ConnectionState.Open Then
                            dbConn.Close()
                        End If
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub DGVTSEndorsementData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTSEndorsementData.CellContentClick
        'If e.RowIndex >= 0 Then
        '    dgvRow = DGVTSEndorsementData.Rows(e.RowIndex) ' get the row index of the selected datagridview
        '    dgvIntRow = DGVTSEndorsementData.SelectedCells.Item(0).RowIndex ' get the row index of the selected column of row index
        '    i = dgvRow.Cells(0).Value.ToString() ' get the value of the 1st column of selected row index

        '    MsgBox("dgv " & dgvIntRow)
        'End If
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click
        FrmAdminPass.DBReference = True
        FrmAdminPass.Show(Me)
        'FrmDBReference.ShowDialog()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        FrmAdminPass.UserReference = True
        FrmAdminPass.Show(Me)
    End Sub

    Private Sub TboxTSFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles TboxTSFailureSymptoms.TextChanged
        TboxTSFailureSymptoms.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TboxTSEndtNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxTSEndtNo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TboxTSEndtNo.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxTSEndtNo_TextChanged(sender As Object, e As EventArgs) Handles TboxTSEndtNo.TextChanged
        If TboxTSEndtNo.TextLength > 0 Then
            LblTSFailureSymptoms.Enabled = True
            TboxTSFailureSymptoms.Enabled = True
        Else
            LblTSFailureSymptoms.Enabled = False
            TboxTSFailureSymptoms.Enabled = False
            TboxTSFailureSymptoms.Clear()
        End If
    End Sub

    Private Sub DGVTSEndorsementData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTSEndorsementData.CellClick
        If DGVTShasRows = True Then
            GBoxTSData.Enabled = True
            BtnTSUpdate.Enabled = True
        End If
    End Sub

    Private Sub DgvInqSummary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvInqSummary.CellContentClick

    End Sub

    Private Sub CboxInqModel_TextChanged(sender As Object, e As EventArgs) Handles CboxInqModel.TextChanged
        'Load_Station()
    End Sub

    Private Sub CboxInqStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboxInqStation.SelectedIndexChanged
        Load_FailureSymptoms(CboxInqFailureSymptoms, CboxInqStation.Text)
    End Sub

    Private Sub CBoxFailureSymptoms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxFailureSymptoms.SelectedIndexChanged

    End Sub

    Private Sub CboxInqFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles CboxInqFailureSymptoms.TextChanged
        Dim selectionStart As Integer = CboxInqFailureSymptoms.SelectionStart
        CboxInqFailureSymptoms.Text = CboxInqFailureSymptoms.Text.ToUpper()
        CboxInqFailureSymptoms.SelectionStart = selectionStart
    End Sub

    Private Sub CBoxTSAnalysis_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSAnalysis.TextChanged
        Dim selectionStart As Integer = CBoxTSAnalysis.SelectionStart
        CBoxTSAnalysis.Text = CBoxTSAnalysis.Text.ToUpper()
        CBoxTSAnalysis.SelectionStart = selectionStart

        If CBoxTSAnalysis.Text = Nothing Then
            ErrorProviderEndorsement.SetError(CBoxTSAnalysis, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(CBoxTSAnalysis, Nothing)
        End If
    End Sub

    Private Sub CBoxTSDefectType_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSDefectType.TextChanged
        Dim selectionStart As Integer = CBoxTSDefectType.SelectionStart
        CBoxTSDefectType.Text = CBoxTSDefectType.Text.ToUpper()
        CBoxTSDefectType.SelectionStart = selectionStart

        If CBoxTSDefectType.Text = Nothing Then
            ErrorProviderEndorsement.SetError(CBoxTSDefectType, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(CBoxTSDefectType, Nothing)
        End If
    End Sub

    Private Sub CBoxTSActionTaken_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSActionTaken.TextChanged
        Dim selectionStart As Integer = CBoxTSActionTaken.SelectionStart
        CBoxTSActionTaken.Text = CBoxTSActionTaken.Text.ToUpper()
        CBoxTSActionTaken.SelectionStart = selectionStart

        If CBoxTSActionTaken.Text = Nothing Then
            ErrorProviderEndorsement.SetError(CBoxTSActionTaken, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(CBoxTSActionTaken, Nothing)
        End If
    End Sub

    Private Sub CBoxTSLocation1_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSLocation1.TextChanged
        Dim selectionStart As Integer = CBoxTSLocation1.SelectionStart
        CBoxTSLocation1.Text = CBoxTSLocation1.Text.ToUpper()
        CBoxTSLocation1.SelectionStart = selectionStart
    End Sub

    Private Sub CBoxTSLocation2_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSLocation2.TextChanged
        Dim selectionStart As Integer = CBoxTSLocation2.SelectionStart
        CBoxTSLocation2.Text = CBoxTSLocation2.Text.ToUpper()
        CBoxTSLocation2.SelectionStart = selectionStart
    End Sub

    Private Sub CBoxTSLocation3_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSLocation3.TextChanged
        Dim selectionStart As Integer = CBoxTSLocation3.SelectionStart
        CBoxTSLocation3.Text = CBoxTSLocation3.Text.ToUpper()
        CBoxTSLocation3.SelectionStart = selectionStart
    End Sub

    Private Sub CBoxTSLocation4_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSLocation4.TextChanged
        Dim selectionStart As Integer = CBoxTSLocation4.SelectionStart
        CBoxTSLocation4.Text = CBoxTSLocation4.Text.ToUpper()
        CBoxTSLocation4.SelectionStart = selectionStart
    End Sub

    Private Sub CBoxTSTrueFailed_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSTrueFailed.TextChanged
        Dim selectionStart As Integer = CBoxTSTrueFailed.SelectionStart
        CBoxTSTrueFailed.Text = CBoxTSTrueFailed.Text.ToUpper()
        CBoxTSTrueFailed.SelectionStart = selectionStart
    End Sub

    Private Sub CBoxTSStatus_TextChanged(sender As Object, e As EventArgs) Handles CBoxTSStatus.TextChanged
        Dim selectionStart As Integer = CBoxTSStatus.SelectionStart
        CBoxTSStatus.Text = CBoxTSStatus.Text.ToUpper()
        CBoxTSStatus.SelectionStart = selectionStart

        If CBoxTSStatus.Text = Nothing Then
            ErrorProviderEndorsement.SetError(CBoxTSStatus, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(CBoxTSStatus, Nothing)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ChkBoxTSSerialNo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBoxTSSerialNo.CheckedChanged
        If ChkBoxTSSerialNo.Checked = True Then
            'clear search information
            TboxTSSerialNo.Text = Nothing
            ClearFetchData()

            TSNoSerial = True
            LblTSVerification.Visible = False
            LblTSSerialNo.Enabled = False
            TboxTSSerialNo.Enabled = False
            LblTSEndtNo.Enabled = True
            TboxTSEndtNo.Enabled = True
            'LblTSFailureSymptoms.Enabled = True
            'TboxTSFailureSymptoms.Enabled = True
            LblTSGuide.Visible = True
            LblTSGuide.Text = "SELECT ROW TO UPDATE"
            DGVTSEndorsementData.DataSource = Nothing
            'LblTSDataSerialNumber.Text = "ID NUMBER:"
            'MsgBox("checked")
        ElseIf ChkBoxTSSerialNo.Checked = False Then
            'clear search information
            TboxTSEndtNo.Text = Nothing
            TboxTSFailureSymptoms.Text = Nothing
            ClearFetchData()

            TSNoSerial = False
            LblTSVerification.Visible = False
            LblTSSerialNo.Enabled = True
            TboxTSSerialNo.Enabled = True
            LblTSEndtNo.Enabled = False
            TboxTSEndtNo.Enabled = False
            'LblTSFailureSymptoms.Enabled = False
            'TboxTSFailureSymptoms.Enabled = False
            LblTSGuide.Visible = False
            LblTSGuide.Text = Nothing
            DGVTSEndorsementData.DataSource = dbTablewSerial
            'LblTSDataSerialNumber.Text = "SERIAL NUMBER:"
            'MsgBox("unchecked")
        End If
    End Sub

    Dim InquiryEndtNoFailedEndtDateTS As Boolean 'multiple combobox with endorsement number ---new

    Private Sub DtpInqDateFailed_Enter(sender As Object, e As EventArgs) Handles DtpInqDateFailed.Enter
        InquirywDateFailed = True
        Inquiry = False

        If InquirywEndtDate = True Then '2 active
            InquiryDateFailedEndt = True
        End If

        If InquirywTSDate = True Then '2 active
            InquiryDateFailedTS = True
        End If

        If InquirywEndtDate = True And InquirywTSDate = True Then '3 active
            InquiryFailedEndtTS = True
        End If

        If InquiryEndtNo = True Then 'Endorsement Number and Date Failed active
            InquiryEndtNoDateFailed = True
        End If

        If InquiryEndtNo = True And InquirywEndtDate = True Then 'Endoresment Date, Date Failed, and endorsement date active
            InquiryEndtNoDateFailedEndtDate = True
        End If

        If InquiryEndtNo = True And InquirywTSDate = True Then 'Endorsement Number, Date Failed, and TS Date active
            InquiryEndtNoDateFailedTS = True
        End If

        If InquiryEndtNo = True And InquirywEndtDate = True And InquirywTSDate = True Then
            InquiryEndtNoFailedEndtDateTS = True
        End If
    End Sub

    Private Sub HandlesDtpInqEndtDate_Enter(sender As Object, e As EventArgs) Handles DtpInqEndtDate.Enter
        InquirywEndtDate = True
        Inquiry = False

        If InquirywDateFailed = True Then '2 active
            InquiryDateFailedEndt = True
        End If

        If InquirywTSDate = True Then '2 active
            InquiryDateEndtTS = True
        End If

        If InquirywDateFailed = True And InquirywTSDate = True Then
            InquiryFailedEndtTS = True
        End If

        If InquiryEndtNo = True Then 'Endorsement Number and endorsement date active
            InquiryEndtNoEndtDate = True
        End If

        If InquiryEndtNo = True And InquirywDateFailed = True Then 'Endorsement number, Date Failed, and endorsement date active
            InquiryEndtNoDateFailedEndtDate = True
        End If

        If InquiryEndtNo = True And InquirywTSDate = True Then 'Endorsement number, endorsement date, and ts date active
            InquiryEndtNoEndtDateTS = True
        End If
    End Sub

    Private Sub TboxInqEndtNo_TextChanged(sender As Object, e As EventArgs) Handles TboxInqEndtNo.TextChanged
        InquiryEndtNo = True
        Inquiry = False

        If InquirywDateFailed = True Then 'Endorsement number and Date Failed active
            InquiryEndtNoDateFailed = True
        End If

        If InquirywEndtDate = True Then 'Endorsement number and Endorsement Date active
            InquiryEndtNoEndtDate = True
        End If

        If InquirywTSDate = True Then 'Endorsement number and TS Date active
            InquiryEndtNoTS = True
        End If

        If InquirywDateFailed = True And InquirywEndtDate = True Then 'Endorsement Number, Date Failed, and Endorsement Date active
            InquiryEndtNoDateFailedEndtDate = True
        End If

        If InquirywDateFailed = True And InquirywTSDate = True Then 'Endorsement Number, Date Failed, and TS Date active
            InquiryEndtNoDateFailedTS = True
        End If

        If InquirywEndtDate = True And InquirywTSDate = True Then 'Endorsement Number, Endorsement Date, and TS Date active
            InquiryEndtNoEndtDateTS = True
        End If

        If InquirywDateFailed = True And InquirywEndtDate = True And InquirywTSDate = True Then 'Endorsement Number, Date Failed, Endorsement Date, and TS Date active
            InquiryEndtNoFailedEndtDateTS = True
        End If
    End Sub

    Private Sub DtpInqTSDate_Enter(sender As Object, e As EventArgs) Handles DtpInqTSDateFrom.Enter, DtpInqTSDateTo.Enter
        InquirywTSDate = True
        Inquiry = False

        If InquirywDateFailed = True Then 'TS Date and Date Failed active
            InquiryDateFailedTS = True
        End If

        If InquirywEndtDate = True Then 'TS Date and Endorsement Date active
            InquiryDateEndtTS = True
        End If

        If InquirywDateFailed = True And InquirywEndtDate = True Then 'TS Date, Date Failed, and Endorsement date active
            InquiryFailedEndtTS = True
        End If

        If InquiryEndtNo = True Then 'Endorsement number and ts date active
            InquiryEndtNoTS = True
        End If

        If InquiryEndtNo = True And InquirywDateFailed = True Then 'endorsement number, date failed, and ts date active
            InquiryEndtNoDateFailedTS = True
        End If

        If InquiryEndtNo = True And InquirywEndtDate = True Then 'endorsement number, endorsement date, and ts date active
            InquiryEndtNoEndtDateTS = True
        End If

        If InquiryFailedEndtTS = True And InquirywDateFailed = True And InquirywEndtDate = True Then 'endorsement number, date failed, endorsement date, and ts date active
            InquiryEndtNoFailedEndtDateTS = True
        End If
    End Sub

    Private Sub TboxPPORegLotNo_TextChanged(sender As Object, e As EventArgs) Handles TboxPPORegLotNo.TextChanged
        TboxPPORegLotNo.MaxLength = 10

        Dim LotNum = Regex.Match(TboxPPORegLotNo.Text, "71[0-9]{5}.[1-9][0-9]|71[0-9]{5}.[2-9]")

        If TboxPPORegLotNo.Text.Length > 0 Then
            If TboxPPORegLotNo.Text = LotNum.Value Then
                ErrorProviderEndorsement.SetError(TboxPPORegLotNo, Nothing)
            Else
                ErrorProviderEndorsement.SetError(TboxPPORegLotNo, "Invalid lot number")
            End If
        Else
            If TboxPPORegLotNo.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TboxPPORegLotNo, Nothing)
            End If
        End If
    End Sub

    Private Sub BtnInqClear_Click(sender As Object, e As EventArgs) Handles BtnInqClear.Click
        Load_Station_Inquiry()
        TboxInqEndtNo.Clear()
        TboxInqSerialNo.Clear()
        CboxInqModel.Text = Nothing
        CboxInqStation.Text = Nothing
        TboxInqPPONo.Clear()
        TboxInqLotNo.Clear()
        TboxInqWorkOrder.Clear()
        TboxInqFailureSymptoms.Clear()
        DtpInqDateFailed.Value = Today
        DtpInqEndtDate.Value = Today
        TboxInqAnalysis.Clear()
        TboxInqActionTaken.Clear()
        TboxInqActionTaken.Clear()
        TboxInqDefType.Clear()
        TboxInqStatus.Clear()
        TboxInqRemarks.Clear()
        DgvInqSummary.DataSource = Nothing
        DtpInqTSDateFrom.Value = Today
        DtpInqTSDateTo.Value = Today
        LblInqTotalUnverified.Text = 0.ToString
        LblInqTotalSearch.Text = 0.ToString
        InquirywDateFailed = False
        InquirywEndtDate = False
        InquirywTSDate = False
        InquiryDateFailedEndt = False
        InquiryDateFailedTS = False
        InquiryDateEndtTS = False
        InquiryFailedEndtTS = False
        Inquiry = True
        InquiryEndtNo = False

        InquiryEndtNoDateFailed = False
        InquiryEndtNoEndtDate = False
        InquiryEndtNoTS = False

        InquiryEndtNoDateFailedEndtDate = False
        InquiryEndtNoDateFailedTS = False
        InquiryEndtNoEndtDateTS = False

        LblInqUnverified.ForeColor = SystemColors.ControlText
        LblInqTotalUnverified.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub CboxInqModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboxInqModel.SelectedIndexChanged

    End Sub

    Private Sub TboxInqEndtNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxInqEndtNo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TboxInqEndtNo.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxInqSerialNo_TextChanged(sender As Object, e As EventArgs) Handles TboxInqSerialNo.TextChanged
        TboxInqSerialNo.MaxLength = 11
        TboxInqSerialNo.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub BtnPPORegSubmit_Click(sender As Object, e As EventArgs) Handles BtnPPORegSubmit.Click
        If TboxPPORegPPONo.Text = Nothing Or TboxPPORegVersion.Text = Nothing Or TboxPPORegMaterialNo.Text = Nothing Or TboxPPORegOrderingPartNo.Text = Nothing Or TboxPPORegModel.Text = Nothing Or TboxPPORegFirmware.Text = Nothing Or TboxPPORegTraceCode.Text = Nothing Or TboxPPORegLotNo.Text = Nothing Or TboxPPORegPPOQty.Text = Nothing Then
            MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Check existing lot number
        Try
            Dim dbQuery = "SELECT lot_no FROM ppo WHERE lot_no = '" & TboxPPORegLotNo.Text & "'"
            dbConn.Open()
            Using dbCmd As New SqlCommand(dbQuery, dbConn)
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        MessageBox.Show("Lot number already registered.", "PPO Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dbConn.Close()
                        Return
                    End If
                End Using
            End Using
            dbConn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try

        DateNow = DateTime.Now.ToString("MMM dd, yyyy")
        TimeNow = DateTime.Now.ToString("HH:mm:ss")

        'Insert data to ppo
        Try
            Dim dbStoredProcedure = "Insert_PPO_Registration"
            dbConn.Open()
            Using dbCmd As New SqlCommand(dbStoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@ppo_no", TboxPPORegPPONo.Text)
                dbCmd.Parameters.AddWithValue("@ver", TboxPPORegVersion.Text)
                dbCmd.Parameters.AddWithValue("@ppo_date", DtpPPORegDate.Value.ToString("MMM dd, yyyy"))
                dbCmd.Parameters.AddWithValue("@material_no", TboxPPORegMaterialNo.Text)
                dbCmd.Parameters.AddWithValue("@ordering_part_no", TboxPPORegOrderingPartNo.Text)
                dbCmd.Parameters.AddWithValue("@model", TboxPPORegModel.Text)
                dbCmd.Parameters.AddWithValue("@firmware", TboxPPORegFirmware.Text)
                dbCmd.Parameters.AddWithValue("@full_trace_code", TboxPPORegTraceCode.Text)
                dbCmd.Parameters.AddWithValue("@lot_no", TboxPPORegLotNo.Text)
                dbCmd.Parameters.AddWithValue("@ppo_qty", TboxPPORegPPOQty.Text)
                dbCmd.Parameters.AddWithValue("@CRD", DtpPPORegCRD.Value.ToString("MMM dd, yyyy"))
                dbCmd.Parameters.AddWithValue("@special_instruction", TboxPPORegSpecialIns.Text)
                dbCmd.Parameters.AddWithValue("@date", DateNow)
                dbCmd.Parameters.AddWithValue("@time", TimeNow)
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
            BtnPPORegClear.PerformClick()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try

        Load_PPO_Records(DgvPPORegPPORecords)
    End Sub

    Private Sub TboxInqPPONo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxInqPPONo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TboxInqPPONo.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxMaterial_TextChanged(sender As Object, e As EventArgs) Handles TboxMaterial.TextChanged
        TboxMaterial.MaxLength = 14
        TboxMaterial.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub BtnUIDBrowse_Click(sender As Object, e As EventArgs) Handles BtnUIDBrowse.Click
        OFDUID.Title = "UID"
        OFDUID.FileName = TboxUIDLotNo.Text
        OFDUID.Filter = "Text files|" & TboxUIDLotNo.Text & "*.txt" '|All files|*.*"

        If OFDUID.ShowDialog() = DialogResult.OK Then
            Dim Directory = IO.Path.GetDirectoryName(OFDUID.FileName)
            Dim FileName = IO.Path.GetFileName(OFDUID.FileName)

            TboxUIDSourceFile.Text = FileName
            Load_UID_To_TempTable()
        End If
    End Sub

    Private Sub Load_UID_To_TempTable()
        Try
            Dim StoredProcedure = "Load_Data_To_Temp_Table"
            Dim dbTable As New DSUID.DTUIDDataTable
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@source_txt_file", OFDUID.FileName)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            DgvUID.DataSource = dbTable
            DgvUID.ClearSelection()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub BtnUIDSubmit_Click(sender As Object, e As EventArgs) Handles BtnUIDSubmit.Click
        If Check_Duplicate_UID() Then
            Return
        End If

        Submit_UIDs()
        BtnUIDClear.PerformClick()
    End Sub

    Private Function Check_Duplicate_UID() As Boolean
        Try
            Dim StoredProcedure = "Check_Duplicate_UID"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    While dbReader.Read
                        If dbReader.HasRows Then
                            Dim count As Integer = Convert.ToInt32(dbReader("MatchingUIDCount"))
                            MessageBox.Show($"A total of {count} UID(s) have already been uploaded. Please review the entries and make necessary corrections.",
                                           "Duplicate UID Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return True
                        End If
                    End While
                End Using
            End Using
            dbConn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try

        Return False ' No duplicates found
    End Function

    Private Sub Submit_UIDs()
        Try
            Dim StoredProcedure = "Insert_TempTable_To_Laser_UID"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@lot_no", TboxUIDLotNo.Text)
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub TboxUIDLotNo_TextChanged(sender As Object, e As EventArgs) Handles TboxUIDLotNo.TextChanged
        TboxUIDLotNo.MaxLength = 10

        'If TboxUIDLotNo.Text.Length > 0 Then
        '    TboxUIDSourceFile.ReadOnly = False
        '    BtnUIDBrowse.Enabled = True
        '    GboxUIDLaserLogs.Enabled = True
        '    BtnUIDSubmit.Enabled = True
        'Else
        '    TboxUIDSourceFile.ReadOnly = True
        '    BtnUIDBrowse.Enabled = False
        '    GboxUIDLaserLogs.Enabled = False
        '    BtnUIDSubmit.Enabled = False
        'End If



        Dim LotNum = Regex.Match(TboxUIDLotNo.Text, "^71[0-9]{5}\.(?:[2-9]|[1-9][0-9])$")

        If TboxUIDLotNo.Text.Length > 0 Then
            If TboxUIDLotNo.Text = LotNum.Value Then
                ErrorProviderEndorsement.SetError(TboxUIDLotNo, Nothing)
                'TboxUIDSourceFile.ReadOnly = False
                'BtnUIDBrowse.Enabled = True
                'GboxUIDLaserLogs.Enabled = True
                'BtnUIDSubmit.Enabled = True
                'BtnUIDClear.Enabled = True
            Else
                ErrorProviderEndorsement.SetError(TboxUIDLotNo, "Invalid lot number")
                TboxUIDSourceFile.Clear()
                DgvUID.DataSource = Nothing
                TboxUIDSourceFile.ReadOnly = True
                BtnUIDBrowse.Enabled = False
                DgvUID.Enabled = False
                BtnUIDSubmit.Enabled = False
                'BtnUIDClear.Enabled = False
            End If
        Else
            If TboxUIDLotNo.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TboxUIDLotNo, Nothing)
                TboxUIDSourceFile.Clear()
                DgvUID.DataSource = Nothing
                TboxUIDSourceFile.ReadOnly = True
                BtnUIDBrowse.Enabled = False
                DgvUID.Enabled = False
                BtnUIDSubmit.Enabled = False

                'TboxUIDSourceFile.ReadOnly = True
                'BtnUIDBrowse.Enabled = False
                'GboxUIDLaserLogs.Enabled = False
                'BtnUIDSubmit.Enabled = False
                'BtnUIDClear.Enabled = False
            End If
        End If

        If ErrorProviderEndorsement.GetError(TboxUIDLotNo) = Nothing And TboxUIDLotNo.Text.Length > 0 Then
            Try
                Dim dbQuery = "SELECT * FROM ppo WHERE lot_no = '" & TboxUIDLotNo.Text & "'"
                dbConn.Open()
                Using dbCmd As New SqlCommand(dbQuery, dbConn)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            ErrorProviderEndorsement.SetError(TboxUIDLotNo, Nothing)
                            BtnUIDBrowse.Enabled = True
                            DgvUID.Enabled = True
                            BtnUIDSubmit.Enabled = True
                            'BtnUIDClear.Enabled = True
                        ElseIf Not dbReader.HasRows Then
                            ErrorProviderEndorsement.SetError(TboxUIDLotNo, "No record found")
                            TboxUIDSourceFile.Clear()
                            DgvUID.DataSource = Nothing
                            BtnUIDBrowse.Enabled = False
                            BtnUIDSubmit.Enabled = False
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub BtnUIDClear_Click(sender As Object, e As EventArgs) Handles BtnUIDClear.Click
        TboxUIDLotNo.Clear()
        'TboxUIDSourceFile.Clear()
        'BtnUIDBrowse.Enabled = False
        'DgvUID.DataSource = Nothing
        'BtnUIDClear.Enabled = False
        'BtnUIDSubmit.Enabled = False
    End Sub

    Private Sub TboxPPORegLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxPPORegLotNo.KeyPress
        If TboxPPORegLotNo.TextLength = 0 Then
            If e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
            If TboxPPORegLotNo.TextLength > 0 Then
                If e.KeyChar = "." Then
                    e.Handled = False
                End If
            End If
        End If

        If TboxPPORegLotNo.Text.Contains(".") Then
            If e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxUIDLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxUIDLotNo.KeyPress
        If TboxUIDLotNo.TextLength = 0 Then
            If e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
            If TboxUIDLotNo.TextLength > 0 Then
                If e.KeyChar = "." Then
                    e.Handled = False
                End If
            End If
        End If

        If TboxUIDLotNo.Text.Contains(".") Then
            If e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxUIDSourceFile_TextChanged(sender As Object, e As EventArgs) Handles TboxUIDSourceFile.TextChanged
        'If TboxUIDSourceFile.Text.Length > 0 Then
        '    TboxUIDLotNo.Enabled = False
        'ElseIf TboxUIDLotNo.Text.Length = 0 Then
        '    TboxUIDLotNo.Enabled = True
        'End If
    End Sub

    Private Sub TboxInqWorkOrder_TextChanged(sender As Object, e As EventArgs) Handles TboxInqWorkOrder.TextChanged
        TboxInqWorkOrder.MaxLength = 7
        TboxInqWorkOrder.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TboxInqActionTaken_TextChanged(sender As Object, e As EventArgs) Handles TboxInqActionTaken.TextChanged
        TboxInqActionTaken.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TboxInqDefType_TextChanged(sender As Object, e As EventArgs) Handles TboxInqDefType.TextChanged
        TboxInqDefType.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TboxInqStatus_TextChanged(sender As Object, e As EventArgs) Handles TboxInqStatus.TextChanged
        TboxInqStatus.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TboxInqRemarks_TextChanged(sender As Object, e As EventArgs) Handles TboxInqRemarks.TextChanged
        TboxInqRemarks.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TboxInqFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles TboxInqFailureSymptoms.TextChanged
        TboxInqFailureSymptoms.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub InquiryEnterKey_KeyDown(sender As Object, e As KeyEventArgs) Handles TboxInqEndtNo.KeyDown, TboxInqSerialNo.KeyDown, CboxInqModel.KeyDown, CboxInqStation.KeyDown, TboxInqPPONo.KeyDown, TboxInqLotNo.KeyDown, TboxInqWorkOrder.KeyDown, TboxInqFailureSymptoms.KeyDown, DtpInqDateFailed.KeyDown, DtpInqEndtDate.KeyDown, TboxInqAnalysis.KeyDown, TboxInqActionTaken.KeyDown, TboxInqDefType.KeyDown, TboxInqStatus.KeyDown, TboxInqRemarks.KeyDown, DtpInqTSDateFrom.KeyDown, DtpInqTSDateTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnInqSearch.PerformClick()
        End If
    End Sub

    Private Sub TboxInqAnalysis_TextChanged(sender As Object, e As EventArgs) Handles TboxInqAnalysis.TextChanged
        TboxInqAnalysis.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxRcvEndtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TBoxRcvEndtNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRcvCheckData.PerformClick()
        End If
    End Sub

    Private Sub TBoxRcvReceivedBy_KeyDown(sender As Object, e As KeyEventArgs) Handles TBoxRcvReceivedBy.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRcvSubmit.PerformClick()
        End If
    End Sub

    Private Sub PressEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles CBoxTSAnalysis.KeyDown, CBoxTSDefectType.KeyDown, CBoxTSActionTaken.KeyDown, CBoxTSLocation1.KeyDown, CBoxTSLocation2.KeyDown, CBoxTSLocation3.KeyDown, CBoxTSLocation4.KeyDown, CBoxTSTrueFailed.KeyDown, TBoxTSRepairedBy.KeyDown, DTPTSDateRepaired.KeyDown, CBoxTSStatus.KeyDown, TBoxTSRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnTSUpdate.PerformClick()
        End If
    End Sub

    Private Sub TboxTSSerialNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TboxTSSerialNo.KeyDown, TboxTSEndtNo.KeyDown, TboxTSFailureSymptoms.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnTSSearch.PerformClick()
        End If
    End Sub

    Private Sub BtnPPORegClear_Click(sender As Object, e As EventArgs) Handles BtnPPORegClear.Click
        TboxPPORegPPONo.Clear()
        TboxPPORegVersion.Clear()
        DtpPPORegDate.Value = Today
        TboxPPORegMaterialNo.Clear()
        TboxPPORegOrderingPartNo.Clear()
        TboxPPORegModel.Clear()
        TboxPPORegFirmware.Clear()
        TboxPPORegTraceCode.Clear()
        TboxPPORegLotNo.Clear()
        TboxPPORegPPOQty.Clear()
        DtpPPORegCRD.Value = Today
        TboxPPORegSpecialIns.Clear()
    End Sub

    Private Sub TboxPPORegPPONo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxPPORegPPONo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TboxPPORegPPONo.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxPPORegVersion_TextChanged(sender As Object, e As EventArgs) Handles TboxPPORegVersion.TextChanged
        TboxPPORegVersion.MaxLength = 2

        If TboxPPORegVersion.Text.Length > 0 Then
            If TboxPPORegVersion.TextLength = 2 Then
                ErrorProviderEndorsement.SetError(TboxPPORegVersion, Nothing)
            ElseIf TboxPPORegVersion.Text.Length <> 2 Then
                ErrorProviderEndorsement.SetError(TboxPPORegVersion, "Invalid version")
            End If
        Else
            If TboxPPORegVersion.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TboxPPORegVersion, Nothing)
            End If
        End If
    End Sub

    Private Sub TboxPPORegVersion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxPPORegVersion.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TboxPPORegMaterialNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxPPORegMaterialNo.KeyPress
        If Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TboxPPORegMaterialNo_TextChanged(sender As Object, e As EventArgs) Handles TboxPPORegMaterialNo.TextChanged
        TboxPPORegMaterialNo.MaxLength = 14
        TboxPPORegMaterialNo.CharacterCasing = CharacterCasing.Upper

        If TboxPPORegMaterialNo.TextLength > 0 Then
            Try
                Dim dbQuery = "SELECT * FROM opn WHERE material_no = '" & TboxPPORegMaterialNo.Text & "'"
                dbConn.Open()
                Using dbCmd As New SqlCommand(dbQuery, dbConn)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            TboxPPORegOrderingPartNo.Text = dbReader("ordering_part_no").ToString
                            TboxPPORegModel.Text = dbReader("model").ToString
                            TboxPPORegFirmware.Text = dbReader("firmware").ToString
                            ErrorProviderEndorsement.SetError(TboxPPORegMaterialNo, Nothing)
                        ElseIf Not dbReader.HasRows Then
                            TboxPPORegOrderingPartNo.Clear()
                            TboxPPORegModel.Clear()
                            TboxPPORegFirmware.Clear()
                            ErrorProviderEndorsement.SetError(TboxPPORegMaterialNo, "Invalid material number")
                        End If
                    End Using
                End Using
                dbConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try
        ElseIf TboxPPORegMaterialNo.Text.Length = 0 Then
            ErrorProviderEndorsement.SetError(TboxPPORegMaterialNo, Nothing)
        End If
    End Sub

    Private Sub TboxPPORegPPOQty_TextChanged(sender As Object, e As EventArgs) Handles TboxPPORegPPOQty.TextChanged
        TboxPPORegPPOQty.MaxLength = 6
    End Sub

    Private Sub TboxPPORegPPOQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxPPORegPPOQty.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If

        If TboxPPORegPPOQty.TextLength = 0 Then
            If e.KeyChar = "0" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TboxPPORegTraceCode_TextChanged(sender As Object, e As EventArgs) Handles TboxPPORegTraceCode.TextChanged
        TboxPPORegTraceCode.MaxLength = 10
        TboxPPORegTraceCode.CharacterCasing = CharacterCasing.Upper

        Dim TraceCode = "[0-9]{2}(0[1-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-3])[A-Z0-9]{6}"
        If TboxPPORegTraceCode.Text.Length > 0 Then
            If Regex.IsMatch(TboxPPORegTraceCode.Text, TraceCode) Then
                ErrorProviderEndorsement.SetError(TboxPPORegTraceCode, Nothing)
            Else
                ErrorProviderEndorsement.SetError(TboxPPORegTraceCode, "Invalid trace code")
            End If
        Else
            If TboxPPORegTraceCode.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TboxPPORegTraceCode, Nothing)
            End If
        End If
    End Sub

    Private Sub TboxPPORegTraceCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxPPORegTraceCode.KeyPress

    End Sub

    Private Sub TboxPPORegPPONo_TextChanged(sender As Object, e As EventArgs) Handles TboxPPORegPPONo.TextChanged
        TboxPPORegPPONo.MaxLength = 10

        If TboxPPORegPPONo.Text.Length > 0 Then
            If TboxPPORegPPONo.TextLength = 10 Then
                ErrorProviderEndorsement.SetError(TboxPPORegPPONo, Nothing)
            ElseIf TboxPPORegPPONo.Text.Length <> 10 Then
                ErrorProviderEndorsement.SetError(TboxPPORegPPONo, "Invalid trace code")
            End If
        Else
            If TboxPPORegPPONo.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TboxPPORegPPONo, Nothing)
            End If
        End If
    End Sub

    Private Sub Enter_KeyPress(sender As Object, e As KeyEventArgs) Handles TboxPPORegPPONo.KeyDown, TboxPPORegVersion.KeyDown, DtpPPORegDate.KeyDown, TboxPPORegMaterialNo.KeyDown, TboxPPORegOrderingPartNo.KeyDown, TboxPPORegModel.KeyDown, TboxPPORegFirmware.KeyDown, TboxPPORegTraceCode.KeyDown, TboxPPORegLotNo.KeyDown, TboxPPORegPPOQty.KeyDown, DtpPPORegCRD.KeyDown, TboxPPORegSpecialIns.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnPPORegSubmit.PerformClick()
        End If
    End Sub
End Class
