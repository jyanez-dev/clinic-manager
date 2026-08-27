
SELECT 'users' AS tabla, COUNT(*) AS registros FROM users
UNION ALL
SELECT 'appointments', COUNT(*) FROM appointments
UNION ALL
SELECT 'appointment_status', COUNT(*) FROM appointment_statuses
UNION ALL
SELECT 'positions', COUNT(*) FROM positions
UNION ALL
SELECT 'document_types', COUNT(*) FROM document_types
UNION ALL
SELECT 'medical_records', COUNT(*) FROM medical_records
UNION ALL
SELECT 'patients', COUNT(*) FROM patients
UNION ALL
SELECT 'record_types', COUNT(*) FROM record_types
UNION ALL
SELECT 'roles', COUNT(*) FROM roles
UNION ALL
SELECT 'user_roles', COUNT(*) FROM user_roles
UNION ALL
SELECT 'employee_specialties', COUNT(*) FROM employee_specialties
UNION ALL
SELECT 'employees', COUNT(*) FROM employees
UNION ALL
SELECT 'employee_positions', COUNT(*) FROM employee_positions
UNION ALL
SELECT 'specialties', COUNT(*) FROM specialties;


select '1 Users', * from users;
select '2 Employees', * from employees;
select '3 Patients', * from patients;
select '4 Appointments', * from appointments;
select '5 MedicalRecords', * from medical_records;
select '6 AppointmentStatus', * from appointment_statuses;
select '7 DocumentTypes', * from document_types;
select '8 Positions', * from positions;
select '9 roles', * from roles;
select '10 UserRoles', * from user_roles;
select '11 EmployeeSpecialties', * from employee_specialties;
select '12 EmployeePositions', * from employee_positions;
select '13 RecordTypes', * from record_types;
select '14 Specialties', * from specialties;
 
--AppointmentStatus,DocumentTypes, RecordTypes, roles


--update users set create_date = CURRENT_TIMESTAMP where user_id = 2;
