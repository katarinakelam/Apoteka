using Apoteka.BLL.BusinessModels;
using Apoteka.BLL.BusinessServices;
using Apoteka.DLL;
using Apoteka.Model.Models;
using Apoteka.ViewModels;
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
        private readonly ApotekaContext apotekaContext;
        private readonly AppSettings settings;
        private readonly KlijentService klijentService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KlijentController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public KlijentController(ApotekaContext context, IOptionsSnapshot<AppSettings> settings)
            : this(context, settings, new KlijentService(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlijentController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public KlijentController(ApotekaContext context, IOptionsSnapshot<AppSettings> settings, KlijentService service)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.settings = settings.Value ?? throw new ArgumentNullException(nameof(settings.Value));
            this.klijentService = service ?? throw new ArgumentNullException(nameof(service));
        }
        #endregion

        // GET: Klijent
        public ActionResult Index(int page = 1, int sort = 1, bool ascending = false)
        {
            var klijenti = this.klijentService.GetAll(page, settings.PageSize);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                Sort = 1,
                Ascending = ascending,
                ItemsPerPage = settings.PageSize,
                TotalItems = klijenti.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                return RedirectToAction(nameof(Index), new { page = pagingInfo.TotalPages, sort, ascending });
            }

            System.Linq.Expressions.Expression<Func<Klijent, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = n => n.Ime;
                    break;
                case 2:
                    orderSelector = n => n.Prezime;
                    break;
                case 3:
                    orderSelector = n => n.DatumRodjenja;
                    break;
                case 4:
                    orderSelector = n => n.BrojZdravstveneIskaznice;
                    break;
            }
            if (orderSelector != null)
            {
                klijenti = ascending ?
                       klijenti.OrderBy(orderSelector) :
                       klijenti.OrderByDescending(orderSelector);
            }

            var klijentiDTO = this.klijentService.ListModelsToDTOs(klijenti.ToList());

            var vm = new KlijentVM
            {
                Klijenti = klijentiDTO,
                PagingInfo = pagingInfo
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}