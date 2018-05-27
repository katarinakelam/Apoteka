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
    public class NabavljacController : Controller
    {
        #region Properties
        private ApotekaContext apotekaContext;
        private readonly NabavljacService nabavljacService;
        private readonly NabavljacVMService vmService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NabavljacController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public NabavljacController()
        {
            this.apotekaContext = new ApotekaContext();
            this.nabavljacService = new NabavljacService(apotekaContext);
            this.vmService = new NabavljacVMService(apotekaContext);
        }
        #endregion

        // GET: Klijent
        public ActionResult Index()
        {
            var nabavljaci = this.nabavljacService.GetAll();

            var vm = this.vmService.ListModelsToVMs(nabavljaci.ToList());
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NabavljacVM vm)
        {
            try
            {
                var model = this.vmService.VMToModel(vm);
                this.nabavljacService.Create(model);

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
                this.nabavljacService.Delete(id);
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
            var nabavljac = this.nabavljacService.Get(id);
            if (nabavljac == null)
            {
                return HttpNotFound("Ne postoji nabavljac s id-em: " + id);
            }
            else
            {
                var vm = this.vmService.ModelToVM(nabavljac);
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NabavljacVM vm)
        {
            try
            {
                var korisnik = this.nabavljacService.Get(vm.NabavljacId);
                if (korisnik == null)
                {
                    return HttpNotFound("Neispravan nabavljac: " + vm.NabavljacId);
                }
                try
                {
                    var model = this.vmService.VMToModel(vm);
                    this.nabavljacService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(vm);
                }
            }
            catch
            {
                return RedirectToAction(nameof(Edit), vm.NabavljacId);
            }
        }
    }
}