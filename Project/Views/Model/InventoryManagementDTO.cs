using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class InventoryManagementDTO : AppointmentDTO,INotifyPropertyChanged
    {
        public List<EquipmentDTO> Equipment { get; set; }
        public RoomDTO RoomTo { get; set; }

        public InventoryManagementDTO() { }

        public InventoryManagementDTO(long id, DateTime beginning, DateTime end, RoomDTO room, RoomDTO roomTo)
        {
            Id = id;
            Beginning = beginning;
            End = end;
            Room = room;
            RoomTo = roomTo;
            Equipment = new List<EquipmentDTO>();
        }

        public InventoryManagementDTO(long id, DateTime beginning, DateTime end, RoomDTO room,List<EquipmentDTO> equipment, RoomDTO roomTo)
        {
            Id = id;
            Beginning = beginning;
            End = end;
            Room = room;
            Equipment = equipment;
            RoomTo = roomTo;
        }

        public InventoryManagementDTO(DateTime beginning, DateTime end, RoomDTO room)
        {
            Beginning = beginning;
            End = end;
            Room = room;
            Equipment = new List<EquipmentDTO>();
        }


    }
}
