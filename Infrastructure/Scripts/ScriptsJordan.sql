USE ClubConquistadoresAguilas;
--Insertar registros para pruebas
---Insertar a Club
DBCC CHECKIDENT ( Clubs, RESEED, 0);
INSERT INTO Clubs (name, address, stars, foundationDate, meetingDay, meetingHour, district, city, region, country,
                   description)
VALUES ('Las Aguilas', 'Ciudad Municipal', 3, '05/05/2014', 'Domingo', '09:00:00', 'Cerro Colorado', 'Arequipa',
        'Arequipa', N'Perú', 'Club de conquistadores Las Aguilas')

---Insertar a People
ALTER TABLE People
    ADD DNI INT NULL;
DBCC CHECKIDENT ( People, RESEED, 0);
INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email, ClubID, DNI)
VALUES ('Jordan', 'Quispe', 'Supo', '09/07/1999', 'M', 'Ciudad Municipal', '914786862',
        'j.jordan.quispe.supo@gmail.com', 1, 70685341);

---Insertar a Users
INSERT INTO Users (ID, userName, password)
VALUES (1, 'dyfmeks', '#Aa12345');

---Insertar roles
delete
from Roles
where id >= 0
DBCC CHECKIDENT ( Roles, RESEED, 0);
INSERT INTO Roles (name, description)
VALUES ('Conquistador', 'Solo son conquistadores, no tienen ningun cargo');
INSERT INTO Roles (name, description)
VALUES ('Consejero', 'Encargado de la unidad');
INSERT INTO Roles (name, description)
VALUES ('Instructor', N'Encargado de enseñar a las clases');
INSERT INTO Roles (name, description)
VALUES ('Tesorero', 'Encargado de llevar la parte financiera del club');
INSERT INTO Roles (name, description)
VALUES ('Director', 'Encargado de dirigir el club, puede ser asociado');
INSERT INTO Roles (name, description)
VALUES ('Apoderado', 'Padre o apoderado del conquistador');

---Insertar unidades
DBCC CHECKIDENT ( Units, RESEED, 0);
INSERT INTO Units (name, motto, battleCry, description, ClubID)
VALUES ('Halcones', 'por definir', 'por definir', 'Unidad de varos del club las aguilas', 1);
INSERT INTO Units (name, motto, battleCry, description, ClubID)
VALUES ('Fenix', 'por definir', 'por definir', 'Unidad de mujeres del club las aguilas', 1);

---Insertar clases de conquistadores
ALTER TABLE Classes
    ALTER COLUMN name NVARCHAR(35) NOT NULL;
DBCC CHECKIDENT ( Classes, RESEED, 0);
INSERT INTO Classes (name, description)
VALUES ('Amigo', N'Clase regular para conquistadores de 10 años');
INSERT INTO Classes (name, description)
VALUES ('Amigo de la naturaleza', N'Clase avanzada para conquistadores de 10 años');
INSERT INTO Classes (name, description)
VALUES (N'Compañero', N'Clase regular para conquistadores de 11 años');
INSERT INTO Classes (name, description)
VALUES (N'Compañero de excursionismo', N'Clase avanzada para conquistadores de 11 años');
INSERT INTO Classes (name, description)
VALUES ('Explorador', N'Clase regular para conquistadores de 12 años');
INSERT INTO Classes (name, description)
VALUES ('Explorador de campo y de bosques', N'Clase avanzada para conquistadores de 12 años');
INSERT INTO Classes (name, description)
VALUES ('Pionero', N'Clase regular para conquistadores de 13 años');
INSERT INTO Classes (name, description)
VALUES ('Pionero de nuevas fronteras', N'Clase avanzada para conquistadores de 13 años');
INSERT INTO Classes (name, description)
VALUES ('Excursionista', N'Clase regular para conquistadores de 14 años');
INSERT INTO Classes (name, description)
VALUES ('Excursionista en el bosque', N'Clase avanzada para conquistadores de 14 años');
INSERT INTO Classes (name, description)
VALUES (N'Guía', N'Clase regular para conquistadores de 15 años');
INSERT INTO Classes (name, description)
VALUES (N'Guía de exploración', N'Clase avanzada para conquistadores de 15 años');
INSERT INTO Classes (name, description)
VALUES (N'Guía Mayor', N'Conquistadores de 18 años');
INSERT INTO Classes (name, description)
VALUES (N'Guía Mayor Master', N'Conquistadores que completaron la clase de GMM');
INSERT INTO Classes (name, description)
VALUES (N'Guía Mayor Master Avanzado', N'Conquistadores que completaron la clase GMMA');

---Insertar posiciones
DBCC CHECKIDENT ( Positions, RESEED, 0);
INSERT INTO Positions (name, description)
VALUES ('Capitan', 'Capitan de la unidad');
INSERT INTO Positions (name, description)
VALUES ('Secretario', 'Secretario de la unidad');
INSERT INTO Positions (name, description)
VALUES ('Capellan', 'Capellan de la unidad');
INSERT INTO Positions (name, description)
VALUES ('Consejero', 'Consejero de la unidad');
INSERT INTO Positions (name, description)
VALUES ('Tesorero', 'Tesorero de la unidad');

