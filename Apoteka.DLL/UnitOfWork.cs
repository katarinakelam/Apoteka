using Apoteka.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apoteka.DLL
{
    public class UnitOfWork : IDisposable
    {
        private ApotekaContext context = new ApotekaContext();

        private GenericRepository<Klijent> klijentRepository;
        public GenericRepository<Klijent> KlijentRepository
        {
            get
            {

                if (this.klijentRepository == null)
                {
                    this.klijentRepository = new GenericRepository<Klijent>(context);
                }
                return klijentRepository;
            }
        }

        private GenericRepository<Korisnik> korisnikRepository;
        public GenericRepository<Korisnik> KorisnikRepository
        {
            get
            {
                if (this.korisnikRepository == null)
                {
                    this.korisnikRepository = new GenericRepository<Korisnik>(context);
                }
                return korisnikRepository;
            }
        }

        private GenericRepository<Lijek> lijekRepository;
        public GenericRepository<Lijek> LijekRepository
        {
            get
            {
                if (this.lijekRepository == null)
                {
                    this.lijekRepository = new GenericRepository<Lijek>(context);
                }
                return lijekRepository;
            }
        }

        private GenericRepository<Nabavljac> nabavljacRepository;
        public GenericRepository<Nabavljac> NabavljacRepository
        {
            get
            {
                if (this.nabavljacRepository == null)
                {
                    this.nabavljacRepository = new GenericRepository<Nabavljac>(context);
                }
                return nabavljacRepository;
            }
        }

        private GenericRepository<Narudzbenica> narudzbenicaRepository;
        public GenericRepository<Narudzbenica> NarudzbenicaRepository
        {
            get
            {
                if (this.narudzbenicaRepository == null)
                {
                    this.narudzbenicaRepository = new GenericRepository<Narudzbenica>(context);
                }
                return narudzbenicaRepository;
            }
        }
        private GenericRepository<NarudzbenicaLijek> narudzbenicaLijekRepository;
        public GenericRepository<NarudzbenicaLijek> NarudzbenicaLijekRepository
        {
            get
            {
                if (this.narudzbenicaLijekRepository == null)
                {
                    this.narudzbenicaLijekRepository = new GenericRepository<NarudzbenicaLijek>(context);
                }
                return narudzbenicaLijekRepository;
            }
        }
        private GenericRepository<Proizvodjac> proizvodjacRepository;
        public GenericRepository<Proizvodjac> ProizvodjacRepository
        {
            get
            {
                if (this.proizvodjacRepository == null)
                {
                    this.proizvodjacRepository = new GenericRepository<Proizvodjac>(context);
                }
                return proizvodjacRepository;
            }
        }
        private GenericRepository<Racun> racunRepository;
        public GenericRepository<Racun> RacunRepository
        {
            get
            {
                if (this.racunRepository == null)
                {
                    this.racunRepository = new GenericRepository<Racun>(context);
                }
                return racunRepository;
            }
        }
        private GenericRepository<RacunLijek> racunLijekRepository;
        public GenericRepository<RacunLijek> RacunLijekRepository
        {
            get
            {
                if (this.racunLijekRepository == null)
                {
                    this.racunLijekRepository = new GenericRepository<RacunLijek>(context);
                }
                return racunLijekRepository;
            }
        }
        private GenericRepository<RadnoMjesto> radnoMjestoRepository;
        public GenericRepository<RadnoMjesto> RadnoMjestoRepository
        {
            get
            {
                if (this.radnoMjestoRepository == null)
                {
                    this.radnoMjestoRepository = new GenericRepository<RadnoMjesto>(context);
                }
                return radnoMjestoRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
