﻿using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
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
    public class NabavljacRepository : IRepository<Nabavljac>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NabavljacRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NabavljacRepository(ApotekaContext context)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Methods

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Nabavljac Get(int id)
        {
            return this.apotekaContext.Nabavljac.Include(n => n.Narudzbenica).AsNoTracking().Where(n => n.NabavljacId == id).FirstOrDefault();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Nabavljac model)
        {
            if (model != null)
            {
                this.apotekaContext.Nabavljac.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Nabavljac model)
        {
            if (this.apotekaContext.Nabavljac.Find(model.NabavljacId) == null)
            {
                this.apotekaContext.Nabavljac.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(Nabavljac model)
        {
            if (model.Narudzbenica.Count > 0)
            {
                foreach (var narudzbenica in model.Narudzbenica)
                {
                    var narudzbenicaToModify = this.apotekaContext.Narudzbenica.Find(narudzbenica.NarudzbenicaId);
                    narudzbenicaToModify.NabavljacId = 0;
                    narudzbenicaToModify.Nabavljac = null;
                }
            }

            this.apotekaContext.Nabavljac.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Nabavljac> GetAll()
        {
            return this.apotekaContext.Nabavljac.Include(n => n.Narudzbenica).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<Nabavljac> GetAllAsQueryable()
        {
            return this.apotekaContext.Nabavljac.Include(n => n.Narudzbenica).AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Gets the last element identifier.
        /// </summary>
        /// <returns>
        /// Returns the last element identifier.
        /// </returns>
        public int GetLast()
        {
            return this.apotekaContext.Nabavljac.Max(k => k.NabavljacId);
        }
        #endregion
    }
}