---Insertar pruebas
INSERT INTO ClassPerson (PersonID, ClassID)
VALUES (1, 11);
INSERT INTO PositionPersonUnit (UnitID, PersonID, PositionID)
VALUES (1, 1, 4);
INSERT INTO UserRol (UserID, RolID)
VALUES (1, 2);

INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email, ClubID, DNI)
VALUES ('Elmer Leonel', 'Mercado', 'Llacho', '09/05/2007', 'M', 'Ciudad Municipal', '987654321', 'correo@gmail.com', 1,
        90865341);
INSERT INTO Users (ID, userName, password)
VALUES (2, 'ellemell', '#Ee12345');
INSERT INTO UserRol (UserID, RolID)
VALUES (2, 5);
INSERT INTO ClassPerson (PersonID, ClassID)
VALUES (2, 11);
INSERT INTO PositionPersonUnit (UnitID, PersonID, PositionID)
VALUES (1, 2, 5);

--Añadiendo campo para control de concurrencia a las tablas
ALTER TABLE Clubs
    ADD concurrencyClub TIMESTAMP NOT NULL;
ALTER TABLE Units
    ADD concurrencyUnit TIMESTAMP NOT NULL;
ALTER TABLE Positions
    ADD concurrencyPosition TIMESTAMP NOT NULL;
ALTER TABLE People
    ADD concurrencyPerson TIMESTAMP NOT NULL;
ALTER TABLE PositionPersonUnit
    ADD concurrencyPPU TIMESTAMP NOT NULL;
ALTER TABLE Activities
    ADD concurrencyActivity TIMESTAMP NOT NULL;
ALTER TABLE PositionPersonActivity
    ADD concurrencyPPA TIMESTAMP NOT NULL;
ALTER TABLE Categories
    ADD concurrencyCategory TIMESTAMP NOT NULL;
ALTER TABLE Specialties
    ADD concurrencySpecialty TIMESTAMP NOT NULL;
ALTER TABLE SpecialtyPerson
    ADD concurrencySP TIMESTAMP NOT NULL;
ALTER TABLE Classes
    ADD concurrencyClass TIMESTAMP NOT NULL;
ALTER TABLE ClassPerson
    ADD concurrencyCP TIMESTAMP NOT NULL;
ALTER TABLE Users
    ADD concurrencyUser TIMESTAMP NOT NULL;
ALTER TABLE Permissions
    ADD concurrencyPermission TIMESTAMP NOT NULL;
ALTER TABLE Roles
    ADD concurrencyRole TIMESTAMP NOT NULL;
ALTER TABLE UserPermission
    ADD concurrencyUP TIMESTAMP NOT NULL;
ALTER TABLE UserRol
    ADD concurrencyUR TIMESTAMP NOT NULL;
ALTER TABLE RolPermission
    ADD concurrencyRP TIMESTAMP NOT NULL;

ALTER TABLE People
    ADD DNI INT NULL;
ALTER TABLE People
    ALTER COLUMN DNI INT NOT NULL;

ALTER TABLE ClassPerson
    ADD year DATE DEFAULT GETDATE() NOT NULL;

ALTER TABLE Classes
    ALTER COLUMN name VARCHAR(35) NOT NULL;

ALTER TABLE Roles
    ADD DEFAULT GETDATE() FOR creationDate;
ALTER TABLE Roles
    ALTER COLUMN creationDate DATE NOT NULL;

ALTER TABLE UserRol
    ADD insertionDate DATE DEFAULT GETDATE() NOT NULL;

--Procedimientos almacenados
---Procedimiento para obtener el usuario
ALTER PROCEDURE usp_GetUserRolByUsername @username VARCHAR(15)
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT U.ID User_ID,
               U.password,
               U.concurrencyUser,
               R.ID Rol_ID,
               R.name
        FROM Users U
                 JOIN UserRol UR on U.ID = UR.UserID
                 JOIN Roles R on R.ID = UR.RolID
        WHERE U.userName = @username
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Usuario no encontrado', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener una persona
ALTER PROCEDURE usp_GetPersonClassByID @PersonID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               P.birthDate,
               P.phone,
               P.email,
               CP.ClassID,
               C.name     class,
               PPU.UnitID,
               U.name     unit,
               coalesce(APBY.Total,0) points,
               coalesce(SBY.Total,0)  savings
        FROM People AS P
                 LEFT OUTER JOIN ClassPerson CP on P.ID = CP.PersonID
                 LEFT OUTER JOIN PositionPersonUnit PPU on P.ID = PPU.PersonID
                 LEFT OUTER JOIN Classes C on C.ID = CP.ClassID
                 LEFT OUTER JOIN Units U on U.ID = PPU.UnitID
                 LEFT JOIN AttendancePointByYear APBY on APBY.ID = p.ID
                 left join SavingsByYear SBY on p.id = SBY.id
        WHERE P.ID = @PersonID
          AND YEAR(CP.year) = YEAR(getdate())
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Persona no encontrado', 16, 1);
    END CATCH
