Public Class Frm_BuscaProd
    Dim Mi_Query As New LogicaNegocio.Query
    Dim Items As New DataTable
    Dim bloq As Integer
    Private Sub Txt_Producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Producto.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub
    Public Sub FuncKeysModule(ByVal value As Keys)
        Select Case value
            Case Keys.F1
                Rdb_Nombre.Checked = True
                'Case Keys.F2
                '    Rdb_Codigo.Checked = True
            Case Keys.F2
                Rdb_Barra.Checked = True
        End Select
    End Sub
    Private Sub Txt_Producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                Filtrar()
                Valida()
            Case 27
                Me.Close()
        End Select
    End Sub
    Private Sub Txt_Producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Producto.KeyUp
        If Rdb_Barra.Checked = False Then
            Filtrar()
        End If
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Producto.TextChanged
        Txt_Producto.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub Valida()
        If Dtg_Productos.RowCount > 0 Then
            Inserta()
        Else
            MsgBox("Producto no existe")
            Inicializa()
        End If
    End Sub
    Private Sub Filtrar()
        If Rdb_Nombre.Checked = True Then
            Items = Mi_Query.MostrarProductos(Txt_Producto.Text + "%", "", "", bloq, TipLabel)
        End If
        'If Rdb_Codigo.Checked = True Then
        '    Items = Mi_Query.MostrarProductos("", Txt_Producto.Text, "", bloq, TipLabel)
        'End If
        If Rdb_Barra.Checked = True Then
            Items = Mi_Query.MostrarProductos("", "", Txt_Producto.Text, bloq, TipLabel)
        End If
        Dtg_Productos.DataSource = Items
        Dtg_Productos.Refresh()
    End Sub
    Private Sub Frm_BuscaProd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Txt_Producto.Focus()
    End Sub
    Private Sub Frm_BuscaProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializa()
    End Sub
    Private Sub Inicializa()
        'Rdb_Barra.Checked = True
        Txt_Producto.Focus()
        bloq = 0
        Txt_Producto.Text = ""
        Define_Grid()
        mostrar()
    End Sub
    Private Sub Define_Grid()
        Dtg_Productos.AutoGenerateColumns = False
        Dtg_Productos.Columns.Clear()
        Dtg_Productos.Columns.Add("Empresa", "Identificador")
        Dtg_Productos.Columns.Add("codigo", "Código")
        Dtg_Productos.Columns.Add("codigo_barra", "CodBar")
        Dtg_Productos.Columns.Add("descripcion1", "Descripción")
        Dtg_Productos.Columns.Add("pvp1", "Precio1")
        Dtg_Productos.Columns.Add("pvp2", "Precio2")
        Dtg_Productos.Columns.Add("pvp3", "Precio3")
        Dtg_Productos.Columns.Add("cantidaduno", "cantidad")
        Dtg_Productos.Columns(0).DataPropertyName = "Empresa"
        Dtg_Productos.Columns(1).DataPropertyName = "codigo"
        Dtg_Productos.Columns(2).DataPropertyName = "codigo_barra"
        Dtg_Productos.Columns(3).DataPropertyName = "descripcion1"
        Dtg_Productos.Columns(4).DataPropertyName = "pvp1"
        Dtg_Productos.Columns(5).DataPropertyName = "pvp2"
        Dtg_Productos.Columns(6).DataPropertyName = "pvp3"
        Dtg_Productos.Columns(7).DataPropertyName = "cantidaduno"
        Dtg_Productos.Columns(0).Frozen = True
        Dtg_Productos.Columns(1).Frozen = True

        Dtg_Productos.Columns(7).Visible = False

    End Sub


    Private Sub mostrar()
        Txt_Producto.Focus()
        Items = Mi_Query.MostrarProductos("", "%", "", bloq, TipLabel)
        Dtg_Productos.DataSource = Items
        Dtg_Productos.Refresh()
    End Sub
    Private Sub Chk_Bloqueados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Bloqueados.CheckedChanged
        If Chk_Bloqueados.Checked = True Then
            bloq = -1
        Else
            bloq = 0
        End If
        Filtrar()
    End Sub
    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
    Private Sub Rdb_Nombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Nombre.CheckedChanged
        mostrar()
    End Sub
    Private Sub Rdb_Codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar()
    End Sub
    Private Sub Rdb_Barra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Barra.CheckedChanged
        mostrar()
    End Sub
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Inserta_Seleccion()
        Me.Close()
    End Sub
    Private Sub Inserta()

        Mi_Query.Insertar_Item(Dtg_Productos.CurrentRow.Cells(0).Value.ToString(), Dtg_Productos.CurrentRow.Cells(1).Value.ToString(),
                Dtg_Productos.CurrentRow.Cells(2).Value.ToString(), Dtg_Productos.CurrentRow.Cells(3).Value.ToString(), Decimal.Round(Decimal.Parse(Dtg_Productos.CurrentRow.Cells(4).Value.ToString()), 2), Dtg_Productos.CurrentRow.Cells(5).Value.ToString(), Dtg_Productos.CurrentRow.Cells(6).Value.ToString(), Dtg_Productos.CurrentRow.Cells(7).Value.ToString(), ObtenerIP)
        Inicializa()
        Frm_Etiquetas.Datos()
    End Sub
    Private Sub Dtg_Productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtg_Productos.DoubleClick
        Inserta()
    End Sub
    Private Sub Dtg_Productos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtg_Productos.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                Dim MiCol As Integer = 0
                Dim MiFil As Integer = Dtg_Productos.CurrentCell.RowIndex - 1
                If Dtg_Productos.CurrentCell.ColumnIndex < Dtg_Productos.ColumnCount - 1 Then   'Si noSalimos del limite
                    MiCol = Dtg_Productos.CurrentCell.ColumnIndex + 1                           'Siguiente columna
                End If
                If MiFil > -1 Then Dtg_Productos.CurrentCell = Dtg_Productos(MiCol, MiFil) 'Posicionar columna
                Inserta()
        End Select
    End Sub
    Sub Inserta_Seleccion()
        Dim MiCol As Integer = 0
        Dim MiFil As Integer = Dtg_Productos.CurrentCell.RowIndex
        If Dtg_Productos.CurrentCell.ColumnIndex < Dtg_Productos.ColumnCount - 1 Then   'Si noSalimos del limite
            MiCol = Dtg_Productos.CurrentCell.ColumnIndex + 1                           'Siguiente columna
        End If
        If MiFil > -1 Then Dtg_Productos.CurrentCell = Dtg_Productos(MiCol, MiFil) 'Posicionar columna
        Inserta()
    End Sub
End Class
