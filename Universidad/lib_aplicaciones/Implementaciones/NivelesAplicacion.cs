using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class NivelesAplicacion : INivelesAplicacion
    {
        private INivelesRepositorio? iRepositorio = null;
        public NivelesAplicacion(INivelesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }
        public Niveles Borrar(Niveles entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Niveles Guardar(Niveles entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Niveles> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Niveles> Buscar(Niveles entidad, String tipo)
        {
            Expression<Func<Niveles, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "NOMBRE":
                    condiciones = x => x.Nombre! == entidad.Nombre!; break;
                default:
                    condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Niveles Modificar(Niveles entidad)
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