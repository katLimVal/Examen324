using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ejercicio3_324.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<cuenta> cuenta { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<transaccion> transaccion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cuenta>()
                .Property(e => e.tipo_cuenta)
                .IsUnicode(false);

            modelBuilder.Entity<cuenta>()
                .HasMany(e => e.transaccion)
                .WithOptional(e => e.cuenta)
                .HasForeignKey(e => e.cuenta_origen_id);

            modelBuilder.Entity<cuenta>()
                .HasMany(e => e.transaccion1)
                .WithOptional(e => e.cuenta1)
                .HasForeignKey(e => e.cuenta_destino_id);

            modelBuilder.Entity<persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.apellidop)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.apellidom)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .HasMany(e => e.cuenta)
                .WithOptional(e => e.persona)
                .HasForeignKey(e => e.persona_id);
        }
    }
}
