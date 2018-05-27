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
    /// Korisnik business service
    /// </summary>
    /// <seealso cref="Apoteka.BLL.BusinessServices.IService{Korisnik}" />
    public class KorisnikService : IService<Korisnik>
    {
        #region Properties
        private readonly ApotekaContext apotekaContext;
        private readonly KorisnikRepository korisnikRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public KorisnikService(ApotekaContext context)
            : this(context, new KorisnikRepository(context))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KorisnikService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="repository">The repository.</param>
        public KorisnikService(ApotekaContext context, KorisnikRepository repository)
        {
            this.apotekaContext = context ?? throw new ArgumentNullException(nameof(context));
            this.korisnikRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Create(Korisnik model)
        {
            this.korisnikRepository.Create(model);
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var toDelete = this.korisnikRepository.Get(id);

            this.korisnikRepository.Delete(toDelete);
        }

        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        public Korisnik Get(int id)
        {
            return this.korisnikRepository.Get(id);
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        public IQueryable<Korisnik> GetAll(int page, int pageSize)
        {
            return this.korisnikRepository.GetAllAsQueryable().Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Korisnik model)
        {
            this.korisnikRepository.Update(model);
        }
        #endregion
    }
}
