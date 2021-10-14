<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscaProd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_Producto = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdb_Nombre = New System.Windows.Forms.RadioButton()
        Me.Rdb_Barra = New System.Windows.Forms.RadioButton()
        Me.Dtg_Productos = New System.Windows.Forms.DataGridView()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Chk_Bloqueados = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Dtg_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txt_Producto)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 50)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Txt_Producto
        '
        Me.Txt_Producto.Location = New System.Drawing.Point(6, 16)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.Size = New System.Drawing.Size(312, 20)
        Me.Txt_Producto.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rdb_Nombre)
        Me.GroupBox2.Controls.Add(Me.Rdb_Barra)
        Me.GroupBox2.Location = New System.Drawing.Point(330, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(504, 50)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar por:"
        '
        'Rdb_Nombre
        '
        Me.Rdb_Nombre.AutoSize = True
        Me.Rdb_Nombre.Location = New System.Drawing.Point(139, 17)
        Me.Rdb_Nombre.Name = "Rdb_Nombre"
        Me.Rdb_Nombre.Size = New System.Drawing.Size(81, 17)
        Me.Rdb_Nombre.TabIndex = 2
        Me.Rdb_Nombre.Text = "Descripción"
        Me.Rdb_Nombre.UseVisualStyleBackColor = True
        '
        'Rdb_Barra
        '
        Me.Rdb_Barra.AutoSize = True
        Me.Rdb_Barra.Checked = True
        Me.Rdb_Barra.Location = New System.Drawing.Point(367, 16)
        Me.Rdb_Barra.Name = "Rdb_Barra"
        Me.Rdb_Barra.Size = New System.Drawing.Size(58, 17)
        Me.Rdb_Barra.TabIndex = 1
        Me.Rdb_Barra.TabStop = True
        Me.Rdb_Barra.Text = "Código"
        Me.Rdb_Barra.UseVisualStyleBackColor = True
        '
        'Dtg_Productos
        '
        Me.Dtg_Productos.AllowUserToAddRows = False
        Me.Dtg_Productos.AllowUserToDeleteRows = False
        Me.Dtg_Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dtg_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dtg_Productos.Location = New System.Drawing.Point(6, 57)
        Me.Dtg_Productos.Name = "Dtg_Productos"
        Me.Dtg_Productos.ReadOnly = True
        Me.Dtg_Productos.RowHeadersVisible = False
        Me.Dtg_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dtg_Productos.Size = New System.Drawing.Size(828, 186)
        Me.Dtg_Productos.TabIndex = 2
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Location = New System.Drawing.Point(650, 249)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(82, 28)
        Me.Btn_Aceptar.TabIndex = 4
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(753, 249)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(81, 28)
        Me.Btn_Cancelar.TabIndex = 5
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Chk_Bloqueados
        '
        Me.Chk_Bloqueados.AutoSize = True
        Me.Chk_Bloqueados.Location = New System.Drawing.Point(6, 254)
        Me.Chk_Bloqueados.Name = "Chk_Bloqueados"
        Me.Chk_Bloqueados.Size = New System.Drawing.Size(170, 17)
        Me.Chk_Bloqueados.TabIndex = 6
        Me.Chk_Bloqueados.Text = "Mostrar solamente bloqueados"
        Me.Chk_Bloqueados.UseVisualStyleBackColor = True
        Me.Chk_Bloqueados.Visible = False
        '
        'Frm_BuscaProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 283)
        Me.Controls.Add(Me.Chk_Bloqueados)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Dtg_Productos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BuscaProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Dtg_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Producto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_Nombre As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Barra As System.Windows.Forms.RadioButton
    Friend WithEvents Dtg_Productos As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Chk_Bloqueados As System.Windows.Forms.CheckBox
End Class
