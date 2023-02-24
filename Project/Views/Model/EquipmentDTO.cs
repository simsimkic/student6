using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class EquipmentDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public RoomDTO Room { get; set; }

        public EquipmentDTO() { }

        public EquipmentDTO(long id, string name,string type, string description,RoomDTO room)  
        {
            Id = id;
            Type = type;
            Description = description;
            Name = name;
            Room = room;
        }

        public EquipmentDTO(string name, string type, string description,RoomDTO room)
        {
            Type = type;
            Description = description;
            Name = name; 
            Room = room;
        }

    }
}
