Imports System.Runtime.InteropServices
Imports System.Text

Public Class ConfigINI
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Button3.DialogResult = DialogResult.OK

        cancel.DialogResult = DialogResult.Cancel
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    Public Shared Function ReadINI(ByVal File As String, ByVal Section As String, ByVal Key As String) As String
        Dim sb As New StringBuilder(500)
        GetPrivateProfileString(Section, Key, "", sb, sb.Capacity, File)
        Return sb.ToString
    End Function

    Public Shared Sub WriteINI(ByVal File As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, File)
    End Sub
    'ruta donde se guardara la configuracion del archivo ini'
    Dim CONFIG_FILE = Environment.CurrentDirectory & "\config.ini"



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            servidor.Text = ConfigINI.ReadINI(CONFIG_FILE, "BD", "dbhost")
            bd.Text = ConfigINI.ReadINI(CONFIG_FILE, "BD", "dbschema")
            puerto.Text = ConfigINI.ReadINI(CONFIG_FILE, "BD", "dbport")
            usuario.Text = ConfigINI.ReadINI(CONFIG_FILE, "BD", "dbuser")
            password.Text = ConfigINI.ReadINI(CONFIG_FILE, "BD", "dbpassword")


        Catch exp As Exception
            MsgBox(exp.ToString)
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ConfigINI.WriteINI(CONFIG_FILE, "BD", "usedb", "true")
            ConfigINI.WriteINI(CONFIG_FILE, "Application", "console", "true")
            ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbhost", servidor.Text)
            ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbschema", bd.Text)
            ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbport", puerto.Text)
            ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbuser", usuario.Text)
            ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbpassword", password.Text)



            MsgBox("Datos Guardados correctamente")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then
            Button3.Enabled = True
            Button1.Enabled = True
            puerto.Enabled = True
            servidor.Enabled = True
            bd.Enabled = True
            usuario.Enabled = True
            password.Enabled = True
        Else
            Button3.Enabled = False
            Button1.Enabled = False
            puerto.Enabled = False
            servidor.Enabled = False
            bd.Enabled = False
            usuario.Enabled = False
            password.Enabled = False
        End If

    End Sub

    Private Sub ConfigINI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Enabled = False
        Button1.Enabled = False
        puerto.Enabled = False
        servidor.Enabled = False
        bd.Enabled = False
        usuario.Enabled = False
        password.Enabled = False


        ConfigINI.WriteINI(CONFIG_FILE, "BD", "usedb", "true")
        ConfigINI.WriteINI(CONFIG_FILE, "Application", "console", "true")
        ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbhost", "192.168.1.56")
        ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbschema", "rdslogs")
        ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbport", "339")
        ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbuser", "rdsuser")
        ConfigINI.WriteINI(CONFIG_FILE, "BD", "dbpassword", "{strong_password}")


    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click

    End Sub
End Class