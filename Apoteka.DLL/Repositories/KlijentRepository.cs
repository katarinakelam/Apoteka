using Apoteka.Model.Models;
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
    /// <seealso cref="Apoteka.DLL.Repositories.IRepository{Apoteka.Model.Models.Klijent}" />
    public class KlijentRepository : IRepository<Klijent>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="KlijentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public KlijentRepository(ApotekaContext context)
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
        public Klijent Get(int id)
        {
            return this.apotekaContext.Klijent.Include(k => k.Racun).AsNoTracking().Where(k => k.KlijentId == id).FirstOrDefault();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Klijent model)
        {
            if (model != null)
            {
                this.apotekaContext.Klijent.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Klijent model)
        {
            if (this.apotekaContext.Klijent.Find(model.KlijentId) == null)
            {
                this.apotekaContext.Klijent.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(Klijent model)
        {
            if (model.Racun.Count > 0)
            {
                foreach (var racun in model.Racun)
                {
                    var racunToModify = this.apotekaContext.Racun.Find(racun.RacunId);
                    racunToModify.KlijentId = 0;
                    racunToModify.Klijent = null;
                }
            }

            this.apotekaContext.Klijent.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Klijent> GetAll()
        {
            return this.apotekaContext.Klijent.Include(k => k.Racun).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<Klijent> GetAllAsQueryable()
        {
            return this.apotekaContext.Klijent.Include(k => k.Racun).AsNoTracking().AsQueryable();
        }

        #endregion
    }
}
