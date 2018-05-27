using Apoteka.DLL;
using Apoteka.DLL.Repositories;
using Apoteka.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.BLL.BusinessServices
{
    /// <summary>
    /// Racun business service
    /// </summary>
    /// <seealso cref="Apoteka.BLL.BusinessServices.IService{Apoteka.Model.Models.Racun}" />
    public class RacunService : IService<Racun>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly RacunRepository racunRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RacunService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RacunService(ApotekaContext context)
            : this(context, new RacunRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RacunService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public RacunService(ApotekaContext context, RacunRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.racunRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Racun model)
        {
            this.racunRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.racunRepository.Get(id);

            this.racunRepository.Delete(toDelete);
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Racun Get(int id)
        {
            return this.racunRepository.Get(id);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IQueryable<Racun> GetAll(int page, int pageSize)
        {
            return this.racunRepository.GetAllAsQueryable().Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Racun model)
        {
            this.racunRepository.Update(model);
        }
        #endregion
    }
}
