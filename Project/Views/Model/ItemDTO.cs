using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class ItemDTO
    {
        public long Id;
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public ItemDTO() { }
        public ItemDTO(long id) { Id = id; }
        public ItemDTO(string name, string type, string description, int quantity)
        {
            Quantity = quantity;
            Type = type;
            Description = description;
            Name = name;
        }
        public ItemDTO(long id, string name, string type, string description, int quantity)
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
