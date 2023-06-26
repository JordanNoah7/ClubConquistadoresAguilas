CREATE DATABASE ClubConquistadoresAguilas;
USE ClubConquistadoresAguilas;

--Creacion de la tabla Clubes
CREATE TABLE Clubs
(
    ID             INT IDENTITY  NOT NULL,
    name           NVARCHAR(25)  NOT NULL,
    address        NVARCHAR(30)  NOT NULL,
    stars          TINYINT       NOT NULL,
    foundationDate DATE          NOT NULL,
    meetingDay     NVARCHAR(10)  NOT NULL,
    meetingHour    TIME(0)       NOT NULL,
    district       NVARCHAR(20)  NOT NULL,
    city           NVARCHAR(20)  NOT NULL,
    region         NVARCHAR(20)  NOT NULL,
    country        NVARCHAR(20)  NOT NULL,
    description    NVARCHAR(250) NOT NULL,
    CONSTRAINT PK_Clubs PRIMARY KEY (ID),
    CONSTRAINT CK_Stars CHECK (stars >= 1 AND stars <= 5),
    CONSTRAINT CK_MeetingDay CHECK (meetingDay IN
                                    ('Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado')),
    CONSTRAINT CK_MeetingHour CHECK (meetingHour >= '06:00:00' AND meetingHour <= '17:00:00')
);

--Creacion de la tabla Unidades
CREATE TABLE Units
(
    ID          TINYINT IDENTITY NOT NULL,
    name        NVARCHAR(15)     NOT NULL,
    motto       NVARCHAR(100)    NOT NULL,
    battleCry   NVARCHAR(250)    NOT NULL,
    description NVARCHAR(250)    NOT NULL,
    ClubID      INT              NOT NULL,
    CONSTRAINT PK_Units PRIMARY KEY (ID),
    CONSTRAINT FK_Club_Units FOREIGN KEY (ClubID) REFERENCES Clubs (ID)
);

--Creacion de la tabla Cargos
CREATE TABLE Positions
(
    ID          TINYINT IDENTITY NOT NULL,
    name        NVARCHAR(20)     NOT NULL,
    description NVARCHAR(250)    NOT NULL,
    CONSTRAINT PK_Positions PRIMARY KEY (ID)
);

