using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class MateriasRepositorio : IMateriasRepositorio
    {
        private Conexion? conexion = null;

        public MateriasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Materias> Listar()
        {

            return conexion!.Listar<Materias>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Materias> Buscar(Expression<Func<Materias, bool>> condiciones)
        {

            return conexion!.Buscar(condiciones);
        }

        public Materias Guardar(Materias entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Materias Modificar(Materias entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Materias Borrar(Materias entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }
    }
}
