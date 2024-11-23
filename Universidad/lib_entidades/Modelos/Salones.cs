using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Salones
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Capacidad { get; set; }

    }
}