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
