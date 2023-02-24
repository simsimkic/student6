using System.IO.Pipes;
using System.Collections.Generic;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.ManyToMany.Repositories.Abstract;
using Project.Repositories.Sequencer;

namespace Project.Repositories.ManyToMany.Repositories
{
    public class OrderDetailsRepository : 
        CSVRepository<OrderDetails, long>,
        IOrderDetailsRepository,
        IEagerCSVRepository<OrderDetails, long>
    {
        private const string ENTITY_NAME = "OrderDetails";
        
        public OrderDetailsRepository(
            ICSVStream<OrderDetails> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }


        public IEnumerable<OrderDetails> GetAllEager()
        {
            throw new System.NotImplementedException();
        }

        public OrderDetails GetEager(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}