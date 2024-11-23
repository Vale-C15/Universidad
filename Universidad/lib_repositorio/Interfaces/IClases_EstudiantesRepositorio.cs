using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IClases_EstudiantesRepositorio
    {
        void Configurar(string string_conexion);
        List<Clases_Estudiantes> Listar();
        List<Clases_Estudiantes> Buscar(Expression<Func<Clases_Estudiantes, bool>>condiciones);
        Clases_Estudiantes Guardar(Clases_Estudiantes entidad);
        Clases_Estudiantes Modificar(Clases_Estudiantes entidad);
        Clases_Estudiantes Borrar(Clases_Estudiantes entidad);
    }
}
