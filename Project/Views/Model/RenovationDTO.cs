using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class RenovationDTO:AppointmentDTO
    {
        public string Type { get; set; }

        public RoomType NewType { get; set; }
        public RenovationDTO() { }

        public RenovationDTO(long id, DateTime beginning, DateTime end, RoomDTO room,string type,RoomType newType):
           base(id, beginning, end, room)
        {
            Type = type;
            NewType = newType;
        }

        public RenovationDTO(DateTime beginning, DateTime end, RoomDTO room, string type, RoomType newType) :
           base(beginning, end, room)
        {
            Type = type;
            NewType = newType;
        }
    }
}
