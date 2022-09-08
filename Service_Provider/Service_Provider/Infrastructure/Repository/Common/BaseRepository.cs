using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Service_Provider.Infrastructure.Repository.Contracts;
using System.Linq.Expressions;

namespace Service_Provider.Infrastructure.Repository.Common;

    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ServiceDBContext context;
        internal DbSet<TEntity> dbSet;
        //Apply if needed Contact Developement Team Lead//internal IUnitOfWork<TEntity> _repositories = new UnitOfWork<TEntity>();
        public BaseRepository(ServiceDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters)
        {
            return null;//dbSet.FromSql(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }
        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public virtual TEntity InsertVal(TEntity entity)
        {
            var val = dbSet.Add(entity);
            context.SaveChanges();
            return val.Entity;
        }
        public virtual async Task<EntityEntry<TEntity>> InsertValAsync(TEntity entity)
        {
            try
            {
                var val = await dbSet.AddAsync(entity);
                context.SaveChanges();
                return val;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            context.SaveChanges();
        }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Update(entityToUpdate);
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }


