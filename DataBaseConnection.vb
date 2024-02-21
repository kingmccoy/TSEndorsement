Imports System.Data.SqlClient

Module DataBaseConnection
    Public dbConn As New SqlConnection("Data Source=DESKTOP-PS4G375\TSENDORSEMENTSVR;Initial Catalog=sli_endorsement;Persist Security Info=True;User ID=test;Password=test123;Encrypt=False;Connection Timeout=30;")
End Module
