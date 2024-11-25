using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Niveles
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Numero { get; set; } // El número hace referencia al nombre del nivel (Semestre 1 = 1)

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.WriteLine("Por favor, ingresa un nombre para continuar");
                return false;
            }
            if (Numero < 0)
            {
                Console.WriteLine("Por favor, ingresa un semestre para continuar");
                return false;
            }
            return true;
        }

    }
}
