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
CREATE PROCEDURE usp_GetUserRolByUsername @username VARCHAR(15)
AS
BEGIN
    BEGIN TRAN
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
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para obtener una persona
CREATE PROCEDURE usp_GetPersonClassByID @PersonID INT
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            SELECT C.firstName,
                   C.fathersSurname,
                   C.mothersSurname,
                   CP.ClassID
            FROM People AS C
                     JOIN ClassPerson CP on C.ID = CP.PersonID
            WHERE C.ID = @PersonID
              AND YEAR(CP.year) = YEAR(getdate())
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---------------------------------------------------------------------------------------------
---Procedimiento para obtener una lista de conquistadores
CREATE PROCEDURE usp_GetPathfinders
AS
BEGIN
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
    WHERE UR.RolID IN (1, 2, 3, 4, 5)
      AND YEAR(UR.insertionDate) = YEAR(GETDATE());
END
GO

---Procedimiento para insertar un padre
CREATE PROCEDURE usp_InsertPerson @DNI INT,
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
    BEGIN TRAN
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
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para insertar un conquistador
CREATE PROCEDURE usp_InsertPathfinder @firstName NVARCHAR(30),
                                      @fathersSurname NVARCHAR(15),
                                      @mothersSurname NVARCHAR(15),
                                      @birthDate DATE,
                                      @gender CHAR(1),
                                      @address NVARCHAR(30),
                                      @phone nvarchar(15),
                                      @email NVARCHAR(30),
                                      @ClubID INT,
                                      @PersonUpID INT,
                                      @userName NVARCHAR(15),
                                      @password NVARCHAR(15)
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            DECLARE @PersonID int;

            INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email,
                                ClubID, PersonID)
            VALUES (@firstName, @fathersSurname, @mothersSurname, @birthDate, @gender, @address, @phone, @email,
                    @ClubID, @PersonUpID);

            SET @PersonID = SCOPE_IDENTITY();

            INSERT INTO Users (ID, userName, password)
            VALUES (@PersonID, @userName, @password);
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para modificar conquistador
CREATE PROCEDURE usp_UpdatePerson @PersonID INT,
                                  @firstName NVARCHAR(30),
                                  @fathersSurname NVARCHAR(15),
                                  @mothersSurname NVARCHAR(15),
                                  @birthDate DATE,
                                  @gender CHAR(1),
                                  @address NVARCHAR(30),
                                  @phone nvarchar(15),
                                  @email NVARCHAR(30),
                                  @FatherID INT/*,
                                      @userName NVARCHAR(15),
                                      @password NVARCHAR(15)*/
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            UPDATE People
            SET firstName      = @firstName,
                fathersSurname = @fathersSurname,
                mothersSurname = @mothersSurname,
                birthDate      = @birthDate,
                gender         = @gender,
                address        = @address,
                phone          = @phone,
                email          = @email,
                PersonID       = @FatherID
            WHERE ID = @PersonID

            /*UPDATE Users
            SET userName = @userName,
                password = @password
            WHERE ID = @PersonID*/
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para modificar padre
/*CREATE PROCEDURE usp_UpdateFather @PersonID INT,
                                  @firstName NVARCHAR(30),
                                  @fathersSurname NVARCHAR(15),
                                  @mothersSurname NVARCHAR(15),
                                  @birthDate DATE,
                                  @gender CHAR(1),
                                  @address NVARCHAR(30),
                                  @phone nvarchar(15),
                                  @email NVARCHAR(30),
                                  @userName NVARCHAR(15),
                                  @password NVARCHAR(15)
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            UPDATE People
            SET firstName      = @firstName,
                fathersSurname = @fathersSurname,
                mothersSurname = @mothersSurname,
                birthDate      = @birthDate,
                gender         = @gender,
                address        = @address,
                phone          = @phone,
                email          = @email
            WHERE ID = @PersonID

            UPDATE Users
            SET userName = @userName,
                password = @password
            WHERE ID = @PersonID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO*/

---Procedimientno para eliminar una persona
CREATE PROCEDURE usp_DeletePerson @PersonID INT
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            DELETE P
            FROM People AS P
            WHERE P.ID = @PersonID

            DELETE U
            FROM Users AS U
            WHERE U.ID = @PersonID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para obtener el club
CREATE PROCEDURE usp_GetClub @ClubID INT
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            SELECT *
            FROM Clubs
            WHERE ID = @ClubID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para obtener una unidad
CREATE PROCEDURE usp_GetUnit @UnitID INT
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            SELECT *
            FROM Units
            WHERE ID = @UnitID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para obtener unidades
CREATE PROCEDURE usp_GetUnits
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            SELECT *
            FROM Units
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para insertar unidad
CREATE PROCEDURE usp_InsertUnit @name NVARCHAR(15),
                                @motto NVARCHAR(100),
                                @battleCry NVARCHAR(250),
                                @description NVARCHAR(250),
                                @ClubID INT
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            INSERT INTO Units (name, motto, battleCry, description, ClubID)
            VALUES (@name, @motto, @battleCry, @description, @ClubID);
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO

---Procedimiento para actualizar unidad
CREATE PROCEDURE usp_UpdateUnit @UnitID TINYINT,
                                @name NVARCHAR(15),
                                @motto NVARCHAR(100),
                                @battleCry NVARCHAR(250),
                                @description NVARCHAR(250)
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            UPDATE Units
            SET name        = @name,
                motto       = @motto,
                battleCry   = @battleCry,
                description = @description
            WHERE ID = @UnitID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO