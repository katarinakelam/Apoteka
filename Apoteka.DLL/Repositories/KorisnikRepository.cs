﻿using Apoteka.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.DLL.Repositories
{
    /// <summary>
    ///  Repository for Racun database entity
    /// </summary>
    /// <seealso cref="Apoteka.DLL.Repositories.IRepository{Apoteka.Model.Models.Racun}" />
    public class KorisnikRepository : IRepository<Korisnik>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public KorisnikRepository(ApotekaContext context)
        {
            this.apotekaContext = context;
        }

        #region Methods

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Korisnik Get(int id)
        {
            return this.apotekaContext.Korisnik.Find(id);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Korisnik model)
        {
            if (model != null)
            {
                this.apotekaContext.Korisnik.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Korisnik model)
        {
            if (this.apotekaContext.Korisnik.Find(model.KorisnikId) == null)
            {
                this.apotekaContext.Korisnik.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(Korisnik model)
        {
            if (model.Narudzbenica.Count > 0)
            {
                foreach (var narudzbenica in model.Narudzbenica)
                {
                    var narudzbenicaToModify = this.apotekaContext.Narudzbenica.Find(narudzbenica.NarudzbenicaId);
                    narudzbenicaToModify.KorisnikId = 0;
                    narudzbenicaToModify.Korisnik = null;
                }
            }

            if (model.Racun.Count > 0)
            {
                foreach (var racun in model.Racun)
                {
                    var racunToModify = this.apotekaContext.Racun.Find(racun.RacunId);
                    racunToModify.KorisnikId = 0;
                    racunToModify.Korisnik = null;
                }
            }

            this.apotekaContext.Korisnik.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Korisnik> GetAll()
        {
            return this.apotekaContext.Korisnik.AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<Korisnik> GetAllAsQueryable()
        {
            return this.apotekaContext.Korisnik.AsQueryable();
        }

        #endregion
    }
}
