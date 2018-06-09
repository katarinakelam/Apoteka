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
    public class NarudzbenicaController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly NarudzbenicaService narudzbenicaService;
        private readonly NarudzbenicaVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NarudzbenicaController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public NarudzbenicaController()
        {
            this.apotekaContext = new ApotekaContext();
            this.narudzbenicaService = new NarudzbenicaService(apotekaContext);
            this.vmService = new NarudzbenicaVMService(apotekaContext);
        }
        #endregion

        // GET: Klijent
        public ActionResult Index()
        {
            var narudzbenice = this.narudzbenicaService.GetAll();

            var vm = this.vmService.ListModelsToVMs(narudzbenice.ToList());
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
        public ActionResult Create(NarudzbenicaVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.narudzbenicaService.Create(model);

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
                this.narudzbenicaService.Delete(id);
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
            var narudzbenica = this.narudzbenicaService.Get(id);
            if (narudzbenica == null)
            {
                return HttpNotFound("Ne postoji narudzbenica s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(narudzbenica);
                PrepareDropDownLists();
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NarudzbenicaVM vm)
        {
            try
            {
                var korisnik = this.narudzbenicaService.Get(vm.NarudzbenicaId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravna narudžbenica: " + vm.NarudzbenicaId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.narudzbenicaService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    PrepareDropDownLists();
                    return View(vm);
                }
            }
            catch
            {
                PrepareDropDownLists();
                return RedirectToAction(nameof(Edit), vm.NarudzbenicaId);
            }
        }

        private void PrepareDropDownLists()
        {
            var korisnici = apotekaContext.Korisnik.OrderBy(v => v.Ime).ToList();
            ViewBag.Korisnici = new SelectList(korisnici, "Prezime", "Prezime");

            var nabavljaci = apotekaContext.Nabavljac.OrderBy(v => v.Naziv).ToList();
            ViewBag.Nabavljaci = new SelectList(nabavljaci, "Naziv", "Naziv");
        }
    }
}