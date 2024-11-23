﻿using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstadosRepositorio : IEstadosRepositorio
    {
        private Conexion? conexion = null;

        public EstadosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Estados> Listar()
        {
            
            return conexion!.Listar<Estados>();
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones)
        {
          

            return conexion!.Buscar(condiciones);
        }

        public Estados Guardar(Estados entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            
            return entidad;
        }

        public Estados Modificar(Estados entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

           
            return entidad;
        }

        public Estados Borrar(Estados entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            

            return entidad;
        }
    }
}
