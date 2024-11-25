using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class NivelesRepositorio : INivelesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? IAuditoriasRepositorio = null;

        public NivelesRepositorio(IAuditoriasRepositorio IAuditoriasRepositorio)
        {
            this.IAuditoriasRepositorio = IAuditoriasRepositorio;
        }

        public NivelesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Niveles> Listar()
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Niveles",
                Referencia = 0,
                Accion = "Listar",

            });

            return conexion!.Listar<Niveles>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Niveles> Buscar(Expression<Func<Niveles, bool>> condiciones)
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Niveles",
                Referencia = 0,
                Accion = "Buscar",

            });

            return conexion!.Buscar(condiciones);
        }

        public Niveles Guardar(Niveles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Niveles",
                Referencia = entidad.Id,
                Accion = "Guardar",

            });

            return entidad;
        }

        public Niveles Modificar(Niveles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Niveles",
                Referencia = entidad.Id,
                Accion = "Modificar",

            });

            return entidad;
        }

        public Niveles Borrar(Niveles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Niveles",
                Referencia = entidad.Id,
                Accion = "Borrar",

            });

            return entidad;
        }
    }
}
