using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>();
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetByCi(int ci)
        {
            var student = _students.Find(s => s.CI == ci);
            if (student == null)
            {
                student = new Student
                {
                    CI = -1,
                    Nombre = "Not Found",
                    Nota = 0,
                };
            }
            return student;
        }

        public Student Create(Student student)
        {
            Student createdStudent;
            if (student.Nota < 0 || student.Nota > 100)
            {
                createdStudent = new Student
                {
                    CI = -1,
                    Nombre = student.Nombre + " / Nota Not Available",
                    Nota = 0,
                };
                // devolver un mensaje de error
                // return BadRequest("Nota must be between 0 and 100.");
            }
            else
            {
                student.CI = _students.Count > 0 ? _students.Max(s => s.CI) + 1 : 1;
                _students.Add(student);
                createdStudent = student;
            }
            return createdStudent;
        }

        public Student Update(int ci, Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.CI == ci);

            student.Nombre = updatedStudent.Nombre;
            student.Nota = updatedStudent.Nota;

            // return NoContent();
            return student;
        }

        public Student Delete(int ci)
        {
            var student = _students.FirstOrDefault(s => s.CI == ci);
            if (student != null)
            {
                _students.Remove(student);
                return student;
            }
            return null;
        }

        public Boolean HasApproved(int ci)
        {
            var student = _students.FirstOrDefault(p => p.CI == ci);
            if (student == null)
                return false;

            return student.Nota >= 51;
        }
    }
}
