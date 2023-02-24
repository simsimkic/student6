using System.Runtime.ConstrainedExecution;
using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class OrderService: IService<Order,long>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll()
            => _orderRepository.GetAll();

        public Order GetById(long id)
            => _orderRepository.GetById(id);

        public Order Remove(Order entity)
            => _orderRepository.Remove(entity);

        public Order Save(Order entity) 
            => _orderRepository.Save(entity);

        public Order Update(Order entity)
            => _orderRepository.Update(entity);
    }
}