END
GO

exec usp_GetPersonClassByID 30
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener una persona
CREATE PROCEDURE usp_GetPersonByID @PersonID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname
        FROM People AS P
        WHERE P.ID = @PersonID
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Persona no encontrada', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---------------------------------------------------------------------------------------------
---Procedimiento para obtener una lista de conquistadores
ALTER PROCEDURE usp_GetPathfinders
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID    PeopleID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               C.name  class,
               U.name  unit,
               P2.name position
        FROM People P
                 JOIN ClassPerson CP on P.ID = CP.PersonID
                 JOIN Classes C on C.ID = CP.ClassID
                 JOIN PositionPersonUnit PPU on P.ID = PPU.PersonID
                 JOIN Units U on U.ID = PPU.UnitID
                 JOIN Positions P2 on P2.ID = PPU.PositionID
                 JOIN Users U2 on P.ID = U2.ID
                 JOIN UserRol UR on U2.ID = UR.UserID
        WHERE UR.RolID IN (1, 2, 4, 5)
          AND YEAR(UR.insertionDate) = YEAR(GETDATE());
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Conquistadores no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
------------------------------------------------------------------------------------------------------------------------
---Procedimiento para insertar persona
ALTER PROCEDURE usp_InsertPerson @DNI VARCHAR(8),
                                 @firstName NVARCHAR(30),
                                 @fathersSurname NVARCHAR(15),
                                 @mothersSurname NVARCHAR(15),
                                 @birthDate DATE,
                                 @gender CHAR(1),
                                 @address NVARCHAR(30),
                                 @phone nvarchar(15),
                                 @email NVARCHAR(30),
                                 @ClubID INT,
                                 @userName NVARCHAR(15),
                                 @password NVARCHAR(15),
                                 @FatherID INT = NULL,
                                 @ClassID INT,
                                 @UnitID INT,
                                 @PositionID INT,
                                 @RoleID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DECLARE @PersonID int;

        INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email,
                            ClubID, PersonID, DNI)
        VALUES (@firstName, @fathersSurname, @mothersSurname, @birthDate, @gender, @address, @phone, @email,
                @ClubID, @FatherID, @DNI);

        SET @PersonID = SCOPE_IDENTITY();

        INSERT INTO Users (ID, userName, password)
        VALUES (@PersonID, @userName, @password);

        INSERT INTO UserRol (UserID, RolID)
        VALUES (@PersonID, @RoleID);

        INSERT INTO ClassPerson (PersonID, ClassID)
        VALUES (@PersonID, @ClassID);

        INSERT INTO PositionPersonUnit (UnitID, PersonID, PositionID)
        VALUES (@UnitID, @PersonID, @PositionID);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al insertar persona', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener una lista de roles
ALTER PROCEDURE usp_GetRoles
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT R.ID,
               R.name
        FROM Roles R;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Roles no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener lista posiciones
ALTER PROCEDURE usp_GetPositions
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.name
        FROM Positions P;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Cargos no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener lista unidades
ALTER PROCEDURE usp_GetUnits
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT U.ID,
               U.name
        FROM Units U;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Unidades no encontradas', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener lista unidades
ALTER PROCEDURE usp_GetClasses
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT C.ID,
               C.name
        FROM Classes C;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Clases no encontradas', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener una lista de padres para llenar el combobox
ALTER PROCEDURE usp_GetFathers
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname
        FROM People P
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
        WHERE UR.RolID = 6
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Padres no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
------------------------------------------------------------------------------------------------------------------------
---Procedimiento para obtener una persona
ALTER PROCEDURE usp_GetPathfinderById @Id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.DNI,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               P.birthDate,
               P.gender,
               P.phone,
               P.email,
               P.address,
               P.PersonID,
               P.concurrencyPerson,
               CP.ClassID,
               PPU.UnitID,
               PPU.PositionID,
               UR.RolID,
               U.userName,
               U.password
        FROM People P
                 JOIN ClassPerson CP on P.ID = CP.PersonID
                 JOIN PositionPersonUnit PPU on P.ID = PPU.PersonID
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
        WHERE P.ID = @Id
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Conquistador no encontrado', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para modificar conquistador
ALTER PROCEDURE usp_UpdatePerson @PersonID INT,
                                 @DNI VARCHAR(8),
                                 @firstName NVARCHAR(30),
                                 @fathersSurname NVARCHAR(15),
                                 @mothersSurname NVARCHAR(15),
                                 @birthDate DATE,
                                 @gender CHAR(1),
                                 @address NVARCHAR(30),
                                 @phone nvarchar(15),
                                 @email NVARCHAR(30),
                                 @ClubID INT,
                                 @userName NVARCHAR(15),
                                 @password NVARCHAR(15),
                                 @FatherID INT = NULL,
                                 @ClassID INT,
                                 @UnitID INT,
                                 @PositionID INT,
                                 @RoleID INT,
                                 @concurrency TIMESTAMP
