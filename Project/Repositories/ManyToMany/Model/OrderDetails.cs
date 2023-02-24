using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class OrderDetails : IIdentifiable<long>
    {
        public long Id;
        public long OrderId { get; set; }
        public long ItemId { get; set; }
        public long Quantity { get; set; }

        public OrderDetails() { }
        public OrderDetails(long orderId, long itemId, long quantity)
        {
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
        }
        public OrderDetails(long id, long orderId, long itemId, long quantity)
        {
            Id = id;
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}