using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.DLL.Repositories
{
    /// <summary>
    ///  Repository for Radno mjesto database entity
    /// </summary>
    /// <seealso cref="Apoteka.DLL.Repositories.IRepository" />
    public class RadnoMjestoRepository : IRepository<RadnoMjesto>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RadnoMjestoRepository(ApotekaContext context)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Methods

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(RadnoMjesto model)
        {
            if (this.apotekaContext.RadnoMjesto.Find(model.RadnoMjestoId) == null)
            {
                this.apotekaContext.RadnoMjesto.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(RadnoMjesto model)
        {
            if (model.Korisnik.Count > 0)
            {
                foreach (var korisnik in model.Korisnik)
                {
                    var korisnikToModify = this.apotekaContext.Korisnik.Find(korisnik.KorisnikId);
                    korisnikToModify.RadnoMjestoId = 0;
                    korisnikToModify.RadnoMjesto = null;
                }
            }

            this.apotekaContext.RadnoMjesto.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public RadnoMjesto Get(int id)
        {
            return this.apotekaContext.RadnoMjesto.Include(n => n.Korisnik).AsNoTracking().Where(n => n.RadnoMjestoId == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<RadnoMjesto> GetAll()
        {
            return this.apotekaContext.RadnoMjesto.Include(n => n.Korisnik).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        public IQueryable<RadnoMjesto> GetAllAsQueryable()
        {
            return this.apotekaContext.RadnoMjesto.Include(n => n.Korisnik).AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(RadnoMjesto model)
        {
            if (model != null)
            {
                this.apotekaContext.RadnoMjesto.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the last element identifier.
        /// </summary>
        /// <returns>
        /// Returns the last element identifier.
        /// </returns>
        public int GetLast()
        {
            return this.apotekaContext.RadnoMjesto.Max(k => k.RadnoMjestoId);
        }
        #endregion

    }
}
