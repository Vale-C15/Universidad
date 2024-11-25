using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace lib_entidades.Modelos
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Contrasena { get; set; }

        public int Rol { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }

    }
}
