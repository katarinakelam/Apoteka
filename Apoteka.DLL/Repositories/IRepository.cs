using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Apoteka.DLL.Repositories
{
    public interface IRepository<TModel>
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
        /// <param name="model">The model.</param>
        void Delete(TModel model);

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>
        /// Returns all instances of model
        /// </returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// Gets all instances of model as queryable.
        /// </summary>
        /// <returns>
        /// Returns  all instances of model as queryable.
        /// </returns>
        IQueryable<TModel> GetAllAsQueryable();
    }
}
