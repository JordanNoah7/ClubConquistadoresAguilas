USE ClubConquistadoresAguilas;
--Insertar registros para pruebas
---Insertar a Club
INSERT INTO Clubs (name, address, stars, foundationDate, meetingDay, meetingHour, district, city, region, country,
                   description)
VALUES ('Las Aguilas', 'Ciudad Municipal', 3, '05/05/2014', 'Domingo', '09:00:00', 'Cerro Colorado', 'Arequipa',
        'Arequipa', 'Perú', 'Club de conquistadores Las Aguilas')
---Insertar a People
INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email, ClubID)
VALUES ('Jordan', 'Quispe', 'Supo', '09/07/1999', 'M', 'Ciudad Municipal', '914786862',
        'j.jordan.quispe.supo@gmail.com', 1);
---Insertar a Users
INSERT INTO Users (ID, userName, password)
VALUES (1, 'dyfmeks', '#Aa12345');

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