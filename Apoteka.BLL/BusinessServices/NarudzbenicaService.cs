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
    /// Narudzbenica business service
    /// </summary>
    /// <seealso cref="Apoteka.BLL.BusinessServices.IService{Apoteka.Model.Models.Narudzbenica}" />
    public class NarudzbenicaService : IService<Narudzbenica>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly NarudzbenicaRepository narudzbenicaRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NarudzbenicaService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NarudzbenicaService(ApotekaContext context)
            : this(context, new NarudzbenicaRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NarudzbenicaService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public NarudzbenicaService(ApotekaContext context, NarudzbenicaRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.narudzbenicaRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Narudzbenica model)
        {
            this.narudzbenicaRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.narudzbenicaRepository.Get(id);

            this.narudzbenicaRepository.Delete(toDelete);
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Narudzbenica Get(int id)
        {
            return this.narudzbenicaRepository.Get(id);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IQueryable<Narudzbenica> GetAll(int page, int pageSize)
        {
            return this.narudzbenicaRepository.GetAllAsQueryable().Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Narudzbenica model)
        {
            this.narudzbenicaRepository.Update(model);
        }
        #endregion
    }
}