AS
BEGIN
    IF @concurrency = (SELECT concurrencyPerson
                       FROM People
                       WHERE ID = @PersonID)
        BEGIN
            BEGIN TRAN;
            BEGIN TRY

                UPDATE People
                SET DNI            = @DNI,
                    firstName      = @firstName,
                    fathersSurname = @fathersSurname,
                    mothersSurname = @mothersSurname,
                    birthDate      = @birthDate,
                    gender         = @gender,
                    address        = @address,
                    phone          = @phone,
                    email          = @email,
                    PersonID       = @FatherID,
                    ClubID         = @ClubID
                WHERE ID = @PersonID;

                UPDATE Users
                SET userName = @userName,
                    password = @password
                WHERE ID = @PersonID;

                UPDATE UserRol
                SET RolID = @RoleID
                WHERE UserID = @PersonID;

                UPDATE ClassPerson
                SET ClassID = @ClassID
                WHERE PersonID = @PersonID;

                UPDATE PositionPersonUnit
                SET UnitID     = @UnitID,
                    PositionID = @PositionID
                WHERE PersonID = @PersonID;

                COMMIT TRAN;
            END TRY
            BEGIN CATCH
                ROLLBACK TRAN;
                RAISERROR ('Error al actualizar persona.', 16, 1);
            END CATCH
        END
    ELSE
        BEGIN
            RAISERROR ('Error al actualizar persona, debido a que el archivo fue modificado antes.', 16, 1);
        END
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimientno para eliminar una persona
ALTER PROCEDURE usp_DeletePerson @PersonID INT
AS
BEGIN
    BEGIN TRAN;
    IF @PersonID NOT IN
       (SELECT PPA.PersonID FROM PositionPersonActivity PPA WHERE PPA.PersonID = @PersonID AND PPA.PositionID = 6)
        BEGIN
            BEGIN TRY
                DELETE SP
                FROM SpecialtyPerson AS SP
                WHERE SP.PersonID = @PersonID;

                DELETE UR
                FROM UserRol AS UR
                WHERE UR.UserID = @PersonID;

                DELETE CP
                FROM ClassPerson AS CP
                WHERE CP.PersonID = @PersonID;

                DELETE PPA
                FROM PositionPersonActivity AS PPA
                WHERE PPA.PersonID = @PersonID;

                DELETE PPU
                FROM PositionPersonUnit AS PPU
                WHERE PPU.PersonID = @PersonID;

                DELETE U
                FROM Users AS U
                WHERE U.ID = @PersonID;

                DELETE P
                FROM People AS P
                WHERE P.ID = @PersonID;

                COMMIT TRAN;
            END TRY
            BEGIN CATCH
                ROLLBACK TRAN;
                RAISERROR ('Error al eliminar persona', 16, 1);
            END CATCH
        END
    ELSE
        BEGIN
            RAISERROR ('La persona es encargada de una actividad', 16, 1);
        END
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener a los consejeros
CREATE PROCEDURE usp_GetCounselors
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID   PeopleID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               C.name class,
               U.name unit
        FROM People P
                 JOIN ClassPerson CP on P.ID = CP.PersonID
                 JOIN Classes C on C.ID = CP.ClassID
                 JOIN PositionPersonUnit PPU on P.ID = PPU.PersonID
                 JOIN Units U on U.ID = PPU.UnitID
                 JOIN Users U2 on P.ID = U2.ID
                 JOIN UserRol UR on U2.ID = UR.UserID
        WHERE (UR.RolID = 2 OR PPU.PositionID = 4)
          AND YEAR(UR.insertionDate) = YEAR(GETDATE())
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Consejeros no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener a los instructores
CREATE PROCEDURE usp_GetInstructors
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID   PeopleID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               C.name class
        FROM People P
                 JOIN ClassPerson CP on P.ID = CP.PersonID
                 JOIN Classes C on C.ID = CP.ClassID
                 JOIN Users U2 on P.ID = U2.ID
                 JOIN UserRol UR on U2.ID = UR.UserID
        WHERE UR.RolID = 3
          AND YEAR(UR.insertionDate) = YEAR(GETDATE())
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Instructores no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener a los padres para llenar la lista de Padres/Apoderados
CREATE PROCEDURE usp_GetParents
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID PeopleID,
               P.DNI,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               P.phone
        FROM People P
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
        WHERE UR.RolID = 6
          AND YEAR(UR.insertionDate) = YEAR(GETDATE())
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Consejeros no encontrados', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para insertar padre
ALTER PROCEDURE usp_InsertParent @DNI VARCHAR(8),
                                 @firstName NVARCHAR(30),
                                 @fathersSurname NVARCHAR(15),
                                 @mothersSurname NVARCHAR(15),
                                 @birthDate DATE,
                                 @gender CHAR(1),
                                 @address NVARCHAR(30),
                                 @phone nvarchar(15),
                                 @email NVARCHAR(30),
                                 @ClubID INT,
                                 @userName NVARCHAR(15),
                                 @password NVARCHAR(15),
                                 @RoleID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DECLARE @PersonID int;

        INSERT INTO People (DNI, firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email,
                            ClubID)
        VALUES (@DNI, @firstName, @fathersSurname, @mothersSurname, @birthDate, @gender, @address, @phone, @email,
                @ClubID);

        SET @PersonID = SCOPE_IDENTITY();

        INSERT INTO Users (ID, userName, password)
        VALUES (@PersonID, @userName, @password);

        INSERT INTO UserRol (UserID, RolID)
        VALUES (@PersonID, @RoleID);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al insertar padre', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para actualizar padre
