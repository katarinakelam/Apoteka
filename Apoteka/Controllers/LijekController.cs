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
    public class LijekController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly LijekService lijekService;
        private readonly LijekVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LijekController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public LijekController()
        {
            this.apotekaContext = new ApotekaContext();
            this.lijekService = new LijekService(apotekaContext);
            this.vmService = new LijekVMService(apotekaContext);
        }
        #endregion

        // GET: Klijent
        public ActionResult Index()
        {
            var lijekovi = this.lijekService.GetAll();

            var vm = this.vmService.ListModelsToVMs(lijekovi.ToList());
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
        public ActionResult Create(LijekVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.lijekService.Create(model);

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
                this.lijekService.Delete(id);
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
            var lijek = this.lijekService.Get(id);
            if (lijek == null)
            {
                return HttpNotFound("Ne postoji lijek s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(lijek);
                PrepareDropDownLists();
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LijekVM vm)
        {
            try
            {
                var korisnik = this.lijekService.Get(vm.LijekId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravan lijek: " + vm.LijekId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.lijekService.Update(model);
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
                return RedirectToAction(nameof(Edit), vm.LijekId);
            }
        }

        private void PrepareDropDownLists()
        {
            var proizvodjaci = apotekaContext.Proizvodjac.OrderBy(v => v.Naziv).ToList();

            ViewBag.Proizvodjaci = new SelectList(proizvodjaci, "Naziv", "Naziv");
        }
    }
}