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
    }
}