using Moq;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using StudentAPI.Tests.Utils;

namespace StudentAPI.Tests.Controllers
{
    public class StudentControllerTests
    {
        [Fact]
        public void Estudiante_ConNotaMayorA51_DeberiaAprobar()
        {
            // Arrange
            StudentController controller = StudentUtils.GetTestStudentControllerStub();
            int studentCI = 10345214; // Fraya tiene nota 95

            // Act
            var result = controller.HasApproved(studentCI);

            // Assert
            Assert.IsType<bool>(result); // Debe ser un booleano
            Assert.True(result); // Debe aprobar
        }

        [Fact]
        public void Estudiante_ConNotaMenorA51_NoDeberiaAprobar()
        {
            // Arrange
            StudentController controller = StudentUtils.GetTestStudentControllerStub();
            int studentCI = 56744323; // Maria tiene nota 45

            // Act
            var result = controller.HasApproved(studentCI);

            // Assert
            Assert.IsType<bool>(result); // Debe ser un booleano
            Assert.False(result); // No debe aprobar
        }

        [Fact]
        public void Estudiante_ElNombreDebeSerElIngresado()
        {
            // Arrange
            var mock = new Mock<IStudentService>();
            var estudianteEsperado = new Student
            {
                CI = 56334678,
                Nombre = "Estefania Sarate",
                Nota = 80
            };

            mock.Setup(s => s.GetByCi(56334678)).Returns(estudianteEsperado);

            var controller = new StudentController(mock.Object);

            // Act
            var resultado = controller.GetByCi(56334678);

            // Assert
            Assert.Equal("Estefania Sarate", resultado.Nombre);
        }

        [Fact]
        public void Estudiante_ElCIDebeSerElIngresado()
        {
            // Arrange
            var mock = new Mock<IStudentService>();
            var estudianteEsperado = new Student
            {
                CI = 65432123,
                Nombre = "Pedro Rojas",
                Nota = 65
            }; 

            mock.Setup(s => s.GetByCi(65432123)).Returns(estudianteEsperado);

            var controller = new StudentController(mock.Object);

            // Act
            var resultado = controller.GetByCi(65432123);

            // Assert
            Assert.Equal(65432123, resultado.CI);
        }


    }
}
