using ResidenceAdmin.DomainModel;
using System;
using System.Linq;

namespace ResidenceAdmin.Persistency
{
    public interface IPersistencyContext
    {
        TEntity Get<TEntity>(int id) where TEntity : Entity;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : Entity;
        void Insert<TEntity>(TEntity entity) where TEntity : Entity;
        void InsertRange<TEntity>(IQueryable<TEntity> entities) where TEntity : Entity;
        void Remove<TEntity>(int id) where TEntity : Entity;
        void RemoveRange<TEntity>() where TEntity : Entity;
        void SaveChanges();
    }
}
