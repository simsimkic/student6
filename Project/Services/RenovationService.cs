using Project.Model;
using Project.Repositories.Abstract;
using Project.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class RenovationService: IRenovationService
    {
        private readonly IRenovationRepository _renovationRepository;
        private readonly IRoomRepository _roomRepository;

        public RenovationService(IRenovationRepository renovationRepository, IRoomRepository roomRepository)
        {
            _renovationRepository = renovationRepository;
            _roomRepository = roomRepository;
        }

        public IEnumerable<Renovation> GetAll()
            => _renovationRepository.GetAll();

        public Renovation GetById(long id)
            => _renovationRepository.GetById(id);

        public Renovation Save(Renovation renovation)
            => _renovationRepository.Save(renovation);

        public Renovation Update(Renovation renovation)
            => _renovationRepository.Update(renovation);

        public Renovation Remove(Renovation renovation)
            => _renovationRepository.Remove(renovation);

        public void RealiseRenovation(Renovation renovation)
        {
            Room room = _roomRepository.GetById(renovation.Room.Id);
            if (renovation.Type.Equals("Rusenje"))
                _roomRepository.Remove(room);
            else if (renovation.Type.Equals("Pregradjivanje"))
            {
                room.Type = renovation.NewType;
                _roomRepository.Save(room);
            }
            else if(renovation.Type.Equals("Promena funkcije"))
            {
                room.Type = renovation.NewType;
                _roomRepository.Update(room);
            }
            Remove(renovation);
        }
    }
}
