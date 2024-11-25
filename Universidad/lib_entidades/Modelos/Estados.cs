using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Estados
    {
        [Key] public int Id { get; set; } // 1. Activo     2. Inactivo
        public string? Nombre { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                Console.WriteLine("Por favor, registra el estudiante para continuar");
                return false;
            }

            return true;
        }

    }
}