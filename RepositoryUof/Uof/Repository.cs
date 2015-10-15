using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Uof
{
    // difference between dbset.Attach and dbset.Add : http://stackoverflow.com/questions/15950946/when-to-use-dbsett-add-vs-dbsett-attach
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public Repository(ContextType type)
        {
            _context = ContextFactory.GetContext(type);
            _dbSet = _context.Set<TEntity>();
        }

        #region CREATE
        public void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Added;
            //_dbSet.Add(entity);
            return;
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                this.Insert(entity);
            return;
        }
        #endregion

        #region READ
        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> GetAllPaged(int pageIndex, int pageSize)
        {
            return _dbSet
                .AsQueryable<TEntity>()
                .Skip<TEntity>((pageIndex - 1) * pageSize)
                .Take<TEntity>(pageSize);
        }

        public IQueryable<TEntity> GetAllPaged(int pageIndex, int pageSize, Expression<Func<TEntity, object>> sortingKeySelector)
        {
            return _dbSet
                .AsQueryable<TEntity>()
                .OrderBy<TEntity, object>(sortingKeySelector)
                .Skip<TEntity>((pageIndex - 1) * pageSize)
                .Take<TEntity>(pageSize);
        }

        public IQueryable<TEntity> GetAllPaged(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<TEntity, object>> sortingKeySelector, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Descending:
                    return _dbSet
                        .AsQueryable<TEntity>()
                        .OrderByDescending<TEntity, object>(sortingKeySelector)
                        .Skip<TEntity>((pageIndex - 1) * pageSize)
                        .Take<TEntity>(pageSize);

                default:
                case SortOrder.Unspecified:
                case SortOrder.Ascending:
                    return _dbSet
                        .AsQueryable<TEntity>()
                        .OrderBy<TEntity, object>(sortingKeySelector)
                        .Skip<TEntity>((pageIndex - 1) * pageSize)
                        .Take<TEntity>(pageSize);
            }
        }

        public IQueryable<TEntity> GetAllPaged<TKey>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<TEntity, TKey>> sortingKeySelector)
        {
            return _dbSet
                .AsQueryable<TEntity>()
                .OrderBy<TEntity, TKey>(sortingKeySelector)
                .Skip<TEntity>((pageIndex - 1) * pageSize)
                .Take<TEntity>(pageSize);
        }

        public IQueryable<TEntity> GetAllPaged<TKey>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<TEntity, TKey>> sortingKeySelector, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Descending:
                    return _dbSet
                        .AsQueryable<TEntity>()
                        .OrderByDescending<TEntity, TKey>(sortingKeySelector)
                        .Skip<TEntity>((pageIndex - 1) * pageSize)
                        .Take<TEntity>(pageSize);

                default:
                case SortOrder.Unspecified:
                case SortOrder.Ascending:
                    return _dbSet
                        .AsQueryable<TEntity>()
                        .OrderBy<TEntity, TKey>(sortingKeySelector)
                        .Skip<TEntity>((pageIndex - 1) * pageSize)
                        .Take<TEntity>(pageSize);
            }
        }

        public TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable<TEntity>();
        }

        public int Count()
        {
            return _dbSet
                .AsQueryable<TEntity>()
                .Count<TEntity>();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet
                .AsQueryable<TEntity>()
                .Count<TEntity>(predicate);
        }
        #endregion

        #region UPDATE
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Update(entity);
            return;
        }
        #endregion

        #region Delete
        public void Delete(object id)
        {
            TEntity entity = this.Find(id);
            this.Delete(entity);
            return;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return;
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Delete(entity);
            return;
        }
        #endregion

        public virtual void Commit()
        {
            _context.SaveChanges();
            return;
        }
    }


}
