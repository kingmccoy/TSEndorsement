Imports System.Data.Common
Imports System.Data.Entity.Infrastructure.DependencyResolution
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Text.RegularExpressions

Public Class FrmMain
    'Private dbCon As New SQLiteConnection("Data Source=" & System.Windows.Forms.Application.StartupPath & "\endorsement_proposal.db;Version=3;FailIfMissing=True;")
    Dim DateNow = DateTime.Now.ToString("MM-dd-yyyy")
    Dim TimeNow = DateTime.Now.ToString("hh:mm:ss")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TboxEndorsementNo.ReadOnly = True
        'TBoxWorkweek.ReadOnly = True
        Dim workweek = DatePart("ww", DTPEndorsementDate.Value)
        TBoxWorkweek.Text = Format(workweek, "00")
        Load_EndorsementNo()
        Load_Model_Variant()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnEndorse.Click
        'Try
        '    Dim q = "INSERT INTO
        '                endorsement (endorsement_no, qty_endorsed, qty, model, serial_no, ppo_no, ppo_qty, lot_no, work_order, station, failure_symptoms, endorsed_by, date_failed, endorsement_date, workweek, date, time)
        '            VALUES
        '                ('" & TboxEndorsementNo.Text & "','" & TBoxQtyEndorsed.Text & "','" & 1 & "','" & CBoxModel.Text & "','" & TBoxSerialNo.Text & "','" & TBoxPPONo.Text & "','" & TBoxPPOQty.Text & "','" & TBoxLotNo.Text & "',
        '                '" & TBoxWorkOrder.Text & "','" & CBoxStation.Text & "','" & TBoxFailureSymptoms.Text & "','" & TBoxEndorsedBy.Text & "','" & DTPDateFailed.Value.ToString("MM-dd-yyyy") & "','" & DTPEndorsementDate.Value.ToString("MM-dd-yyyy") & "',
        '                '" & TBoxWorkweek.Text & "','" & DateNow & "','" & TimeNow & "')"
        '    dbConn.Open()
        '    Using dbCmd As New SqlCommand(q, dbConn)
        '        dbCmd.ExecuteNonQuery()
        '    End Using
        '    dbConn.Close()
        'Catch ex As Exception
        '    dbConn.Close()
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        ''Using DataSet
        'Try
        '    Dim dbTable As New DSEndorsementData.DTEndorsementDataDataTable
        '    Dim newRow As DataRow = dbTable.NewRow

        '    Dim maxId As Integer = 0
        '    For Each row As DataRow In dbTable.Rows
        '        Dim id As Integer = Convert.ToInt32(row("id"))
        '        If id > maxId Then
        '            maxId = id
        '        End If
        '    Next

        '    newRow("id") = maxId + 1
        '    newRow("endorsement_no") = TboxEndorsementNo.Text
        '    newRow("qty_endorsed") = TBoxQtyEndorsed.Text
        '    newRow("qty") = 1
        '    newRow("model") = CBoxModel.Text
        '    newRow("serial_no") = TBoxSerialNo.Text
        '    newRow("ppo_no") = TBoxPPONo.Text
        '    newRow("ppo_qty") = TBoxPPOQty.Text
        '    newRow("lot_no") = TBoxLotNo.Text
        '    newRow("work_order") = TBoxWorkOrder.Text
        '    newRow("station") = CBoxStation.Text
        '    newRow("failure_symptoms") = TBoxFailureSymptoms.Text
        '    newRow("endorsed_by") = TBoxEndorsedBy.Text
        '    newRow("date_failed") = DTPDateFailed.Value.ToString("MM-dd-yyyy")
        '    newRow("endorsement_date") = DTPEndorsementDate.Value.ToString("MM-dd-yyyy")
        '    newRow("workweek") = TBoxWorkweek.Text
        '    newRow("date") = DateNow
        '    newRow("time") = TimeNow

        '    dbTable.Rows.Add(newRow)
        '    DGVEndorsementData.DataSource = dbTable


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error Insert Data to Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        Try
            Dim StoredProcedure = "InsertTempEndorsementData"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@id",)
                dbCmd.Parameters.AddWithValue("@endorsement_no", TboxEndorsementNo.Text)
                dbCmd.Parameters.AddWithValue("@qty_endorsed", TBoxQtyEndorsed.Text)
                dbCmd.Parameters.AddWithValue("@qty", 1)
                dbCmd.Parameters.AddWithValue("@model", CBoxModel.Text)
                dbCmd.Parameters.AddWithValue("@serial_no", TBoxSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@ppo_no", TBoxPPONo.Text)
                dbCmd.Parameters.AddWithValue("@ppo_qty", TBoxPPOQty.Text)
                dbCmd.Parameters.AddWithValue("@lot_no", TBoxLotNo.Text)
                dbCmd.Parameters.AddWithValue("@work_order", TBoxWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@station", CBoxStation.Text)
                dbCmd.Parameters.AddWithValue("@failure_symptoms", TBoxFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@endorsed_by", TBoxEndorsedBy.Text)
                dbCmd.Parameters.AddWithValue("@date_failed", DTPDateFailed.Value.ToString("MM-dd-yyyy"))
                dbCmd.Parameters.AddWithValue("@endorsement_date", DTPEndorsementDate.Value.ToString("HH:mm:ss"))
                dbCmd.Parameters.AddWithValue("@workweek", TBoxWorkweek.Text)
                dbCmd.Parameters.AddWithValue("@date", DateNow)
                dbCmd.Parameters.AddWithValue("@time", TimeNow)
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
            Load_TempEndorsementData()
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Load_EndorsementNo()
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
            Dim q = "SELECT
                        ROW_NUMBER() OVER (ORDER BY id) AS id, model, serial_no, ppo_no, ppo_qty, lot_no, work_order, station, failure_symptoms, endorsed_by
                    FROM
                        TempEndorsement
                    WHERE endorsement_no = '" & TboxEndorsementNo.Text & "'"
            dbConn.Open()
            Using dbCmd As New SqlCommand(q, dbConn)
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

        If TBoxQtyEndorsed.Text.Length > 0 Then
            If TBoxQtyEndorsed.Text = Qty.Value Then
                ErrorProvider1.SetError(TBoxQtyEndorsed, Nothing)
            Else
                ErrorProvider1.SetError(TBoxQtyEndorsed, "Only number are allowed")
            End If
        Else
            If TBoxQtyEndorsed.Text.Length = 0 Then
                ErrorProvider1.SetError(TBoxQtyEndorsed, Nothing)
            End If
        End If
    End Sub

    Private Sub TBoxPPONo_TextChanged(sender As Object, e As EventArgs) Handles TBoxPPONo.TextChanged
        TBoxPPONo.MaxLength = 10

        Dim PPONum = "[0-9]{10}"
        If TBoxPPONo.Text.Length > 0 Then
            If Regex.IsMatch(TBoxPPONo.Text, PPONum) Then
                ErrorProvider1.SetError(TBoxPPONo, Nothing)
            Else
                ErrorProvider1.SetError(TBoxPPONo, "Invalid PPO number")
            End If
        Else
            If TBoxPPONo.Text.Length = 0 Then
                ErrorProvider1.SetError(TBoxPPONo, Nothing)
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

    Private Sub CBoxModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxModel.SelectedIndexChanged
        Load_Station()
    End Sub

    Private Sub CBoxModel_TextChanged(sender As Object, e As EventArgs) Handles CBoxModel.TextChanged
        If CBoxModel.Text = Nothing Then
            CBoxStation.DataSource = Nothing
        End If
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
            Else
                ErrorProvider1.SetError(TBoxLotNo, "Invalid lot number")
            End If
        Else
            If TBoxLotNo.Text.Length = 0 Then
                ErrorProvider1.SetError(TBoxLotNo, Nothing)
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
            Else
                ErrorProvider1.SetError(TBoxWorkOrder, "Invalid work order")
            End If
        Else
            If TBoxWorkOrder.TextLength = 0 Then
                ErrorProvider1.SetError(TBoxWorkOrder, Nothing)
            End If
        End If
    End Sub

    Private Sub TBoxEndorsedBy_TextChanged(sender As Object, e As EventArgs) Handles TBoxEndorsedBy.TextChanged
        TBoxEndorsedBy.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TBoxSerialNo_TextChanged(sender As Object, e As EventArgs) Handles TBoxSerialNo.TextChanged
        TBoxSerialNo.MaxLength = 11
        TBoxSerialNo.CharacterCasing = CharacterCasing.Upper

        Dim RegexSerialNo = Regex.Match(TBoxSerialNo.Text, "[0-9]{2}[0-9]{2}BC[2-9A-HJ-NP-Z]{5}")

        If TBoxSerialNo.Text.Length > 0 Then
            If TBoxSerialNo.Text = RegexSerialNo.Value Then
                ErrorProvider1.SetError(TBoxSerialNo, Nothing)
            Else
                ErrorProvider1.SetError(TBoxSerialNo, "Invalid serial number")
            End If
        Else
            If TBoxSerialNo.TextLength = 0 Then
                ErrorProvider1.SetError(TBoxSerialNo, Nothing)
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
    End Sub
End Class
