using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades;
using lib_entidades.Modelos;
using lib_utilidades;
namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class NivelesPruebaUnitaria
    {
        private INivelesComunicacion? iComunicacion = null;
        private Niveles? entidad = null;
        private List<Niveles>? lista = null;
        public NivelesPruebaUnitaria()
        {
            iComunicacion = new NivelesComunicacion();
        }
        [TestMethod]
        public void Executar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }
        private void Listar()
        {
            var datos = new Dictionary<string, object>();
            var task = iComunicacion!.Listar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Niveles>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "NOMBRE";
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Niveles>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Niveles()
            {
                Nombre = "Test",
                Numero = 0
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Niveles>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre = entidad.Nombre + "Mod ";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Niveles>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        public void Borrar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Borrar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Niveles>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}