ALTER PROCEDURE usp_UpdateParent @PersonID INT,
                                 @DNI VARCHAR(8),
                                 @firstName NVARCHAR(30),
                                 @fathersSurname NVARCHAR(15),
                                 @mothersSurname NVARCHAR(15),
                                 @birthDate DATE,
                                 @gender CHAR(1),
                                 @address NVARCHAR(30),
                                 @phone nvarchar(15),
                                 @email NVARCHAR(30),
                                 @ClubID INT,
                                 @userName NVARCHAR(15),
                                 @password NVARCHAR(15),
                                 @RoleID INT,
                                 @concurrency TIMESTAMP
AS
BEGIN
    IF @concurrency = (SELECT concurrencyPerson
                       FROM People
                       WHERE ID = @PersonID)
        BEGIN
            BEGIN TRAN;
            BEGIN TRY

                UPDATE People
                SET DNI            = @DNI,
                    firstName      = @firstName,
                    fathersSurname = @fathersSurname,
                    mothersSurname = @mothersSurname,
                    birthDate      = @birthDate,
                    gender         = @gender,
                    address        = @address,
                    phone          = @phone,
                    email          = @email,
                    ClubID         = @ClubID
                WHERE ID = @PersonID;

                UPDATE Users
                SET userName = @userName,
                    password = @password
                WHERE ID = @PersonID;

                UPDATE UserRol
                SET RolID = @RoleID
                WHERE UserID = @PersonID;

                COMMIT TRAN;
            END TRY
            BEGIN CATCH
                ROLLBACK TRAN;
                RAISERROR ('Error al actualizar padre.', 16, 1);
            END CATCH
        END
    ELSE
        BEGIN
            RAISERROR ('Error al actualizar padre, debido a que el registro fue modificado antes.', 16, 1);
        END
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener una persona
ALTER PROCEDURE usp_GetParentById @Id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.DNI,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               P.birthDate,
               P.gender,
               P.phone,
               P.email,
               P.address,
               P.concurrencyPerson,
               UR.RolID,
               U.userName,
               U.password
        FROM People P
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
        WHERE P.ID = @Id
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Padre no encontrado', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener todas las actividades
CREATE PROCEDURE usp_GetActivities
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT A.ID,
               A.name,
               A.startDate,
               A.endDate,
               PPA.PersonID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               A.location
        FROM Activities A
                 JOIN PositionPersonActivity PPA on A.ID = PPA.ActivityID
                 JOIN People P on P.ID = PPA.PersonID
        WHERE PPA.PositionID = 6
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al obtener las actividades de la base de datos', 16, 1);
    END CATCH
END
GO
---------------------------------------------------------------------------------------------Listo
---Procidimiento para insertar la cabecera de una actividad
ALTER PROCEDURE usp_InsertActivity @name nvarchar(20),
                                   @startDate date,
                                   @endDate date,
                                   @location nvarchar(50),
                                   @description nvarchar(MAX),
                                   @requirements NVARCHAR(MAX),
                                   @manager int
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DECLARE @IdActivity INT;

        INSERT INTO Activities (name, startDate, endDate, location, description, requirements, ClubID)
        VALUES (@name, @startDate, @endDate, @location, @description, @requirements, 1);

        SET @IdActivity = SCOPE_IDENTITY();

        INSERT INTO PositionPersonActivity (ActivityID, PersonID, PositionID)
        VALUES (@IdActivity, @manager, 6);

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al agregar la actividad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener las personas que pueden ser encargados
CREATE PROCEDURE usp_GetManagers
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname
        FROM People P
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
        WHERE UR.RolID != 6
          AND DATEDIFF(YEAR, P.birthDate, GETDATE()) >= 18;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener todos los participantes de la actividad
