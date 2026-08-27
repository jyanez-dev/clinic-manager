CREATE OR REPLACE FUNCTION set_edit_date()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    NEW.edit_date = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$;

CREATE TRIGGER trg_users_edit_date
BEFORE UPDATE ON users
FOR EACH ROW
EXECUTE FUNCTION set_edit_date();

CREATE TRIGGER trg_patients_edit_date
BEFORE UPDATE ON patients
FOR EACH ROW
EXECUTE FUNCTION set_edit_date();

CREATE TRIGGER trg_employees_edit_date
BEFORE UPDATE ON employees
FOR EACH ROW
EXECUTE FUNCTION set_edit_date();

CREATE TRIGGER trg_appointments_edit_date
BEFORE UPDATE ON appointments
FOR EACH ROW
EXECUTE FUNCTION set_edit_date();

CREATE TRIGGER trg_medical_records_edit_date
BEFORE UPDATE ON medical_records
FOR EACH ROW
EXECUTE FUNCTION set_edit_date();