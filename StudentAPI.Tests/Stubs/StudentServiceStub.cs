using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Tests.Stubs
{
    public class StudentServiceStub : IStudentService
    {
        private List<Student> _students;

        public StudentServiceStub()
        {
            _students = new List<Student>()
            {
                new Student
                {
                    CI = 56744323,
                    Nombre = "María López",
                    Nota = 45,
                },
                new Student
                {
                    CI = 10345214,
                    Nombre = "Fraya Jhemina Chambi",
                    Nota = 95,
                },
            };
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetByCi(int ci)
        {
            return _students.FirstOrDefault(s => s.CI == ci);
        }

        public bool HasApproved(int ci)
        {
            var student = _students.FirstOrDefault(p => p.CI == ci);
            if (student == null)
                return false;

            return student.Nota >= 51;
        }

        public Student Create(Student student)
        {
            _students.Add(student);
            return student;
        }

        public Student Update(int ci, Student updatedStudent)
        {
            var existing = _students.FirstOrDefault(s => s.CI == ci);
            if (existing != null)
            {
                existing.Nombre = updatedStudent.Nombre;
                existing.Nota = updatedStudent.Nota;
            }
            return existing;
        }

        public Student Delete(int ci)
        {
            var student = _students.FirstOrDefault(s => s.CI == ci);
            if (student != null)
            {
                _students.Remove(student);
            }
            return student;
        }
    }
}
