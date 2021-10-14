Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports System.Data.Odbc

Public Class AbrirTabla
    Inherits Coneccion
    Public Function Recuperar_Registros_ORCL(ByVal CadenaConsulta As String) As DataTable
        Dim cnn_ORCL As New OracleConnection
        AbrirConeccion_ORCL(cnn_ORCL)
        Dim cmd As New OracleCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OracleDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As String
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor <> "0" Then
                oda.ReturnProviderSpecificTypes = True
                oda.Fill(ods, "Tabla")
                Return ods.Tables("Tabla")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Recuperar_Registros_Syba(ByVal CadenaConsulta As String) As DataTable
        Dim cnn_ORCL As New OdbcConnection
        AbrirConeccionSybases(cnn_ORCL)
        Dim cmd As New OdbcCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OdbcDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As String
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor <> "0" Then
                oda.ReturnProviderSpecificTypes = True
                oda.Fill(ods, "Tabla")
                Return ods.Tables("Tabla")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Modificar_Registros_ORCL(ByVal CadenaConsulta As String) As Boolean
        Dim cnn_ORCL As New OracleConnection
        AbrirConeccion_ORCL(cnn_ORCL)
        Dim cmd As New OracleCommand(CadenaConsulta, cnn_ORCL)
        Dim Valor As Object
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor = Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function Modificar_Registros_SYBA(ByVal CadenaConsulta As String) As Boolean
        Dim cnn_ORCL As New OdbcConnection
        AbrirConeccionSybases(cnn_ORCL)
        Dim cmd As New OdbcCommand(CadenaConsulta, cnn_ORCL)
        Dim Valor As Object
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor = Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function Recuperar_Registros(ByVal CadenaConsulta As String) As DataTable
        Dim cnn_ORCL As New OracleConnection
        AbrirConeccion_ORCL(cnn_ORCL)
        Dim cmd As New OracleCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OracleDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As String
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor <> "0" Then
                oda.ReturnProviderSpecificTypes = True
                oda.Fill(ods, "Tabla")
                Return ods.Tables("Tabla")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        cnn_ORCL.Close()
    End Function

    Public Function Recuperar_Registros_Sybase(ByVal CadenaConsulta As String) As DataTable
        Dim cnn_ORCL As New OdbcConnection
        AbrirConeccionSybases(cnn_ORCL)
        Dim cmd As New OdbcCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OdbcDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As String
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor <> "0" Then
                oda.ReturnProviderSpecificTypes = True
                oda.Fill(ods, "Tabla")
                Return ods.Tables("Tabla")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        cnn_ORCL.Close()
    End Function
    Public Function Modificar_Registros(ByVal CadenaConsulta As String) As Boolean
        Dim cnn_ORCL As New OracleConnection
        AbrirConeccion_ORCL(cnn_ORCL)
        Dim cmd As New OracleCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OracleDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As Object
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor = Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        cnn_ORCL.Close()
    End Function
    Public Function Modificar_Registros_Sybase(ByVal CadenaConsulta As String) As Boolean
        Dim cnn_ORCL As New OdbcConnection
        AbrirConeccionSybases(cnn_ORCL)
        Dim cmd As New OdbcCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OdbcDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As Object
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor = Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        cnn_ORCL.Close()
    End Function

    Public Function Modificar_Registros_Sybase_codigo(ByVal CadenaConsulta As String) As Boolean
        Dim cnn_ORCL As New OdbcConnection
        AbrirConeccionSybases(cnn_ORCL)
        Dim cmd As New OdbcCommand(CadenaConsulta, cnn_ORCL)
        Dim oda As New OdbcDataAdapter(CadenaConsulta, cnn_ORCL)
        Dim ods As New DataSet
        Dim Valor As Object
        Try
            Valor = cmd.ExecuteScalar
            cnn_ORCL.Close()
            If Valor = Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        cnn_ORCL.Close()
    End Function
End Class
