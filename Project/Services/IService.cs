using System.Collections.Generic;
namespace Project.Services
{
    public interface IService<E, ID> where E : class
    {
        E GetById(ID id);
        IEnumerable<E> GetAll();
        E Save(E entity);
        E Update(E entity);
        E Remove(E entity);
    }
}