--Creacion de la tabla Personas
CREATE TABLE People
(
    ID             INT IDENTITY NOT NULL,
    firstName      NVARCHAR(30) NOT NULL,
    fathersSurname NVARCHAR(15) NOT NULL,
    mothersSurname NVARCHAR(15) NOT NULL,
    birthDate      DATE         NOT NULL,
    gender         CHAR(1)      NOT NULL,
    address        NVARCHAR(30) NOT NULL,
    phone          nvarchar(15) NOT NULL,
    email          NVARCHAR(30) NOT NULL,
    ClubID         INT          NOT NULL,
    PersonID       INT          NULL,
    CONSTRAINT PK_People PRIMARY KEY (ID),
    CONSTRAINT FK_Club_People FOREIGN KEY (ClubID) REFERENCES Clubs (ID),
    CONSTRAINT FK_Parent_Child FOREIGN KEY (PersonID) REFERENCES People (ID),
    CONSTRAINT CK_Gender CHECK (gender IN ('M', 'F')),
    CONSTRAINT CK_Phone CHECK (phone LIKE '[0][1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR phone LIKE '[9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    CONSTRAINT CK_Email CHECK (email LIKE '%@%.%' AND email NOT LIKE '%@%@%')
);

--Creacion de la tabla CargoPersonaUnidad
CREATE TABLE PositionPersonUnit
(
    UnitID     TINYINT NOT NULL,
    PersonID   INT     NOT NULL,
    PositionID Tinyint NOT NULL,
    CONSTRAINT PK_PositionPersonUnit PRIMARY KEY (UnitID, PersonID),
    CONSTRAINT FK_PositionPersonUnit_Unit FOREIGN KEY (UnitID) REFERENCES Units (ID),
    CONSTRAINT FK_PositionPersonUnit_Person FOREIGN KEY (PersonID) REFERENCES People (ID),
    CONSTRAINT FK_PositionPersonUnit_Position FOREIGN KEY (PositionID) REFERENCES Positions (ID),
);

--Creacion de la tabla Actividades
CREATE TABLE Activities
(
    ID           INT IDENTITY  NOT NULL,
    name         NVARCHAR(20)  NOT NULL,
    startDate    DATE          NOT NULL,
    endDate      DATE          NOT NULL,
    location     NVARCHAR(50)  NOT NULL,
    description  NVARCHAR(250) NOT NULL,
    requirements NVARCHAR(250) NOT NULL,
    ClubID       INT           NOT NULL,
    CONSTRAINT PK_Activities PRIMARY KEY (ID),
    CONSTRAINT FK_Club_Activities FOREIGN KEY (ClubID) REFERENCES Clubs (ID),
    CONSTRAINT CK_StartDate CHECK (startDate <= endDate),
    CONSTRAINT CK_EndDate CHECK (endDate >= startDate)
);

--Creacion de la tabla CargoPersonaActividad
CREATE TABLE PositionPersonActivity
(
    ActivityID INT     NOT NULL,
    PersonID   INT     NOT NULL,
    PositionID TINYINT NOT NULL,
    CONSTRAINT PK_PositionPersonActivity PRIMARY KEY (ActivityID, PersonID),
    CONSTRAINT FK_PositionPersonActivity_Activity FOREIGN KEY (ActivityID) REFERENCES Activities (ID),
    CONSTRAINT FK_PositionPersonActivity_Person FOREIGN KEY (PersonID) REFERENCES People (ID),
    CONSTRAINT FK_PositionPersonActivity_Position FOREIGN KEY (PositionID) REFERENCES Positions (ID),
);

--Creacion de la tabla Categorias
CREATE TABLE Categories
(
    ID          TINYINT IDENTITY NOT NULL,
    name        NVARCHAR(15)     NOT NULL,
    description NVARCHAR(250)    NOT NULL,
    CONSTRAINT PK_Categories PRIMARY KEY (ID)
);

--Creacion de la tabla Especialidades
CREATE TABLE Specialties
(
    ID           SMALLINT IDENTITY NOT NULL,
    name         NVARCHAR(25)      NOT NULL,
    description  NVARCHAR(250)     NOT NULL,
    requirements NVARCHAR(1000)    NOT NULL,
    CategoryID   TINYINT           NOT NULL,
    CONSTRAINT PK_Specialties PRIMARY KEY (ID),
    CONSTRAINT FK_Category_Specialties FOREIGN KEY (CategoryID) REFERENCES Categories (ID)
);

--Creacion de la tabla EspecialidadPersona
CREATE TABLE SpecialtyPerson
(
    PersonID    INT      NOT NULL,
    SpecialtyID SMALLINT NOT NULL,
    CONSTRAINT PK_SpecialtyPerson PRIMARY KEY (PersonID, SpecialtyID),
    CONSTRAINT FK_SpecialtyPerson_Person FOREIGN KEY (PersonID) REFERENCES People (ID),
    CONSTRAINT FK_SpecialtyPerson_Specialty FOREIGN KEY (SpecialtyID) REFERENCES Specialties (ID)
);

--Creacion de la tabla Clases
CREATE TABLE Classes
(
    ID          TINYINT IDENTITY NOT NULL,
    name        NVARCHAR(15)     NOT NULL,
    description NVARCHAR(250)    NOT NULL,
    CONSTRAINT PK_Classes PRIMARY KEY (ID),
);

--Creacion de la tabla ClasePersona
CREATE TABLE ClassPerson
(
    PersonID INT     NOT NULL,
    ClassID  TINYINT NOT NULL,
    CONSTRAINT PK_ClassPerson PRIMARY KEY (PersonID, ClassID),
    CONSTRAINT FK_ClassPerson_Person FOREIGN KEY (PersonID) REFERENCES People (ID),
    CONSTRAINT FK_ClassPerson_Class FOREIGN KEY (ClassID) REFERENCES Classes (ID)
);

--Creacion de la tabla Usuarios
CREATE TABLE Users
(
    ID           INT          NOT NULL,
    userName     NVARCHAR(15) NOT NULL,
    password     NVARCHAR(15) NOT NULL,
    creationDate DATE DEFAULT GETDATE(),
    CONSTRAINT PK_Users PRIMARY KEY (ID),
    CONSTRAINT FK_Person_User FOREIGN KEY (ID) REFERENCES People (ID),
    CONSTRAINT CK_Password CHECK (password LIKE '%[0-9]%' AND password LIKE '%[A-Z]%' AND password LIKE '%[!@#$%^&*()]%')
);

--Creacion de la tabla Permisos
CREATE TABLE Permissions
(
    ID           TINYINT IDENTITY NOT NULL,
    name         NVARCHAR(20)     NOT NULL,
    description  NVARCHAR(250)    NOT NULL,
    creationDate DATE,
    CONSTRAINT PK_Permissions PRIMARY KEY (ID),
);

--Creacion de la tabla Roles
CREATE TABLE Roles
(
    ID           TINYINT IDENTITY NOT NULL,
    name         NVARCHAR(20)     NOT NULL,
    description  NVARCHAR(250)    NOT NULL,
    creationDate DATE,
    CONSTRAINT PK_Roles PRIMARY KEY (ID),
);

--Creacion de la tabla UnidadPermiso
CREATE TABLE UserPermission
(
    UserID       INT     NOT NULL,
    PermissionID TINYINT NOT NULL,
    CONSTRAINT PK_UserPermission PRIMARY KEY (UserID, PermissionID),
    CONSTRAINT FK_UserPermission_User FOREIGN KEY (UserID) REFERENCES Users (ID),
    CONSTRAINT FK_UserPermission_Permission FOREIGN KEY (PermissionID) REFERENCES Permissions (ID),
);

--Creacion de la tabla UsuarioRol
CREATE TABLE UserRol
(
    UserID INT     NOT NULL,
    RolID  TINYINT NOT NULL,
    CONSTRAINT PK_UserRol PRIMARY KEY (UserID, RolID),
    CONSTRAINT FK_UserRol_User FOREIGN KEY (UserID) REFERENCES Users (ID),
    CONSTRAINT FK_UserRol_Rol FOREIGN KEY (RolID) REFERENCES Roles (ID),
);

--Creacion de la tabla RolPermiso
CREATE TABLE RolPermission
(
    RolID        TINYINT NOT NULL,
    PermissionID TINYINT NOT NULL,
    CONSTRAINT PK_RolPermission PRIMARY KEY (RolID, PermissionID),
    CONSTRAINT FK_RolPermission_Permission FOREIGN KEY (PermissionID) REFERENCES Permissions (ID),
    CONSTRAINT FK_RolPermission_Rol FOREIGN KEY (RolID) REFERENCES Roles (ID),
);