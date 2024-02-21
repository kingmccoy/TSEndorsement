Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Text.RegularExpressions

Public Class Endorsement
    'Private dbCon As New SQLiteConnection("Data Source=" & System.Windows.Forms.Application.StartupPath & "\endorsement_proposal.db;Version=3;FailIfMissing=True;")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        TboxEndorsementNo.ReadOnly = True
        TBoxWorkweek.ReadOnly = True
        Dim workweek = DatePart("ww", DTPEndorsementDate.Value)
        TBoxWorkweek.Text = Format(workweek, "00")
        Load_QtyEndorsed()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TBoxQtyEndorsed.Clear()
        TBoxModel.Clear()
        TBoxSerialNo.Clear()
        TBoxPPONo.Clear()
        TBoxPPOQty.Clear()
        TBoxLotNo.Clear()
        TBoxWorkOrder.Clear()
        TBoxStation.Clear()
        TBoxFailureSymptoms.Clear()
        TBoxEndorsedBy.Clear()
        TBoxWorkweek.Clear()

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
        Try
            Dim q = "INSERT INTO endorsement (endorsement_no,qty_endorsed, qty, model, serial_no, ppo_no, lot_no, work_order, station, failure_symptoms, endorsed_by, date_failed, endorsement_date, workweek)
                    VALUES ('" & TboxEndorsementNo.Text & "','" & TBoxQtyEndorsed.Text & "','" & 1 & "','" & TBoxModel.Text & "','" & TBoxSerialNo.Text & "','" & TBoxPPONo.Text & "','" & TBoxPPOQty.Text & "','" & TBoxLotNo.Text & "',
            '" & TBoxWorkOrder.Text & "','" & TBoxStation.Text & "','" & TBoxFailureSymptoms.Text & "','" & DTPDateFailed.Value.ToString("MM-dd-yyyy") & "','" & DTPEndorsementDate.Value.ToString("MM-dd-yyyy") & "',
            '" & TBoxWorkweek.Text & "')"
            dbConn.Open()
            Using dbCmd As New SqlCommand(q, dbConn)
                dbCmd.ExecuteNonQuery()
            End Using
            dbConn.Close()
        Catch ex As Exception
            'dbConn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Load_QtyEndorsed()
        Try
            Dim q = ""
            dbConn.Open()
            Using dbCmd As New SqlCommand(q, dbConn)

            End Using
            dbConn.Close()
        Catch ex As Exception
            dbConn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Load_DataBase()
        Try

        Catch ex As Exception
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
                ErrorProvider1.Clear()
            Else
                ErrorProvider1.SetError(TBoxPPONo, "Invalid PPO number")
            End If
        Else
            If TBoxPPONo.Text.Length = 0 Then
                ErrorProvider1.Clear()
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
End Class
