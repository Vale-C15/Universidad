using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Estudiantes
    {
        [Key] public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Carnet { get; set; }
        public int Nivel { get; set; }
        public int Estado { get; set; }

        [ForeignKey("Nivel")] public Niveles? _Nivel { get; set; }
        [ForeignKey("Estado")] public Estados? _Estado { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Cedula))
            {
                Console.WriteLine("Por favor, ingresa tu número de cédula para continuar");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.WriteLine("Por favor, ingresa tu nombre para continuar");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Carnet))
            {
                Console.WriteLine("Por favor, ingresa tu carnet para continuar");
                return false;
            }
            if (Nivel <= 0)
            {
                Console.WriteLine("Por favor, ingresa tu semestre para continuar");
                return false;
            }
            if (Estado <= 0)
            {
                Console.WriteLine("Por favor, registrate para continuar");
                return false;
            }
            return true;
        }
    }
}