using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apoteka.BLL.BusinessServices
{
    /// <summary>
    /// Interface for business services
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IService<TModel>
    {
        /// <summary>
        /// Gets model by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the specified model
        /// </returns>
        TModel Get(int id);

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(TModel model);

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns the identifier of the new model
        /// </returns>
        void Create(TModel model);

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        IQueryable<TModel> GetAll(int page, int pageSize);
    }
}
