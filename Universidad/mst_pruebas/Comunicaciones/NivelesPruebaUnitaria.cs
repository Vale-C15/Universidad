using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class NivelesPruebaUnitaria
    {
        private INivelesComunicacion? iComunicacion = null;
        private Niveles? entidad = null;

        public NivelesPruebaUnitaria()
        {
            iComunicacion = new NivelesComunicacion();
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
            entidad = new Niveles()
            {
                Nombre = "Test",
                Numero = 0
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
            entidad!.Nombre = entidad.Nombre + "Mod ";

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