<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Etiquetas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Etiquetas))
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Dtg_Etiqueta = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Btn_Calibrar = New System.Windows.Forms.Button()
        Me.Btn_Quitar = New System.Windows.Forms.Button()
        Me.Btn_Borrar = New System.Windows.Forms.Button()
        Me.Btn_Agregar = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmb_Impresoras = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkSelec = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Tipetiqueta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Lbl_Proveedor = New System.Windows.Forms.Label()
        CType(Me.Dtg_Etiqueta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Salir.Location = New System.Drawing.Point(6, 208)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(84, 42)
        Me.Btn_Salir.TabIndex = 4
        Me.Btn_Salir.Text = "Salir"
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Dtg_Etiqueta
        '
        Me.Dtg_Etiqueta.AllowUserToAddRows = False
        Me.Dtg_Etiqueta.AllowUserToDeleteRows = False
        Me.Dtg_Etiqueta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtg_Etiqueta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dtg_Etiqueta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dtg_Etiqueta.Location = New System.Drawing.Point(6, 19)
        Me.Dtg_Etiqueta.Name = "Dtg_Etiqueta"
        Me.Dtg_Etiqueta.RowHeadersVisible = False
        Me.Dtg_Etiqueta.RowHeadersWidth = 49
        Me.Dtg_Etiqueta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dtg_Etiqueta.Size = New System.Drawing.Size(729, 342)
        Me.Dtg_Etiqueta.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Btn_Calibrar)
        Me.GroupBox2.Controls.Add(Me.Btn_Quitar)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Controls.Add(Me.Btn_Borrar)
        Me.GroupBox2.Controls.Add(Me.Btn_Agregar)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(6, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(99, 416)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Btn_Calibrar
        '
        Me.Btn_Calibrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Calibrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Calibrar.Image = CType(resources.GetObject("Btn_Calibrar.Image"), System.Drawing.Image)
        Me.Btn_Calibrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Calibrar.Location = New System.Drawing.Point(6, 280)
        Me.Btn_Calibrar.Name = "Btn_Calibrar"
        Me.Btn_Calibrar.Size = New System.Drawing.Size(84, 51)
        Me.Btn_Calibrar.TabIndex = 6
        Me.Btn_Calibrar.Text = "Calibrar"
        Me.Btn_Calibrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Btn_Calibrar, "Permite modificar la cantidades relacionadas con precio 2")
        Me.Btn_Calibrar.UseVisualStyleBackColor = True
        '
        'Btn_Quitar
        '
        Me.Btn_Quitar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Quitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Quitar.Image = CType(resources.GetObject("Btn_Quitar.Image"), System.Drawing.Image)
        Me.Btn_Quitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Quitar.Location = New System.Drawing.Point(9, 76)
        Me.Btn_Quitar.Name = "Btn_Quitar"
        Me.Btn_Quitar.Size = New System.Drawing.Size(84, 42)
        Me.Btn_Quitar.TabIndex = 1
        Me.Btn_Quitar.Text = "Quitar"
        Me.Btn_Quitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Quitar.UseVisualStyleBackColor = True
        '
        'Btn_Borrar
        '
        Me.Btn_Borrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Borrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Borrar.Image = CType(resources.GetObject("Btn_Borrar.Image"), System.Drawing.Image)
        Me.Btn_Borrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Borrar.Location = New System.Drawing.Point(9, 136)
        Me.Btn_Borrar.Name = "Btn_Borrar"
        Me.Btn_Borrar.Size = New System.Drawing.Size(84, 42)
        Me.Btn_Borrar.TabIndex = 2
        Me.Btn_Borrar.Text = "Borrar"
        Me.Btn_Borrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Borrar.UseVisualStyleBackColor = True
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Agregar.Image = CType(resources.GetObject("Btn_Agregar.Image"), System.Drawing.Image)
        Me.Btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Agregar.Location = New System.Drawing.Point(9, 19)
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Size = New System.Drawing.Size(84, 42)
        Me.Btn_Agregar.TabIndex = 0
        Me.Btn_Agregar.Text = "Agregar"
        Me.Btn_Agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Agregar.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(6, 368)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(84, 42)
        Me.Btn_Imprimir.TabIndex = 3
        Me.Btn_Imprimir.Text = "Imprimir"
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Cmb_Impresoras)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ChkSelec)
        Me.GroupBox1.Controls.Add(Me.Btn_Imprimir)
        Me.GroupBox1.Controls.Add(Me.Dtg_Etiqueta)
        Me.GroupBox1.Location = New System.Drawing.Point(111, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(745, 416)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Cmb_Impresoras
        '
        Me.Cmb_Impresoras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Impresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Impresoras.FormattingEnabled = True
        Me.Cmb_Impresoras.Location = New System.Drawing.Point(109, 384)
        Me.Cmb_Impresoras.Name = "Cmb_Impresoras"
        Me.Cmb_Impresoras.Size = New System.Drawing.Size(198, 21)
        Me.Cmb_Impresoras.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 368)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Seleccione la impresora ZEBRA "
        '
        'ChkSelec
        '
        Me.ChkSelec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkSelec.AutoSize = True
        Me.ChkSelec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSelec.Location = New System.Drawing.Point(624, 389)
        Me.ChkSelec.Name = "ChkSelec"
        Me.ChkSelec.Size = New System.Drawing.Size(110, 17)
        Me.ChkSelec.TabIndex = 9
        Me.ChkSelec.Text = "Seleccionar Todo"
        Me.ChkSelec.UseVisualStyleBackColor = True
        Me.ChkSelec.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Cmb_Tipetiqueta)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(850, 50)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Etiquetas.My.MySettings.Default, "Almacen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = New System.Drawing.Font("Century Schoolbook", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(386, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(454, 34)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = Global.Etiquetas.My.MySettings.Default.Almacen
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmb_Tipetiqueta
        '
        Me.Cmb_Tipetiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Tipetiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Tipetiqueta.FormattingEnabled = True
        Me.Cmb_Tipetiqueta.Items.AddRange(New Object() {"Etiqueta por producto", "Etiqueta por número de compra", "Código de Barras", "Etiquetas prendas de vestir", "Código de Barras Sin Precio", "Pequeña", "Amarilla sin precio", "Amarilla con precio", "Amarilla Unidad"})
        Me.Cmb_Tipetiqueta.Location = New System.Drawing.Point(105, 15)
        Me.Cmb_Tipetiqueta.Name = "Cmb_Tipetiqueta"
        Me.Cmb_Tipetiqueta.Size = New System.Drawing.Size(265, 24)
        Me.Cmb_Tipetiqueta.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Escoja el tipo -->"
        '
        'Lbl_Proveedor
        '
        Me.Lbl_Proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Proveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lbl_Proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Proveedor.ForeColor = System.Drawing.Color.DimGray
        Me.Lbl_Proveedor.Location = New System.Drawing.Point(12, 68)
        Me.Lbl_Proveedor.Name = "Lbl_Proveedor"
        Me.Lbl_Proveedor.Size = New System.Drawing.Size(834, 20)
        Me.Lbl_Proveedor.TabIndex = 8
        Me.Lbl_Proveedor.Text = "PRODUCTOS"
        Me.Lbl_Proveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_Etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 519)
        Me.Controls.Add(Me.Lbl_Proveedor)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frm_Etiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de etiquetas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dtg_Etiqueta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Dtg_Etiqueta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Borrar As System.Windows.Forms.Button
    Friend WithEvents Btn_Quitar As System.Windows.Forms.Button
    Friend WithEvents Btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Tipetiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Lbl_Proveedor As System.Windows.Forms.Label
    Friend WithEvents ChkSelec As System.Windows.Forms.CheckBox
    Friend WithEvents Cmb_Impresoras As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Calibrar As Button
End Class
