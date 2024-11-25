using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Materias
    {
        public string? Nombre { get; set; }
        [Key] public int Id { get; set; }
        public int Creditos { get; set; }
        public int Nivel { get; set; }
        [ForeignKey("Materia")] public Materias? _Materia { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.WriteLine("Por favor, ingresa el nombre para continuar");
                return false;
            }

            if (Creditos < 0 || Creditos > 8)
            {
                Console.WriteLine("Por favor, ingresa un número de créditos para continuar");
                return false;
            }
            if (Nivel < 0)
            {
                Console.WriteLine("Por favor, ingresa un semestre para continuar");
                return false;
            }

            return true;
        }
    }
}
