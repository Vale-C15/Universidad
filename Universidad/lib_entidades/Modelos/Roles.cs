using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace lib_entidades.Modelos
{
    public class Roles
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Listar { get; set; }
        public bool Buscar { get; set; }
        public bool Eliminar { get; set; }
        public bool Modificar { get; set; }
     
    }
}
