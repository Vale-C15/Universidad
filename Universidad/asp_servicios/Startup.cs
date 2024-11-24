using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
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
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IClases_EstudiantesRepositorio, Clases_EstudiantesRepositorio>();
            services.AddScoped<IEstudiantesRepositorio, EstudiantesRepositorio>();
            services.AddScoped<IEstadosRepositorio, EstadosRepositorio>();
            services.AddScoped<IMateriasRepositorio, MateriasRepositorio>();
            services.AddScoped<INivelesRepositorio, NivelesRepositorio>();
            services.AddScoped<ISalonesRepositorio, SalonesRepositorio>();
           // services.AddScoped<IAuditoriasRepositorio, AuditoriasRepositorio>();

            // Aplicaciones
            services.AddScoped<IClases_EstudiantesAplicacion, Clases_EstudiantesAplicacion>();
            services.AddScoped<IEstudiantesAplicacion, EstudiantesAplicacion>();
            services.AddScoped<IEstadosAplicacion, EstadosAplicacion>();
            services.AddScoped<IMateriasAplicacion, MateriasAplicacion>();
            services.AddScoped<INivelesAplicacion, NivelesAplicacion>();
            services.AddScoped<ISalonesAplicacion, SalonesAplicacion>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();
            Conexion Conexion = new Conexion();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}