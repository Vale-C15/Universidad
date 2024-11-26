using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface INivelesPresentacion
    {
        Task<List<Niveles>> Listar();
        Task<List<Niveles>> Buscar(Niveles entidad, string tipo);
        Task<Niveles> Guardar(Niveles entidad);
        Task<Niveles> Modificar(Niveles entidad);
        Task<Niveles> Borrar(Niveles entidad);
    }
}
