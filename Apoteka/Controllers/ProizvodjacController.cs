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
    public class ProizvodjacController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly ProizvodjacService proizvodjacService;
        private readonly ProizvodjacVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public ProizvodjacController()
        {
            this.apotekaContext = new ApotekaContext();
            this.proizvodjacService = new ProizvodjacService(apotekaContext);
            this.vmService = new Service(apotekaContext);
        }
        #endregion
ProizvodjacVM
        // GET: Klijent
        public ActionResult Index()
        {
            var proizvodjaci = this.proizvodjacService.GetAll();

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
        public ActionResult Create(ProizvodjacVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.proizvodjacService.Create(model);

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
                this.proizvodjacService.Delete(id);
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
            var proizvodjac = this.proizvodjacService.Get(id);
            if (proizvodjac == null)
            {
                return HttpNotFound("Ne postoji proizvodjac s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(proizvodjac);
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProizvodjacVM vm)
        {
            try
            {
                var korisnik = this.proizvodjacService.Get(vm.ProizvodjacId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravan nabavljac: " + vm.ProizvodjacId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.proizvodjacService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(vm);
                }
            }
            catch
            {
                return RedirectToAction(nameof(Edit), vm.ProizvodjacId);
            }
        }
    }
}