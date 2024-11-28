using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class MateriasRepositorio : IMateriasRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? IAuditoriasRepositorio = null;

        public MateriasRepositorio(Conexion conexion, IAuditoriasRepositorio IAuditoriasRepositorio)
        {
            this.conexion = conexion; 
            this.IAuditoriasRepositorio = IAuditoriasRepositorio;
        }

        public List<Materias> Listar()
        {
            /*IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Materias",
                Referencia = 0,
                Accion = "Listar",

            });*/

            return conexion!.Listar<Materias>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Materias> Buscar(Expression<Func<Materias, bool>> condiciones)
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Materias",
                Referencia = 0,
                Accion = "Buscar",

            });

            return conexion!.Buscar(condiciones);
        }

        public Materias Guardar(Materias entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Materias",
                Referencia = entidad.Id,
                Accion = "Guardar",

            });

            return entidad;
        }

        public Materias Modificar(Materias entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Materias",
                Referencia = entidad.Id,
                Accion = "Modificar",

            });

            return entidad;
        }

        public Materias Borrar(Materias entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Materias",
                Referencia = entidad.Id,
                Accion = "Borrar",

            });

            return entidad;
        }
    }
}
