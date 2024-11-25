using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Clases_Estudiantes
    {
        [Key] public int Id { get; set; }
        public int Estudiante { get; set; }
        public int Salon { get; set; }
        public int Materia { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Nota4 { get; set; }
        public decimal Nota5 { get; set; }
        public decimal NotaFinal { get; set; }

        [ForeignKey("Estudiante")] public Estudiantes? _Estudiante { get; set; }
        [ForeignKey("Salon")] public Salones? _Salon { get; set; }
        [ForeignKey("Materia")] public Materias? _Materia { get; set; }

        public bool Validar()
        {
            if (Estudiante <= 0)
            {
                Console.Write("Por favor, registra el estudiante para continuar");
                return false;
            }
            if (Salon <= 0)
            {
                Console.Write("Por favor, registra el salon para continuar");
                return false;
            }
            if (Materia <= 0)
            {
                Console.Write("Por favor, registra la materia para continuar");
                return false;
            }

            if (Nota1 < 0.0m || Nota1 > 5.0m ||
                Nota2 < 0.0m || Nota2 > 5.0m ||
                Nota3 < 0.0m || Nota3 > 5.0m ||
                Nota4 < 0.0m || Nota4 > 5.0m ||
                Nota5 < 0.0m || Nota5 > 5.0m)
            {
                Console.Write("Por favor, registra una nota dentro del rango aceptado en la institucion para continuar");
                return false;
            }

            return true;
        }
    }
}