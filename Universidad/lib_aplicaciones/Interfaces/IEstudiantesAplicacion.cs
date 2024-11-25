﻿using lib_entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstudiantesAplicacion
    {
        void Configurar(string string_conexion);
        List<Estudiantes> Listar();
        List<Estudiantes> Buscar(Estudiantes entidad, string tipo);
        Estudiantes Guardar(Estudiantes entidad);
        Estudiantes Modificar(Estudiantes entidad);
        Estudiantes Borrar(Estudiantes entidad);
    }
}
