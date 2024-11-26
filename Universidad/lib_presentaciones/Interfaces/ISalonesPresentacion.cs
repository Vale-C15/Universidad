using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ISalonesPresentacion
    {
        Task<List<Salones>> Listar();
        Task<List<Salones>> Buscar(Salones entidad, string tipo);
        Task<Salones> Guardar(Salones entidad);
        Task<Salones> Modificar(Salones entidad);
        Task<Salones> Borrar(Salones entidad);
    }
}
