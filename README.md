# Guía para Levantar y Ejecutar la API

Este repositorio contiene el código fuente de una API para un Sistema de Gestión de Alquileres. Sigue las siguientes instrucciones para levantar el proyecto localmente y comenzar a usar la API.

## Levantando el Proyecto

1. **Clona el Repositorio:**
   Clona este repositorio en tu máquina local utilizando el siguiente comando:
   
```
git clone https://github.com/JesusJs/Sistema_Gestion_Alquileres.git
```

2. **Script sql-server:**
   ve a la carpeta llamada "Script_SqlServer", ejecuta el script en sql-server para crear, la base de datos, tabla con usuario y contrasena.

   **Instancia de base de datos SQL:**
        Coloca aqui la instancia de tu sqlserver:
     ![image](https://github.com/JesusJs/GestionAlquileres/assets/67086360/c1b771ef-b3d4-458d-ba59-b50e86da67c8)

   
4. **Instala Dependencias:**
Asegúrate de tener todas las dependencias necesarias instaladas en tu entorno de desarrollo. Puedes instalarlas ejecutando:
```
dotnet restore
```


4. **Ejecuta la Aplicación:**
Una vez que hayas clonado el repositorio y configurado las dependencias, puedes ejecutar la aplicación utilizando el siguiente comando:

```
dotnet run
```

## Autenticación y Autorización

5. **Inicio de Sesión:**
Después de levantar la aplicación, puedes iniciar sesión como usuario utilizando las siguientes credenciales:
- **Usuario:** `prueba`
- **Contraseña:** `pruebapass`

6. **Obtención de Token de Autenticación:**
Después de proporcionar las credenciales de inicio de sesión, recibirás un token de autenticación. Debes copiar este token ya que se utilizará para realizar todas las peticiones a la API.

7. **Autorización:**
Para autorizar las solicitudes a la API, debes agregar el token de autenticación en el encabezado `Authorization`. Utiliza el formato `Bearer {token}`. Por ejemplo:

```
Authorization: Bearer FGSDgfsdf
```



## Realización de Peticiones

Una vez que hayas iniciado sesión y obtenido el token de autenticación, puedes comenzar a realizar peticiones a la API utilizando herramientas como Postman o cURL.

