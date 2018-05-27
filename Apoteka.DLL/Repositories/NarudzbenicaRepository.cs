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
    public class NarudzbenicaRepository : IRepository<Narudzbenica>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NarudzbenicaRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NarudzbenicaRepository(ApotekaContext context)
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
        public Narudzbenica Get(int id)
        {
            return this.apotekaContext.Narudzbenica.Include(n => n.Korisnik).Include(n => n.Nabavljac).Include(n => n.NarudzbenicaLijek).AsNoTracking().Where(n => n.NarudzbenicaId == id).FirstOrDefault();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Narudzbenica model)
        {
            if (model != null)
            {
                this.apotekaContext.Narudzbenica.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Narudzbenica model)
        {
            if (this.apotekaContext.Narudzbenica.Find(model.NarudzbenicaId) == null)
            {
                this.apotekaContext.Narudzbenica.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(Narudzbenica model)
        {
            if (model.NarudzbenicaLijek.Count > 0)
            {
                foreach (var narudzbenicaLijek in model.NarudzbenicaLijek)
                {
                    var toModify = this.apotekaContext.NarudzbenicaLijek.Find(narudzbenicaLijek.NarudzbenicaId, narudzbenicaLijek.LijekId);
                    toModify.NarudzbenicaId = 0;
                    toModify.Narudzbenica = null;
                }
            }

            this.apotekaContext.Narudzbenica.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Narudzbenica> GetAll()
        {
            return this.apotekaContext.Narudzbenica.Include(n => n.Korisnik).Include(n => n.Nabavljac).Include(n => n.NarudzbenicaLijek).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<Narudzbenica> GetAllAsQueryable()
        {
            return this.apotekaContext.Narudzbenica.Include(n => n.Korisnik).Include(n => n.Nabavljac).Include(n => n.NarudzbenicaLijek).AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Gets the last element identifier.
        /// </summary>
        /// <returns>
        /// Returns the last element identifier.
        /// </returns>
        public int GetLast()
        {
            return this.apotekaContext.Narudzbenica.Max(k => k.NarudzbenicaId);
        }
        #endregion
    }
}
