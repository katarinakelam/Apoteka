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
    public class ProizvodjacVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly ProizvodjacRepository proizvodjacRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProizvodjacVMService(ApotekaContext context)
            : this(context, new ProizvodjacRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public ProizvodjacVMService(ApotekaContext context, ProizvodjacRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.proizvodjacRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public ProizvodjacVM ModelToVM(Proizvodjac model)
        {
            var dto = new ProizvodjacVM
            {
                ProizvodjacId = model.ProizvodjacId,
                Naziv = model.Naziv,
                Adresa = model.Adresa
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
        public Proizvodjac VMToModel(ProizvodjacVM dto)
        {
            var model = new Proizvodjac
            {
                ProizvodjacId = dto.ProizvodjacId,
                Naziv = dto.Naziv,
                Adresa = dto.Adresa
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
        public List<ProizvodjacVM> ListModelsToVMs(List<Proizvodjac> model)
        {
            var proizvodjaci = new List<ProizvodjacVM>();
            foreach (var proizvodjac in model)
            {
                proizvodjaci.Add(this.ModelToVM(proizvodjac));
            }

            return proizvodjaci;
        }
    }
}