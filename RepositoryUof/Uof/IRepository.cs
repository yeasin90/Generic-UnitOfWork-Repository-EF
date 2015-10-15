using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Uof
{
    public interface IRepository<TEntity>
    {
        #region CREATE
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);

        #endregion

        #region READ
        TEntity Get(object id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllPaged(int pageIndex, int pageSize);
        IQueryable<TEntity> GetAllPaged(int pageIndex, int pageSize, Expression<Func<TEntity, object>> sortingKeySelector);
        IQueryable<TEntity> GetAllPaged(int pageIndex, int pageSize, Expression<Func<TEntity, object>> sortingKeySelector, SortOrder sortOrder);
        IQueryable<TEntity> GetAllPaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> sortingKeySelector);
        IQueryable<TEntity> GetAllPaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> sortingKeySelector, SortOrder sortOrder);
        TEntity Find(object id);
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region UPDATE
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        #endregion

        #region Delete
        void Delete(object id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        #endregion

        void Commit();
    }
}
