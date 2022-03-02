# BT Con Selenium en C#

Framework Automatizacion para Bantotal Web

```sh
Framework creado en C# con Selenium preparado para automatizar pruebas en ambientes Bantotal Web que funcionan solo en Internet Explorer
```

Paso para poder ejecutar las pruebas

## Instalación

* IDE para C# [Visual Studio](https://visualstudio.microsoft.com/es/vs/community/) v2019 +
* Selenium Web Driver para  [Internet Explorer](https://selenium-release.storage.googleapis.com/3.141/IEDriverServer_Win32_3.141.59.zip) V3.141.59 32 bits

Pasos

```sh
Copiar "IEDriverServer" en el directorio "C:\webdriver" si no existe, crearlo.
```

Desde Visual Studio clonar el repositorio

```sh
Menú "Archivo" -> "Clonar repositorio..."
Dirección del repositorio: https://github.com/wilux/selenium_csharp.git
Una vez cargado, en el "Explorador de Soluciones" hacer doble click sobre el proyecto "BT_selenium"
```
## Credenciales

```sh
Dentro del proyecto se encuentra una clase llamado "CredencialesTemplate.cs", la misma contiene el "usuario" y "contraseña" de acceso que deben proveer. 
1.- Eliminar el archivo faltante (maracado con una cruz roja) llamado "Credenciales.cs"
2.- Renombrar la clase "CredencialesTemplate.cs" por "Credenciales.cs" y editar con sus datos.
```

## Librerias

```sh
Visual Studio detecta e instala automaticamente las librerias necesarias.
Para ello, ir ha "Herramientas" -> "Administrador de paquetes NuGet" -> "Administrar paquetes Nuget para la solución..."
Ya dentro de NuGet, saldra una advertencia que dice "Faltan algunos paquetes NuGet..." Deben presionar sobre el botón "Restaurar".
```

| Librerias | Documentación |
| ------ | ------ |
| Nunit | [https://docs.nunit.org/] |
| Selenium | [https://www.selenium.dev/documentation/] |


## License

MIT
