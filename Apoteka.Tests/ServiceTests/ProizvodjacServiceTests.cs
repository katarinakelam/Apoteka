using System;
using System.Linq;
using Apoteka.BLL.BusinessServices;
using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Apoteka.Tests.ServiceTests
{
    [TestClass]
    public class ProizvodjacServiceTests
    {
        [TestMethod]
        public void CreateServiceTest()
        {
            var testHelper = new TestHelper();
            var service = new ProizvodjacService(testHelper.Context);

            Assert.IsNotNull(service, "service is null");
        }

        [TestMethod]
        public void AddProizvodjacServiceTest()
        {
            var testHelper = new TestHelper();
            var service = new ProizvodjacService(testHelper.Context);

            var proizvodjacToAdd = new Proizvodjac
            {
                Naziv = "Novi proizvodjac",
                Adresa = "Proizvodjacka 5"
            };

            service.Create(proizvodjacToAdd);

            //Check if proizvodjac is added to the database
            var proizvodjacFromDb = testHelper.Context.Proizvodjac.AsNoTracking().LastOrDefault();
            Assert.IsNotNull(proizvodjacFromDb, "proizvodjac from database is null");
            Assert.AreEqual(proizvodjacFromDb.Naziv, proizvodjacToAdd.Naziv);
        }

        [TestMethod]
        public void DeleteProizvodjacServiceTest()
        {
            var testHelper = new TestHelper();
            var service = new ProizvodjacService(testHelper.Context);

            var proizvodjacId = testHelper.Context.Proizvodjac.AsNoTracking().Max(p => p.ProizvodjacId);
            var proizvodjac = service.Get(proizvodjacId);

            service.Delete(proizvodjacId);

            var proizvodjacFromDb = service.Get(proizvodjacId);
            Assert.IsNull(proizvodjacFromDb, "proizvodjac was not deleted from the database");
        }
    }
}
