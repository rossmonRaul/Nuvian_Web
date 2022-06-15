using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class CIIADHEL_BDContext : DbContext
    {
        public CIIADHEL_BDContext()
        {
        }

        public CIIADHEL_BDContext(DbContextOptions<CIIADHEL_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notams> Notams { get; set; }
        public virtual DbSet<TbAeropuerto> TbAeropuerto { get; set; }
        public virtual DbSet<TbCaracteristicasEspecializadasAeropuerto> TbCaracteristicasEspecializadasAeropuerto { get; set; }
        public virtual DbSet<TbContacto> TbContacto { get; set; }
        public virtual DbSet<TbDocumentos> TbDocumentos { get; set; }
        public virtual DbSet<TbFrecuencias> TbFrecuencias { get; set; }
        public virtual DbSet<TbPistas> TbPistas { get; set; }
        public virtual DbSet<TbRoles> TbRoles { get; set; }
        public virtual DbSet<TbUsuarios> TbUsuarios { get; set; }

        // Unable to generate entity type for table 'dbo.PruebaFT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TB_Propuesta2Doc'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-I8ROQB4S\\MSSQLSERVER01;Initial Catalog=CIIADHEL_BD;User ID=Chepe;Password=123;Application Name=TestOficialProject;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notams>(entity =>
            {
                entity.HasKey(e => e.IdNotams)
                    .HasName("PK__NOTAMS__A541A1CF58BAC4C5");

                entity.ToTable("NOTAMS");

                entity.Property(e => e.IdNotams).HasColumnName("ID_NOTAMS");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.Notam).IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.Notams)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NOTAMS__ID_Aerop__3A179ED3");
            });

            modelBuilder.Entity<TbAeropuerto>(entity =>
            {
                entity.HasKey(e => e.IdAeropuerto)
                    .HasName("PK__TB_Aerop__FC71A31D08E3F5D8");

                entity.ToTable("TB_Aeropuerto");

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.EstadoAeropuerto)
                    .IsRequired()
                    .HasColumnName("Estado_Aeropuerto")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

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

            modelBuilder.Entity<TbCaracteristicasEspecializadasAeropuerto>(entity =>
            {
                entity.HasKey(e => e.IdCarEspAero)
                    .HasName("PK__TB_Carac__3E48C5FFB20CE8EC");

                entity.ToTable("TB_Caracteristicas_especializadas_aeropuerto");

                entity.Property(e => e.IdCarEspAero).HasColumnName("ID_CarESP_Aero");

                entity.Property(e => e.Combustible)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Coordenada)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EspacioAereo)
                    .IsRequired()
                    .HasColumnName("Espacio_Aereo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.InfoGeneral)
                    .HasColumnName("Info_General")
                    .IsUnicode(false);

                entity.Property(e => e.InfoTorre)
                    .HasColumnName("Info_Torre")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NormaGeneral)
                    .HasColumnName("Norma_General")
                    .IsUnicode(false);

                entity.Property(e => e.NormaParticular)
                    .HasColumnName("Norma_Particular")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.TbCaracteristicasEspecializadasAeropuerto)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .HasConstraintName("FK__TB_Caract__ID_Ae__2EA5EC27");
            });

            modelBuilder.Entity<TbContacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PK__TB_Conta__20EEEB111BF69733");

                entity.ToTable("TB_Contacto");

                entity.Property(e => e.IdContacto).HasColumnName("ID_Contacto");

                entity.Property(e => e.DireccionExacta)
                    .IsRequired()
                    .HasColumnName("Direccion_Exacta")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Horario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.NumeroTelefono1)
                    .HasColumnName("Numero_Telefono1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono2)
                    .HasColumnName("Numero_Telefono2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.TbContacto)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Contac__ID_Ae__373B3228");
            });

            modelBuilder.Entity<TbDocumentos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Documentos");

                entity.HasIndex(e => e.Id2)
                    .HasName("UQ__TB_Docum__C49703DD62CAC56F")
                    .IsUnique();

                entity.Property(e => e.Extension)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id2).HasColumnName("ID2");

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.IdDocumento)
                    .HasColumnName("ID_Documento")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAeropuerto)
                    .HasConstraintName("FK__TB_Docume__ID_Ae__13F1F5EB");
            });

            modelBuilder.Entity<TbFrecuencias>(entity =>
            {
                entity.HasKey(e => e.IdFrecuencia)
                    .HasName("PK__TB_Frecu__DDAA8889ED632818");

                entity.ToTable("TB_Frecuencias");

                entity.Property(e => e.IdFrecuencia).HasColumnName("ID_Frecuencia");

                entity.Property(e => e.Frecuencia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.TipoFrecuencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.TbFrecuencias)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Frecue__ID_Ae__44952D46");
            });

            modelBuilder.Entity<TbPistas>(entity =>
            {
                entity.HasKey(e => e.IdPista)
                    .HasName("PK__TB_Pista__3C499C466D625359");

                entity.ToTable("TB_Pistas");

                entity.Property(e => e.IdPista).HasColumnName("ID_Pista");

                entity.Property(e => e.AsdaRwy1).HasColumnName("ASDA_Rwy_1");

                entity.Property(e => e.AsdaRwy2).HasColumnName("ASDA_Rwy_2");

                entity.Property(e => e.Elevacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.LdaRwy1).HasColumnName("LDA_Rwy_1");

                entity.Property(e => e.LdaRwy2).HasColumnName("LDA_Rwy_2");

                entity.Property(e => e.Pista)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SuperficiePista)
                    .HasColumnName("Superficie_Pista")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TodaRwy1).HasColumnName("TODA_Rwy_1");

                entity.Property(e => e.TodaRwy2).HasColumnName("TODA_Rwy_2");

                entity.Property(e => e.ToraRwy1).HasColumnName("TORA_Rwy_1");

                entity.Property(e => e.ToraRwy2).HasColumnName("TORA_Rwy_2");

                entity.Property(e => e.UltimaActualizacion)
                    .HasColumnName("Ultima_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioActualizacion).HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.TbPistas)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Pistas__ID_Ae__318258D2");
            });

            modelBuilder.Entity<TbRoles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__TB_Roles__202AD220FCD2F0BF");

                entity.ToTable("TB_Roles");

                entity.Property(e => e.IdRol).HasColumnName("ID_Rol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsr)
                    .HasName("PK__TB_Usuar__2A8C692A93A8CE86");

                entity.ToTable("TB_Usuarios");

                entity.Property(e => e.IdUsr).HasColumnName("ID_USR");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdAeropuerto).HasColumnName("ID_Aeropuerto");

                entity.Property(e => e.IdRol).HasColumnName("ID_Rol");

                entity.Property(e => e.NombreUsr)
                    .IsRequired()
                    .HasColumnName("Nombre_USR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.TbUsuarios)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .HasConstraintName("FK__TB_Usuari__ID_Ae__65F62111");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TbUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Usuari__ID_Ro__6501FCD8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
