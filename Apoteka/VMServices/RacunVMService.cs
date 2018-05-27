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
    public class RacunVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly RacunRepository racunRepository;
        #endregion

        #region ConstructorsNarudzbenicaVMService
        /// <summary>
        /// Initializes a new instance of the <see cref="RacunVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RacunVMService(ApotekaContext context)
            : this(context, new RacunRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RacunVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public RacunVMService(ApotekaContext context, RacunRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.racunRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public RacunVM ModelToVM(Racun model)
        {
            var dto = new RacunVM
            {
                DatumIvrijemeIzdavanja = (DateTime)model.DatumIvrijemeIzdavanja,
                KorisnikNaziv = model.Korisnik.Prezime,
                KlijentNaziv = model.Klijent.Prezime,
                RacunId = model.RacunId
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
        public Racun VMToModel(RacunVM dto)
        {
            var model = new Racun
            {
                DatumIvrijemeIzdavanja = dto.DatumIvrijemeIzdavanja,
                RacunId = dto.RacunId
            };

            var korisnik = this.apotekaContext.Korisnik.Where(r => r.Prezime == dto.KorisnikNaziv).FirstOrDefault();
            model.Korisnik = korisnik;
            model.KorisnikId = korisnik.KorisnikId;

            var klijent = this.apotekaContext.Klijent.Where(r => r.Prezime == dto.KlijentNaziv).FirstOrDefault();
            model.Klijent = klijent;
            model.KlijentId = klijent.KlijentId;

            return model;
        }

        /// <summary>
        /// Maps the models to dtos.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped models to dtos
        /// </returns>
        public List<RacunVM> ListModelsToVMs(List<Racun> model)
        {
            var racuni = new List<RacunVM>();
            foreach (var racun in model)
            {
                racuni.Add(this.ModelToVM(racun));
            }

            return racuni;
        }
    }
}