﻿using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios
{
    public partial class Conexion : DbContext
    {
        private int tamaño = 20;
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected DbSet<Clases_Estudiantes>? Clases_Estudiantes { get; set; }
        protected DbSet<Estados>? Estados { get; set; }
        protected DbSet<Estudiantes>? Estudiantes { get; set; }
        protected DbSet<Materias>? Materias { get; set; }
        protected DbSet<Niveles>? Niveles { get; set; }
        protected DbSet<Salones>? Salones { get; set; }
        protected DbSet<Auditorias>? Auditorias { get; set; }
        protected DbSet<Usuarios>? Usuarios { get; set; }
        protected DbSet<Roles>? Roles { get; set; }


        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>()
                .Take(tamaño)
                .ToList();
        }

        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>()
                .Where(condiciones)
                .Take(tamaño)
                .ToList();
        }

        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}