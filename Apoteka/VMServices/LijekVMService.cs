using Apoteka.DLL;
using Apoteka.DLL.Repositories;
using Apoteka.Model.Models;
using Apoteka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apoteka.VMServices
{
    public class LijekVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly LijekRepository lijekRepository;
        #endregion

        #region ConstructorsLijekVMService
        /// <summary>
        /// Initializes a new instance of the <see cref="LijekVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LijekVMService(ApotekaContext context)
            : this(context, new LijekRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LijekVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public LijekVMService(ApotekaContext context, LijekRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.lijekRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public LijekVM ModelToVM(Lijek model)
        {
            var dto = new LijekVM
            {
                TrgovackoIme = model.TrgovackoIme,
                FarmaceutskoIme = model.FarmaceutskoIme,
                Cijena = (int)model.Cijena,
                Kolicina = (int)model.Kolicina,
                Jacina = model.Jacina,
                ReferencaUputa = model.ReferencaUputa,
                LijekId = model.LijekId,
                ProizvodjacNaziv = model.Proizvodjac.Naziv
            };
            return dto;
        }

        /// <summary>
        /// Maps dto to model
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>
        /// Returns mapped dto to model
        /// </returns>
        public Lijek VMToModel(LijekVM dto)
        {
            var model = new Lijek
            {
                TrgovackoIme = dto.TrgovackoIme,
                FarmaceutskoIme = dto.FarmaceutskoIme,
                Cijena = dto.Cijena,
                Kolicina = dto.Kolicina,
                Jacina = dto.Jacina,
                ReferencaUputa = dto.ReferencaUputa,
                LijekId = dto.LijekId
            };

            var proizvodjac = this.apotekaContext.Proizvodjac.Where(r => r.Naziv == dto.ProizvodjacNaziv).FirstOrDefault();
            model.Proizvodjac = proizvodjac;
            model.ProizvodjacId = proizvodjac.ProizvodjacId;

            return model;
        }

        /// <summary>
        /// Maps the models to dtos.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped models to dtos
        /// </returns>
        public List<LijekVM> ListModelsToVMs(List<Lijek> model)
        {
            var lijekovi = new List<LijekVM>();
            foreach (var lijek in model)
            {
                lijekovi.Add(this.ModelToVM(lijek));
            }

            return lijekovi;
        }
    }
}