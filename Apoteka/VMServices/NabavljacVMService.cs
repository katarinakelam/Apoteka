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
    public class NabavljacVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly NabavljacRepository nabavljacRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NabavljacVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NabavljacVMService(ApotekaContext context)
            : this(context, new NabavljacRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NabavljacVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public NabavljacVMService(ApotekaContext context, NabavljacRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.nabavljacRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public NabavljacVM ModelToVM(Nabavljac model)
        {
            var dto = new NabavljacVM
            {
                NabavljacId = model.NabavljacId,
                Naziv = model.Naziv,
                Adresa = model.Adresa,
                Iban = model.Iban
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
        public Nabavljac VMToModel(NabavljacVM dto)
        {
            var model = new Nabavljac
            {
                NabavljacId = dto.NabavljacId,
                Naziv = dto.Naziv,
                Adresa = dto.Adresa,
                Iban = dto.Iban
            };

            return model;
        }

        /// <summary>
        /// Maps the models to dtos.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped models to dtos
        /// </returns>
        public List<NabavljacVM> ListModelsToVMs(List<Nabavljac> model)
        {
            var lijekovi = new List<NabavljacVM>();
            foreach (var lijek in model)
            {
                lijekovi.Add(this.ModelToVM(lijek));
            }

            return lijekovi;
        }
    }
}