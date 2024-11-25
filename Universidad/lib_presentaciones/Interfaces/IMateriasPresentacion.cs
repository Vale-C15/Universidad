using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IMateriasPresentacion
    {
        Task<List<Materias>> Listar();
        Task<List<Materias>> Buscar(Materias entidad, string tipo);
        Task<Materias> Guardar(Materias entidad);
        Task<Materias> Modificar(Materias entidad);
        Task<Materias> Borrar(Materias entidad);
    }
}