CREATE PROCEDURE usp_GetParticipants @ActivityId INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname
        FROM PositionPersonActivity PPA
                 JOIN People P on P.ID = PPA.PersonID
        WHERE PPA.PositionID != 6
          AND PPA.ActivityID = @ActivityId
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RAISERROR ('Error al obtener los participantes de la actividad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener todos los conquistadores que no participan en la actividad
ALTER PROCEDURE usp_GetNoParticipants @ActivityId INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID, P.firstName, P.fathersSurname, P.mothersSurname
        FROM People P
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
        WHERE P.ID NOT IN (SELECT PPA.PersonID
                           FROM Activities A
                                    JOIN PositionPersonActivity PPA on A.ID = PPA.ActivityID
                           WHERE A.ID = @ActivityId)
          AND UR.RolID IN (1, 2, 3, 4, 5);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al obtener los que no participan de la actividad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procidimiento para insertar participantes
CREATE PROCEDURE usp_InsertParticipant @ActivityId INT,
                                       @PersonId INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        INSERT INTO PositionPersonActivity (ActivityID, PersonID, PositionID)
        VALUES (@ActivityId, @PersonId, 7);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al insertar al participante en la actividad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procidimiento para eliminar participantes
CREATE PROCEDURE usp_DeleteParticipant @ActivityId INT,
                                       @PersonId INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DELETE
        FROM PositionPersonActivity
        WHERE ActivityID = @ActivityId
          AND PersonID = @PersonId;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al eliminar al participante de la actividad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo


---Procidimiento para actualizar cabecera de actividad
Alter PROCEDURE usp_UpdateActivity @ActivityId INT,
                                   @name nvarchar(50),
                                   @startDate date,
                                   @endDate date,
                                   @location nvarchar(50),
                                   @description nvarchar(MAX),
                                   @requirements NVARCHAR(MAX),
                                   @manager int,
                                   @concurrency TIMESTAMP
AS
BEGIN
    BEGIN TRAN;
    IF @concurrency = (SELECT concurrencyActivity
                       FROM Activities
                       WHERE ID = @ActivityId)
        BEGIN
            BEGIN TRY
                UPDATE Activities
                SET name         = @name,
                    startDate    = @startDate,
                    endDate      = @endDate,
                    location     = @location,
                    description  = @description,
                    requirements = @requirements
                WHERE ID = @ActivityId;

                IF @manager IN (SELECT PPA.PersonID
                                FROM PositionPersonActivity PPA
                                WHERE PPA.ActivityID = @ActivityId)
                    BEGIN
                        IF @manager != (SELECT PPA.PersonID
                                        FROM PositionPersonActivity PPA
                                        WHERE PPA.PositionID = 6
                                          AND PPA.ActivityID = @ActivityId)
                            BEGIN
                                UPDATE PositionPersonActivity
                                SET PositionID = 7
                                WHERE PositionID = 6
                                  AND ActivityID = @ActivityId;

                                UPDATE PositionPersonActivity
                                SET PositionID = 6
                                WHERE ActivityID = @ActivityId
                                  AND PersonID = @manager;
                            END
                    END
                ELSE
                    BEGIN
                        UPDATE PositionPersonActivity
                        SET PositionID = 7
                        WHERE PositionID = 6
                          AND ActivityID = @ActivityId;

                        INSERT INTO PositionPersonActivity (ActivityID, PersonID, PositionID)
                        VALUES (@ActivityId, @manager, 6);
                    END

                COMMIT TRAN;
            END TRY
            BEGIN CATCH
                ROLLBACK TRAN;
                RAISERROR ('Error al actualizar la actividad.', 16, 1);
            END CATCH
        END
    ELSE
        BEGIN
            ROLLBACK TRAN;
            RAISERROR ('Otro usuario actualizo la actividad.', 16, 1);
        END
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener la actividad y poder editarla
ALTER PROCEDURE usp_GetActivity @ActivityId INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT A.name,
               A.startDate,
               A.endDate,
               A.location,
               A.description,
               A.requirements,
               A.concurrencyActivity,
               P.ID
        FROM Activities A
                 JOIN PositionPersonActivity PPA on A.ID = PPA.ActivityID
                 JOIN People P on P.ID = PPA.PersonID
        WHERE PPA.PositionID = 6
          AND A.ID = @ActivityId
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al obtener la actividad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para eliminar actividad
ALTER PROCEDURE usp_DeleteActivity @ActivityId INT--, @concurrency TIMESTAMP
AS
BEGIN
    BEGIN TRAN;
    --IF @concurrency = (SELECT concurrencyActivity
    --                 FROM Activities
    --               WHERE ID = @ActivityId)
    --BEGIN
    BEGIN TRY
        DELETE
        FROM PositionPersonActivity
        WHERE ActivityID = @ActivityId;

        DELETE
        FROM Activities
        WHERE ID = @ActivityId;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al eliminar la actividad.', 16, 1);
    END CATCH
    --END
    --ELSE
    --  BEGIN
    --    ROLLBACK TRAN;
    --  RAISERROR ('Otro usuario elimino o actualizo la actividad.', 16, 1);
    --END
END
GO
-------------------------------------------------------------------------------------------Listo
---Funcion para obtener la suma de puntos para insertar el total
CREATE FUNCTION uf_CalculateTotal(@frecuency TINYINT,
                                  @devotion TINYINT,
                                  @monthly TINYINT,
                                  @discipline TINYINT,
                                  @year TINYINT,
                                  @requeriments TINYINT)
    RETURNS TINYINT
AS
BEGIN
    DECLARE @total SMALLINT;
    SET @total = @frecuency + @devotion + @monthly + @discipline + @year + @requeriments;
    RETURN @total;
END
-------------------------------------------------------------------------------------------Listo
---Vista para obtener la suma de puntos de las personas en el año actual
CREATE VIEW AttendancePointByYear
AS
SELECT P.ID,
       SUM(A.frecuency) + SUM(A.devotion) + SUM(A.monthly) + SUM(A.discipline) + SUM(A.year) +
       SUM(A.requeriments) AS Total
FROM People P
         JOIN Attendance A on P.ID = A.PersonID
WHERE YEAR(A.date) = YEAR(GETDATE())
GROUP BY P.ID, YEAR(A.date)
-------------------------------------------------------------------------------------------Listo
---Procedimiento para insertar los puntos
alter PROC usp_InsertAttendance @PersonID INT,
                                @frecuency TINYINT,
                                @devotion TINYINT,
                                @monthly TINYINT,
                                @discipline TINYINT,
                                @year TINYINT,
                                @requeriments TINYINT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        INSERT INTO Attendance (PersonID, frecuency, devotion, monthly, discipline, year, requeriments)
        VALUES (@PersonID, @frecuency, @devotion, @monthly, @discipline, @year, @requeriments)
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al insertar la asistencia.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener la lista de conquistadores por unidad
alter PROCEDURE usp_GetPathfindersByUnit @UnitID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               COALESCE(APBY.Total, 0) Total
        FROM People P
                 JOIN PositionPersonUnit PPU ON P.ID = PPU.PersonID
                 LEFT JOIN AttendancePointByYear APBY ON P.ID = APBY.ID
        WHERE DATEDIFF(YEAR, P.birthDate, GETDATE()) <= 15
          AND PPU.UnitID = @UnitID
          AND P.ID NOT IN (SELECT A.PersonID
                           FROM Attendance A
                           WHERE A.date = CAST(GETDATE() AS DATE));
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al obtener a los conquistadores de la unidad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener la lista de todos los miembros de la unidad
ALTER PROCEDURE usp_GetMembersByUnit @UnitID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               C.name
        FROM People P
                 JOIN PositionPersonUnit PPU ON P.ID = PPU.PersonID
                 JOIN ClassPerson CP on P.ID = CP.PersonID
                 JOIN Classes C on C.ID = CP.ClassID
        WHERE PPU.UnitID = @UnitID;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al obtener a los miembros de la unidad.', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para insertar un instructor
ALTER PROCEDURE usp_InsertInstructor @DNI VARCHAR(8),
                                     @firstName NVARCHAR(30),
                                     @fathersSurname NVARCHAR(15),
                                     @mothersSurname NVARCHAR(15),
                                     @birthDate DATE,
                                     @gender CHAR(1),
                                     @address NVARCHAR(30),
                                     @phone nvarchar(15),
                                     @email NVARCHAR(30),
                                     @ClubID INT,
                                     @userName NVARCHAR(15),
                                     @password NVARCHAR(15),
                                     @ClassID INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DECLARE @PersonID int;

        INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email,
                            ClubID, PersonID, DNI)
        VALUES (@firstName, @fathersSurname, @mothersSurname, @birthDate, @gender, @address, @phone, @email,
                @ClubID, null, @DNI);

        SET @PersonID = SCOPE_IDENTITY();

        INSERT INTO Users (ID, userName, password)
        VALUES (@PersonID, @userName, @password);

        INSERT INTO UserRol (UserID, RolID)
        VALUES (@PersonID, 3);

        INSERT INTO ClassPerson (PersonID, ClassID)
        VALUES (@PersonID, @ClassID);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al insertar instructor', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para actualizar instructor
