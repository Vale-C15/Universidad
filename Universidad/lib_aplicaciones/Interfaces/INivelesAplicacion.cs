using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface INivelesAplicacion
    {
        void Configurar(string string_conexion);
        List<Niveles> Listar();
        List<Niveles> Buscar(Niveles entidad, string tipo);
        Niveles Guardar(Niveles entidad);
        Niveles Modificar(Niveles entidad);
        Niveles Borrar(Niveles entidad);
    }
}