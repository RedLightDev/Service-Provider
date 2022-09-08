using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Service_Provider.Infrastructure.Repository.Common;
public interface IRepository<TEntity> where TEntity : class
{
    void Delete(TEntity entityToDelete);
    void Delete(object id);
    IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");
    TEntity GetByID(object id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetWithRawSql(string query,
        params object[] parameters);
    void Insert(TEntity entity);
    Task<bool> InsertAsync(TEntity entity);
    TEntity InsertVal(TEntity entity);
    Task<EntityEntry<TEntity>> InsertValAsync(TEntity entity);
    void Update(TEntity entityToUpdate);
}


