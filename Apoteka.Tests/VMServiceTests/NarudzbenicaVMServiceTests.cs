using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apoteka.ViewModels;
using Apoteka.VMServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Apoteka.Tests.VMServiceTests
{
    [TestClass]
    public class NarudzbenicaVMServiceTests
    {
        [TestMethod]
        public void CreateVMServiceTest()
        {
            var testHelper = new TestHelper();
            var vmService = new NarudzbenicaVMService(testHelper.Context);

            Assert.IsNotNull(vmService, "service is null");
        }

        [TestMethod]
        public void TranslateVMToModelVMServiceTest()
        {
            var testHelper = new TestHelper();
            var vmService = new NarudzbenicaVMService(testHelper.Context);

            var goodNarudzbenicaVM = new NarudzbenicaVM
            {
                DatumIvrijemeIzdavanja = new DateTime (2018, 3, 3, 15, 15, 15),
                AdresaDostave = "Dostava 3",
                KorisnikNaziv = "Ante",
                NabavljacNaziv = "Mile"
            };

            Assert.IsTrue(this.ValidateModel(goodNarudzbenicaVM));

            //Testing validation rule that requires NabavljacNaziv to be entered
            var badNarudzbenicaVM = new NarudzbenicaVM
            {
                DatumIvrijemeIzdavanja = new DateTime(2018, 3, 3, 15, 15, 15),
                AdresaDostave = "Dostava 3",
                KorisnikNaziv = "Ante"
            };

            Assert.IsFalse(this.ValidateModel(badNarudzbenicaVM));
        }

        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            var result = Validator.TryValidateObject(model, ctx, validationResults, true);
            return result;
        }
    }
}
