using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IEstadosRepositorio
    {
        void Configurar(string string_conexion);
        List<Estados> Listar();
        List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones);
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}
