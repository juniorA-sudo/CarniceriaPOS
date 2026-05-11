IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CarniceriaPOS')
BEGIN
    ALTER DATABASE CarniceriaPOS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CarniceriaPOS;
    PRINT 'Base de datos CarniceriaPOS eliminada exitosamente';
END
ELSE
BEGIN
    PRINT 'La base de datos CarniceriaPOS no existe';
END

GO
