using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentaciones
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Comunicaciones
            services.AddScoped<IClases_EstudiantesComunicacion, Clases_EstudiantesComunicacion>();
            services.AddScoped<IEstadosComunicacion, EstadosComunicacion>();
            services.AddScoped<IEstudiantesComunicacion, EstudiantesComunicacion>();
            services.AddScoped<IMateriasComunicacion, MateriasComunicacion>();
            services.AddScoped<INivelesComunicacion, NivelesComunicacion>();
            services.AddScoped<ISalonesComunicacion, SalonesComunicacion>();
            // Presentaciones
            services.AddScoped<IClases_EstudiantesPresentacion, Clases_EstudiantesPresentacion>();
            services.AddScoped<IEstadosPresentacion, EstadosPresentacion>();
            services.AddScoped<IEstudiantesPresentacion, EstudiantesPresentacion>();
            services.AddScoped<IMateriasPresentacion, MateriasPresentacion>();
            services.AddScoped<INivelesPresentacion, NivelesPresentacion>();
            services.AddScoped<ISalonesPresentacion, SalonesPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}