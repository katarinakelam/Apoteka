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
    /// Nabavljac business service
    /// </summary>
    /// <seealso cref="Apoteka.BLL.BusinessServices.IService{Apoteka.Model.Models.Nabavljac}" />
    public class NabavljacService : IService<Nabavljac>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly NabavljacRepository nabavljacRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NabavljacService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NabavljacService(ApotekaContext context)
            : this(context, new NabavljacRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NabavljacService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public NabavljacService(ApotekaContext context, NabavljacRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.nabavljacRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Nabavljac model)
        {
            this.nabavljacRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.nabavljacRepository.Get(id);

            this.nabavljacRepository.Delete(toDelete);
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Nabavljac Get(int id)
        {
            return this.nabavljacRepository.Get(id);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IQueryable<Nabavljac> GetAll(int page, int pageSize)
        {
            return this.nabavljacRepository.GetAllAsQueryable().Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Nabavljac model)
        {
            this.nabavljacRepository.Update(model);
        }
        #endregion
    }
}
