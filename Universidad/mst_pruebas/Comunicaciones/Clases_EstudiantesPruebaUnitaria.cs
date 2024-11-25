using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class Clases_EstudiantesPruebaUnitaria
    {
        private IClases_EstudiantesComunicacion? iComunicacion = null;
        private Clases_Estudiantes? entidad = null;
        private List<Clases_Estudiantes>? lista = null;
        public Clases_EstudiantesPruebaUnitaria()
        {
            iComunicacion = new Clases_EstudiantesComunicacion();
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
            lista = JsonConversor.ConvertirAObjeto<List<Clases_Estudiantes>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "ESTUDIANTE";
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Clases_Estudiantes>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Clases_Estudiantes()
            {
                Estudiante = 1,
                Salon = 1,
                Materia = 1,
                Nota1 = 1.0m,
                Nota2 = 1.0m,
                Nota3 = 1.0m,
                Nota4 = 1.0m,
                Nota5 = 1.0m,
                NotaFinal = 1.0m
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Clases_Estudiantes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.NotaFinal = 3.0m;
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Clases_Estudiantes>(
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
            entidad = JsonConversor.ConvertirAObjeto<Clases_Estudiantes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}
