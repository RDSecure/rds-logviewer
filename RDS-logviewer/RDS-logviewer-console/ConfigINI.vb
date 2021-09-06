Imports System.Runtime.InteropServices
Imports System.Text

Public Class ConfigINI
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
    Dim ruta As String = "\config.ini"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            servidor.Text = ConfigINI.ReadINI(ruta, "Connection", "dbhost")
            bd.Text = ConfigINI.ReadINI(ruta, "Connection", "dbschema")
            puerto.Text = ConfigINI.ReadINI(ruta, "Connection", "dbport")
            usuario.Text = ConfigINI.ReadINI(ruta, "Connection", "dbuser")
            password.Text = ConfigINI.ReadINI(ruta, "Connection", "dbpassword")
        Catch exp As Exception
            MsgBox(exp.ToString)
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ConfigINI.WriteINI(ruta, "Connection", "usedb", "true")
            ConfigINI.WriteINI(ruta, "Application", "console", "true")
            ConfigINI.WriteINI(ruta, "Connection", "dbhost", servidor.Text)
            ConfigINI.WriteINI(ruta, "Connection", "dbschema", bd.Text)
            ConfigINI.WriteINI(ruta, "Connection", "dbport", puerto.Text)
            ConfigINI.WriteINI(ruta, "Connection", "dbuser", usuario.Text)
            ConfigINI.WriteINI(ruta, "Connection", "dbpassword", password.Text)


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
    End Sub
End Class