using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private List<Estudiante> _estudiantes;

        public StudentService()
        {
            _estudiantes = new List<Estudiante>();
        }

        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetByCi(int ci)
        {
            var estudiante = _estudiantes.Find(s => s.CI == ci);
            if (estudiante == null)
            {
                estudiante = new Estudiante
                {
                    CI = -1,
                    Nombre = "Not Found",
                    Nota = 0,
                };
            }
            return estudiante;
        }

        public Estudiante Create(Estudiante estudiante)
        {
            Estudiante createdStudent;
            if (estudiante.Nota < 0 || estudiante.Nota > 100)
            {
                createdStudent = new Estudiante
                {
                    CI = -1,
                    Nombre = estudiante.Nombre + " / Nota Not Available",
                    Nota = 0,
                };
                // devolver un mensaje de error
                // return BadRequest("Nota must be between 0 and 100.");
            }
            else
            {
                estudiante.CI = _estudiantes.Count > 0 ? _estudiantes.Max(s => s.CI) + 1 : 1;
                _estudiantes.Add(estudiante);
                createdStudent = estudiante;
            }
            return createdStudent;
        }

        public Estudiante Update(int ci, Estudiante updatedStudent)
        {
            var estudiante = _estudiantes.FirstOrDefault(s => s.CI == ci);

            estudiante.Nombre = updatedStudent.Nombre;
            estudiante.Nota = updatedStudent.Nota;

            // return NoContent();
            return estudiante;
        }

        public Estudiante Delete(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(s => s.CI == ci);
            if (estudiante != null)
            {
                _estudiantes.Remove(estudiante);
                return estudiante;
            }
            return null;
        }

        public Boolean HasApproved(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(p => p.CI == ci);
            if (estudiante == null)
                return false;

            return estudiante.Nota >= 51;
        }
    }
}
