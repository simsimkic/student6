using System.Collections.Generic;

namespace Project.Controllers
{
    public interface IController<E, ID> where E : class
    {
        IEnumerable<E> GetAll();
        E GetById(ID id);
        E Save(E entity);
        E Update(E entity);
        E Remove(E entity);
         
    }
}