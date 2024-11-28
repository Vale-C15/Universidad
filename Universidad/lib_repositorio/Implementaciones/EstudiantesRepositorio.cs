using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstudiantesRepositorio : IEstudiantesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? IAuditoriasRepositorio = null;

        public EstudiantesRepositorio(Conexion conexion, IAuditoriasRepositorio IAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.IAuditoriasRepositorio = IAuditoriasRepositorio;
        }

        public List<Estudiantes> Listar()
        {
            /*IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Estudiantes",
                Referencia = 0,
                Accion = "Listar",

            });*/

            return conexion!.Listar<Estudiantes>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Estudiantes> Buscar(Expression<Func<Estudiantes, bool>> condiciones)
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Estudiantes",
                Referencia = 0,
                Accion = "Buscar",

            });

            return conexion!.Buscar(condiciones);
        }

        public Estudiantes Guardar(Estudiantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Estudiantes",
                Referencia = entidad.Id,
                Accion = "Guardar",

            });

            return entidad;
        }

        public Estudiantes Modificar(Estudiantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Estudiantes",
                Referencia = entidad.Id,
                Accion = "Modificar",

            });

            return entidad;
        }

        public Estudiantes Borrar(Estudiantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Estudiantes",
                Referencia = entidad.Id,
                Accion = "Borrar",

            });

            return entidad;
        }
    }
}
