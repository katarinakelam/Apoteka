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
    public class RadnoMjestoVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly RadnoMjestoRepository radnoMjestoRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RadnoMjestoVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RadnoMjestoVMService(ApotekaContext context)
            : this(context, new RadnoMjestoRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RadnoMjestoVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public RadnoMjestoVMService(ApotekaContext context, RadnoMjestoRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.radnoMjestoRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public RadnoMjestoVM ModelToVM(RadnoMjesto model)
        {
            var dto = new RadnoMjestoVM
            {
                RadnoMjestoId = model.RadnoMjestoId,
                Naziv = model.Naziv,
                OvlastNarucivanja = (bool)model.OvlastNarucivanja
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
        public RadnoMjesto VMToModel(RadnoMjestoVM dto)
        {
            var model = new RadnoMjesto
            {
                RadnoMjestoId = dto.RadnoMjestoId,
                Naziv = dto.Naziv,
                OvlastNarucivanja = dto.OvlastNarucivanja
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
        public List<RadnoMjestoVM> ListModelsToVMs(List<RadnoMjesto> model)
        {
            var radnaMjesta = new List<RadnoMjestoVM>();
            foreach (var radnoMjesto in model)
            {
                radnaMjesta.Add(this.ModelToVM(radnoMjesto));
            }

            return radnaMjesta;
        }
    }
}