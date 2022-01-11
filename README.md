# rds-logviewer
Lector de LOGS de RDS, tiene la capacidad de exportar la información captada a una base de datos MySQL 

# Objetivo general    

Diseñar y Desarrollar una aplicación Web que Implemente el sistema RDsecure Logs System que permita obtener y extraer los datos e información de los usuarios y llevar un control, gestión y administración dentro de la base de datos, mediante consultas y requerimientos dentro de la empresa J-PYRSA.  


## Requisitos del sistema
- Sistema Operativo: Windows  10, 7.
- Versión del .net: Visual Studio 2015 V.4.8.0
- Base de datos (versión): MySQl -11.3.0 (32 Bit o 64 bit)

## Herramientas de desarrollo
- Visual Studio 
es un entorno de desarrollo integrado (IDE, por sus siglas en inglés) para Windows y macOS. Es compatible con múltiples lenguajes de programación, tales como C++, C#, Visual Basic .NET, F#, Java, Python, Ruby y PHP, al igual que entornos de desarrollo web, como ASP.NET MVC, Django, etc., a lo cual hay que sumarle las nuevas capacidades en línea bajo Windows Azure en forma del editor Monaco.


Visual Studio permite a los desarrolladores crear sitios y aplicaciones web, así como servicios web en cualquier entorno compatible con la plataforma .NET (a partir de la versión .NET 2002). Así, se pueden crear aplicaciones que se comuniquen entre estaciones de trabajo, páginas web, dispositivos móviles, dispositivos embebidos y videoconsolas, entre otros.

El Explorador de objetos de SQL Server ofrece una vista de los objetos de base de datos similar a la de SQL Server Management Studio. Con el Explorador de objetos de SQL Server puede realizar trabajos de administración y diseño de bases de datos ligeras. Algunos ejemplos son la edición de datos de tabla, la comparación de esquemas y la ejecución de consultas mediante menús contextuales.


-Ventajas 
-	Permite trabajar con los frameworks:
-	.NET Framework 2.0
-	.NET Framework 3.0
-	.NET Framework 3.5
-	.NET Framework 4.0
-	.NET Framework 4.5
-	.NET Framework 4.5.1
-	.NET Framework 4.5.2
-	.NET Framework 4.6
-	.NET Framework 4.6.1
-	.NET Core 1.0
-	.NET Core 1.1
-	.NET Core 2.0
-	Unificación de lenguajes de desarrollo. 
-	Posibilidad de desarrollar para plataformas móviles con C# nativo.
-	Excelentes herramientas de depuración. 
-	Integración de código abierto.

