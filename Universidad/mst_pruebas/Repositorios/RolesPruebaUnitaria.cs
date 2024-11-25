using lib_entidades.Modelos;
using lib_repositorio.Implementaciones;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_prueba.Nucleo;

namespace mst_prueba.Repositorio
{
    [TestClass]
    public class RolesPruebaUnitaria
    {
        private IRolesRepositorio? iRepositorio = null;
        private Roles? entidad = null;
        private List<Roles>? lista = null;


        public RolesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iRepositorio = new RolesRepositorio(conexion);
        }


        [TestMethod]
        public void Executar()
        {
            Guardar();
            Listar();
            Modificar();
            Borrar();
        }

        private void Listar()
        {
            lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Guardar()
        {
            entidad = new Roles()
            {
                Nombre = "Test",
                Listar = true,
                Buscar = true,
                Eliminar = true,
                Modificar = true

            };
            entidad = iRepositorio!.Guardar(entidad!);
            Assert.IsTrue(entidad.Id != 0);

        }

        public void Modificar()
        { 
            entidad!.Nombre = entidad.Nombre + "Mod ";
            entidad!.Listar = false;
            entidad!.Buscar = false;
            entidad!.Eliminar = false;
            entidad!.Modificar = false;
            entidad = iRepositorio!.Modificar(entidad!);

            Assert.IsTrue(entidad.Id != 0);
        }

        public void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            Assert.IsTrue(entidad.Id != 0);
        }
    }
}