using System.Collections.Generic;

namespace Services
{ 
    public interface IEntityService<TEntity> where TEntity : class, IEntity
    {
        //IEnumerable<TEntity> Find();
        //TEntity FindById(int id);
        //void Add(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(int id);
    }
}