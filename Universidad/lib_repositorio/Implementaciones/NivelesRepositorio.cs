using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class NivelesRepositorio : INivelesRepositorio
    {
        private Conexion? conexion = null;

        public NivelesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Niveles> Listar()
        {

            return conexion!.Listar<Niveles>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Niveles> Buscar(Expression<Func<Niveles, bool>> condiciones)
        {

            return conexion!.Buscar(condiciones);
        }

        public Niveles Guardar(Niveles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Niveles Modificar(Niveles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();


            return entidad;
        }

        public Niveles Borrar(Niveles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }
    }
}
