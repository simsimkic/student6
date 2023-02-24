using System;
using System.Collections.Generic;

namespace Project.Repositories.Abstract
{
    public interface IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        E GetById(ID id);
        IEnumerable<E> GetAll();
        E Save(E entity);
        E Update(E entity);
        E Remove(E entity);
        IEnumerable<E> Find(Func<E, bool> predicate);
    }
}
