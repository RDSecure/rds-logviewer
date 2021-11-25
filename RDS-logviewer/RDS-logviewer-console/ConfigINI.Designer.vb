<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfigINI
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigINI))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_GuardarDatos = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_puerto = New System.Windows.Forms.TextBox()
        Me.txt_bd = New System.Windows.Forms.TextBox()
        Me.txt_servidor = New System.Windows.Forms.TextBox()
        Me.btn_verDatos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_host = New System.Windows.Forms.Label()
        Me.chk_usedb = New System.Windows.Forms.CheckBox()
        Me.cancel = New System.Windows.Forms.Button()
        Me.btn_testDB_Connection = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.BlueViolet
        Me.Label11.Location = New System.Drawing.Point(462, 124)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 2)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.BlueViolet
        Me.Label10.Location = New System.Drawing.Point(462, 172)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 2)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.BlueViolet
        Me.Label9.Location = New System.Drawing.Point(200, 220)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 2)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.BlueViolet
        Me.Label8.Location = New System.Drawing.Point(200, 172)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 2)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Label8"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.BlueViolet
        Me.Label6.Location = New System.Drawing.Point(200, 125)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 2)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Label6"
        '
        'btn_GuardarDatos
        '
        Me.btn_GuardarDatos.BackColor = System.Drawing.Color.AliceBlue
        Me.btn_GuardarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GuardarDatos.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_GuardarDatos.Image = CType(resources.GetObject("btn_GuardarDatos.Image"), System.Drawing.Image)
        Me.btn_GuardarDatos.Location = New System.Drawing.Point(233, 322)
        Me.btn_GuardarDatos.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_GuardarDatos.Name = "btn_GuardarDatos"
        Me.btn_GuardarDatos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_GuardarDatos.Size = New System.Drawing.Size(157, 39)
        Me.btn_GuardarDatos.TabIndex = 33
        Me.btn_GuardarDatos.Text = "GUARDAR DATOS"
        Me.btn_GuardarDatos.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 37)
        Me.Panel1.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS Reference Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Location = New System.Drawing.Point(174, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(371, 24)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Configuracion de la Base de datos"
        '
        'txt_password
        '
        Me.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_password.Location = New System.Drawing.Point(202, 206)
        Me.txt_password.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(137, 13)
        Me.txt_password.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 204)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Contraseña:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(382, 158)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(382, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Puerto:"
        '
        'txt_usuario
        '
        Me.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_usuario.Location = New System.Drawing.Point(464, 159)
        Me.txt_usuario.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(137, 13)
        Me.txt_usuario.TabIndex = 27
        '
        'txt_puerto
        '
        Me.txt_puerto.BackColor = System.Drawing.Color.White
        Me.txt_puerto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_puerto.Location = New System.Drawing.Point(464, 111)
        Me.txt_puerto.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_puerto.Name = "txt_puerto"
        Me.txt_puerto.Size = New System.Drawing.Size(137, 13)
        Me.txt_puerto.TabIndex = 26
        '
        'txt_bd
        '
        Me.txt_bd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_bd.Location = New System.Drawing.Point(202, 159)
        Me.txt_bd.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_bd.Name = "txt_bd"
        Me.txt_bd.Size = New System.Drawing.Size(137, 13)
        Me.txt_bd.TabIndex = 25
        '
        'txt_servidor
        '
        Me.txt_servidor.BackColor = System.Drawing.Color.White
        Me.txt_servidor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_servidor.Location = New System.Drawing.Point(202, 114)
        Me.txt_servidor.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_servidor.Name = "txt_servidor"
        Me.txt_servidor.Size = New System.Drawing.Size(137, 13)
        Me.txt_servidor.TabIndex = 24
        '
        'btn_verDatos
        '
        Me.btn_verDatos.BackColor = System.Drawing.Color.AliceBlue
        Me.btn_verDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_verDatos.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_verDatos.Image = CType(resources.GetObject("btn_verDatos.Image"), System.Drawing.Image)
        Me.btn_verDatos.Location = New System.Drawing.Point(99, 322)
        Me.btn_verDatos.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_verDatos.Name = "btn_verDatos"
        Me.btn_verDatos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_verDatos.Size = New System.Drawing.Size(130, 39)
        Me.btn_verDatos.TabIndex = 23
        Me.btn_verDatos.Text = "VER DATOS"
        Me.btn_verDatos.UseVisualStyleBackColor = False
        Me.btn_verDatos.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 158)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Base de datos:"
        '
        'lbl_host
        '
        Me.lbl_host.AutoSize = True
        Me.lbl_host.Font = New System.Drawing.Font("Sitka Text", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_host.Location = New System.Drawing.Point(9, 114)
        Me.lbl_host.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_host.Name = "lbl_host"
        Me.lbl_host.Size = New System.Drawing.Size(74, 20)
        Me.lbl_host.TabIndex = 21
        Me.lbl_host.Text = "Servidor:"
        '
        'chk_usedb
        '
        Me.chk_usedb.AutoSize = True
        Me.chk_usedb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_usedb.Location = New System.Drawing.Point(12, 61)
        Me.chk_usedb.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_usedb.Name = "chk_usedb"
        Me.chk_usedb.Size = New System.Drawing.Size(174, 21)
        Me.chk_usedb.TabIndex = 39
        Me.chk_usedb.Text = "Usar base de datos "
        Me.chk_usedb.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel.Location = New System.Drawing.Point(394, 322)
        Me.cancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(157, 39)
        Me.cancel.TabIndex = 60
        Me.cancel.Text = "Button2"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'btn_testDB_Connection
        '
        Me.btn_testDB_Connection.BackColor = System.Drawing.Color.AliceBlue
        Me.btn_testDB_Connection.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_testDB_Connection.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_testDB_Connection.Image = CType(resources.GetObject("btn_testDB_Connection.Image"), System.Drawing.Image)
        Me.btn_testDB_Connection.Location = New System.Drawing.Point(394, 265)
        Me.btn_testDB_Connection.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_testDB_Connection.Name = "btn_testDB_Connection"
        Me.btn_testDB_Connection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_testDB_Connection.Size = New System.Drawing.Size(130, 39)
        Me.btn_testDB_Connection.TabIndex = 61
        Me.btn_testDB_Connection.Text = "Probar conexió a la DB"
        Me.btn_testDB_Connection.UseVisualStyleBackColor = False
        '
        'ConfigINI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CancelButton = Me.cancel
        Me.ClientSize = New System.Drawing.Size(640, 392)
        Me.Controls.Add(Me.btn_testDB_Connection)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.chk_usedb)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_GuardarDatos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.txt_puerto)
        Me.Controls.Add(Me.txt_bd)
        Me.Controls.Add(Me.txt_servidor)
        Me.Controls.Add(Me.btn_verDatos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_host)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfigINI"
        Me.ShowIcon = False
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
    Friend WithEvents btn_GuardarDatos As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents txt_puerto As System.Windows.Forms.TextBox
    Friend WithEvents txt_bd As System.Windows.Forms.TextBox
    Friend WithEvents txt_servidor As System.Windows.Forms.TextBox
    Friend WithEvents btn_verDatos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_host As System.Windows.Forms.Label
    Friend WithEvents chk_usedb As System.Windows.Forms.CheckBox
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents btn_testDB_Connection As System.Windows.Forms.Button
End Class
