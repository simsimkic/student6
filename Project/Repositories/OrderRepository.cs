using System.IO;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class OrderRepository : 
        CSVRepository<Order, long>,
        IOrderRepository,
        IEagerCSVRepository<Order, long>
    {
        private const string ENTITY_NAME = "Order";
        private readonly IRepository<Medicine,long> _medicineRepository;
        private readonly IRepository<Equipment, long> _equipmentRepository;
        private readonly IRepository<MedicalConsumables, long> _consumablesRepository;
        private readonly IRepository<OrderDetails, long> _orderDetailsRepository;

        public OrderRepository(
            ICSVStream<Order> stream,
            IRepository<Medicine, long> medicineRepository,
            IRepository<Equipment, long> equipmentRepository,
            IRepository<MedicalConsumables, long> consumablesRepository,
            IRepository<OrderDetails, long> orderDetailsRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _medicineRepository = medicineRepository;
            _equipmentRepository = equipmentRepository;
            _consumablesRepository = consumablesRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public new IEnumerable<Order> Find(Func<Order, bool> predicate) => GetAllEager().Where(predicate);
        public IEnumerable<Order> GetAllEager() => GetAll();
        public Order GetEager(long id) => GetById(id);
        public new Order Save(Order entity)
        {
            Order order = base.Save(entity);
            foreach (MedicalConsumables cons in order.Consumebles)
                _orderDetailsRepository.Save( new OrderDetails(order.Id, cons.Id, cons.Quantity)); 

            foreach (Medicine med in order.Medicine)
                _orderDetailsRepository.Save( new OrderDetails(order.Id, med.Id, med.Quantity)); 

            foreach (Equipment eq in order.Equipments)
                _orderDetailsRepository.Save( new OrderDetails(order.Id, eq.Id, 1)); 

            return order;


        }
    }
}
