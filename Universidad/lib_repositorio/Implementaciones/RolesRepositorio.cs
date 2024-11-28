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
        private IAuditoriasRepositorio? IAuditoriasRepositorio = null;

        public RolesRepositorio(Conexion conexion, IAuditoriasRepositorio IAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.IAuditoriasRepositorio = IAuditoriasRepositorio;
        }

        public List<Roles> Listar()
        {
            /*IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Roles",
                Referencia = 0,
                Accion = "Listar",

            });*/

            return conexion!.Listar<Roles>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones)
        {
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Roles",
                Referencia = 0,
                Accion = "Buscar",

            });

            return conexion!.Buscar(condiciones);
        }

        public Roles Guardar(Roles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Roles",
                Referencia = entidad.Id,
                Accion = "Guardar",

            });

            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Roles",
                Referencia = entidad.Id,
                Accion = "Modificar",

            });

            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Roles",
                Referencia = entidad.Id,
                Accion = "Borrar",

            });

            return entidad;
        }
    }
}
