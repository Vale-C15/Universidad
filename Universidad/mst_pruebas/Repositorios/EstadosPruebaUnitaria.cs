using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_prueba.Nucleo;

namespace mst_prueba.Repositorio
{
    [TestClass]
    public class EstadosPruebaUnitaria
    {
        private IEstadosRepositorio? iRepositorio = null;
        private Estados? entidad = null;
        private List<Estados>? lista = null;


        public EstadosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iRepositorio = new EstadosRepositorio(conexion);
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
            entidad = new Estados()
            {
                Nombre = "Test"
            };
            entidad = iRepositorio!.Guardar(entidad!);
            Assert.IsTrue(entidad.Id != 0);

        }

        public void Modificar()
        { 
            entidad!.Nombre = entidad.Nombre + "Mod ";
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