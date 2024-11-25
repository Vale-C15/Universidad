using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class SalonesRepositorio : ISalonesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? IAuditoriasRepositorio = null;

        public SalonesRepositorio(IAuditoriasRepositorio IAuditoriasRepositorio)
        {
            this.IAuditoriasRepositorio = IAuditoriasRepositorio;
        }

        public SalonesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Salones> Listar()
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Salones",
                Referencia = 0,
                Accion = "Listar",

            });

            return conexion!.Listar<Salones>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Salones> Buscar(Expression<Func<Salones, bool>> condiciones)
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Salones",
                Referencia = 0,
                Accion = "Buscar",

            });

            return conexion!.Buscar(condiciones);
        }

        public Salones Guardar(Salones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Salones",
                Referencia = entidad.Id,
                Accion = "Guardar",

            });

            return entidad;
        }

        public Salones Modificar(Salones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Salones",
                Referencia = entidad.Id,
                Accion = "Modificar",

            });

            return entidad;
        }

        public Salones Borrar(Salones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Salones",
                Referencia = entidad.Id,
                Accion = "Borrar",

            });

            return entidad;
        }
    }
}
