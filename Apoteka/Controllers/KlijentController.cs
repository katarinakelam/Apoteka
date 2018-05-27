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
    /// Klijent MVC Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class KlijentController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly KlijentService klijentService;
        private readonly KlijentVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KlijentController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public KlijentController()
        {
            this.apotekaContext = new ApotekaContext();
            this.klijentService = new KlijentService(apotekaContext);
            this.vmService = new KlijentVMService();
        }
        #endregion

        // GET: Klijent
        public ActionResult Index()
        {
            var klijenti = this.klijentService.GetAll();

            var vm = this.vmService.ListModelsToVMs(klijenti.ToList());
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KlijentVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.klijentService.Create(model);

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
                this.klijentService.Delete(id);
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
            var klijent = this.klijentService.Get(id);
            if (klijent == null)
            {
                return HttpNotFound("Ne postoji klijent s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(klijent);
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KlijentVM vm)
        {
            try
            {
                var klijent = this.klijentService.Get(vm.KlijentId);
                if (klijent == null)
                {
                    return HttpNotFound("Neispravan klijent: " + vm.KlijentId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.klijentService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(vm);
                }
            }
            catch
            {
                return RedirectToAction(nameof(Edit), vm.KlijentId);
            }
        }
    }
}