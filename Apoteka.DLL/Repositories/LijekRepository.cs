using Apoteka.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.DLL.Repositories
{
    /// <summary>
    /// Repository for Lijek database entity
    /// </summary>
    /// <seealso cref="Apoteka.DLL.Repositories.IRepository{Lijek}" />
    public class LijekRepository : IRepository<Lijek>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LijekRepository(ApotekaContext context)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Methods

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Create(Lijek model)
        {
            if (this.apotekaContext.Lijek.Find(model.LijekId) == null)
            {
                this.apotekaContext.Lijek.Add(model);
                this.apotekaContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(Lijek model)
        {
            if (model.NarudzbenicaLijek.Count > 0)
            {
                foreach (var narudzbenicaLijek in model.NarudzbenicaLijek)
                {
                    var toModify = this.apotekaContext.NarudzbenicaLijek.Find(narudzbenicaLijek.NarudzbenicaId, narudzbenicaLijek.LijekId);
                    toModify.LijekId = 0;
                    toModify.Lijek = null;
                }
            }

            foreach (var racunLijek in model.RacunLijek)
            {
                var toModify = this.apotekaContext.NarudzbenicaLijek.Find(racunLijek.RacunId, racunLijek.LijekId);
                toModify.LijekId = 0;
                toModify.Lijek = null;
            }

            this.apotekaContext.Lijek.Remove(model);
            this.apotekaContext.SaveChanges();
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public Lijek Get(int id)
        {
            return this.apotekaContext.Lijek.Include(k => k.NarudzbenicaLijek).Include(kr => kr.RacunLijek).AsNoTracking().Where(k => k.LijekId == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Lijek> GetAll()
        {
            return this.apotekaContext.Lijek.Include(k => k.NarudzbenicaLijek).Include(kr => kr.RacunLijek).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<Lijek> GetAllAsQueryable()
        {
            return this.apotekaContext.Lijek.Include(k => k.NarudzbenicaLijek).Include(kr => kr.RacunLijek).AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(Lijek model)
        {
            if (model != null)
            {
                this.apotekaContext.Lijek.Update(model);
                this.apotekaContext.SaveChanges();
            }
        }
        #endregion
    }
}