CREATE PROCEDURE usp_UpdateInstructor @PersonID INT,
                                      @DNI VARCHAR(8),
                                      @firstName NVARCHAR(30),
                                      @fathersSurname NVARCHAR(15),
                                      @mothersSurname NVARCHAR(15),
                                      @birthDate DATE,
                                      @gender CHAR(1),
                                      @address NVARCHAR(30),
                                      @phone nvarchar(15),
                                      @email NVARCHAR(30),
                                      @ClubID INT,
                                      @userName NVARCHAR(15),
                                      @password NVARCHAR(15),
                                      @ClassID INT,
                                      @concurrency TIMESTAMP
AS
BEGIN
    IF @concurrency = (SELECT concurrencyPerson
                       FROM People
                       WHERE ID = @PersonID)
        BEGIN
            BEGIN TRAN;
            BEGIN TRY

                UPDATE People
                SET DNI            = @DNI,
                    firstName      = @firstName,
                    fathersSurname = @fathersSurname,
                    mothersSurname = @mothersSurname,
                    birthDate      = @birthDate,
                    gender         = @gender,
                    address        = @address,
                    phone          = @phone,
                    email          = @email,
                    PersonID       = null,
                    ClubID         = @ClubID
                WHERE ID = @PersonID;

                UPDATE Users
                SET userName = @userName,
                    password = @password
                WHERE ID = @PersonID;

                UPDATE UserRol
                SET RolID = 3
                WHERE UserID = @PersonID;

                UPDATE ClassPerson
                SET ClassID = @ClassID
                WHERE PersonID = @PersonID;

                COMMIT TRAN;
            END TRY
            BEGIN CATCH
                ROLLBACK TRAN;
                RAISERROR ('Error al actualizar los datos del instructor.', 16, 1);
            END CATCH
        END
    ELSE
        BEGIN
            RAISERROR ('Error al actualizar los datos del instructor, debido a que ya fue modificado antes.', 16, 1);
        END
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener una persona
CREATE PROCEDURE usp_GetInstuctorById @Id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.DNI,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname,
               P.birthDate,
               P.gender,
               P.phone,
               P.email,
               P.address,
               P.concurrencyPerson,
               U.userName,
               U.password,
               CP.ClassID
        FROM People P
                 JOIN Users U on P.ID = U.ID
                 JOIN UserRol UR on U.ID = UR.UserID
                 JOIN ClassPerson CP on P.ID = CP.PersonID
        WHERE P.ID = @Id
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Instructor no encontrado', 16, 1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener la lista de categoria de especialidades
CREATE PROCEDURE usp_GetSpecialtyCategories
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT C.ID,
               C.name
        FROM Categories C
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener la lista de especialidades por categoria
CREATE PROCEDURE usp_GetSpecialtyByCategory @CategoryId TINYINT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT S.ID,
               S.name
        FROM Specialties S
        WHERE S.CategoryID = @CategoryId
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para obtener los conquistadores de la clase
CREATE PROCEDURE usp_GetPathfindersByClass @ClassId TINYINT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.ID,
               P.firstName,
               P.fathersSurname,
               P.mothersSurname
        FROM People P
                 JOIN ClassPerson CP on P.ID = CP.PersonID
        WHERE CP.ClassID = @ClassId
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
---Procedimiento para insertar nota de conquistador
CREATE PROCEDURE usp_InsertNote @PersonID INT,
                                @SpecialtyID INT,
                                @Note TINYINT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        IF @PersonID IN (SELECT SP.PersonID FROM SpecialtyPerson SP WHERE SP.SpecialtyID = @SpecialtyID)
            BEGIN
                UPDATE SpecialtyPerson
                SET Note = @Note
                WHERE PersonID = @PersonID
                  AND SpecialtyID = @SpecialtyID
            END
        ELSE
            BEGIN
                INSERT INTO SpecialtyPerson (PersonID, SpecialtyID, Note)
                VALUES (@PersonID, @SpecialtyID, @Note)
            END
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RAISERROR ('Error al insertar la nota.',16,1);
    END CATCH
