using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_prueba.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class Clases_EstudiantesPruebaUnitaria
    {
        private IClases_EstudiantesRepositorio? iRepositorio = null;
        private Clases_Estudiantes? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;
        private List<Clases_Estudiantes>? lista = null;

        public Clases_EstudiantesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            iRepositorio = new Clases_EstudiantesRepositorio(conexion, iAuditoriasRepositorio);
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
            entidad!.Nota1 = 2.0m;
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