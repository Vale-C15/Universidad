using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosAplicacion
    {
        void Configurar(string string_conexion);
        List<Estados> Listar();
        List<Estados> Buscar(Estados entidad, string tipo);
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}
