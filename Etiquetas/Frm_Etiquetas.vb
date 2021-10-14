Option Explicit On
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Math
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Public Class Frm_Etiquetas
    Dim Mi_Query As New LogicaNegocio.Query
    Dim items As New DataTable
    'Dim pd As New PrintDialog()
    Dim printDoc As New PrintDocument
    Dim descripcion1, descripcion2, descripcion3 As String
    Dim Etiq_Amarillas As Decimal = 0
    Private Sub Define_Grid()
        ChkSelec.Visible = False
        Dtg_Etiqueta.AutoGenerateColumns = False
        Dtg_Etiqueta.Columns.Clear()
        Dtg_Etiqueta.Columns.Add("ID", "Indentificador")
        Dtg_Etiqueta.Columns.Add("codigo", "Código")
        Dtg_Etiqueta.Columns.Add("codbar", "CodBar")
        Dtg_Etiqueta.Columns.Add("descripcion", "Descripción")
        Dtg_Etiqueta.Columns.Add("precio1", "Precio1")
        Dtg_Etiqueta.Columns.Add("precio2", "Precio2")
        Dtg_Etiqueta.Columns.Add("precio3", "Precio3")
        Dtg_Etiqueta.Columns.Add("cantidad2", "cantidad")
        Dtg_Etiqueta.Columns.Add("imprimir", "Imprimir")
        Dtg_Etiqueta.Columns.Add("proveedor", "proveedor")
        If TipLabel = 1 Then
            Dim Check As DataGridViewColumn = New DataGridViewCheckBoxColumn
            Check.DataPropertyName = "Selecionar"
            Check.Name = "Selecionar"
            Dtg_Etiqueta.Columns.Add(Check)
            ChkSelec.Visible = True
            ChkSelec.Checked = False
        End If
        ''cantidad era 6 
        Dtg_Etiqueta.Columns(0).DataPropertyName = "ID"
        Dtg_Etiqueta.Columns(1).DataPropertyName = "codigo"
        Dtg_Etiqueta.Columns(2).DataPropertyName = "codbar"
        Dtg_Etiqueta.Columns(3).DataPropertyName = "descripcion"
        Dtg_Etiqueta.Columns(4).DataPropertyName = "precio1"
        Dtg_Etiqueta.Columns(5).DataPropertyName = "precio2"
        Dtg_Etiqueta.Columns(6).DataPropertyName = "Precio3"
        Dtg_Etiqueta.Columns(7).DataPropertyName = "Cantidad2"
        Dtg_Etiqueta.Columns(8).DataPropertyName = "imprimir"
        Dtg_Etiqueta.Columns(9).DataPropertyName = "proveedor"
        Dtg_Etiqueta.Columns(0).ReadOnly = True
        Dtg_Etiqueta.Columns(1).ReadOnly = True
        Dtg_Etiqueta.Columns(2).ReadOnly = True
        Dtg_Etiqueta.Columns(3).ReadOnly = True
        Dtg_Etiqueta.Columns(4).ReadOnly = True
        Dtg_Etiqueta.Columns(5).ReadOnly = True
        Dtg_Etiqueta.Columns(6).ReadOnly = True
        Dtg_Etiqueta.Columns(7).ReadOnly = False
        Dtg_Etiqueta.Columns(8).Visible = True
        Dtg_Etiqueta.Columns(9).Visible = False
        Dtg_Etiqueta.Columns(0).Frozen = True

        Dtg_Etiqueta.Columns(7).Visible = False
    End Sub
    Private Sub Frm_Etiquetas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Datos()
    End Sub
    Public Sub Datos()
        Define_Grid()
        LLena_Grid()
    End Sub
    Private Sub LLena_Grid()
        items = Mi_Query.Recuperar_Datos(TipLabel, "dba.etiqueta_item", "codigo", "%", "descripcion", ObtenerIP)
        Dtg_Etiqueta.DataSource = items
        Dtg_Etiqueta.Refresh()
        Valida_Grid()
    End Sub
    Private Sub Frm_Etiquetas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        End
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub Btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar.Click
        If TipLabel = 1 Then
            Borrar_Item()
            Dim compra As String
            Dim entrada As String
            Do
                entrada = InputBox("Ingrese el número de compra:")
            Loop Until IsNumeric(entrada)
            'compra = CDec(entrada)
            compra = entrada
            If compra = 0 Then Exit Sub
            Mi_Query.MostrarProductosCompra(compra, ObtenerIP)
            LLena_Grid()
            If Not Dtg_Etiqueta.Rows.Count > 0 Then
                MsgBox("No existe este número de compra", MsgBoxStyle.Critical)
                Lbl_Proveedor.Text = "PRODUCTOS"
            Else
                Lbl_Proveedor.Text = Dtg_Etiqueta.Rows(0).Cells(9).Value.ToString
            End If
        Else
            Frm_BuscaProd.ShowDialog()
        End If
    End Sub
    Private Sub Frm_Etiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim delimitadores() As String = {","}
        Dim vectoraux() As String
        Dim cont As Integer = 0
        vectoraux = My.Settings.ListaEtiquetas.Split(delimitadores, StringSplitOptions.None)
        For Each item As String In vectoraux
            If item.Trim() = "" Then
                Cmb_Tipetiqueta.Items(cont) = item.Trim()
            End If
            cont = cont + 1
        Next
        Cmb_Tipetiqueta.SelectedIndex = 0
        ToolTip1.SetToolTip(Btn_Agregar, "Busca item para adicionar a la lista para imprimir")
        ToolTip1.SetToolTip(Btn_Quitar, "Quita el item seleccionado de la lista")
        ToolTip1.SetToolTip(Btn_Borrar, "Quita todos los items de la lista")
        'Cmb_Tipetiqueta.Items(1) = ""

        Dim i As Integer
        Dim InstalledPrinter As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            InstalledPrinter = PrinterSettings.InstalledPrinters.Item(i)
            Cmb_impresoras.items.add(InstalledPrinter)
        Next
    End Sub
    Private Sub Cmb_Tipetiqueta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Tipetiqueta.SelectedIndexChanged
        ' 0 Etiqueta por producto
        ' 1 Etiqueta por numero de compra
        ' 2 Código de barra 
        ' 3 Etiquetas Prendas de Vestir
        If Cmb_Tipetiqueta.Text = "" Then Cmb_Tipetiqueta.SelectedIndex = 0
        TipLabel = Cmb_Tipetiqueta.SelectedIndex
        Select Case TipLabel
            Case 0, 2, 4, 5, 6, 7
                Lbl_Proveedor.Text = "PRODUCTOS"
            Case 3
                Lbl_Proveedor.Text = "PRENDAS DE VESTIR"
        End Select
        Borrar_Item()
        Datos()
    End Sub

    ''Se cambio Id por codigo
    Private Sub Borrar_Item()
        Mi_Query.Eliminar_Datos("dba.etiqueta_item", "codigo", "%")
    End Sub
    Private Sub Btn_Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar.Click
        If Dtg_Etiqueta.Rows.Count > 0 Then
            If BorrarSeleccion() = False Then
                Mi_Query.Eliminar_Datos("dba.etiqueta_item", "codigo", Dtg_Etiqueta.CurrentRow.Cells(1).Value.ToString().Trim)
            End If
            Datos()
        Else
            MsgBox("No hay datos", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function BorrarSeleccion() As Boolean
        If TipLabel <> 1 Then Return False
        Dim con As Integer = 0
        For i As Integer = 0 To Dtg_Etiqueta.RowCount - 1
            If Dtg_Etiqueta.Rows(i).Cells(10).Value = True Then
                Mi_Query.Eliminar_Datos("dba.etiqueta_item", "codigo", Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim)
                con = con + 1
            End If
        Next
        If con > 0 Then
            Return True
            ChkSelec.Checked = False
        Else
            Return False
        End If
    End Function
    Private Sub Btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click
        Borrar_Item()
        Datos()
    End Sub
    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Dim copias As Integer
        If Cmb_Tipetiqueta.Text = "" Then
            MsgBox("Debe de selecionar un tipo de etiqueta", MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Dtg_Etiqueta.Rows.Count > 0 Then
            If Cmb_Impresoras.SelectedIndex <> -1 Then
                printDoc.PrinterSettings.PrinterName = Cmb_Impresoras.Text
            Else
                Exit Sub
            End If
            For i As Integer = 0 To Dtg_Etiqueta.RowCount - 1
                copias = Dtg_Etiqueta.Rows(i).Cells(8).Value.ToString

                For j As Integer = 1 To copias
                    Select Case TipLabel
                        Case 0, 1
                            If (EnCero(Dtg_Etiqueta.Rows(i).Cells(8).Value.ToString().Trim) = True) Then
                                Imprimir_Precio(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim), "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString().Trim,
                                "", "", "", "", "Unidad")
                            End If
                            If (EnCero(Dtg_Etiqueta.Rows(i).Cells(8).Value.ToString().Trim) = False) Then
                                Imprimir_Precio(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim), "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString().Trim,
                                    "$" & Dtg_Etiqueta.Rows(i).Cells(5).Value.ToString().Trim, "", "$" & Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim, "", "2 Precios")
                            End If

                            'If (EnCero(Dtg_Etiqueta.Rows(i).Cells(8).Value.ToString().Trim) = False) Then
                            '    Imprimir_Precio(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim), "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString().Trim,
                            '        "$" & Dtg_Etiqueta.Rows(i).Cells(5).Value.ToString().Trim, "", "$" & Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim, "", "3 Precios", Dtg_Etiqueta.Rows(i).Cells(2).Value.ToString().Trim)
                            'End If


                            'If (EnCero(Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim) = False) Then
                            '    Imprimir_Precio(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim), "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString().Trim,
                            '        "$" & Dtg_Etiqueta.Rows(i).Cells(5).Value.ToString().Trim, "", Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim, "", "2 Precios")
                            'End If
                        Case 2
                            descripcion1 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim)
                            descripcion2 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim)
                            Imprimir_Codbar(descripcion1, descripcion2, Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString, Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                        Case 3
                            descripcion1 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim)
                            If Dtg_Etiqueta.Rows(i).Cells(2).Value.ToString().Trim = "0" Then
                                Imprimir_Precio_Prendas(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, descripcion1, descripcion2, descripcion3,
                                     "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                            Else
                                Imprimir_Precio_Prendas(Dtg_Etiqueta.Rows(i).Cells(2).Value.ToString().Trim, descripcion1, descripcion2, descripcion3,
                                     "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                            End If
                        Case 4
                            descripcion1 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim)
                            descripcion2 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim)
                            Imprimir_CodbarSinPrecio(descripcion1, descripcion2, Dtg_Etiqueta.Rows(i).Cells(2).Value.ToString, Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                        Case 5
                            descripcion1 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim)
                            Imprimir_EtiquetaPequena(descripcion1, descripcion2, Dtg_Etiqueta.Rows(i).Cells(0).Value.ToString, Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                        Case 6
                            descripcion1 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim)
                            Imprimir_EtiquetaAmarillaSinCosto(descripcion1, descripcion2, Dtg_Etiqueta.Rows(i).Cells(2).Value.ToString, Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                        Case 7
                            descripcion1 = Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim)
                            Imprimir_EtiquetaAmarillaConPrecio(descripcion1, descripcion2, Dtg_Etiqueta.Rows(i).Cells(2).Value.ToString, "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString)
                        Case 8
                            If (EnCero(Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim) = True) Then
                                Imprimir_Unidad(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim), "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString().Trim,
                                "", "", "", "", "Unidad")
                            End If
                            If (EnCero(Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim) = False) Then
                                Imprimir_Unidad(Dtg_Etiqueta.Rows(i).Cells(1).Value.ToString().Trim, Longitud_descrip(Dtg_Etiqueta.Rows(i).Cells(3).Value.ToString().Trim), "$" & Dtg_Etiqueta.Rows(i).Cells(4).Value.ToString().Trim,
                                    "$" & Dtg_Etiqueta.Rows(i).Cells(5).Value.ToString().Trim, "", Dtg_Etiqueta.Rows(i).Cells(6).Value.ToString().Trim, "", "2 Precios")
                            End If
                    End Select
                Next
            Next
        Else
            MsgBox("No hay datos para imprimir", MsgBoxStyle.Critical, "Etiquetas")
        End If
    End Sub
    Private Function Longitud_descrip(ByVal descrip As String) As String
        Dim l, l2, l3 As Integer
        l = descrip.Length
        Select Case TipLabel
            Case 0, 1
                If l > 40 Then
                    l = l - 40
                    Return descrip.Remove(40, l)
                End If
            Case 2
                descripcion2 = " "
                If l > 30 Then
                    l = l - 30
                    descripcion2 = descrip.Substring(30)
                    l2 = descripcion2.Length
                    If l2 > 30 Then
                        l2 = l2 - 30
                        descripcion2 = descripcion2.Remove(30, l2)
                    End If
                    Return descrip.Remove(30, l)
                End If
            Case 3, 4
                descripcion2 = " "
                descripcion3 = ""
                If l > 22 Then
                    l = l - 22
                    descripcion2 = descrip.Substring(22)
                    l2 = descripcion2.Length
                    If l2 > 22 Then
                        l2 = l2 - 22
                        descripcion3 = descripcion2.Substring(22)
                        descripcion2 = descripcion2.Remove(22, l2)
                    End If
                    l3 = descripcion3.Length
                    If l3 > 22 Then
                        l3 = l3 - 22
                        descripcion3 = descripcion3.Remove(22, l3)
                    End If
                    Return descrip.Remove(22, l)
                End If
            Case 5
                descripcion2 = " "
                descripcion3 = ""
                If l > 20 Then
                    l = l - 20
                    descripcion2 = descrip.Substring(20)
                    l2 = descripcion2.Length
                    If l2 > 20 Then
                        l2 = l2 - 20
                        descripcion3 = descripcion2.Substring(20)
                        descripcion2 = descripcion2.Remove(20, l2)
                    End If
                    l3 = descripcion3.Length
                    If l3 > 20 Then
                        l3 = l3 - 20
                        descripcion3 = descripcion3.Remove(20, l3)
                    End If
                    Return descrip.Remove(20, l)
                End If
            Case 6, 7
                descripcion2 = " "
                descripcion3 = ""
                If l > 27 Then
                    l = l - 27
                    descripcion2 = descrip.Substring(27)
                    l2 = descripcion2.Length
                    If l2 > 27 Then
                        l2 = l2 - 27
                        descripcion3 = descripcion2.Substring(27)
                        descripcion2 = descripcion2.Remove(27, l2)
                    End If
                    l3 = descripcion3.Length
                    If l3 > 27 Then
                        l3 = l3 - 27
                        descripcion3 = descripcion3.Remove(27, l3)
                    End If
                    Return descrip.Remove(27, l)
                End If
        End Select
        Return descrip
    End Function

    Private Sub Imprimir_Unidad(ByVal codigo As String, ByVal descrip As String, ByVal precio1 As String, ByVal precio2 As String, ByVal precio3 As String, ByVal cant2 As String, ByVal cant3 As String, ByVal tipo As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("N" & vbLf)
        Cadena.Append("q280" & vbLf)
        Cadena.Append("Q512,B24+0" & vbLf)
        Cadena.Append("S2" & vbLf)
        Cadena.Append("D8" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("TTh:m" & vbLf)
        Cadena.Append("TDy2.mn.dd" & vbLf)
        ' NOMBRE DEL PRODUCTO
        Cadena.Append("A235,39,1,4,2,1,N," & Chr(34) & descrip.Trim & Chr(34) & vbLf)
        'PRIMERA LINEA VERTICAL
        Cadena.Append("LO30,26,210,2" & vbLf)
        Select Case TipLabel
            Case 0, 8
                'PRIMERA LINEA HORIZONTAL
                Cadena.Append("LO240,26,2,656" & vbLf)

                'SEGUNDA LINEA HORIZONTAL
                Cadena.Append("LO190,26,2,656" & vbLf)

                'TERCERA LINEA HORIZONTAL
                Cadena.Append("LO30,26,2,656" & vbLf)

                'TERCERA LINEA VERTICAL
                Cadena.Append("LO30,679,210,2" & vbLf)

                If tipo.Trim = "Unidad" Then
                    ' Un solo precio (y,x,rotacion,tipo de letra(1-7),ancho(1-8),alto(1-9),normal(N) reverse(R)
                    Cadena.Append("A180,250,1,5,2,1,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A180,50,1,4,2,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    'Cadena.Append("A185,640,2,3,1,1,N," & Chr(34) & codigo.Trim & Chr(34) & vbLf)
                End If
                If tipo.Trim = "2 Precios" Then
                    'SEGUNDA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,360,160,2" & vbLf)

                    Cadena.Append("A165,39,1,5,2,1,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,39,1,3,1,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    Cadena.Append("A165,370,1,5,2,1,N," & Chr(34) & precio2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,370,1,3,1,1,N," & Chr(34) & "POR " & cant2.Trim & " UNIDADES" & Chr(34) & vbLf)
                End If
                If tipo.Trim = "3 Precios" Then
                    'SEGUNDA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,250,160,2" & vbLf)
                    'TERCERA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,470,160,2" & vbLf)

                    Cadena.Append("A150,39,1,4,3,2,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,39,1,3,1,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    Cadena.Append("A150,255,1,4,3,2,N," & Chr(34) & precio2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,255,1,3,1,1,N," & Chr(34) & "POR " & cant2.Trim & " UNDS." & Chr(34) & vbLf)
                    Cadena.Append("A150,475,1,4,3,2,N," & Chr(34) & precio3.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,475,1,3,1,1,N," & Chr(34) & "POR " & cant3.Trim & " UNDS." & Chr(34) & vbLf)
                End If
                '46 CARACTERES
                Cadena.Append("A50,33,1,3,1,1,R," & Chr(34) & "                " & My.Settings.Almacen & "               " & Chr(34) & vbLf)
        End Select

        Cadena.Append("FE" & vbLf)
        Cadena.Append("P1" & vbLf)

        ' You need a string to send.
        ' Open the printer dialog box, and then allow the user to select a printer.

        'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Cadena.ToString)
        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)

    End Sub

    Private Sub Imprimir_Precio_Sybase(ByVal codigo As String, ByVal descrip As String, ByVal precio1 As String, ByVal precio2 As String, ByVal precio3 As String, ByVal cant2 As String, ByVal cant3 As String, ByVal tipo As String, ByVal codigobarra As String)
        Dim Cadena As New StringBuilder


        Cadena.Append("^XA" & vbLf)
        Cadena.Append("^MMT" & vbLf)
        Cadena.Append("^PW243" & vbLf)
        Cadena.Append("^LL719" & vbLf)
        Cadena.Append("^LS0" & vbLf)
        Cadena.Append("^FO56,30^GB0,648,2^FS" & vbLf)
        ' NOMBRE DEL PRODUCTO
        Cadena.Append("^FT49,678^A0B,34,33^FH\^CI28^FD" & descrip.Trim & "^FS^CI27" & vbLf)
        Select Case TipLabel
            Case 0, 1


                If tipo.Trim = "Unidad" Then
                    ' Un solo precio (y,x,rotacion,tipo de letra(1-7),ancho(1-8),alto(1-9),normal(N) reverse(R)
                    Cadena.Append("A180,250,1,5,2,1,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A180,50,1,4,2,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    'Cadena.Append("A185,640,2,3,1,1,N," & Chr(34) & codigo.Trim & Chr(34) & vbLf)
                End If
                If tipo.Trim = "2 Precios" Then

                    Cadena.Append("LO30,250,160,2" & vbLf)
                    'TERCERA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,470,160,2" & vbLf)

                    Cadena.Append("A150,39,1,4,3,2,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,39,1,3,1,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    Cadena.Append("A150,255,1,4,3,2,N," & Chr(34) & precio2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,255,1,3,1,1,N," & Chr(34) & "POR " & precio3.Trim & " UNDS." & Chr(34) & vbLf)
                    Cadena.Append("A150,475,1,4,3,2,N," & Chr(34) & cant2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,475,1,3,1,1,N," & Chr(34) & "POR " & cant3.Trim & " UNDS." & Chr(34) & vbLf)
                End If
                If tipo.Trim = "3 Precios" Then
                    'SEGUNDA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("^FT216,638^A0B,23,23^FH\^CI28^FD" & "P.V.P POR UNIDAD" & "^FS^CI27" & vbLf)
                    Cadena.Append("^FT154,623^A0B,23,23^FH\^CI28^FD" & "P.V.P POR TRES" & "^FS^CI27 " & vbLf)
                    Cadena.Append("^FT95,623^A0B,23,23^FH\^CI28^FD" & "P.VP POR CAJA" & "^FS^CI27" & vbLf)
                    'TERCERA LINEA VERTICAL (y,x,largo,ancho)

                    Cadena.Append("^FT97,420^A0B,45,46^FH\^CI28^FD" & precio1.Trim & "^FS^CI27" & vbLf)
                    Cadena.Append("^FT163,420^A0B,45,46^FH\^CI28^FD" & precio2.Trim & " ^FS^CI27" & vbLf)
                    Cadena.Append("^FT228,420^A0B,45,46^FH\^CI28^FD" & cant2.Trim & "^FS^CI27" & vbLf)
                    Cadena.Append("^BY1,3,50^FT158,234^BCB,,Y,N" & vbLf)
                    Cadena.Append("^FH\^FD" & codigobarra.Trim & "^FS" & vbLf)
                End If
                '46 CARACTERES
                'Cadena.Append("^BY2,3,68^FT21,133^BCN,,Y,N" & vbLf)
                'Cadena.Append("^FH\^FD>;1234656555>65^FS" & vbLf)
                'Cadena.Append("^FO7,172^GB698,0,1^FS" & vbLf)
                'Cadena.Append("^FT220,188^A0N,17,20^FH\^CI28^FD" & Chr(34) & "         " & My.Settings.Almacen & "               " & Chr(34) & "^FS^CI27" & vbLf)
                'Cadena.Append("A50,33,1,3,1,1,R," & Chr(34) & "                " & My.Settings.Almacen & "               " & Chr(34) & vbLf)
        End Select

        'Cadena.Append("^PQ" & copias & ",0,1,Y" & vbLf)
        Cadena.Append("FE" & vbLf)
        Cadena.Append("P1" & vbLf)
        Cadena.Append("^XZ" & vbLf)

        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)

    End Sub


    Private Sub Imprimir_Precio(ByVal codigo As String, ByVal descrip As String, ByVal precio1 As String, ByVal precio2 As String, ByVal precio3 As String, ByVal cant2 As String, ByVal cant3 As String, ByVal tipo As String)
        Dim Cadena As New StringBuilder
        precio3 = 3

        Cadena.Append("N" & vbLf)
        Cadena.Append("q280" & vbLf)
        Cadena.Append("Q512,B24+0" & vbLf)
        Cadena.Append("S2" & vbLf)
        Cadena.Append("D8" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("TTh:m" & vbLf)
        Cadena.Append("TDy2.mn.dd" & vbLf)
        ' NOMBRE DEL PRODUCTO
        Cadena.Append("A235,39,1,4,2,1,N," & Chr(34) & descrip.Trim & Chr(34) & vbLf)
        'Cadena.Append("A235,39,1,4,2,1,N," & Chr(34) & descrip.Trim & Chr(34) & vbLf)
        'PRIMERA LINEA VERTICAL
        Cadena.Append("LO30,26,210,2" & vbLf)
        Select Case TipLabel
            Case 0, 1
                'PRIMERA LINEA HORIZONTAL
                Cadena.Append("LO240,26,2,656" & vbLf)

                'SEGUNDA LINEA HORIZONTAL
                Cadena.Append("LO190,26,2,656" & vbLf)

                'TERCERA LINEA HORIZONTAL
                Cadena.Append("LO30,26,2,656" & vbLf)

                'TERCERA LINEA VERTICAL
                Cadena.Append("LO30,679,210,2" & vbLf)

                If tipo.Trim = "Unidad" Then
                    ' Un solo precio (y,x,rotacion,tipo de letra(1-7),ancho(1-8),alto(1-9),normal(N) reverse(R)
                    Cadena.Append("A180,250,1,5,2,1,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A180,50,1,4,2,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    'Cadena.Append("A185,640,2,3,1,1,N," & Chr(34) & codigo.Trim & Chr(34) & vbLf)
                End If
                If tipo.Trim = "2 Precios" Then

                    'SEGUNDA LINEA VERTICAL (y,x,largo,ancho)
                    'Cadena.Append("LO30,360,160,2" & vbLf)


                    'Cadena.Append("a165,39,1,5,2,1,n," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    'Cadena.Append("a187,39,1,3,1,1,n," & Chr(34) & "unidad" & Chr(34) & vbLf)
                    'Cadena.Append("a165,370,1,5,2,1,n," & Chr(34) & precio2.Trim & Chr(34) & vbLf)
                    'Cadena.Append("a187,370,1,3,1,1,n," & Chr(34) & "por " & cant2.Trim & " unidades" & Chr(34) & vbLf)

                    Cadena.Append("LO30,250,160,2" & vbLf)
                    'TERCERA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,470,160,2" & vbLf)

                    Cadena.Append("A150,39,1,4,3,2,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,39,1,3,1,1,N," & Chr(34) & "POR UNA UNIDAD" & Chr(34) & vbLf)
                    Cadena.Append("A150,255,1,4,3,2,N," & Chr(34) & precio2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,255,1,3,1,1,N," & Chr(34) & "POR " & precio3.Trim & " UNDS." & Chr(34) & vbLf)
                    Cadena.Append("A150,475,1,4,3,2,N," & Chr(34) & cant2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,475,1,3,1,1,N," & Chr(34) & "POR " & cant3.Trim & " CAJA." & Chr(34) & vbLf)
                End If
                If tipo.Trim = "3 Precios" Then
                    'SEGUNDA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,250,160,2" & vbLf)
                    'TERCERA LINEA VERTICAL (y,x,largo,ancho)
                    Cadena.Append("LO30,470,160,2" & vbLf)

                    Cadena.Append("A150,39,1,4,3,2,N," & Chr(34) & precio1.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,39,1,3,1,1,N," & Chr(34) & "UNIDAD" & Chr(34) & vbLf)
                    Cadena.Append("A150,255,1,4,3,2,N," & Chr(34) & precio2.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,255,1,3,1,1,N," & Chr(34) & "POR " & cant2.Trim & " UNDS." & Chr(34) & vbLf)
                    Cadena.Append("A150,475,1,4,3,2,N," & Chr(34) & precio3.Trim & Chr(34) & vbLf)
                    Cadena.Append("A187,475,1,3,1,1,N," & Chr(34) & "POR " & cant3.Trim & " UNDS." & Chr(34) & vbLf)
                End If
                '46 CARACTERES
                Cadena.Append("A50,33,1,3,1,1,R," & Chr(34) & "         " & My.Settings.Almacen & "               " & Chr(34) & vbLf)
                'Cadena.Append("A50,33,1,3,1,1,R," & Chr(34) & "                " & My.Settings.Almacen & "               " & Chr(34) & vbLf)
        End Select

        Cadena.Append("FE" & vbLf)
        Cadena.Append("P1" & vbLf)

        ' You need a string to send.
        ' Open the printer dialog box, and then allow the user to select a printer.

        'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Cadena.ToString)
        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)

    End Sub
    Private Sub Imprimir_Precio_Prendas(ByVal codigo As String, ByVal descrip1 As String, ByVal descrip2 As String, ByVal descrip3 As String, ByVal precio As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("N" & vbLf)
        Cadena.Append("q800" & vbLf)
        Cadena.Append("Q240,B24+0" & vbLf)
        Cadena.Append("S2" & vbLf)
        Cadena.Append("D8" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("TTh:m" & vbLf)
        Cadena.Append("TDy2.mn.dd" & vbLf)
        ' h,v
        Cadena.Append("A550,200,2,4,1,1,N," & Chr(34) & descrip1.Trim & Chr(34) & vbLf)
        Cadena.Append("A550,170,2,4,1,1,N," & Chr(34) & descrip2.Trim & Chr(34) & vbLf)
        Cadena.Append("A550,140,2,4,1,1,N," & Chr(34) & descrip3.Trim & Chr(34) & vbLf)
        Cadena.Append("B550,100,2,1,2,4,50,B," & Chr(34) & codigo.Trim & Chr(34) & vbLf)
        Cadena.Append("A150,65,1,4,2,1,N," & Chr(34) & precio.Trim & Chr(34) & vbLf)
        'Cadena.Append("LO587,10,115,202" & vbLf)
        Cadena.Append("LO175,10,5,202" & vbLf)
        '13 caracteres
        Cadena.Append("A700,10,1,4,1,1,R," & Chr(34) & "   Abastos   " & Chr(34) & vbLf)
        Cadena.Append("A670,10,1,4,1,1,R," & Chr(34) & "   Cleymer   " & Chr(34) & vbLf)
        'DerAncho,HastaAlto,Grozor,IzqAncho,DesdeAlto
        Cadena.Append("X80,215,5,705,5" & vbLf)
        Cadena.Append("FE" & vbLf)
        Cadena.Append("P1" & vbLf)

        ' You need a string to send.
        ' Open the printer dialog box, and then allow the user to select a printer.

        'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Cadena.ToString)
        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)

    End Sub
    Private Sub Imprimir_Codbar(ByVal descrip1 As String, ByVal descrip2 As String, ByVal codbar As String, ByVal precio As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("N" & vbLf)
        Cadena.Append("q320" & vbLf)
        Cadena.Append("Q128,B24+0" & vbLf)
        Cadena.Append("S2" & vbLf)
        Cadena.Append("D8" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("TTh:m" & vbLf)
        Cadena.Append("TDy2.mn.dd" & vbLf)
        Cadena.Append("A1,15,0,2,1,1,N," & Chr(34) & My.Settings.Almacen & Chr(34) & vbLf)
        Cadena.Append("A1,35,0,3,1,1,N," & Chr(34) & "----------------------" & Chr(34) & vbLf)
        Cadena.Append("A10,50,0,1,1,1,N," & Chr(34) & descrip1.Trim & Chr(34) & vbLf)
        'Cadena.Append("A10,65,0,1,1,1,N," & Chr(34) & descrip2.Trim & Chr(34) & vbLf)
        Cadena.Append("B10,80,0,1,2,4,50,B," & Chr(34) & codbar.Trim & Chr(34) & vbLf)
        Cadena.Append("A10,165,0,1,1,2,B," & Chr(34) & descrip2.Trim & Chr(34) & vbLf)
        Cadena.Append("A220,80,0,3,1,3,N," & Chr(34) & "$ " & precio.Trim & Chr(34) & vbLf)
        Cadena.Append("FE" & vbLf)
        Cadena.Append("P1" & vbLf)
        ' You need a string to send.
        ' Open the printer dialog box, and then allow the user to select a printer.

        'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Cadena.ToString)
        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)
    End Sub

    Private Sub Imprimir_CodbarSinPrecio(ByVal descrip1 As String, ByVal descrip2 As String, ByVal codbar As String, ByVal precio As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("N" & vbLf)
        Cadena.Append("q320" & vbLf)
        Cadena.Append("Q128,B24+0" & vbLf)
        Cadena.Append("S2" & vbLf)
        Cadena.Append("D8" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("TTh:m" & vbLf)
        Cadena.Append("TDy2.mn.dd" & vbLf)
        Cadena.Append("A1,15,0,3,1,1,N," & Chr(34) & My.Settings.Almacen & Chr(34) & vbLf)
        Cadena.Append("A1,35,0,3,1,1,N," & Chr(34) & "----------------------" & Chr(34) & vbLf)
        Cadena.Append("A10,50,0,1,1,1,N," & Chr(34) & descrip1.Trim & Chr(34) & vbLf)
        'Cadena.Append("A10,65,0,1,1,1,N," & Chr(34) & descrip2.Trim & Chr(34) & vbLf)
        Cadena.Append("B10,80,0,1,2,4,50,B," & Chr(34) & codbar.Trim & Chr(34) & vbLf)
        Cadena.Append("A10,165,0,1,1,2,B," & Chr(34) & descrip2.Trim & Chr(34) & vbLf)
        Cadena.Append("A220,80,0,3,1,3,N," & Chr(34) & "" & Chr(34) & vbLf)
        Cadena.Append("FE" & vbLf)
        Cadena.Append("P1" & vbLf)
        ' You need a string to send.
        ' Open the printer dialog box, and then allow the user to select a printer.

        'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Cadena.ToString)
        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)
    End Sub

    Private Sub Imprimir_EtiquetaPequena(ByVal descrip1 As String, ByVal descrip2 As String, ByVal codbar As String, ByVal precio As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("I8,A,001" & vbLf)

        Cadena.Append("Q104,024" & vbLf)
        Cadena.Append("q831" & vbLf)
        Cadena.Append("rN" & vbLf)
        Cadena.Append("S3" & vbLf)
        Cadena.Append("D15" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("JF" & vbLf)
        Cadena.Append("O" & vbLf)
        Cadena.Append("R287,0" & vbLf)
        Cadena.Append("f100" & vbLf)
        Cadena.Append("N" & vbLf)
        ' Cadena.Append("GW6,4,13,45,à          ÿ€          ÿ€          ÿ            ÿÿÿÿÿÿÿÿÿÿÿðÿÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿøÿÿÿÿÿÿÿÿÿÿðÿÿÿÿÿÿÿÿÿÿðÿÿÿÿÿÿÿÿÿÿÿÀÿ            ÿ€          ÿà          ÿü          ÿ" & vbLf)
        Cadena.Append("B247,49,2,1,2,6,20,B," & Chr(34) & codbar & Chr(34) & vbLf)
        ' Cadena.Append("A90,35,2,2,1,1,N," & Chr(34) & precio & Chr(34) & vbLf)
        Cadena.Append("A244,69,2,2,1,1,N," & Chr(34) & descrip2 & Chr(34) & vbLf)
        Cadena.Append("A244,88,2,2,1,1,N," & Chr(34) & descrip1 & Chr(34) & vbLf)
        Cadena.Append("P1" & vbLf)

        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)
    End Sub

    Private Sub Imprimir_EtiquetaAmarillaSinCosto(ByVal descrip1 As String, ByVal descrip2 As String, ByVal codbar As String, ByVal precio As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("I8,A,001" & vbLf)

        Cadena.Append("Q719,B024+000" & vbLf)
        Cadena.Append("q831" & vbLf)
        Cadena.Append("rN" & vbLf)
        Cadena.Append("S4" & vbLf)
        Cadena.Append("D10" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("JF" & vbLf)
        Cadena.Append("OD" & vbLf)
        Cadena.Append("R295,0" & vbLf)
        Cadena.Append("f100" & vbLf)
        Cadena.Append("N" & vbLf)

        Cadena.Append("A197,26,1,2,2,2,N," & Chr(34) & descrip1 & Chr(34) & vbLf)
        Cadena.Append("X12,7,4,234,712" & vbLf)

        Cadena.Append("A36,10,1,3,1,1,R," & Chr(34) & My.Settings.Almacen & Chr(34) & vbLf)

        Cadena.Append("A154,27,1,2,2,2,N," & Chr(34) & descrip2 & Chr(34) & vbLf)

        Cadena.Append("B125,412,1,1,2,6,34,B," & Chr(34) & codbar & Chr(34) & vbLf)
        Cadena.Append("P1" & vbLf)

        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)
    End Sub

    Private Sub Imprimir_EtiquetaAmarillaConPrecio(ByVal descrip1 As String, ByVal descrip2 As String, ByVal codbar As String, ByVal precio As String)
        Dim Cadena As New StringBuilder
        Cadena.Append("I8,A,001" & vbLf)

        Cadena.Append("Q719,B024+000" & vbLf)
        Cadena.Append("q831" & vbLf)
        Cadena.Append("rN" & vbLf)
        Cadena.Append("S3" & vbLf)
        Cadena.Append("D7" & vbLf)
        Cadena.Append("ZT" & vbLf)
        Cadena.Append("JF" & vbLf)
        Cadena.Append("O" & vbLf)
        Cadena.Append("R295,0" & vbLf)
        Cadena.Append("f100" & vbLf)
        Cadena.Append("N" & vbLf)

        Cadena.Append("A38,693,3,2,2,2,N," & Chr(34) & descrip1 & Chr(34) & vbLf)
        Cadena.Append("A129,651,3,5,1,1,N," & Chr(34) & precio & Chr(34) & vbLf)
        Cadena.Append("A76,695,3,2,2,2,N," & Chr(34) & descrip2 & Chr(34) & vbLf)

        Cadena.Append("B126,358,3,3,1,3,38,B," & Chr(34) & codbar & Chr(34) & vbLf)
        'Cadena.Append("A174,359,3,3,1,1,N," & Chr(34) & codbar & Chr(34) & vbLf)
        Cadena.Append("A197,709,3,3,1,1,R," & Chr(34) & My.Settings.Almacen & Chr(34) & vbLf)

        Cadena.Append("LO115,2,5,716" & vbLf)
        Cadena.Append("LO12,1,5,716" & vbLf)
        Cadena.Append("LO219,2,4,716" & vbLf)

        Cadena.Append("P1" & vbLf)

        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)
    End Sub
    Private Sub ChkSelec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelec.CheckedChanged
        If ChkSelec.Checked = True Then
            Seleccionar_Todo()
        Else
            Quitar_Seleccion_Todo()
        End If
    End Sub
    Sub Seleccionar_Todo()
        For i As Integer = 0 To Dtg_Etiqueta.RowCount - 1 Step 1
            Dim chkCell As DataGridViewCheckBoxCell = Me.Dtg_Etiqueta.Rows(i).Cells("Selecionar")
            chkCell.Value = True
        Next
    End Sub
    Sub Quitar_Seleccion_Todo()
        For i As Integer = 0 To Dtg_Etiqueta.RowCount - 1 Step 1
            Dim chkCell As DataGridViewCheckBoxCell = Me.Dtg_Etiqueta.Rows(i).Cells("Selecionar")
            chkCell.Value = False
        Next
    End Sub
    Private Sub Btn_Cantidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Dtg_Etiqueta.Rows.Count > 0 Then
            Dim cant As Decimal
            Dim entrada As String
            Dim producto As String
            Dim codigo As String
            producto = Dtg_Etiqueta.CurrentRow.Cells(3).Value.ToString().Trim
            codigo = Dtg_Etiqueta.CurrentRow.Cells(0).Value.ToString().Trim
            Do
                entrada = InputBox("Ingrese la cantidad", producto)
            Loop Until IsNumeric(entrada)
            cant = CDec(entrada)
            If cant > -1 Then
                Dim cantidades As New DataTable
                cantidades = Mi_Query.Datos_Etiqueta_Cantidad(codigo)
                If cantidades.Rows.Count > 0 Then
                    Mi_Query.Act_cant_etiqueta(codigo, cant)
                Else
                    Mi_Query.Ins_cant_etiqueta(codigo, cant)
                End If
                Mi_Query.Act_cant_etiqueta_item(codigo, cant)
                Datos()
            Else
                Exit Sub
            End If
        Else
            MsgBox("Debe seleccionar un producto", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Btn_Calibrar_Click(sender As Object, e As EventArgs) Handles Btn_Calibrar.Click
        Dim Cadena As New StringBuilder
        ''FUNCIONA PARA CALIBRAR
        Cadena.Append("~JC" & vbLf)
        RawPrinterHelper.SendStringToPrinter(Cmb_Impresoras.Text, Cadena.ToString)

    End Sub



    Private Sub Valida_Grid()
        For i As Integer = 0 To Dtg_Etiqueta.RowCount - 1
            'para validar ceros
            If EnCero(Dtg_Etiqueta.Rows(i).Cells(8).Value.ToString().Trim) = True Then Dtg_Etiqueta.Rows(i).Cells(8).Style.BackColor = Color.LightCyan
        Next
    End Sub
    Private Function EnCero(ByVal celda As String) As Boolean
        If celda = "0" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
