USE [ClinicManagerDB]
GO

INSERT INTO Roles(Name)
VALUES
    ('Admin'), 
    ('Doctor')

INSERT INTO DocumentTypes (Name)
VALUES
    ('DNI'),      
    ('Passport'), 
    ('Other');
    
INSERT INTO AppointmentStatus (Name)
VALUES 
    ('Scheduled'),
    ('Cancelled'),
    ('Done');

INSERT INTO RecordTypes (Name)
VALUES
    ('Consultation'),
    ('Lab'),
    ('Imaging');

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[UserName]
           ,[PasswordHash]
           ,[IsActive]
           ,[CreateDate]
           ,[CreateUser]
           )
     VALUES
           ('Admin'
           ,'Admin'
           ,'Admin'
           ,'Admin_1'
           ,1
           ,GETDATE()
           ,1
           )

INSERT INTO [dbo].[Specialties]
           (Name)
     VALUES
           ('Dermatología'),
           ('Ginecología'),
           ('Cirugía General')
GO






    