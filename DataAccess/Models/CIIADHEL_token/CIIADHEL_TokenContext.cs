using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_token
{
    public partial class CIIADHEL_TokenContext : DbContext
    {
        public CIIADHEL_TokenContext()
        {
        }

        public CIIADHEL_TokenContext(DbContextOptions<CIIADHEL_TokenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAeroFavoritos> TbAeroFavoritos { get; set; }
        public virtual DbSet<TbDispositivo> TbDispositivo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-I8ROQB4S\\MSSQLSERVER01;Initial Catalog=CIIADHEL_Token;User ID=Chepe;Password=123;Application Name=TestOficialProject;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAeroFavoritos>(entity =>
            {
                entity.HasKey(e => e.IdFavorito)
                    .HasName("PK__TB_Aero___FA228CC5AB774B94");

                entity.ToTable("TB_Aero_Favoritos");

                entity.Property(e => e.IdFavorito).HasColumnName("ID_Favorito");

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.Identificador)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreIcao)
                    .IsRequired()
                    .HasColumnName("NombreICAO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NombreOaci)
                    .IsRequired()
                    .HasColumnName("Nombre_OACI")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");
            });

            modelBuilder.Entity<TbDispositivo>(entity =>
            {
                entity.HasKey(e => e.IdDispositivo)
                    .HasName("PK__TB_Dispo__262CC3D6FC7CCC24");

                entity.ToTable("TB_Dispositivo");

                entity.HasIndex(e => new { e.Identificador, e.Token })
                    .HasName("UQ__TB_Dispo__83DC0131C3B8EFC4")
                    .IsUnique();

                entity.Property(e => e.IdDispositivo).HasColumnName("ID_Dispositivo");

                entity.Property(e => e.Identificador)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
