CREATE DATABASE BD_Universidad
GO

USE BD_Universidad
GO

CREATE TABLE Estados(
ID INT NOT NULL IDENTITY (1,1),
Nombre NVARCHAR(20) NOT NULL UNIQUE,
CONSTRAINT PK_Estados PRIMARY KEY CLUSTERED (ID)
);
GO


CREATE TABLE Niveles(
ID INT NOT NULL IDENTITY (1,1),
Nombre NVARCHAR (20) NOT NULL UNIQUE,
Numero INT NOT NULL UNIQUE,
CONSTRAINT PK_Niveles PRIMARY KEY CLUSTERED (ID)
);
GO

CREATE TABLE Materias(
ID INT NOT NULL IDENTITY (1,1),
Nombre NVARCHAR (50) NOT NULL UNIQUE,
Creditos INT NOT NULL,
Nivel INT NOT NULL,
CONSTRAINT PK_Materias PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_Niveles_Materias FOREIGN KEY (Nivel) REFERENCES Niveles (ID) ON DELETE NO ACTION ON UPDATE NO ACTION 
);
GO

CREATE TABLE Estudiantes(
ID INT NOT NULL IDENTITY (1, 1),
Cedula NVARCHAR (15) NOT NULL UNIQUE,
Nombre NVARCHAR (50) NOT NULL, 
Carnet NVARCHAR (15) NOT NULL UNIQUE,
Nivel INT NOT NULL,
Estado INT NOT NULL,
CONSTRAINT PK_Estudiantes PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_Niveles_Estudiantes FOREIGN KEY (Nivel) REFERENCES Niveles (ID) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT FK_Estados_Estudiantes FOREIGN KEY (Estado) REFERENCES Estados (ID) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE Salones(
ID INT NOT NULL IDENTITY (1,1),
Nombre NVARCHAR (6) NOT NULL UNIQUE,
Capacidad INT NOT NULL
CONSTRAINT PK_Salones PRIMARY KEY CLUSTERED (ID)
);
GO

CREATE TABLE Clases_Estudiantes(
ID INT NOT NULL IDENTITY (1,1),
Estudiante INT NOT NULL,
Salon INT NOT NULL,
Materia INT NOT NULL,
Nota1 DECIMAL NOT NULL,
Nota2 DECIMAL NOT NULL,
Nota3 DECIMAL NOT NULL,
Nota4 DECIMAL NOT NULL,
Nota5 DECIMAL NOT NULL,
NotaFinal DECIMAL NOT NULL,
CONSTRAINT PK_Clases_Estudiantes PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_Estudiantes_Clases_Estudiantes FOREIGN KEY (Estudiante) REFERENCES Estudiantes (ID) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT FK_Salon_Clases_Estudiantes FOREIGN KEY (Salon) REFERENCES Salones (ID) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT FK_Materias_Clases_Estudiantes FOREIGN KEY (Materia) REFERENCES Materias (ID) ON DELETE NO ACTION ON UPDATE NO ACTION 
);
GO

INSERT INTO Estados (Nombre)
VALUES
('Activo'),
('Inactivo'); 

INSERT INTO Niveles(Nombre, Numero)
VALUES
('Semestre 1',1),
('Semestre 2',2),
('Semestre 3',3),
('Semestre 4',4),
('Semestre 5',5),
('Semestre 6',6),
('Semestre 7',7),
('Semestre 8',8),
('Semestre 9',9),
('Semestre 10',10);

INSERT INTO Salones(Nombre, Capacidad)
VALUES
('K506', 40),
('N400', 40),
('L203', 30),
('M303', 35);

INSERT INTO Materias (Nombre, Creditos, Nivel)
VALUES
('Matematicas Basicas', 2, 1),
('Geometria vectorial', 3, 1),
('Calculo diferencial', 3, 2),
('Estructura de datos', 5, 3);

INSERT INTO Estudiantes (Cedula, Nombre, Carnet, Nivel, Estado)
VALUES
('1010', 'Johan', 111, 1, 2), -- inactivo
('1011', 'Stiven', 112, 3, 2), -- inactivo
('1012', 'Geraldine',113, 2, 1),
('1013', 'Valeria', 114, 1, 1), 
('1014', 'Isabela', 115, 3, 1);

INSERT INTO Clases_Estudiantes (Estudiante, Salon, Materia, Nota1, Nota2, Nota3, Nota4, Nota5, NotaFinal)
VALUES
( 5, 1, 1, 4.0, 3.2, 4.5, 1.0, 2.5, 3.04),
( 3, 3, 2, 5.0, 4.3, 4.0, 3.8, 4.0, 4.22),
( 4, 4, 3, 2.0, 1.8, 1.6, 3.0, 0.6, 1.80);
