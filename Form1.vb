Imports System.Data.Common
Imports System.Data.SQLite

Public Class Form1
    Private dbCon As New SQLiteConnection("Data Source=" & System.Windows.Forms.Application.StartupPath & "\endorsement_proposal.db;Version=3;FailIfMissing=True;")

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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try
            Dim q = "INSERT INTO endorsement (endorsement_no,qty_endorsed, qty, model, serial_no, ppo_no, lot_no, work_order, station, failure_symptoms, endorsed_by, date_failed, endorsement_date, workweek)
                    VALUES ('" & TboxEndorsementNo.Text & "','" & TBoxQtyEndorsed.Text & "','" & 1 & "','" & TBoxModel.Text & "','" & TBoxSerialNo.Text & "','" & TBoxPPONo.Text & "','" & TBoxPPOQty.Text & "','" & TBoxLotNo.Text & "',
            '" & TBoxWorkOrder.Text & "','" & TBoxStation.Text & "','" & TBoxFailureSymptoms.Text & "','" & DTPDateFailed.Value.ToString("MM-dd-yyyy") & "','" & DTPEndorsementDate.Value.ToString("MM-dd-yyyy") & "',
            '" & TBoxWorkweek.Text & "')"
            dbCon.Open()
            Using dbCmd As New SQLiteCommand(q, dbCon)
                dbCmd.ExecuteNonQuery()
            End Using
            dbCon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Load_QtyEndorsed()
        Dim dtTable As New DataTable
        Try
            Dim q = "SELECT (SELECT endorsement_no FROM endorsement ORDER BY id DESC LIMIT 1) + 1 AS endorsement_no"
            dbCon.Open()
            Using dbCmd As New SQLiteCommand(q, dbCon)
                Using dbReader As SQLiteDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        TboxEndorsementNo.Text = dbReader("endorsement_no").ToString
                    End If
                End Using
            End Using
            dbCon.Close()
        Catch ex As Exception
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

    End Sub
End Class
