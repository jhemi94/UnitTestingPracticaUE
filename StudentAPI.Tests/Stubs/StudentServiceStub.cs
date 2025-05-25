using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Tests.Stubs
{
    public class StudentServiceStub : IStudentService
    {
        private List<Estudiante> _estudiantes;

        public StudentServiceStub()
        {
            _estudiantes = new List<Estudiante>()
            {
                new Estudiante
                {
                    CI = 56744323,
                    Nombre = "María López",
                    Nota = 45,
                },
                new Estudiante
                {
                    CI = 10345214,
                    Nombre = "Fraya Jhemina Chambi",
                    Nota = 95,
                },
            };
        }

        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetByCi(int ci)
        {
            return _estudiantes.FirstOrDefault(s => s.CI == ci);
        }

        public bool HasApproved(int ci)
        {
            var student = _estudiantes.FirstOrDefault(p => p.CI == ci);
            if (student == null)
                return false;

            return student.Nota >= 51;
        }

        public Estudiante Create(Estudiante student)
        {
            _estudiantes.Add(student);
            return student;
        }

        public Estudiante Update(int ci, Estudiante updatedStudent)
        {
            var existing = _estudiantes.FirstOrDefault(s => s.CI == ci);
            if (existing != null)
            {
                existing.Nombre = updatedStudent.Nombre;
                existing.Nota = updatedStudent.Nota;
            }
            return existing;
        }

        public Estudiante Delete(int ci)
        {
            var student = _estudiantes.FirstOrDefault(s => s.CI == ci);
            if (student != null)
            {
                _estudiantes.Remove(student);
            }
            return student;
        }
    }
}
