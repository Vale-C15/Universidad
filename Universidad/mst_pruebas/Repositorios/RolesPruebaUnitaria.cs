using lib_entidades.Modelos;
using lib_repositorio.Implementaciones;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class RolesPruebaUnitaria
    {
        private IRolesRepositorio? iRepositorio = null;
        private Roles? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;
        private List<Roles>? lista = null;

        public RolesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            iRepositorio = new RolesRepositorio(conexion, iAuditoriasRepositorio);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }
        private void Guardar()
        {
            entidad = new Roles()
            {
                Nombre = "Test",
                Listar = true,
                Buscar = true,
                Eliminar = true,
                Modificar = true
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Listar()
        {
            lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        private void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Modificar()
        {
            entidad!.Nombre = entidad.Nombre + "Mod ";
            entidad = iRepositorio!.Modificar(entidad!);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);
            Assert.IsTrue(entidad.Id != 0);
        }
    }
}