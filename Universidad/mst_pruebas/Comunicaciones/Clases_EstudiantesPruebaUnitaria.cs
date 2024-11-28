using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class Clases_EstudiantesPruebaUnitaria
    {
        private IClases_EstudiantesComunicacion? iComunicacion = null;
        private Clases_Estudiantes? entidad = null;

        public Clases_EstudiantesPruebaUnitaria()
        {
            iComunicacion = new Clases_EstudiantesComunicacion();
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
            entidad = new Clases_Estudiantes()
            {
                Estudiante = 1,
                Salon = 1,
                Materia = 2,
                Nota1 = 1.0m,
                Nota2 = 1.0m,
                Nota3 = 1.0m,
                Nota4 = 1.0m,
                Nota5 = 1.0m,
                NotaFinal = 1.0m,
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
            datos["Tipo"] = "ESTUDIANTE";
            var respuesta = await iComunicacion!.Buscar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Modificar() 
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nota1 = 2.0m;

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