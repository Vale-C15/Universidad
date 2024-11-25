using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class MateriasAplicacion : IMateriasAplicacion
    {
        private IMateriasRepositorio? iRepositorio = null;
        public MateriasAplicacion(IMateriasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }
        public Materias Borrar(Materias entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Materias Guardar(Materias entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Materias> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Materias> Buscar(Materias entidad, String tipo)
        {
            Expression<Func<Materias, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "NOMBRE":
                    condiciones = x => x.Nombre! == entidad.Nombre!; break;
                default:
                    condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Materias Modificar(Materias entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}