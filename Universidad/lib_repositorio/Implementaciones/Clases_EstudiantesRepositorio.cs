using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;


namespace lib_repositorios.Implementaciones
{
    public class Clases_EstudiantesRepositorio : IClases_EstudiantesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? IAuditoriasRepositorio = null;

        public Clases_EstudiantesRepositorio(Conexion conexion, IAuditoriasRepositorio IAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.IAuditoriasRepositorio = IAuditoriasRepositorio;
        }
        
        public List<Clases_Estudiantes> Listar()
        {
            /*IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Clases_Estudiantes",
                Referencia = 0,
                Accion = "Listar",

            });*/

            return conexion!.Listar<Clases_Estudiantes>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        } 
        public List<Clases_Estudiantes> Buscar(Expression<Func<Clases_Estudiantes, bool>> condiciones)
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Clases_Estudiantes",
                Referencia = 0,
                Accion = "Buscar",

            });

            return conexion!.Buscar(condiciones);
        }

        public Clases_Estudiantes Guardar(Clases_Estudiantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Clases_Estudiantes",
                Referencia = entidad.Id,
                Accion = "Guardar",

            });

            return entidad;
        }

        public Clases_Estudiantes Modificar(Clases_Estudiantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Clases_Estudiantes",
                Referencia = entidad.Id,
                Accion = "Modificar",

            });

            return entidad;
        }

        public Clases_Estudiantes Borrar(Clases_Estudiantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Clases_Estudiantes",
                Referencia = entidad.Id,
                Accion = "Borrar",

            });

            return entidad;
        }
    }
}
