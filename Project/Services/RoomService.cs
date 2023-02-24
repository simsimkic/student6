using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class RoomService:IService<Room,long>
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
            => _roomRepository.GetAll();

        public Room GetById(long id)
            => _roomRepository.GetById(id);

        public Room Save(Room room)
            => _roomRepository.Save(room);

        public Room Update(Room room)
            => _roomRepository.Update(room);

        public Room Remove(Room room)
            => _roomRepository.Remove(room);



    }
}
