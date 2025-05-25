using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using StudentAPI.Tests.Stubs;

namespace StudentAPI.Tests.Utils
{
    public static class StudentUtils
    {
        public static List<Estudiante> GetTestStudents()
        {
            return new List<Estudiante>
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

        public static StudentController GetTestStudentControllerStub()
        {
            StudentController controller = new StudentController(new StudentServiceStub());
            return controller;
        }
    }
}
