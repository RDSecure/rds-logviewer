# rds-logviewer
Lector de LOGS de RDS, tiene la capacidad de exportar la información captada a una base de datos MySQL

## Introducción
El programa **RDS-LogViewer-Console** tiene como finalidad leer los logs que va generando el RDSGateway/WSP en el WEV

El RDSG, al momento de la instalación crea una entrada especial en el Windows EventViewer llamada "HOB WebSecureProxy", en ese repositorio se van a almacenar todos los logs que se van generando.
## Terminología
| Término | Descripción |
|--|--|
| WEG |  Windows EventViewer |
| RDSG | RDSGateway/WSP |
|  |  |

## Problemática
Uno de los principales problemas que nos enfrentamos son:

 - Es muy complicado "peinar" los logs en tiempo de ejecución directamente desde el WEV.
 - Se requiere un análisis de usuarios.
 - Enviar los datos del WEV hacía una base de datos para su posterior integración con otros reporteadores.

## Lista de comandos para la aplicación RDS-LogViewer-Console
Aunque la aplicación funciona bastante bien en Single Mode, se requiere integrar elementos que permitan un mejor manejo de la información mostrada. A continuación se enumeran una lista de deseos de comandos.
```console
    Forma de uso:
      rdslogviewer {comandos}
    Comandos
	    --config            Especifica un archivo de configuración por defecto,
                          dónde se podrán definir valores por default para
                          conexiones recurrentes.
	    --console=bool			True:Ejecuta el programa en modo consola.
                          False: Ejecuta el programa en forma gráfica (no implementado)
		--usedb=bool          infica que almacenaremos los datos en una base de datos.
                          Esto es útil si se requiere enviar la información a una
                          DB diferente o de pruebas.
		--dbhost=String       Dirección del servidor de la base de datos (requiere --usedb)			
		--dbport=Integer      Puerto del servidor de la base de datos (requiere --usedb)
		--dbschema=String     Base de datos/Schema de rdslog (requiere --usedb)
		--dbuser=String       Usuario de la base de datos (requiere --usedb)
		--dbpassword=String		Contraseña del usuario de la base de datos (requiere --usedb)
    --help                Ayuda
    
    Aunadamente se podría usar el comando
    
    rdslogviewer {comando} --help  
```

## Archivo de configuración de la aplicación
Debido a que esta aplicación será parte de la Suit del RDS, se requerirá estabecer la ruta de instalación dentro del directorio de instalación del RDS, creo que este aplicativo tendría que ir dentro del directorio 	`%ProgramFiles%\RDSecure\management`. Por lo tanto, allí mismo se guardará el archivo de configuración, y contendrá la siguiente información.
```ini
    [Application]
    console=true
    [DB]
    usedb=true
    dbhost=192.168.1.56
    dbport=389
    dbschema=rdslogs
    dbuser=rdsuser
    dbpassword={strong_password}
```

asas
