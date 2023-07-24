using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EntityService<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _dbSet;

        public EntityService(DbContext context)
        {
            _context = context;
        }

        public EntityService()
        {
            _context = new MyDbContext(
                "server = 127.0.0.1; port = 3306; user = root; password =root; database =rpsoft;Charset=utf8;Allow User Variables=True;SslMode=none");

            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public T FirstOrDefaultNoTracking(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }

        public int Update(T t)
        {
            t.EntityState = EntityState.Modified;
            return _context.SaveChanges();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        //public async Task InsertAsync(T entity)
        //{
        //    await _context.Set<T>().AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //}

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }


    //public abstract class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity
    //{
    //    private readonly LazyServiceFactory _lazyServiceFactory;

    //    protected EntityService(LazyServiceFactory lazyServiceFactory)
    //    {
    //        _lazyServiceFactory = lazyServiceFactory;
    //    }

    //    protected DbContext DbContext => _lazyServiceFactory.GetService<DbContext>();

    //    public virtual async Task<TEntity> FindAsync(long id)
    //    {
    //        return await DbContext.Set<TEntity>().FindAsync(id);
    //    }

    //    public virtual IQueryable<TEntity> GetAll()
    //    {
    //        return DbContext.Set<TEntity>();
    //    }

    //    public virtual async Task AddAsync(TEntity entity)
    //    {
    //        DbContext.Set<TEntity>().Add(entity);
    //        await DbContext.SaveChangesAsync();
    //    }

    //    public virtual async Task UpdateAsync(TEntity entity)
    //    {
    //        DbContext.Entry(entity).State = EntityState.Modified;
    //        await DbContext.SaveChangesAsync();
    //    }

    //    public virtual async Task DeleteAsync(TEntity entity)
    //    {
    //        DbContext.Set<TEntity>().Remove(entity);
    //        await DbContext.SaveChangesAsync();
    //    }
    //}

}
