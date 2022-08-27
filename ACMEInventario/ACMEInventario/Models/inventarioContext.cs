using Microsoft.EntityFrameworkCore;

namespace ACMEInventario.Models
{
    public partial class inventarioContext : DbContext
    {
        public inventarioContext()
        {
        }

        public inventarioContext(DbContextOptions<inventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; } = null!;

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodigoBarra).HasColumnName("codigoBarra");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("precioUnitario");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__idSuc__29572725");

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__idTip__286302EC");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("Sucursal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreSucursal)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombreSucursal");
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.ToTable("Tipo_Movimiento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.TipoMovimiento1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipoMovimiento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
