-- ========================================================
-- DATABASE: ClinicManagerDB
-- SCRIPT: 01_initial_database_and_tables_creation.sql
-- AUTHOR: [Jorge Yañez]
-- DATE: [Sunday, April 5th, 2026]
-- DESCRIPTION: Initial tables creation for Clinic Manager
-- ========================================================

-- ========================================
-- 1️ Create database if it doesn't exist
-- ========================================
IF DB_ID('ClinicManagerDB') IS NULL
BEGIN
    CREATE DATABASE ClinicManagerDB;
END
GO

USE ClinicManagerDB;
GO

-- ========================================
-- 2️ Users table
-- ========================================
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    UserName NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    IsActive BIT DEFAULT 1,
    CreateDate DATETIME DEFAULT GETDATE(),
    EditDate DATETIME
);

-- ========================================
-- 3️ Roles table
-- ========================================
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

-- ========================================
-- 4️ UserRoles table (Many-to-Many)
-- ========================================
CREATE TABLE UserRoles (
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    PRIMARY KEY(UserId, RoleId),
    FOREIGN KEY(UserId) REFERENCES Users(UserId),
    FOREIGN KEY(RoleId) REFERENCES Roles(RoleId)
);

-- ========================================
-- 5️ Doctors table
-- ========================================
CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL UNIQUE,  -- Each doctor linked to a user
    Specialty NVARCHAR(100),
    Active BIT DEFAULT 1,
    FOREIGN KEY(UserId) REFERENCES Users(UserId)
);

-- ========================================
-- 6️ DocumentTypes table
-- ========================================
CREATE TABLE DocumentTypes (
    DocTypeId INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(20) NOT NULL
);

-- Default document types
INSERT INTO DocumentTypes (Description)
VALUES
    ('DNI'),      -- 0
    ('Passport'), -- 1
    ('Other');    -- 2

-- ========================================
-- 7️ Patients table
-- ========================================
CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    DocNum NVARCHAR(30),
    Address NVARCHAR(300),
    FirstName1 NVARCHAR(50) NOT NULL,
    FirstName2 NVARCHAR(50),
    LastName1 NVARCHAR(50) NOT NULL,
    LastName2 NVARCHAR(50),
    DocTypeId INT, -- FK to DocumentTypes
    BirthDate DATE,
    Sex SMALLINT DEFAULT 0 NOT NULL,
    Tel1 NVARCHAR(20),
    Tel2 NVARCHAR(20),
    Mobile1 NVARCHAR(20),
    Mobile2 NVARCHAR(20),
    Email NVARCHAR(100),
    Obs NVARCHAR(1025),
    Status BIT DEFAULT 1, -- 1=Active, 0=Inactive
    CreateUser INT,
    CreateDate DATETIME DEFAULT GETDATE(),
    EditUser INT,
    EditDate DATETIME,
    FOREIGN KEY(DocTypeId) REFERENCES DocumentTypes(DocTypeId),
    FOREIGN KEY(CreateUser) REFERENCES Users(UserId),
    FOREIGN KEY(EditUser) REFERENCES Users(UserId)
);

-- ========================================
-- 8️ AppointmentStatus table
-- ========================================
CREATE TABLE AppointmentStatus (
    AppointmentStatusId INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(20) NOT NULL
);

-- Default statuses
INSERT INTO AppointmentStatus (Description)
VALUES 
    ('Scheduled'),
    ('Cancelled'),
    ('Done');

-- ========================================
-- 9️ Appointments table
-- ========================================
CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDateTime DATETIME,
    AppointmentStatusId INT DEFAULT 1, -- Default = Scheduled
    Observation NVARCHAR(1025),
    Description NVARCHAR(1025),
    Amount DECIMAL(16,4),
    CreateUser INT,
    CreateDate DATETIME DEFAULT GETDATE(),
    EditUser INT,
    EditDate DATETIME,
    FOREIGN KEY(PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY(DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY(AppointmentStatusId) REFERENCES AppointmentStatus(AppointmentStatusId),
    FOREIGN KEY(CreateUser) REFERENCES Users(UserId),
    FOREIGN KEY(EditUser) REFERENCES Users(UserId)
);
CREATE INDEX IDX_Appointments_PatientId ON Appointments(PatientId);
CREATE INDEX IDX_Appointments_DoctorId ON Appointments(DoctorId);

-- ========================================
-- 10️ RecordTypes table
-- ========================================
CREATE TABLE RecordTypes (
    RecordTypeId INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(50) NOT NULL
);

-- Default record types
INSERT INTO RecordTypes (Description)
VALUES
    ('Consultation'),
    ('Lab'),
    ('Imaging');

-- ========================================
-- 11️ MedicalRecords table
-- ========================================
CREATE TABLE MedicalRecords (
    MedicalRecordId INT IDENTITY(1,1) PRIMARY KEY,
    RecordNumber NVARCHAR(20),
    PatientId INT NOT NULL,
    RecordTypeId INT DEFAULT 1, -- Default = Consultation
    CreateUser INT,
    CreateDate DATETIME DEFAULT GETDATE(),
    EditUser INT,
    EditDate DATETIME,
    FOREIGN KEY(PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY(RecordTypeId) REFERENCES RecordTypes(RecordTypeId),
    FOREIGN KEY(CreateUser) REFERENCES Users(UserId),
    FOREIGN KEY(EditUser) REFERENCES Users(UserId)
);
CREATE INDEX IDX_MedicalRecords_PatientId ON MedicalRecords(PatientId);

-- ========================================================
-- End of initial tables creation
-- ========================================================