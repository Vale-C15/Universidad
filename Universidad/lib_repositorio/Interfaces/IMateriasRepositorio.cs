using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IMateriasRepositorio
    {
        void Configurar(string string_conexion);
        List<Materias> Listar();
        List<Materias> Buscar(Expression<Func<Materias, bool>> condiciones);
        Materias Guardar(Materias entidad);
        Materias Modificar(Materias entidad);
        Materias Borrar(Materias entidad);
    }
}
