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
    public class RoomRepository :
        CSVRepository<Room, long>,
        IRoomRepository,
        IEagerCSVRepository<Room, long>
    {
        private const string ENTITY_NAME = "Room";
        private readonly ItemCSVRepository<Equipment, Item, long> _equipmentRepository;

        public RoomRepository(
            ICSVStream<Room> stream,
            ISequencer<long> sequencer,
            ItemCSVRepository<Equipment, Item, long> equipmentRepository
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _equipmentRepository = equipmentRepository;
        }
        public new IEnumerable<Room> Find(Func<Room, bool> predicate) => GetAllEager().Where(predicate);
        public new Room Save(Room room)
        {
            if (IsRoomUnique(room.Id))
                return base.Save(room);
            else
                throw new Exception();
        }
        private bool IsRoomUnique(long id)
         => GetById(id) == null;
        private Room GetByIdNumber(long id)
        => base.GetById(id);

        public new IEnumerable<Room> GetAll()
        => GetAllEager();

        public IEnumerable<Room> GetAllEager()
        {
            List<Room> eagerRooms= new List<Room>();
            var rooms = base.GetAll();

            foreach (Room room in rooms)
                eagerRooms.Add(GetEager(room.Id));
            return eagerRooms;
        }

        public Room GetEager(long id)
        {
            var room = base.GetById(id);
            var equipment = _equipmentRepository.GetAll();
            room.Equipment = equipment.Where(eq => eq.Room.Id == id).ToList();
            return room;
        }

    }
}
