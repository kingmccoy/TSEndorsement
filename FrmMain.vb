Imports System.Data.Common
Imports System.Data.Entity.Infrastructure.DependencyResolution
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles

Public Class FrmMain
    'Private dbCon As New SQLiteConnection("Data Source=" & System.Windows.Forms.Application.StartupPath & "\endorsement_proposal.db;Version=3;FailIfMissing=True;")
    Dim DateNow = DateTime.Now.ToString("MM-dd-yyyy")
    Dim TimeNow = DateTime.Now.ToString("hh:mm:ss")
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
        TBoxFailureSymptoms.Clear()
        TBoxEndorsedBy.Clear()
        BtnScan.Enabled = True
        BtnReset.Enabled = True

        GBoxData.Enabled = False
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        TBoxFailureSymptoms.Clear()
        BtnSubmit.Enabled = False
        BtnCancel.Enabled = False

        DGVEndorsementData.DataSource = Nothing
        LblNewQty.Text = 0
        LblTotalQty.Text = 0
    End Sub

    Private Sub BtnEndorse_Click(sender As Object, e As EventArgs) Handles BtnEndorse.Click
        If TBoxSerialNo.TextLength = 0 Or CBoxStation.Text = Nothing Or TBoxFailureSymptoms.TextLength = 0 Then
            MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
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
                Dim StoredProcedure As String = "InsertTempEndorsementData"
                dbConn.Open()
                Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                    dbCmd.CommandType = CommandType.StoredProcedure

                    ' Add parameters with proper data types
                    dbCmd.Parameters.AddWithValue("@endorsement_no", TboxEndorsementNo.Text)
                    dbCmd.Parameters.AddWithValue("@qty_endorsed", Integer.Parse(TBoxQtyEndorsed.Text))
                    dbCmd.Parameters.AddWithValue("@qty", 1)
                    dbCmd.Parameters.AddWithValue("@model", CBoxModel.Text)
                    dbCmd.Parameters.AddWithValue("@serial_no", TBoxSerialNo.Text)
                    dbCmd.Parameters.AddWithValue("@ppo_no", TBoxPPONo.Text)
                    dbCmd.Parameters.AddWithValue("@ppo_qty", Integer.Parse(TBoxPPOQty.Text))
                    dbCmd.Parameters.AddWithValue("@lot_no", TBoxLotNo.Text)
                    dbCmd.Parameters.AddWithValue("@work_order", TBoxWorkOrder.Text)
                    dbCmd.Parameters.AddWithValue("@station", CBoxStation.Text)
                    dbCmd.Parameters.AddWithValue("@failure_symptoms", TBoxFailureSymptoms.Text)
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

                TBoxSerialNo.Enabled = False
                CBoxStation.Enabled = False
                TBoxFailureSymptoms.Enabled = False

                BtnEndorse.Enabled = False
                BtnDataClear.Enabled = False

                BtnEndorseAnotherModel.Enabled = True
                BtnSubmit.Enabled = True

                LblSerialNo.Focus()
            Else
                BtnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnEndorseEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles TBoxSerialNo.KeyDown, CBoxStation.KeyDown, TBoxFailureSymptoms.KeyDown
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
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error Endorsement Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error Loading Temp Endorsement Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Load_Model_Variant()
        Try
            Dim dbTable As New DSJoinTable.DTvariantDataTable
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
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error Loading Model", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                ErrorProvider1.SetError(TBoxPPONo, Nothing)
                Invalid_ppoNumber = False
            Else
                ErrorProvider1.SetError(TBoxPPONo, "Invalid PPO number")
                Invalid_ppoNumber = True
            End If
        Else
            If TBoxPPONo.Text.Length = 0 Then
                ErrorProvider1.SetError(TBoxPPONo, Nothing)
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
    End Sub

    Private Sub TBoxLotNo_TextChanged(sender As Object, e As EventArgs) Handles TBoxLotNo.TextChanged
        TBoxLotNo.MaxLength = 10

        Dim LotNum = Regex.Match(TBoxLotNo.Text, "71[0-9]{5}.[1-9][0-9]|71[0-9]{5}.[2-9]")

        If TBoxLotNo.Text.Length > 0 Then
            If TBoxLotNo.Text = LotNum.Value Then
                ErrorProvider1.SetError(TBoxLotNo, Nothing)
                Invalid_lotNumber = False
            Else
                ErrorProvider1.SetError(TBoxLotNo, "Invalid lot number")
                Invalid_lotNumber = True
            End If
        Else
            If TBoxLotNo.Text.Length = 0 Then
                ErrorProvider1.SetError(TBoxLotNo, Nothing)
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
                ErrorProvider1.SetError(TBoxWorkOrder, Nothing)
                Invalid_workOrder = False
            Else
                ErrorProvider1.SetError(TBoxWorkOrder, "Invalid work order")
                Invalid_workOrder = True
            End If
        Else
            If TBoxWorkOrder.TextLength = 0 Then
                ErrorProvider1.SetError(TBoxWorkOrder, Nothing)
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
                ErrorProvider1.SetError(TBoxSerialNo, Nothing)
                Invalid_serialNumber = False
            Else
                ErrorProvider1.SetError(TBoxSerialNo, "Invalid serial number")
                Invalid_serialNumber = True
            End If
        Else
            If TBoxSerialNo.TextLength = 0 Then
                ErrorProvider1.SetError(TBoxSerialNo, Nothing)
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
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error Couting Temp Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            BtnEndorse.Enabled = True
            BtnDataClear.Enabled = True
            BtnReturn.Enabled = True

            BtnSubmit.Enabled = True
            BtnCancel.Enabled = True

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
                MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                ' Handle other types of exceptions
                MessageBox.Show(ex.Message, "Error Opening Scanning Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Handle other types of exceptions
            MessageBox.Show(ex.Message, "Error Dropping Database Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        GBoxInformation.Focus()
    End Sub

    Private Sub BtnDataClear_Click(sender As Object, e As EventArgs) Handles BtnDataClear.Click
        TBoxSerialNo.Clear()
        CBoxStation.Text = Nothing
        TBoxFailureSymptoms.Clear()
    End Sub

    Private Sub TBoxFailureSymptoms_TextChanged(sender As Object, e As EventArgs) Handles TBoxFailureSymptoms.TextChanged
        TBoxFailureSymptoms.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxFailureSymptoms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBoxFailureSymptoms.KeyPress
        If TBoxFailureSymptoms.TextLength = 0 Then
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
                'dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@endtNo", TBoxRcvEndtNo.Text)
                Dim Count As Integer = dbCmd.ExecuteScalar
                LblEndtTotalQty.Text = Count
            End Using
            dbConn.Close()

            DGVRcvEndtData.DataSource = dbTable
            DGVRcvEndtData.ClearSelection()
        Catch ex As SqlException
            ' Handle database-related errors
            MessageBox.Show("An error occurred while processing your request. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Handle other types of exceptions
            MessageBox.Show(ex.Message, "Error Searching Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub TBoxRcvEndtNo_TextChanged(sender As Object, e As EventArgs) Handles TBoxRcvEndtNo.TextChanged

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

    Private Sub TBoxRcvReceivedBy_TextChanged(sender As Object, e As EventArgs) Handles TBoxRcvReceivedBy.TextChanged
        TBoxRcvReceivedBy.CharacterCasing = CharacterCasing.Upper
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
End Class
