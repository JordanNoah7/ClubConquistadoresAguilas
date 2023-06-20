USE ClubConquistadoresAguilas;
INSERT INTO Clubs (name, address, stars, foundationDate, meetingDay, meetingHour, district, city, region, country,
                   description)
VALUES ('Las Aguilas', 'Ciudad Municipal', 3, '05/05/2014', 'Domingo', '09:00:00', 'Cerro Colorado', 'Arequipa',
        'Arequipa', 'Perú', 'Club de conquistadores Las Aguilas')

INSERT INTO People (firstName, fathersSurname, mothersSurname, birthDate, gender, address, phone, email, ClubID)
VALUES ('Jordan', 'Quispe', 'Supo', '09/07/1999', 'M', 'Ciudad Municipal', '914786862',
        'j.jordan.quispe.supo@gmail.com', 1);

INSERT INTO Users (ID, userName, password)
VALUES (1, 'dyfmeks', '#Aa12345');

SELECT *
FROM People;
SELECT *
FROM Users;
SELECT *
FROM People
         join Users U on People.ID = U.ID;