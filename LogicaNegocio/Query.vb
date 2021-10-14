Imports System.Configuration
Imports System.Data.Odbc
Imports System.Text


Public Class Query
    Dim empresa As String
    Public Function Recuperar_Datos(ByVal tipo As Integer, ByVal tabla As String, ByVal campo As String, ByVal cod As String, ByVal campo_orden As String, ByVal ip As String) As DataTable
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        Dim codEmpresa As String = ConfigurationManager.AppSettings("codEmpresa")
        empresa = codEmpresa


        CadConsulta.Append(" " & vbLf)
        If tipo = 1 Then
            CadConsulta.Append("select   id,codigo,codbar, descripcion, precio1,precio2,precio3,cantidad2,1 as imprimir, proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "'   order by " & campo_orden & " " & vbLf)
            'CadConsulta.Append("select   id,codigo,codbar, descripcion, precio1,precio2,cantidad2,1 as imprimir, proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "' and ip='" & ip.Trim & "' and id='" & empresa.Trim & "'  order by " & campo_orden & " " & vbLf)
        ElseIf tipo = 5 Then
            CadConsulta.Append("select id, codigo,codbar,descripcion, precio1,precio2,precio3,cantidad2,1 as imprimir,proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "'   order by " & campo_orden & " " & vbLf)
            'CadConsulta.Append("select id, codigo,codbar,descripcion, precio1,precio2,cantidad2,1 as imprimir,proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "' and ip='" & ip.Trim & "' and id='" & empresa.Trim & "'  order by " & campo_orden & " " & vbLf)
        Else
            CadConsulta.Append("select  id,codigo,codbar,descripcion, precio1,precio2,precio3,cantidad2,1 as imprimir, proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "'  order by " & campo_orden & " " & vbLf)
            'CadConsulta.Append("select  id,codigo,codbar,descripcion, precio1,precio2,cantidad2,1 as imprimir, proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "' and ip='" & ip.Trim & "' and id='" & empresa.Trim & "'  order by " & campo_orden & " " & vbLf)
        End If
        CadConsulta.Append(" " & vbLf)


        'CadConsulta.Append(" " & vbLf)
        'If tipo = 1 Then
        '    CadConsulta.Append("select  17 as id,codigo,codbar, descripcion, precio1,precio2,cantidad2,1 as imprimir, proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "' and ip='" & ip.Trim & "' order by " & campo_orden & " " & vbLf)
        'ElseIf tipo = 5 Then
        '    CadConsulta.Append("select 17  as id,codigo,codbar,descripcion, precio1,precio2,cantidad2,1 as imprimir,proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "' and ip='" & ip.Trim & "' order by " & campo_orden & " " & vbLf)
        'Else
        '    CadConsulta.Append("select 17  id,codigo,codbar,descripcion, precio1,precio2, cantidad2,1 as imprimir, proveedor from " & tabla & " where " & campo & "  like '" & cod.Trim & "' and ip='" & ip.Trim & "' order by " & campo_orden & " " & vbLf)
        'End If
        'CadConsulta.Append(" " & vbLf)

        Try
            Return tb_datos.Recuperar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Recuperar_Datos2(ByVal tabla As String) As DataTable
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("select * from " & tabla & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Recuperar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Datos_Etiqueta_Cantidad(ByVal codigo As String) As DataTable
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("select * from dba.etiqueta_cantidad where id_prod='" & codigo & "'" & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Recuperar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function MostrarProductos_ant(ByVal descr As String, ByVal cod As String, ByVal codbar As String, ByVal bloq As Integer, ByVal tipo As Integer) As DataTable
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("select top 10 idproductodescripcion as ID,isnull(codigointerno,0) as codigo,isnull(codigobarra,0) as codbar,ltrim(rtrim(upper(descripcionlarga))) as descripcion," & vbLf)
        CadConsulta.Append("isnull((cast(round((case when (idgravaiva=1)then preciosiniva*1.12 else preciosiniva end),2) as decimal(14,2))),0)as precio1," & vbLf)
        CadConsulta.Append("isnull((cast(round((case when (idgravaiva=1)then preciomayorista*1.12 else preciomayorista end),2) as decimal(14,2))),0)as precio2, " & vbLf)
        CadConsulta.Append("isnull((cast(round(cantidad,2) as decimal(14,0))),0) as cantidad " & vbLf)
        CadConsulta.Append("from productos_descripcion left join etiqueta_cantidad on idproductodescripcion=id_prod")
        If descr <> "" Then
            CadConsulta.Append(" where descripcionlarga like'" & descr.Trim & "' " & vbLf)
        End If
        If codbar <> "" Then
            CadConsulta.Append(" where (codigobarra like'" & codbar.Trim & "') or (codigointerno like'" & codbar.Trim & "') " & vbLf)
        End If
        CadConsulta.Append(" order by descripcionlarga  " & vbLf)
        CadConsulta.Append(" " & vbLf)
        'MsgBox(CadConsulta.ToString)
        Try
            Return tb_datos.Recuperar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function MostrarProductos(ByVal descr As String, ByVal cod As String, ByVal codbar As String, ByVal bloq As Integer, ByVal tipo As Integer) As DataTable
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        Dim codEmpresa As String = ConfigurationManager.AppSettings("codEmpresa")
        empresa = codEmpresa
        CadConsulta.Append("select TOP 30 empresa,codigo,codigo_barra,descripcion1," & vbLf)
        CadConsulta.Append("pvp1," & vbLf)
        CadConsulta.Append("pvp2, " & vbLf)
        CadConsulta.Append("pvp3, " & vbLf)
        CadConsulta.Append("1 as cantidaduno " & vbLf)
        CadConsulta.Append(" from dba.in_item")
        CadConsulta.Append(" where empresa = '" & empresa.Trim & "' " & vbLf)

        Dim x As Integer = 0
        If descr <> "" Then
            CadConsulta.Append(" and descripcion1 like'" & descr.Trim & "'" & vbLf)
            'CadConsulta.Append(" and rownum <100")
            x = 1
        End If
        If codbar <> "" Then
            CadConsulta.Append(" and ((codigo_barra like'" & codbar.Trim & "' ) or (codigo like'" & codbar.Trim & "')) " & vbLf)
            'CadConsulta.Append(" and codigo  like '" & codbar.Trim & "' " & vbLf)
            'CadConsulta.Append(" and rownum <100")
            x = 1
        End If
        CadConsulta.Append(" order by descripcion1  " & vbLf)
        CadConsulta.Append(" " & vbLf)

        'MsgBox(CadConsulta.ToString)
        Try
            Return tb_datos.Recuperar_Registros_Syba(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function MostrarProductosCompra(ByVal compra As String, ByVal ip As String) As Boolean

        '''Preguntar a Caleb
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("insert into dba.etiqueta_item " & vbLf)
        CadConsulta.Append("select codigo,codigo_barra,descripcion1,pvp1,pvp2,pvp3, " & vbLf)
        CadConsulta.Append("0 as cantidad2'" & ip & "'" & vbLf)
        CadConsulta.Append(" from dba.in_item  " & vbLf)
        CadConsulta.Append("where empresa = '" & compra & "' ")
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Modificar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Insertar_Item(ByVal ID As Decimal, ByVal cod As String, ByVal codbar As String, ByVal nom As String, ByVal prec1 As Decimal, ByVal prec2 As Decimal, ByVal prec3 As Decimal, ByVal cantidad As Decimal, ByVal ip As String) As Boolean
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla   
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("insert into dba.etiqueta_item (ID,codigo,codbar,descripcion,precio1,precio2,precio3,cantidad2,ip)" & vbLf)
        CadConsulta.Append("values('" & ID & "','" & cod & "','" & codbar & "','" & nom.Replace("'", "").Trim & "',('" & prec1 & "'),'" & prec2 & "','" & prec3 & "','" & cantidad & "','" & ip.Trim & "')" & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Modificar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Act_cant_etiqueta_item(ByVal codigo As String, ByVal cantidad As Decimal) As Boolean
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("update dba.etiqueta_item set cantidad='" & cantidad & "' where ID='" & codigo & "'" & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Modificar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Act_cant_etiqueta(ByVal codigo As String, ByVal cantidad As Decimal) As Boolean
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("update dba.etiqueta_cantidad set cantidad='" & cantidad & "' where id_prod='" & codigo & "'" & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Modificar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Ins_cant_etiqueta(ByVal codigo As String, ByVal cantidad As Decimal) As Boolean
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("insert into dba.etiqueta_cantidad (id_prod,cantidad) values( '" & codigo & "','" & cantidad & "')" & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Modificar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Eliminar_Datos(ByVal tabla As String, ByVal campo As String, ByVal cod As String) As Boolean
        Dim CadConsulta As New StringBuilder
        Dim tb_datos As New BaseDatos.AbrirTabla
        CadConsulta.Append(" " & vbLf)
        CadConsulta.Append("delete from " & tabla & " where " & campo & " like '" & cod & "'" & vbLf)
        CadConsulta.Append(" " & vbLf)
        Try
            Return tb_datos.Modificar_Registros_Sybase(CadConsulta.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


End Class