![Visual_Studio_Icon_2019 svg](https://user-images.githubusercontent.com/87664093/146627661-d38c8f42-6994-4ebc-9a7d-2bab18ff5aac.png)



- HeidiSQL 

HeidiSQL es un ligero programa para Windows que nos ofrece una interfaz amigable para administrar MySQL, pero también sistemas gestores SQL Server de Microsoft. Permite navegar por las bases de datos y las tablas, editando cualquier información, creando registros, modificando tablas, vistas, procedimientos, triggers y en general todo aquello que necesitaremos en el día a día de la administración de bases de datos.

- Ventajas
-	Conectar con varios servidores a la vez en una única ventana.
-	Conectar con servidores MySQL por línea de comandos.
-	Conectar con SSH o realizar conexiones SSL.
-	Editar tablas, vistas, procedimientos almacenados, triggers, eventos agendados...
-	Crear reportes SQL.
-	Exportar o importar datos desde o hacia otras fuentes o bases de datos. Por ejemplo, importar datos que haya en ficheros de texto o exportar los datos de las tablas a ficheros de texto con diversos formatos como CSV, HTML, XML, SQL, arrays de PHP, etc.
-	Administrar los privilegios de los usuarios.
-	Escribir consultas con resaltado de código SQL y completado de código y preformato de código SQL para una mejor lectura.
-	Monitorizar procesos del cliente y matarlos si lo necesitamos.
-	Búsquedas de un texto, no solo en una tabla, sino en múltiples, por si no sabemos dónde se encontraba.
-	Optimización y reparación de tablas, etc.
![HeidiSQL_logo_image](https://user-images.githubusercontent.com/87664093/146627669-1f4e3a40-29f5-4dd3-b577-0dcf097674f7.png)



-  SQL Server

Microsoft SQL Server es la alternativa de Microsoft a otros potentes sistemas gestores de bases de datos. Es un sistema de gestión de base de datos relacional desarrollado como un servidor que da servicio a otras aplicaciones de software que pueden funcionar ya sea en el mismo ordenador o en otro ordenador a través de una red (incluyendo Internet).


Los servidores SQL Server suelen presentar como principal característica una alta disponibilidad al permitir un gran tiempo de actividad y una conmutación más rápida. Todo esto sin sacrificar los recursos de memoria del sistema. Gracias a las funciones de memoria integradas directamente en los motores de base de datos SQL Server y de análisis, mejora la flexibilidad y se facilita el uso. Pero quizá su característica más destacada es que ofrece una solución robusta que se integra a la perfección con la familia de servidores Microsoft Server. 


- Ventajas 


-	Soporte de transacciones.
-	Escalabilidad, estabilidad y seguridad.
-	Soporte de procedimientos almacenados.
-	Incluye también un potente entorno gráfico de administración, que permite el
-	uso de comandos DDL y DML gráficamente.
-	Permite trabajar en modo cliente-servidor, donde la información y datos se alojan en el servidor y las terminales o clientes de la red solo acceden a la información.
-	Permite administrar información de otros servidores de datos.


![microsoft_sqlserver](https://user-images.githubusercontent.com/87664093/146627673-b6d4e9b6-77b9-4897-9082-146da56cd756.png)








## Instalación del esquema de la base de datos
Instalacion de heidiSQL
Nos dirigimos a la pagina https://www.haddishysql.com/download.php para descargar el programa HeidiSQL.

![heidi1](https://user-images.githubusercontent.com/87664093/144310912-e9063436-7249-4bc3-989b-1cc810dda2e5.png)

Después de haber descargado HeidiSQL procedemos a instalarlo dado clic en la descarga, el siguiente paso nos aparecerá una ventana donde vienen los acuerdos de la licencia si uno está de acuerdo sobre él se le da clic en aceptar en aceptó el acuerdo y después se le da de nuevo en el boton de siguiente.

![heidi2](https://user-images.githubusercontent.com/87664093/144312172-3b78db46-912e-4da2-b82b-460829c16e57.png)



las opciónes que nos muestra en la siguiente ventana  son iconos adicionales:
•	Crear un icono en el escritorio
•	Crear un icono de inicio rápido
•	Opciones asociados SQL archivos con heidiSQL comprobar automáticamente las actualizaciones con HeidiSQL 
•	Automáticamente informe versiones clientes de servidor en HeidiSQL.com 


![heidi3](https://user-images.githubusercontent.com/87664093/144312202-e98f3f81-8331-425d-979f-8a0fcd8871a6.png)

La siguiente ventana nos mostrara las tareas adicionales que elegimos para corroborar si están correctas y poder iniciar la instalación. 

![heidi4](https://user-images.githubusercontent.com/87664093/144312229-6937bcfe-ac7c-492a-bc3e-d46f0a13ac69.png)


El siguiente paso se escoge el nombre de la carpeta donde nos indica donde va a quedar el programa para cuando se realice una base y uno lo quiera modificar o hacer algo a ese archivo se pueda localizar. El mismo programa por default nos proporciona un nombre pero uno puede escoger el que uno quiera, se da clic en siguiente para continuar con la instalación.

![heidi5](https://user-images.githubusercontent.com/87664093/144312268-d41e854c-1651-4d44-a0c0-f010b5753307.png)


Al dar clic al botón de siguiente nos mostrara una barra de instalación y un botón para cancelar la instalación.
Al final de la instalación nos indica Heidi SQL que la instalación fue correcta y se le da clic en finalizar y así es como se instala Heidi SQL se cuela en una PC


## Edición del archivo de configuración

- Creación de un formulario en la aplicación para que el usuario pueda configurar una nueva conexión hacia la base de datos que desee conectarse, puede guardar esos datos ya que se almacenaran en un archivo INI y de igual manera podrá observar los datos que contiene el archivo INI.

![config](https://user-images.githubusercontent.com/87662377/144690206-f5162146-81a8-467a-a47b-43c31d2958af.png)



## Introducción
El programa **RDS-LogViewer-Console** tiene como finalidad leer los logs que va generando el RDSGateway/WSP en el WEV

El RDSG, al momento de la instalación crea una entrada especial en el Windows EventViewer llamada "HOB WebSecureProxy", en ese repositorio se va a almacenar todos los logs que se van generando.



## Terminología
| Término | Descripción |
|--|--|
| WEG |  Windows EventViewer |
| RDSG | RDSGateway/WSP |
|  |  |

![image](https://user-images.githubusercontent.com/30660343/125528279-fa42935f-8e41-4ac6-b6b8-861ff3c78d9b.png)


## Problemática
Uno de los principales problemas que nos enfrentamos son:

 - Es muy complicado "peinar" los logs en tiempo de ejecución directamente desde el WEV.
 - Se requiere un análisis de usuarios.
 - Enviar los datos del WEV hacía una base de datos para su posterior integración con otros reporteadores.
 
## Por hacer (TODO)
- Crear la aplicación para que funcione como servicio de Windows. (actualmente ya se tiene el procedimiento interno, solo hace falta la adaptación dependiendo de los parámetros de la aplicación o archivo de configuración)
- Crear el script/procedimeinto para instalar, desinstalar el servicio.

## Lista de comandos para la aplicación RDS-LogViewer-Console
Aunque la aplicación funciona bastante bien en Single Mode, se requiere integrar elementos que permitan un mejor manejo de la información mostrada. A continuación se enumeran una lista de deseos de comandos.
```console
    Forma de uso:
      rdslogviewer {comandos}
    Comandos
                --config              Especifica un archivo de configuración por defecto,
                                      dónde se podrán definir valores por default para
                                      conexiones recurrentes.
	        --console=bool        True:Ejecuta el programa en modo consola.
                                      False: Ejecuta el programa en forma gráfica (no implementado)
		--usedb=bool          infica que almacenaremos los datos en una base de datos.
                                      Esto es útil si se requiere enviar la información a una
                                      DB diferente o de pruebas.
		--dbhost=String       Dirección del servidor de la base de datos (requiere --usedb)			
		--dbport=Integer      Puerto del servidor de la base de datos (requiere --usedb)
		--dbschema=String     Base de datos/Schema de rdslog (requiere --usedb)
		--dbuser=String       Usuario de la base de datos (requiere --usedb)
		--dbpassword=String   Contraseña del usuario de la base de datos (requiere --usedb)
=========================================================================================================
                --install             Instala el servicio de Windows
		--uninstall           Desinstala el servicio de Windows 
=========================================================================================================
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
## Base de datos
### Estructura de base la base de datos.
A continuación se muestran los 
- Diseñar una solución de software que resuelva las necesidades del administrador haciendo una interacción en tiempo real propias del proceso de protocolo, utilizando tecnologías estándares y protocolos de seguridad que garanticen la autenticidad, fiabilidad, integridad, confidencialidad y disponibilidad de la información de los usuarios. 
 El registro deberá contener, como mínimo, los siguientes datos: 
-	Usuario o Administrador. 
-	Registro de inicio de sección. 
-	Eventos realizados. 
-	Niveles. 
-	Dirección IP. 
-	Servidor conectado. 
-	Mensajes. 
-	Contenido. 
-	Grupos. 
-	Pro tocólogos. 
-	Socket. 
-	Severely. 
-	Fecha de finalización de sección. 



![image](https://user-images.githubusercontent.com/30660343/107375508-19efc400-6ae9-11eb-8726-0a2922fb1c04.png)

La base de datos cuenta con 3 tablas:

**RDSLogs:** Esta tabla conguja la información que viene del WEV así como el evento del RDSG en sí.

  `id, TimeCreated, TimeCreatedf, EventID, Level, EventRecordID, Computer, Origin_code` Son datos provenientes WEV
  `severely_key` Referencia local
  `code, SNO, INETA, messaje, rdsContent` Información que viene de los logs del RDSG
Script para crear la tabla rdslogs
```sql
CREATE TABLE `rdslogs` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `TimeCreated` varchar(30) DEFAULT NULL,
  `TimeCreatedf` datetime DEFAULT NULL,
  `EventID` int DEFAULT NULL,
  `Level` int DEFAULT NULL,
  `EventRecordID` int DEFAULT NULL,
  `Computer` varchar(45) DEFAULT NULL,
  `Origin_code` varchar(10) NOT NULL,
  `severely_key` varchar(45) NOT NULL,
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `SNO` varchar(45) DEFAULT NULL,
  `INETA` varchar(45) DEFAULT NULL,
  `messaje` text,
  `rdsContent` text,
  PRIMARY KEY (`id`),
  KEY `fk_RDSLogs_Origin_idx` (`Origin_code`),
  KEY `fk_RDSLogs_severely1_idx` (`severely_key`),
  CONSTRAINT `fk_RDSLogs_Origin` FOREIGN KEY (`Origin_code`) REFERENCES `origin` (`code`),
  CONSTRAINT `fk_RDSLogs_severely1` FOREIGN KEY (`severely_key`) REFERENCES `severely` (`key`)
) ENGINE=InnoDB AUTO_INCREMENT=352 DEFAULT CHARSET=utf8;
```
**severely**

Script para generar la tabla severely
```sql
CREATE TABLE `severely` (
  `key` varchar(5) NOT NULL,
  `NumValue` int DEFAULT NULL,
  `Severity` varchar(20) DEFAULT NULL,
  `Keyword` varchar(10) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
```
Dar de alta valores por default

```sql
INSERT INTO `severely` VALUES ('A',1,'Alert','alert','Action must be taken immediately'),('C',2,'Critical','crit','Critical conditions'),('D',7,'Debug','debug','Debug-level messages'),('E',0,'Emergency','emerg','	System is unusable'),('ER',3,'Error','err','Error conditions'),('I',6,'Informational','info','Informational messages'),('N',5,'Notice','notice','Normal but significant conditions'),('T',8,'unknow','unknow','unknow'),('W',4,'Warning','warning','Warning conditions');
```
**origin**
Esta tabla diferencía la procedencia de los logs que vienen del RDSG:
**Administration Access** Los provenientes del portar de Administración (puerto 10000)
***Statics** estadísticas generales de la aplicación
**User Portal**: Logs provenientes del portal del usuario
```sql
CREATE TABLE `origin` (
  `code` varchar(10) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `origin`
--

LOCK TABLES `origin` WRITE;
/*!40000 ALTER TABLE `origin` DISABLE KEYS */;
INSERT INTO `origin` VALUES ('AdminA','Administration Access'),('Statics','Statics'),('UserP','User Portal');
```
