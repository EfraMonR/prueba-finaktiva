-- Crear la base de datos Registration
CREATE DATABASE Registration;
GO

-- Seleccionar la base de datos Registration
USE Registration;
GO

-- Crear la tabla EventLogs
CREATE TABLE EventLogs (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    fecha DATETIME NOT NULL,
    descripcion VARCHAR(MAX) NOT NULL,
    tipoEvento INT NOT NULL
);
GO
