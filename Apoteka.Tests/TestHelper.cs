using Apoteka.DLL;
using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Tests
{
    public class TestHelper
    {
        public ApotekaContext Context { get; set; }

        public TestHelper()
        {
            var options = new DbContextOptionsBuilder<ApotekaContext>()
                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
                     .Options;
            this.Context = new ApotekaContext(options);
            this.Context = this.PopulateData(Context);
        }

        public ApotekaContext PopulateData(ApotekaContext context)
        {
            context.Klijent.Add(new Klijent { KlijentId = 1, BrojZdravstveneIskaznice = 268458682, DatumRodjenja = new DateTime(1996, 3, 30), Ime = "Ante", Prezime = "Antic "});
            context.Klijent.Add(new Klijent { KlijentId = 2, BrojZdravstveneIskaznice = 317452862, DatumRodjenja = new DateTime(1995, 2, 20), Ime = "Ivana", Prezime = "Ivic "});

            context.RadnoMjesto.Add(new RadnoMjesto { RadnoMjestoId = 1, Naziv = "Blagajnik", OvlastNarucivanja = false });
            context.RadnoMjesto.Add(new RadnoMjesto { RadnoMjestoId = 2, Naziv = "Vlasnik", OvlastNarucivanja = true });

            context.Korisnik.Add(new Korisnik { KorisnikId = 1, RadnoMjestoId = 1, Ime = "Mijo", Prezime = "Mijic", DatumRodjenja = new DateTime(1994, 1, 10), });
            context.Korisnik.Add(new Korisnik { KorisnikId = 2, RadnoMjestoId = 2, Ime = "Pero", Prezime = "Peric", DatumRodjenja = new DateTime(1993, 12, 21), });

            context.Proizvodjac.Add(new Proizvodjac { ProizvodjacId = 1, Adresa = "Brune Busica 5, Zagreb", Naziv = "Marinini lijekovi" });
            context.Proizvodjac.Add(new Proizvodjac { ProizvodjacId = 2, Adresa = "Splitska 32", Naziv = "Medica d.o.o." });

            context.Lijek.Add(new Lijek {LijekId = 1, Cijena= 100, FarmaceutskoIme="Paracetamol", TrgovackoIme="Lekadol 500mg", Jacina= "500mg", Kolicina= 25, ReferencaUputa="https:\\www.gooogle.com", ProizvodjacId= 1 });
            context.Lijek.Add(new Lijek {LijekId = 2, Cijena= 89, FarmaceutskoIme="Ibuprofen", TrgovackoIme="Brufen 600mg", Jacina= "600mg", Kolicina= 20, ReferencaUputa="https:\\www.facebook.com", ProizvodjacId= 2 });

            context.Nabavljac.Add(new Nabavljac { NabavljacId = 1, Adresa = "Nabavljacka 1", Iban= "HR90273488392", Naziv="Portus nabava d.o.o." });
            context.Nabavljac.Add(new Nabavljac { NabavljacId = 2, Adresa = "Nabavljacka 87", Iban= "HR90273488334", Naziv="Hades nabava d.o.o." });

            context.Narudzbenica.Add(new Narudzbenica { NarudzbenicaId = 1, NabavljacId= 1, KorisnikId = 1, AdresaDostave = "Andrina 1", DatumIvrijemeIzdavanja= new DateTime(2018, 4, 6, 10, 20, 20)});
            context.Narudzbenica.Add(new Narudzbenica { NarudzbenicaId = 2, NabavljacId= 2, KorisnikId = 2, AdresaDostave = "Grada Meinza 10", DatumIvrijemeIzdavanja= new DateTime(2018, 4, 8, 12, 30, 20)});

            context.Racun.Add(new Racun { RacunId = 1, DatumIvrijemeIzdavanja = new DateTime(2018, 5, 5, 5, 5, 5), KorisnikId = 1, KlijentId = 1});
            context.Racun.Add(new Racun { RacunId = 2, DatumIvrijemeIzdavanja = new DateTime(2018, 6, 6, 6, 6, 6), KorisnikId = 2, KlijentId = 2});

            context.SaveChanges();
            return context;
        }

    }
}
