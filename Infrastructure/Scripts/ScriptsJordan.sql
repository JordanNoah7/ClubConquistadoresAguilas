USE ClubConquistadoresAguilas;
--Insertar registros para pruebas
---Insertar a Club
INSERT INTO Clubs (name, address, stars, foundationDate, meetingDay, meetingHour, district, city, region, country,
                   description)
VALUES ('Las Aguilas', 'Ciudad Municipal', 3, '05/05/2014', 'Domingo', '09:00:00', 'Cerro Colorado', 'Arequipa',
        'Arequipa', N'Perú', 'Club de conquistadores Las Aguilas')
---Insertar a People
INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email, ClubID)
VALUES ('Jordan', 'Quispe', 'Supo', '09/07/1999', 'M', 'Ciudad Municipal', '914786862',
        'j.jordan.quispe.supo@gmail.com', 1);
---Insertar a Users
INSERT INTO Users (ID, userName, password)
VALUES (1, 'dyfmeks', '#Aa12345');

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

--Procedimientos almacenados
---Procedimiento para obtener todos los usuarios
CREATE PROCEDURE usp_GetUsers
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            SELECT *
            FROM Users
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO
---Procedimiento para obtener una persona
CREATE PROCEDURE usp_GetPerson @PersonID INT
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            SELECT *
            FROM People AS p
            WHERE p.ID = @PersonID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO
execute dbo.usp_GetPerson 1
---Procedimiento para insertar un padre
CREATE PROCEDURE usp_InsertFather @firstName NVARCHAR(30),
                                  @fathersSurname NVARCHAR(15),
                                  @mothersSurname NVARCHAR(15),
                                  @birthDate DATE,
                                  @gender CHAR(1),
                                  @address NVARCHAR(30),
                                  @phone nvarchar(15),
                                  @email NVARCHAR(30),
                                  @ClubID INT,
                                  @userName NVARCHAR(15),
                                  @password NVARCHAR(15)
AS
BEGIN
    BEGIN TRAN
        BEGIN TRY
            DECLARE @PersonID int;

            INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email,
                                ClubID)
            VALUES (@firstName, @fathersSurname, @mothersSurname, @birthDate, @gender, @address, @phone, @email,
                    @ClubID);

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
CREATE PROCEDURE usp_UpdatePathfinder @PersonID INT,
                                      @firstName NVARCHAR(30),
                                      @fathersSurname NVARCHAR(15),
                                      @mothersSurname NVARCHAR(15),
                                      @birthDate DATE,
                                      @gender CHAR(1),
                                      @address NVARCHAR(30),
                                      @phone nvarchar(15),
                                      @email NVARCHAR(30),
                                      @PersonUpID INT,
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
                email          = @email,
                PersonID       = @PersonUpID
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
GO

---Procedimiento para modificar padre
CREATE PROCEDURE usp_UpdateFather @PersonID INT,
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
GO

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
            SET
                name = @name,
                motto = @motto,
                battleCry = @battleCry,
                description = @description
            WHERE ID = @UnitID
            COMMIT
        END TRY
        BEGIN CATCH
            ROLLBACK
        END CATCH
END
GO