using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BancoCodigo.Models
{
    public partial class BaseDeDatosBancoContext : DbContext
    {
        public BaseDeDatosBancoContext()
        {
        }

        public BaseDeDatosBancoContext(DbContextOptions<BaseDeDatosBancoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientesTable> ClientesTable { get; set; }
        public virtual DbSet<CuentaTable> CuentaTable { get; set; }
        public virtual DbSet<MovimientoFecha> MovimientoFecha { get; set; }
        public virtual DbSet<MovimientosTable> MovimientosTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-R3GJCGA;Database=BaseDeDatosBanco;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientesTable>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK_PersonaTable");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CuentaTable>(entity =>
            {
                entity.HasKey(e => e.CuentaId);

                entity.Property(e => e.Cliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.CuentaTable)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_CuentaTable_ClientesTable1");
            });

            modelBuilder.Entity<MovimientoFecha>(entity =>
            {
                entity.Property(e => e.Cliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Movimiento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoDisponible).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Movimientos)
                    .WithMany(p => p.MovimientoFecha)
                    .HasForeignKey(d => d.MovimientosId)
                    .HasConstraintName("FK_MovimientoFecha_MovimientosTable");
            });

            modelBuilder.Entity<MovimientosTable>(entity =>
            {
                entity.HasKey(e => e.MovimientosId)
                    .HasName("PK_MovimientoTalbe");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.MovimientosTable)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("FK_MovimientosTable_CuentaTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
