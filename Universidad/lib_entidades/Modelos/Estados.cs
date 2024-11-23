using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Estados
    {
        [Key] public int Id { get; set; } // 1. Activo     2. Inactivo
        public string? Nombre { get; set; }

    }
}