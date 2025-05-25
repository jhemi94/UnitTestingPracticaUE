namespace StudentAPI.Models
{
    public class Student
    {
        public int CI { get; set; }
        public string Nombre { get; set; }
        public int Nota { get; set; }
        public Student()
        {
            Nombre = string.Empty; // ← Solución más rápida
        }
    }
}
