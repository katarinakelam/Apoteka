using System;
using System.Configuration;
using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Apoteka.DLL
{
    public partial class ApotekaContext : DbContext
    {
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = ConfigurationManager.ConnectionStrings["Apoteka"].ConnectionString;
            }
        }

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
