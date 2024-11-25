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
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private Conexion? conexion = null;

        public UsuariosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Usuarios> Listar()
        {

            return conexion!.Listar<Usuarios>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Usuarios> Buscar(Expression<Func<Usuarios, bool>> condiciones)
        {


            return conexion!.Buscar(condiciones);
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();


            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            return entidad;
        }
    }
}
