
INSERT INTO roles(name)
VALUES
    ('Admin'), 
    ('DoctorUser'),
    ('Scheduler')


INSERT INTO document_types (name)
VALUES
    ('DNI'),      
    ('Passport'), 
    ('Other');
    
INSERT INTO appointment_statuses (name)
VALUES 
    ('Scheduled'),
    ('Cancelled'),
    ('Done');

INSERT INTO record_types (name)
VALUES
    ('Consultation'),
    ('Lab'),
    ('Imaging');

INSERT INTO users
            (
           user_name
           ,password_hash
           ,is_active
           ,create_date
           ,create_user
           )
     VALUES
           ('Admin'
           ,'Admin_1'
           ,true
           ,CURRENT_TIMESTAMP
           ,1
           )

INSERT INTO specialties
           (name)
     VALUES
           ('Dermatología'),
           ('Ginecología'),
           ('Cirugía General')



INSERT INTO positions
           (name)
     VALUES
           ('Doctor'),
           ('Enfermera'),
           ('Recepcionista')


