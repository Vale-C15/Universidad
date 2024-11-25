using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorio.Implementaciones
{
    public class RolesRepositorio : IRolesRepositorio
    {
        private Conexion? conexion = null;

        public RolesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Roles> Listar()
        {

            return conexion!.Listar<Roles>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones)
        {


            return conexion!.Buscar(condiciones);
        }

        public Roles Guardar(Roles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();


            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }
    }
}
