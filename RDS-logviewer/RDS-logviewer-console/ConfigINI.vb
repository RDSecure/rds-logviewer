Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class ConfigINI
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        btn_GuardarDatos.DialogResult = DialogResult.OK

        cancel.DialogResult = DialogResult.Cancel
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub load_data()
        Try
            Dim asd As String = ReadINI(CONFIG_FILE, "BD", "usedb")

            If asd.Equals("true") Then
                chk_usedb.Checked = True
            Else
                chk_usedb.Checked = False
            End If

            txt_servidor.Text = ReadINI(CONFIG_FILE, "BD", "dbhost")
            txt_bd.Text = ReadINI(CONFIG_FILE, "BD", "dbschema")
            txt_puerto.Text = ReadINI(CONFIG_FILE, "BD", "dbport")
            txt_usuario.Text = ReadINI(CONFIG_FILE, "BD", "dbuser")
            txt_password.Text = ReadINI(CONFIG_FILE, "BD", "dbpassword")


        Catch exp As Exception
            MsgBox(exp.ToString)
        End Try
    End Sub

    Private Sub btn_verDatos_Click(sender As Object, e As EventArgs) Handles btn_verDatos.Click

        load_data()
    End Sub


    Private Sub btn_GuardarDatos_Click(sender As Object, e As EventArgs) Handles btn_GuardarDatos.Click
        Try

            If chk_usedb.Checked Then
                WriteINI(CONFIG_FILE, "BD", "usedb", "true")
            Else
                WriteINI(CONFIG_FILE, "BD", "usedb", "false")

            End If

            WriteINI(CONFIG_FILE, "BD", "dbhost", txt_servidor.Text)
            WriteINI(CONFIG_FILE, "BD", "dbschema", txt_bd.Text)
            WriteINI(CONFIG_FILE, "BD", "dbport", txt_puerto.Text)
            WriteINI(CONFIG_FILE, "BD", "dbuser", txt_usuario.Text)
            WriteINI(CONFIG_FILE, "BD", "dbpassword", txt_password.Text)

            MsgBox("Datos Guardados correctamente")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub chk_usedb_CheckedChanged(sender As Object, e As EventArgs) Handles chk_usedb.CheckedChanged

        If chk_usedb.Checked Then
            habilitar_componentes(True)
        Else
            habilitar_componentes(False)
        End If

    End Sub

    Private Sub ConfigINI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_GuardarDatos.Enabled = True
        habilitar_componentes(False)

        load_data()

    End Sub
    Sub habilitar_componentes(ByVal bool As Boolean)
        btn_verDatos.Enabled = bool
        txt_puerto.Enabled = bool
        txt_servidor.Enabled = bool
        txt_bd.Enabled = bool
        txt_usuario.Enabled = bool
        txt_password.Enabled = bool
    End Sub

    Private Sub btn_testDB_Connection_Click(sender As Object, e As EventArgs) Handles btn_testDB_Connection.Click
        Dim test As Boolean

        Dim sqlConn As New MySqlConnection()

        If DBConnectionStatus() Then
            MsgBox("Super")
        Else
            MsgBox(":(")
        End If




    End Sub
End Class