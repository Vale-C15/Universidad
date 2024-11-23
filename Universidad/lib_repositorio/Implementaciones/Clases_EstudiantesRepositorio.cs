using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;


namespace lib_repositorios.Implementaciones
{
    public class Clases_EstudiantesRepositorio : IClases_EstudiantesRepositorio
    {
        private Conexion? conexion = null;
        public Clases_EstudiantesRepositorio (Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Clases_Estudiantes> Listar()
        {

            return conexion!.Listar<Clases_Estudiantes>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        } 
        public List<Clases_Estudiantes> Buscar(Expression<Func<Clases_Estudiantes, bool>> condiciones)
        {

            return conexion!.Buscar(condiciones);
        }

        public Clases_Estudiantes Guardar(Clases_Estudiantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Clases_Estudiantes Modificar(Clases_Estudiantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Clases_Estudiantes Borrar(Clases_Estudiantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }
    }
}
