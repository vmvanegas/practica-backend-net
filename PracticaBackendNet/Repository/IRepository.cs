﻿using PracticaBackendNet.Models;

namespace PracticaBackendNet.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
        IEnumerable<Beer> Search(Func<TEntity, bool> filter);
    }
}
