# rds-logviewer

Lector de LOGS de RDS, tiene la capacidad de exportar la información captada a una base de datos MySQL 

## Objetivo general    

Diseñar y Desarrollar una aplicación Web que Implemente el sistema RDsecure Logs System que permita obtener y extraer los datos e información de los usuarios y llevar un control, gestión y administración dentro de la base de datos, mediante consultas y requerimientos dentro de la empresa J-PYRSA.  


## Requisitos del sistema

- Sistema Operativo: Windows  7+
- Versión del .net: Visual Studio 2015 V.4.8.0
- Base de datos (versión):  8.0.19 - MySQL Community Server - GPL

## Herramientas de desarrollo (opcional)

- Visual Studio 
- HeidiSQL

## Instación

### base de datos

> Esta descripción es sólo pára mariadb / mysql ejecutándose en una máquina Linux

Desde la línea de comandos ejecutar.

```shell
mysql -u root -e "CREATE DATABASE IF NOT EXISTS rdsecurelogs; \
GRANT ALL PRIVILEGES ON rdsecurelogs.* \
  TO rdsuser@localhost \
  IDENTIFIED BY 'adminpw'";
```

Importar el scrip de la base de datos

```shell
mysql -u rdsuser –p adminpw < ./sql/database.sql
```

## Ejecución de la aplicación

La aplicación puede ejecutarse de dos formas

1. Por medio de la consola.
2. De forma desatendida

## Ejecución por medio de la consola.

A continuación se enumeran una lista de deseos de comandos.

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
### Ejemplos

Ejecutar la aplicación en modo consola, sin guardar información, sólo con la salida en pantalla.

```shell
rdslogviewer --console=true --usedb=false 
```

Ejecutar la aplicación en modo consola, guardando la información en la Base de datos con salida en pantalla.

```shell
rdslogviewer --console=true --usedb=true --dbhost=192.168.1.200 --dbport=3306 --dbschema=rdsecurelogs --dbuser=rdsuser --dbpassword=adminpw
```

Ejecutar la aplicación en modo consola, usando un archivo de configuración.

Crear el archivo de configuración `config.ini` en la misma carpeta donde se tiene el ejecutable

```ini
    [Application]
    console=true
    [DB]
    usedb=true
    dbhost=192.168.1.56
    dbport=3306
    dbschema=rdsecurelogs
    dbuser=rdsuser
    dbpassword=adminpw
```

```shell
rdslogviewer --console=true --config
```