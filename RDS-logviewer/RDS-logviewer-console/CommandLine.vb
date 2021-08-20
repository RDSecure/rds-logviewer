Module CommandLine
    Function getArguments(argumentos() As String) As Boolean
        If argumentos.Length > 1 Then
            For i As Integer = 1 To argumentos.Length - 1

                If (argumentos(i).Equals("--config")) Then
                    Try
                        CONFIG_FILE = argumentos(i + 1)
                        If (CONFIG_FILE.StartsWith("--")) Then
                            CONFIG_FILE = Environment.CurrentDirectory & "\default.cfg"
                        End If
                    Catch ex As Exception
                        CONFIG_FILE = Environment.CurrentDirectory & "\default.cfg"
                    End Try
                ElseIf argumentos(i).Equals("--help") Then
                    help()
                    Return False
                ElseIf argumentos(i).Equals("--console") Then
                    CONSOLEMODE = True
                ElseIf argumentos(i).Equals("--service") Then
                    RUN_AS_SERVICE = True
                ElseIf argumentos(i).Equals("--gui") Then
                    GUIMODE = True
                ElseIf argumentos(i).Equals("--debug") Then
                    DEBUGMODE = True
                ElseIf argumentos(i).Equals("--usedb") Then
                    USESQL = True
                ElseIf (argumentos(i).Equals("--dbhost")) Then
                    Try
                        dbhost = argumentos(i + 1)
                        If (dbhost.StartsWith("--")) Then
                            db_help("--db_host")
                        End If
                    Catch ex As Exception
                        db_help("--db_host")
                    End Try
                ElseIf (argumentos(i).Equals("--dbport")) Then
                    Try
                        dbport = argumentos(i + 1)
                        If (dbhost.StartsWith("--")) Then
                            dbport = "389"
                        End If
                    Catch ex As Exception
                        dbport = "389"
                    End Try
                ElseIf (argumentos(i).Equals("--dbschema")) Then
                    Try
                        dbschema = argumentos(i + 1)
                        If (dbschema.StartsWith("--")) Then
                            db_help("--dbschema")
                        End If
                    Catch ex As Exception
                        db_help("--dbschema")
                    End Try
                ElseIf (argumentos(i).Equals("--dbusername")) Then
                    Try
                        dbusername = argumentos(i + 1)
                        If (dbusername.StartsWith("--")) Then
                            db_help("--dbusername")
                        End If
                    Catch ex As Exception
                        db_help("--dbusername")
                    End Try
                ElseIf (argumentos(i).Equals("--dbpassword")) Then
                    Try
                        dbpassword = argumentos(i + 1)
                        If (dbpassword.StartsWith("--")) Then
                            db_help("--dbpassword")
                        End If
                    Catch ex As Exception
                        db_help("--dbpassword")
                    End Try
                ElseIf (argumentos(i).Equals("--dbotherOptions")) Then
                    Try
                        dbotherOptions = argumentos(i + 1)
                        If (dbotherOptions.StartsWith("--")) Then
                            db_help("--dbotherOptions")
                        End If
                    Catch ex As Exception
                        db_help("--dbotherOptions")
                    End Try
                ElseIf (argumentos(i).Equals("--eventviewer")) Then
                    Try
                        READ_EV = argumentos(i + 1)
                        If READ_EV.StartsWith("--") Then
                            Console.WriteLine("El argumento --eventviewer requiere un valor, por ejemplo:")
                            Console.WriteLine(" --eventviewer C:\ruta\archivo_eventviewer.xml")
                            Return False
                        End If
                    Catch ex As Exception
                        Console.WriteLine("El argumento --eventviewer requiere un valor, por ejemplo:")
                        Console.WriteLine(" --eventviewer C:\ruta\archivo_eventviewer.xml")
                        Return False
                    End Try
                End If
            Next
            If (check_db_parameters() = False) Then
                Return False
            End If
            If DEBUGMODE Then
                muestra_variables(argumentos)
            End If
        Else ' no hay argumentos en la linea de comandos
            help()
        End If
        Return True
    End Function



    Sub db_help(ByVal argument As String)
        Console.WriteLine("El argumento " & argument & " requiere un valor, por ejemplo:")
        Select Case argument
            Case "--db_host"
                Console.WriteLine(" --db_host localhost")
            Case "--dbport"
                Console.WriteLine(" --db_port 3306")
            Case "--dbschema"
                Console.WriteLine(" --dbschema rdslogs")
            Case "--dbusername"
                Console.WriteLine(" --dbuser rds_user")
            Case "--dbpassword"
                Console.WriteLine(" --dbpassword password")
            Case "--dbotherOptions"
                Console.WriteLine(" --dbotherOptions opciones mysql")

        End Select
    End Sub
    Sub help()
        Console.WriteLine("Forma de uso:")
        Console.WriteLine("  rdslogviewer {comandos}")
        Console.WriteLine("Comandos")
        Console.WriteLine(" --config              Especifica un archivo de configuración por defecto,")
        Console.WriteLine("                       dónde se podrán definir valores por default para")
        Console.WriteLine("                       conexiones recurrentes.")
        Console.WriteLine(" --console             Ejecuta el programa en modo consola.")
        Console.WriteLine(" --gui                 Ejecuta el programa en forma gráfica (no implementado)")
        Console.WriteLine(" --eservice            Ejecuta la aplicación en modo servicio")
        Console.WriteLine("")
        Console.WriteLine("=====================================================================================================")
        Console.WriteLine("                              OPCIONES DE BASE DE DATOS")
        Console.WriteLine("=====================================================================================================")
        Console.WriteLine(" --usedb               Indica que almacenaremos los datos en una base de datos.")
        Console.WriteLine("                       Esto es útil si se requiere enviar la información a una")
        Console.WriteLine("                       DB diferente o de pruebas.")
        Console.WriteLine(" --dbhost String       Dirección del servidor de la base de datos (requiere --usedb)")
        Console.WriteLine(" --dbport Integer      Puerto del servidor de la base de datos (requiere --usedb)")
        Console.WriteLine(" --dbschema String     Base de datos/Schema de rdslog (requiere --usedb)")
        Console.WriteLine(" --dbuser String       Usuario de la base de datos (requiere --usedb)")
        Console.WriteLine(" --dbpassword String   Contraseña del usuario de la base de datos (requiere --usedb)")
        Console.WriteLine("")
        Console.WriteLine("=====================================================================================================")
        Console.WriteLine("                                 OPCIONES DE MANEJO DE EVENT VIEWER")
        Console.WriteLine("=====================================================================================================")
        Console.WriteLine(" --read_ev String      Lee el archivo xml del event viewer")
        Console.WriteLine("")
        Console.WriteLine("========================================TODO==========================================================")
        Console.WriteLine(" --install             Instala el servicio de Windows")
        Console.WriteLine(" --uninstall           Desinstala el servicio de Windows ")
        Console.WriteLine("=====================================================================================================")
        Console.WriteLine(" --help                Ayuda")
        Console.WriteLine("")
    End Sub

    Sub muestra_variables(ByVal commandLineArgumentsos() As String)

        Console.WriteLine("===== Comprobación de Variables ======")
        Console.WriteLine("Línea de comandos: " & commandLineArgumentsos.ToString)
        For a As Integer = 0 To (commandLineArgumentsos.Length - 1)
            Console.WriteLine("Argumento[" & a & "]:" & commandLineArgumentsos(a))
        Next
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("===== CONTROL DE LA APLICACIÓN =======")
        Console.WriteLine("CONSOLEMODE: " & CONSOLEMODE)
        Console.WriteLine("GUIMODE: " & GUIMODE)
        Console.WriteLine("DEBUGMODE: " & DEBUGMODE)
        Console.WriteLine("CONFIG_FILE: " & CONFIG_FILE)
        Console.WriteLine("RUN_AS_SERVICE: " & RUN_AS_SERVICE)
        Console.WriteLine("")
        Console.WriteLine("===== MANEJO DEL EVENTVIEWERR =========")
        Console.WriteLine("READ_EV: " & READ_EV)
        Console.WriteLine("===== MANEJO DE LA BASE DE DATOS ======")
        Console.WriteLine("")
        Console.WriteLine("USESQL: " & USESQL)
        Console.WriteLine("dbusername: " & dbusername)
        Console.WriteLine("dbpassword: " & dbpassword)
        Console.WriteLine("db_username: " & dbusername)
        Console.WriteLine("dbschema: " & dbschema)
        Console.WriteLine("dbhost: " & dbhost)
        Console.WriteLine("db_username: " & dbusername)
        Console.WriteLine("dbport: " & dbport)
        Console.WriteLine("dbotherOptions: " & dbotherOptions)
    End Sub

    Function check_db_parameters() As Boolean
        Dim result As Boolean = True
        If (USESQL) Then
            If (String.IsNullOrEmpty(dbhost)) Then
                Console.WriteLine("Si se utiliza el argumento --usedb el parámetro --dbhost es necesario")
                result = False
            ElseIf (String.IsNullOrEmpty(dbusername)) Then
                Console.WriteLine("Si se utiliza el argumento --usedb el parámetro --dbusername es necesario")
                result = False
            ElseIf (String.IsNullOrEmpty(dbpassword)) Then
                Console.WriteLine("Si se utiliza el argumento --usedb el parámetro --dbpassword es necesario")
                result = False
            ElseIf (String.IsNullOrEmpty(dbschema)) Then
                Console.WriteLine("Si se utiliza el argumento --usedb el parámetro --dbschema es necesario")
                result = False
            End If
        Else
            result = True
        End If
        Return result
    End Function
End Module
