using patientAPI.Models;   // same as from models.patient import Patient in python


namespace patientAPI.Services   // folder-level grouping
{
    public class PatientsService  // other parts of the project can use this class
    {
        private readonly List<Patient>_patients = new()  // Only this class PatientsService can access this list.
        {
            new Patient { Id = 1, Name = "John Doe", Age = 32, Gender = "Male"},
            new Patient { Id = 2, Name = "Jane Smith", Age = 28, Gender = "Female"}

        };
        public List<Patient> GetAll()   // This is a function that can be called and returns all the object values in _patients <- name of the object
        {
            return _patients;
        }

        public Patient? GetById(int id)
        {
            return _patients.FirstOrDefault(p => p.Id == id); // I know were creating the getbyid service and were stating the input has to be an id.  Not sure what p means but im seeing this is a arrow function i think, think its saying patient name = patient id
        }

        public Patient Add(Patient patient)    // this allows us to add and create a patient? 
        {
            patient.Id = _patients.Max(p => p.Id) + 1;
            _patients.Add(patient);
            return patient;
        }

        public Patient Update(Patient patient)
        {
            var existing = GetById(patient.Id);
            if (existing is null)
            {
                return null;
            }

            existing.Name = patient.Name;
            existing.Age = patient.Age;
            existing.Gender = patient.Gender;
            return existing;
        }

        public bool Delete(int id)
        {
            var patient = GetById(id);  // Reuses service logic from GetById to find the patient to delete
            if (patient != null)
            {
                _patients.Remove(patient);
                return true;
            }
            return false;
        }
    }
}