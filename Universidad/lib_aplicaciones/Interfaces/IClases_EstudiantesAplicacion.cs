using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IClases_EstudiantesAplicacion
    {
        void Configurar(string string_conexion);
        List<Clases_Estudiantes> Listar();
        List<Clases_Estudiantes> Buscar(Clases_Estudiantes entidad, string tipo);
        Clases_Estudiantes Guardar(Clases_Estudiantes entidad);
        Clases_Estudiantes Modificar(Clases_Estudiantes entidad);
        Clases_Estudiantes Borrar(Clases_Estudiantes entidad);
    }
}
