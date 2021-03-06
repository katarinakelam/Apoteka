﻿using Apoteka.DLL;
using Apoteka.DLL.Repositories;
using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.BLL.BusinessServices
{
    /// <summary>
    /// Klijent business service
    /// </summary>
    public class KlijentService : IService<Klijent>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly KlijentRepository klijentRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KlijentService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public KlijentService(ApotekaContext context)
            :this(context, new KlijentRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlijentService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public KlijentService(ApotekaContext context, KlijentRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.klijentRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Klijent Get(int id)
        {
            return this.klijentRepository.Get(id);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Klijent model)
        {
            this.klijentRepository.Update(model);
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Klijent model)
        {
            var lastId = this.klijentRepository.GetLast();
            model.KlijentId = lastId + 1;
            this.klijentRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.klijentRepository.Get(id);

            this.klijentRepository.Delete(toDelete);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IQueryable<Klijent> GetAll()
        {
            return this.klijentRepository.GetAllAsQueryable();
        }

        /// <summary>
        /// Gets the racuni for klijent.
        /// </summary>
        /// <param name="id">The klijent identifier.</param>
        /// <returns>
        /// Returns the racuni for klijent
        /// </returns>
        public List<Racun> GetRacuniForKlijent(int klijentId)
        {
            var racuni = this.apotekaContext.Racun.Include(r => r.Korisnik).Include(r => r.Klijent).Where(r => r.KlijentId == klijentId).ToList();

            return racuni;
        }
        #endregion
    }
}
