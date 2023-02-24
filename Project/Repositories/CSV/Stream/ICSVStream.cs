using System.Collections.Generic;

namespace Project.Repositories.CSV.Stream
{
    
    public interface ICSVStream<E>
    {
        void SaveAll(IEnumerable<E> entities);
        IEnumerable<E> ReadAll();
        void AppendToFile(E entity);
    }
}