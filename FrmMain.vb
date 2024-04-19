Imports System.Data.Common
Imports System.Data.Entity.Infrastructure.DependencyResolution
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FrmMain
    'Private dbCon As New SQLiteConnection("Data Source=" & System.Windows.Forms.Application.StartupPath & "\endorsement_proposal.db;Version=3;FailIfMissing=True;")
    Dim DateNow, TimeNow As String
    Dim Invalid_ppoNumber, Invalid_lotNumber, Invalid_workOrder, Invalid_serialNumber As Boolean

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim workweek = DatePart("ww", DTPEndorsementDate.Value)
        TBoxWorkweek.Text = Format(workweek, "00")
        Load_Latest_EndorsementNo()
        Load_Model_Variant()
        DropTempEndorsementTable() ' Drop the temporary endorsement table

        CBoxModel.Enabled = False
        TBoxPPONo.ReadOnly = True
        TBoxPPOQty.ReadOnly = True
        TBoxLotNo.ReadOnly = True
        TBoxWorkOrder.ReadOnly = True
        TBoxQtyEndorsed.ReadOnly = True
        DTPDateFailed.Enabled = False
        DTPEndorsementDate.Enabled = False
        BtnEndorseAnotherModel.Enabled = False

        GBoxData.Enabled = False
        BtnEndorseAnotherModel.Enabled = False
        BtnSubmit.Enabled = False
        BtnCancel.Enabled = False
    End Sub

    Private Sub BtnInformationClear_Click(sender As Object, e As EventArgs) Handles BtnInformationClear.Click
        TBoxQtyEndorsed.Clear()
        CBoxModel.Text = Nothing
        TBoxSerialNo.Clear()
        TBoxPPONo.Clear()
        TBoxPPOQty.Clear()
        TBoxLotNo.Clear()
        TBoxWorkOrder.Clear()
        CBoxStation.Text = Nothing
        TBoxFailureSymptoms.Clear()
        'CBoxFailureSymptoms.Text = Nothing

        'TBoxEndorsedBy.Clear()
        'TBoxWorkweek.Clear()

        'TBoxValidatedBy.Clear()
        'TBoxAnalysis.Clear()
        'TBoxActionTaken.Clear()
        'TBoxLocation1.Clear()
        'TBoxLocation2.Clear()
        'TBoxLocation3.Clear()
        'TBoxLocation4.Clear()
        'TBoxLocation5.Clear()
        'TBoxRepairedBy.Clear()
        'TBoxDefectType.Clear()
        'TBoxStatus.Clear()
        'TBoxRemarks.Clear()
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
        TBoxFailureSymptoms.Clear()
        CBoxFailureSymptoms.Text = Nothing
        BtnSubmit.Enabled = False
        BtnCancel.Enabled = False

        DGVEndorsementData.DataSource = Nothing
        LblNewQty.Text = 0
        LblTotalQty.Text = 0
    End Sub

    Private Sub BtnEndorse_Click(sender As Object, e As EventArgs) Handles BtnEndorse.Click
        If ChkBoxEndtSerialNo.Checked = True And TBoxSerialNo.Enabled = False Then
            If CBoxStation.Text = Nothing Or TBoxFailureSymptoms.TextLength = 0 Then
                'If CBoxStation.Text = Nothing Or CBoxFailureSymptoms.Text.Length = 0 Then
                MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information 1", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Else
                If TBoxSerialNo.TextLength = 0 Or CBoxStation.Text = Nothing Or TBoxFailureSymptoms.TextLength = 0 Then
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
                    dbCmd.Parameters.AddWithValue("@model", CBoxModel.Text)
                    dbCmd.Parameters.AddWithValue("@serial_no", If(ChkBoxEndtSerialNo.Checked = True, "N/A", TBoxSerialNo.Text))
                    dbCmd.Parameters.AddWithValue("@ppo_no", TBoxPPONo.Text)
                    dbCmd.Parameters.AddWithValue("@ppo_qty", Integer.Parse(TBoxPPOQty.Text))
                    dbCmd.Parameters.AddWithValue("@lot_no", TBoxLotNo.Text)
                    dbCmd.Parameters.AddWithValue("@work_order", TBoxWorkOrder.Text)
                    dbCmd.Parameters.AddWithValue("@station", CBoxStation.Text)
                    dbCmd.Parameters.AddWithValue("@failure_symptoms", TBoxFailureSymptoms.Text)
                    'dbCmd.Parameters.AddWithValue("@failure_symptoms", CBoxFailureSymptoms.Text)
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

            If LblNewQty.Text = TBoxQtyEndorsed.Text Then
                'GBoxData.Enabled = False
                TBoxSerialNo.Clear()
                CBoxStation.Text = Nothing
                TBoxFailureSymptoms.Clear()
                'CBoxFailureSymptoms.Text = Nothing

                TBoxSerialNo.Enabled = False
                CBoxStation.Enabled = False
                TBoxFailureSymptoms.Enabled = False
                'CBoxFailureSymptoms.Enabled = False

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

    Private Sub BtnEndorseEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles TBoxSerialNo.KeyDown, CBoxStation.KeyDown, TBoxFailureSymptoms.KeyDown, CBoxFailureSymptoms.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEndorse.PerformClick()
        End If
    End Sub

    Private Sub Load_Latest_EndorsementNo()
        Try
            Dim procedure = "GetEndorsementNo"
            dbConn.Open()
            Using dbCmd As New SqlCommand(procedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        TboxEndorsementNo.Text = dbReader("endorsement_no")
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
    End Sub

    Private Sub Load_TempEndorsementData()
        Try
            Dim dbTable As New DSEndorsementData.DTEndorsementDataDataTable
            Dim StoredProcedure = "LoadTempEndorsementData"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@endtNo", TboxEndorsementNo.Text)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            DGVEndorsementData.DataSource = dbTable
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub Load_Model_Variant()
        Try
            Dim dbTable As New DSJoinTable.DTVariantDataTable
            Dim q = "SELECT * FROM variant"
            dbConn.Open()
            Using dbCmd As New SqlCommand(q, dbConn)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            CBoxModel.DataSource = dbTable
            CBoxModel.DisplayMember = "variant"
            CBoxModel.Text = Nothing
            CboxInqModel.DataSource = dbTable
            CboxInqModel.DisplayMember = "variant"
            CboxInqModel.Text = Nothing
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub Load_Station()
        Try
            Dim dbTable As New DSStation.DTStationsDataTable
            Dim StoredProcedure = "GetStation"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@variant", CBoxModel.Text)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            CBoxStation.DataSource = dbTable
            CBoxStation.DisplayMember = "station"
            CBoxStation.Text = Nothing
            CBoxStation.DropDownHeight = 106
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub Load_FailureSymptoms()
        Try
            Dim DbTable As New DataTable
            Dim Query = "SELECT DISTINCT failure_symptoms FROM endorsement WHERE station='" & CBoxStation.Text & "'"
            dbConn.Open()
            Using dbCmd As New SqlCommand(Query, dbConn)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(DbTable)
                End Using
            End Using
            dbConn.Close()
            CBoxFailureSymptoms.DataSource = DbTable
            CBoxFailureSymptoms.DisplayMember = "failure_symptoms"
            CBoxFailureSymptoms.Text = Nothing
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

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
        Load_Station()

        If CBoxModel.Text = Nothing Then
            TBoxPPONo.ReadOnly = True
            TBoxPPOQty.ReadOnly = True
            TBoxLotNo.ReadOnly = True
            TBoxWorkOrder.ReadOnly = True
            TBoxQtyEndorsed.ReadOnly = True
            DTPDateFailed.Enabled = False
            DTPEndorsementDate.Enabled = False

            CBoxStation.DataSource = Nothing
        Else
            TBoxPPONo.ReadOnly = False
            TBoxPPOQty.ReadOnly = False
            TBoxLotNo.ReadOnly = False
            TBoxWorkOrder.ReadOnly = False
            TBoxQtyEndorsed.ReadOnly = False
            DTPDateFailed.Enabled = True
            DTPEndorsementDate.Enabled = True
        End If

        ' Clears the value if selected item is not equal from the previous
        If CBoxModel.Text <> CBoxModelPreviousValue Then
            TBoxPPONo.Clear()
            TBoxPPOQty.Clear()
            TBoxLotNo.Clear()
            TBoxWorkOrder.Clear()
            TBoxQtyEndorsed.Clear()
        End If

        CBoxModelPreviousValue = CBoxModel.Text
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
                Invalid_lotNumber = False
            Else
                ErrorProviderEndorsement.SetError(TBoxLotNo, "Invalid lot number")
                Invalid_lotNumber = True
            End If
        Else
            If TBoxLotNo.Text.Length = 0 Then
                ErrorProviderEndorsement.SetError(TBoxLotNo, Nothing)
                Invalid_lotNumber = False
            End If
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
        Else
            CBoxModel.Enabled = False
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

        Load_Latest_EndorsementNo()
        Reset_Fillup_Form()
    End Sub

    Private Sub Count_TempEndorsement()
        Try
            Dim Query = "SELECT COUNT(id) AS id FROM TempEndorsement"
            dbConn.Open()
            Using dbCmd As New SqlCommand(Query, dbConn)
                Dim count As Integer = Convert.ToInt32(dbCmd.ExecuteScalar())

                LblTotalQty.Text = count.ToString

            End Using
            dbConn.Close()
        Catch ex As SqlException
            dbConn.Close()
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Erro Exeption Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
        If TBoxQtyEndorsed.TextLength = 0 Or CBoxModel.Text = Nothing Or TBoxPPONo.TextLength = 0 Or TBoxPPOQty.TextLength = 0 Or TBoxLotNo.TextLength = 0 Or TBoxWorkOrder.TextLength = 0 Or TBoxEndorsedBy.TextLength = 0 Then
            MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Invalid_ppoNumber = True Or Invalid_lotNumber = True Or Invalid_workOrder Then
            MessageBox.Show("Please ensure all fields with an error mark are in the correct format.", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            GBoxInformation.Enabled = False
            GBoxData.Enabled = True
            BtnEndorseAnotherModel.Enabled = False

            TBoxSerialNo.Enabled = True
            CBoxStation.Enabled = True
            TBoxFailureSymptoms.Enabled = True
            'CBoxFailureSymptoms.Enabled = True
            BtnEndorse.Enabled = True
            BtnDataClear.Enabled = True
            BtnReturn.Enabled = True

            BtnSubmit.Enabled = True
            BtnCancel.Enabled = True

            ChkBoxEndtSerialNo.Enabled = True
            TBoxSerialNo.Focus()
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

    Private Sub BtnScanEnter_KeyPress(sender As Object, e As KeyEventArgs) Handles TBoxQtyEndorsed.KeyDown, CBoxModel.KeyDown, TBoxPPONo.KeyDown, TBoxPPOQty.KeyDown, TBoxLotNo.KeyDown, TBoxWorkOrder.KeyDown, TBoxEndorsedBy.KeyDown, DTPDateFailed.KeyDown, DTPEndorsementDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnScan.PerformClick()
        End If
    End Sub

    Private Sub DropTempEndorsementTable()
        Try
            Dim StoredProcedure = "DropTempEndorsementTable"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
        Catch ex As SqlException
            ' Handle database-related errors
            'MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Handle other types of exceptions
            'MessageBox.Show(ex.Message, "Error Dropping Database Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub BtnEndorseAnotherModel_Click(sender As Object, e As EventArgs) Handles BtnEndorseAnotherModel.Click
        GBoxInformation.Enabled = True
        BtnReset.Enabled = False
        GBoxData.Enabled = False
        CBoxModel.Text = Nothing
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        TBoxFailureSymptoms.Clear()
        'CBoxFailureSymptoms.Text = Nothing
        LblNewQty.Text = 0
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
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
            TBoxFailureSymptoms.Clear()
            'CBoxFailureSymptoms.Text = Nothing
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        CBoxModel.Text = Nothing
        TBoxEndorsedBy.Clear()
        TBoxEndorsedBy.ReadOnly = False
    End Sub

    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles BtnReturn.Click
        GBoxInformation.Enabled = True
        BtnDataClear.PerformClick()
        GBoxData.Enabled = False
        ChkBoxEndtSerialNo.Enabled = False
        GBoxInformation.Focus()
    End Sub

    Private Sub BtnDataClear_Click(sender As Object, e As EventArgs) Handles BtnDataClear.Click
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        TBoxFailureSymptoms.Clear()
        'CBoxFailureSymptoms.Text = Nothing
    End Sub

    Private Sub TBoxFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles TBoxFailureSymptoms.TextChanged
        TBoxFailureSymptoms.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub CBoxFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles CBoxFailureSymptoms.TextChanged
        Dim selectionStart As Integer = CBoxFailureSymptoms.SelectionStart
        CBoxFailureSymptoms.Text = CBoxFailureSymptoms.Text.ToUpper()
        CBoxFailureSymptoms.SelectionStart = selectionStart
        'CBoxFailureSymptoms.SelectionLength = 0
    End Sub

    Private Sub TBoxFailureSymptoms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxFailureSymptoms.KeyPress
        If TBoxFailureSymptoms.TextLength = 0 Then
            If e.KeyChar = ChrW(Keys.Space) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CBoxFailureSymptoms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBoxFailureSymptoms.KeyPress
        If CBoxFailureSymptoms.Text.Length = 0 Then
            If e.KeyChar = ChrW(Keys.Space) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtnRcvCheckData_Click(sender As Object, e As EventArgs) Handles BtnRcvCheckData.Click
        Try
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
                        LblRcvStatus.Text = Nothing
                        LblRcvStatus.Visible = False

                        LblRcvReceivedDateTitle.Visible = False
                        LblRcvRcvdDate.Text = Nothing
                        LblRcvRcvdDate.Visible = False

                        LblRcvReceiver.Visible = False
                        lblRcvReceiverName.Text = Nothing
                        lblRcvReceiverName.Visible = False
                    End If
                End Using
            End Using
            dbConn.Close()

            If LblRcvStatus.Text = "ALREADY RECEIVED" Then
                BtnRcvSubmit.Enabled = False
            Else
                BtnRcvSubmit.Enabled = True
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
        BtnRcvSubmit.Enabled = True
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

    Private Sub BtnTSSearch_Click(sender As Object, e As EventArgs) Handles BtnTSSearch.Click
        If ErrorProviderEndorsement.GetError(TboxTSSerialNo) = "Invalid serial number" Then
            'MessageBox.Show("The input serial number is invalid.", " Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LblTSVerification.Visible = True
            LblTSVerification.Text = "INVALID SERIAL NUMBER"
            Return
        End If

        If TboxTSSerialNo.TextLength = 0 Then
            LblTSVerification.Visible = True
            LblTSVerification.Text = "NO SERIAL NUMBER"
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

                        TBoxTSAnalysis.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("analysis")), dbReader.GetString(dbReader.GetOrdinal("analysis")), "")
                        TBoxTSActionTaken.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("action_taken")), dbReader.GetString(dbReader.GetOrdinal("action_taken")), "")
                        TBoxTSLocation1.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location1")), dbReader.GetString(dbReader.GetOrdinal("location1")), "")
                        TBoxTSLocation2.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location2")), dbReader.GetString(dbReader.GetOrdinal("location2")), "")
                        TBoxTSLocation3.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location3")), dbReader.GetString(dbReader.GetOrdinal("location3")), "")
                        TBoxTSLocation4.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location4")), dbReader.GetString(dbReader.GetOrdinal("location4")), "")
                        TBoxTSLocation5.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("location5")), dbReader.GetString(dbReader.GetOrdinal("location5")), "")
                        TBoxTSRepairedBy.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("repaired_by")), dbReader.GetString(dbReader.GetOrdinal("repaired_by")), "")
                        DTPTSDateRepaired.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_repaired")), dbReader.GetDateTime(dbReader.GetOrdinal("date_repaired")).ToString(), "")
                        TBoxTSDefectType.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("defect_type")), dbReader.GetString(dbReader.GetOrdinal("defect_type")), "")
                        TBoxTSStatus.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("status")), dbReader.GetString(dbReader.GetOrdinal("status")), "")
                        TBoxTSRemarks.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("remarks")), dbReader.GetString(dbReader.GetOrdinal("remarks")), "")
                        'LblTSRcvdDate.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_received")), dbReader.GetString(dbReader.GetOrdinal("date_received")), "N/A")

                        Dim DateTS = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date")), dbReader.GetDateTime(dbReader.GetOrdinal("date")).ToString("MMMM dd, yyyy"), "")
                        Dim TimeTS = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("time")), dbReader.GetTimeSpan(dbReader.GetOrdinal("time")).ToString("hh\:mm\:ss"), "")

                        LblTSTimeStamp.Visible = True
                        'LblTSReceivedDateTitle.Visible = True
                        'LblTSRcvdDate.Visible = True
                        'LblTSReceiver.Visible = True
                        'lblTSReceiverName.Visible = True
                        LblTSDataQRCode.Visible = True

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

                                TBoxTSAnalysis_TextChanged(sender, e)
                                TBoxTSDefectType_TextChanged(sender, e)
                                TBoxTSActionTaken_TextChanged(sender, e)
                                TBoxTSRepairedBy_TextChanged(sender, e)
                                TBoxTSStatus_TextChanged(sender, e)
                            Else
                                LblTSVerification.ForeColor = Color.DarkGreen
                                LblTSVerification.Text = Nothing ' or any other default value or message
                                GBoxData.Enabled = True

                                TBoxTSAnalysis_TextChanged(sender, e)
                                TBoxTSDefectType_TextChanged(sender, e)
                                TBoxTSActionTaken_TextChanged(sender, e)
                                TBoxTSRepairedBy_TextChanged(sender, e)
                                TBoxTSStatus_TextChanged(sender, e)

                                LblTSReceivedDateTitle.Visible = True
                                LblTSRcvdDate.Visible = True
                                LblTSReceiver.Visible = True
                                lblTSReceiverName.Visible = True
                                LblTSTimeStamp.Text = "Last update: " & DateTS & " " & TimeTS
                                LblTSDataQRCode.Visible = True
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
        TboxTSSerialNo.Clear()
        ClearFetchData()
    End Sub

    Private Sub ClearFetchData()
        LblTSVerification.Text = Nothing
        LblTSReceivedDateTitle.Visible = False
        LblTSRcvdDate.Visible = False
        LblTSRcvdDate.Text = Nothing
        LblTSReceiver.Visible = False
        lblTSReceiverName.Visible = False
        lblTSReceiverName.Text = Nothing
        TBoxTSAnalysis.Clear()
        ErrorProviderEndorsement.SetError(TBoxTSAnalysis, Nothing)
        TBoxTSActionTaken.Clear()
        ErrorProviderEndorsement.SetError(TBoxTSActionTaken, Nothing)
        TBoxTSLocation1.Clear()
        TBoxTSLocation2.Clear()
        TBoxTSLocation3.Clear()
        TBoxTSLocation4.Clear()
        TBoxTSLocation5.Clear()
        TBoxTSRepairedBy.Clear()
        ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, Nothing)
        DTPTSDateRepaired.ResetText()
        TBoxTSDefectType.Clear()
        ErrorProviderEndorsement.SetError(TBoxTSDefectType, Nothing)
        TBoxTSStatus.Clear()
        ErrorProviderEndorsement.SetError(TBoxTSStatus, Nothing)
        TBoxTSRemarks.Clear()
        LblTSTimeStamp.Text = Nothing
    End Sub

    Private Sub BtnTSUpdate_Click(sender As Object, e As EventArgs) Handles BtnTSUpdate.Click
        Try
            Dim StoredProcedure = "GetTSData"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@serialNo", TboxTSSerialNo.Text)
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        'LblTSRcvdDate.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("date_received")), dbReader.GetDateTime(dbReader.GetOrdinal("date_received")).ToString("MMMM dd, yyyy"), "N/A")
                        'lblTSReceiverName.Text = If(Not dbReader.IsDBNull(dbReader.GetOrdinal("receiver")), dbReader.GetString(dbReader.GetOrdinal("receiver")), "N/A")

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

        If TBoxTSAnalysis.Text = Nothing Or TBoxTSDefectType.Text = Nothing Or TBoxTSActionTaken.Text = Nothing Or TBoxTSRepairedBy.Text = Nothing Or TBoxTSStatus.Text = Nothing Then
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
                dbCmd.Parameters.AddWithValue("@analysis", TBoxTSAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actionTaken", TBoxTSActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@location1", TBoxTSLocation1.Text)
                dbCmd.Parameters.AddWithValue("@location2", TBoxTSLocation2.Text)
                dbCmd.Parameters.AddWithValue("@location3", TBoxTSLocation3.Text)
                dbCmd.Parameters.AddWithValue("@location4", TBoxTSLocation4.Text)
                dbCmd.Parameters.AddWithValue("@location5", TBoxTSLocation5.Text)
                dbCmd.Parameters.AddWithValue("@repairedBy", TBoxTSRepairedBy.Text)
                dbCmd.Parameters.AddWithValue("@dateRepaired", DTPTSDateRepaired.Value)
                dbCmd.Parameters.AddWithValue("@defectType", TBoxTSDefectType.Text)
                dbCmd.Parameters.AddWithValue("@status", TBoxTSStatus.Text)
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
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Updating TS Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub TBoxTSDefectType_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSDefectType.TextChanged
        TBoxTSDefectType.CharacterCasing = CharacterCasing.Upper
        If TBoxTSDefectType.TextLength = 0 Then
            ErrorProviderEndorsement.SetError(TBoxTSDefectType, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(TBoxTSDefectType, Nothing)
        End If
    End Sub

    Private Sub TBoxTSAnalysis_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSAnalysis.TextChanged
        TBoxTSAnalysis.CharacterCasing = CharacterCasing.Upper
        If TBoxTSAnalysis.TextLength = 0 Then
            ErrorProviderEndorsement.SetError(TBoxTSAnalysis, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(TBoxTSAnalysis, Nothing)
        End If
    End Sub

    Private Sub TBoxTSActionTaken_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSActionTaken.TextChanged
        TBoxTSActionTaken.CharacterCasing = CharacterCasing.Upper
        If TBoxTSActionTaken.TextLength = 0 Then
            ErrorProviderEndorsement.SetError(TBoxTSActionTaken, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(TBoxTSActionTaken, Nothing)
        End If
    End Sub

    Private Sub TBoxTSLocation1_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation1.TextChanged
        TBoxTSLocation1.CharacterCasing = CharacterCasing.Upper
        'If TBoxTSLocation1.TextLength = 0 Then
        '    ErrorProviderEndorsement.SetError(TBoxTSLocation1, "Please fill the information")
        'Else
        '    ErrorProviderEndorsement.SetError(TBoxTSLocation1, Nothing)
        'End If
    End Sub

    Private Sub TBoxTSLocation2_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation2.TextChanged
        TBoxTSLocation2.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxTSLocation3_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation3.TextChanged
        TBoxTSLocation3.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxTSLocation4_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation4.TextChanged
        TBoxTSLocation4.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxTSLocation5_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSLocation5.TextChanged
        TBoxTSLocation5.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxTSRepairedBy_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSRepairedBy.TextChanged
        TBoxTSRepairedBy.CharacterCasing = CharacterCasing.Upper
        If TBoxTSRepairedBy.TextLength = 0 Then
            ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(TBoxTSRepairedBy, Nothing)
        End If
    End Sub

    Private Sub TBoxTSStatus_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSStatus.TextChanged
        TBoxTSStatus.CharacterCasing = CharacterCasing.Upper
        If TBoxTSStatus.TextLength = 0 Then
            ErrorProviderEndorsement.SetError(TBoxTSStatus, "Please fill the information")
        Else
            ErrorProviderEndorsement.SetError(TBoxTSStatus, Nothing)
        End If
    End Sub

    Private Sub TBoxTSRemarks_TextChanged(sender As Object, e As EventArgs) Handles TBoxTSRemarks.TextChanged
        TBoxTSRemarks.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private elapsedTime As Integer

    Private Sub TBoxWorkweek_TextChanged(sender As Object, e As EventArgs) Handles TBoxWorkweek.TextChanged

    End Sub

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
        Load_FailureSymptoms()
    End Sub

    Private Sub BtnInqSearch_Click(sender As Object, e As EventArgs) Handles BtnInqSearch.Click
        Load_Inquiry()
    End Sub

    Private Sub Load_Inquiry()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            Dim StoredProcedure = "Inquiry"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtNo", TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialNo", TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@ppoNo", TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotNo", TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workOrder", TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@dateFailed", DtpInqDateFailed.Value)
                dbCmd.Parameters.AddWithValue("@endtDate", DtpInqEndtDate.Value)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            DgvInqSummary.DataSource = dbTable
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQL Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Updating TS Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
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

    Private Sub PressEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles TBoxTSAnalysis.KeyDown, TBoxTSDefectType.KeyDown, TBoxTSActionTaken.KeyDown, TBoxTSLocation1.KeyDown, TBoxTSLocation2.KeyDown, TBoxTSLocation3.KeyDown, TBoxTSLocation4.KeyDown, TBoxTSLocation5.KeyDown, TBoxTSRepairedBy.KeyDown, DTPTSDateRepaired.KeyDown, TBoxTSStatus.KeyDown, TBoxTSRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnTSUpdate.PerformClick()
        End If
    End Sub

    Private Sub TboxTSSerialNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TboxTSSerialNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnTSSearch.PerformClick()
        End If
    End Sub
End Class
