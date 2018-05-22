using System;
using System.Configuration;
using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Apoteka.DLL
{
    /// <summary>
    /// Database context for Apoteka database
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public partial class ApotekaContext : DbContext
    {
        #region Properties
        //Sets of entities in the database
        public virtual DbSet<Klijent> Klijent { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Lijek> Lijek { get; set; }
        public virtual DbSet<Nabavljac> Nabavljac { get; set; }
        public virtual DbSet<Narudzbenica> Narudzbenica { get; set; }
        public virtual DbSet<NarudzbenicaLijek> NarudzbenicaLijek { get; set; }
        public virtual DbSet<Proizvodjac> Proizvodjac { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<RacunLijek> RacunLijek { get; set; }
        public virtual DbSet<RadnoMjesto> RadnoMjesto { get; set; }
        #endregion
        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = ConfigurationManager.ConnectionStrings["Apoteka"].ConnectionString;
            }
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.Property(e => e.KlijentId).ValueGeneratedNever();

                entity.Property(e => e.Ime).IsUnicode(false);

                entity.Property(e => e.Prezime).IsUnicode(false);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.KorisnikId).ValueGeneratedNever();

                entity.Property(e => e.Ime).IsUnicode(false);

                entity.Property(e => e.Prezime).IsUnicode(false);

                entity.HasOne(d => d.RadnoMjesto)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.RadnoMjestoId)
                    .HasConstraintName("FK_Korisnik_RadnoMjesto");
            });

            modelBuilder.Entity<Lijek>(entity =>
            {
                entity.Property(e => e.LijekId).ValueGeneratedNever();

                entity.Property(e => e.FarmaceutskoIme).IsUnicode(false);

                entity.Property(e => e.Jacina).IsUnicode(false);

                entity.Property(e => e.ReferencaUputa).IsUnicode(false);

                entity.Property(e => e.TrgovackoIme).IsUnicode(false);

                entity.HasOne(d => d.Proizvodjac)
                    .WithMany(p => p.Lijek)
                    .HasForeignKey(d => d.ProizvodjacId)
                    .HasConstraintName("FK_Lijek_Proizvodjac");
            });

            modelBuilder.Entity<Nabavljac>(entity =>
            {
                entity.Property(e => e.NabavljacId).ValueGeneratedNever();

                entity.Property(e => e.Adresa).IsUnicode(false);

                entity.Property(e => e.Iban).IsUnicode(false);

                entity.Property(e => e.Naziv).IsUnicode(false);
            });

            modelBuilder.Entity<Narudzbenica>(entity =>
            {
                entity.Property(e => e.NarudzbenicaId).ValueGeneratedNever();

                entity.Property(e => e.AdresaDostave).IsUnicode(false);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Narudzbenica)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Narudzbenica_Korisnik");

                entity.HasOne(d => d.Nabavljac)
                    .WithMany(p => p.Narudzbenica)
                    .HasForeignKey(d => d.NabavljacId)
                    .HasConstraintName("FK_Narudzbenica_Nabavljac");
            });

            modelBuilder.Entity<NarudzbenicaLijek>(entity =>
            {
                entity.HasKey(e => new { e.NarudzbenicaId, e.LijekId });

                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.NarudzbenicaLijek)
                    .HasForeignKey(d => d.LijekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NarudzbenicaLijek_Lijek");

                entity.HasOne(d => d.Narudzbenica)
                    .WithMany(p => p.NarudzbenicaLijek)
                    .HasForeignKey(d => d.NarudzbenicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NarudzbenicaLijek_Narudzbenica");
            });

            modelBuilder.Entity<Proizvodjac>(entity =>
            {
                entity.Property(e => e.ProizvodjacId).ValueGeneratedNever();

                entity.Property(e => e.Adresa).IsUnicode(false);

                entity.Property(e => e.Naziv).IsUnicode(false);
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.Property(e => e.RacunId).ValueGeneratedNever();

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Racun)
                    .HasForeignKey(d => d.KlijentId)
                    .HasConstraintName("FK_Racun_Klijent");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Racun)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Racun_Korisnik");
            });

            modelBuilder.Entity<RacunLijek>(entity =>
            {
                entity.HasKey(e => new { e.RacunId, e.LijekId });

                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.RacunLijek)
                    .HasForeignKey(d => d.LijekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RacunLijek_Lijek");

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.RacunLijek)
                    .HasForeignKey(d => d.RacunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RacunLijek_Racun");
            });

            modelBuilder.Entity<RadnoMjesto>(entity =>
            {
                entity.Property(e => e.RadnoMjestoId).ValueGeneratedNever();

                entity.Property(e => e.Naziv).IsUnicode(false);
            });
        }
    }
}
