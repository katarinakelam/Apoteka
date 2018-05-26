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
    /// Proizvodjac business service
    /// </summary>
    /// <seealso cref="Apoteka.BLL.BusinessServices.IService{Apoteka.Model.Models.Proizvodjac}" />
    public class ProizvodjacService : IService<Proizvodjac>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly ProizvodjacRepository proizvodjacRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProizvodjacService(ApotekaContext context)
            : this(context, new ProizvodjacRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProizvodjacService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public ProizvodjacService(ApotekaContext context, ProizvodjacRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.proizvodjacRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Proizvodjac model)
        {
            this.proizvodjacRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.proizvodjacRepository.Get(id);

            this.proizvodjacRepository.Delete(toDelete);
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Proizvodjac Get(int id)
        {
            return this.proizvodjacRepository.Get(id);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<Proizvodjac> GetAll(int page, int pageSize)
        {
            return this.proizvodjacRepository.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Proizvodjac model)
        {
            this.proizvodjacRepository.Update(model);
        }
        #endregion
    }
}
