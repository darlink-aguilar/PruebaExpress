-- Creación de BD
CREATE DATABASE Prueba
GO

USE PRUEBA
GO

-- Creación de tablas
CREATE TABLE Empresas 
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NombreEmpresa NVARCHAR(80) NOT NULL,
	Direccion NVARCHAR(80) NOT NULL
)
GO

CREATE TABLE Maquinas
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(80) NOT NULL,
	AñoCreacion INT NOT NULL,
	IdEmpresa INT NOT NULL
)
GO

CREATE TABLE Funcionarios
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(80) NOT NULL,
	Apellido NVARCHAR(80) NOT NULL,
	IdMaquina INT NOT NULL
)
GO

-- Relaciones

ALTER TABLE Maquinas ADD FOREIGN KEY(IdEmpresa) 
REFERENCES Empresas
GO

ALTER TABLE Funcionarios ADD FOREIGN KEY(IdMaquina) 
REFERENCES Maquinas
GO

-- Insertar datos
INSERT INTO Empresas (NombreEmpresa, Direccion) VALUES
('Tech Solutions S.A.', 'Av. Intercomunal #123'),
('Industrias Globales', 'Calle Industrial, Lote 45'),
('Logística del Norte', 'Carrera 50 #12-34'),
('Innovaciones Médicas', 'Av. Las Ciencias 789'),
('Alimentos Frescos Co.', 'Zona Franca, Bodega 5'),
('Construcciones Alfa', 'Vía Principal Km 4');
GO

INSERT INTO Maquinas (Nombre, AñoCreacion, IdEmpresa) VALUES
('Servidor Principal Dell', 2022, 1),
('Brazo Robótico Kuka', 2021, 2),
('Montacargas Caterpillar', 2019, 3),
('Escáner Tomográfico GE', 2023, 4),
('Empacadora Alvac', 2020, 5),
('Mezcladora de Concreto', 2018, 6);
GO

INSERT INTO Funcionarios (Nombre, Apellido, IdMaquina) VALUES
('Juan', 'Pérez', 1),
('María', 'Gómez', 2),
('Carlos', 'Rodríguez', 3),
('Ana', 'Martínez', 4),
('Luis', 'Sánchez', 5),
('Elena', 'Ramírez', 6);
GO

-- Consulta: Las maquinas con la cantidad de funcionarios que tiene
SELECT M.NOMBRE, COUNT(F.ID) AS 'CANTIDAD DE FUNCIONARIOS' -- Renombramos
FROM Maquinas M LEFT JOIN Funcionarios F -- Left para que nos traiga las maquinas aun así no tengan funcionarios asignados
ON F.IdMaquina = M.Id
GROUP BY M.Nombre