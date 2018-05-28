using Apoteka.BLL.BusinessServices;
using Apoteka.DLL;
using Apoteka.Model.Models;
using Apoteka.ViewModels;
using Apoteka.VMServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apoteka.Controllers
{
    /// <summary>
    /// Lijek MVC Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class RadnoMjestoController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly RadnoMjestoService radnoMjestoService;
        private readonly RadnoMjestoVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RadnoMjestoController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public RadnoMjestoController()
        {
            this.apotekaContext = new ApotekaContext();
            this.radnoMjestoService = new RadnoMjestoService(apotekaContext);
            this.vmService = new RadnoMjestoVMService(apotekaContext);
        }
        #endregion
        // GET: Klijent
        public ActionResult Index()
        {
            var proizvodjaci = this.radnoMjestoService.GetAll();

            var vm = this.vmService.ListModelsToVMs(proizvodjaci.ToList());
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RadnoMjestoVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.radnoMjestoService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(vm);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this.radnoMjestoService.Delete(id);
            }
            catch (Exception exc)
            {
                HttpNotFound(exc.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var proizvodjac = this.radnoMjestoService.Get(id);
            if (proizvodjac == null)
            {
                return HttpNotFound("Ne postoji radno mjesto s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(proizvodjac);
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RadnoMjestoVM vm)
        {
            try
            {
                var korisnik = this.radnoMjestoService.Get(vm.RadnoMjestoId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravno radno mjesto: " + vm.RadnoMjestoId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.radnoMjestoService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(vm);
                }
            }
            catch
            {
                return RedirectToAction(nameof(Edit), vm.RadnoMjestoId);
            }
        }
    }
}