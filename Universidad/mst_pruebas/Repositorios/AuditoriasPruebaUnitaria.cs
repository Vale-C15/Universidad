using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_prueba.Nucleo;

namespace mst_prueba.Repositorio
{
    [TestClass]
    public class AuditoriasPruebaUnitaria
    {
        private IAuditoriasRepositorio? iRepositorio = null;
        private Auditorias? entidad = null;
        private List<Auditorias>? lista = null;


        public AuditoriasPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iRepositorio = new AuditoriasRepositorio(conexion);
        }


        [TestMethod]
       
        public void Guardar()
        {
            entidad = new Auditorias()
            {
                Fecha = DateTime.Now,
                Tabla = "Test",
                Referencia = 0,
                Accion = "Test"
            };
            entidad = iRepositorio!.Guardar(entidad!);
            Assert.IsTrue(entidad.Id != 0);

        }
    }
}