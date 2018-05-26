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
    /// Radno mjesto business service
    /// </summary>
    /// <seealso cref="Apoteka.BLL.BusinessServices.IService{Apoteka.Model.Models.RadnoMjesto}" />
    public class RadnoMjestoService : IService<RadnoMjesto>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly RadnoMjestoRepository radnoMjestoRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RadnoMjestoService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RadnoMjestoService(ApotekaContext context)
            : this(context, new RadnoMjestoRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RadnoMjestoService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public RadnoMjestoService(ApotekaContext context, RadnoMjestoRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.radnoMjestoRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(RadnoMjesto model)
        {
            this.radnoMjestoRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.radnoMjestoRepository.Get(id);

            this.radnoMjestoRepository.Delete(toDelete);
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
            return this.radnoMjestoRepository.Get(id);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IEnumerable<RadnoMjesto> GetAll(int page, int pageSize)
        {
            return this.radnoMjestoRepository.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(RadnoMjesto model)
        {
            this.radnoMjestoRepository.Update(model);
        }
        #endregion
    }
}
