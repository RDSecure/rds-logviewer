<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigINI
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigINI))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.usuario = New System.Windows.Forms.TextBox()
        Me.puerto = New System.Windows.Forms.TextBox()
        Me.bd = New System.Windows.Forms.TextBox()
        Me.servidor = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.BlueViolet
        Me.Label11.Location = New System.Drawing.Point(616, 153)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(186, 2)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.BlueViolet
        Me.Label10.Location = New System.Drawing.Point(616, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 2)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.BlueViolet
        Me.Label9.Location = New System.Drawing.Point(266, 271)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(186, 2)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.BlueViolet
        Me.Label8.Location = New System.Drawing.Point(266, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(186, 2)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Label8"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.BlueViolet
        Me.Label6.Location = New System.Drawing.Point(266, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 2)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Label6"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.AliceBlue
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(593, 392)
        Me.Button3.Name = "Button3"
        Me.Button3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button3.Size = New System.Drawing.Size(209, 48)
        Me.Button3.TabIndex = 33
        Me.Button3.Text = "GUARDAR DATOS"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(853, 46)
        Me.Panel1.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS Reference Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Location = New System.Drawing.Point(232, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(406, 29)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Configuracion de la aplicacion "
        '
        'password
        '
        Me.password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.password.Location = New System.Drawing.Point(269, 253)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password.Size = New System.Drawing.Size(183, 15)
        Me.password.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 24)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Contraseña:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(509, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 24)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(509, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 24)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Puerto:"
        '
        'usuario
        '
        Me.usuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.usuario.Location = New System.Drawing.Point(619, 196)
        Me.usuario.Name = "usuario"
        Me.usuario.Size = New System.Drawing.Size(183, 15)
        Me.usuario.TabIndex = 27
        '
        'puerto
        '
        Me.puerto.BackColor = System.Drawing.Color.White
        Me.puerto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.puerto.Location = New System.Drawing.Point(619, 137)
        Me.puerto.Name = "puerto"
        Me.puerto.Size = New System.Drawing.Size(183, 15)
        Me.puerto.TabIndex = 26
        '
        'bd
        '
        Me.bd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bd.Location = New System.Drawing.Point(269, 196)
        Me.bd.Name = "bd"
        Me.bd.Size = New System.Drawing.Size(183, 15)
        Me.bd.TabIndex = 25
        '
        'servidor
        '
        Me.servidor.BackColor = System.Drawing.Color.White
        Me.servidor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.servidor.Location = New System.Drawing.Point(269, 140)
        Me.servidor.Name = "servidor"
        Me.servidor.Size = New System.Drawing.Size(183, 15)
        Me.servidor.TabIndex = 24
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.AliceBlue
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(132, 396)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button1.Size = New System.Drawing.Size(173, 48)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "VER DATOS"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(248, 24)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Nombre de la abse de datos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 24)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "IP del Servidor:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(16, 75)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(201, 24)
        Me.CheckBox1.TabIndex = 39
        Me.CheckBox1.Text = "Usar base de datos "
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ConfigINI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(853, 482)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.usuario)
        Me.Controls.Add(Me.puerto)
        Me.Controls.Add(Me.bd)
        Me.Controls.Add(Me.servidor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ConfigINI"
        Me.Text = "ConfigINI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents password As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents usuario As System.Windows.Forms.TextBox
    Friend WithEvents puerto As System.Windows.Forms.TextBox
    Friend WithEvents bd As System.Windows.Forms.TextBox
    Friend WithEvents servidor As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
