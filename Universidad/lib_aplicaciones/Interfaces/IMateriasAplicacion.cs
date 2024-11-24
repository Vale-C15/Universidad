using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IMateriasAplicacion
    {
        void Configurar(string string_conexion);
        List<Materias> Listar();
        List<Materias> Buscar(Materias entidad, string tipo);
        Materias Guardar(Materias entidad);
        Materias Modificar(Materias entidad);
        Materias Borrar(Materias entidad);
    }
}