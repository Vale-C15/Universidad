using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class SalonesRepositorio : ISalonesRepositorio
    {
        private Conexion? conexion = null;

        public SalonesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Salones> Listar()
        {

            return conexion!.Listar<Salones>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Salones> Buscar(Expression<Func<Salones, bool>> condiciones)
        {


            return conexion!.Buscar(condiciones);
        }

        public Salones Guardar(Salones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();


            return entidad;
        }

        public Salones Modificar(Salones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Salones Borrar(Salones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }
    }
}
