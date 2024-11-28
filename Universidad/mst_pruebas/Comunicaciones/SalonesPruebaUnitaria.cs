using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class SalonesPruebaUnitaria
    {
        private ISalonesComunicacion? iComunicacion = null;
        private Salones? entidad = null;

        public SalonesPruebaUnitaria()
        {
            iComunicacion = new SalonesComunicacion();
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
        private async void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Salones()
            {
                Nombre = "Test",
                Capacidad = 0
            };

            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Guardar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Listar()
        {
            var datos = new Dictionary<string, object>();
            var respuesta = await iComunicacion!.Listar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "NOMBRE";
            var respuesta = await iComunicacion!.Buscar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre = entidad.Nombre + " M";

            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Modificar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Borrar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            var respuesta = await iComunicacion!.Borrar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
    }
}