using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface ISalonesAplicacion
    {
        void Configurar(string string_conexion);
        List<Salones> Listar();
        List<Salones> Buscar(Salones entidad, string tipo);
        Salones Guardar(Salones entidad);
        Salones Modificar(Salones entidad);
        Salones Borrar(Salones entidad);
    }
}
