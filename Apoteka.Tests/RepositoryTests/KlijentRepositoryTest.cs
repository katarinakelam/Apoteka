using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Apoteka.DLL;
using Apoteka.DLL.Repositories;
using Apoteka.Model.Models;

namespace Apoteka.Tests.RepositoryTests
{
    /// <summary>
    /// Summary description for KlijentRepositoryTest
    /// </summary>
    [TestClass]
    public class KlijentRepositoryTest
    {
        [TestMethod]
        public void CreateKlijentRepositoryTest()
        {
            var testHelper = new TestHelper();
            var repository = new KlijentRepository(testHelper.Context);

            Assert.IsNotNull(repository, "repository is null");
        }

        [TestMethod]
        public void AddKlijentToKlijentRepositoryTest()
        {
            //Create repository
            var testHelper = new TestHelper();
            var repository = new KlijentRepository(testHelper.Context);

            //Create klijent for adding
            var klijentId = repository.GetLast() + 1;
            var klijentToAdd = new Klijent { KlijentId = klijentId, BrojZdravstveneIskaznice = 41645451, DatumRodjenja = new DateTime( 1994, 3, 3), Ime= "Miro", Prezime = "Miric" };

            //Add klijent to repository
            repository.Create(klijentToAdd);

            //Check if klijent is added to the database
            var klijentFromDb = repository.Get(klijentId);
            Assert.IsNotNull(klijentFromDb, "klijent from database is null");
            Assert.AreEqual(klijentToAdd.Ime, klijentFromDb.Ime);
        }

        [TestMethod]
        public void RemoveKlijentRepositoryTest()
        {
            //Create repository
            var testHelper = new TestHelper();
            var repository = new KlijentRepository(testHelper.Context);

            //Get klijent for deleting
            var klijentId = repository.GetLast();
            var klijentToDelete = repository.Get(klijentId);

            //Delete klijent from repository
            repository.Delete(klijentToDelete);

            //Check if klijent is deleted from the database
            var klijentFromDb = repository.Get(klijentId);
            Assert.IsNull(klijentFromDb, "klijent was not deleted");
        }
    }
}
