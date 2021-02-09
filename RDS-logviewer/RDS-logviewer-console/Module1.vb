Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports System.Data.Sql
Imports rdslib
Imports System.Net
Imports System

Module Module1
    Dim xml As String = String.Empty
    Dim speed As String = String.Empty
    Dim CONSOLEMODE As Boolean = True
    Dim GUIMODE As Boolean = True
    Dim DEBUGMODE As Boolean = True
    Dim ALLE As Boolean = False ' Envía todos los eventos
    Dim propsFilename As String = String.Empty
    Dim SaveIntoMySQL As Boolean = False

    Sub Main()
        'debugProg()
        setComandLineParameters()
        setVariablesAndConstructors()

        Dim cki As ConsoleKeyInfo

        'Dim clArgs() As String = Environment.GetCommandLineArgs()

        Dim query As New EventLogQuery("HOB WebSecureProxy", PathType.LogName)
        Dim watcher As New EventLogWatcher(query)

        AddHandler watcher.EventRecordWritten, AddressOf watcher_EventRecordWritten
        watcher.Enabled = True

        REM Console.ReadLine()
        Console.Write("Press 'X' to quit, or ")
        Console.WriteLine("CTRL+C to interrupt the read operation:")
        AddHandler Console.CancelKeyPress, AddressOf myHandler
        While True
            ' Start a console read operation. Do not display the input.
            cki = Console.ReadKey(True)

            If cki.Key = ConsoleKey.Enter Then
                Console.WriteLine("")
            Else
                Console.Write(cki.Key.ToString())
            End If

            If cki.Key = ConsoleKey.X Then Exit While
        End While
    End Sub
    Sub myHandler(ByVal sender As Object, ByVal args As ConsoleCancelEventArgs)
        Console.WriteLine(vbLf & "The read operation has been interrupted.")
        Console.WriteLine($"  Key pressed: {args.SpecialKey}")
        Console.WriteLine($"  Cancel property: {args.Cancel}")
        End
        Console.WriteLine($"  Cancel property: {args.Cancel}")
        Console.WriteLine("The read operation will resume..." & vbLf)
    End Sub
    Sub setVariablesAndConstructors()

    End Sub


    Public Sub watcher_EventRecordWritten(sender As Object, e As EventRecordWrittenEventArgs)
        'Console.WriteLine(e.EventRecord.ToXml())s
        'Dim filename As String = "C: \rdsecure\temp\event-" & GenerateGUID() & ".xml"
        GenerateEvents(e.EventRecord.ToXml())
    End Sub

    Sub GenerateEvents(xmlcontent As String)
        ' cambiamos la comilla a comillas dobles
        ' TODO: Reparar las comillas, al pareccer tanto la sencilla como las dobles son legales, si es asüi
        ' ahorraríamos valiosísimos milisegundos
        xmlcontent = xmlcontent.Replace("'", """")
        ' eliminaos el xmlns de xml porque me estaba dando problemas
        xmlcontent = xmlcontent.Replace(" xmlns=""http://schemas.microsoft.com/win/2004/08/events/event""", "")

        Dim Keywords, Computer, Data, Provider, SystemTime, OriginCode, severely_key, code, SNO, INETA, messaje As String
        Dim EventID, Level, EventRecordID As Integer
        Dim tmp As String = String.Empty

        Data = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/EventData", "Data")

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

        'cadenaMensaje = "HWSPS062I GATE=Administration Access SNO=00000262 INETA=::1 display: HAUTHW034W unknown authentication failed for userid=dadmin with error 'cannot find a valid auth method'"
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

                messaje = tmp.Substring(posicion)
                If messaje.StartsWith(" ") Then
                    messaje = messaje.Substring(1)
                End If
                If SaveIntoMySQL Then
                    mio(SystemTime, TimeCreatedf, EventID, Level, EventRecordID, Computer, OriginCode, severely_key, code, SNO, INETA, messaje, Data)
                End If

            Else
                'HWSPR002I Report Performance / elapsed CPU time 34 sec / virt-stor 61GB / I-O 153 1649KB.
                Dim posicion As Integer = Data.IndexOf(" ")
                code = Data.Substring(0, posicion)
                severely_key = Right(code, 1).ToUpper
                messaje = Data.Substring(posicion)
                If SaveIntoMySQL Then
                    mio(SystemTime, TimeCreatedf, EventID, Level, EventRecordID, Computer, OriginCode, severely_key, code, "", "", messaje, Data)
                End If
            End If
        Else
            Dim posicion As Integer = Data.IndexOf(" ")
            code = Data.Substring(0, posicion)
            messaje = Data.Substring(posicion)
            If SaveIntoMySQL Then
                mio(SystemTime, TimeCreatedf, EventID, Level, EventRecordID, Computer, "Statics", "I", code, "", "", messaje, Data)
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
    Sub mio(TimeCreated As String, TimeCreatedf As DateTime, EventID As Integer, LEVEL As Integer, EventRecordID As Integer, Computer As String,
            Origin_code As String, severely_key As String, code As String, SNO As String, INETA As String, messaje As String, rdsContent As String)

        Dim conn As New MySqlConnection
        Dim com As New MySqlCommand
        conn.ConnectionString = "Server=localhost; User Id=root; Password=p123p123; Database=rdsecurelogs"

        Dim MysqlConn = New MySqlConnection
        Try

            conn.Open()
            com.Connection = conn
            com.CommandText = "INSERT INTO rdslogs (TimeCreated, TimeCreatedf, EventID, `Level`, EventRecordID, Computer, Origin_code, severely_key, code, SNO, INETA, messaje, rdsContent) VALUES " &
                "(@vTimeCreated, @vTimeCreatedf, @vEventID, @vLevel, @vEventRecordID, @vComputer, @vOrigin_code, @vseverely_key, @vcode, @vSNO, @vINETA, @vmessaje, @vrdsContent);"

            'com.CommandText = "INSERT INTO rdslogs (TimeCreated, TimeCreatedf, EventID, `Level`, EventRecordID, Computer, Origin_code, severely_key, code, SNO, INETA, messaje, rdsContent) VALUES " &
            '   "(@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9, @v10, @v11, @v12, @v13);"


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
            com.Parameters.Add("@vmessaje", MySqlDbType.VarString)
            com.Parameters.Add("@vrdsContent", MySqlDbType.VarString)
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
            com.Parameters("@vmessaje").Value = messaje
            com.Parameters("@vrdsContent").Value = rdsContent
            com.ExecuteNonQuery()
        Catch ex As MySqlException

            Dim text As String = com.CommandText
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

    Sub mio2(TimeCreated As String, TimeCreatedf As DateTime, EventID As Integer, LEVEL As Integer, EventRecordID As Integer, Computer As String,
            Origin_code As String, severely_key As String, code As String, SNO As String, INETA As String, messaje As String, rdsContent As String)

        Dim conn As New MySqlConnection
        Dim com As New MySqlCommand
        conn.ConnectionString = "Server=localhost; User Id=root; Password=p123p123; Database=rdsecurelogs"

        Dim MysqlConn = New MySqlConnection
        Try
            conn.Open()
            com.Connection = conn

            com.CommandText = "INSERT INTO rdslogs (TimeCreated, TimeCreatedf, EventID, `Level`, EventRecordID, Computer, Origin_code, severely_key, code, SNO, INETA, messaje, rdsContent) VALUES " &
                "(@vTimeCreated, @vTimeCreatedf, @vEventID, @vLevel, @vEventRecordID, @vComputer, @vOrigin_code, @vseverely_key, @vcode, @vSNO, @vINETA, @vmessaje, @vrdsContent);"

            'com.CommandText = "INSERT INTO rdslogs (TimeCreated, TimeCreatedf, EventID, `Level`, EventRecordID, Computer, Origin_code, severely_key, code, SNO, INETA, messaje, rdsContent) VALUES " &
            '   "(@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9, @v10, @v11, @v12, @v13);"


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
            com.Parameters.Add("@vmessaje", MySqlDbType.VarString)
            com.Parameters.Add("@vrdsContent", MySqlDbType.VarString)
            com.Prepare()
            '' Agregamos los valores a los parametros antes dichos

            com.Parameters("@vTimeCreated").Value = TimeCreated
            com.Parameters("@vTimeCreatedf").Value = TimeCreatedf.ToString("yyyy-MM-dd HH:mm:ss")
            com.Parameters("@vEventID").Value = EventID
            com.Parameters("@vLevel").Value = LEVEL
            com.Parameters("@vEventRecordID").Value = EventRecordID
            com.Parameters("@vComputer").Value = Computer
            com.Parameters("@vOrigin_code").Value = Origin_code
            com.Parameters("@vseverely_key").Value = severely_key
            com.Parameters("@vcode").Value = code
            com.Parameters("@vSNO").Value = SNO
            com.Parameters("@vINETA").Value = INETA
            com.Parameters("@vmessaje").Value = messaje
            com.Parameters("@vrdsContent").Value = rdsContent

            com.ExecuteNonQuery()



        Catch ex As MySqlException

            Dim text As String = com.CommandText

            Console.WriteLine("===== Error ======")
            Console.WriteLine(ex)
            Console.WriteLine("===== SQL Error ======")
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine("===== ERW Error ======")
            Console.WriteLine(com.CommandText)
            Console.WriteLine("")

        Finally
            MysqlConn.Close()
            MysqlConn.Dispose()

        End Try



    End Sub

    Sub GenerateEvents2(xmlcontent As String)
        ' cambiamos la comilla a comillas dobles
        ' TODO: Reparar las comillas, al pareccer tanto la sencilla como las dobles son legales, si es asüi
        ' ahorraríamos valiosísimos milisegundos
        xmlcontent = xmlcontent.Replace("'", """")
        ' eliminaos el xmlns de xml porque me estaba dando problemas
        xmlcontent = xmlcontent.Replace(" xmlns=""http://schemas.microsoft.com/win/2004/08/events/event""", "")
        Dim sqlquery As String = ""
        Dim EventID, Keywords, Computer, Data, Provider, SystemTime, EventRecordID, Level As String
        Dim TimeCreatedf As Date

        Data = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/EventData", "Data")

        If (Data.Contains("HWSPR004I") = False) Then
            'If (Data.Contains("connection ended - client ended with error") = False) Then
            '
            ' el el mensaje DATA contiene la cadena "connection ended - client ended with error" ignoramoes el mensaje.
            ' este mensaje no es relevante para el análisis y causa mucho ruido. Y no tiene caso gastar recursos de 
            ' memoria y CPU para analizar el XML
            EventID = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "EventID")
            Keywords = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "Keywords")
            Computer = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "Computer")
            EventRecordID = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "EventRecordID")
            Level = rdslib.xmlhelper.getXML_Element_fromXML(xmlcontent, "/Event/System", "Level")

            Provider = rdslib.xmlhelper.GetContinents(xmlcontent, "//System//Provider", "Name")
            SystemTime = rdslib.xmlhelper.GetContinents(xmlcontent, "//System//TimeCreated", "SystemTime")

            TimeCreatedf = Convert.ToDateTime(SystemTime)

            Console.WriteLine(TimeCreatedf.ToString("yyyy-MM-dd HH:mm:ss"))
            Console.WriteLine(TimeCreatedf.ToString())

            If CONSOLEMODE Then
                colorize("====================CONTENT " & EventRecordID & " ====================", ConsoleColor.Magenta)
                colorize(xmlcontent & vbNewLine, ConsoleColor.DarkGray)
                colorize("Provider     : " & Provider, ConsoleColor.Yellow)
                colorize("TimeCreated  : " & SystemTime, ConsoleColor.Yellow)
                colorize("EventID      : " & EventID, ConsoleColor.Yellow)
                colorize("Level        : " & Level, ConsoleColor.Yellow)
                colorize("Keywords     : " & Keywords, ConsoleColor.Yellow)
                colorize("EventRecordID: " & EventRecordID, ConsoleColor.Yellow)
                colorize("Computer     : " & Computer, ConsoleColor.Yellow)
                colorize("====================HOB Content messaje " & EventRecordID & " ====================", ConsoleColor.Magenta)

                If Data.Contains("logged on") Then
                    ' si la cadena contiene logged on lo coloreamos de verde
                    colorize("Data         : " & Data, ConsoleColor.Green)
                ElseIf Data.Contains("ldap authentication failed") Then
                    ' si la cadena contiene ldap authentication failed on lo coloreamos de rojo
                    colorize("Data         : " & Data, ConsoleColor.Red)
                ElseIf Data.Contains("SSL") Then
                    ' si la cadena contiene ldap authentication failed on lo coloreamos de rojo
                    colorize("Data         : " & Data, ConsoleColor.Blue)
                ElseIf Data.Contains("HOB") Then

                Else
                    colorize("Data         : " & Data, ConsoleColor.Gray)
                    'set session owner group
                    'logged on
                    '
                    '
                    'connection ended - client ended with error
                End If
            End If
        End If
    End Sub

    Sub debugProg()
        Dim filename As String = "C:\rdsecure\temp\event-1b286456-0731-41b9-bbb2-6329bf39405e.xml"
        'Dim xmlcontent As String = e.EventRecord.ToXml().Replace("'", """")
        'crearArchivo(filename, xmlcontent)

        Dim xmldoc As New XmlDocument
        xmldoc.Load(filename)
        Dim xmlcontent = xmldoc.InnerXml

        GenerateEvents(xmlcontent)
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
    Sub setComandLineParameters()
        ' Get the values of the command line in an array
        ' Index  Discription
        ' 0      Full path of executing prograsm with program name
        ' 1      First switch in command in your example -t
        ' 2      First value in command in your example text1
        ' 3      Second switch in command in your example -s
        ' 4      Second value in command in your example text2
        Dim clArgs() As String = Environment.GetCommandLineArgs()
        ' Hold the command line values
        Dim config As String = String.Empty
        Dim user As String = String.Empty
        Dim Console As Boolean = True
        ' Test to see if two switchs and two values were passed in
        ' if yes parse the array

        If clArgs.Length > 1 Then
            For i As Integer = 1 To clArgs.Length - 1

                If (clArgs(i) = "-c") Or (clArgs(i).Contains("--config")) Then
                    config = clArgs(i + 1)

                    If String.IsNullOrEmpty(config) Then
                        config = "default.cfg"
                    End If
                ElseIf (clArgs(i).Contains("--console")) Then
                    Console = clArgs(i + 1)
                ElseIf (clArgs(i) = "-u") Or (clArgs(i).Contains("--user")) Then
                    user = clArgs(i + 1)
                End If
            Next
        Else
            cons2()
        End If
    End Sub

    Sub configWizard()

        Dim db_host As String
        Dim db_user As String
        Dim db_user_password As String
        Dim db_schema As String

        Console.WriteLine("Se creó el archivo default.cfg")
        Console.Write("Servidor de la base de datos: ")
        db_host = Console.Read

        Console.Write("Usuario de la base de datos: ")
        db_user = Console.Read

        Console.Write("Contraseña del usuario de la base de datos: ")
        db_user_password = Console.Read

        Console.Write("Esquema: ")
        db_schema = Console.Read

    End Sub
    Sub cons2()
        Console.WriteLine("EventLog2db")
        Console.WriteLine("")
        Console.WriteLine("No se ha establedico un archivo de configuración en la linea de comandos")
        Console.WriteLine("¿Quiere ejecutar el programa solo como lectura de logs?")
        Console.WriteLine("No se guardarán los cambios en ninguna base de datos.")

        Console.Write("(S)i / (N)o: ")

        Dim response As ConsoleKey
        response = Console.ReadKey(False).Key

        If response = ConsoleKey.Y Then


        End If
        If response = ConsoleKey.N Then
            End
        End If


        Console.WriteLine("")
    End Sub
    Sub usage()
        Console.WriteLine("EventLog2db (OPTIONS)")
        Console.WriteLine("=============================")
        Console.WriteLine("-c" & vbTab & "--config" & vbTab & "Ruta para el archivo de configuracion")
        Console.WriteLine("-u" & vbTab & "--user" & vbTab & "Database username")
        Console.WriteLine("-p" & vbTab & "--password" & vbTab & "Database username password")
        Console.WriteLine("-db" & vbTab & "--database" & vbTab & "Database")
        Console.WriteLine("EventLog2db")
    End Sub

#End Region
End Module
