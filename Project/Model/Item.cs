using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Item : IIdentifiable<long>
    {
        public long Id;
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Item() { }
        public Item(long id) { Id = id; }
        public Item(int quantity, string type, string description, string name)
        {
            Quantity = quantity;
            Type = type;
            Description = description;
            Name = name;
        }

        public Item(long id, int quantity, string type, string description, string name)
        {
            Id = id;
            Quantity = quantity;
            Type = type;
            Description = description;
            Name = name;
        }
        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
