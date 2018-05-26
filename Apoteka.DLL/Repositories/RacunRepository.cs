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
    /// <seealso cref="Apoteka.DLL.Repositories.IRepository{Apoteka.Model.Models.Racun}" />
    public class RacunRepository : IRepository<Racun>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RacunRepository(ApotekaContext context)
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
        public Racun Get(int id)
        {
            return this.apotekaContext.Racun.Include(n => n.RacunLijek).AsNoTracking().Where(n => n.RacunId == id).FirstOrDefault();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Racun model)
        {
            if (model != null)
            {
                this.apotekaContext.Racun.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Racun model)
        {
            if (this.apotekaContext.Racun.Find(model.RacunId) == null)
            {
                this.apotekaContext.Racun.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(Racun model)
        {
            this.apotekaContext.Racun.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Racun> GetAll()
        {
            return this.apotekaContext.Racun.Include(n => n.RacunLijek).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<Racun> GetAllAsQueryable()
        {
            return this.apotekaContext.Racun.Include(n => n.RacunLijek).AsNoTracking().AsQueryable();
        }

        #endregion
    }
}
