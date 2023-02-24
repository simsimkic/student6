using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class InventoryManagement : Appointment
    {

        public List<Equipment> Equipment { get; set; }
        public Room RoomTo { get; set; }

        public InventoryManagement(long id, DateTime beginning, DateTime end, Room room, Room roomTo)
            : base(id, beginning, end, room)
        { 
            RoomTo = roomTo;
        }

        public InventoryManagement(long id, DateTime beginning, DateTime end, Room room, List<Equipment> equipment, Room roomTo)
            : base(id, beginning, end, room)
        {
            Equipment = equipment;
            RoomTo = roomTo;
        }
        public InventoryManagement(DateTime beginning, DateTime end, Room room)
            : base(beginning, end, room)
        { }

    }
}
