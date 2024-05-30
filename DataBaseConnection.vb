Imports System.Data.SqlClient

Module DataBaseConnection
    Public dbConn As New SqlConnection("Data Source=10.10.15.11,1444;Initial Catalog=sli_endorsement;Persist Security Info=True;User ID=test;Password=test123;Encrypt=False;Connection Timeout=30;")

    Public Sub Load_Model_Variant()
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
            FrmMain.CBoxModel.DataSource = dbTable
            FrmMain.CBoxModel.DisplayMember = "variant"
            FrmMain.CBoxModel.Text = Nothing
            FrmMain.CboxInqModel.DataSource = dbTable
            FrmMain.CboxInqModel.DisplayMember = "variant"
            FrmMain.CboxInqModel.Text = Nothing
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

    Public Sub Load_Inquiry()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "Inquiry"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@endtNo", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar()
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

    Public Sub Load_InquiryUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar()

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNo()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNo"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtNo", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar()
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

    Public Sub Load_InquiryEndtNoUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar()

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryDateFailed()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailed"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryDateFailedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
            End Using
            dbConn.Close()
            'FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryDateFailedUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
            End Using
            dbConn.Close()
            'FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoDateFailed()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailed"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoDateFailedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
            End Using
            dbConn.Close()
            'FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoDateFailedUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
            End Using
            dbConn.Close()
            'FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtDate()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtDate"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtDateCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtDateCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtDateUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtDateUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNoEndtDate()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoEndtDate"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoEndtDateCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoEndtDateCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtNoEndtDateUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoEndtDateUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                'dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryDateFailedEndt()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedEndt"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryDateFailedEndtCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedEndtCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryDateFailedEndtUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedEndtUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNoDateFailedEndt()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedEndt"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoDateFailedEndtCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedEndtCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtNoDateFailedEndtUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedEndtUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryTSDate()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryTSDate"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryTSDateCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryTSDateCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryTSDateUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryTSDateUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNoTSDate()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoTSDate"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoTSDateCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoTSDateCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtNoTSDateUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoTSDateUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryDateFailedTS()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedTS"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryDateFailedTSCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedTSCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryDateFailedTSUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryDateFailedTSUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNoDateFailedTS()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedTS"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoDateFailedTSCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedTSCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtNoDateFailedTSUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoDateFailedTSUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                'dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtDateTS()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtDateTS"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtDateTSCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtDateTSCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtDateTSUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtDateTSUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNoEndtDateTS()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoEndtDateTS"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoEndtDateTSCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoEndtDateTSCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtNoEndtDateTSUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoEndtDateTSUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                'dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryFailedEndtTS()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryFailedEndtTS"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryFailedEndtTSCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryFailedEndtTSCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryFailedEndtTSUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryFailedEndtTSUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_InquiryEndtNoFailedEndtTS()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoFailedEndtTS"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.DgvInqSummary.DataSource = dbTable
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

    Public Sub Load_InquiryEndtNoFailedEndtTSCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoFailedEndtTSCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalSearch.Text = dbCmd.ExecuteScalar
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

    Public Sub Load_InquiryEndtNoFailedEndtTSUnverifiedCount()
        Try
            Dim dbTable As New DSInquiry.DTInquiryDataTable
            'Dim dbTable As New DataTable
            Dim StoredProcedure = "InquiryEndtNoFailedEndtTSUnverifiedCount"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@endtno", FrmMain.TboxInqEndtNo.Text)
                dbCmd.Parameters.AddWithValue("@serialno", FrmMain.TboxInqSerialNo.Text)
                dbCmd.Parameters.AddWithValue("@model", FrmMain.CboxInqModel.Text)
                dbCmd.Parameters.AddWithValue("@station", FrmMain.CboxInqStation.Text)
                dbCmd.Parameters.AddWithValue("@ppono", FrmMain.TboxInqPPONo.Text)
                dbCmd.Parameters.AddWithValue("@lotno", FrmMain.TboxInqLotNo.Text)
                dbCmd.Parameters.AddWithValue("@workorder", FrmMain.TboxInqWorkOrder.Text)
                dbCmd.Parameters.AddWithValue("@failuresymptoms", FrmMain.TboxInqFailureSymptoms.Text)
                dbCmd.Parameters.AddWithValue("@datefailed", FrmMain.DtpInqDateFailed.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@endtdate", FrmMain.DtpInqEndtDate.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@analysis", FrmMain.TboxInqAnalysis.Text)
                dbCmd.Parameters.AddWithValue("@actiontaken", FrmMain.TboxInqActionTaken.Text)
                dbCmd.Parameters.AddWithValue("@defecttype", FrmMain.TboxInqDefType.Text)
                'dbCmd.Parameters.AddWithValue("@status", FrmMain.TboxInqStatus.Text)
                dbCmd.Parameters.AddWithValue("@remarks", FrmMain.TboxInqRemarks.Text)
                dbCmd.Parameters.AddWithValue("@tsDateFrom", FrmMain.DtpInqTSDateFrom.Value.ToString("yyyy-MM-dd"))
                dbCmd.Parameters.AddWithValue("@tsDateTo", FrmMain.DtpInqTSDateTo.Value.ToString("yyyy-MM-dd"))

                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using

                FrmMain.LblInqTotalUnverified.Text = dbCmd.ExecuteScalar

                If FrmMain.LblInqTotalUnverified.Text <> 0 Then
                    FrmMain.LblInqUnverified.ForeColor = Color.DarkRed
                    FrmMain.LblInqTotalUnverified.ForeColor = Color.DarkRed
                ElseIf FrmMain.LblInqTotalUnverified.Text = 0 Then
                    FrmMain.LblInqUnverified.ForeColor = SystemColors.ControlText
                    FrmMain.LblInqTotalUnverified.ForeColor = SystemColors.ControlText
                End If
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

    Public Sub Load_Station()
        Try
            Dim dbTable As New DSStation.DTStationsDataTable
            Dim StoredProcedure = "GetStation"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                dbCmd.Parameters.AddWithValue("@variant", FrmMain.CBoxModel.Text)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.CBoxStation.DataSource = dbTable
            FrmMain.CBoxStation.DisplayMember = "station"
            FrmMain.CBoxStation.Text = Nothing
            FrmMain.CBoxStation.DropDownHeight = 106
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

    Public Sub Load_Station_Inquiry()
        Try
            Dim dbTable As New DSStation.DTStationsDataTable
            Dim StoredProcedure = "SELECT * FROM station"
            dbConn.Open()
            Using dbCmd As New SqlCommand(StoredProcedure, dbConn)
                'dbCmd.CommandType = CommandType.StoredProcedure
                'dbCmd.Parameters.AddWithValue("@variant", CboxInqModel.Text)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            FrmMain.CboxInqStation.DataSource = dbTable
            FrmMain.CboxInqStation.DisplayMember = "station"
            FrmMain.CboxInqStation.Text = Nothing
            FrmMain.CboxInqStation.DropDownHeight = 106
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

    Public Sub Load_Latest_EndorsementNo()
        Try
            Dim procedure = "GetEndorsementNo"
            dbConn.Open()
            Using dbCmd As New SqlCommand(procedure, dbConn)
                dbCmd.CommandType = CommandType.StoredProcedure
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        FrmMain.TboxEndorsementNo.Text = dbReader("endorsement_no")
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

    Public Sub Load_TempEndorsementData()
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
            FrmMain.DGVEndorsementData.DataSource = dbTable
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

    Public Sub Count_TempEndorsement()
        Try
            Dim Query = "SELECT COUNT(id) AS id FROM TempEndorsement"
            dbConn.Open()
            Using dbCmd As New SqlCommand(Query, dbConn)
                Dim count As Integer = Convert.ToInt32(dbCmd.ExecuteScalar())

                FrmMain.LblTotalQty.Text = count.ToString

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

    Public Sub DropTempEndorsementTable()
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

    Public Sub DropTempTSEndorsementTable()
        Try
            Dim StoredProcedure = "DropTempTSEndorsementTable"
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
End Module
