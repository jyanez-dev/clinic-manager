USE [ClinicManagerDB]
GO

INSERT INTO Roles(Name)
VALUES
    ('Admin'), 
    ('DoctorUser'),
    ('Scheduler')


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


INSERT INTO [dbo].[Positions]
           (Name)
     VALUES
           ('Doctor'),
           ('Enfermera'),
           ('Recepcionista')
GO




   /*
   
   Positions

Doctor
Nurse
Receptionist
Administrator
Accountant
Intern

Roles

Admin
User
Scheduler
MedicalRecords
Reports
ReadOnly

   */