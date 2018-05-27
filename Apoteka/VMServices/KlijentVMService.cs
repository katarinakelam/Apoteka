using Apoteka.Model.Models;
using Apoteka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apoteka.VMServices
{
    public class KlijentVMService
    {
        /// <summary>
        /// Models to dto.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns mapped model to dto
        /// </returns>
        public KlijentVM ModelToVM(Klijent model)
        {
            var dto = new KlijentVM
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                DatumRodjenja = (DateTime)model.DatumRodjenja,
                BrojZdravstveneIskaznice = (int)model.BrojZdravstveneIskaznice,
                KlijentId = model.KlijentId
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
        public Klijent VMToModel(KlijentVM dto)
        {
            var model = new Klijent
            {
                KlijentId = dto.KlijentId,
                Ime = dto.Ime,
                Prezime = dto.Prezime,
                DatumRodjenja = dto.DatumRodjenja,
                BrojZdravstveneIskaznice = dto.BrojZdravstveneIskaznice
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
        public List<KlijentVM> ListModelsToVMs(List<Klijent> model)
        {
            var klijenti = new List<KlijentVM>();
            foreach (var klijent in model)
            {
                klijenti.Add(this.ModelToVM(klijent));
            }

            return klijenti;
        }
    }
}