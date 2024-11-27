using lib_entidades.Modelos;
namespace lib_presentaciones.Interfaces
{
    public interface IClases_EstudiantesPresentacion
    {
        Task<List<Clases_Estudiantes>> Listar();
        Task<List<Clases_Estudiantes>> Buscar(Clases_Estudiantes entidad, string tipo);
        Task<Clases_Estudiantes> Guardar(Clases_Estudiantes entidad);
        Task<Clases_Estudiantes> Modificar(Clases_Estudiantes entidad);
        Task<Clases_Estudiantes> Borrar(Clases_Estudiantes entidad);
    }
}