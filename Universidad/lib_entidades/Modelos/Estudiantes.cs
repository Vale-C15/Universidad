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

        [NotMapped] public Niveles? _Nivel { get; set; }
        [NotMapped] public Estados? _Estado { get; set; }

    }
}