using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.DLL.Repositories
{
    /// <summary>
    /// Repository for Proizvodjac database entity
    /// </summary>
    public class ProizvodjacRepository : IRepository<Proizvodjac>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProizvodjacRepository(ApotekaContext context)
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
        public Proizvodjac Get(int id)
        {
            return this.apotekaContext.Proizvodjac.Include(n => n.Lijek).AsNoTracking().Where(n => n.ProizvodjacId == id).FirstOrDefault();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Proizvodjac model)
        {
            if (model != null)
            {
                this.apotekaContext.Proizvodjac.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Proizvodjac model)
        {
            if (this.apotekaContext.Proizvodjac.Find(model.ProizvodjacId) == null)
            {
                this.apotekaContext.Proizvodjac.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(Proizvodjac model)
        {
            if (model.Lijek.Count > 0)
            {
                foreach(var lijek in model.Lijek)
                {
                    var lijekToModify = this.apotekaContext.Lijek.Find(lijek.LijekId);
                    lijekToModify.ProizvodjacId = 0;
                    lijekToModify.Proizvodjac = null;
                }
            }

            this.apotekaContext.Proizvodjac.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Proizvodjac> GetAll()
        {
            return this.apotekaContext.Proizvodjac.Include(n => n.Lijek).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<Proizvodjac> GetAllAsQueryable()
        {
            return this.apotekaContext.Proizvodjac.Include(n => n.Lijek).AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Gets the last element identifier.
        /// </summary>
        /// <returns>
        /// Returns the last element identifier.
        /// </returns>
        public int GetLast()
        {
            return this.apotekaContext.Proizvodjac.Max(k => k.ProizvodjacId);
        }
        #endregion
    }
}
