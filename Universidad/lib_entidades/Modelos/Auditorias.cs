using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tabla { get; set; }
        public int Referencia { get; set; }
        public string? Accion { get; set; }
    }
}
