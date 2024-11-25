using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Salones
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Capacidad { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.WriteLine("Por favor, ingresa un nombre para continuar");
                return false;
            }
            if (Capacidad < 0)
            {
                Console.WriteLine("Por favor, ingresa una capacidad para continuar");
                return false;
            }
            return true;
        }

    }
}