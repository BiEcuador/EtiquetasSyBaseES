Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Odbc

Public Class Coneccion
    Public Sub AbrirConeccion(ByRef cn As SqlConnection)
        Try
            Dim constring As String = ConfigurationManager.ConnectionStrings("SqlConect").ToString
            cn = New SqlConnection(constring)
            cn.Open()
        Catch ex As Exception
            Dim a As String = ex.Message
        End Try
    End Sub
    Public Sub AbrirConeccion_ORCL(ByRef cn As OracleConnection)
        Try
            Dim constring As String
            constring = ConfigurationManager.ConnectionStrings("OrclConect").ToString
            cn = New OracleConnection(constring)
            cn.Open()
        Catch ex As Exception
            Dim a As String = ex.Message
        End Try
    End Sub

    Public Sub AbrirConeccionSybases(ByRef cn As OdbcConnection)
        Try
            Dim constring As String = ConfigurationManager.ConnectionStrings("OdbcDatabase").ToString
            cn = New OdbcConnection(constring)
            cn.Open()
        Catch ex As Exception
            Dim a As String = ex.Message
        End Try
    End Sub
End Class
