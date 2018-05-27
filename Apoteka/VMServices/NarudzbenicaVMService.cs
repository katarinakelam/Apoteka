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
    public class NarudzbenicaVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly NarudzbenicaRepository narudzbenicaRepository;
        #endregion

        #region ConstructorsNarudzbenicaVMService
        /// <summary>
        /// Initializes a new instance of the <see cref="NarudzbenicaVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NarudzbenicaVMService(ApotekaContext context)
            : this(context, new NarudzbenicaRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NarudzbenicaVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public NarudzbenicaVMService(ApotekaContext context, NarudzbenicaRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.narudzbenicaRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public NarudzbenicaVM ModelToVM(Narudzbenica model)
        {
            var dto = new NarudzbenicaVM
            {
                DatumIvrijemeIzdavanja = (DateTime)model.DatumIvrijemeIzdavanja,
                AdresaDostave = model.AdresaDostave,
                KorisnikNaziv = model.Korisnik.Prezime,
                NabavljacNaziv = model.Nabavljac.Naziv,
                NarudzbenicaId = model.NarudzbenicaId
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
        public Narudzbenica VMToModel(NarudzbenicaVM dto)
        {
            var model = new Narudzbenica
            {
                DatumIvrijemeIzdavanja = dto.DatumIvrijemeIzdavanja,
                AdresaDostave = dto.AdresaDostave,
                NarudzbenicaId = dto.NarudzbenicaId
            };

            var korisnik = this.apotekaContext.Korisnik.Where(r => r.Prezime == dto.KorisnikNaziv).FirstOrDefault();
            model.Korisnik = korisnik;
            model.KorisnikId = korisnik.KorisnikId;

            var nabavljac = this.apotekaContext.Nabavljac.Where(r => r.Naziv == dto.NabavljacNaziv).FirstOrDefault();
            model.Nabavljac = nabavljac;
            model.NabavljacId = nabavljac.NabavljacId;

            return model;
        }

        /// <summary>
        /// Maps the models to dtos.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped models to dtos
        /// </returns>
        public List<NarudzbenicaVM> ListModelsToVMs(List<Narudzbenica> model)
        {
            var narudzbenice = new List<NarudzbenicaVM>();
            foreach (var narudzbenica in model)
            {
                narudzbenice.Add(this.ModelToVM(narudzbenica));
            }

            return narudzbenice;
        }
    }
}