END
GO
-------------------------------------------------------------------------------------------Listo
--Procedimiento para obtener los hijos de un padre debe tener nombres y apellidos, Dni, clase y unidad
alter PROCEDURE usp_GetChildren @FatherId INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        SELECT P.Id, P.DNI, P.FirstName, P.FathersSurname, P.MothersSurname, c.name class, u.name unit
        FROM People P
                 JOIN ClassPerson CP ON P.Id = CP.PersonId
                 JOIN Classes C ON cp.ClassId = c.ID
                 JOIN PositionPersonUnit PPU ON ppu.PersonId = P.Id
                 JOIN UNITS U ON U.ID = PPU.UNITID
        WHERE p.PersonId = @FatherId
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO


--Arreglar el sp personclassbyid para que muestre puntos y ahorro más

--Procedimiento para insertar ahorro de conquistador
CREATE PROC usp_InsertFee @PersonId INT, @Fee DECIMAL(10, 2)
AS
begin
    begin tran;
    begin try
        insert into Savings (PersonId, Fee) VALUES (@PersonId, @Fee);
        commit tran;
    end try
    begin catch
        rollback tran;
    end catch
end
go



--Crear tabla de ahorro de conquistador
CReATE TABLE Savings
(
    PersonId INT                    NOT NULL,
    Date     DATE DEFAULT GETDATE() NOT NULL,
    Fee      DECIMAL(10, 2),
    CONSTRAINT PK_Savings PRIMARY KEY (PersonId, Date),
    CONSTRAINT FK_PERSON_SAVINGS FOREIGN KEY (PersonId) REFERENCES People (Id),
    CONSTRAINT CK_Fee CHECK (Fee > 0)
);



CREATE VIEW SavingsByYear
AS
SELECT P.ID,
       SUM(S.Fee) AS Total
FROM People P
         JOIN Savings S on P.ID = S.PersonID
WHERE YEAR(s.date) = YEAR(GETDATE())
GROUP BY P.ID, YEAR(s.date)

update People set PersonID = 22 where ID = 9
exec usp_GetPersonClassByID 2