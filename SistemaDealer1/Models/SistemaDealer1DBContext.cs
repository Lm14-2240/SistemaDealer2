using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class SistemaDealer1DBContext : DbContext
    {
        public SistemaDealer1DBContext() : base("name=SistemaDealerDataContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SistemaDealer1DBContext>());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Combustible> Combustibles { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Sucursal> Sucursals { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Transmision> Transmisions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>().HasRequired(x => x.Cliente);
            modelBuilder.Entity<Factura>().HasRequired(x => x.Cliente);
            modelBuilder.Entity<Factura>().HasRequired(x => x.Vehiculo);
            modelBuilder.Entity<Factura>().HasRequired(x => x.Empleado);
        }
        
    }
}