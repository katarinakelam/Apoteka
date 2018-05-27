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
    public class KorisnikVMService
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly KorisnikRepository korisnikRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikVMService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public KorisnikVMService(ApotekaContext context)
            : this(context, new KorisnikRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public KorisnikVMService(ApotekaContext context, KorisnikRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.korisnikRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public KorisnikVM ModelToVM(Korisnik model)
        {
            var dto = new KorisnikVM
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                DatumRodjenja = (DateTime)model.DatumRodjenja,
                RadnoMjestoNaziv = model.RadnoMjesto.Naziv,
                KorisnikId = model.KorisnikId
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
        public Korisnik VMToModel(KorisnikVM dto)
        {
            var model = new Korisnik
            {
                KorisnikId = dto.KorisnikId,
                Ime = dto.Ime,
                Prezime = dto.Prezime,
                DatumRodjenja = dto.DatumRodjenja
            };

            var radnomjesto = this.apotekaContext.RadnoMjesto.Where(r => r.Naziv == dto.RadnoMjestoNaziv).FirstOrDefault();
            model.RadnoMjesto = radnomjesto;
            model.RadnoMjestoId = radnomjesto.RadnoMjestoId;

            return model;
        }

        /// <summary>
        /// Maps the models to dtos.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped models to dtos
        /// </returns>
        public List<KorisnikVM> ListModelsToVMs(List<Korisnik> model)
        {
            var korisnici = new List<KorisnikVM>();
            foreach (var korisnik in model)
            {
                korisnici.Add(this.ModelToVM(korisnik));
            }

            return korisnici;
        }
    }
}