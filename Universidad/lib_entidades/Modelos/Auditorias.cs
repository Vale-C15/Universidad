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
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Accion))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Tabla))
            {
                Console.WriteLine("Por favor, ingresa una tabla para continuar");
                return false;
            }
            return true;
        }
    }
}
