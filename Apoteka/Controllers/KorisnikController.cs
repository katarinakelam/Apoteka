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
    /// Korisnik MVC Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class KorisnikController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly KorisnikService korisnikService;
        private readonly KorisnikVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public KorisnikController()
        {
            this.apotekaContext = new ApotekaContext();
            this.korisnikService = new KorisnikService(apotekaContext);
            this.vmService = new KorisnikVMService(apotekaContext);
        }
        #endregion

        // GET: Klijent
        public ActionResult Index()
        {
            var klijenti = this.korisnikService.GetAll();

            var vm = this.vmService.ListModelsToVMs(klijenti.ToList());
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
        public ActionResult Create(KorisnikVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.korisnikService.Create(model);
               
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
                this.korisnikService.Delete(id);
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
            var klijent = this.korisnikService.Get(id);
            if (klijent == null)
            {
                return HttpNotFound("Ne postoji korisnik s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(klijent);
                PrepareDropDownLists();
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KorisnikVM vm)
        {
            try
            {
                var korisnik = this.korisnikService.Get(vm.KorisnikId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravan korisnik: " + vm.KorisnikId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.korisnikService.Update(model);
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
                return RedirectToAction(nameof(Edit), vm.KorisnikId);
            }
        }


        private void PrepareDropDownLists()
        {
            var radnamjesta = apotekaContext.RadnoMjesto.OrderBy(v => v.Naziv).ToList();

            ViewBag.RadnaMjesta = new SelectList(radnamjesta, "Naziv", "Naziv");
        }
    }
}