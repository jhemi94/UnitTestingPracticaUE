namespace StudentAPI.Models
{
    public class Estudiante
    {
        public int CI { get; set; }
        public string Nombre { get; set; }
        public int Nota { get; set; }
        public Estudiante()
        {
            Nombre = string.Empty; // ← Solución más rápida
        }
    }
}
