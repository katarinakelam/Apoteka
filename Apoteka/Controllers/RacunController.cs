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
    public class RacunController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly RacunService racunService;
        private readonly RacunVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RacunController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public RacunController()
        {
            this.apotekaContext = new ApotekaContext();
            this.racunService = new RacunService(apotekaContext);
            this.vmService = new RacunVMService(apotekaContext);
        }
        #endregion

        // GET: Klijent
        public ActionResult Index()
        {
            var racuni = this.racunService.GetAll();

            var vm = this.vmService.ListModelsToVMs(racuni.ToList());
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            PrepareDropDownLists();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RacunVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.racunService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                PrepareDropDownLists();
                return View(vm);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this.racunService.Delete(id);
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
            var racun = this.racunService.Get(id);
            if (racun == null)
            {
                return HttpNotFound("Ne postoji racun s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(racun);
                PrepareDropDownLists();
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RacunVM vm)
        {
            try
            {
                var korisnik = this.racunService.Get(vm.RacunId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravan račun: " + vm.RacunId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.racunService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(vm);
                }
            }
            catch
            {
                PrepareDropDownLists();
                return RedirectToAction(nameof(Edit), vm.RacunId);
            }
        }

        private void PrepareDropDownLists()
        {
            var korisnici = apotekaContext.Korisnik.OrderBy(v => v.Ime).ToList();
            ViewBag.Korisnici = new SelectList(korisnici, "Prezime", "Prezime");

            var klijenti = apotekaContext.Klijent.OrderBy(v => v.Prezime).ToList();
            ViewBag.Klijenti = new SelectList(klijenti, "Prezime", "Prezime");
        }
    }
}