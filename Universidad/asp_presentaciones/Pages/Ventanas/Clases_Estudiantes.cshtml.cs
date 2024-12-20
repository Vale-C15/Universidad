using lib_entidades;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages.Ventanas
{
    public class Clases_EstudiantesModel : PageModel
    {
        private IClases_EstudiantesPresentacion? iPresentacion = null;

        public Clases_EstudiantesModel(IClases_EstudiantesPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Clases_Estudiantes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Clases_Estudiantes? Actual { get; set; }
        [BindProperty] public Clases_Estudiantes? Filtro { get; set; }
        [BindProperty] public List<Clases_Estudiantes>? Lista { get; set; }
        [BindProperty] public List<Salones>? Salones { get; set; } //Lista de claves foraneas
        [BindProperty] public List<Materias>? Materias { get; set; } //Lista de claves foraneas

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("key");
                if (String.IsNullOrEmpty(variable_session))
                    HttpContext.Session.SetString("key", "Pruebas");

                Filtro!.Estudiante = Filtro!.Estudiante;

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "ESTUDIANTE");
                task.Wait();
                Lista = task.Result;
                CargarCombox();
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                CargarCombox();
                Actual = new Clases_Estudiantes()
                {
                    //Fecha = DateTime.Now,
                };
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                /*if (FormFile != null)
                {
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    Actual!.Imagen = EncodingHelper.ToString(memoryStream.ToArray());
                    memoryStream.Dispose();
                }*/ //para imagen 

                Task<Clases_Estudiantes>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!);
                else
                    task = this.iPresentacion!.Modificar(Actual!);
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //Para claves foraneas
        public void CargarCombox()
        {
            try
            {
                if (!(Salones == null || Salones!.Count <= 0))
                    return;

               Salones = new List<Salones>()
                {
                  new  Salones() { Id = 0, Nombre = " " },
                new  Salones() { Id = 1, Nombre = "K506" },
                new  Salones() { Id = 2, Nombre = "N400" },
                new  Salones() { Id = 3, Nombre = "L203" },
                new  Salones() { Id = 4, Nombre = "M303" }

                };

                if (!(Materias == null || Materias!.Count <= 0))
                    return;

                Materias = new List<Materias>()
                {
                    new  Materias() { Id = 0, Nombre = " " },
                    new  Materias() { Id = 1, Nombre = "K506" },
                    new  Materias() { Id = 2, Nombre = "N400" },
                    new  Materias() { Id = 3, Nombre = "L203" },
                    new  Materias() { Id = 4, Nombre = "M303" }

                };
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirSalon(int id)
        {
            try
            {
                CargarCombox();
                return Salones!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public string ConvertirMateria(int id)
        {
            try
            {
                CargarCombox();
                return Materias!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        /*public string ConvertirActivo(bool valor)
        {
            try
            {
                return valor ? "Activo" : "Inactivo";
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return "Falso";
            }
        }*/
    }
}