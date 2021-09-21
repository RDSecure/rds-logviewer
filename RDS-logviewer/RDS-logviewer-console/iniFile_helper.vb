Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO

Module iniFile_helper

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    Public Function ReadINI(ByVal File As String, ByVal Section As String, ByVal Key As String) As String
        Dim sb As New StringBuilder(500)
        GetPrivateProfileString(Section, Key, "", sb, sb.Capacity, File)
        Return sb.ToString
    End Function

    Public Sub WriteINI(ByVal File As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, File)
    End Sub

    Function CreateTemplate() As Boolean
        Try
            WriteINI(CONFIG_FILE, "BD", "usedb", "true")
            ' WriteINI(CONFIG_FILE, "Application", "console", "true")
            WriteINI(CONFIG_FILE, "BD", "dbhost", "{IP/name}")
            WriteINI(CONFIG_FILE, "BD", "dbschema", "{database name}")
            WriteINI(CONFIG_FILE, "BD", "dbport", "339")
            WriteINI(CONFIG_FILE, "BD", "dbuser", "{database user}")
            WriteINI(CONFIG_FILE, "BD", "dbpassword", "{strong_password}")
            WriteINI(CONFIG_FILE, "Application", "console", "false")
            Return True
        Catch ex As Exception
            ' TODO Aqui van los logs
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function
    Function CreateIniFiles() As Boolean
        Try
            File.Create(CONFIG_FILE).Dispose()
            If CreateTemplate() = False Then
                Return False
            End If
            Return True
        Catch ex As Exception
            ' TODO Aqui van los logs
            Console.WriteLine(ex.Message)
            Return False
        End Try


    End Function
End Module
