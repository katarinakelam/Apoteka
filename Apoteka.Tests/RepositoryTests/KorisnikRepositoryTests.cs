using System;
using System.Linq;
using Apoteka.DLL.Repositories;
using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Apoteka.Tests.RepositoryTests
{
    [TestClass]
    public class KorisnikRepositoryTests
    {
        [TestMethod]
        public void CreateRepositoryTest()
        {
            var testHelper = new TestHelper();
            var repository = new KorisnikRepository(testHelper.Context);

            Assert.IsNotNull(repository, "repository is null");
        }

        [TestMethod]
        public void AddKorisnikToRepositoryTest()
        {
            //Create repository
            var testHelper = new TestHelper();
            var repository = new KorisnikRepository(testHelper.Context);

            //Create korisnik for adding
            var korisnikId = repository.GetLast() + 1;
            var korisnikToAdd = new Korisnik { KorisnikId = korisnikId, RadnoMjestoId = 2, DatumRodjenja = new DateTime(1994, 3, 3), Ime = "Miro", Prezime = "Miric" };

            //Add korisnik to repository
            repository.Create(korisnikToAdd);

            //Check if korisnik is added to the database
            var korisnikFromDb = repository.Get(korisnikId);
            Assert.IsNotNull(korisnikFromDb, "korisnik from database is null");
            Assert.AreEqual(korisnikToAdd.Ime, korisnikFromDb.Ime);
        }
    }
}
