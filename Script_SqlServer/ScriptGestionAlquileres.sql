CREATE DATABASE GestorPropiedades;

USE GestorPropiedades;

GO

-- Creación de la tabla Propiedades
CREATE TABLE Propiedades (
  propiedadesId INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL,
  ubicacion VARCHAR(20) NOT NULL,
  urlImagen VARCHAR(200) NOT NULL,
  disponibilidad BIT NOT NULL,
  precio INT NOT NULL,
  fechaArrendamiento DATETIME NULL
);

GO

-- Creación de la tabla Clientes
CREATE TABLE Clientes (
  usuarioId VARCHAR(50) NOT NULL,
  usuario VARCHAR(50) NOT NULL,
  contrasena VARCHAR(200) NOT NULL,
  CONSTRAINT PK_Clientes PRIMARY KEY (usuarioId, usuario)
);

GO

INSERT INTO Clientes (usuarioId, usuario, contrasena) VALUES
  (1, 'prueba', 'pruebapass');
GO