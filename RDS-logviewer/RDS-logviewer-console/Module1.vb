Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Module Module1
    'Dim xml As String = String.Empty
    Public CONSOLEMODE As Boolean = False       ' Manda los mensajes a la salida de la consola
    Public GUIMODE As Boolean = True            ' Habilita el modo gráfico de la aplicación: TODO
    Public DEBUGMODE As Boolean = False         ' Habilita el modo de debug dónde manda los mensajes
    Public CONFIG_FILE As String = ""           ' El archivo de configucación de la aplicación 
    Public USESQL As Boolean = False            ' Guarda la salida de los datos en una base de datos
    Public dbhost As String = ""                ' la dirección de la base de datos
    Public dbusername As String = ""            ' el usuario de la base de datos
    Public dbpassword As String = ""            ' contraseña del usuario de la base de datos
    Public dbschema As String = ""              ' e nombre del esqueme
    Public dbport As String = "389"             ' el puerto del servicio de la base de datos
    Public dbotherOptions As String = ""        ' Otras opciones para la base de datos
    Public READ_EV As String = ""               ' Archivo XML de los eventos 
    Public RUN_AS_SERVICE As Boolean = False
    Public ConnectionStr As String = ""

    Dim INI As ConfigINI



    Sub readEventViewer()
        Try
            Dim query As New EventLogQuery("HOB WebSecureProxy", PathType.LogName)
            Dim watcher As New EventLogWatcher(query)

            AddHandler watcher.EventRecordWritten, AddressOf watcher_EventRecordWritten
            watcher.Enabled = True
            Console.ReadLine()

        Catch ex As Exception
            Console.WriteLine(ex.Message)

        End Try

    End Sub

    Function DBConnectionStatus() As Boolean
        Try
            Using sqlConn As New MySqlConnection(ConnectionStr)
                sqlConn.Open()
                Return (sqlConn.State = ConnectionState.Open)
            End Using
        Catch e1 As MySqlException
            Console.WriteLine(e1.Message)
            Return False
        Catch e2 As Exception
            Console.WriteLine(e2.Message)
            Return False
        End Try
    End Function




    Sub main()
        If getArguments(Environment.GetCommandLineArgs()) Then
            If GUIMODE Then
                CONFIG_FILE = Environment.CurrentDirectory & "\config.ini"

                If File.Exists(CONFIG_FILE) = False Then
                    If CreateIniFiles() = False Then
                        Exit Sub
                    End If
                    MsgBox("Se ha creado el archivo de configuracion")

                End If
                If File.Exists(CONFIG_FILE) Then
                    INI = New ConfigINI()
                    INI.ShowDialog()
                    If INI.DialogResult = DialogResult.OK Then
                        readEventViewer()
                    End If
                End If
            End If



            If USESQL Then
                ConnectionStr = "Server=" & dbhost & "; Port= " & dbport & "; User Id=" & dbusername & "; Password=" & dbpassword & "; Database=" & dbschema
                If DBConnectionStatus() = False Then
                    Console.WriteLine("Verifique la conexión a la base de datos")
                    Exit Sub
                End If
            End If
            If String.IsNullOrEmpty(READ_EV) = False Then
                If File.Exists(READ_EV) Then
                    readEventFromFile(READ_EV)
                Else
                    Console.WriteLine("El archivo " & READ_EV & " no existe")
                End If
            Else
                readEventViewer()
            End If

        End If
    End Sub


    ''' <summary>
    ''' read the events from a XML file
    ''' </summary>
    ''' <param name="xml_fileName">the XML file with complete path</param>
    Sub readEventFromFile(xml_fileName As String)
        ' https://www.vbforums.com/showthread.php?824713-RESOLVED-Loop-through-XML-File

        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim fs As New FileStream(xml_fileName, FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("Event")

        Dim header As String = "<Event xmlns='http://schemas.microsoft.com/win/2004/08/events/event'>"
        Dim tail As String = "</Event>"

        For i = 0 To xmlnode.Count - 1
            Dim xml1 As String = "<System>" & xmlnode(i).ChildNodes.Item(0).InnerXml.Replace(" xmlns=""http://schemas.microsoft.com/win/2004/08/events/event""", "") & "</System>"
            Dim xml2 As String = "<EventData>" & xmlnode(i).ChildNodes.Item(1).InnerXml.Replace(" xmlns=""http://schemas.microsoft.com/win/2004/08/events/event""", "") & "</EventData>"
            Dim xml_end As String = header & xml1 & xml2 & tail
            GenerateEvents(xml_end)
            If DEBUGMODE Then
                System.Threading.Thread.Sleep(10)
            End If

        Next

        fs.Close()
        fs = Nothing
        xmlnode = Nothing
        xmldoc = Nothing


    End Sub

    Sub _myHandler(ByVal sender As Object, ByVal args As ConsoleCancelEventArgs)
        Console.WriteLine(vbLf & "The read operation has been interrupted.")
        Console.WriteLine($"  Key pressed: {args.SpecialKey}")
        Console.WriteLine($"  Cancel property: {args.Cancel}")
        End
        Console.WriteLine($"  Cancel property: {args.Cancel}")
        Console.WriteLine("The read operation will resume..." & vbLf)
    End Sub

    Public Sub watcher_EventRecordWritten(sender As Object, e As EventRecordWrittenEventArgs)
        GenerateEvents(e.EventRecord.ToXml())
    End Sub

    Sub GenerateEvents(xmlcontent As String)
        ' cambiamos la comilla a comillas dobles
        ' TODO: Reparar las comillas, al pareccer tanto la sencilla como las dobles son legales, si es asüi
        ' ahorraríamos valiosísimos milisegundos
        xmlcontent = xmlcontent.Replace("'", """")
        ' eliminaos el xmlns de xml porque me estaba dando problemas
        xmlcontent = xmlcontent.Replace(" xmlns=""http://schemas.microsoft.com/win/2004/08/events/event""", "")

        Dim Keywords, Computer, Data, Provider, SystemTime, OriginCode, severely_key, code, SNO, INETA, message, group, userid, protocol, socket As String
        Dim EventID, Level, EventRecordID As Integer
        Dim tmp As String = String.Empty

        Data = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/EventData", "Data")

        If Data.Equals(Nothing) Then
            Exit Sub
        End If

        ' el el mensaje DATA contiene la cadena "connection ended - client ended with error" ignoramoes el mensaje.HWSPS06
        ' este mensaje no es relevante para el análisis y causa mucho ruido. Y no tiene caso gastar recursos de 
        ' memoria y CPU para analizar el XML
        If Data.Contains("HWSPR006I") Or
           Data.Contains("HWSPR005I") Or
           Data.Contains("HWSPR010I") Or
           Data.Contains("HWSPR001I") Or
           Data.Contains("HWSPR009I") Or
           Data.Contains("HWSPS003I") Or
           Data.Contains("HWSPR004I") Or
           Data.Contains("HWSPS014W") Or
           Data.Contains("HWSPS004I") Or
           Data.Contains("HWSPATE038W") Or
           Data.Contains("HIWSE048E") Then
            'colorize("HWSPATE038W - DROPED", ConsoleColor.Red)
            Exit Sub
        End If

        EventID = Integer.Parse(rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "EventID"))
        Level = Integer.Parse(rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "Level"))
        EventRecordID = Integer.Parse(rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "EventRecordID"))
        'Dim TimeCreatedf As Date

        Keywords = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "Keywords")
        Computer = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "Computer")
        Provider = rdslib.xmlhelper.GetContinents(xmlcontent, "//System//Provider", "Name")
        SystemTime = rdslib.xmlhelper.GetContinents(xmlcontent, "//System//TimeCreated", "SystemTime")
        Dim TimeCreatedf As Date = Convert.ToDateTime(SystemTime)



        If Data.Contains("HWSP") Then
            If Data.Contains("Administration Access") Then
                OriginCode = "AdminA"
            ElseIf Data.Contains("User Portal") Then
                OriginCode = "UserP"
            Else
                OriginCode = "Statics"
            End If
            If Data.Contains("SNO") And Data.Contains("INETA") Then
                Dim posicion As Integer = Data.IndexOf(" ")
                code = Data.Substring(0, posicion)
                severely_key = Right(code, 1).ToUpper

                tmp = Data.Substring(posicion)

                ' eliminamos el primer espacio en caso de ue haya uno
                If (tmp.StartsWith(" ")) Then
                    tmp = tmp.Substring(1)
                End If

                posicion = tmp.IndexOf("SNO")
                tmp = tmp.Substring(posicion)

                posicion = tmp.IndexOf(" ")
                SNO = tmp.Substring(0, posicion)
                SNO = SNO.Replace("SNO=", "")

                tmp = tmp.Substring(posicion)

                ' eliminamos el primer espacio en caso de ue haya uno
                If (tmp.StartsWith(" ")) Then
                    tmp = tmp.Substring(1)
                End If
                posicion = tmp.IndexOf(" ")
                INETA = tmp.Substring(0, posicion)
                INETA = INETA.Replace("INETA=", "")

                message = tmp.Substring(posicion)
                If message.StartsWith(" ") Then
                    message = message.Substring(1)
                End If


                If Data.Contains("HOB-RDP-EXT1") Then
                    protocol = "HOB-RDP-EXT1"
                    socket = Data.Substring(Data.LastIndexOf(" ") + 1)
                Else
                    protocol = ""
                    socket = ""
                End If

                If Data.Contains("set session owner group=") Then
                    group = message.Replace("set session owner group=", "")
                    Dim posision As Integer = group.IndexOf(" ")
                    group = group.Remove(posision)
                    userid = message.Substring(message.LastIndexOf(" ") + 8)
                    userid = userid.Substring(0, userid.Length - 1)
                Else
                    group = ""
                    userid = ""
                End If

                If USESQL Then
                    mio(SystemTime, TimeCreatedf, EventID, Level, EventRecordID, Computer, OriginCode, severely_key, code, SNO, INETA, message, Data, group, userid, protocol, socket)
                End If
            Else
                'HWSPR002I Report Performance / elapsed CPU time 34 sec / virt-stor 61GB / I-O 153 1649KB.
                Dim posicion As Integer = Data.IndexOf(" ")
                code = Data.Substring(0, posicion)
                severely_key = Right(code, 1).ToUpper

                If severely_key.Equals(vbLf) Then
                    severely_key = "I"
                End If

                message = Data.Substring(posicion)
                If USESQL Then
                    mio(SystemTime, TimeCreatedf, EventID, Level, EventRecordID, Computer, OriginCode, severely_key, code, "", "", message, Data, group, userid, protocol, socket)
                End If
            End If
        Else
            Dim posicion As Integer = Data.IndexOf(" ")
            code = Data.Substring(0, posicion)
            message = Data.Substring(posicion)
            If USESQL Then
                mio(SystemTime, TimeCreatedf, EventID, Level, EventRecordID, Computer, "Statics", "I", code, "", "", message, Data, group, userid, protocol, socket)
            End If
        End If

        If CONSOLEMODE Then
            Dim color As ConsoleColor
            If Data.Contains("GATE=Administration Access") Then
                color = ConsoleColor.Yellow
            ElseIf Data.Contains("GATE=User Portal") Then
                color = ConsoleColor.Blue
            Else
                color = ConsoleColor.Gray
            End If

            colorize("==================== Eventviewer headre with record ID " & EventRecordID & " ====================", ConsoleColor.Gray)
            colorizeAtomic("█ ", color)
            colorize(
                EventRecordID & vbTab & ": TimeCreated: " & vbTab & "Computer: " & Computer & vbTab &
                 "Date:  " & TimeCreatedf.ToString("yyyy-MM-dd HH:mm:ss"), color)
            If Data.Contains("logged on") Then
                ' si la cadena contiene logged on lo coloreamos de verde
                colorize("Data   :  " & Data, ConsoleColor.Green)
            ElseIf Data.Contains("ldap authentication failed") Then
                ' si la cadena contiene ldap authentication failed on lo coloreamos de rojo
                colorize("Data   : " & Data, ConsoleColor.DarkMagenta)
            ElseIf Data.ToLower.Contains("ERROR") Then
                colorize("Error  : " & Data, ConsoleColor.DarkCyan)
            ElseIf Data.Contains("Error") Or Data.Contains("error") Then
                colorize("Error  : " & Data, ConsoleColor.DarkRed)
            Else
                colorize("Data   : " & Data, ConsoleColor.Gray)
            End If
        End If
    End Sub

    Function testConn() As Boolean
        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Sub mio(TimeCreated As String, TimeCreatedf As DateTime, EventID As Integer, LEVEL As Integer, EventRecordID As Integer, Computer As String,
            Origin_code As String, severely_key As String, code As String, SNO As String, INETA As String, message As String, rdsContent As String,
            grouprds As String, userid As String, protocol As String, socket As String)

        Dim conn As New MySqlConnection
        Dim com As New MySqlCommand
        conn.ConnectionString = ConnectionStr

        Dim MysqlConn = New MySqlConnection
        Try
            conn.Open()
            com.Connection = conn
            com.CommandText = "INSERT INTO rdslogs (TimeCreated, TimeCreatedf, EventID, `Level`, EventRecordID, Computer, Origin_code, severely_key, code, SNO, INETA, message, rdsContent, grouprds, userid, protocol, socket) VALUES " &
                "(@vTimeCreated, @vTimeCreatedf, @vEventID, @vLevel, @vEventRecordID, @vComputer, @vOrigin_code, @vseverely_key, @vcode, @vSNO, @vINETA, @vmessage, @vrdsContent, @vgrouprds, @vuserid, @vprotocol, @vsocket);"

            com.Parameters.Add("@vTimeCreated", MySqlDbType.VarString)
            com.Parameters.Add("@vTimeCreatedf", MySqlDbType.DateTime)
            com.Parameters.Add("@vEventID", MySqlDbType.Int16)
            com.Parameters.Add("@vLevel", MySqlDbType.Int16)
            com.Parameters.Add("@vEventRecordID", MySqlDbType.Int16)
            com.Parameters.Add("@vComputer", MySqlDbType.VarString)
            com.Parameters.Add("@vOrigin_code", MySqlDbType.VarString)
            com.Parameters.Add("@vseverely_key", MySqlDbType.VarString)
            com.Parameters.Add("@vcode", MySqlDbType.VarString)
            com.Parameters.Add("@vSNO", MySqlDbType.VarString)
            com.Parameters.Add("@vINETA", MySqlDbType.VarString)
            com.Parameters.Add("@vmessage", MySqlDbType.VarString)
            com.Parameters.Add("@vrdsContent", MySqlDbType.VarString)
            com.Parameters.Add("@vgrouprds", MySqlDbType.VarString)
            com.Parameters.Add("@vuserid", MySqlDbType.VarString)
            com.Parameters.Add("@vprotocol", MySqlDbType.VarString)
            com.Parameters.Add("@vsocket", MySqlDbType.VarString)
            com.Prepare()
            '' Agregamos los valores a los parametros antes dichos

            com.Parameters("@vTimeCreated").Value = TimeCreated
            com.Parameters("@vTimeCreatedf").Value = TimeCreatedf
            com.Parameters("@vEventID").Value = EventID
            com.Parameters("@vLevel").Value = LEVEL
            com.Parameters("@vEventRecordID").Value = EventRecordID
            com.Parameters("@vComputer").Value = Computer
            com.Parameters("@vOrigin_code").Value = Origin_code
            com.Parameters("@vseverely_key").Value = severely_key
            com.Parameters("@vcode").Value = code
            com.Parameters("@vSNO").Value = SNO
            com.Parameters("@vINETA").Value = INETA
            com.Parameters("@vmessage").Value = message
            com.Parameters("@vrdsContent").Value = rdsContent
            com.Parameters("@vgrouprds").Value = grouprds
            com.Parameters("@vuserid").Value = userid
            com.Parameters("@vprotocol").Value = protocol
            com.Parameters("@vsocket").Value = socket


            com.ExecuteNonQuery()


        Catch ex As MySqlException
            Dim text As String = com.CommandText
            Console.WriteLine("===== Query ======")
            Console.WriteLine(text)
            Console.WriteLine("===== Error ======")
            Console.WriteLine(ex)
            Console.WriteLine("===== SQL Error ======")
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine("===== ERW Error ======")
            Console.WriteLine(rdsContent)
            Console.WriteLine("")
        Finally
            MysqlConn.Close()
            MysqlConn.Dispose()
        End Try
    End Sub

    Sub colorize(mensaje As String, color As ConsoleColor)
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = color
        Console.WriteLine(mensaje)
        Console.ResetColor()
    End Sub
    Sub colorizeAtomic(mensaje As String, color As ConsoleColor)
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = color
        Console.Write(mensaje)
        Console.ResetColor()
    End Sub

#Region "Testing"


#End Region
End Module
