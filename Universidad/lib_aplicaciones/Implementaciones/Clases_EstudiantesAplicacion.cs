using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class Clases_EstudiantesAplicacion : IClases_EstudiantesAplicacion
    {
        private IClases_EstudiantesRepositorio? iRepositorio = null;
        public Clases_EstudiantesAplicacion(IClases_EstudiantesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar (string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }
        public Clases_Estudiantes Borrar(Clases_Estudiantes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Clases_Estudiantes Guardar(Clases_Estudiantes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad = Calcular(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Clases_Estudiantes> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Clases_Estudiantes> Buscar(Clases_Estudiantes entidad, String tipo)
        {
            Expression<Func<Clases_Estudiantes, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "ESTUDIANTE":
                    condiciones = x => x.Estudiante! == entidad.Estudiante!; break;
                default:
                    condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Clases_Estudiantes Modificar(Clases_Estudiantes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
        private Clases_Estudiantes Calcular(Clases_Estudiantes entidad)
        {
            entidad.NotaFinal = (entidad.Nota1 +
                entidad.Nota2 +
                entidad.Nota3 +
                entidad.Nota4 +
                entidad.Nota5) / 5;
            return entidad;
        }
    }
}




