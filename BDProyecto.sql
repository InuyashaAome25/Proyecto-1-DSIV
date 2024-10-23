CREATE DATABASE DBCalculadoraProyect

USE DBCalculadoraProyect

CREATE TABLE Calculos(
	ID INT PRIMARY KEY IDENTITY(1,1),
    Operacion NVARCHAR(100),
    Resultado NVARCHAR(50),
	Operador NVARCHAR(20),
    Fecha DATETIME DEFAULT GETDATE()
);

GO
CREATE PROCEDURE InsertarCalculo
    @Operacion NVARCHAR(100),
    @Resultado NVARCHAR(50),
    @Operador NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Calculos (Operacion, Resultado, Operador)
    VALUES (@Operacion, @Resultado, @Operador);
END;

GO
CREATE PROCEDURE MostrarCalculos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Calculos ORDER BY Fecha DESC;
END;