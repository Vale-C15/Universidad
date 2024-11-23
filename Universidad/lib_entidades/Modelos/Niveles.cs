using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Niveles
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Numero { get; set; } // El número hace referencia al nombre del nivel (Semestre 1 = 1)

    }
}
