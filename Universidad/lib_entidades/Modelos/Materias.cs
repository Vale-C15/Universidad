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
    }
}
