using lib_entidades.Modelos;
using lib_repositorio.Implementaciones;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class UsuariosPruebaUnitaria
    {
        private IUsuariosRepositorio? iRepositorio = null;
        private Usuarios? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;
        private List<Usuarios>? lista = null;

        public UsuariosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            iRepositorio = new UsuariosRepositorio(conexion, iAuditoriasRepositorio);
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
            entidad = new Usuarios()
            {
                Nombre = "Test",
                Contrasena = "Test"
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