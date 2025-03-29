using Microsoft.EntityFrameworkCore;
using RemindMe.Models;

namespace RemindMe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recordatorio> Recordatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
            modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("contrasena");
            modelBuilder.Entity<Usuario>().Property(u => u.Created_At).HasColumnName("created_at");
            //-------------------------------------------------------------------------------------
            modelBuilder.Entity<Recordatorio>().ToTable("recordatorios");

            modelBuilder.Entity<Recordatorio>().Property(r => r.Titulo).HasColumnName("titulo");
            modelBuilder.Entity<Recordatorio>().Property(r => r.Descripcion).HasColumnName("descripcion");
            modelBuilder.Entity<Recordatorio>().Property(r => r.Fecha_Hora).HasColumnName("fecha_hora");
            modelBuilder.Entity<Recordatorio>().Property(r => r.Created_At).HasColumnName("created_at");


        }
    }
}
