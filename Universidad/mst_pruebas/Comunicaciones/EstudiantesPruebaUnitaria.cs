using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class EstudiantesPruebaUnitaria
    {
        private IEstudiantesComunicacion? iComunicacion = null;
        private Estudiantes? entidad = null;

        public EstudiantesPruebaUnitaria()
        {
            iComunicacion = new EstudiantesComunicacion();
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
            entidad = new Estudiantes()
            {
                Cedula = "1111",
                Nombre = "Test",
                Carnet = "1111",
                Nivel = 1,
                Estado = 1
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
            entidad!.Nombre = entidad.Nombre + " " + DateTime.Now.ToString();

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