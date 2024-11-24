using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using mst_prueba.Nucleo;

namespace mst_prueba.Repositorio
{
    [TestClass]
    public class EstudiantessPruebaUnitaria
    {
        private IEstudiantesRepositorio? iRepositorio = null;
        private Estudiantes? entidad = null;
        private List<Estudiantes>? lista = null;

        public EstudiantessPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iRepositorio = new EstudiantesRepositorio(conexion);
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
            entidad = new Estudiantes()
            {
                Cedula = "1111",
                Nombre = "Test",
                Carnet = "1111",
                Nivel = 1,
                Estado = 1
    };
            entidad = iRepositorio!.Guardar(entidad!);
            Assert.IsTrue(entidad.Id != 0);

        }

        public void Modificar()
        {
            entidad!.Nombre = entidad.Nombre + " " + DateTime.Now.ToString();
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
